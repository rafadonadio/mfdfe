using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Configuration;

namespace Entities
{
    public class DetallesComprobantesDTO
    {
        #region Atributos
        private ComprobantesDTO cabecera;
        private String producto;
        private Int32 cantidad;
        private Double impunitario;
		//private Double impunitarioForm;
        private Double impunitarioneto;
        private Double imptotal;
        private Double imptotalneto;
        private Double impunitariosistema;
        
        #endregion        

        #region Contructor
        public DetallesComprobantesDTO(DetallesComprobantes detalle)
        {
            cabecera = new ComprobantesDTO(detalle.Comprobante);
            cantidad = detalle.Cantidad;
			imptotal = detalle.ImpTotalForm;
            imptotalneto = detalle.ImpTotalNeto;
			impunitario = detalle.ImpUnitarioForm;
            impunitarioneto = detalle.ImpUnitarioNeto;
            impunitariosistema = detalle.ImpUnitarioNetoSistema;
            producto = detalle.Producto.Nombre;
        }
        
        #endregion        
        
        #region Propiedades
        public String CAE
        {
            get { return cabecera.CAE; }
        }
        public String domicilioCliente
        {
            get { return cabecera.domicilioCliente; }
        }
        public String localidadCliente
        {
            get { return cabecera.localidadCliente; }
        }
        public String provinciaCliente
        {
            get { return cabecera.provinciaCliente; }
        }
        public String paisCliente
        {
            get { return cabecera.paisCliente; }
        }
        public String telefonosCliente
        {
            get { return cabecera.telefonosCliente; }
        }
        public byte[] logo
        {
            get { return cabecera.logo; }
        }
        public String cliente
        {
            get { return cabecera.cliente; }
        }
        public String cuitCliente
        {
            get { return cabecera.cuitCliente; }
        }
        public String tipoCliente
        {
            get { return cabecera.tipoCliente; }
        }
        public String tipoPago
        {
            get { return cabecera.tipoPago; }
        }
        public String emision
        {
            get { return cabecera.emision; }
        }
        public String tipo
        {
            get { return cabecera.tipo; }
        }

		public String tipoCodigo
		{
			get { return cabecera.tipoCodigo; }
		}
		public String nrocbante
        {
            get { return cabecera.nrocbante; }
        }
        public String razonSocial
        {
            get { return cabecera.razonSocial; }
        }
        public String direccion
        {
            get { return cabecera.direccion; }
        }
        public String codigoPostal
        {
            get { return cabecera.codigoPostal; }
        }
        public String telefono
        {
            get { return cabecera.telefono; }
        }
        public String email
        {
            get { return cabecera.email; }
        }
        public String sitioWeb
        {
            get { return cabecera.sitioWeb; }
        }
        public String nroIIBB
        {
            get { return cabecera.nroIIBB; }
        }
        public String cuitEmpresa
        {
            get { return cabecera.cuitEmpresa; }
        }
        public String tipoContEmpresa
        {
            get { return cabecera.tipoContEmpresa; }
        }
        public String inicioActividad
        {
            get { return cabecera.inicioAct; }
        }
        public String observaciones
        {
            get { return cabecera.observaciones; }
        }
        /*public Double percepciones
        {
            get { return cabecera.percepciones; }
        }*/

		public string percepciones
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((cabecera.percepciones / cabecera.valorDolar),2).ToString();
				else
					return PrefijoMoneda + cabecera.percepciones.ToString();
			}
		}

        public Double descuento
        {
            get { return cabecera.descuento; }
        }
        public Double subtotalneto
        {
            get { return cabecera.subtotalneto; }
        }
		/*public Double subtotalaimp
		{
			get { return cabecera.subtotalaimp; }
		}*/
		public string subtotalaimp
		{
			get {
				if (cabecera.enDolares && cabecera.valorDolar!=0)
					return PrefijoMoneda + Math.Round((cabecera.subtotalaimp / cabecera.valorDolar), 2).ToString();
			else
					return PrefijoMoneda + cabecera.subtotalaimp.ToString(); 
			}
		}
		public string subtotalaimpForm
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((cabecera.subtotalaimpForm / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + cabecera.subtotalaimpForm.ToString();
			}
		}
        /*public Double iva1
        {
            get { return cabecera.iva1; }
        }
        public Double iva2
        {
            get { return cabecera.iva2; }
        }*/
		public string iva1
		{
			get {
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((cabecera.iva1 / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + Math.Round(cabecera.iva1,2).ToString();
			}
		}
		public string iva2
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((cabecera.iva2 / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + Math.Round(cabecera.iva2, 2).ToString();
			}
		}
        public Double subtotal
        {
            get { return cabecera.subtotal; }
        }

		public string iva1Form
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((cabecera.iva1Form / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + Math.Round(cabecera.iva1Form, 2).ToString();
			}
		}
		public string iva2Form
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((cabecera.iva2Form / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + Math.Round(cabecera.iva2, 2).ToString();
			}
		}
		
        public Double total
        {
            get { return cabecera.total; }
        }
		private string PrefijoMoneda {
			get
			{
				if (cabecera.enDolares)
					return "U$S ";
				else
					return "";
			}
		
		}

		public String totalConvertido
		{
			get {
				if (cabecera.enDolares && cabecera.valorDolar!=0)
					return PrefijoMoneda + Math.Round((cabecera.total / cabecera.valorDolar), 2).ToString();
			else
					return PrefijoMoneda + Math.Round(cabecera.total,2).ToString(); 
			}
		}

		public String estado
        {
            get { return cabecera.estado; }
        }
        public String Producto
        {
            get { return producto; }
        }
        public Int32 Cantidad
        {
            get { return cantidad; }
        }
        /*public Double Impunitario
        {
            get { return impunitario; }
        }*/

		public string Impunitario
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((impunitario / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + impunitario.ToString();
			}
		}
        public Double Impunitarioneto
        {
            get { return impunitarioneto; }
        }
        /*public Double Imptotal
        {
            get { return imptotal; }
        }*/
		public string Imptotal
		{
			get
			{
				if (cabecera.enDolares && cabecera.valorDolar != 0)
					return PrefijoMoneda + Math.Round((imptotal / cabecera.valorDolar), 2).ToString();
				else
					return PrefijoMoneda + imptotal.ToString();
			}
		}
        public Double Imptotalneto
        {
            get { return imptotalneto; }
        }
        public Double Impunitariosistema
        {
            get { return impunitariosistema; }
        }
       
        public String Ambiente
        {
            
            get {
                string flagAmbiente = ConfigurationManager.AppSettings["FlagEnvir"];
                if (flagAmbiente == "0")
                    return "FACTURA REALIZADA CON WEB SERVICE DE HOMOLOGACIÓN";
                else
                    return string.Empty;
            
            }
        }
        #endregion
    }
}
