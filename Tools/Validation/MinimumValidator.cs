using System;
using FrameWork.DataBusinessModel;

namespace FrameWork.Tools.Validation {
    public class MinimumValidator : AbstractRangeValidator {
        public MinimumValidator() : base() {
        }

        public MinimumValidator(bool inclusive) : base(inclusive) {
        }

        public MinimumValidator(ErrorMessages messages) : base(messages) {
        }

        public MinimumValidator(ErrorMessages messages, bool inclusive) : base(messages, inclusive) {
        }

        public bool Validate(IComparable value, IComparable minValue) {
            bool result;
            if (inclusive) result = (value.CompareTo(minValue) >= 0);
            else result = (value.CompareTo(minValue) > 0);
            return result;
        }

        public bool Validate(IComparable value, IComparable minValue, string errorMessage) {
            bool result = Validate(value, minValue);
            if (!result) AddMessage(errorMessage);
            return result;
        }
    }
}