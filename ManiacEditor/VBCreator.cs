using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ManiacEditor
{
    class VBCreator : IDisposable
    {
        List<float> vertices = new List<float>();

        public void AddRectangle(Rectangle rect)
        {
            vertices.AddRange(new float[] {
                rect.Left, rect.Top,
                rect.Right, rect.Top,
                rect.Right, rect.Bottom,
                rect.Left, rect.Bottom,
            });
        }

        public void AddRectangleOutline(Rectangle rect)
        {
            vertices.AddRange(new float[] {
                rect.Left, rect.Top,
                rect.Right, rect.Top,
                rect.Right, rect.Top,
                rect.Right, rect.Bottom,
                rect.Right, rect.Bottom,
                rect.Left, rect.Bottom,
                rect.Left, rect.Bottom,
                rect.Left, rect.Top,
            });
        }

        public Vertices GetVertices()
        {
            Vertices v = new Vertices(vertices.ToArray());
            v.SetData();
            v.SetDataSize(vertices.Count);
            return v;
        } 

        public void Dispose()
        {

        }
    }
}
