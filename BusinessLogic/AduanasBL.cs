using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.Tools.Validation;

namespace BusinessLogic {
    public class AduanasBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic {
        
        public override Type PersistentType {
            get { return typeof (Aduanas); }
        }

        public override object GetModule() {
            return new ModuloParametros();
        }

        public override bool RequiredFieldsValidator(FrameWork.DataBusinessModel.DataModel.Persistent persistentObject, FrameWork.DataBusinessModel.ErrorMessages messages) {
            bool result= base.RequiredFieldsValidator(persistentObject, messages);
            if(persistentObject is Aduanas) {
                Aduanas aduana = persistentObject as Aduanas;
                if(!new MinimumValidator(messages, true).Validate(aduana.Codigo, 0, "El código es inválido")) result=false;
                if(!new RequiredFieldValidator(messages).Validate(aduana.Descripcion, "Debe ingresar una descripción")) result=false;
            }
            return result;
        }
    }
}
