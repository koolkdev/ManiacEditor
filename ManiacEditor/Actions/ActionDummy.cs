using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiacEditor.Actions
{
    class ActionDummy : IAction
    {
        public ActionDummy() { }
        public void Undo() { }
        public IAction Redo() { return this; }
    }
}
