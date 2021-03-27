using System;
using System.Collections.Generic;
using System.Text;

namespace Entities {
    public class ComprobantesComprasDTO {
		public String razonSocial;
		public String proveedor;
        public String cuitProveedor;
        public String tipoProveedor;
        public String emision;
        public String tipo;
        public String numero;
        public String observaciones;
        public String estado;
        public byte[] logo;
        public double total;
        public double totalNoGravado;
        public double netoGravado;
        public double impuestoLiquidado;
        public double importeOperacionesExentas;
        public double percepciones;
        public double percepcionesIngresosBrutos;
        public double percepcionesMunicipales;
        public double impuestosInternos;

        public ComprobantesComprasDTO(ComprobantesCompras  comprobante) {
			razonSocial = comprobante.Empresa.RazonSocial;
			proveedor = comprobante.NombreProveedor;
            cuitProveedor = comprobante.CUITProveedor;
            tipoProveedor = comprobante.TipoProveedor.Descripcion;
            emision = comprobante.Emision.ToString("dd/MM/yyyy");
            tipo = comprobante.Tipo.Nombre;
            numero = comprobante.Numero;
            observaciones = comprobante.Observaciones;
            percepciones = comprobante.Percepciones;
            total = comprobante.Total;
            estado = comprobante.Estado;
            logo = comprobante.Empresa.LogoEmpresa;

            total = comprobante.Total;
            totalNoGravado = comprobante.TotalNoGravado;
            netoGravado = comprobante.NetoGravado;
            impuestoLiquidado = comprobante.ImpuestoLiquidado;
            importeOperacionesExentas = comprobante.ImporteOperacionesExentas;
            percepciones = comprobante.Percepciones;
            percepcionesIngresosBrutos = comprobante.PercepcionesIngresosBrutos;
            percepcionesMunicipales = comprobante.PercepcionesMunicipales;
            impuestosInternos = comprobante.ImpuestosInternos;
        }
    }
}
