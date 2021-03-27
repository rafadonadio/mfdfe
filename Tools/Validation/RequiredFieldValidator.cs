using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.Tools.Validation {
    public class RequiredFieldValidator : Validator {
        public RequiredFieldValidator() : base() {
        }

        public RequiredFieldValidator(ErrorMessages messages) : base(messages) {
        }

        public bool Validate(string fieldValue) {
            return ((fieldValue != null) && (fieldValue.Trim().Length > 0));
        }

        public bool Validate(string fieldValue, string errorMessage) {
            bool result = Validate(fieldValue);
            if (!result) AddMessage(errorMessage);
            return result;
        }

        public bool Validate(Persistent fieldValue) {
            return (fieldValue != null);
        }

        public bool Validate(Persistent fieldValue, string errorMessage) {
            bool result = Validate(fieldValue);
            if (!result) AddMessage(errorMessage);
            return result;
        }
    }
}