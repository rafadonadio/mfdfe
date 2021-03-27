using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities {
    [ColumnAttributes("Codigo", true, 1, 10, "Código"),
     ColumnAttributes("Descripcion", true, 2, 20, "Descripción"),
     SortKeyAttributes("Codigo")]
    public class Aduanas:Persistent {
        private int codigo;
        private string descripcion;

        public int Codigo {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descripcion {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public override string ToString() {
            return String.Format("{0} - {1}", Codigo, Descripcion);
        }
    }
}
