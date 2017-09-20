using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ManiacEditor.Actions
{
    class ActionChangeTile : IAction
    {
        Action<Point, ushort> setLayer;
        Point position;
        private ushort oldValue, newValue;

        public ActionChangeTile(Action<Point, ushort> setLayer, Point position, ushort oldValue, ushort newValue)
        {
            this.setLayer = setLayer;
            this.position = position;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public void Undo()
        {
            setLayer(position, oldValue);
        }

        public IAction Redo()
        {
            return new ActionChangeTile(setLayer, position, newValue, oldValue);
        }
    }
}
