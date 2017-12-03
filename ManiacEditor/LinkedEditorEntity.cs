using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiacEditor
{
    class LinkedEditorEntity : EditorEntity
    {
        public LinkedEditorEntity(RSDKv5.SceneEntity entity) : base(entity)
        {
        }

        public override void Draw(DevicePanel d)
        {
            base.Draw(d);

            if (Entity.GetAttribute("go").ValueVar == 0)
            {
                // this is the start of a WarpDoor, find its partner(s)
                var warpDoors = Entity.Object.Entities.Where(e => e.GetAttribute("tag").ValueUInt8 ==
                                                                  Entity.GetAttribute("destinationTag").ValueVar);

                if (warpDoors != null
                    && warpDoors.Any())
                {
                    // some destinations seem to be duplicated, so we must loop
                    foreach (var wd in warpDoors)
                    {
                        DrawLinkArrow(d, Entity, wd);
                    }
                }
            }
            else
            {
                // this is the end of a WarpDoor, find its partner(s)
                var warpDoors = Entity.Object.Entities.Where(e => e.GetAttribute("destinationTag").ValueVar ==
                                                                  Entity.GetAttribute("tag").ValueUInt8);

                if (warpDoors != null
                    && warpDoors.Any())
                {
                    // some destinations are served by multiple entry points
                    // so we must loop
                    foreach (var wd in warpDoors)
                    {
                        DrawLinkArrow(d, wd, Entity, true);
                    }
                }

            }
        }

        private void DrawLinkArrow(DevicePanel d, RSDKv5.SceneEntity start, RSDKv5.SceneEntity end, bool checkPartnerArrow = false)
        {
            int startX = start.Position.X.High;
            int startY = start.Position.Y.High;
            int endX = end.Position.X.High;
            int endY = end.Position.Y.High;

            if (checkPartnerArrow && d.IsObjectOnScreen(startX, startY, NAME_BOX_WIDTH, NAME_BOX_HEIGHT)) return;

            int dx = endX - startX;
            int dy = endY - startY;

            int offsetX = 0;
            int offsetY = 0;
            int offsetDestinationX = 0;
            int offsetDestinationY = 0;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // horizontal difference greater than vertical difference
                offsetY = NAME_BOX_HALF_HEIGHT;
                offsetDestinationY = NAME_BOX_HALF_HEIGHT;

                if (dx > 0)
                {
                    offsetX = NAME_BOX_WIDTH;
                }
                else
                {
                    offsetDestinationX = NAME_BOX_WIDTH;
                }
            }
            else
            {
                // vertical difference greater than horizontal difference
                offsetX = NAME_BOX_HALF_WIDTH;
                offsetDestinationX = NAME_BOX_HALF_WIDTH;

                if (dy > 0)
                {
                    offsetY = NAME_BOX_HEIGHT;
                }
                else
                {
                    offsetDestinationY = NAME_BOX_HEIGHT;
                }
            }

            d.DrawArrow(startX + offsetX,
                        startY + offsetY,
                        end.Position.X.High + offsetDestinationX,
                        end.Position.Y.High + offsetDestinationY,
                        Color.GreenYellow);
        }
    }
}
