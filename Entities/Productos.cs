using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
    [ColumnAttributes("Identificacion", true, 1, 10),
    ColumnAttributes("Nombre", true, 2, 15)]
    [FilterColumnAttribute("Identificacion")]
    public class Productos : Persistent
    {
        private string identificacion;
        private string nombre;
        private Double impmc;
        private Ivas tipoIva;
        private Usuarios  userUpd;
        private Rubros rubro;
        private Clases clase;

        public override string ToString()
        {
            return identificacion;
        }

        public string Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Double Impmc
        {
            get { return impmc; }
            set { impmc = value; }
        }
        public Ivas TipoIva
        {
            get { return tipoIva ; }
            set { tipoIva  = value; }
        }
        public Usuarios  UserUpd
        {
            get { return userUpd; }
            set { userUpd = value; }
        }
        public Rubros Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }
        public Clases Clase
        {
            get { return clase ; }
            set { clase = value; }
        }
    }



}
