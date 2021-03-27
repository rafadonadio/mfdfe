using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class TiposComprobantesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(TiposComprobantes); }
        }

        public System.Collections.IList GetDataSource(TiposComprobantesList tipo)
        {
            NHibernate.ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
            crit.Add(new NHibernate.Expression.EqExpression ("Tipo",tipo));
            return crit.List();
        }
        
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayComprobantes(persistentObject as TiposComprobantes ))
            {
                result = false;
                messages.Add("No se puede eliminar el tipo de comprobante porque existen comprobantes asociados");
            }
            return result;
        }

        private bool HayComprobantes(TiposComprobantes tipos)
        {
            return DBConnection.Session.CreateCriteria(typeof(Comprobantes)).Add(Expression.Eq("Tipo", tipos)).
                SetMaxResults(1).List().Count > 0;
        }
        
        public override object GetModule()
        {
            return new ModuloParametros();
        }
    }

}
