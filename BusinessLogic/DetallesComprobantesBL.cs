using System;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Entities;
using FrameWork.Tools.Validation;

namespace BusinessLogic
{
    public class DetallesComprobantesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            DetallesComprobantes detalle = persistentObject as DetallesComprobantes;
            result &= new RequiredFieldValidator(messages).Validate(detalle.Producto , "Debe ingresar un Producto");
            return result;
        }
        public override bool BusinessValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.BusinessValidator(persistentObject, messages);
            return result;
        }
        public override Type PersistentType
        {
            get { return typeof(DetallesComprobantes); }
        }
    }
}
