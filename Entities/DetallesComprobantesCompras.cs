using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities {
    [ColumnAttributes("ImporteGravado", true, 1, 8, "Gravado", "#0.#0"),
    ColumnAttributes("ImporteNoGravado", true, 2, 8, "No Gravado", "#0.#0"),
    ColumnAttributes("ImporteOperacionesExentas", true, 3, 8, "Exentas", "#0.#0"),
    ColumnAttributes("TipoIva", true, 4, 8, "IVA")]
    public class DetallesComprobantesCompras:Persistent {
        private ComprobantesCompras comprobante;
        private Ivas tipoIva;
        private double importeGravado;
        private double importeNoGravado;
        private double importeOperacionesExentas;
        
        public ComprobantesCompras Comprobante {
            get { return comprobante; }
            set { comprobante = value; }
        }

        public Ivas TipoIva {
            get { return tipoIva; }
            set { tipoIva = value; }
        }

        public double ImporteGravado {
            get { return importeGravado; }
            set { importeGravado = value; }
        }

        public double ImporteNoGravado {
            get { return importeNoGravado; }
            set { importeNoGravado = value; }
        }

        public double ImporteOperacionesExentas {
            get { return importeOperacionesExentas; }
            set { importeOperacionesExentas = value; }
        }
        
        public double ImporteImpuesto {
            get {
                if (tipoIva != null) return (ImporteGravado * TipoIva.Alicuota / 100);
                else return 0;
            }
        }
    }
}
