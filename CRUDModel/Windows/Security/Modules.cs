using System;
using System.Collections.Generic;
using System.Text;

namespace Security
{   
    [Serializable] 
    public class Modules
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
        protected Modules() { }
        private static Modules  instance = null;

        public static Modules Instance
        {
            get
            {
                if (instance == null) instance = new Modules();
                return instance;
            }
        }

    }
}
