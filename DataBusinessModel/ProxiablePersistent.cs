namespace FrameWork.DataBusinessModel.DataModel
{
    /// <summary>
    /// To be used in classes that should be proxied by NHibernate
    /// </summary>
    public class ProxiablePersistent : Persistent {
        public override bool Equals(object obj) {
            bool result = false;
            if ((obj != null)&&(GetType().IsAssignableFrom(obj.GetType()) || obj.GetType().IsAssignableFrom(GetType())))
                result= ((Id == (obj as ProxiablePersistent).Id) || ((Id==0) && (notSavedID == (obj as ProxiablePersistent).notSavedID)));

            return result;
        }

        public override int CompareTo(object obj) {
            int result = -1;
            if ((obj != null) && (GetType().IsAssignableFrom(obj.GetType()) || obj.GetType().IsAssignableFrom(GetType()))) {
                result = Id.CompareTo((obj as ProxiablePersistent).Id);
                if (result == 0) result = notSavedID.CompareTo((obj as ProxiablePersistent).notSavedID);
            }
            return result;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}