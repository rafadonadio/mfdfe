using System;
using System.Text;
using System.Collections;
using FrameWork.DataBusinessModel.DataModel;
using Security;

namespace Entities
{
    [ColumnAttributes("Nombre", true, 1, 20,"Usuario")]
    [Serializable]
    public class Usuarios : Persistent
    {
        private string nombre;
        private string password;
        protected IDictionary access;
        protected UsersGroups usergroup;

        public Usuarios()
        {
            access = new Hashtable();
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
        public IDictionary Access
        {
            get { return access; }
            set { access = value; }
        }

        public UsersGroups UserGroup
        {
            get { return usergroup; }
            set { usergroup = value; }
        }
    }
    public enum AccessTypes
    {
        Read = 1,
        Insert = 2,
        Update = 4,
        Delete = 8
    }
}
