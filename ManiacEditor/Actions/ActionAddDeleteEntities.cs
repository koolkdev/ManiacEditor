using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManiacEditor.Actions
{
    class ActionAddDeleteEntities : IAction
    {
        Action<List<EditorEntity>> addEntity;
        Action<List<EditorEntity>> deleteEntity;
        List<EditorEntity> entities;
        bool add;

        public ActionAddDeleteEntities(List<EditorEntity> entities, bool add, Action<List<EditorEntity>> addEntity, Action<List<EditorEntity>> deleteEntity)
        {
            this.entities = entities;
            this.add = add;
            this.addEntity = addEntity;
            this.deleteEntity = deleteEntity;
        }

        public void Undo()
        {
            if (add)
                deleteEntity(entities);
            else
                addEntity(entities);
        }

        public IAction Redo()
        {
            return new ActionAddDeleteEntities(entities, !add, addEntity, deleteEntity);
        }

    }
}