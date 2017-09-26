using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RSDKv5;
using ManiacEditor.Actions;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    class EditorLayer : IDrawable
    {
        public SceneLayer Layer;

        const int TILES_CHUNK_SIZE = 16;

        public const int TILE_SIZE = 16;

        static float[] verticesBuffer = new float[TILE_SIZE * TILE_SIZE * 8];
        static float[] textCoordsBuffer = new float[TILE_SIZE * TILE_SIZE * 8];
        static uint[] indicesBuffer = new uint[TILE_SIZE * TILE_SIZE * 8];
        ChunkVBO[][] chunks;
        ChunkVBO[][] selectedChunks;
        ChunkVBO selectedOOB;
        Texture2D texture;

        public PointsMap SelectedTiles;
        public Dictionary<Point, ushort> SelectedTilesValue = new Dictionary<Point, ushort>();

        public PointsMap TempSelectionTiles;
        bool TempSelectionDeselect;

        Rectangle tempSelectionArea;

        Point draggedDistance;
        bool dragging;
        
        bool isDragOver;

        public List<IAction> Actions = new List<IAction>();

        static int DivideRoundUp(int number, int by)
        {
            return (number + by - 1) / by;
        }

        class ChunkVBO
        {
            public Vertices Vertices;
            public bool VerticesUpdated = false;
            public TexCoords TexCoords;
            public bool TexCoordsUpdated = false;
            public Indices SelectIndices;
        }

        public class PointsMap
        {
            HashSet<Point>[][] PointsChunks;
            HashSet<Point> OutOfBoundsPoints = new HashSet<Point>();
            public HashSet<Point> ChangedChunks = new HashSet<Point>();
            public int Count = 0;

            public PointsMap(int width, int height)
            {
                PointsChunks = new HashSet<Point>[DivideRoundUp(height, TILES_CHUNK_SIZE)][];
                for (int i = 0; i < PointsChunks.Length; ++i)
                {
                    PointsChunks[i] = new HashSet<Point>[DivideRoundUp(width, TILES_CHUNK_SIZE)];
                    for (int j = 0; j < PointsChunks[i].Length; ++j)
                        PointsChunks[i][j] = new HashSet<Point>();
                }
            }

            public void Add(Point point)
            {
                HashSet<Point> h;
                if (point.Y < 0 || point.X < 0 || point.Y / TILES_CHUNK_SIZE >= PointsChunks.Length || point.X / TILES_CHUNK_SIZE >= PointsChunks[0].Length)
                    h = OutOfBoundsPoints;
                else
                {
                    h = PointsChunks[point.Y / TILES_CHUNK_SIZE][point.X / TILES_CHUNK_SIZE];
                    ChangedChunks.Add(new Point(point.X / TILES_CHUNK_SIZE, point.Y / TILES_CHUNK_SIZE));
                }
                Count -= h.Count;
                h.Add(point);
                Count += h.Count;
            }
            
            public void Remove(Point point)
            {
                HashSet<Point> h;
                if (point.Y < 0 || point.X < 0 || point.Y / TILES_CHUNK_SIZE >= PointsChunks.Length || point.X / TILES_CHUNK_SIZE >= PointsChunks[0].Length)
                    h = OutOfBoundsPoints;
                else
                {
                    h = PointsChunks[point.Y / TILES_CHUNK_SIZE][point.X / TILES_CHUNK_SIZE];
                    ChangedChunks.Add(new Point(point.X / TILES_CHUNK_SIZE, point.Y / TILES_CHUNK_SIZE));
                }
                Count -= h.Count;
                h.Remove(point);
                ChangedChunks.Add(new Point(point.X / TILES_CHUNK_SIZE, point.Y / TILES_CHUNK_SIZE));
                Count += h.Count;
            }

            public bool Contains(Point point)
            {
                if (point.Y < 0 || point.X < 0 || point.Y / TILES_CHUNK_SIZE >= PointsChunks.Length || point.X / TILES_CHUNK_SIZE >= PointsChunks[0].Length)
                    return OutOfBoundsPoints.Contains(point);
                else
                    return PointsChunks[point.Y / TILES_CHUNK_SIZE][point.X / TILES_CHUNK_SIZE].Contains(point);
            }

            public bool IsChunkUsed(int x, int y)
            {
                return PointsChunks[y][x].Count > 0;
            }

            public void Clear()
            {
                for (int i = 0; i < PointsChunks.Length; ++i)
                {
                    for (int j = 0; j < PointsChunks[i].Length; ++j)
                    {
                        if (PointsChunks[i][j].Count > 0)
                            ChangedChunks.Add(new Point(j, i));
                        PointsChunks[i][j].Clear();
                    }
                }
                OutOfBoundsPoints.Clear();
                Count = 0;
            }

            public HashSet<Point> GetChunkPoint(int x, int y)
            {
                return PointsChunks[y][x];
            }

            public List<Point> PopAll()
            {
                List<Point> points = GetAll();
                Clear();
                return points;
            }

            public List<Point> GetAll()
            {
                List<Point> points = new List<Point>(Count);
                for (int i = 0; i < PointsChunks.Length; ++i)
                    for (int j = 0; j < PointsChunks[i].Length; ++j)
                        points.AddRange(PointsChunks[i][j]);
                points.AddRange(OutOfBoundsPoints);
                return points;
            }

            public void AddPoints(List<Point> points)
            {
                points.ForEach(point => Add(point));
            }

            public HashSet<Point> GetOOB()
            {
                return OutOfBoundsPoints;
            }


        }

        public EditorLayer(SceneLayer layer)
        {
            this.Layer = layer;

            chunks = new ChunkVBO[DivideRoundUp(this.Layer.Height, TILES_CHUNK_SIZE)][];
            for (int i = 0; i < chunks.Length; ++i)
            {
                chunks[i] = new ChunkVBO[DivideRoundUp(this.Layer.Width, TILES_CHUNK_SIZE)];
                for (int j = 0; j < chunks[i].Length; ++j)
                {
                    // We can use the same buffers because we fill each chunk at a time
                    chunks[i][j] = new ChunkVBO();
                    chunks[i][j].Vertices = new Vertices(verticesBuffer);
                    chunks[i][j].TexCoords = new TexCoords(textCoordsBuffer, TILE_SIZE, TILE_SIZE * 0x400);
                }
            }

            selectedChunks = new ChunkVBO[DivideRoundUp(this.Layer.Height, TILES_CHUNK_SIZE)][];
            for (int i = 0; i < selectedChunks.Length; ++i)
            {
                selectedChunks[i] = new ChunkVBO[DivideRoundUp(this.Layer.Width, TILES_CHUNK_SIZE)];
                for (int j = 0; j < selectedChunks[i].Length; ++j)
                {
                    selectedChunks[i][j] = new ChunkVBO();
                    selectedChunks[i][j].Vertices = new Vertices(verticesBuffer);
                    selectedChunks[i][j].TexCoords = new TexCoords(textCoordsBuffer, TILE_SIZE, TILE_SIZE * 0x400);
                    selectedChunks[i][j].SelectIndices = new Indices(indicesBuffer);
                }
            }

            selectedOOB = new ChunkVBO();
            selectedOOB.TexCoords = new TexCoords(null, TILE_SIZE, TILE_SIZE * 0x400);
            selectedOOB.Vertices = new Vertices(null);
            selectedOOB.SelectIndices = new Indices(null);

            SelectedTiles = new PointsMap(this.Layer.Width, this.Layer.Height);
            TempSelectionTiles = new PointsMap(this.Layer.Width, this.Layer.Height);
        }

        public bool IsTriggerDrag(Point oldPos, Point newPos)
        {
            oldPos = new Point(oldPos.X / TILE_SIZE, oldPos.Y / TILE_SIZE);
            newPos = new Point(newPos.X / TILE_SIZE, newPos.Y / TILE_SIZE);
            return oldPos != newPos;
        }

        public void StartDrag(bool duplicate)
        {
            List<Point> newPoints = SelectedTiles.PopAll();
            Dictionary<Point, ushort> newDict = new Dictionary<Point, ushort>();
            foreach (Point point in newPoints)
            {
                if (SelectedTilesValue.ContainsKey(point))
                {
                    newDict[point] = SelectedTilesValue[point];
                }
                else
                {
                    // Not moved yet
                    newDict[point] = Layer.Tiles[point.Y][point.X];
                    if (!duplicate) RemoveTile(point);
                }
            }
            if (duplicate)
            {
                Deselect();
                // Create new actions group
                Actions.Add(new ActionDummy());
            }
            SelectedTilesValue = newDict;
            SelectedTiles.AddPoints(newPoints);
            InvalidateSelectedChunks();

            selectedOOB.TexCoordsUpdated = false;
            selectedOOB.VerticesUpdated = false;

            dragging = true;
            draggedDistance = Point.Empty;
        }

        public void UpdateDrag(Point oldPos, Point newPos)
        {
            oldPos = new Point(oldPos.X / TILE_SIZE, oldPos.Y / TILE_SIZE);
            newPos = new Point(newPos.X / TILE_SIZE, newPos.Y / TILE_SIZE);
            draggedDistance = new Point(newPos.X - oldPos.X, newPos.Y - oldPos.Y);
        }

        public void EndDrag(Point oldPos, Point newPos)
        {
            dragging = false;
            MoveSelected(oldPos, newPos, false, true);

            selectedOOB.Vertices.SetBuffer(null);
            selectedOOB.SelectIndices.SetBuffer(null);
            selectedOOB.TexCoords.SetBuffer(null);
        }

        public void StartDragOver(Point point, ushort value)
        {
            Deselect();
            isDragOver = true;
            DragOver(point, value);
        }

        public void DragOver(Point point, ushort value)
        {
            SelectedTiles.Clear();
            SelectedTilesValue.Clear();
            point = new Point(point.X / TILE_SIZE, point.Y / TILE_SIZE);
            SelectedTiles.Add(point);
            InvalidateSelectedChunks();
            SelectedTilesValue[point] = value;
        }

        public void EndDragOver(bool remove)
        {
            if (isDragOver)
            {
                if (remove)
                {
                    SelectedTiles.Clear();
                    SelectedTilesValue.Clear();
                }
                isDragOver = false;
            }
            InvalidateSelectedChunks();
        }

        private void DetachSelected()
        {
            foreach (Point point in SelectedTiles.GetAll())
            {
                if (!SelectedTilesValue.ContainsKey(point))
                {
                    // Not moved yet
                    SelectedTilesValue[point] = Layer.Tiles[point.Y][point.X];
                    RemoveTile(point);
                }
            }
        }

        public void MoveSelected(Point oldPos, Point newPos, bool duplicate=false, bool forceUpdate=false)
        {
            oldPos = new Point(oldPos.X / TILE_SIZE, oldPos.Y / TILE_SIZE);
            newPos = new Point(newPos.X / TILE_SIZE, newPos.Y / TILE_SIZE);
            if (oldPos != newPos)
            {
                Dictionary<Point, ushort> newDict = new Dictionary<Point, ushort>();
                List<Point> newPoints = new List<Point>(SelectedTiles.Count);
                foreach (Point point in SelectedTiles.PopAll())
                {
                    Point newPoint = new Point(point.X + (newPos.X - oldPos.X), point.Y + (newPos.Y - oldPos.Y));
                    newPoints.Add(newPoint);
                    if (SelectedTilesValue.ContainsKey(point))
                    {
                        newDict[newPoint] = SelectedTilesValue[point];
                    }
                    else
                    {
                        // Not moved yet
                        newDict[newPoint] = Layer.Tiles[point.Y][point.X];
                        if (!duplicate) RemoveTile(point);
                    }
                }
                if (duplicate)
                {
                    Deselect();
                    // Create new actions group
                    Actions.Add(new ActionDummy());
                }
                SelectedTilesValue = newDict;
                SelectedTiles.AddPoints(newPoints);
                InvalidateSelectedChunks();
            }
            else if (forceUpdate)
            {
                for (int y = 0; y < chunks.Length; ++y)
                    for (int x = 0; x < chunks[0].Length; ++x)
                        if (SelectedTiles.IsChunkUsed(x, y))
                            SelectedTiles.ChangedChunks.Add(new Point(x, y));
                InvalidateSelectedChunks();
            }
        }

        public void MoveSelectedQuonta(Point change)
        {
            MoveSelected(Point.Empty, new Point(change.X * TILE_SIZE, change.Y * TILE_SIZE), false);
        }

        public void DeleteSelected()
        {
            bool removedSomething = SelectedTiles.Count > 0;
            foreach (Point p in SelectedTiles.PopAll())
            {
                // Remove only tiles that not moved, because we already removed the moved tiles
                if (!SelectedTilesValue.ContainsKey(p))
                {
                    RemoveTile(p);
                }
            }
            if (removedSomething)
                Actions.Add(new ActionsGroupCloseMarker());
            SelectedTilesValue.Clear();
        }

        public void FlipPropertySelected(ushort bit)
        {
            DetachSelected();

            List<Point> points = new List<Point>(SelectedTilesValue.Keys);
            foreach (Point point in points)
            {
                SelectedTilesValue[point] ^= bit;
            }
        }

        public void SetPropertySelected(int bit, bool state)
        {
            DetachSelected();

            List<Point> points = new List<Point>(SelectedTilesValue.Keys);
            foreach (Point point in points)
            {
                if (state)
                    SelectedTilesValue[point] |= (ushort)(1 << bit);
                else
                    SelectedTilesValue[point] &= (ushort)(~(1 << bit));
            }
        }

        public List<ushort> GetSelectedValues()
        {
            // Including temp selection
            List<ushort> selectedValues = new List<ushort>();
            foreach (Point point in SelectedTiles.GetAll())
            {
                if (TempSelectionDeselect && TempSelectionTiles.Contains(point)) continue;
                if (SelectedTilesValue.ContainsKey(point))
                {
                    selectedValues.Add(SelectedTilesValue[point]);
                }
                else
                {
                    // Not moved yet
                    selectedValues.Add(Layer.Tiles[point.Y][point.X]);
                }
            }
            foreach (Point point in TempSelectionTiles.GetAll())
            {
                if (SelectedTiles.Contains(point)) continue;
                selectedValues.Add(Layer.Tiles[point.Y][point.X]);
            }
            return selectedValues;
        }

        public Dictionary<Point, ushort> CopyToClipboard(bool keepPosition = false)
        {
            if (SelectedTiles.Count == 0) return null;
            int minX = 0, minY = 0;

            Dictionary<Point, ushort> copiedTiles = new Dictionary<Point, ushort>(SelectedTilesValue);;
            foreach (Point point in SelectedTiles.GetAll())
            {
                if (!copiedTiles.ContainsKey(point))
                {
                    // Not moved yet
                    copiedTiles[point] = GetTile(point);
                }
            }
            if (!keepPosition)
            {
                minX = copiedTiles.Keys.Min(x => x.X);
                minY = copiedTiles.Keys.Min(x => x.Y);
            }
            return copiedTiles.ToDictionary(x => new Point(x.Key.X - minX, x.Key.Y - minY), x => x.Value);
        }

        public void PasteFromClipboard(Point newPos, Dictionary<Point, ushort> points)
        {
            newPos = new Point(newPos.X / TILE_SIZE, newPos.Y / TILE_SIZE);
            Deselect();
            foreach (KeyValuePair<Point, ushort> point in points)
            {
                Point tilePos = new Point(point.Key.X + newPos.X, point.Key.Y + newPos.Y);
                SelectedTiles.Add(tilePos);
                SelectedTilesValue[tilePos] = point.Value;
            }
            InvalidateSelectedChunks();
            // Create new actions group
            Actions.Add(new ActionDummy());
        }

        public void Select(Rectangle area, bool addSelection = false, bool deselectIfSelected = false)
        {
            if (!addSelection) Deselect();
            for (int y = Math.Max(area.Y / TILE_SIZE, 0); y < Math.Min(DivideRoundUp(area.Y + area.Height, TILE_SIZE), Layer.Height); ++y)
            {
                for (int x = Math.Max(area.X / TILE_SIZE, 0); x < Math.Min(DivideRoundUp(area.X + area.Width, TILE_SIZE), Layer.Width); ++x)
                {
                    if (addSelection || deselectIfSelected)
                    {
                        Point p = new Point(x, y);
                        if (SelectedTiles.Contains(p))
                        {
                            if (deselectIfSelected)
                            {
                                // Deselect
                                DeselectPoint(p);
                            }
                            // Don't add already selected tile, or if it was just deslected
                            continue;
                        }
                    }
                    if (Layer.Tiles[y][x] != 0xffff)
                    {
                        SelectedTiles.Add(new Point(x, y));
                    }
                }
            }
            InvalidateSelectedChunks();
        }

        public void Select(Point point, bool addSelection = false, bool deselectIfSelected = false)
        {
            if (!addSelection) Deselect();
            point = new Point(point.X / TILE_SIZE, point.Y / TILE_SIZE);
            if (point.X >= 0 && point.Y >= 0 && point.X < this.Layer.Tiles[0].Length && point.Y < this.Layer.Tiles.Length)
            {
                if (deselectIfSelected && SelectedTiles.Contains(point))
                {
                    // Deselect
                    DeselectPoint(point);
                }
                else if (this.Layer.Tiles[point.Y][point.X] != 0xffff)
                {
                    // Just add the point
                    SelectedTiles.Add(point);
                }
            }
            InvalidateSelectedChunks();
        }

        private void AddToTempSelection(Rectangle area)
        {
            if (area.Width == 0 || area.Height == 0) return;
            for (int y = Math.Max(area.Y / TILE_SIZE, 0); y < Math.Min(DivideRoundUp(area.Y + area.Height, TILE_SIZE), Layer.Height); ++y)
            {
                for (int x = Math.Max(area.X / TILE_SIZE, 0); x < Math.Min(DivideRoundUp(area.X + area.Width, TILE_SIZE), Layer.Width); ++x)
                {
                    if (!TempSelectionTiles.Contains(new Point(x, y)) && (SelectedTiles.Contains(new Point(x, y)) || Layer.Tiles[y][x] != 0xffff))
                    {
                        TempSelectionTiles.Add(new Point(x, y));
                    }
                }
            }
        }
        private void RemoveFromTempSelection(Rectangle area, Rectangle newArea)
        {
            if (area.Width == 0 || area.Height == 0) return;
            for (int y = Math.Max(area.Y / TILE_SIZE, 0); y < Math.Min(DivideRoundUp(area.Y + area.Height, TILE_SIZE), Layer.Height); ++y)
            {
                for (int x = Math.Max(area.X / TILE_SIZE, 0); x < Math.Min(DivideRoundUp(area.X + area.Width, TILE_SIZE), Layer.Width); ++x)
                {
                    if (TempSelectionTiles.Contains(new Point(x, y)) && !newArea.IntersectsWith(new Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE)))
                    {
                        TempSelectionTiles.Remove(new Point(x, y));
                    }
                }
            }
        }

        public void TempSelection(Rectangle area, bool deselectIfSelected)
        {
            TempSelectionDeselect = deselectIfSelected;

            if (tempSelectionArea == Rectangle.Empty)
            {
                TempSelectionTiles.Clear();

                for (int y = Math.Max(area.Y / TILE_SIZE, 0); y < Math.Min(DivideRoundUp(area.Y + area.Height, TILE_SIZE), Layer.Height); ++y)
                {
                    for (int x = Math.Max(area.X / TILE_SIZE, 0); x < Math.Min(DivideRoundUp(area.X + area.Width, TILE_SIZE), Layer.Width); ++x)
                    {
                        if (SelectedTiles.Contains(new Point(x, y)) || Layer.Tiles[y][x] != 0xffff)
                        {
                            TempSelectionTiles.Add(new Point(x, y));
                        }
                    }
                }
            }
            else
            {
                Rectangle commonArea = area;
                commonArea.Intersect(tempSelectionArea);

                AddToTempSelection(new Rectangle(area.Left, area.Top, area.Width, Math.Max(commonArea.Top - area.Top, 0)));
                AddToTempSelection(new Rectangle(commonArea.Right, commonArea.Top, Math.Max(area.Right - commonArea.Right, 0), commonArea.Height));
                AddToTempSelection(new Rectangle(area.Left, commonArea.Top, Math.Max(commonArea.Left - area.Left, 0), commonArea.Height));
                AddToTempSelection(new Rectangle(area.Left, commonArea.Bottom, area.Width, Math.Max(area.Bottom - commonArea.Bottom, 0)));

                RemoveFromTempSelection(new Rectangle(tempSelectionArea.Left, tempSelectionArea.Top, tempSelectionArea.Width, Math.Max(commonArea.Top - tempSelectionArea.Top, 0)), area);
                RemoveFromTempSelection(new Rectangle(commonArea.Right, commonArea.Top, Math.Max(tempSelectionArea.Right - commonArea.Right, 0), commonArea.Height), area);
                RemoveFromTempSelection(new Rectangle(tempSelectionArea.Left, commonArea.Top, Math.Max(commonArea.Left - tempSelectionArea.Left, 0), commonArea.Height), area);
                RemoveFromTempSelection(new Rectangle(tempSelectionArea.Left, commonArea.Bottom, tempSelectionArea.Width, Math.Max(tempSelectionArea.Bottom - commonArea.Bottom, 0)), area);
            }
            tempSelectionArea = area;
            InvalidateSelectedChunks();
        }

        public void EndTempSelection()
        {
            tempSelectionArea = Rectangle.Empty;
            TempSelectionTiles.Clear();
        }

        private void InvalidateChunk(int x, int y)
        {
            chunks[y][x].VerticesUpdated = false;
            chunks[y][x].TexCoordsUpdated = false;
        }

        private void InvalidateSelectedChunks()
        {
            foreach (var chunk in SelectedTiles.ChangedChunks)
            {
                selectedChunks[chunk.Y][chunk.X].VerticesUpdated = false;
                selectedChunks[chunk.Y][chunk.X].TexCoordsUpdated = false;
                InvalidateChunk(chunk.X, chunk.Y);
            }
            SelectedTiles.ChangedChunks.Clear();
            foreach (var chunk in TempSelectionTiles.ChangedChunks)
            {
                selectedChunks[chunk.Y][chunk.X].VerticesUpdated = false;
                selectedChunks[chunk.Y][chunk.X].TexCoordsUpdated = false;
                InvalidateChunk(chunk.X, chunk.Y);
            }
            TempSelectionTiles.ChangedChunks.Clear();
        }

        private ushort GetTile(Point point)
        {
            return Layer.Tiles[point.Y][point.X];
        }

        private void SetTile(Point point, ushort value, bool addAction = true)
        {
            if (addAction)
                Actions.Add(new ActionChangeTile((x, y) => SetTile(x, y, false), point, Layer.Tiles[point.Y][point.X], value));
            Layer.Tiles[point.Y][point.X] = value;
            InvalidateChunk(point.X / TILES_CHUNK_SIZE, point.Y / TILES_CHUNK_SIZE);
        }

        private void RemoveTile(Point point)
        {
            SetTile(point, 0xffff);
        }

        private void DeselectPoint(Point p)
        {
            if (SelectedTilesValue.ContainsKey(p))
            {
                // Or else it wasn't moved at all
                SetTile(p, SelectedTilesValue[p]);
                SelectedTilesValue.Remove(p);
            }
            SelectedTiles.Remove(p);
        }

        public void Deselect()
        {
            bool hasTiles = SelectedTilesValue.Count > 0;
            foreach (KeyValuePair<Point, ushort> point in SelectedTilesValue)
            {
                // ignore out of bounds
                if (point.Key.X < 0 || point.Key.Y < 0 || point.Key.Y >= Layer.Height || point.Key.X >= Layer.Width) continue;
                SetTile(point.Key, point.Value);
            }
            if (hasTiles)
                Actions.Add(new ActionsGroupCloseMarker());

            SelectedTiles.Clear();
            SelectedTilesValue.Clear();
            InvalidateSelectedChunks();
        }

        public bool IsPointSelected(Point point)
        {
            return SelectedTiles.Contains(new Point(point.X / TILE_SIZE, point.Y / TILE_SIZE));
        }

        public bool HasTileAt(Point point)
        {
            point = new Point(point.X / TILE_SIZE, point.Y / TILE_SIZE);
            if (point.X >= 0 && point.Y >= 0 && point.X < this.Layer.Tiles[0].Length && point.Y < this.Layer.Tiles.Length)
            {
                return Layer.Tiles[point.Y][point.X] != 0xffff;
            }
            return false;
        }

        public ushort GetTileAt(Point point)
        {
            point = new Point(point.X / TILE_SIZE, point.Y / TILE_SIZE);
            if (point.X >= 0 && point.Y >= 0 && point.X < this.Layer.Tiles[0].Length && point.Y < this.Layer.Tiles.Length)
            {
                if (SelectedTilesValue.ContainsKey(point)) return SelectedTilesValue[point];
                else return Layer.Tiles[point.Y][point.X];
            }
            return 0xffff;
        }

        private Rectangle GetTilesChunkArea(int x, int y)
        {
            int y_start = y * TILES_CHUNK_SIZE;
            int y_end = Math.Min((y + 1) * TILES_CHUNK_SIZE, Layer.Height);

            int x_start = x * TILES_CHUNK_SIZE;
            int x_end = Math.Min((x + 1) * TILES_CHUNK_SIZE, Layer.Width);

            return new Rectangle(x_start, y_start, x_end - x_start, y_end - y_start);
        }

        public void DrawTile(Graphics g, ushort tile, int x, int y)
        {
            bool flipX = ((tile >> 10) & 1) == 1;
            bool flipY = ((tile >> 11) & 1) == 1;
            g.DrawImage(Editor.Instance.StageTiles.Image.GetBitmap(new Rectangle(0, (tile & 0x3ff) * TILE_SIZE, TILE_SIZE, TILE_SIZE), flipX, flipY), 
                new Rectangle(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE));
        }
        
        private void AddTileToVBO(ChunkVBO vbo, ushort tile, int x, int y)
        {
            bool flipX = ((tile >> 10) & 1) == 1;
            bool flipY = ((tile >> 11) & 1) == 1;
            if (!vbo.VerticesUpdated)
                vbo.Vertices.Add(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
            if (!vbo.TexCoordsUpdated)
                vbo.TexCoords.Add(0, (tile & 0x3ff) * TILE_SIZE, TILE_SIZE, TILE_SIZE, flipX, flipY);
        }

        /*public void DrawTile(DevicePanel d, ushort tile, int x, int y, bool selected, int Transperncy)
        {
            bool flipX = ((tile >> 10) & 1) == 1;
            bool flipY = ((tile >> 11) & 1) == 1;
            d.DrawBitmap(Editor.Instance.StageTiles.Image.GetTexture(d._device, new Rectangle(0, (tile & 0x3ff) * TILE_SIZE, TILE_SIZE, TILE_SIZE), flipX, flipY),
                x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE, selected, Transperncy);
            if (selected)
            {
                d.DrawLine(x * TILE_SIZE, y * TILE_SIZE, x * TILE_SIZE + TILE_SIZE, y * TILE_SIZE, System.Drawing.Color.Brown);
                d.DrawLine(x * TILE_SIZE, y * TILE_SIZE, x * TILE_SIZE, y * TILE_SIZE + TILE_SIZE, System.Drawing.Color.Brown);
                d.DrawLine(x * TILE_SIZE + TILE_SIZE, y * TILE_SIZE + TILE_SIZE, x * TILE_SIZE + TILE_SIZE, y * TILE_SIZE, System.Drawing.Color.Brown);
                d.DrawLine(x * TILE_SIZE + TILE_SIZE, y * TILE_SIZE + TILE_SIZE, x * TILE_SIZE, y * TILE_SIZE + TILE_SIZE, System.Drawing.Color.Brown);
            }
        }*/

                public void Draw(Graphics g)
        {
            for (int y = 0; y < Layer.Height; ++y)
            {
                for (int x = 0; x < Layer.Width; ++x)
                {
                    if (this.Layer.Tiles[y][x] != 0xffff)
                    {
                        DrawTile(g, Layer.Tiles[y][x], x, y);
                    }
                }
            }
        }

        private void UpdateChunkVBO(int x, int y)
        {
            ChunkVBO vbo = chunks[y][x];
            if (vbo.TexCoordsUpdated && vbo.VerticesUpdated) return;

            if (!vbo.VerticesUpdated) vbo.Vertices.Reset();
            if (!vbo.TexCoordsUpdated) vbo.TexCoords.Reset();

            bool checkSelected = SelectedTiles.IsChunkUsed(x, y) || TempSelectionTiles.IsChunkUsed(x, y);

            Rectangle rect = GetTilesChunkArea(x, y);

            for (int ty = rect.Y; ty < rect.Y + rect.Height; ++ty)
            {
                for (int tx = rect.X; tx < rect.X + rect.Width; ++tx)
                {
                    if (checkSelected && TempSelectionDeselect && SelectedTiles.Contains(new Point(tx, ty)) && TempSelectionTiles.Contains(new Point(tx, ty)))
                    {
                        Point p = new Point(tx, ty);
                        if (SelectedTilesValue.ContainsKey(p))
                            AddTileToVBO(vbo, SelectedTilesValue[p], p.X, p.Y);
                        else // It is still in the original place
                            AddTileToVBO(vbo, Layer.Tiles[p.Y][p.X], p.X, p.Y);
                    }
                    else if (Layer.Tiles[ty][tx] != 0xffff)
                    {
                        if (!checkSelected || dragging)
                            AddTileToVBO(vbo, Layer.Tiles[ty][tx], tx, ty);
                        else
                        {
                            Point p = new Point(tx, ty);
                            if (SelectedTiles.Contains(p) || TempSelectionTiles.Contains(p))
                            {
                                if (SelectedTiles.Contains(p) && TempSelectionTiles.Contains(p) && TempSelectionDeselect)
                                    AddTileToVBO(vbo, Layer.Tiles[ty][tx], tx, ty);
                            }
                            else
                                AddTileToVBO(vbo, Layer.Tiles[ty][tx], tx, ty);
                        }
                    }
                }
            }

            if (!vbo.VerticesUpdated)
            {
                vbo.Vertices.UpdateData();
                vbo.VerticesUpdated = true;
            }
            if (!vbo.TexCoordsUpdated)
            {
                vbo.TexCoords.UpdateData();
                vbo.TexCoordsUpdated = true;
            }
        }

        private void AddSelectIndices(ChunkVBO vbo)
        {
            // Make rectangle around the selected block, using the vertices
            // Line 1
            vbo.SelectIndices.Add(vbo.Vertices.Count);
            vbo.SelectIndices.Add(vbo.Vertices.Count + 1);
            // Line 2
            vbo.SelectIndices.Add(vbo.Vertices.Count + 1);
            vbo.SelectIndices.Add(vbo.Vertices.Count + 2);
            // Line 3
            vbo.SelectIndices.Add(vbo.Vertices.Count + 2);
            vbo.SelectIndices.Add(vbo.Vertices.Count + 3);
            // Line 4
            vbo.SelectIndices.Add(vbo.Vertices.Count + 3);
            vbo.SelectIndices.Add(vbo.Vertices.Count);
        }

        private void UpdateSelectedChunkVBO(int x, int y)
        {
            ChunkVBO vbo = selectedChunks[y][x];
            if (vbo.TexCoordsUpdated && vbo.VerticesUpdated) return;

            if (!vbo.VerticesUpdated)
            {
                vbo.Vertices.Reset();
                vbo.SelectIndices.Reset();
            }
            if (!vbo.TexCoordsUpdated) vbo.TexCoords.Reset();

            Rectangle rect = GetTilesChunkArea(x, y);

            foreach (Point p in SelectedTiles.GetChunkPoint(x, y))
            {
                if (!TempSelectionDeselect || !TempSelectionTiles.Contains(p))
                {
                    if (!vbo.VerticesUpdated)
                        AddSelectIndices(vbo);

                    if (SelectedTilesValue.ContainsKey(p))
                        AddTileToVBO(vbo, SelectedTilesValue[p], p.X, p.Y);
                    else // It is still in the original place
                        AddTileToVBO(vbo, Layer.Tiles[p.Y][p.X], p.X, p.Y);
                }
            }

            foreach (Point p in TempSelectionTiles.GetChunkPoint(x, y))
            {
                if (SelectedTiles.Contains(p)) continue;
                if (!vbo.VerticesUpdated)
                    AddSelectIndices(vbo);
                AddTileToVBO(vbo, Layer.Tiles[p.Y][p.X], p.X, p.Y);
            }

            if (!vbo.VerticesUpdated)
            {
                vbo.Vertices.UpdateData();
                vbo.SelectIndices.UpdateData();
                vbo.VerticesUpdated = true;
            }
            if (!vbo.TexCoordsUpdated)
            {
                vbo.TexCoords.UpdateData();
                vbo.TexCoordsUpdated = true;
            }
        }

        private void UpdateSelectedOOBVBO()
        {
            ChunkVBO vbo = selectedOOB;
            if (vbo.TexCoordsUpdated && vbo.VerticesUpdated) return;

            if (!vbo.VerticesUpdated)
            {
                vbo.Vertices.SetBuffer(new float[SelectedTiles.GetOOB().Count * 8]);
                vbo.SelectIndices.SetBuffer(new uint[SelectedTiles.GetOOB().Count * 8]);
            }

            if (!vbo.TexCoordsUpdated)
            {
                vbo.TexCoords.SetBuffer(new float[SelectedTiles.GetOOB().Count * 8]);
            }

            foreach (Point p in SelectedTiles.GetOOB())
            {
                if (!vbo.VerticesUpdated)
                    AddSelectIndices(vbo);
                AddTileToVBO(vbo, SelectedTilesValue[p], p.X, p.Y);
            }

            if (!vbo.VerticesUpdated)
            {
                vbo.Vertices.SetData();
                vbo.SelectIndices.SetData();
                vbo.VerticesUpdated = true;
            }
            if (!vbo.TexCoordsUpdated)
            {
                vbo.TexCoords.SetData();
                vbo.TexCoordsUpdated = true;
            }
        }

        private void DrawTilesChunk(DevicePanel d, int x, int y, int Transperncy)
        {
            /*Rectangle rect = GetTilesChunkArea(x, y);

            for (int ty = rect.Y; ty < rect.Y + rect.Height; ++ty)
            {
                for (int tx = rect.X; tx < rect.X + rect.Width; ++tx)
                {
                    Point p = new Point(tx, ty);
                    // We will draw those later
                    if (SelectedTiles.Contains(p) || TempSelectionTiles.Contains(p)) continue;
                    
                    if (this.Layer.Tiles[ty][tx] != 0xffff)
                    {
                        DrawTile(d, this.Layer.Tiles[ty][tx], tx, ty, false, Transperncy);
                    }
                }
            }*/
        }

        private void DrawSelectedTiles(DevicePanel d, int x, int y, int Transperncy)
        {
            /*foreach (Point p in SelectedTiles.GetChunkPoint(x, y))
                if (SelectedTilesValue.ContainsKey(p))
                    DrawTile(d, SelectedTilesValue[p], p.X, p.Y, !TempSelectionDeselect || !TempSelectionTiles.Contains(p), Transperncy);
                else // It is still in the original place
                    DrawTile(d, Layer.Tiles[p.Y][p.X], p.X, p.Y, !TempSelectionDeselect || !TempSelectionTiles.Contains(p), Transperncy);

            foreach (Point p in TempSelectionTiles.GetChunkPoint(x, y)) {
                if (SelectedTiles.Contains(p)) continue;
                DrawTile(d, Layer.Tiles[p.Y][p.X], p.X, p.Y, true, Transperncy);
            }*/
        }

        public void Draw(DevicePanel d)
        {
            /*int Transperncy = (Editor.Instance.EditLayer != null && Editor.Instance.EditLayer != this) ? 0x32 : 0xFF;

            Rectangle screen = d.GetScreen();

            int start_x = screen.X / (TILES_CHUNK_SIZE * TILE_SIZE);
            int end_x = Math.Min(DivideRoundUp(screen.X + screen.Width, TILES_CHUNK_SIZE * TILE_SIZE), TileChunksTextures[0].Length);
            int start_y = screen.Y / (TILES_CHUNK_SIZE * TILE_SIZE);
            int end_y = Math.Min(DivideRoundUp(screen.Y + screen.Height, TILES_CHUNK_SIZE * TILE_SIZE), TileChunksTextures.Length);
            for (int y = start_y; y < end_y; ++y)
            {
                for (int x = start_x; x < end_x; ++x)
                {
                    Rectangle rect = GetTilesChunkArea(x, y);
                    if (SelectedTiles.IsChunkUsed(x, y) || TempSelectionTiles.IsChunkUsed(x, y))
                    {
                        // TODO: If the full chunk is selected, cache it
                        // draw one by one
                        DrawTilesChunk(d, x, y, Transperncy);
                    }
                    else
                    {
                        d.DrawBitmap(GetTilesChunkTexture(d, x, y), rect.X * TILE_SIZE, rect.Y * TILE_SIZE, rect.Width * TILE_SIZE, rect.Height * TILE_SIZE, false, Transperncy);
                    }
                    DrawSelectedTiles(d, x, y, Transperncy);
                }
            }*/
        }

        public void Draw(GLViewControl g)
        {
            byte Transperncy = (Editor.Instance.EditLayer != null && Editor.Instance.EditLayer != this) ? (byte)0x32 : (byte)0xFF;

            if (texture == null)
            {
                texture = Texture2D.CreateTexture(Editor.Instance.StageTiles.Image.Bitmap);
            }
            GL.Enable(EnableCap.Texture2D);
            texture.Bind();

            GL.PushAttrib(AttribMask.CurrentBit);

            GL.Color4((byte)255, (byte)255, (byte)255, Transperncy);
            for (int y = 0; y < chunks.Length; ++y)
            {
                for (int x = 0; x < chunks[0].Length; ++x)
                {
                    UpdateChunkVBO(x, y);
                    
                    chunks[y][x].Vertices.Load();
                    chunks[y][x].TexCoords.Load();
                    GL.DrawArrays(PrimitiveType.Quads, 0, chunks[y][x].Vertices.Count);
                    chunks[y][x].Vertices.Unload();
                    chunks[y][x].TexCoords.Unload();
                }
            }
            GL.Disable(EnableCap.Texture2D);

            GL.Color4(System.Drawing.Color.BlueViolet.R, System.Drawing.Color.BlueViolet.G, System.Drawing.Color.BlueViolet.B, Transperncy);
            GL.LineWidth(1.0f);
            for (int y = 0; y < chunks.Length; ++y)
            {
                for (int x = 0; x < chunks[0].Length; ++x)
                {
                    if (SelectedTiles.IsChunkUsed(x, y) || TempSelectionTiles.IsChunkUsed(x, y))
                    {
                        UpdateSelectedChunkVBO(x, y);

                        if (dragging)
                        {
                            GL.PushMatrix();
                            GL.Translate(draggedDistance.X * TILE_SIZE, draggedDistance.Y * TILE_SIZE, Editor.LAYER_DEPTH / 2);
                        }

                        GL.Enable(EnableCap.Texture2D);
                        selectedChunks[y][x].Vertices.Load();
                        selectedChunks[y][x].TexCoords.Load();
                        GL.DrawArrays(PrimitiveType.Quads, 0, selectedChunks[y][x].Vertices.Count);
                        selectedChunks[y][x].TexCoords.Unload();
                        GL.Disable(EnableCap.Texture2D);

                        GL.PushMatrix();
                        GL.Translate(0, 0, Editor.LAYER_DEPTH / 4);
                        selectedChunks[y][x].SelectIndices.Load();
                        GL.DrawElements(PrimitiveType.Lines, selectedChunks[y][x].SelectIndices.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
                        selectedChunks[y][x].SelectIndices.Unload();
                        selectedChunks[y][x].Vertices.Unload();
                        GL.PopMatrix();

                        if (dragging)
                        {
                            GL.PopMatrix();
                        }
                    }
                }
            }
            if (dragging)
            {
                UpdateSelectedOOBVBO();

                GL.PushMatrix();
                GL.Translate(draggedDistance.X * TILE_SIZE, draggedDistance.Y * TILE_SIZE, Editor.LAYER_DEPTH / 2);

                GL.Enable(EnableCap.Texture2D);
                selectedOOB.Vertices.Load();
                selectedOOB.TexCoords.Load();
                GL.DrawArrays(PrimitiveType.Quads, 0, selectedOOB.Vertices.Count);
                selectedOOB.TexCoords.Unload();
                GL.Disable(EnableCap.Texture2D);

                GL.PushMatrix();
                GL.Translate(0, 0, Editor.LAYER_DEPTH / 4);
                selectedOOB.SelectIndices.Load();
                GL.DrawElements(PrimitiveType.Lines, selectedOOB.SelectIndices.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
                selectedOOB.SelectIndices.Unload();
                selectedOOB.Vertices.Unload();
                GL.PopMatrix();

                GL.PopMatrix();
            }

            GL.PopAttrib();

            texture.Unbind();
        }

        public void DisposeGraphics(GLViewControl gl)
        {
            gl.MakeCurrent();
            foreach (var vbos in chunks)
            {
                foreach (var vbo in vbos)
                {
                    vbo.TexCoords.Destroy();
                    vbo.Vertices.Destroy();
                }
            }
            foreach (var vbos in selectedChunks)
            {
                foreach (var vbo in vbos)
                {
                    vbo.TexCoords.Destroy();
                    vbo.Vertices.Destroy();
                    vbo.SelectIndices.Destroy();
                }
            }
            selectedOOB.TexCoords.Destroy();
            selectedOOB.Vertices.Destroy();
            selectedOOB.SelectIndices.Destroy();
        }
    }
}
