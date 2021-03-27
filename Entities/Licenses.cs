using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Entities
{
    [Serializable]
    public class Licenses
    {
        protected string pcname;
        private DateTime firstAccess;
        private DateTime lastAccess;
        private int countAccess;
        private string serial;
        protected bool activated;

        private Licenses() { }
        private static Licenses instance = null;

        public static Licenses Instance
        {
            get
            {
                if (instance == null) instance = new Licenses();
                return instance;
            }
        }

        public DateTime FirstAccess
        {
            get { return firstAccess; }
            set { firstAccess = value; }
        }
        public DateTime LastAccess
        {
            get { return lastAccess; }
            set { lastAccess = value; }
        }
        public int CountAccess
        {
            get { return countAccess; }
            set { countAccess = value; }
        }
        public bool Activated
        {
            get { return activated; }
            set { activated  = value; }
        }
        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }
        public string PcName
        {
            get { return pcname; }
            set { pcname = value; }
        }


        public byte[] Value
        {
            get { return Serialize(this); }
            set { 
                Licenses lic =Deserialize(value);
                if (lic !=null)
                    instance = lic; 
            }
        }

        public byte[] Serialize(Licenses set)
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
        protected Licenses Deserialize(byte[] serializedObject)
        {
            Stream str = new MemoryStream(serializedObject);
            BinaryFormatter formater = new BinaryFormatter();
            Licenses set = null;
            try
            {
                set = (formater.Deserialize(str) as Licenses );
            }
            catch (Exception)
            {
                return null;
            }
            return set;
        }

    }
}
