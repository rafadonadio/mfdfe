using System;
using Entities;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.Tools.Validation;

namespace BusinessLogic {
    public class DetallesComprobantesComprasBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic {
        public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages) {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            DetallesComprobantesCompras detalle = persistentObject as DetallesComprobantesCompras;
            result &= new RequiredFieldValidator(messages).Validate(detalle.TipoIva, "Debe ingresar un Tipo de Iva");
            return result;
        }
        
        public override Type PersistentType {
            get { return typeof(DetallesComprobantesCompras); }
        }
    }
}
