using System;

namespace FrameWork.DataBusinessModel.DataModel
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct,
        AllowMultiple = true)]
    public class SortKeyAttributes : Attribute, IComparable {
        private string name;
        private int index;
        private bool ascending;

        public string Name {
            get { return name; }
        }

        public int Index {
            get { return index; }
        }

        public bool Ascending {
            get { return ascending; }
        }

        public SortKeyAttributes(string name) : this(name, true) {
        }

        public SortKeyAttributes(string name, bool ascending) : this(name, ascending, 0) {
        }

        public SortKeyAttributes(string name, bool ascending, int index) {
            this.name = name;
            this.ascending = ascending;
            this.index = index;
        }

        public int CompareTo(object obj) {
            if (obj is SortKeyAttributes) return (this.Index.CompareTo((obj as SortKeyAttributes).Index));
            else return -1;
        }
    }
}