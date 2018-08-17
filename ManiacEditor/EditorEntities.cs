using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace ManiacEditor
{
    class EditorEntities : IDrawable
    {
        public static bool SceneWithoutFilters = false;
        public static bool FirstEntity = true;
        public static bool FilterRefreshNeeded = false;
        public static int DefaultFilter = -1;

        List<EditorEntity> entities = new List<EditorEntity>();
        List<EditorEntity> selectedEntities = new List<EditorEntity>();
        List<EditorEntity> tempSelection = new List<EditorEntity>();

        Dictionary<ushort, EditorEntity> entitiesBySlot = new Dictionary<ushort, EditorEntity>();

        ushort nextFreeSlot = 0;

        public List<EditorEntity> Entities { get { return entities; } }
        public List<EditorEntity> SelectedEntities { get { return selectedEntities; } }

        public class TooManyEntitiesException : Exception { }

        public Actions.IAction LastAction;


        public EditorEntities(RSDKv5.Scene scene)
        {
            foreach (var obj in scene.Objects)
            {
                entities.AddRange(obj.Entities.Select(x => GenerateEditorEntity(x)));
            }
            entitiesBySlot = entities.ToDictionary(x => x.Entity.SlotID);
        }

        private ushort getFreeSlot(RSDKv5.SceneEntity preferred)
        {
            if (preferred != null && !entitiesBySlot.ContainsKey(preferred.SlotID)) return preferred.SlotID;
            while (entitiesBySlot.ContainsKey(nextFreeSlot))
            {
                ++nextFreeSlot;
            }
            if (nextFreeSlot == 2048)
            {
                if (entitiesBySlot.Count < 2048)
                {
                    // Next time search from beggining
                    nextFreeSlot = 0;
                }
                throw new TooManyEntitiesException();
            }
            return nextFreeSlot++;
        }

        public void Select(Rectangle area, bool addSelection = false, bool deselectIfSelected = false)
        {
            if (!addSelection) Deselect();
            foreach (var entity in entities)
            {
                if (entity.IsInArea(area))
                {
                    if (deselectIfSelected && selectedEntities.Contains(entity))
                    {
                        selectedEntities.Remove(entity);
                        entity.Selected = false;
                    }
                    else if (!selectedEntities.Contains(entity))
                    {
                        selectedEntities.Add(entity);
                        entity.Selected = true;
                    }
                }
            }
        }

        public void Select(Point point, bool addSelection = false, bool deselectIfSelected = false)
        {
            if (!addSelection) Deselect();
            // In reverse because we want to select the top one
            foreach (EditorEntity entity in entities.Reverse<EditorEntity>())
            {
                if (entity.ContainsPoint(point))
                {
                    if (deselectIfSelected && selectedEntities.Contains(entity))
                    {
                        selectedEntities.Remove(entity);
                        entity.Selected = false;
                    }
                    else
                    {
                        selectedEntities.Add(entity);
                        entity.Selected = true;
                    }
                    // Only the top
                    break;
                }
            }
        }

        public void SelectSlot(int slot)
        {
            Deselect();
            if (entitiesBySlot.ContainsKey((ushort)slot))
            {
                selectedEntities.Add(entitiesBySlot[(ushort)slot]);
                entitiesBySlot[(ushort)slot].Selected = true;
            }
        }

        private void AddEntities(List<EditorEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Entity.Object.Entities.Add(entity.Entity);
                this.entities.Add(entity);
                entitiesBySlot[entity.Entity.SlotID] = entity;
            }
        }

        private void DeleteEntities(List<EditorEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.Entity.Object.Entities.Remove(entity.Entity);
                this.entities.Remove(entity);
                entitiesBySlot.Remove(entity.Entity.SlotID);
                if (entity.Entity.SlotID < nextFreeSlot) nextFreeSlot = entity.Entity.SlotID;
            }
        }

        private void DuplicateEntities(List<EditorEntity> entities)
        {
            if (null == entities || !entities.Any()) return;
            
            var new_entities = entities.Select(x => GenerateEditorEntity(new RSDKv5.SceneEntity(x.Entity, getFreeSlot(x.Entity)))).ToList();
            if (new_entities.Count > 0)
                LastAction = new Actions.ActionAddDeleteEntities(new_entities.ToList(), true, x => AddEntities(x), x => DeleteEntities(x));
            AddEntities(new_entities);
            Deselect();
            selectedEntities.AddRange(new_entities);
            foreach (var entity in new_entities)
                entity.Selected = true;
        }

        public void MoveSelected(Point oldPos, Point newPos, bool duplicate)
        {
            Point diff = new Point(newPos.X - oldPos.X, newPos.Y - oldPos.Y);
            if (duplicate) DuplicateEntities(selectedEntities);
            foreach (var entity in selectedEntities)
            {
                entity.Move(diff);
            }
        }

        public bool IsSelected()
        {
            return selectedEntities.Count > 0 || tempSelection.Count > 0;
        }

        public void DeleteSelected()
        {
            if (selectedEntities.Count > 0)
                LastAction = new Actions.ActionAddDeleteEntities(selectedEntities.ToList(), false, x => AddEntities(x), x => DeleteEntities(x));
            DeleteEntities(selectedEntities);
            Deselect();
        }

        public List<EditorEntity> CopyToClipboard(bool keepPosition = false)
        {
            if (selectedEntities.Count == 0) return null;
            short minX = 0, minY = 0;

            List<EditorEntity> copiedEntities = selectedEntities.Select(x => GenerateEditorEntity(new RSDKv5.SceneEntity(x.Entity, x.Entity.SlotID))).ToList();
            if (!keepPosition)
            {
                minX = copiedEntities.Min(x => x.Entity.Position.X.High);
                minY = copiedEntities.Min(x => x.Entity.Position.Y.High);
                copiedEntities.ForEach(x => x.Move(new Point(-minX, -minY)));
            }

            return copiedEntities;
        }

        public void PasteFromClipboard(Point newPos, List<EditorEntity> entities)
        {
            DuplicateEntities(entities);
            foreach (var entity in selectedEntities)
            {
                // Move them
                entity.Move(newPos);
            }
        }

        public EditorEntity GetEntityAt(Point point)
        {
            foreach (EditorEntity entity in entities.Reverse<EditorEntity>())
                if (entity.ContainsPoint(point))
                    return entity;
            return null;
        }

        public void TempSelection(Rectangle area, bool deselectIfSelected)
        {
            List<EditorEntity> newSelection = (from entity in entities where entity.IsInArea(area) select entity).ToList();

            foreach (var entity in (from entity in tempSelection where !newSelection.Contains(entity) select entity))
            {
                entity.Selected = selectedEntities.Contains(entity);
            }

            tempSelection = newSelection;

            foreach (var entity in newSelection)
            {
                entity.Selected = !deselectIfSelected || !selectedEntities.Contains(entity);
            }
        }
        public void Deselect()
        {
            foreach (var entity in entities)
            {
                entity.Selected = false;
            }
            selectedEntities.Clear();
        }

        public void EndTempSelection()
        {
            tempSelection.Clear();
        }

        public void Draw(Graphics g)
        {

        }

        public void Draw(DevicePanel d)
        {
            if (FilterRefreshNeeded)
                UpdateViewFilters();
            foreach (var entity in entities)
                entity.Draw(d);
        }

        /// <summary>
        /// Creates a new instance of the given SceneObject at the indicated position.
        /// </summary>
        /// <param name="sceneObject">Type of SceneObject to create an instance of.</param>
        /// <param name="position">Location to insert into the scene.</param>
        public void Add(RSDKv5.SceneObject sceneObject, RSDKv5.Position position)
        {
            var editorEntity = GenerateEditorEntity(new RSDKv5.SceneEntity(sceneObject, getFreeSlot(null)));
            editorEntity.Entity.Position = position;
            var newEntities = new List<EditorEntity> { editorEntity };
            LastAction = new Actions.ActionAddDeleteEntities(newEntities, true, x => AddEntities(x), x => DeleteEntities(x));
            AddEntities(newEntities);

            Deselect();
            editorEntity.Selected = true;
            selectedEntities.Add(editorEntity);
        }

        private EditorEntity GenerateEditorEntity(RSDKv5.SceneEntity sceneEntity)
        {
            try
            {
                // ideally this would be driven by configuration...one day
                // or can we assume anything with a "Go" and "Tag" Attributes is linked to another?
                if (sceneEntity.Object.Name.ToString().Equals("WarpDoor", StringComparison.InvariantCultureIgnoreCase))
                {
                    return new LinkedEditorEntity(sceneEntity);
                }
            }
            catch
            {
                Debug.WriteLine("Failed to generate a LinkedEditorEntity, will create a basic one instead.");
            }

            EditorEntity entity = new EditorEntity(sceneEntity);

            // Check the first entity spawned to see if this Scene uses filters
            if (FirstEntity)
            {
                FirstEntity = false;

                // Try to get "filter"
                try
                {
                    int filter = entity.Entity.GetAttribute("filter").ValueUInt8;
                }

                // If this is an old Scene that doesn't have them, disable future filter checks
                catch (KeyNotFoundException)
                {
                    SceneWithoutFilters = true;
                }
            }

            if (!SceneWithoutFilters && DefaultFilter > -1)
            {
                entity.Entity.GetAttribute("filter").ValueUInt8 = (byte)DefaultFilter;
                DefaultFilter = -1;
            }

            entity.SetFilter();

            return entity;
        }

        public void UpdateViewFilters()
        {
            FilterRefreshNeeded = false;
            foreach (EditorEntity entity in entities)
                entity.SetFilter();
        }

        public static void ResetFilterStuff()
        {
            SceneWithoutFilters = false;
            FirstEntity = true;
            FilterRefreshNeeded = false;
        }

    }
}
