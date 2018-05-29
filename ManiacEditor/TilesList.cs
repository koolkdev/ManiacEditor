using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSDKv5;

namespace ManiacEditor
{
    public partial class TilesList : UserControl, IDrawArea
    {
        public GIF TilesImage = null;

        const int TILE_SIZE = 16;

        int _tileScale = 2;
        public int TileScale { get { return _tileScale; } set { _tileScale = value; AdjustControls(); } }

        public int BorderSize = 1;

        public int SelectedTile = -1;

        public Action<int> TileDoubleClick;

        public Point mouseDownPos;

        bool _flipHorizontal;
        bool _flipVertical;

        public bool FlipHorizontal { get { return _flipHorizontal; } set { _flipHorizontal = value; graphicPanel.Render(); } }
        public bool FlipVertical { get { return _flipVertical; } set { _flipVertical = value; graphicPanel.Render(); } }

        public TilesList()
        {
            InitializeComponent();
            
            graphicPanel.Init(this);
        }

        private void ResizeGraphicPanel(int width = 0, int height = 0)
        {
            graphicPanel.Width = width;
            graphicPanel.Height = height;
        }

        public void Reload()
        {
            TilesImage.Reload();
            graphicPanel.Refresh();
        }
        
        public void DisposeTextures()
        {
            TilesImage?.DisposeTextures();
        }

        private void graphicPanel_Resize(object sender, EventArgs e)
        {
            graphicPanel.ResetDevice();

        }

        private void graphicPanel_OnRender(object sender, DeviceEventArgs e)
        {

            if (TilesImage != null) {
                // Create a local version of the graphics object for the PictureBox.

                int tile_size = (TILE_SIZE + BorderSize * 2);

                int tiles_per_line = panel1.Width / tile_size / TileScale;

                // Draw a string on the PictureBox.
                for (int i = (vScrollBar1.Value / tile_size / TileScale) * tiles_per_line; i < ((vScrollBar1.Value + panel1.Height) / tile_size / TileScale) * tiles_per_line + tiles_per_line; ++i)
                {
                    if (i < 0x400)
                    {
                        graphicPanel.DrawBitmap(TilesImage.GetTexture(graphicPanel._device, new Rectangle(0, i * TILE_SIZE, TILE_SIZE, TILE_SIZE), _flipHorizontal, _flipVertical),
                            (i % tiles_per_line) * tile_size + BorderSize, (i / tiles_per_line) * tile_size + BorderSize, TILE_SIZE, TILE_SIZE, false, 255);
                    }
                    else
                    {
                        // Draw red X
                        graphicPanel.DrawLine(
                            (i % tiles_per_line) * tile_size + BorderSize, 
                            (i / tiles_per_line) * tile_size + BorderSize, 
                            (i % tiles_per_line) * tile_size + tile_size - BorderSize,
                            (i / tiles_per_line) * tile_size + tile_size - BorderSize, 
                            System.Drawing.Color.Red);
                        graphicPanel.DrawLine(
                            (i % tiles_per_line) * tile_size + tile_size - BorderSize * 2,
                            (i / tiles_per_line) * tile_size + BorderSize,
                            (i % tiles_per_line) * tile_size,
                            (i / tiles_per_line) * tile_size + tile_size - BorderSize,
                            System.Drawing.Color.Red);
                    }
                }
                for (int i = 0; i < tiles_per_line; ++i)
                {
                    graphicPanel.DrawLine(i * tile_size, vScrollBar1.Value / TileScale, i * tile_size, (vScrollBar1.Value + panel1.Height) / TileScale, System.Drawing.Color.Black);
                    graphicPanel.DrawLine(i * tile_size + tile_size - BorderSize, vScrollBar1.Value / TileScale, i * tile_size + tile_size - BorderSize, (vScrollBar1.Value + panel1.Height) / TileScale, System.Drawing.Color.Black);
                }
                for (int i = (vScrollBar1.Value / tile_size / TileScale); i < ((vScrollBar1.Value + panel1.Height) / tile_size / TileScale) + 1; ++i)
                {
                    graphicPanel.DrawLine(0, i * tile_size, tiles_per_line * tile_size, i * tile_size, System.Drawing.Color.Black);
                    graphicPanel.DrawLine(0, i * tile_size + tile_size - BorderSize, tiles_per_line * tile_size, i * tile_size + tile_size - BorderSize, System.Drawing.Color.Black);
                }
                if (SelectedTile != -1)
                {
                    graphicPanel.DrawLine((SelectedTile % tiles_per_line) * tile_size, (SelectedTile / tiles_per_line) * tile_size, (SelectedTile % tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile / tiles_per_line) * tile_size, System.Drawing.Color.Red);
                    graphicPanel.DrawLine((SelectedTile % tiles_per_line) * tile_size, (SelectedTile / tiles_per_line) * tile_size, (SelectedTile % tiles_per_line) * tile_size, (SelectedTile / tiles_per_line) * tile_size + tile_size - BorderSize, System.Drawing.Color.Red);
                    graphicPanel.DrawLine((SelectedTile % tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile / tiles_per_line) * tile_size, (SelectedTile % tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile / tiles_per_line) * tile_size + tile_size - BorderSize, System.Drawing.Color.Red);
                    graphicPanel.DrawLine((SelectedTile % tiles_per_line) * tile_size, (SelectedTile / tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile % tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile / tiles_per_line) * tile_size + tile_size - BorderSize, System.Drawing.Color.Red);
                    // TODO: Need to fix the line drawing the DevicePanel
                    graphicPanel.DrawLine((SelectedTile % tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile / tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile % tiles_per_line) * tile_size + tile_size - BorderSize, (SelectedTile / tiles_per_line) * tile_size + tile_size - BorderSize, System.Drawing.Color.Red);
                }
            }
        }

