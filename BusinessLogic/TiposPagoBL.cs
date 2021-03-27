using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class TiposPagoBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(TiposPago); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayClientes(persistentObject as TiposPago))
            {
                result = false;
                messages.Add("No se puede eliminar el tipo de pago porque existen clientes asociados");
            }

            if (HayComprobantes(persistentObject as TiposPago))
            {
                result = false;
                messages.Add("No se puede eliminar el tipo de pago porque existen comprobantes asociados");
            }

            return result;
        }

        private bool HayComprobantes(TiposPago tipoPago)
        {
            return DBConnection.Session.CreateCriteria(typeof(Comprobantes)).Add(Expression.Eq("TipoPago", tipoPago)).
                SetMaxResults(1).List().Count > 0;
        }

        private bool HayClientes(TiposPago tipoPago)
        {
            return DBConnection.Session.CreateCriteria(typeof(Clientes)).Add(Expression.Eq("TipoPago", tipoPago)).
                SetMaxResults(1).List().Count > 0;
        }
    }
}
