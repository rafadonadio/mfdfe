using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Security;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    [Serializable]
    public class ModuloParametros : Modules
    {
        public ModuloParametros()
        { }
    }

    public class ClasesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(Clases); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayClientes(persistentObject as Clases))
            {
                result = false;
                messages.Add("No se puede eliminar el país porque existen clientes asociados");
            }
            if (HayProductos(persistentObject as Clases))
            {
                result = false;
                messages.Add("No se puede eliminar el país porque existen productos asociados");
            }
            return result;
        }

        private bool HayClientes(Clases clase)
        {
            return DBConnection.Session.CreateCriteria(typeof(Clientes)).Add(Expression.Eq("Clase", clase)).
                SetMaxResults(1).List().Count > 0;
        }
        private bool HayProductos(Clases clase)
        {
            return DBConnection.Session.CreateCriteria(typeof(Productos)).Add(Expression.Eq("Clase", clase)).
                SetMaxResults(1).List().Count > 0;
        }
    }
}
