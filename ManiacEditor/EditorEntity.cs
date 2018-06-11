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

        private SceneEntity entity;

        public static Dictionary<string, EditorAnimation> Animations = new Dictionary<string, EditorAnimation>();
        public static Dictionary<string, Bitmap> Sheets = new Dictionary<string, Bitmap>();
        public static string[] DataDirectoryList = null;
        public static bool Working = false;
        public Animation rsdkAnim;
        public DateTime lastFrametime;
        public int index = 0;
        public SceneEntity Entity { get { return entity; } }

        public EditorEntity(SceneEntity entity)
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
            int size = ((section.Width > section.Height ? section.Width : section.Height) / 64) * 64;
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

        public List<LoadAnimationData> AnimsToLoad = new List<LoadAnimationData>();
        
        public void LoadNextAnimation()
        {
            if (AnimsToLoad.Count == 0)
                return;
            var val = AnimsToLoad[0];
            if (val.anim == null)
            {
                string key = $"{val.name}-{val.AnimId}-{val.frameId}-{val.fliph}-{val.flipv}-{val.rotate}";
                if (!Animations.ContainsKey(key))
                {
                    if (!Working)
                    {
                        try
                        {
                            LoadAnimation(val.name, val.d, val.AnimId, val.frameId, val.fliph, val.flipv, val.rotate, false);
                        }
                        catch (Exception e)
                        {
                            throw new ApplicationException($"Pop loading next animiation. {val.name}, {val.AnimId}, {val.frameId}, {val.fliph}, {val.flipv}, {val.rotate}", e);
                        }
                    }
                }
                else
                {
                    val.anim = Animations[key];
                }

            }
            if (val.anim == null)
                return;
            if (val.anim.Ready)
                AnimsToLoad.RemoveAt(0);
            else
            {
                if (val.anim.Frames.Count == 0)
                {
                    val.anim.Ready = true;
                    AnimsToLoad.RemoveAt(0);
                    return;
                }
                val.anim.Frames[val.anim.loadedFrames].Texture = TextureCreator.FromBitmap(val.d._device, val.anim.Frames[val.anim.loadedFrames]._Bitmap);
                val.anim.Frames[val.anim.loadedFrames]._Bitmap.Dispose();
                ++val.anim.loadedFrames;
                if (val.anim.loadedFrames == val.anim.Frames.Count)
                    val.anim.Ready = true;
            }
        }


        public class LoadAnimationData
        {
            public string name;
            public DevicePanel d;
            public int AnimId, frameId;
            public bool fliph, flipv, rotate;
            public EditorAnimation anim;
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
        public EditorAnimation LoadAnimation2(string name, DevicePanel d, int AnimId, int frameId, bool fliph, bool flipv, bool rotate)
        {
            string key = $"{name}-{AnimId}-{frameId}-{fliph}-{flipv}-{rotate}";
            if (Animations.ContainsKey(key))
            {
                if (Animations[key].Ready)
                {
                    // Use the already loaded Amination
                    return Animations[key];
                }
                else
                    return null;
            }
            var entry = new LoadAnimationData()
            {
                name = name,
                d = d,
                AnimId = AnimId,
                frameId = frameId,
                fliph = fliph,
                flipv = flipv,
                rotate = rotate
            };
            AnimsToLoad.Add(entry);
            return null;
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
        public EditorAnimation LoadAnimation(string name, DevicePanel d, int AnimId, int frameId, bool fliph, bool flipv, bool rotate, bool loadImageToDX = true)
        {

            string key = $"{name}-{AnimId}-{frameId}-{fliph}-{flipv}-{rotate}";
            var anim = new EditorAnimation();
            if (Animations.ContainsKey(key))
            {
                if (Animations[key].Ready)
                {
                    // Use the already loaded Amination
                    return Animations[key];
                }
                else
                {
                    return null;
                }
            }

            Animations.Add(key, anim);

            if (DataDirectoryList == null)
                DataDirectoryList = Directory.GetFiles(Path.Combine(Editor.DataDirectory, "Sprites"), $"*.bin", SearchOption.AllDirectories);


            // Checks Global frist
            string path = Editor.Instance.SelectedZone + "\\" + name + ".bin";
            string path2 = Path.Combine(Editor.DataDirectory, "sprites") + '\\' + path;
            if (!File.Exists(path2))
            {
                // Checks without last character
                path = path = Editor.Instance.SelectedZone.Substring(0, Editor.Instance.SelectedZone.Length - 1) + "\\" + name + ".bin";
                path2 = Path.Combine(Editor.DataDirectory, "sprites") + '\\' + path;
            }
            if (!File.Exists(path2))
            {
                // Checks Global
                path = "Global\\" + name + ".bin";
                path2 = Path.Combine(Editor.DataDirectory, "sprites") + '\\' + path;
            }
            if (!File.Exists(path2))
            {
                // Checks the Stage folder 
                foreach (string dir in Directory.GetDirectories(Path.Combine(Editor.DataDirectory, "Sprites"), $"*", SearchOption.TopDirectoryOnly))
                {
                    path = Path.GetFileName(dir) + "\\" + name + ".bin";
                    path2 = Path.Combine(Editor.DataDirectory, "sprites") + '\\' + path;
                    if (File.Exists(path2))
                        break;
                }
            }
            if (!File.Exists(path2))
            {
                // Seaches all around the Data directory
                var list = DataDirectoryList;
                if (list.Any(t => Path.GetFileName(t.ToLower()).Contains(name.ToLower())))
                {
                    list = list.Where(t => Path.GetFileName(t.ToLower()).Contains(name.ToLower())).ToArray();
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
            if (AnimId == -1)
            {
                if (rsdkAnim.Animations.Any(t => t.AnimName.Contains("Normal")))
                    AnimId = rsdkAnim.Animations.FindIndex(t => t.AnimName.Contains("Normal"));
                else AnimId = 0;
                // Use Vertical Amination if one exists
                if (rotate && rsdkAnim.Animations.Any(t => t.AnimName.EndsWith(" V")))
                    AnimId = rsdkAnim.Animations.FindIndex(t => t.AnimName.EndsWith(" V"));
            }
            if (AnimId >= rsdkAnim.Animations.Count)
                AnimId = rsdkAnim.Animations.Count - 1;
            for (int i = 0; i < rsdkAnim.Animations[AnimId].Frames.Count; ++i)
            {
                // check we don't stray outside our loaded animations/frames
                // if user enters a value that would take us there, just show
                // a valid frame instead
                var animiation = rsdkAnim.Animations[AnimId];
                var frame = animiation.Frames[i];
                if (frameId >= 0 && frameId < animiation.Frames.Count)
                    frame = animiation.Frames[frameId];
                Bitmap map;
                if (!Sheets.ContainsKey(rsdkAnim.SpriteSheets[frame.SpriteSheet]))
                {
                    string targetFile = Path.Combine(Editor.DataDirectory, "sprites", rsdkAnim.SpriteSheets[frame.SpriteSheet].Replace('/', '\\'));
                    if (!File.Exists(targetFile))
                    {
                        map = null;
                        // add a Null to our lookup, so we can avoid looking again in the future
                        Sheets.Add(rsdkAnim.SpriteSheets[frame.SpriteSheet], map);
                    }
                    else
                    {
                        map = new Bitmap(targetFile);
                        Sheets.Add(rsdkAnim.SpriteSheets[frame.SpriteSheet], map);
                    }
                }
                else
                    map = Sheets[rsdkAnim.SpriteSheets[frame.SpriteSheet]];

                if (frame.Width == 0 || frame.Height == 0)
                    continue;

                // can't load the animation, it probably doesn't exist in the User's Sprites folder
                if (map == null) return null;

                // We are storing the first colour from the palette so we can use it to make sprites transparent
                var colour = map.Palette.Entries[0];
                // Slow
                map = CropImage(map, new Rectangle(frame.X, frame.Y, frame.Width, frame.Height), fliph, flipv);
                RemoveColourImage(map, colour, frame.Width, frame.Height);

                Texture texture = null;
                if (loadImageToDX)
                {
                    texture = TextureCreator.FromBitmap(d._device, map);
                }
                var editorFrame = new EditorAnimation.EditorFrame()
                {
                    Texture = texture,
                    Frame = frame,
                    Entry = rsdkAnim.Animations[AnimId]
                };
                if (!loadImageToDX)
                    editorFrame._Bitmap = map;
                anim.Frames.Add(editorFrame);
                if (frameId != -1)
                    break;
            }
            anim.ImageLoaded = true;
            if (loadImageToDX)
                anim.Ready = true;
            Working = false;
            return anim;

        }

        // allow derived types to override the draw
        public virtual void Draw(DevicePanel d)
        {
            if (!d.IsObjectOnScreen(entity.Position.X.High, entity.Position.Y.High, NAME_BOX_WIDTH, NAME_BOX_HEIGHT)) return;
            System.Drawing.Color color = Selected ? System.Drawing.Color.MediumPurple : System.Drawing.Color.MediumTurquoise;
            System.Drawing.Color color2 = System.Drawing.Color.DarkBlue;
            int Transparency = (Editor.Instance.EditLayer == null) ? 0xff : 0x32;
            LoadNextAnimation();
            int x = entity.Position.X.High;
            int y = entity.Position.Y.High;
            bool fliph = false;
            bool flipv = false;
            bool rotate = false;
            var offset = GetRotationFromAttributes(ref fliph, ref flipv, ref rotate);
            string name = entity.Object.Name.Name;
            var editorAnim = LoadAnimation2(name, d, -1, -1, fliph, flipv, rotate);
            if (name == "Spring"          || name == "Player"         || name == "Platform"    ||
                name == "TimeAttackGate"  || name == "Spikes"         || name == "ItemBox"     ||
                name == "Bridge"          || name == "TeeterTotter"   || name == "HUD"         ||
                name == "Music"           || name == "BoundsMarker"   || name == "TitleCard"   ||
                name == "CorkscrewPath"   || name == "BGSwitch"       || name == "ForceSpin"   ||
                name == "UIControl"       || name == "SignPost"       || name == "UFO_Ring"    ||
                name == "UFO_Sphere"      || name == "UFO_Player"     || name == "UFO_ItemBox" ||
                name == "UFO_Springboard" || name == "Decoration"     || name == "WaterGush"   ||
                name == "BreakBar"        || name == "InvisibleBlock")
            {
                DrawOthers(d);
            }
            else if (editorAnim != null && editorAnim.Frames.Count > 0)
            {
                // Just incase
                if (index >= editorAnim.Frames.Count)
                    index = 0;
                var frame = editorAnim.Frames[index];

                if (entity.attributesMap.ContainsKey("frameID"))
                    frame = GetFrameFromAttribute(editorAnim, entity.attributesMap["frameID"]);
                
                if (frame != null)
                {
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    // Draw the normal filled Rectangle but Its visible if you have the entity selected
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX + ((int)offset.X * frame.Frame.Width), y + frame.Frame.CenterY + ((int)offset.Y * frame.Frame.Height),
                            frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
                else
                { // No frame to render
                    d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color));
                }
                // Draws the Special Objects
                //DrawOthers(d);
            }
            else
            {
                d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color));
            }

            d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Selected ? 0x60 : 0x00, System.Drawing.Color.MediumPurple));
            d.DrawLine(x, y, x + NAME_BOX_WIDTH, y, System.Drawing.Color.FromArgb(Transparency, color2));
            d.DrawLine(x, y, x, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color2));
            d.DrawLine(x, y + NAME_BOX_HEIGHT, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color2));
            d.DrawLine(x + NAME_BOX_WIDTH, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, System.Drawing.Color.FromArgb(Transparency, color2));

            if (Editor.Instance.GetZoom() >= 1) d.DrawTextSmall(String.Format("{0} (ID: {1})", entity.Object.Name, entity.SlotID), x + 2, y + 2, NAME_BOX_WIDTH - 4, System.Drawing.Color.FromArgb(Transparency, System.Drawing.Color.Black), true);
        }

        public EditorAnimation.EditorFrame GetFrameFromAttribute(EditorAnimation anim, AttributeValue attribute, string key = "frameID")
        {
            int frameID = -1;
            switch (attribute.Type)
            {
                case AttributeTypes.UINT8:
                    frameID = entity.attributesMap[key].ValueUInt8;
                    break;
                case AttributeTypes.INT8:
                    frameID = entity.attributesMap[key].ValueInt8;
                    break;
                case AttributeTypes.VAR:
                    frameID = (int)entity.attributesMap[key].ValueVar;
                    break;
            }
            if (frameID >= anim.Frames.Count)
                frameID = (anim.Frames.Count - 1) - (frameID % anim.Frames.Count + 1);
            if (frameID < 0)
                frameID = 0;
            if (frameID >= 0 && frameID < int.MaxValue)
                return anim.Frames[frameID % anim.Frames.Count];
            else
                return null; // Don't Render the Animation
        }

        /// <summary>
        /// Guesses the rotation of an entity
        /// </summary>
        /// <param name="attributes">List of all Attributes</param>
        /// <param name="fliph">Reference to fliph</param>
        /// <param name="flipv">Reference to flipv</param>
        /// <returns>AnimationID Offset</returns>
        public SharpDX.Vector2 GetRotationFromAttributes(ref bool fliph, ref bool flipv, ref bool rotate)
        {
            AttributeValue attribute = null;
            var attributes = entity.attributesMap;
            int dir = 0;
            var offset = new SharpDX.Vector2();
            if (attributes.ContainsKey("orientation"))
            {
                attribute = attributes["orientation"];
                switch (attribute.Type)
                {
                    case AttributeTypes.UINT8:
                        dir = attribute.ValueUInt8;
                        break;
                    case AttributeTypes.INT8:
                        dir = attribute.ValueInt8;
                        break;
                    case AttributeTypes.VAR:
                        dir = (int) attribute.ValueVar;
                        break;
                }
                if (dir == 0) // Up
                {
                }
                else if (dir == 1) // Down
                {
                    fliph = true;
                    offset.X = 1;
                    flipv = true;
                    offset.Y = 1;
                }
                else if (dir == 2) // Right
                {
                    flipv = true;
                    rotate = true;
                    offset.Y = 1;
                    //animID = 1;
                }
                else if (dir == 3) // Left
                {
                    flipv = true;
                    rotate = true;
                    offset.Y = 1;
                    //animID = 1;
                }
            }
            if (attributes.ContainsKey("direction") && dir == 0)
            {
                attribute = attributes["direction"];
                switch (attribute.Type)
                {
                    case AttributeTypes.UINT8:
                        dir = attribute.ValueUInt8;
                        break;
                    case AttributeTypes.INT8:
                        dir = attribute.ValueInt8;
                        break;
                    case AttributeTypes.VAR:
                        dir = (int)attribute.ValueVar;
                        break;
                }
                if (dir == 0) // Right
                {
                }
                else if (dir == 1) // left
                {
                    fliph = true;
                    offset.X = 0;
                    rotate = true;
                }
                else if (dir == 2) // Up
                {
                    flipv = true;
                }
                else if (dir == 3) // Down
                {
                    flipv = true;
                    offset.Y = 1;
                }
            }
            return offset;
        }

        /// <summary>
        /// Handles animation timing
        /// </summary>
        /// <param name="speed">Speed</param>
        /// <param name="frameCount">The total amount of frames</param>
        public void ProcessAnimation(int speed, int frameCount, int duration)
        {
            // Playback
            if (Editor.Instance.ShowAnimations.Checked)
            {
                if (speed > 0)
                {
                    int speed1 = speed * 64 / (duration == 0 ? 256 : duration);
                    if (speed1 == 0)
                        speed1 = 1;
                    if ((DateTime.Now - lastFrametime).TotalMilliseconds > 1024 / speed1)
                    {
                        index++;
                        lastFrametime = DateTime.Now;
                    }
                }
            }
            else index = 0;
            if (index >= frameCount)
                index = 0;
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
                var editorAnimBox = LoadAnimation2("ItemBox", d, 0, 0, false, false, false);
                var editorAnimEffect = LoadAnimation2("ItemBox", d, 2, (int)value.ValueVar, false, false, false);
                if (editorAnimBox != null && editorAnimEffect != null && editorAnimEffect.Frames.Count != 0)
                {
                    var frameBox = editorAnimBox.Frames[0];
                    var frameEffect = editorAnimEffect.Frames[0];
                    d.DrawBitmap(frameBox.Texture, x + frameBox.Frame.CenterX, y + frameBox.Frame.CenterY,
                        frameBox.Frame.Width, frameBox.Frame.Height, false, Transparency);
                    d.DrawBitmap(frameEffect.Texture, x + frameEffect.Frame.CenterX, y + frameEffect.Frame.CenterY - 3,
                        frameEffect.Frame.Width, frameEffect.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "Bridge")
            {
                var value = entity.attributesMap["length"].ValueUInt8 / 2;
                var editorAnim = LoadAnimation2("Bridge", d, 0, 0, false, false, false);
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
            else if (entity.Object.Name.Name == "TeeterTotter")
            {
                var value = entity.attributesMap["length"].ValueUInt32 / 2;
                var editorAnim = LoadAnimation2("TeeterTotter", d, 0, 0, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[0];
                    for (int i = -(int)value; i < value + 1; ++i)
                    {
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX + (i * (frame.Frame.Width + 2)),
                            y + frame.Frame.CenterY, frame.Frame.Width, frame.Frame.Height, false, Transparency);
                    }
                }
            }
            else if (entity.Object.Name.Name == "Spikes")
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
                var editorAnim = LoadAnimation2("Spikes", d, animID, 0, fliph, flipv, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[0];
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }

            }
            else if (entity.Object.Name.Name == "Spring")
            {
                int animID = (int) entity.attributesMap["type"].ValueVar;
                var flipFlag = entity.attributesMap["flipFlag"].ValueVar;
                bool fliph = false;
                bool flipv = false;
                // Down
                if (flipFlag == 2)
                    flipv = true;
                // Left
                if (flipFlag == 1)
                    fliph = true;

                var editorAnim = LoadAnimation2("Springs", d, animID % 6, -1, fliph, flipv, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0 && animID >= 0)
                {
                    var frame = editorAnim.Frames[index];

                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);

                    d.DrawBitmap(frame.Texture,
                        x + frame.Frame.CenterX - (fliph ? (frame.Frame.Width - editorAnim.Frames[0].Frame.Width) : 0),
                        y + frame.Frame.CenterY + (flipv ? (frame.Frame.Height - editorAnim.Frames[0].Frame.Height) : 0),
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "Player")
            {
                int id = (int)entity.attributesMap["characterID"].ValueVar;
                if (id > 7)
                {
                    entity.attributesMap["characterID"].ValueVar = 7u;
                }
                var editorAnim = LoadAnimation2("PlayerIcons", d, 0, id, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "SignPost")
            {
                var editorAnim = LoadAnimation2("SignPost", d, 0, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(1, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
                editorAnim = LoadAnimation2("SignPost", d, 4, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    for (int i = 0; i < editorAnim.Frames.Count; ++i)
                    {
                        if (i == 1)
                            continue;
                        var frame = editorAnim.Frames[i];
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                            frame.Frame.Width, frame.Frame.Height, false, Transparency);
                    }
                }
            }
            else if (entity.Object.Name.Name == "TimeAttackGate")
            {
                bool finish = entity.attributesMap["finishLine"].ValueBool;
                var editorAnimBase = LoadAnimation2("SpeedGate", d, 0, 0, false, false, false);
                var editorAnimTop = LoadAnimation2("SpeedGate", d, 1, 0, false, false, false);
                var editorAnimFins = LoadAnimation2("SpeedGate", d, finish ? 4 : 3, -1, false, false, false);
                if (editorAnimBase != null && editorAnimTop != null && editorAnimFins != null)
                {
                    var frameBase = editorAnimBase.Frames[0];
                    var frameTop = editorAnimTop.Frames[0];
                    d.DrawBitmap(frameBase.Texture, x + frameBase.Frame.CenterX, y + frameBase.Frame.CenterY,
                        frameBase.Frame.Width, frameBase.Frame.Height, false, Transparency);
                    d.DrawBitmap(frameTop.Texture, x + frameTop.Frame.CenterX, y + frameTop.Frame.CenterY,
                        frameTop.Frame.Width, frameTop.Frame.Height, false, Transparency);
                    for (int i = 0; i < editorAnimFins.Frames.Count; ++i)
                    {
                        var frame = editorAnimFins.Frames[i];
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                            frame.Frame.Width, frame.Frame.Height, false, Transparency);
                    }
                }
            }
            else if (entity.Object.Name.Name == "HUD")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 0, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "Music")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "BoundsMarker")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 2, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "TitleCard")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 3, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "CorkscrewPath")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 4, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "BGSwitch")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 5, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "ForceSpin")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 6, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "UIControl")
            {
                var editorAnim = LoadAnimation2("EditorIcons", d, 0, 7, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "WaterGush")
            {
                var length = (int)(entity.attributesMap["length"].ValueUInt32);
                var editorAnim = LoadAnimation2("WaterGush", d, 0, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    for (int i = -length + 1; i <= 0; ++i)
                    {
                        d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY + i * frame.Frame.Height,
                            frame.Frame.Width, frame.Frame.Height, false, Transparency);
                    }
                }
            }
            else if (entity.Object.Name.Name == "InvisibleBlock")
            {
                var width = (int)(entity.attributesMap["width"].ValueUInt8);
                var height = (int)(entity.attributesMap["height"].ValueUInt8);
                var editorAnim = LoadAnimation2("ItemBox", d, 2, 10, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    bool wEven = width % 2 == 0;
                    bool hEven = height % 2 == 0;
                    for (int xx = 0; xx <= width; ++xx)
                    {
                        for (int yy = 0; yy <= height; ++yy)
                        {
                            d.DrawBitmap(frame.Texture,
                                x + (wEven ? frame.Frame.CenterX : -frame.Frame.Width) + (-width/2 + xx) * frame.Frame.Width,
                                y + (hEven ? frame.Frame.CenterY : -frame.Frame.Height) + (-height/2 + yy) * frame.Frame.Height,
                                frame.Frame.Width, frame.Frame.Height, false, Transparency);
                        }
                    }
                }
            }
            else if (entity.Object.Name.Name == "Decoration")
            {
                var type = entity.attributesMap["type"].ValueUInt8;
                var editorAnim = LoadAnimation2("Decoration", d, type, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    if (index >= editorAnim.Frames.Count)
                        index = 0;
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "BreakBar")
            {
                var length = (short)(entity.attributesMap["length"].ValueUInt16);
                var orientation = entity.attributesMap["orientation"].ValueUInt8;
                if (orientation > 1)
                {
                    orientation = 0;
                }
                var editorAnim = LoadAnimation2("BreakBar", d, orientation, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frameTop = editorAnim.Frames[0];
                    var frameBase = editorAnim.Frames[1];
                    var frameBottom = editorAnim.Frames[2];
                    for (int i = -length/2; i <= length / 2; ++i)
                    {
                        d.DrawBitmap(frameBase.Texture, x + frameBase.Frame.CenterX,
                            y + frameBase.Frame.CenterY + i * frameBase.Frame.Height,
                            frameBase.Frame.Width, frameBase.Frame.Height, false, Transparency);
                    }
                    d.DrawBitmap(frameTop.Texture, x + frameTop.Frame.CenterX,
                        y + frameTop.Frame.CenterY - (length / 2 + 1) * frameBase.Frame.Height,
                        frameTop.Frame.Width, frameTop.Frame.Height, false, Transparency);
                    d.DrawBitmap(frameBottom.Texture, x + frameBottom.Frame.CenterX,
                        y + frameBottom.Frame.CenterY + (length / 2 + 1) * frameBottom.Frame.Height,
                        frameBottom.Frame.Width, frameBottom.Frame.Height, false, Transparency);

                }
            }
            else if (entity.Object.Name.Name == "UFO_Ring")
            {
                var editorAnim = LoadAnimation2("Ring", d, 0, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "UFO_Springboard")
            {
                var editorAnim = LoadAnimation2("Spring", d, 0, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(50, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "UFO_Sphere")
            {
                int id = (int)entity.attributesMap["type"].ValueVar;
                if (id > 4)
                {
                    entity.attributesMap["type"].ValueVar = 4u;
                }
                var editorAnim = LoadAnimation2("Spheres", d, id, -1, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "UFO_Player")
            {
               var editorAnim = LoadAnimation2("PlayerIcons", d, 0, 7, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "UFO_ItemBox")
            {
                int id = (int)entity.attributesMap["type"].ValueVar;
                if (id > 2)
                {
                    entity.attributesMap["type"].ValueVar = 2u;
                }
                var editorAnim = LoadAnimation2("Items", d, 0, id, false, false, false);
                if (editorAnim != null && editorAnim.Frames.Count != 0)
                {
                    var frame = editorAnim.Frames[index];
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }
            else if (entity.Object.Name.Name == "Platform")
            {
                int frameID = 0;
                int targetFrameID = -1;
                var attribute = entity.attributesMap["frameID"];
                switch (attribute.Type)
                {
                    case AttributeTypes.UINT8:
                        targetFrameID = attribute.ValueUInt8;
                        break;
                    case AttributeTypes.INT8:
                        targetFrameID = attribute.ValueInt8;
                        break;
                    case AttributeTypes.VAR:
                        targetFrameID = (int)attribute.ValueVar;
                        break;
                }

                int aminID = 0;
                EditorAnimation editorAnim = null;
                while (true)
                {
                    try
                    {
                        editorAnim = LoadAnimation("Platform", d, aminID, -1, false, false, false);

                        if (editorAnim == null) return; // no animation, bail out

                        frameID += editorAnim.Frames.Count;
                        if (targetFrameID < frameID)
                        {
                            int aminStart = (frameID - editorAnim.Frames.Count);
                            frameID = targetFrameID - aminStart;
                            break;
                        }
                        aminID++;
                    }
                    catch (Exception e)
                    {
                        throw new ApplicationException($"Pop Loading Platforms! {aminID}", e);
                    }
                }
                if (editorAnim.Frames.Count != 0)
                {
                    EditorAnimation.EditorFrame frame = null;
                    if (editorAnim.Frames[0].Entry.FrameSpeed > 0)
                        frame = editorAnim.Frames[index];
                    else
                        frame = editorAnim.Frames[frameID > 0 ? frameID : 0];
                    ProcessAnimation(frame.Entry.FrameSpeed, frame.Entry.Frames.Count, frame.Frame.Duration);
                    d.DrawBitmap(frame.Texture, x + frame.Frame.CenterX, y + frame.Frame.CenterY,
                        frame.Frame.Width, frame.Frame.Height, false, Transparency);
                }
            }

        }

        public static void ReleaseResources()
        {
            DataDirectoryList = null;

            foreach (var pair in Sheets)
                pair.Value?.Dispose();
            Sheets.Clear();

            foreach (var pair in Animations)
                foreach (var pair2 in pair.Value.Frames)
                    pair2.Texture?.Dispose();

            Animations.Clear();

        }

        public class EditorAnimation
        {
            public int loadedFrames = 0;
            public bool Ready = false;
            public bool ImageLoaded = false;
            public List<EditorFrame> Frames = new List<EditorFrame>();
            public class EditorFrame
            {
                public Texture Texture;
                public Animation.Frame Frame;
                public Animation.AnimationEntry Entry;
                public Bitmap _Bitmap;
            }
        }
    }
}
