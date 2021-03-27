using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class RubrosBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(Rubros); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayProductos(persistentObject as Rubros))
            {
                result = false;
                messages.Add("No se puede eliminar el rubro porque existen productos asociados");
            }
            return result;
        }

        private bool HayProductos(Rubros rubro)
        {
            return DBConnection.Session.CreateCriteria(typeof(Productos)).Add(Expression.Eq("Rubro", rubro)).
                SetMaxResults(1).List().Count > 0;
        }
    }
}
