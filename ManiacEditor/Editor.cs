using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ManiacEditor.Actions;
using System.Collections;
using System.Net;
using RSDKv5;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    public partial class Editor : Form, IDrawArea
    {
        bool dragged;
        bool startDragged;
        int lastX, lastY, draggedX, draggedY;

        int ClickedX=-1, ClickedY=-1;

        public Stack<IAction> undo = new Stack<IAction>();
        public Stack<IAction> redo = new Stack<IAction>();
        
        bool draggingSelection;
        int selectingX, selectingY;
        bool zooming;
        //double Zoom = 1;
        int ZoomLevel = 0;

        string DataDirectory;

        GameConfig GameConfig;

        string SelectedZone;
        string SelectedScene;

        internal StageTiles StageTiles;
        internal Scene Scene;

        string SceneFilename = null;

        internal EditorLayer FGHigh;
        internal EditorLayer FGLow;

        internal EditorBackground Background;

        internal EditorLayer EditLayer;

        internal TilesToolbar TilesToolbar = null;
        private EntitiesToolbar entitiesToolbar = null;

        internal Dictionary<Point, ushort> TilesClipboard;
        private List<EditorEntity> entitiesClipboard;

        internal int SceneWidth;
        internal int SceneHeight;

        int lastFPS;
        
        bool scrolling = false;
        bool scrollingDragged = false, wheelClicked = false;
        Point scrollPosition, lastScrollPos;

        EditorEntities entities;

        public static Editor Instance;

        public const double LAYER_DEPTH = 0.1;
        
        Timer scrollTimer = new Timer() { Interval = 1 };

        public Editor()
        {
            Instance = this;
            InitializeComponent();

            this.splitContainer1.Panel2MinSize = 254;

            GraphicPanel.GotFocus += new EventHandler(OnGotFocus);
            GraphicPanel.LostFocus += new EventHandler(OnLostFocus);

            scrollTimer.Tick += ScrollTick;

            SetViewSize();

            UpdateControls();
        }

        private bool IsEditing()
        {
            return IsTilesEdit() || IsEntitiesEdit();
        }

        private bool IsTilesEdit()
        {
            return EditLayer != null;
        }

        private bool IsEntitiesEdit()
        {
            return EditEntities.Checked;
        }


        private bool IsSelected()
        {
            if (IsTilesEdit())
            {
                return EditLayer.SelectedTiles.Count > 0 || EditLayer.TempSelectionTiles.Count > 0;
            }
            else if (IsEntitiesEdit())
            {
                return entities.IsSelected();
            }
            return false;
        }

        private void SetSceneOnlyButtonsState(bool enabled)
        {
            saveToolStripMenuItem.Enabled = enabled;
            saveAsToolStripMenuItem.Enabled = enabled;
            saveAspngToolStripMenuItem.Enabled = enabled;

            ShowFGHigh.Enabled = enabled;
            ShowFGLow.Enabled = enabled;
            ShowEntities.Enabled = enabled;

            Save.Enabled = enabled;

            zoomInButton.Enabled = enabled && ZoomLevel < 5;
            zoomOutButton.Enabled = enabled && ZoomLevel > -5;

            SetEditButtonsState(enabled);
        }

        private void SetSelectOnlyButtonsState(bool enabled=true)
        {
            enabled &= IsSelected();
            deleteToolStripMenuItem.Enabled = enabled;
            copyToolStripMenuItem.Enabled = enabled;
            cutToolStripMenuItem.Enabled = enabled;
            duplicateToolStripMenuItem.Enabled = enabled;

            flipHorizontalToolStripMenuItem.Enabled = enabled && IsTilesEdit();
            flipVerticalToolStripMenuItem.Enabled = enabled && IsTilesEdit();

            if (IsEntitiesEdit())
            {
                entitiesToolbar.SelectedEntities = entities.SelectedEntities.Select(x => x.Entity).ToList();
            }
        }

        private void SetEditButtonsState(bool enabled)
        {
            EditFGLow.Enabled = enabled;
            EditFGHigh.Enabled = enabled;
            EditEntities.Enabled = enabled;
            
            if (enabled && EditFGLow.Checked) EditLayer = FGLow;
            else if (enabled && EditFGHigh.Checked) EditLayer = FGHigh;
            else EditLayer = null;

            undoToolStripMenuItem.Enabled = enabled && undo.Count > 0;
            redoToolStripMenuItem.Enabled = enabled && redo.Count > 0;

            undoButton.Enabled = enabled && undo.Count > 0;
            redoButton.Enabled = enabled && redo.Count > 0;

            pointerButton.Enabled = enabled && IsTilesEdit();
            selectTool.Enabled = enabled && IsTilesEdit();
            placeTilesButton.Enabled = enabled && IsTilesEdit();

            if (enabled && IsTilesEdit() && TilesClipboard != null)
                pasteToolStripMenuItem.Enabled = true;
            else
                pasteToolStripMenuItem.Enabled = false;

            if (IsTilesEdit())
            {
                if (TilesToolbar == null)
                {
                    TilesToolbar = new TilesToolbar(StageTiles);
                    TilesToolbar.TileDoubleClick = new Action<int>(x =>
                    {
                        EditorPlaceTile(new Point(GraphicPanel.ScreenX + EditorLayer.TILE_SIZE - 1, GraphicPanel.ScreenY + EditorLayer.TILE_SIZE - 1), x);
                    });
                    TilesToolbar.TileOptionChanged = new Action<int, bool>( (option, state) =>
                    {
                        EditLayer.SetPropertySelected(option + 12, state);
                    });
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(TilesToolbar);
                    splitContainer1.Panel2Collapsed = false;
                    TilesToolbar.Width = splitContainer1.Panel2.Width - 2;
                    TilesToolbar.Height = splitContainer1.Panel2.Height - 2;
                    Form1_Resize(null, null);
                }
                UpdateTilesOptions();
                TilesToolbar.ShowShortcuts = placeTilesButton.Checked;
            }
            else
            {
                TilesToolbar?.Dispose();
                TilesToolbar = null;
            }
            if (IsEntitiesEdit())
            {
                if (entitiesToolbar == null)
                {
                    entitiesToolbar = new EntitiesToolbar();
                    entitiesToolbar.SelectedEntity = new Action<int>(x =>
                    {
                        entities.SelectSlot(x);
                        SetSelectOnlyButtonsState();
                    });
                    entitiesToolbar.AddAction = new Action<IAction>(x =>
                    {
                        undo.Push(x);
                        redo.Clear();
                        UpdateControls();
                    });
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(entitiesToolbar);
                    splitContainer1.Panel2Collapsed = false;
                    entitiesToolbar.Width = splitContainer1.Panel2.Width - 2;
                    entitiesToolbar.Height = splitContainer1.Panel2.Height - 2;
                    Form1_Resize(null, null);
                }
                UpdateEntitiesToolbarList();
                //entitiesToolbar.SelectedEntities = entities.SelectedEntities.Select(x => x.Entity).ToList();
            }
            else
            {
                entitiesToolbar?.Dispose();
                entitiesToolbar = null;
            }
            if (TilesToolbar == null && entitiesToolbar == null)
            {
                splitContainer1.Panel2Collapsed = true;
                Form1_Resize(null, null);
            }

            SetSelectOnlyButtonsState(enabled);
        }

        private void UpdateEntitiesToolbarList()
        {
            entitiesToolbar.Entities = entities.Entities.Select(x => x.Entity).ToList();
        }

        private void UpdateTilesOptions()
        {
            if (IsTilesEdit())
            {
                List<ushort> values = EditLayer.GetSelectedValues();
                if (values.Count > 0)
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        bool set = ((values[0] & (1 << (i + 12))) != 0);
                        bool unk = false;
                        foreach (ushort value in values)
                        {
                            if (set != ((value & (1 << (i + 12))) != 0))
                            {
                                unk = true;
                                break;
                            }
                        }
                        TilesToolbar.SetTileOptionState(i, unk ? TilesToolbar.TileOptionState.Indeterminate : set ? TilesToolbar.TileOptionState.Checked : TilesToolbar.TileOptionState.Unchcked);
                    }
                }
                else
                {
                    for (int i = 0; i < 4; ++i)
                        TilesToolbar.SetTileOptionState(i, TilesToolbar.TileOptionState.Disabled);
                }
            }
        }

        private void UpdateControls()
        {
            SetSceneOnlyButtonsState(Scene != null);
        }

        public void OnGotFocus(object sender, EventArgs e)
        {
        }
        public void OnLostFocus(object sender, EventArgs e)
        {
        }

        public void EditorPlaceTile(Point position, int tile)
        {
            Dictionary<Point, ushort> tiles = new Dictionary<Point, ushort>();
            tiles[new Point(0, 0)] = (ushort)tile;
            EditLayer?.PasteFromClipboard(position, tiles);
            UpdateEditLayerActions();
        }

        public void MagnetDisable()
        {
        }

        private void UpdateEditLayerActions()
        {
            if (EditLayer != null)
            {
                List<IAction> actions = EditLayer.Actions;
                if (actions.Count > 0) redo.Clear();
                while (actions.Count > 0)
                {
                    bool create_new = false;
                    if (undo.Count == 0 || !(undo.Peek() is ActionsGroup))
                    {
                        create_new = true;
                    }
                    else
                    {
                        create_new = (undo.Peek() as ActionsGroup).IsClosed;
                    }
                    if (create_new)
                    {
                        undo.Push(new ActionsGroup());
                    }
                    (undo.Peek() as ActionsGroup).AddAction(actions[0]);
                    actions.RemoveAt(0);
                }
                UpdateControls();
            }
        }

        public void DeleteSelected()
        {
            EditLayer?.DeleteSelected();
            UpdateEditLayerActions();

            if (IsEntitiesEdit())
            {
                entities.DeleteSelected();
                UpdateLastEntityAction();
            }
        }

        public void UpdateLastEntityAction()
        {
            if (entities.LastAction != null)
            {
                redo.Clear();
                undo.Push(entities.LastAction);
                entities.LastAction = null;
                UpdateControls();
            }

        }

        public void GraphicPanel_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                if (IsTilesEdit() && placeTilesButton.Checked)
                    TilesToolbar.SetSelectTileOption(0, true);
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                if (IsTilesEdit() && placeTilesButton.Checked)
                    TilesToolbar.SetSelectTileOption(1, true);
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                Open_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                New_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save_Click(null, null);
            }
            else if (e.Control && (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0))
            {
                SetZoomLevel(0, new Point(0, 0));
            }
            else if (e.KeyCode == Keys.Z)
            {
                EditorUndo();
            }
            else if (e.KeyCode == Keys.Y)
            {
                EditorRedo();
            }
            if (IsEditing())
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.V)
                    {
                        pasteToolStripMenuItem_Click(sender, e);
                    }
                }
                if (IsSelected())
                {
                    if (e.KeyData == Keys.Delete)
                    {
                        DeleteSelected();
                    }
                    else if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                    {
                        int x = 0, y = 0;
                        switch (e.KeyData)
                        {
                            case Keys.Up: y = -1; break;
                            case Keys.Down: y = 1; break;
                            case Keys.Left: x = -1; break;
                            case Keys.Right: x = 1; break;
                        }
                        EditLayer?.MoveSelectedQuonta(new Point(x, y));
                        UpdateEditLayerActions();

                        if (IsEntitiesEdit())
                        {
                            entities.MoveSelected(new Point(0, 0), new Point(x, y), false);
                            entitiesToolbar.UpdateCurrentEntityProperites();

                            // Try to merge with last move
                            if (undo.Count > 0 && undo.Peek() is ActionMoveEntities && (undo.Peek() as ActionMoveEntities).UpdateFromKey(entities.SelectedEntities, new Point(x,y))) { }
                            else
                            {
                                undo.Push(new ActionMoveEntities(entities.SelectedEntities.ToList(), new Point(x, y), true));
                                redo.Clear();
                                UpdateControls();
                            }
                        }
                    }
                    else if (e.KeyData == Keys.F)
                    {
                        if (IsTilesEdit())
                            flipVerticalToolStripMenuItem_Click(sender, e);
                    }
                    else if (e.KeyData == Keys.M)
                    {
                        if (IsTilesEdit())
                            flipHorizontalToolStripMenuItem_Click(sender, e);
                    }
                    if (e.Control)
                    {
                        if (e.KeyCode == Keys.X)
                        {
                            cutToolStripMenuItem_Click(sender, e);
                        }
                        else if (e.KeyCode == Keys.C)
                        {
                            copyToolStripMenuItem_Click(sender, e);
                        }
                        else if (e.KeyCode == Keys.D)
                        {
                            duplicateToolStripMenuItem_Click(sender, e);
                        }
                    }
                }
            }
        }

        public void GraphicPanel_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                if (IsTilesEdit() && placeTilesButton.Checked)
                    TilesToolbar.SetSelectTileOption(0, false);
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                if (IsTilesEdit() && placeTilesButton.Checked)
                    TilesToolbar.SetSelectTileOption(1, false);
            }
        }

        private bool CtrlPressed()
        {
            return ModifierKeys.HasFlag(Keys.Control);
        }

        private bool ShiftPressed()
        {
            return ModifierKeys.HasFlag(Keys.Shift);
        }

        private void GraphicPanel_OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void ScrollTick(object sender, EventArgs e)
        {
            Point position = new Point((int)(GraphicPanel.ScreenX * GraphicPanel.Zoom), (int)(GraphicPanel.ScreenY * GraphicPanel.Zoom));

            if (wheelClicked)
            {
                scrollingDragged = true;
            }

            int xMove = (hScrollBar1.Visible) ? lastScrollPos.X - position.X - scrollPosition.X : 0;
            int yMove = (vScrollBar1.Visible) ? lastScrollPos.Y - position.Y - scrollPosition.Y : 0;

            if (Math.Abs(xMove) < 15) xMove = 0;
            if (Math.Abs(yMove) < 15) yMove = 0;

            if (xMove > 0)
            {
                if (yMove > 0) Cursor = Cursors.PanSE;
                else if (yMove < 0) Cursor = Cursors.PanNE;
                else Cursor = Cursors.PanEast;
            }
            else if (xMove < 0)
            {
                if (yMove > 0) Cursor = Cursors.PanSW;
                else if (yMove < 0) Cursor = Cursors.PanNW;
                else Cursor = Cursors.PanWest;
            }
            else
            {
                if (yMove > 0) Cursor = Cursors.PanSouth;
                else if (yMove < 0) Cursor = Cursors.PanNorth;
                else
                {
                    if (vScrollBar1.Visible && hScrollBar1.Visible) Cursor = Cursors.NoMove2D;
                    else if (vScrollBar1.Visible) Cursor = Cursors.NoMoveVert;
                    else if (hScrollBar1.Visible) Cursor = Cursors.NoMoveHoriz;
                }
            }

            int x = xMove / 10 + position.X;
            int y = yMove / 10 + position.Y;

            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x > hScrollBar1.Maximum - hScrollBar1.LargeChange) x = hScrollBar1.Maximum - hScrollBar1.LargeChange;
            if (y > vScrollBar1.Maximum - vScrollBar1.LargeChange) y = vScrollBar1.Maximum - vScrollBar1.LargeChange;
            
            if (x != position.X || y != position.Y)
            {
                if (vScrollBar1.Visible)
                {
                    vScrollBar1.Value = y;
                }
                if (hScrollBar1.Visible)
                {
                    hScrollBar1.Value = x;
                }
                Point nposition = new Point((int)(GraphicPanel.ScreenX * GraphicPanel.Zoom), (int)(GraphicPanel.ScreenY * GraphicPanel.Zoom));
                lastScrollPos.X += nposition.X - position.X;
                lastScrollPos.Y += nposition.Y - position.Y;
            }
        }

        private void GraphicPanel_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (ClickedX != -1)
            {
                Point clicked_point = new Point(ClickedX, ClickedY);
                // There was just a click now we can determine that this click is dragging
                if (IsTilesEdit())
                {
                    if (EditLayer.IsPointSelected(clicked_point))
                    {
                        // Start dragging the tiles
                        dragged = true;
                        startDragged = true;
                        EditLayer.StartDrag();
                    }
                    else if (!selectTool.Checked && !ShiftPressed() && !CtrlPressed() && EditLayer.HasTileAt(clicked_point))
                    {
                        // Start dragging the single selected tile
                        EditLayer.Select(clicked_point);
                        dragged = true;
                        startDragged = true;
                        EditLayer.StartDrag();
                    }
                    else
                    {
                        // Start drag selection
                        //EditLayer.Select(clicked_point, ShiftPressed || CtrlPressed, CtrlPressed);
                        if (!ShiftPressed() && !CtrlPressed())
                            Deselect();
                        UpdateControls();
                        UpdateEditLayerActions();
                        draggingSelection = true;
                        selectingX = ClickedX;
                        selectingY = ClickedY;
                    }
                }
                else if (IsEntitiesEdit())
                {
                    if (entities.GetEntityAt(clicked_point)?.Selected ?? false)
                    {
                        ClickedX = e.X;
                        ClickedY = e.Y;
                        // Start dragging the entity
                        dragged = true;
                        draggedX = 0;
                        draggedY = 0;
                        startDragged = true;
                    }
                    else
                    {
                        // Start drag selection
                        if (!ShiftPressed() && !CtrlPressed())
                            Deselect();
                        UpdateControls();
                        draggingSelection = true;
                        selectingX = ClickedX;
                        selectingY = ClickedY;
                    }
                }
                ClickedX = -1;
                ClickedY = -1;
            }
            if (scrolling)
            {
                lastScrollPos = new Point((int)(e.X * GraphicPanel.Zoom), (int)(e.Y * GraphicPanel.Zoom));
            }

            toolStripStatusLabel1.Text = "X: " + e.X + " Y: " + e.Y;

            if (IsEditing())
            {
                if (IsTilesEdit() && placeTilesButton.Checked)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // Place tile
                        if (TilesToolbar.SelectedTile != -1)
                        {
                            if (EditLayer.GetTileAt(e.Location) != TilesToolbar.SelectedTile)
                            {
                                EditorPlaceTile(e.Location, TilesToolbar.SelectedTile);
                            }
                            else if (!EditLayer.IsPointSelected(e.Location))
                            {
                                EditLayer.Select(e.Location);
                            }
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        // Remove tile
                        if (!EditLayer.IsPointSelected(e.Location))
                        {
                            EditLayer.Select(e.Location);
                        }
                        DeleteSelected();
                    }
                }
                if (draggingSelection || dragged)
                {
                    Point position = new Point((int)(GraphicPanel.ScreenX * GraphicPanel.Zoom), (int)(GraphicPanel.ScreenY * GraphicPanel.Zoom)); ;
                    int ScreenMaxX = position.X + splitContainer1.Panel1.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
                    int ScreenMaxY = position.Y + splitContainer1.Panel1.Height - System.Windows.Forms.SystemInformation.HorizontalScrollBarHeight;
                    int ScreenMinX = position.X;
                    int ScreenMinY = position.Y;

                    int x = position.X;
                    int y = position.Y;
                    int eX = (int)(e.X * GraphicPanel.Zoom);
                    int eY = (int)(e.Y * GraphicPanel.Zoom);

                    if (eX > ScreenMaxX)
                    {
                        x += (eX - ScreenMaxX) / 10;
                    }
                    else if (eX < ScreenMinX)
                    {
                        x += (eX - ScreenMinX) / 10;
                    }
                    if (eY > ScreenMaxY)
                    {
                        y += (eY - ScreenMaxY) / 10;
                    }
                    else if (eY < ScreenMinY)
                    {
                        y += (eY - ScreenMinY) / 10;
                    }

                    if (x < 0) x = 0;
                    if (y < 0) y = 0;
                    if (x > hScrollBar1.Maximum - hScrollBar1.LargeChange) x = hScrollBar1.Maximum - hScrollBar1.LargeChange;
                    if (y > vScrollBar1.Maximum - vScrollBar1.LargeChange) y = vScrollBar1.Maximum - vScrollBar1.LargeChange;

                    if (x != position.X || y != position.Y)
                    {
                        if (vScrollBar1.Visible)
                        {
                            vScrollBar1.Value = y;
                        }
                        if (hScrollBar1.Visible)
                        {
                            hScrollBar1.Value = x;
                        }
                        GraphicPanel.OnMouseMoveEventCreate();
                        GraphicPanel.Invalidate();
                        GraphicPanel.Update();
                    }
                }

                if (draggingSelection)
                {
                    if (selectingX != e.X && selectingY != e.Y)
                    {
                        int x1 = selectingX, x2 = e.X;
                        int y1 = selectingY, y2 = e.Y;
                        if (x1 > x2)
                        {
                            x1 = e.X;
                            x2 = selectingX;
                        }
                        if (y1 > y2)
                        {
                            y1 = e.Y;
                            y2 = selectingY;
                        }
                        EditLayer?.TempSelection(new Rectangle(x1, y1, x2 - x1, y2 - y1), CtrlPressed());
                        UpdateTilesOptions();

                        if (IsEntitiesEdit()) entities.TempSelection(new Rectangle(x1, y1, x2 - x1, y2 - y1), CtrlPressed());
                    }
                }
                else if (dragged)
                {
                    Point oldPoint = new Point(lastX, lastY);
                    Point newPoint = e.Location;

                    EditLayer?.MoveSelected(oldPoint, newPoint, CtrlPressed());
                    UpdateEditLayerActions();
                    if (IsEntitiesEdit())
                    {
                        try
                        {
                            entities.MoveSelected(oldPoint, newPoint, CtrlPressed() && startDragged);
                        }
                        catch(EditorEntities.TooManyEntitiesException)
                        {
                            MessageBox.Show("Too many entities! (limit: 2048)");
                            dragged = false;
                            return;
                        }
                        draggedX += newPoint.X - oldPoint.X;
                        draggedY += newPoint.Y - oldPoint.Y;
                        if (CtrlPressed() && startDragged)
                        {
                            UpdateEntitiesToolbarList();
                            SetSelectOnlyButtonsState();
                        }
                        entitiesToolbar.UpdateCurrentEntityProperites();
                    }
                    startDragged = false;
                }
            }
            lastX = e.X;
            lastY = e.Y;
        }
        private void GraphicPanel_OnMouseDown(object sender, MouseEventArgs e)
        {
            //GraphicPanel.Focus();
            if (e.Button == MouseButtons.Left)
            {
                if (IsEditing() && !dragged)
                {
                    if (IsTilesEdit())
                    {
                        if (placeTilesButton.Checked)
                        {
                            // Place tile
                            if (TilesToolbar.SelectedTile != -1)
                            {
                                EditorPlaceTile(e.Location, TilesToolbar.SelectedTile);
                            }
                        }
                        else
                        {
                            ClickedX = e.X;
                            ClickedY = e.Y;
                        }
                    }
                    else if (IsEntitiesEdit())
                    {
                        if (entities.GetEntityAt(e.Location)?.Selected ?? false)
                        {
                            // We will have to check if this dragging or clicking
                            ClickedX = e.X;
                            ClickedY = e.Y;
                        }
                        else if (!ShiftPressed() && !CtrlPressed() && entities.GetEntityAt(e.Location) != null)
                        {
                            entities.Select(e.Location);
                            SetSelectOnlyButtonsState();
                            // Start dragging the single selected entity
                            dragged = true;
                            draggedX = 0;
                            draggedY = 0;
                            startDragged = true;
                        }
                        else
                        {
                            ClickedX = e.X;
                            ClickedY = e.Y;
                        }
                    }
                }

                if (scrolling)
                {
                    scrolling = false;
                    scrollTimer.Stop();
                    Cursor = Cursors.Default;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (IsTilesEdit() && placeTilesButton.Checked)
                {
                    // Remove tile
                    if (!EditLayer.IsPointSelected(e.Location))
                    {
                        EditLayer.Select(e.Location);
                    }
                    DeleteSelected();
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                wheelClicked = true;
                scrolling = true;
                scrollingDragged = false;
                scrollPosition = new Point((int)((e.X - GraphicPanel.ScreenX) * GraphicPanel.Zoom), (int)((e.Y - GraphicPanel.ScreenY) * GraphicPanel.Zoom));
                lastScrollPos = scrollPosition;
                scrollTimer.Start();
                if (vScrollBar1.Visible && hScrollBar1.Visible)
                {
                    Cursor = Cursors.NoMove2D;
                }
                else if (vScrollBar1.Visible)
                {
                    Cursor = Cursors.NoMoveVert;
                }
                else if (hScrollBar1.Visible)
                {
                    Cursor = Cursors.NoMoveHoriz;
                }
                else
                {
                    scrolling = false;
                    scrollTimer.Stop();
                }
            }
        }
        private void GraphicPanel_OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (IsEditing()) {
                    MagnetDisable();
                    if (draggingSelection)
                    {
                        if (selectingX != e.X && selectingY != e.Y)
                        {

                            int x1 = selectingX, x2 = e.X;
                            int y1 = selectingY, y2 = e.Y;
                            if (x1 > x2)
                            {
                                x1 = e.X;
                                x2 = selectingX;
                            }
                            if (y1 > y2)
                            {
                                y1 = e.Y;
                                y2 = selectingY;
                            }

                            EditLayer?.Select(new Rectangle(x1, y1, x2 - x1, y2 - y1), ShiftPressed() || CtrlPressed(), CtrlPressed());
                            if (IsEntitiesEdit()) entities.Select(new Rectangle(x1, y1, x2 - x1, y2 - y1), ShiftPressed() || CtrlPressed(), CtrlPressed());
                            SetSelectOnlyButtonsState();
                            UpdateEditLayerActions();
                        }
                        draggingSelection = false;
                        EditLayer?.EndTempSelection();
                        if (IsEntitiesEdit()) entities.EndTempSelection();
                    }
                    else
                    {
                        if (ClickedX != -1)
                        {
                            // So it was just click
                            if (IsTilesEdit())
                            {
                                EditLayer.Select(e.Location, ShiftPressed() || CtrlPressed(), CtrlPressed());
                                UpdateEditLayerActions();
                            }
                            else if (IsEntitiesEdit())
                            {
                                entities.Select(e.Location, ShiftPressed() || CtrlPressed(), CtrlPressed());
                            }
                            SetSelectOnlyButtonsState();
                            ClickedX = -1;
                            ClickedY = -1;
                        }
                        if (dragged && (draggedX != 0 || draggedY != 0))
                        {
                            if (IsEntitiesEdit())
                            {
                                IAction action = new ActionMoveEntities(entities.SelectedEntities.ToList(), new Point(draggedX, draggedY));
                                if (entities.LastAction != null)
                                {
                                    // If it is move & duplicate, merge them together
                                    var taction = new ActionsGroup();
                                    taction.AddAction(entities.LastAction);
                                    entities.LastAction = null;
                                    taction.AddAction(action);
                                    taction.Close();
                                    action = taction;
                                }
                                undo.Push(action);
                                redo.Clear();
                                UpdateControls();
                            }
                        }
                        dragged = false;
                    }
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                wheelClicked = false;
                if (scrollingDragged)
                {
                    scrolling = false;
                    scrollTimer.Stop();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void GraphicPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (CtrlPressed())
            {
                int change = e.Delta / 120;
                ZoomLevel += change;
                if (ZoomLevel > 5) ZoomLevel = 5;
                if (ZoomLevel < -5) ZoomLevel = -5;
                
                SetZoomLevel(ZoomLevel, new Point(e.X - GraphicPanel.ScreenX, e.Y - GraphicPanel.ScreenY));
            }
            else
            {
                if (vScrollBar1.Visible)
                {
                    int y = vScrollBar1.Value - e.Delta;
                    if (y < 0) y = 0;
                    if (y > vScrollBar1.Maximum - vScrollBar1.LargeChange) y = vScrollBar1.Maximum - vScrollBar1.LargeChange;
                    vScrollBar1.Value = y;
                }

            }
        }

        public void SetZoomLevel(int zoom_level, Point zoom_point)
        {            
            double old_zoom = GraphicPanel.Zoom;

            ZoomLevel = zoom_level;

            switch (ZoomLevel)
            {
                case 5: GraphicPanel.Zoom = 4; break;
                case 4: GraphicPanel.Zoom = 3; break;
                case 3: GraphicPanel.Zoom = 2; break;
                case 2: GraphicPanel.Zoom = 3 / 2.0; break;
                case 1: GraphicPanel.Zoom = 5 / 4.0; break;
                case 0: GraphicPanel.Zoom = 1; break;
                case -1: GraphicPanel.Zoom = 2 / 3.0; break;
                case -2: GraphicPanel.Zoom = 1 / 2.0; break;
                case -3: GraphicPanel.Zoom = 1 / 3.0; break;
                case -4: GraphicPanel.Zoom = 1 / 4.0; break;
                case -5: GraphicPanel.Zoom = 1 / 8.0; break;
            }

            zooming = true;

            int screenX = GraphicPanel.ScreenX;
            int screenY = GraphicPanel.ScreenY;

            if (Scene != null)
                SetViewSize((int)(SceneWidth * GraphicPanel.Zoom), (int)(SceneHeight * GraphicPanel.Zoom));

            if (hScrollBar1.Visible)
            {
                hScrollBar1.Value = Math.Min(hScrollBar1.Maximum - hScrollBar1.LargeChange, Math.Max(0, (int)((zoom_point.X + GraphicPanel.ScreenX) * GraphicPanel.Zoom - zoom_point.X * old_zoom)));
            }
            if (vScrollBar1.Visible)
            {
                vScrollBar1.Value = Math.Min(vScrollBar1.Maximum - vScrollBar1.LargeChange, Math.Max(0, (int)((zoom_point.Y + GraphicPanel.ScreenY) * GraphicPanel.Zoom - zoom_point.Y * old_zoom)));
            }

            zooming = false;

            UpdateControls();
        }
        
        private bool load()
        {
            if (DataDirectory == null)
            {
                do
                {
                    MessageBox.Show("Please select the \"Data\" folder", "Message");

                    FolderSelectDialog folderBrowserDialog = new FolderSelectDialog();
                    folderBrowserDialog.Title = "Select Data Folder";

                    if (!folderBrowserDialog.ShowDialog())
                        return false;

                    DataDirectory = folderBrowserDialog.FileName;
                }
                while (!File.Exists(Path.Combine(DataDirectory, "Game", "GameConfig.bin")));

                GameConfig = new GameConfig(Path.Combine(DataDirectory, "Game", "GameConfig.bin"));
            }
            return true;
        }

        void UnloadScene()
        {
            Scene = null;
            SceneFilename = null;

            SelectedScene = null;
            SelectedZone = null;

            if (StageTiles != null) StageTiles.Dispose();
            StageTiles = null;

            if (FGHigh != null) FGHigh.Dispose();
            FGHigh = null;
            if (FGLow != null) FGLow.Dispose();
            FGLow = null;

            Background = null;
            
            TilesClipboard = null;
            entitiesClipboard = null;

            entities = null;

            GraphicPanel.Zoom = 1;
            ZoomLevel = 0;

            undo.Clear();
            redo.Clear();

            EditFGLow.Checked = false;
            EditFGHigh.Checked = false;
            EditEntities.Checked = false;

            SetViewSize();

            UpdateControls();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (load())
            {
                SceneSelect select = new SceneSelect(GameConfig);
                select.ShowDialog();

                if (select.Result == null)
                    return;

                UnloadScene();

                if (File.Exists(select.Result))
                {
                    // Selected file

                    StageTiles = new StageTiles(Path.GetDirectoryName(select.Result));
                    SceneFilename = select.Result;
                }
                else
                {
                    string[] splitted = select.Result.Split('/');

                    SelectedZone = splitted[0];
                    SelectedScene = splitted[1];


                    StageTiles = new StageTiles(Path.Combine(DataDirectory, "Stages", SelectedZone));
                    SceneFilename = Path.Combine(DataDirectory, "Stages", SelectedZone, SelectedScene);
                }
                Scene = new Scene(SceneFilename);

                SceneLayer low_layer = null, high_layer = null;

                foreach (SceneLayer layer in Scene.Layers)
                {
                    if (layer.Name == "FG Low\0")
                        low_layer = layer;
                    else if (layer.Name == "FG High\0")
                        high_layer = layer;
                }

                if (low_layer == null || high_layer == null)
                {
                    MessageBox.Show("Not found FG Low and FG High", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UnloadScene();
                    return;
                }

                FGLow = new EditorLayer(low_layer);
                FGHigh = new EditorLayer(high_layer);

                Background = new EditorBackground();

                entities = new EditorEntities(Scene);

                SceneWidth = low_layer.Width * 16;
                SceneHeight = low_layer.Height * 16;

                SetViewSize(SceneWidth, SceneHeight);

                UpdateControls();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2.Controls.Count == 1)
            {
                splitContainer1.Panel2.Controls[0].Height = splitContainer1.Panel2.Height - 2;
                splitContainer1.Panel2.Controls[0].Width = splitContainer1.Panel2.Width - 2;
            }

            // TODO: It hides right now few pixels at the edge

            bool nvscrollbar = false;
            bool nhscrollbar = false;

            if (hScrollBar1.Maximum > viewPanel.Width - 2) nhscrollbar = true;
            if (vScrollBar1.Maximum > viewPanel.Height - 2) nvscrollbar = true;
            if (hScrollBar1.Maximum > viewPanel.Width - (nvscrollbar ? vScrollBar1.Width : 0)) hScrollBar1.Visible = true;
            if (vScrollBar1.Maximum > viewPanel.Height - (nhscrollbar ? hScrollBar1.Height : 0)) vScrollBar1.Visible = true;

            vScrollBar1.Visible = nvscrollbar;
            hScrollBar1.Visible = nhscrollbar;

            if (vScrollBar1.Visible)
            {
                // Docking isn't enough because we want that it will be high/wider when only one of the scroll bars is visible
                //vScrollBar1.Location = new Point(splitContainer1.SplitterDistance - 19, 0);
                vScrollBar1.Height = viewPanel.Height - (hScrollBar1.Visible ? hScrollBar1.Height : 0);
                vScrollBar1.LargeChange = vScrollBar1.Height;
                hScrollBar1.Value = Math.Max(0, Math.Min(hScrollBar1.Value, hScrollBar1.Maximum - hScrollBar1.LargeChange));
            }
            else
            {
                //GraphicPanel.ScreenY = 0;
                vScrollBar1.Value = 0;
            }
            if (hScrollBar1.Visible)
            {
                //hScrollBar1.Location = new Point(0, splitContainer1.Height - 18);
                hScrollBar1.Width = viewPanel.Width - (vScrollBar1.Visible ? vScrollBar1.Width : 0);
                hScrollBar1.LargeChange = hScrollBar1.Width;
                vScrollBar1.Value = Math.Max(0, Math.Min(vScrollBar1.Value, vScrollBar1.Maximum - vScrollBar1.LargeChange));
            }
            else
            {
                //GraphicPanel.ScreenX = 0;
                hScrollBar1.Value = 0;
            }

            if (hScrollBar1.Visible && vScrollBar1.Visible)
            {
                panel3.Visible = true;
                //panel3.Location = new Point(hScrollBar1.Width, vScrollBar1.Height);
            }
            else panel3.Visible = false;
        }


        private void SetViewSize(int width = 0, int height = 0)
        {
            vScrollBar1.Maximum = height;
            hScrollBar1.Maximum = width;

            /*GraphicPanel.DrawWidth = Math.Min(width, GraphicPanel.Width);
            GraphicPanel.DrawHeight = Math.Min(height, GraphicPanel.Height);*/

            Form1_Resize(null, null);

            hScrollBar1.Value = Math.Max(0, Math.Min(hScrollBar1.Value, hScrollBar1.Maximum - hScrollBar1.LargeChange));
            vScrollBar1.Value = Math.Max(0, Math.Min(vScrollBar1.Value, vScrollBar1.Maximum - vScrollBar1.LargeChange));
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_Click(sender, e);
        }

        private void GraphicPanel_Render(object sender, EventArgs e)
        {

            if (GraphicPanel.MeasuredFPS != lastFPS)
            {
                lastFPS = GraphicPanel.MeasuredFPS;
                this.Text = String.Format("{0} FPS", lastFPS);
            }

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Enable(EnableCap.DepthTest);

            GL.Color3(System.Drawing.Color.White);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(0, 0);
            GL.Vertex2(0, SceneHeight);
            GL.Vertex2(SceneWidth, SceneHeight);
            GL.Vertex2(SceneWidth, 0);
            GL.End();
            /*GL.PushMatrix();
            GL.Translate(100f, 0.0, 0.0);
            GL.LineWidth(5.0f * (float)GraphicPanel.Zoom);
            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex2(100f, 0f);
            GL.Vertex2(200f, 100f);
            GL.Vertex2(200f, 200f);
            GL.End();
            GL.PopMatrix();*/
            
     
            // hmm, if I call refresh when I update the values, for some reason it will stop to render until I stop calling refrsh
            // So I will refresh it here
            if (entitiesToolbar?.NeedRefresh ?? false) entitiesToolbar.PropertiesRefresh();
            if (Scene != null)
            {
                GL.PushMatrix();
                GL.Translate(0, 0, LAYER_DEPTH);
                /*if (!IsTilesEdit())
                    Background.Draw(GraphicPanel);*/
               
                GL.Translate(0, 0, LAYER_DEPTH);
                if (ShowFGLow.Checked || EditFGLow.Checked)
                    FGLow.Draw(GraphicPanel);

                GL.Translate(0, 0, LAYER_DEPTH);
                /*if (ShowEntities.Checked && !EditEntities.Checked)
                    entities.Draw(GraphicPanel);*/

                GL.Translate(0, 0, LAYER_DEPTH);
                if (ShowFGHigh.Checked || EditFGHigh.Checked)
                    FGHigh.Draw(GraphicPanel);

                GL.PopMatrix();
                /*if (EditEntities.Checked)
                    entities.Draw(GraphicPanel);*/
            }
            /*if (draggingSelection)
            {
                int x1 = (int)(selectingX / Zoom), x2 = (int)(lastX / Zoom);
                int y1 = (int)(selectingY / Zoom), y2 = (int)(lastY / Zoom);
                if (x1 != x2 && y1 != y2)
                {
                    if (x1 > x2)
                    {
                        x1 = (int)(lastX / Zoom);
                        x2 = (int)(selectingX / Zoom);
                    }
                    if (y1 > y2)
                    {
                        y1 = (int)(lastY / Zoom);
                        y2 = (int)(selectingY / Zoom);
                    }

                    GraphicPanel.DrawRectangle(x1, y1, x2, y2, Color.FromArgb(50, Color.Purple));

                    GraphicPanel.DrawLine(x1, y1, x2, y1, Color.Purple);
                    GraphicPanel.DrawLine(x1, y1, x1, y2, Color.Purple);
                    GraphicPanel.DrawLine(x2, y2, x2, y1, Color.Purple);
                    GraphicPanel.DrawLine(x2, y2, x1, y2, Color.Purple);
                }
            }
            if (scrolling)
            {
                if (vScrollBar1.Visible && hScrollBar1.Visible) GraphicPanel.Draw2DCursor(scrollPosition.X, scrollPosition.Y);
                else if (vScrollBar1.Visible) GraphicPanel.DrawVertCursor(scrollPosition.X, scrollPosition.Y);
                else if (hScrollBar1.Visible) GraphicPanel.DrawHorizCursor(scrollPosition.X, scrollPosition.Y);
            }*/
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.DepthTest);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*GraphicPanel.Init(this);*/
        }

        private void LayerShowButton_Click(ToolStripButton button, string desc)
        {
            if (button.Checked)
            {
                button.Checked = false;
                button.ToolTipText = "Show " + desc;
            }
            else
            {
                button.Checked = true;
                button.ToolTipText = "Hide " + desc;
            }
        }

        private void ShowFGLow_Click(object sender, EventArgs e)
        {
            LayerShowButton_Click(ShowFGLow, "Layer FG Low");
        }

        private void ShowFGHigh_Click(object sender, EventArgs e)
        {
            LayerShowButton_Click(ShowFGHigh, "Layer FG High");
        }

        private void ShowEntities_Click(object sender, EventArgs e)
        {
            LayerShowButton_Click(ShowEntities, "Entities");
        }

        public void Deselect(bool updateControls = true)
        {
            if (IsEditing())
            {
                EditLayer?.Deselect();
                if (IsEntitiesEdit()) entities.Deselect();
                SetSelectOnlyButtonsState(false);
                if (updateControls)
                    UpdateEditLayerActions();
            }
            //MagnetDisable();
        }        

        private void LayerEditButton_Click(ToolStripButton button)
        {
            Deselect(false);
            if (button.Checked)
            {
                button.Checked = false;
            }
            else
            {
                EditFGLow.Checked = false;
                EditFGHigh.Checked = false;
                EditEntities.Checked = false;
                button.Checked = true;
            }
            UpdateControls();
        }

        private void EditFGLow_Click(object sender, EventArgs e)
        {
            LayerEditButton_Click(EditFGLow);
        }

        private void EditFGHigh_Click(object sender, EventArgs e)
        {
            LayerEditButton_Click(EditFGHigh);
        }

        private void EditEntities_Click(object sender, EventArgs e)
        {
            LayerEditButton_Click(EditEntities);
        }
        

        private void Save_Click(object sender, EventArgs e)
        {
            if (Scene == null) return;

            if (IsTilesEdit())
            {
                // Apply changes
                Deselect();
            }

            Scene.Write(SceneFilename);
        }

        private void MagnetMode_Click(object sender, EventArgs e)
        {
        }
        

        private void New_Click(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Click(sender, e);
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void saveAspngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Scene != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = ".png File|*.png";
                save.DefaultExt = "png";
                if (save.ShowDialog() != DialogResult.Cancel)
                {
                    using (Bitmap bitmap = new Bitmap(SceneWidth, SceneHeight))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            FGLow.Draw(g);
                            FGHigh.Draw(g);
                        }
                        bitmap.Save(save.FileName);
                    }
                }
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Form1_Resize(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLayer?.FlipPropertySelected(1 << 10);
            UpdateEditLayerActions();
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTilesEdit())
            {
                TilesClipboard = EditLayer.CopyToClipboard();
            }
            else if (IsEntitiesEdit())
            {
                entitiesClipboard = entities.CopyToClipboard();
            }
            UpdateControls();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTilesEdit())
            {
                EditLayer.PasteFromClipboard(new Point(16, 16), EditLayer.CopyToClipboard(true));
                UpdateEditLayerActions();
            }
            else if (IsEntitiesEdit())
            {
                try
                {
                    entities.PasteFromClipboard(new Point(16, 16), entities.CopyToClipboard(true));
                    UpdateLastEntityAction();
                }
                catch (EditorEntities.TooManyEntitiesException)
                {
                    MessageBox.Show("Too many entities! (limit: 2048)");
                    return;
                }
                UpdateEntitiesToolbarList();
                SetSelectOnlyButtonsState();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorUndo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorRedo();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            EditorUndo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            EditorRedo();
        }

        public void EditorUndo()
        {
            if (undo.Count > 0)
            {
                if (IsTilesEdit())
                {
                    // Deselect to apply the changes
                    Deselect();
                } 
                else if (IsEntitiesEdit())
                {
                    if (undo.Peek() is ActionAddDeleteEntities)
                    {
                        // deselect only if delete/create
                        Deselect();
                    }
                }
                IAction act = undo.Pop();
                act.Undo();
                redo.Push(act.Redo());
                if (IsEntitiesEdit() && IsSelected())
                {
                    // We need to update the properties of the selected entity
                    entitiesToolbar.UpdateCurrentEntityProperites();
                }
            }
            UpdateControls();
        }

        public void EditorRedo()
        {
            if (redo.Count > 0)
            {
                IAction act = redo.Pop();
                act.Undo();
                undo.Push(act.Redo());
                if (IsEntitiesEdit() && IsSelected())
                {
                    // We need to update the properties of the selected entity
                    entitiesToolbar.UpdateCurrentEntityProperites();
                }
            }
            UpdateControls();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTilesEdit())
            {
                TilesClipboard = EditLayer.CopyToClipboard();
                DeleteSelected();
                UpdateControls();
                UpdateEditLayerActions();
            }
            else if (IsEntitiesEdit())
            {
                entitiesClipboard = entities.CopyToClipboard();
                DeleteSelected();
                UpdateControls();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (IsTilesEdit() && TilesClipboard != null)
            {
                EditLayer.PasteFromClipboard(new Point((int)(ShiftX / Zoom) + EditorLayer.TILE_SIZE - 1, (int)(ShiftY / Zoom) + EditorLayer.TILE_SIZE - 1), TilesClipboard);
                UpdateEditLayerActions();
            }
            else if (IsEntitiesEdit())
            {
                try
                {
                    entities.PasteFromClipboard(new Point((int)(ShiftX / Zoom), (int)(ShiftY / Zoom)), entitiesClipboard);
                    UpdateLastEntityAction();
                }
                catch (EditorEntities.TooManyEntitiesException)
                {
                    MessageBox.Show("Too many entities! (limit: 2048)");
                    return;
                }
                UpdateEntitiesToolbarList();
                SetSelectOnlyButtonsState();
            }*/
        }

        private void GraphicPanel_MouseEnter(object sender, EventArgs e)
        {
            //GraphicPanel.Focus();
        }

        private void GraphicPanel_DragEnter(object sender, DragEventArgs e)
        {
            /*if (e.Data.GetDataPresent(typeof(Int32)) && IsTilesEdit())
            {
                Point rel = GraphicPanel.PointToScreen(Point.Empty);
                e.Effect = DragDropEffects.Move;
                // (ushort)((Int32)e.Data.GetData(e.Data.GetFormats()[0])
                EditLayer.StartDragOver(new Point((int)(((e.X - rel.X) + ShiftX) / Zoom), (int)(((e.Y - rel.Y) + ShiftY) / Zoom)), (ushort)TilesToolbar.SelectedTile);
                UpdateEditLayerActions();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }*/
        }

        private void GraphicPanel_DragOver(object sender, DragEventArgs e)
        {
            /*if (e.Data.GetDataPresent(typeof(Int32)) && IsTilesEdit())
            {
                Point rel = GraphicPanel.PointToScreen(Point.Empty);
                EditLayer.DragOver(new Point((int)(((e.X - rel.X) + ShiftX) / Zoom), (int)(((e.Y - rel.Y) + ShiftY) / Zoom)), (ushort)TilesToolbar.SelectedTile);
                GraphicPanel.Render();
            }*/
        }

        private void GraphicPanel_DragLeave(object sender, EventArgs e)
        {
            EditLayer?.EndDragOver(true);
            //GraphicPanel.Invalidate();
        }

        private void GraphicPanel_DragDrop(object sender, DragEventArgs e)
        {
            EditLayer?.EndDragOver(false);
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            ZoomLevel += 1;
            if (ZoomLevel > 5) ZoomLevel = 5;
            if (ZoomLevel < -5) ZoomLevel = -5;

            SetZoomLevel(ZoomLevel, new Point(0, 0));
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            ZoomLevel -= 1;
            if (ZoomLevel > 5) ZoomLevel = 5;
            if (ZoomLevel < -5) ZoomLevel = -5;

            SetZoomLevel(ZoomLevel, new Point(0, 0));
        }

        private void selectTool_Click(object sender, EventArgs e)
        {
            selectTool.Checked = !selectTool.Checked;
            pointerButton.Checked = false;
            placeTilesButton.Checked = false;
            UpdateControls();
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            pointerButton.Checked = !pointerButton.Checked;
            selectTool.Checked = false;
            placeTilesButton.Checked = false;
            UpdateControls();
        }

        private void placeTilesButton_Click(object sender, EventArgs e)
        {
            placeTilesButton.Checked = !placeTilesButton.Checked;
            selectTool.Checked = false;
            pointerButton.Checked = false;
            UpdateControls();
        }

        private void MapEditor_Activated(object sender, EventArgs e)
        {
            GraphicPanel.Focus();
        }

        private void MapEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (!GraphicPanel.Focused && e.Control)
            {
                GraphicPanel_OnKeyDown(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Scene == null) return;

            if (IsTilesEdit())
            {
                // Apply changes
                Deselect();
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Scene File|*.bin";
            save.DefaultExt = "bin";
            save.InitialDirectory = Path.GetDirectoryName(SceneFilename);
            save.RestoreDirectory = false;
            save.FileName = Path.GetFileName(SceneFilename);
            if (save.ShowDialog() != DialogResult.Cancel)
            {
                Scene.Write(save.FileName);
            }
        }

        private void MapEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (!GraphicPanel.Focused && e.Control)
            {
                GraphicPanel_OnKeyUp(sender, e);
            }
        }

        private void flipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLayer?.FlipPropertySelected(1 << 11);
            UpdateEditLayerActions();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            GraphicPanel.ScreenY = (int)(e.NewValue / GraphicPanel.Zoom);
            //GraphicPanel.Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            GraphicPanel.ScreenX = (int)(e.NewValue / GraphicPanel.Zoom);
            //GraphicPanel.Invalidate();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            GraphicPanel.ScreenY = (int)((sender as VScrollBar).Value / GraphicPanel.Zoom);
            //if(!(zooming || draggingSelection || dragged || scrolling)) GraphicPanel.Invalidate();

            /*if (draggingSelection)
            {
                GraphicPanel.OnMouseMoveEventCreate();
            }*/
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            GraphicPanel.ScreenX = (int)((sender as HScrollBar).Value / GraphicPanel.Zoom);
            //if (!(zooming || draggingSelection || dragged || scrolling)) GraphicPanel.Invalidate();
        }

        public void DisposeTextures()
        {
            if (FGHigh != null) FGHigh.DisposeTextures();
            if (FGLow != null) FGLow.DisposeTextures();
        }

        public Rectangle GetScreen()
        {
            //return new Rectangle(ShiftX, ShiftY, viewPanel.Width, viewPanel.Height);
            return new Rectangle(0, 0, viewPanel.Width, viewPanel.Height);
        }

        public double GetZoom()
        {
            return GraphicPanel.Zoom;
        }
    }
}