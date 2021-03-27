using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel;

namespace FrameWork.Tools.Validation
{
    public abstract class Validator {
        private ErrorMessages messages;
        
        public Validator() {
            messages = null;
        }
        
        public Validator(ErrorMessages messages) {
            this.messages = messages;
        }
        
        protected void AddMessage(string errorMessage) {
            if(messages!=null) messages.Add(errorMessage);
        }
    }
}
