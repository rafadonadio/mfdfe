using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
    [ColumnAttributes("Nombre", true, 1, 10),
    ColumnAttributes("Letra", true, 2, 2)]
    [FilterColumnAttribute("Nombre")]
    [Serializable]    
    public class TiposComprobantes : Persistent
    {
        private String nombre;
        private Char letra;
        private String codigo;
        private TiposComprobantesList tipo;

        public override string ToString()
        {
            return nombre;
        }
        public String Nombre
        {
            get { return nombre;  }
            set { nombre = value;  }
        }
        public Char Letra
        {
            get { return letra ; }
            set { letra = value; }
        }
        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public TiposComprobantesList Tipo
        {
            get { return tipo ; }
            set { tipo = value; }
        }
    }

    public enum TiposComprobantesList
    { 
        Factura = 0,
        NotaCredito = 1,
        NotaDebito = 2
    }
}
