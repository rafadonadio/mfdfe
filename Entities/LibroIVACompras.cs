using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities {
    public class LibroIVACompras {
        private double importeTotal;
        private double importeNetoNoGravado;
        private double importeNetoGravado;
        private double impuestoLiquidado;
        private double importeOperacionesExentas;
        private double importePercepcionesNacionales;
        private double importePercepcionesIngresosBrutos;
        private double importePercepcionesMunicipales;
        private double importeImpuestosInternos;
        private IList<RegistroLibroIVACompras> registros;
        private Empresas empresa;
        private int anio;
        private int mes;

        public LibroIVACompras(Empresas empresa, int anio, int mes, IList comprobantesCompras) {
            registros = new List<RegistroLibroIVACompras>();
            this.empresa = empresa;
            this.anio = anio;
            this.mes = mes;

            importeTotal = importeNetoGravado = importeNetoNoGravado = impuestoLiquidado = 
                importeOperacionesExentas = importePercepcionesNacionales = importePercepcionesIngresosBrutos =
                importePercepcionesMunicipales = importeImpuestosInternos = 0;
            
            CargarComprobantes(comprobantesCompras);
        }
        
        protected void CargarComprobantes(IList comprobantesCompras) {
            foreach (ComprobantesCompras comprobante in comprobantesCompras) {
                foreach (RegistroLibroIVACompras registroLibroIVACompras in RegistrosPorIVA(comprobante)) {
                    registros.Add(registroLibroIVACompras);

                    importeNetoNoGravado += registroLibroIVACompras.ImporteNetoNoGravado;
                    importeNetoGravado += registroLibroIVACompras.ImporteNetoGravado;
                    impuestoLiquidado += registroLibroIVACompras.ImpuestoLiquidado;
                    importeOperacionesExentas += registroLibroIVACompras.ImporteOperacionesExentas;
                    importePercepcionesNacionales += registroLibroIVACompras.ImportePercepcionesNacionales;
                    importePercepcionesIngresosBrutos += registroLibroIVACompras.ImportePercepcionesIngresosBrutos;
                    importePercepcionesMunicipales += registroLibroIVACompras.ImportePercepcionesMunicipales;
                    importeImpuestosInternos += registroLibroIVACompras.ImporteImpuestosInternos;
                    importeTotal += registroLibroIVACompras.ImporteTotal;
                }
            }
        }

        protected IList<RegistroLibroIVACompras> RegistrosPorIVA(ComprobantesCompras comprobante) {
            IDictionary<Ivas, RegistroLibroIVACompras> dictionary = new Dictionary<Ivas, RegistroLibroIVACompras>();
            IList<RegistroLibroIVACompras> result = new List<RegistroLibroIVACompras>();
            RegistroLibroIVACompras registroActual;

            comprobante.CalcularTotales();
            foreach (DetallesComprobantesCompras detalle in comprobante.Items) {
                if (!dictionary.ContainsKey(detalle.TipoIva)) dictionary.Add(detalle.TipoIva, new RegistroLibroIVACompras(comprobante));
                registroActual=dictionary[detalle.TipoIva];
                
                registroActual.ImporteNetoGravado += detalle.ImporteGravado;
                registroActual.ImporteNetoNoGravado += detalle.ImporteNoGravado;
                registroActual.ImporteOperacionesExentas += detalle.ImporteOperacionesExentas;
                registroActual.ImpuestoLiquidado += detalle.ImporteImpuesto;
            }

            foreach (KeyValuePair<Ivas, RegistroLibroIVACompras> pair in dictionary) {
                pair.Value.AlicuotaIVA = pair.Key.Alicuota;
                pair.Value.CantidadAlicuotas = dictionary.Count;
                result.Add(pair.Value);
            }

            //El último lleva el total de todos los demás campos para ImporteTotal, ImpuestosInternos, 
            //ImportePercepcionesIngresosBrutos, ImportePercepcionesMunicipales e ImportePercepcionesNacionales
            registroActual = result[result.Count - 1];
            registroActual.ImporteImpuestosInternos = comprobante.ImpuestosInternos;
            registroActual.ImportePercepcionesIngresosBrutos = comprobante.PercepcionesIngresosBrutos;
            registroActual.ImportePercepcionesMunicipales = comprobante.PercepcionesMunicipales;
            registroActual.ImportePercepcionesNacionales = comprobante.Percepciones;
            registroActual.ImporteTotal = comprobante.Total;
            
            return result;
        }

        public double ImporteTotal {
            get { return importeTotal; }
        }

        public double ImporteNetoNoGravado {
            get { return importeNetoNoGravado; }
        }

        public double ImporteNetoGravado {
            get { return importeNetoGravado; }
        }

        public double ImpuestoLiquidado {
            get { return impuestoLiquidado; }
        }

        public double ImporteOperacionesExentas {
            get { return importeOperacionesExentas; }
        }

        public double ImportePercepcionesNacionales {
            get { return importePercepcionesNacionales; }
        }

        public double ImportePercepcionesIngresosBrutos {
            get { return importePercepcionesIngresosBrutos; }
        }

        public double ImportePercepcionesMunicipales {
            get { return importePercepcionesMunicipales; }
        }

        public double ImporteImpuestosInternos {
            get { return importeImpuestosInternos; }
        }

        public IList<RegistroLibroIVACompras> Registros {
            get { return registros; }
        }

        public Empresas Empresa {
            get { return empresa; }
            set { empresa = value; }
        }

        public int Anio {
            get { return anio; }
            set { anio = value; }
        }

        public int Mes {
            get { return mes; }
            set { mes = value; }
        }
    }
    
    public class RegistroLibroIVACompras {
        public double ImporteTotal, ImporteNetoGravado, ImporteNetoNoGravado, ImpuestoLiquidado, 
                      ImporteOperacionesExentas, ImportePercepcionesNacionales, 
                      ImportePercepcionesIngresosBrutos, ImportePercepcionesMunicipales, ImporteImpuestosInternos;
        public double AlicuotaIVA;
        
        public DateTime FechaComprobante;
        public string TipoComprobante;
        public string PuntoVenta;
        public string NumeroComprobante;
        public int CantidadHojasComprobante;
        public bool Importacion;
        public int CodigoAduana;
        public string CodigoDestinacion;
        public string NumeroDespacho;
        public char DigitoVerificadorNumeroDespacho;
        public DateTime? FechaDespacho;
        public string CUITProveedor;
        public string NombreProveedor;
        public string TipoProveedor;
        public int CantidadAlicuotas;
        public string CAI;
        public DateTime FechaVencimientoCAI;
        
        public RegistroLibroIVACompras(ComprobantesCompras comprobante) {
            ImporteTotal = ImporteNetoGravado = ImporteNetoNoGravado = ImpuestoLiquidado = 
                ImporteOperacionesExentas = ImportePercepcionesNacionales = ImportePercepcionesIngresosBrutos = 
                ImportePercepcionesMunicipales = ImporteImpuestosInternos = 0;

            FechaComprobante = comprobante.Emision;
            TipoComprobante = comprobante.Tipo.Codigo;
            PuntoVenta = comprobante.Numero.Substring(0, 4);
            NumeroComprobante = comprobante.Numero.Substring(5);
            CantidadHojasComprobante = comprobante.CantidadHojas;
            Importacion = comprobante.Importacion;
            if (comprobante.Importacion) {
                CodigoAduana = comprobante.Aduana.Codigo;
                CodigoDestinacion = comprobante.Destinacion.Codigo;
                NumeroDespacho = comprobante.NumeroDespacho;
                DigitoVerificadorNumeroDespacho = comprobante.DigitoVerificadorNumeroDespacho;
                FechaDespacho = comprobante.FechaDespacho;
            }
            CUITProveedor = comprobante.CUITProveedor;
            NombreProveedor = comprobante.NombreProveedor;
            TipoProveedor = comprobante.TipoProveedor.Codigo;
            CAI = comprobante.CAIProveedor;
            FechaVencimientoCAI = comprobante.FechaVencimientoCAIProveedor;
        }
    }
}
