using FrameWork.DataBusinessModel;

namespace FrameWork.Tools.Validation {
    public abstract class AbstractRangeValidator : Validator {
        protected bool inclusive;

        public AbstractRangeValidator(bool inclusive) : base() {
            this.inclusive = inclusive;
        }

        public AbstractRangeValidator() : this(true) {
        }

        public AbstractRangeValidator(ErrorMessages messages) : this(messages, true) {
        }

        public AbstractRangeValidator(ErrorMessages messages, bool inclusive) : base(messages) {
            this.inclusive = inclusive;
        }
    }
}