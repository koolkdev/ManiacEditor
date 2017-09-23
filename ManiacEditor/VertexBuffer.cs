using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    public class VertexBuffer
    {
        public void Create()
        {
            //  Generate the vertex array.
            uint[] ids = new uint[1];
            GL.GenBuffers(1, ids);
            vertexBufferObject = ids[0];
        }

        public void Destroy()
        {
            uint[] ids = new uint[1];
            ids[0] = vertexBufferObject;
            GL.DeleteBuffers(1, ids);
            vertexBufferObject = 0;
        }

        public void SetData(float[] rawData, int? count = null)
        {
            GL.BufferData(BufferTarget.ArrayBuffer, (count ?? rawData.Length) * sizeof(float), rawData, BufferUsageHint.DynamicDraw);
        }

        public void UpdateData(float[] rawData, int offset=0, int? count = null)
        {
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)offset, (count ?? rawData.Length) * sizeof(float), rawData);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public bool IsCreated() { return vertexBufferObject != 0; }
        
        public uint VertexBufferObject
        {
            get { return vertexBufferObject; }
        }

        private uint vertexBufferObject;
    }
}