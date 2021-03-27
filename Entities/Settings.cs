using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Entities
{
    [Serializable]
    public abstract class Settings
    {
        public string Name
        {
            get { return this.GetType().Name; }
            set { }
        }

        public byte[] Value
        {
            get { return Serialize(GetInstance()); }
            set { SetInstance(Deserialize(value)); }
        }

        public byte[] Serialize(Settings set)
        {
            Stream str = new MemoryStream();
            BinaryFormatter formater = new BinaryFormatter();
            try
            {
                formater.Serialize(str, set);
            }
            catch (Exception)
            {
                return null;
            }

            byte[] ret = new byte[str.Length];
            str.Position = 0;
            str.Read(ret, 0, Convert.ToInt32(str.Length));
            
            return ret;
        }
        protected Settings Deserialize(byte[] serializedObject)
        {
            Stream str = new MemoryStream(serializedObject);
            BinaryFormatter formater = new BinaryFormatter();
            Settings set = null;
            try
            {
                set = (formater.Deserialize(str) as Settings);
            }
            catch (Exception)
            {
                return null;
            }
            return set;
        }
        protected abstract void SetInstance(Settings s);
        protected abstract Settings GetInstance();
    }
}
