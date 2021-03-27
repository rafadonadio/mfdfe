using System;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Entities;
using FrameWork.Tools.Validation;
using Security;
using NHibernate.Expression;

namespace BusinessLogic
{
    [Serializable]
    public class ModuloClientes : Modules
    {
        public ModuloClientes()
        { }
    }

    public class ClientesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            Clientes cliente = persistentObject as Clientes ;
            RequiredFieldValidator requiredValidator = new RequiredFieldValidator(messages);
            result &= requiredValidator.Validate(cliente.Nombre, "Debe ingresar un Nombre");
            result &= requiredValidator.Validate(cliente.CUIT , "Debe ingresar un CUIT");
            result &= requiredValidator.Validate(cliente.TipoPago, "Debe ingresar un Tipo de Pago");
            result &= requiredValidator.Validate(cliente.TipoContribuyente , "Debe ingresar un Tipo de Contribuyente");
            result &= requiredValidator.Validate(cliente.Email, "Debe ingresar el Email");
            return result;
        }
        
        public override Type PersistentType
        {
            get { return typeof(Clientes); }
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayComprobantes(persistentObject as Clientes ))
            {
                result = false;
                messages.Add("No se puede eliminar el cliente porque existen comprobantes asociados");
            }
            return result;
        }

        private bool HayComprobantes(Clientes cliente)
        {
            return DBConnection.Session.CreateCriteria(typeof(Comprobantes)).Add(Expression.Eq("Cliente", cliente)).
                SetMaxResults(1).List().Count > 0;
        }
        public override object GetModule()
        {
            return new ModuloClientes(); 
        }
    }
}
