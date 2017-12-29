using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RSDKv5Color = RSDKv5.Color;

namespace ManiacEditor
{
    class EditorBackground : IDrawable
    {
        const int BOX_SIZE = 8;

        static int DivideRoundUp(int number, int by)
        {
            return (number + by - 1) / by;
        }

        public void Draw(Graphics g)
        {
            
        }

        public void Draw(DevicePanel d)
        {
            Rectangle screen = d.GetScreen();

            RSDKv5Color rcolor1 = Editor.Instance.EditorScene.EditorMetadata.BackgroundColor1;
            RSDKv5Color rcolor2 = Editor.Instance.EditorScene.EditorMetadata.BackgroundColor2;

            Color color1 = Color.FromArgb(rcolor1.A, rcolor1.R, rcolor1.G, rcolor1.B);
            Color color2 = Color.FromArgb(rcolor2.A, rcolor2.R, rcolor2.G, rcolor2.B);

            int start_x = screen.X / (BOX_SIZE * EditorLayer.TILE_SIZE);
            int end_x = Math.Min(DivideRoundUp(screen.X + screen.Width, BOX_SIZE * EditorLayer.TILE_SIZE), Editor.Instance.SceneWidth);
            int start_y = screen.Y / (BOX_SIZE * EditorLayer.TILE_SIZE);
            int end_y = Math.Min(DivideRoundUp(screen.Y + screen.Height, BOX_SIZE * EditorLayer.TILE_SIZE), Editor.Instance.Height);

            // Draw with first color everything
            d.DrawRectangle(screen.X, screen.Y, screen.X + screen.Width, screen.Y + screen.Height, color1);

            if (color2.A != 0) {
                for (int y = start_y; y < end_y; ++y)
                {
                    for (int x = start_x; x < end_x; ++x)
                    {
                        if ((x + y) % 2 == 1) d.DrawRectangle(x * BOX_SIZE * EditorLayer.TILE_SIZE, y * BOX_SIZE * EditorLayer.TILE_SIZE, (x + 1) * BOX_SIZE * EditorLayer.TILE_SIZE, (y + 1) * BOX_SIZE * EditorLayer.TILE_SIZE, color2);
                    }
                }
            }
        }
    }
}
