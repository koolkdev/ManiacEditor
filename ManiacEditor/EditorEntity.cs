using RSDKv5;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ManiacEditor
{
    class EditorEntity : IDrawable
    {
        protected const int NAME_BOX_WIDTH  = 20;
        protected const int NAME_BOX_HEIGHT = 20;

        protected const int NAME_BOX_HALF_WIDTH  = NAME_BOX_WIDTH  / 2;
        protected const int NAME_BOX_HALF_HEIGHT = NAME_BOX_HEIGHT / 2;

        public bool Selected;

        private RSDKv5.SceneEntity entity;

        public static Dictionary<string, EditorAnimation> Animations = new Dictionary<string, EditorAnimation>();
        public static Dictionary<string, Bitmap> Sheets = new Dictionary<string, Bitmap>();
        public static string[] DataDirectoryList = null;
        public RSDKv5.Animation rsdkAnim;
        public DateTime lastFrametime;
        public int index = 0;
        public RSDKv5.SceneEntity Entity { get { return entity; } }

        public EditorEntity(RSDKv5.SceneEntity entity)
        {
            this.entity = entity;
            lastFrametime = DateTime.Now;
        }
 
        public void Draw(Graphics g)
        {
        }

        public bool ContainsPoint(Point point)
        {
            return GetDimensions().Contains(point);
        }

        public bool IsInArea(Rectangle area)
        {
            return GetDimensions().IntersectsWith(area);
        }

        public void Move(Point diff)
        {
            entity.Position.X.High += (short)diff.X;
            entity.Position.Y.High += (short)diff.Y;
        }

        public Rectangle GetDimensions()
        {
            return new Rectangle(entity.Position.X.High, entity.Position.Y.High, NAME_BOX_WIDTH, NAME_BOX_HEIGHT);
        }

        public Bitmap CropImage(Bitmap source, Rectangle section, bool fliph, bool flipv)
        {
            Bitmap bmp2 = new Bitmap(section.Size.Width, section.Size.Height);
            using (Graphics gg = Graphics.FromImage(bmp2))
                gg.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            if (fliph && flipv)
                bmp2.RotateFlip(RotateFlipType.RotateNoneFlipXY);
            else if (fliph)
                bmp2.RotateFlip(RotateFlipType.RotateNoneFlipX);
            else if (flipv)
                bmp2.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Bitmap bmp = new Bitmap(1024, 1024);
            using (Graphics g = Graphics.FromImage(bmp))
                g.DrawImage(bmp2, 0, 0, new Rectangle(0, 0, bmp2.Width, bmp2.Height), GraphicsUnit.Pixel);
            return bmp;
        }

        public Bitmap RemoveColourImage(Bitmap source, System.Drawing.Color colour, int width, int height)
        {
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (source.GetPixel(x, y) == colour)
                        source.SetPixel(x, y, System.Drawing.Color.Transparent);
                }
            }
            return source;
        }

        /// <summary>
        /// Loads / Gets the Sprite Animation
        /// NOTE: 
        /// </summary>
        /// <param name="name">The Name of the object</param>
        /// <param name="d">The DevicePanel</param>
        /// <param name="AnimId">The Animation ID (-1 to Load Normal)</param>
        /// <param name="frameId">The Frame ID for the specified Animation (-1 to load all frames)</param>
        /// <param name="fliph">Flip the Texture Horizontally</param>
        /// <param name="flipv">Flip the Texture Vertically</param>
        /// <returns>The fully loaded Animation</returns>
        public EditorAnimation LoadAnimation(string name, DevicePanel d, int AnimId, int frameId, bool fliph, bool flipv)
        {

            string key = $"{name}-{AnimId}-{frameId}-{fliph}-{flipv}";
            if (Animations.ContainsKey(key))
            {
                // Use the already loaded Amination
                return Animations[key];
            }

            if (DataDirectoryList == null)
                DataDirectoryList = Directory.GetFiles(Editor.DataDirectory, $"*.bin", SearchOption.AllDirectories);


            // Checks Global frist
            string path = "Global\\" + name + ".bin";
            string path2 = Path.Combine(Editor.DataDirectory, "sprites") + '\\' + path;
            if (!File.Exists(path2))
            {
                // Checks Global frist
                path = Editor.Instance.SelectedZone + "\\" + name + ".bin";
                path2 = Path.Combine(Editor.DataDirectory, "sprites") + '\\' + path;
            }
            if (!File.Exists(path2))
            {
                // Seaches all around the Data directory
                var list = DataDirectoryList;
                if (list.Any(t => t.ToLower().Contains(name)))
                {
                    list = list.Where(t => t.ToLower().Contains(name)).ToArray();
                    if (list.Any(t => t.ToLower().Contains(Editor.Instance.SelectedZone)))
                        path2 = list.Where(t => t.ToLower().Contains(Editor.Instance.SelectedZone)).First();
                    else
                        path2 = list.First();
                }
            }
            if (!File.Exists(path2))
            {
                // No Admination Found
                return null;
            }

            using (var stream = File.OpenRead(path2))
            {
                rsdkAnim = new Animation();
                rsdkAnim.Load(new BinaryReader(stream));
            }
            var anim = new EditorAnimation();
            if (AnimId == -1)
            {
                if (rsdkAnim.Animations.Any(t => t.AnimName.Contains("Normal")))
                    AnimId = rsdkAnim.Animations.FindIndex(t => t.AnimName.Contains("Normal"));
                else AnimId = 0;
            }
            for (int i = 0; i < rsdkAnim.Animations[AnimId].Frames.Count; ++i)
            {
                var frame = rsdkAnim.Animations[AnimId].Frames[i];
                if (frameId != -1)
                    frame = rsdkAnim.Animations[AnimId].Frames[frameId];
                Bitmap map;
                if (!Sheets.ContainsKey(rsdkAnim.SpriteSheets[frame.SpriteSheet]))
                {
                    map = new Bitmap(Path.Combine(Editor.DataDirectory, "sprites", rsdkAnim.SpriteSheets[frame.SpriteSheet].Replace('/', '\\')));
                    Sheets.Add(rsdkAnim.SpriteSheets[frame.SpriteSheet], map);
                }
                else
                    map = Sheets[rsdkAnim.SpriteSheets[frame.SpriteSheet]];

                if (frame.Width == 0 || frame.Height == 0)
                    continue;
                // We are storing the first colour from the palette so we can use it to make sprites transparent
                var colour = map.Palette.Entries[0];
                // Slow
                map = CropImage(map, new Rectangle(frame.X, frame.Y, frame.Width, frame.Height), fliph, flipv);
                RemoveColourImage(map, colour, frame.Width, frame.Height);
                
                var texture = TextureCreator.FromBitmapSlow(d._device, map);
                var editorFrame = new EditorAnimation.EditorFrame()
                {
                    Texture = texture,
                    Frame = frame,
                    Entry = rsdkAnim.Animations[AnimId]
                };
                anim.Frames.Add(editorFrame);
                if (frameId != -1)
                    break;
            }

            Animations.Add(key, anim);
            return anim;

        }

        // allow derived types to override the draw
        public virtual void Draw(DevicePanel d)
        {
            if (!d.IsObjectOnScreen(entity.Position.X.High, entity.Position.Y.High, NAME_BOX_WIDTH, NAME_BOX_HEIGHT)) return;
            System.Drawing.Color color = Selected ? System.Drawing.Color.MediumPurple : System.Drawing.Color.MediumTurquoise;
            System.Drawing.Color color2 = System.Drawing.Color.DarkBlue;
            int Transparency = (Editor.Instance.EditLayer == null) ? 0xff : 0x32;

            int x = entity.Position.X.High;
            int y = entity.Position.Y.High;

            var editorAnim = LoadAnimation(entity.Object.Name.Name, d, -1, -1, false, false);
            if (editorAnim != null && editorAnim.Frames.Count > 0)
            {
                // Just incase
                if (index >= editorAnim.Frames.Count)
                    index = 0;
                var frame = editorAnim.Frames[index];
                if (entity.attributesMap.ContainsKey("frameID"))
                {
                    if (entity.attributesMap["frameID"].ValueInt8 >= 0)
                        frame = editorAnim.Frames[entity.attributesMap["frameID"].ValueInt8 % editorAnim.Frames.Count];
                    else
                        frame = null; // Don't Render the Animation
                }

                // Playback
                if (Editor.Instance.ShowAnimations.Checked)
                {
                    if (frame.Entry.FrameSpeed > 0)
                        if ((DateTime.Now - lastFrametime).Milliseconds > frame.Entry.FrameSpeed)
                        {
                            index++;
                            lastFrametime = DateTime.Now;
                        }
                    if (index == editorAnim.Frames.Count)
                        index = 0;//frame.Entry.FrameLoop;
                }
                else index = 0;
                if (frame != null)
                {
                    // Draw the normal filled Rectangle but Its visible if you have the entity selected
                    d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Selected ? 0x40 : 0x00, System.Drawing.Color.MediumPurple));
                    if (!(entity.Object.Name.Name == "Spikes")) // Don't render some Special Objects
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                            frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
                else
                { // No frame to render
                    d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color));
                }
                // Draws the Special Objects
                DrawOthers(d);
            }
            else
            {
                if (entity.Object.Name.Name == "Spring") DrawOthers(d);
                else
                    d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color));
            }

            d.DrawLine(x, y, x + NAME_BOX_WIDTH, y, System.Drawing.Color.FromArgb(Transparency, color2));
            d.DrawLine(x, y, x, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color2));
            d.DrawLine(x, y + NAME_BOX_HEIGHT, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color2));
            d.DrawLine(x + NAME_BOX_WIDTH, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color2));

            if (Editor.Instance.GetZoom() >= 1) d.DrawTextSmall(String.Format("{0} (ID: {1})", entity.Object.Name, entity.SlotID), x + 2, y + 2, NAME_BOX_WIDTH - 4, System.Drawing.Color.FromArgb(Transparency, System.Drawing.Color.Black), true);
        }

        // These are special
        public void DrawOthers(DevicePanel d)
        {
            int x = entity.Position.X.High;
            int y = entity.Position.Y.High;
            int Transparency = (Editor.Instance.EditLayer == null) ? 0xff : 0x32;
            if (entity.Object.Name.Name == "ItemBox")
            {
                var value = entity.attributesMap["type"];
                var editorAnim = LoadAnimation("ItemBox", d, 2, (int)value.ValueVar, false, false);
                if (editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[0];
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY - 3,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            if (entity.Object.Name.Name == "Bridge")
            {
                var value = entity.attributesMap["length"].ValueUInt8 / 2;
                var editorAnim = LoadAnimation("Bridge", d, 0, 0, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[0];
                    for (int i = -value; i < value + 1; ++i)
                    {
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX + (i * (frame.Frame.Width + 2)),
                            y + frame.Frame.CenterY, frame.Frame.Width, frame.Frame.Height, false, Transparency);
                    }
                }
            }
            if (entity.Object.Name.Name == "Spikes")
            {
                var value = entity.attributesMap["type"];
                bool fliph = false;
                bool flipv = false;
                int animID = 0;
                
                // Down
                if (value.ValueVar == 1)
                {
                    flipv = true;
                    animID = 0;
                }
                // Right
                if (value.ValueVar == 2)
                {
                    animID = 1;
                }
                // Left
                if (value.ValueVar == 3)
                {
                    fliph = true;
                    animID = 1;
                }
                var editorAnim = LoadAnimation("Spikes", d, animID, 0, fliph, flipv);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[0];
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }

            }

            if (entity.Object.Name.Name == "Spring")
            {
                var animID = entity.attributesMap["type"].ValueVar;
                var flipFlag = entity.attributesMap["flipFlag"].ValueVar;
                bool fliph = false;
                bool flipv = false;
                // Down
                if (flipFlag == 2)
                    flipv = true;
                // Left
                if (flipFlag == 1)
                    fliph = true;

                var editorAnim = LoadAnimation("Springs", d, (int)animID, -1, fliph, flipv);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];

                    // Playback
                    if (Editor.Instance.ShowAnimations.Checked)
                    {
                        if (frame.Entry.FrameSpeed > 0)
                            if ((DateTime.Now - lastFrametime).Milliseconds > frame.Entry.FrameSpeed)
                            {
                                index++;
                                lastFrametime = DateTime.Now;
                            }
                        if (index == editorAnim.Frames.Count)
                            index = 0;//frame.Entry.FrameLoop;
                    }
                    else index = 0;

                    d.DrawBitmap(frame.Texture,
                        x + frame.Frame.CenterX - (fliph ? (frame.Frame.Width - editorAnim.Frames[0].Frame.Width) : 0),
                        y + frame.Frame.CenterY + (flipv ? (frame.Frame.Height) : 0),
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }

            }
        }

        public static void ReleaseResources()
        {
            DataDirectoryList = null;

            foreach (var pair in Sheets)
                pair.Value.Dispose();
            Sheets.Clear();

            foreach (var pair in Animations)
                foreach (var pair2 in pair.Value.Frames)
                    pair2.Texture.Dispose();

            Animations.Clear();

        }

        public class EditorAnimation
        {
            public List<EditorFrame> Frames = new List<EditorFrame>();
            public class EditorFrame
            {
                public Texture Texture;
                public Animation.Frame Frame;
                public Animation.AnimationEntry Entry;
            }
        }
    }
}
