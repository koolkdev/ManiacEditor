using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    class Indices
    {
        public uint[] indices;
        int count;

        IndexBuffer ib = new IndexBuffer();

        public int Count
        {
            get { return count; }
        }

        public Indices(uint[] buf)
        {
            indices = buf;
            count = 0;
        }

        public void Create()
        {
            ib.Create();
        }

        public void Destroy()
        {
            if (ib.IsCreated())
            {
                ib.Destroy();
            }
        }

        public void SetBuffer(uint[] buf)
        {
            indices = buf;
            count = 0;
        }

        public void Add(int index)
        {
            indices[count++] = (uint)index;
        }

        public void Add(uint index)
        {
            indices[count++] = index;
        }

        public void Reset()
        {
            count = 0;
        }

        public void SetData()
        {
            if (!ib.IsCreated())
            {
                Create();
            }
            ib.Bind();
            ib.SetData(indices);
            ib.Unbind();
        }

        public void UpdateData()
        {
            if (!ib.IsCreated())
            {
                Create();
                SetData();
            }
            else
            {
                ib.Bind();
                ib.UpdateData(indices);
                ib.Unbind();
            }
        }

        public void Load()
        {
            ib.Bind();
        }

        public void Unload()
        {
            ib.Unbind();
        }

    }
}
