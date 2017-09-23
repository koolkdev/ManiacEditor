using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using SystemColor = System.Drawing.Color;

namespace RSDKv5
{
    public class GIF : IDisposable
    {
        Bitmap bitmap;

        public Bitmap Bitmap { get { return bitmap; } }

        Dictionary<Tuple<Rectangle, bool, bool>, Bitmap> bitmapCache = new Dictionary<Tuple<Rectangle, bool, bool>, Bitmap>();

        public GIF(string filename)
        {
            bitmap = new Bitmap(filename);
            // TODO: Proper transparent (palette index 0)
            bitmap.MakeTransparent(SystemColor.FromArgb(0xff00ff));
        }

        public GIF(Bitmap bitmap)
        {
            this.bitmap = new Bitmap(bitmap);
        }

        private Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        public Bitmap GetBitmap(Rectangle section, bool flipX = false, bool flipY = false)
        {
            Bitmap bmp;
            if (bitmapCache.TryGetValue(new Tuple<Rectangle, bool, bool>(section, flipX, flipY), out bmp)) return bmp;

            bmp = CropImage(bitmap, section);
            if (flipX)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            if (flipY)
            {
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            bitmapCache[new Tuple<Rectangle, bool, bool>(section, flipX, flipY)] = bmp;
            return bmp;
        }

        public void Dispose()
        {
            bitmap.Dispose();
        }

        public GIF Clone()
        {
            return new GIF(bitmap);
        }
    }
}
