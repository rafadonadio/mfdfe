using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;
using Security;

namespace Entities {
     [ColumnAttributes("Emision", true, 1, 10, "Emisión", "dd/MM/yyyy"),
     ColumnAttributes("Letra", true, 2, 2),
     ColumnAttributes("Numero", true, 3, 15, "Número"),
     ColumnAttributes("NombreProveedor", true, 4, 15, "Proveedor"),
     ColumnAttributes("CUITProveedor", true, 5, 15, "CUIT"),
     ColumnAttributes("Estado", true, 6, 10)]
    public class ComprobantesCompras : Persistent {
        public const string EstadoEmitido = "EMITIDO";
        public const string EstadoAnulado = "ANULADO";

        private IList<DetallesComprobantesCompras> items;

        //Datos Generales
        private TiposComprobantesList supertipo;
        private TiposComprobantes tipo;
        private String numero;
        private int cantidadHojas;
        private DateTime emision;
        private Nullable<DateTime> anulacion;
        private String estado;
        private Empresas empresa;
        private String observaciones;
        
        //Datos del Proveedor
        private String nombreProveedor;
        private String cuitProveedor;
        private String caiProveedor;
        private DateTime fechaVencimientoCAIProveedor;
        private TiposContribuyentes tipoProveedor;

        //Datos Aduaneros
        private bool importacion;
        private Destinaciones destinacion;
        private Aduanas aduana;
        private String numeroDespacho;
        private Char digitoVerificadorNumeroDespacho;
        private Nullable<DateTime> fechaDespacho;
        
        //Totales
        private double total;
        private double totalNoGravado;
        private double netoGravado;
        private double impuestoLiquidado;
        private double importeOperacionesExentas;
        private double percepciones;
        private double percepcionesIngresosBrutos;
        private double percepcionesMunicipales;
        private double impuestosInternos;
        
        public ComprobantesCompras() {
            items = new List<DetallesComprobantesCompras>();
            emision = DateTime.Now;
            estado = EstadoEmitido;
            anulacion = null;
            CantidadHojas = 1;
            FechaVencimientoCAIProveedor = DateTime.Now;
            
            Percepciones = PercepcionesIngresosBrutos = PercepcionesMunicipales = ImpuestosInternos = 0;
            CalcularTotales();
            ActualizarTotal();
        }
        
        public void Anular() {
            estado = EstadoAnulado;
            anulacion = DateTime.Now;
        }
        
        public void AddChild(DetallesComprobantesCompras detalle) {
            if (!items.Contains(detalle)) {
                items.Add(detalle);
                CalcularTotales();
                ActualizarTotal();
            }
            CalcularTotales();
            ActualizarTotal();
        }
        
        public void CalcularTotales() {
            totalNoGravado = netoGravado = impuestoLiquidado = importeOperacionesExentas = 0;
            
            foreach (DetallesComprobantesCompras detalle in items) {
                totalNoGravado += detalle.ImporteNoGravado;
                netoGravado += detalle.ImporteGravado;
                importeOperacionesExentas += detalle.ImporteOperacionesExentas;
                impuestoLiquidado += detalle.ImporteImpuesto;
                ActualizarTotal();
            }
            
            ActualizarTotal();
        }
        
        private void ActualizarTotal() {
            total = TotalNoGravado + NetoGravado + ImpuestoLiquidado + ImporteOperacionesExentas + Percepciones +
                    PercepcionesIngresosBrutos + PercepcionesMunicipales + ImpuestosInternos;
        }
        
        public DateTime Emision {
            get { return emision; }
            set { emision = value; }
        }
        
        public TiposComprobantes Tipo {
            get { return tipo; }
            set { tipo = value; }
        }
        
        public Char Letra {
            get {
                if (Tipo != null)
                    return Tipo.Letra;
                else
                    return ' ';
            }
        }

        public TiposComprobantesList Supertipo {
            get { return supertipo; }
            set { supertipo = value; }
        }

        public String Numero {
            get { return numero; }
            set { numero = value; }
        }

        public string NombreProveedor {
            get { return nombreProveedor; }
            set { nombreProveedor = value; }
        }

        public string CUITProveedor {
            get { return cuitProveedor; }
            set { cuitProveedor = value; }
        }

        public string CAIProveedor {
            get { return caiProveedor; }
            set { caiProveedor = value; }
        }

        public DateTime FechaVencimientoCAIProveedor {
            get { return fechaVencimientoCAIProveedor; }
            set { fechaVencimientoCAIProveedor = value; }
        }

        public TiposContribuyentes TipoProveedor {
            get { return tipoProveedor; }
            set { tipoProveedor = value; }
        }

        public string Estado {
            get { return estado; }
        }

        public bool IsAnulado {
            get { return Estado == EstadoAnulado; }
        }
        
        public DateTime? Anulacion {
            get { return anulacion; }
        }

        public Empresas Empresa {
            get { return empresa; }
            set { empresa = value; }
        }

        public int CantidadHojas {
            get { return cantidadHojas; }
            set { cantidadHojas = value; }
        }

        public IList<DetallesComprobantesCompras> Items {
            get { return items; }
            set { items = value; }
        }

        public double Total {
            get { return total; }
            set { total = value; }
        }

        public double TotalNoGravado {
            get { return totalNoGravado; }
			set { totalNoGravado = value; }
        }

        public double NetoGravado {
            get { return netoGravado; }
			set { netoGravado = value; }
        }

        public double ImpuestoLiquidado {
            get { return impuestoLiquidado; }
			set { impuestoLiquidado = value; }
        }

        public double ImporteOperacionesExentas {
            get { return importeOperacionesExentas; }
        }

        public double Percepciones {
            get { return percepciones; }
            set { percepciones = value; ActualizarTotal(); }
        }

        public double PercepcionesIngresosBrutos {
            get { return percepcionesIngresosBrutos; }
            set { percepcionesIngresosBrutos = value; ActualizarTotal(); }
        }

        public double PercepcionesMunicipales {
            get { return percepcionesMunicipales; }
            set { percepcionesMunicipales = value; ActualizarTotal(); }
        }

        public double ImpuestosInternos {
            get { return impuestosInternos; }
            set { impuestosInternos = value; ActualizarTotal(); }
        }

        public Destinaciones Destinacion {
            get { return destinacion; }
            set { destinacion = value; }
        }

        public Aduanas Aduana {
            get { return aduana; }
            set { aduana = value; }
        }

        public string NumeroDespacho {
            get { return numeroDespacho; }
            set { numeroDespacho = value; }
        }

        public char DigitoVerificadorNumeroDespacho {
            get { return digitoVerificadorNumeroDespacho; }
            set { digitoVerificadorNumeroDespacho = value; }
        }

        public DateTime? FechaDespacho {
            get { return fechaDespacho; }
            set { fechaDespacho = value; }
        }

        public string Observaciones {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public bool Importacion {
            get { return importacion; }
            set { importacion = value; }
        }
    }
}
