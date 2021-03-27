using System;

namespace FrameWork.DataBusinessModel.DataModel
{
    /// <summary>
    /// Clase base para el modelo de datos de las aplicaciones
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct,
        AllowMultiple = false)]
    public class FilterColumnAttribute : Attribute
    {
        string name;


        public FilterColumnAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}