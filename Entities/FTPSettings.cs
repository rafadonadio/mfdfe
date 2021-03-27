using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{

    [Serializable]
    public class FTPSettings : Settings
    {
        protected String host;
        protected Int32 port;
        protected String user;
        protected String pass; 
        
        
        private FTPSettings() { }
        private static FTPSettings instance = null;

        public static FTPSettings Instance
        {
            get
            {
                if (instance == null) instance = new FTPSettings();
                return instance;
            }
        }
        protected override void SetInstance(Settings s)
        {
            if (s is FTPSettings) instance = s as FTPSettings;
        }
        protected override Settings GetInstance()
        {
            return instance;
        }


        public String Host
        {
            get { return host; }
            set { host = value; }
        }
        public Int32 Port
        {
            get { return port; }
            set { port = value; }
        }
        public String User
        {
            get { return user; }
            set { user = value; }
        }
        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }
    
    }    
}
