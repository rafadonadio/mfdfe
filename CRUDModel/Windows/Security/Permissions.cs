using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Security
{
    public class Permissions : Persistent
    {
        private UsersGroups userGroup;
        protected Functions function;

        protected UsersGroups UserGroup
        {
            get { return userGroup; }
            set { userGroup = value; }
        }

        public byte[] Value
        {
            get { return Serialize(function); }
            set { function = Deserialize(value); }
        }

        public Functions Function
        {
            get { return function; }
            set { function = value; }
        }


        public override bool Equals(object obj)
        {
            if (obj is Permissions)
            {
                if ((function.Equals((obj as Permissions).function)) && (userGroup.Id  == (obj as Permissions).UserGroup.Id))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public Permissions()
        { }

        public Permissions(UsersGroups usergroup, Functions function)
        {
            this.userGroup = usergroup;
            this.function = function; 
        }        

        public byte[] Serialize(Functions function)
        {
            Stream str = new MemoryStream();
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                formater.Serialize(str, function);
            }
            catch
            {
                return null;
            }

            byte[] ret = new byte[str.Length];
            str.Position = 0;
            str.Read(ret, 0, Convert.ToInt32(str.Length));

            return ret;
        }
        protected Functions Deserialize(byte[] serializedObject)
        {
            Stream str = new MemoryStream(serializedObject);
            BinaryFormatter formater = new BinaryFormatter();
            Functions set = null;
            try
            {
                set = (formater.Deserialize(str) as Functions);
            }
            catch 
            {
                return null;
            }
            return set;
        }
    }
}
