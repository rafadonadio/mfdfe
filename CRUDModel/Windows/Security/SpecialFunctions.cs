using System;
using System.Collections.Generic;
using System.Text;

namespace Security
{
    [Serializable]
    public class SpecialFunctions : Functions 
    {
        protected Modules module;
        protected Actions action;

        public Modules Module
        {
            get { return module; }
            set { module = value; }
        }

        public Actions Action
        {
            get { return action; }
            set { action = value; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is SpecialFunctions)
            {
                if ((this.Module.Equals ((obj as SpecialFunctions).Module)) && (this.Action == (obj as SpecialFunctions).Action))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override string ToString()
        {
            return module.ToString() + " - " + action.ToString();
        }
    }
}
