using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace FrameWork.CRUDModel.Windows.UI {
    public class FormLayoutManager : IFormLayoutManager {
        [Serializable]
        public class SerializableLayout {
            private Point location;
            private Size size;
            
            public SerializableLayout() {
                Location = Point.Empty;
                Size = System.Drawing.Size.Empty;
            }
            public SerializableLayout(Form form) {
                Location = new Point(form.Location.X, form.Location.Y);
                Size = new Size(form.Size.Width, form.Size.Height);
            }

            public Point Location {
                get { return location; }
                set { location = value; }
            }

            public Size Size {
                get { return size; }
                set { size = value; }
            }
            
            public void Apply(Form form) {
                form.Location = Location;
                form.Size = Size;
            }
        }
        
		private string path;
		private MD5 md5;
        private XmlSerializer serializer;

		private FormLayoutManager() {
			md5 = MD5.Create();
		    serializer = new XmlSerializer(typeof(SerializableLayout));
			Path = ".\\";
		}
        
        private static FormLayoutManager instance = null;
        public static FormLayoutManager Instance {
            get {
                if(instance==null) instance=new FormLayoutManager();
                return instance;
            }
        }

        public string Path {
            get { return path; }
            set { path = value; }
        }
        
        protected string FormKey(Form form) {
            byte[] inputBytes = Encoding.ASCII.GetBytes(String.Format("{0}.{1}", form.Name,form.Text));
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash) sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        
        protected string LayoutFileName(Form form) {
            return String.Format("{0}{1}.FormLayout.xml", Path, FormKey(form));
        }
        
        public void Save(Form form) {
            XmlWriter writer = new XmlTextWriter(LayoutFileName(form), Encoding.UTF8);
            serializer.Serialize(writer, new SerializableLayout(form));
            writer.Close();
        }

        public void Load(Form form) {
            try {
                XmlReader reader = new XmlTextReader(LayoutFileName(form));
                SerializableLayout layout = serializer.Deserialize(reader) as SerializableLayout;
                reader.Close();
                layout.Apply(form);
            }
            catch {
                
            }
        }
    }
}