        public Rectangle GetScreen()
        {
            return new Rectangle(0, vScrollBar1.Value, graphicPanel.DrawWidth, graphicPanel.DrawHeight);
        }

        public double GetZoom()
        {
            return TileScale;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            AdjustControls();
        }

        private void AdjustControls()
        {
            int tile_size = (TILE_SIZE + BorderSize * 2);
            int tiles_per_line = panel1.Width / tile_size / TileScale;

            vScrollBar1.Maximum = ((0x400 + tiles_per_line + 1) / tiles_per_line) * tile_size * TileScale;
            vScrollBar1.LargeChange = Math.Min(panel1.Height, vScrollBar1.Maximum);
            if (vScrollBar1.LargeChange == vScrollBar1.Maximum)
                vScrollBar1.Enabled = false;
            else
                vScrollBar1.Enabled = true;
            vScrollBar1.SmallChange = tile_size * TileScale * (panel1.Height / tile_size / TileScale);
            vScrollBar1.Value = Math.Min(vScrollBar1.Value, vScrollBar1.Maximum - vScrollBar1.LargeChange);

            graphicPanel.DrawWidth = panel1.Width;
            graphicPanel.DrawHeight = Math.Max(vScrollBar1.Maximum, panel1.Height);
            while (panel1.Width > graphicPanel.Width)
                graphicPanel.Width *= 2;
            while (panel1.Height > graphicPanel.Height)
                graphicPanel.Height *= 2;
            graphicPanel.Render();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            graphicPanel.Render();
        }

        private void graphicPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            vScrollBar1.Value = Math.Max(Math.Min(vScrollBar1.Value - (e.Delta * vScrollBar1.SmallChange / 120), vScrollBar1.Maximum - vScrollBar1.LargeChange), 0);
        }

        private void ClickTile(int x, int y)
        {
            int tile_size = (TILE_SIZE + BorderSize * 2);
            int tiles_per_line = panel1.Width / tile_size / TileScale;

            int tile_number = ((y / tile_size / TileScale) * tiles_per_line) + (x / tile_size / TileScale);
            if (x / tile_size / TileScale < tiles_per_line && tile_number >= 0 && tile_number < 0x400)
            {
                SelectedTile = tile_number;
            }
            else
            {
                SelectedTile = -1;
            }
            graphicPanel.Render();
        }

        private void graphicPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickTile(e.X, e.Y);
                mouseDownPos = e.Location;
            }
        }

        private void graphicPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickTile(e.X, e.Y);
                if (SelectedTile != -1 && TileDoubleClick != null)
                {
                    TileDoubleClick(SelectedTile);
                }
            }
        }

        private void graphicPanel_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void graphicPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void graphicPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dynamic dx = e.X - mouseDownPos.X;
                dynamic dy = e.Y - mouseDownPos.Y;
                if (Math.Abs(dx) >= SystemInformation.DoubleClickSize.Width || Math.Abs(dy) >= SystemInformation.DoubleClickSize.Height)
                {
                    if (SelectedTile != -1)
                    {
                        Int32 val = SelectedTile;
                        DoDragDrop(val, DragDropEffects.Move);
                    }
                }
            }
        }

        public new void Dispose()
        {
            TilesImage?.Dispose();
            graphicPanel.Dispose();
            base.Dispose();
        }
    }
}
