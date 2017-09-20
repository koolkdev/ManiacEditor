using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManiacEditor.Actions
{
    public interface IAction
    {
        void Undo();
        IAction Redo();
    }
}
