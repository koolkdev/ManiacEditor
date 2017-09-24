using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    public class IndexBuffer
    {
        public void Create()
        {
            uint[] ids = new uint[1];
            GL.GenBuffers(1, ids);
            bufferObject = ids[0];
        }

        public void Destroy()
        {
            uint[] ids = new uint[1];
            ids[0] = bufferObject;
            GL.DeleteBuffers(1, ids);
            bufferObject = 0;
        }

        public void SetData(ushort[] rawData)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, rawData.Length * sizeof(ushort), rawData, BufferUsageHint.DynamicDraw);
        }

        public void SetData(uint[] rawData, int? count = null)
        {
            GL.BufferData(BufferTarget.ElementArrayBuffer, (count ?? rawData.Length) * sizeof(uint), rawData, BufferUsageHint.DynamicDraw);
        }

        public void UpdateData(uint[] rawData, int offset = 0, int? count = null)
        {
            GL.BufferSubData(BufferTarget.ElementArrayBuffer, (IntPtr)offset, (count ?? rawData.Length) * sizeof(uint), rawData);
        }

        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, bufferObject);
        }

        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public bool IsCreated() { return bufferObject != 0; }
        
        public uint IndexBufferObject
        {
            get { return bufferObject; }
        }

        private uint bufferObject;
    }

}
