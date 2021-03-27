using System;
using FrameWork.DataBusinessModel;

namespace FrameWork.Tools.Validation {
    public class RangeValidator : AbstractRangeValidator {
        private MinimumValidator minimumValidator;
        private MaximumValidator maximumValidator;
        
        public RangeValidator() : base() {
            InitializeValidators();
        }

        public RangeValidator(bool inclusive) : base(inclusive) {
            InitializeValidators();
        }

        public RangeValidator(ErrorMessages messages) : base(messages) {
            InitializeValidators();
        }

        public RangeValidator(ErrorMessages messages, bool inclusive) : base(messages,inclusive) {
            InitializeValidators();
        }
        
        private void InitializeValidators() {
            minimumValidator = new MinimumValidator(inclusive);
            maximumValidator = new MaximumValidator(inclusive);
        }

        public bool Validate(IComparable value, IComparable minValue, IComparable maxValue) {
            return (minimumValidator.Validate(value, minValue) && maximumValidator.Validate(value, maxValue));
        }

        public bool Validate(IComparable value, IComparable minValue, IComparable maxValue, string errorMessage) {
            bool result = Validate(value, minValue, maxValue);
            if (!result) AddMessage(errorMessage);
            return result;
        }
    }
}