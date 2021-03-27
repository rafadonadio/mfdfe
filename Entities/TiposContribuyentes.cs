using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
    [Serializable]
    public class TiposContribuyentes : IdDescripcion 
    {
        private TiposComprobantes tipoComprobanteFactura;
        private TiposComprobantes tipoComprobanteNotaDebito;
        private TiposComprobantes tipoComprobanteNotaCredito;
        private bool discriminaIVA;
        private bool percepciones;
        private String codigo;
		private bool computaIVA;

        public TiposComprobantes TipoComprobanteFactura
        {
            get { return tipoComprobanteFactura; }
            set { tipoComprobanteFactura = value; }
        }
        public TiposComprobantes TipoComprobanteNotaDebito
        {
            get { return tipoComprobanteNotaDebito; }
            set { tipoComprobanteNotaDebito = value; }
        }
        public TiposComprobantes TipoComprobanteNotaCredito
        {
            get { return tipoComprobanteNotaCredito; }
            set { tipoComprobanteNotaCredito = value; }
        }
        public bool DiscriminaIVA
        {
            get { return discriminaIVA; }
            set { discriminaIVA = value; }
        }
        public bool Percepciones
        {
            get { return percepciones; }
            set { percepciones = value; }
        }
        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
		public bool ComputaIVA
		{
			get { return computaIVA; }
			set { computaIVA = value; }
		}
    }
}
