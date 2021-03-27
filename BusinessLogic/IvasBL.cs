using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class IvasBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(Ivas ); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayProductos(persistentObject as Ivas))
            {
                result = false;
                messages.Add("No se puede eliminar el tipo de iva porque existen productos asociados");
            }
            return result;
        }

        private bool HayProductos(Ivas iva)
        {
            return DBConnection.Session.CreateCriteria(typeof(Productos)).Add(Expression.Eq("TipoIva", iva)).
                SetMaxResults(1).List().Count > 0;
        }
    }
}