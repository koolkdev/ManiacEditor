using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ManiacEditor.Actions
{
    class ActionMoveEntities : IAction
    {
        List<EditorEntity> entities;
        Point diff;
        bool key;

        public ActionMoveEntities(List<EditorEntity> entities, Point diff, bool key=false)
        {
            this.entities = entities;
            this.diff = new Point(-diff.X, -diff.Y);
            this.key = key;
        }

        public bool UpdateFromKey(List<EditorEntity> entities, Point change)
        {
            if (!key) return false;
            if (entities.Count != this.entities.Count) return false;
            for (int i = 0; i < entities.Count; ++i)
                if (entities[i] != this.entities[i])
                    return false;

            diff.X -= change.X;
            diff.Y -= change.Y;
            return true;
        }

        public void Undo()
        {
            foreach (var entity in entities)
                entity.Move(diff);
        }

        public IAction Redo()
        {
            // Don't pass key, because we don't want to merge with it after 
            return new ActionMoveEntities(entities, diff);
        }
    }
}
