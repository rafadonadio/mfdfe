using System;
using System.Reflection;

namespace FrameWork.DataBusinessModel.DataModel {
    [ColumnAttributes("Id", false, 0, 0)]
    [Serializable]
	public abstract class Persistent:IComparable {
		protected Int32 id;
        protected int notSavedID;
        private static int lastNotSavedID=0;

        /*public virtual bool IsChanged
        {
            get { return true; }
        }*/

		public Persistent() {
			Id = 0;
            notSavedID = ++lastNotSavedID;
		}

		public virtual Persistent Parent {
			set {
			}
		}

		public virtual Int32 Id {
			get { return id; }
			set { 
			    id = value;
                notSavedID = 0;
			}
		}

        public override bool Equals(object obj) {
            if(obj!=null) 
                return ((GetType() == obj.GetType()) && (Id == (obj as Persistent).Id) && (notSavedID == (obj as Persistent).notSavedID));
            else return false;
        }

		public Persistent Clone() {
			Persistent result=(Persistent) Activator.CreateInstance(this.GetType());
			foreach(FieldInfo field in result.GetType().GetFields(BindingFlags.Instance|BindingFlags.Public | BindingFlags.NonPublic)) {
				field.SetValue(result, field.GetValue(this));
			}
			return result;
		}

	    public virtual int CompareTo(object obj) {
            int result = -1;
	        if((obj!=null)&&(GetType()==obj.GetType())) {
                result = Id.CompareTo((obj as Persistent).Id);
                if (result == 0) result = notSavedID.CompareTo((obj as Persistent).notSavedID);
	        }
            return result;
	    }
	}
}