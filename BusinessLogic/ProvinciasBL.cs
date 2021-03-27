using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class ProvinciasBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic 
    {
        public override Type PersistentType
        {
            get { return typeof(Provincias); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayClientes(persistentObject as Provincias))
            {
                result = false;
                messages.Add("No se puede eliminar la provincia porque existen clientes asociados");
            }
            return result;
        }

        private bool HayClientes(Provincias provincia)
        {
            return DBConnection.Session.CreateCriteria(typeof(Clientes)).Add(Expression.Eq("Provincia", provincia)).
                SetMaxResults(1).List().Count > 0;
        }
    }
}
