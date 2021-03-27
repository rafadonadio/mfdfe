using System;
using System.Collections.Generic;
using System.Text;

namespace Security
{
    [Serializable]
    public abstract class Actions
    {
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
