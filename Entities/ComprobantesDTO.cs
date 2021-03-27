using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Entities
{
    public class ComprobantesDTO
    {
        public String CAE;
		public String razonSocial;
		public String direccion;
		public String codigoPostal;
        public String telefono;
        public String email;
        public String sitioWeb;
        public String cuitEmpresa;
		public Boolean iibb;
        public String nroIIBB;
        public String inicioAct;
        public String tipoContEmpresa;
		public String cliente;
		public String cuitCliente;
        public String tipoCliente;
        public String tipoPago;
        public String emision;
        public String tipo;
		public String tipoCodigo;
		public String nrocbante;
        public String observaciones;
        public Double percepciones;
        public Double descuento;
        public Double subtotalneto;
        public Double subtotalaimp;
        public Double iva1;
        public Double iva2;
		public Double subtotalaimpForm;
		public Double iva1Form;
		public Double iva2Form;
        
		public Double subtotal;
        public Double total;
        public String estado;
		public Double valorDolar=1;
		public bool enDolares;
        public byte[] logo ;
        public string domicilioCliente;
        public string localidadCliente;
        public string provinciaCliente;
        public string paisCliente;
        public string telefonosCliente;
        
        public ComprobantesDTO (Comprobantes comprobante)
        {
            CAE = comprobante.CAE;
			razonSocial = comprobante.Empresa.RazonSocial;
			direccion = comprobante.Empresa.Direccion;
			codigoPostal = comprobante.Empresa.CodigoPostal;
            telefono = comprobante.Empresa.Telefono;
            email = comprobante.Empresa.Email;
            sitioWeb = comprobante.Empresa.SitioWeb;
            iibb = comprobante.Empresa.IIBB;
            nroIIBB = comprobante.Empresa.NroIIBB;
            telefono = comprobante.Empresa.Telefono;
            cuitEmpresa = comprobante.Empresa.Cuit;
            tipoContEmpresa = comprobante.Empresa.TipoContribuyente.Descripcion;
            cliente = comprobante.NombreCliente;
			cuitCliente = comprobante.CUITCliente;
            tipoCliente = comprobante.TipoCliente.Descripcion;
			tipoPago = comprobante.TipoPago.Descripcion;
            emision = comprobante.Emision.ToString("dd/MM/yyyy");
            tipo = comprobante.Tipo.Nombre;
			tipoCodigo = comprobante.Tipo.Codigo;
			nrocbante = comprobante.NroCbante;
            observaciones = comprobante.Observaciones ;
            percepciones = comprobante.Percepciones ;
            descuento = comprobante.Descuento ;
            subtotalneto = comprobante.SubtotalNeto;
            subtotalaimp = comprobante.SubtotalAImp; 
			iva1 = comprobante.Iva1;
			iva2 = comprobante.Iva2;
			subtotalaimpForm = comprobante.SubtotalForm; 
            iva1Form = comprobante.Iva1Form;
            iva2Form = comprobante.Iva2Form ;
            subtotal = comprobante.Subtotal ;
            total = comprobante.Total;
            estado = comprobante.Estado;
            logo = comprobante.Empresa.LogoEmpresa;
			inicioAct = comprobante.Empresa.Inicio.ToString("dd/MM/yyyy");

            if (comprobante.Cliente != null)
            {
                domicilioCliente = comprobante.Cliente.Domicilio;
                localidadCliente = comprobante.Cliente.Localidad ;
                if(comprobante.Cliente.Provincia != null) provinciaCliente = comprobante.Cliente.Provincia.ToString ();
                if (comprobante.Cliente.Pais != null) paisCliente = comprobante.Cliente.Pais.ToString();
                telefonosCliente = comprobante.Cliente.Telefonos ;
				enDolares = comprobante.EnDolares;
				valorDolar = GeneralSettings.Instance.CotizacionUS;
            }
        }
    }
}
