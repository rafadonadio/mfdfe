using System;
using FrameWork.DataBusinessModel;

namespace FrameWork.Tools.Validation {
    public class MaximumValidator : AbstractRangeValidator {
        public MaximumValidator() : base() {
        }

        public MaximumValidator(bool inclusive) : base(inclusive) {
        }

        public MaximumValidator(ErrorMessages messages) : base(messages) {
        }

        public MaximumValidator(ErrorMessages messages, bool inclusive) : base(messages, inclusive) {
        }

        public bool Validate(IComparable value, IComparable maxValue) {
            bool result;
            if (inclusive) result = (value.CompareTo(maxValue) <= 0);
            else result = (value.CompareTo(maxValue) < 0);
            return result;
        }

        public bool Validate(IComparable value, IComparable maxValue, string errorMessage) {
            bool result = Validate(value, maxValue);
            if (!result) AddMessage(errorMessage);
            return result;
        }
    }
}