using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.Tools.Validation;

namespace BusinessLogic {
    public class DestinacionesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic {

        public override Type PersistentType {
            get { return typeof(Destinaciones); }
        }

        public override object GetModule() {
            return new ModuloParametros();
        }

        public override bool RequiredFieldsValidator(FrameWork.DataBusinessModel.DataModel.Persistent persistentObject, FrameWork.DataBusinessModel.ErrorMessages messages) {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            if (persistentObject is Destinaciones) {
                Destinaciones destinacion = persistentObject as Destinaciones;
                RequiredFieldValidator validator=new RequiredFieldValidator(messages);
                if (!validator.Validate(destinacion.Codigo, "Debe ingresar un código")) result = false;
                if (!validator.Validate(destinacion.Descripcion, "Debe ingresar una descripción")) result = false;
            }
            return result;
        }
    }
}
