using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using RSDKv5Color = RSDKv5.Color;

namespace ManiacEditor
{
    class EditorBackground : IDrawable
    {
        const int BOX_SIZE = 8;

        Vertices vb1;
        Vertices vb2;

        static int DivideRoundUp(int number, int by)
        {
            return (number + by - 1) / by;
        }

        int width;
        int height;

        public EditorBackground(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw(Graphics g)
        {
            
        }

        public void Draw(GLViewControl gl)
        {
            RSDKv5Color rcolor1 = Editor.Instance.Scene.EditorMetadata.BackgroundColor1;
            RSDKv5Color rcolor2 = Editor.Instance.Scene.EditorMetadata.BackgroundColor2;

            Color color1 = Color.FromArgb(rcolor1.A, rcolor1.R, rcolor1.G, rcolor1.B);
            Color color2 = Color.FromArgb(rcolor2.A, rcolor2.R, rcolor2.G, rcolor2.B);

            // Draw with first color everything
            if (vb1 == null)
            {
                using (var c = new VBCreator())
                {
                    c.AddRectangle(new Rectangle(0, 0, width, height));
                    vb1 = c.GetVertices();
                }
            }
            vb1.Draw(PrimitiveType.Quads, color1);

            if (color2.A != 0) {
                if (vb2 == null)
                {
                    using (var c = new VBCreator())
                    {
                        for (int y = 0; y < DivideRoundUp(height, BOX_SIZE * EditorLayer.TILE_SIZE); ++y)
                        {
                            for (int x = 0; x < DivideRoundUp(width, BOX_SIZE * EditorLayer.TILE_SIZE); ++x)
                            {
                                if ((x + y) % 2 == 1) c.AddRectangle(new Rectangle(x * BOX_SIZE * EditorLayer.TILE_SIZE, y * BOX_SIZE * EditorLayer.TILE_SIZE, BOX_SIZE * EditorLayer.TILE_SIZE, BOX_SIZE * EditorLayer.TILE_SIZE));
                            }
                        }
                        vb2 = c.GetVertices();
                    }
                }
                GL.PushMatrix();
                GL.Translate(0, 0, Editor.LAYER_DEPTH / 2);
                vb2.Draw(PrimitiveType.Quads, color2);
                GL.PopMatrix();
            }
        }

        public void DisposeGraphics()
        {
            vb1?.Destroy();
            vb1 = null;
            vb2?.Destroy();
            vb2 = null;
        }
    }
}
