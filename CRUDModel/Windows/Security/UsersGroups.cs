using System;
using System.Collections;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Security
{
    [ColumnAttributes("Name", true, 1, 10)]
    public class UsersGroups : Persistent
    {
        protected IList functionsList;
        protected IList permissionsList;
        protected String name;

        public UsersGroups()
            : base()
        {
            functionsList = new ArrayList();
            permissionsList = new ArrayList(); 
        }

        public override string ToString()
        {
            return Name;
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList FunctionsList
        {
            get { return functionsList; }
            set { functionsList = value; }
        }

        public IList PermissionsList
        {
            get {
                ArrayList deletedList = new ArrayList(); 
                foreach (Functions func in functionsList)
                {
                    if (!permissionsList.Contains (new Permissions(this, func)))
                        permissionsList.Add(new Permissions(this, func));
                }
                foreach (Permissions perm in permissionsList)
                {
                    if (!functionsList.Contains(perm.Function))
                        deletedList.Add(perm);
                }
                foreach (Permissions perm in deletedList)
                    permissionsList.Remove(perm);
 

                return permissionsList;
                
            }
            set {
                permissionsList = value;
                functionsList.Clear(); 
                foreach (Permissions perm in value)
                {
                    functionsList.Add(perm.Function);
                }
            }
            
        }
    }
}
