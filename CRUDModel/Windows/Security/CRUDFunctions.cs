using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.CRUDModel;

namespace Security
{
    [Serializable]
    public class CRUDFunctions : Functions
    {
        protected Modules module;
        protected CRUDAction action;

        public CRUDFunctions(Modules module, CRUDAction action)
        {
            this.module = module;
            this.action = action;
        }

        public Modules Module
        {
            get { return module; }
            set { module = value; }
        }

        public CRUDAction Action
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
            if (obj is CRUDFunctions)
            {
                if ((this.Module.Equals((obj as CRUDFunctions).Module)) && (this.Action.Equals((obj as CRUDFunctions).Action )))
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
