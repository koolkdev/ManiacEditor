using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using SharpDX.Direct3D9;
using SharpDX;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ManiacEditor
{
    public class TextureCreator
    {
        public static Texture FromBitmap(Device device, Bitmap bitmap)
        {
            Texture texture = new Texture(device, bitmap.Width, bitmap.Height, 1, Usage.Dynamic, Format.A8R8G8B8, Pool.Default);
            DataStream data;
            DataRectangle rec = texture.LockRectangle(0, LockFlags.None, out data);
            BitmapData bd = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int bufferSize = bd.Height * bd.Stride;

            //create data buffer 
            byte[] bytes = new byte[bufferSize];

            // copy bitmap data into buffer
            Marshal.Copy(bd.Scan0, bytes, 0, bytes.Length);
            data.Write(bytes, 0, bytes.Length);

            texture.UnlockRectangle(0);
            bitmap.UnlockBits(bd);
            return texture;
        }

        public static Texture FromBitmapSlow(Device device, Bitmap bitmap)
        {
            // The fast function doesn't work for all textures, even with correct pixel format, not sure why
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return Texture.FromStream(device, memoryStream);
            }
        }
    }
}
