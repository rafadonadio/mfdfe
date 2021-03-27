using System;

namespace FrameWork.DataBusinessModel.DataModel
{
    /// <summary>
    /// Clase base para el modelo de datos de las aplicaciones
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct,
        AllowMultiple = true)]
    public class ColumnAttributes : Attribute, IComparable {
        string name, caption, format;
        bool visible;
        int index;
        int width;

        public ColumnAttributes(string name, bool visible, int index, int width) : this(name, visible, index, width, name) {
        }

        public ColumnAttributes(string name, bool visible, int index, int width, string caption) {
            this.name = name;
            this.caption = caption;
            this.visible = visible;
            this.index = index;
            this.width = width;
        }

        public ColumnAttributes(string name, bool visible, int index, int width, string caption, string format)
        {
            this.name = name;
            this.caption = caption;
            this.visible = visible;
            this.index = index;
            this.width = width;
            this.format = format; 
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Visible {
            get { return visible; }
            set { visible = value; }
        }

        public int Index {
            get { return index; }
            set { index = value; }
        }

        public int Width {
            get { return width*10; }
            set { width = value; }
        }

        public string Caption {
            get { return caption; }
            set { caption = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }
        
        public int CompareTo(object obj)
        {
            if (obj is ColumnAttributes) return (this.Index.CompareTo(((ColumnAttributes) obj).Index));
            else return -1;
        }
    }
}