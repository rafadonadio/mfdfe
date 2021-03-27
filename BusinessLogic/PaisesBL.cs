using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class PaisesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic 
    {
        public override Type PersistentType
        {
            get { return typeof(Paises); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayClientes(persistentObject as Paises))
            {
                result = false;
                messages.Add("No se puede eliminar el país porque existen clientes asociados");
            }
            return result;
        }

        private bool HayClientes(Paises pais)
        {
            return DBConnection.Session.CreateCriteria(typeof(Clientes)).Add(Expression.Eq("Pais", pais)).
                SetMaxResults(1).List().Count > 0;
        }
    }
}
