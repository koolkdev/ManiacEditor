using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    class TexCoords
    {
        public float[] coords;
        int count;
        int width;
        int height;

        VertexBuffer vb = new VertexBuffer();

        public int Count
        {
            get { return count / 2; }
        }

        public TexCoords(float[] buf, int width, int height)
        {
            coords = buf;
            count = 0;

            this.width = width;
            this.height = height;
        }

        public void Create()
        {
            vb.Create();
        }

        public void Destroy()
        {
            if (vb.IsCreated())
            {
                vb.Destroy();
            }
        }

        public void SetBuffer(float[] buf)
        {
            coords = buf;
            count = 0;
        }

        public void Add(int x, int y, int width, int height, bool flipX=false, bool flipY=false)
        {
            int right = x;
            int left = x + width;
            int top = y;
            int bottom = y + height;
            if (flipX)
            {
                right = left;
                left = x;
            }
            if (flipY)
            {
                top = bottom;
                bottom = y;

            }
            coords[count++] = (float)right / this.width;
            coords[count++] = (float)top / this.height;

            coords[count++] = (float)left / this.width;
            coords[count++] = (float)top / this.height;

            coords[count++] = (float)left / this.width;
            coords[count++] = (float)bottom / this.height;

            coords[count++] = (float)right / this.width;
            coords[count++] = (float)bottom / this.height;
        }

        public void Reset()
        {
            count = 0;
        }

        public void SetData()
        {
            if (!vb.IsCreated())
            {
                Create();
            }
            vb.Bind();
            vb.SetData(coords);
            vb.Unbind();
        }

        public void UpdateData()
        {
            if (!vb.IsCreated())
            {
                Create();
                SetData();
            }
            else
            {
                vb.Bind();
                vb.UpdateData(coords);
                vb.Unbind();
            }
        }

        public void Load()
        {
            vb.Bind();
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, IntPtr.Zero);
        }

        public void Unload()
        {

            GL.DisableClientState(ArrayCap.TextureCoordArray);
            vb.Unbind();
        }

    }
}
