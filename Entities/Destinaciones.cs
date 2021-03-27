using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities {
    [ColumnAttributes("Codigo", true, 1, 10, "Código"),
     ColumnAttributes("Descripcion", true, 2, 20, "Descripción"),
     ColumnAttributes("Desde", true, 3, 10),
     ColumnAttributes("Hasta", true, 4, 10),
     SortKeyAttributes("Codigo")]
    public class Destinaciones:Persistent {
        private string codigo;
        private string descripcion;
        private DateTime desde;
        private DateTime hasta;

        public Destinaciones() {
            Desde = Hasta = DateTime.Now;
        }
        
        public string Codigo {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime Desde {
            get { return desde; }
            set { desde = value; }
        }

        public DateTime Hasta {
            get { return hasta; }
            set { hasta = value; }
        }

        public override string ToString() {
            return String.Format("{0} - {1}", Codigo, Descripcion);
        }

    }
}
