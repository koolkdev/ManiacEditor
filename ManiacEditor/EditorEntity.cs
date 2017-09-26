using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ManiacEditor
{
    class EditorEntity : IDrawable
    {
        const int NAME_BOX_WIDTH = 20;
        const int NAME_BOX_HEIGHT = 20;

        public bool Selected;

        private RSDKv5.SceneEntity entity;

        public RSDKv5.SceneEntity Entity { get { return entity; } }

        public EditorEntity(RSDKv5.SceneEntity entity)
        {
            this.entity = entity;
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

        /*public void Draw(DevicePanel d)
        {
            if (!d.IsObjectOnScreen(entity.Position.X.High, entity.Position.Y.High, NAME_BOX_WIDTH, NAME_BOX_HEIGHT)) return;
            Color color = Selected ? Color.MediumPurple : Color.MediumTurquoise;
            Color color2 = Color.DarkBlue;
            int Transparency = (Editor.Instance.EditLayer == null) ? 0xff : 0x32;

            int x = entity.Position.X.High;
            int y = entity.Position.Y.High;

            d.DrawRectangle(x, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, Color.FromArgb(Transparency, color));
            d.DrawLine(x, y, x + NAME_BOX_WIDTH, y, Color.FromArgb(Transparency, color2));
            d.DrawLine(x, y, x, y + NAME_BOX_HEIGHT, Color.FromArgb(Transparency, color2));
            d.DrawLine(x, y + NAME_BOX_HEIGHT, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, Color.FromArgb(Transparency, color2));
            d.DrawLine(x + NAME_BOX_WIDTH, y, x + NAME_BOX_WIDTH, y + NAME_BOX_HEIGHT, Color.FromArgb(Transparency, color2));

            if (Editor.Instance.GetZoom() >= 1) d.DrawTextSmall(String.Format("{0} (ID: {1})", entity.Object.Name, entity.SlotID), x + 2, y + 2, NAME_BOX_WIDTH - 4, Color.FromArgb(Transparency, Color.Black), true);
        }*/
    }
}
