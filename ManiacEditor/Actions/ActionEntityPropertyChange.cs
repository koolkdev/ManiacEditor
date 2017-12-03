using RSDKv5;
using System;

namespace ManiacEditor.Actions
{
    class ActionEntityPropertyChange : IAction
    {
        SceneEntity entity;
        string tag;
        object oldValue;
        object newValue;
        Action<SceneEntity, string, object, object> setValue;

        public string Description => $"changing {tag} on {entity.Object.Name} from {oldValue} to {newValue}";

        public ActionEntityPropertyChange(SceneEntity entity, string tag, object oldValue, object newValue, Action<SceneEntity, string, object, object> setValue)
        {
            this.entity = entity;
            this.tag = tag;
            this.oldValue = oldValue;
            this.newValue = newValue;
            this.setValue = setValue;
        }

        public void Undo()
        {
            setValue(entity, tag, oldValue, newValue);
        }

        public IAction Redo()
        {
            return new ActionEntityPropertyChange(entity, tag, newValue, oldValue, setValue);
        }
    }
}
