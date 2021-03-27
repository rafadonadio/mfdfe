using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Funciones
    {
        protected int id;
        protected string nombre;

        public Funciones()
        {
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public override bool Equals(object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return id;
        }


    }
}
