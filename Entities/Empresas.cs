using System;
using System.Drawing;
using System.IO;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities {
    [ColumnAttributes("RazonSocial", true, 1, 15),
        ColumnAttributes("Cuit", true, 2, 10)]
    [Serializable]
    public class Empresas : Persistent {
        private String razonSocial;
        private String direccion;
        private String codigoPostal;
        private String cuit;
        private DateTime inicio;
        private String email;
        private Boolean iibb;
        private String nroIIBB;
        private String telefono;
        private String sitioWeb;
        private Boolean verReporte;
        private Boolean percepciones;
        private Double montoMinimoPerc;
        private Double porcentajePerc;
        private Usuarios userUpd;
        private TiposContribuyentes tipoContribuyente;
        private Ivas iva1;
        private Ivas iva2;
        private String cai;
        private DateTime fechaVtoCAI;
        private byte[] logoEmpresa;
        private String logoEmpresaFileName;
        private byte[] loginTicket;
        private String loginTicketFileName;
        private byte[] certificado;
        private String certificadoFileName;
        private String certificadoPassword;
        private byte[] certificadoDestino;
        private String certificadoDestinoFileName;
        private String dnOrigen;
        private String dnDestino;
        private string ultimaFacturaA;
        private string ultimaFacturaB;
		private string ultimaFacturaC;
		private string ultimaFacturaE;
		private string ultimaNotaDebitoA;
        private string ultimaNotaDebitoB;
		private string ultimaNotaDebitoC;
		private string ultimaNotaDebitoE;
		private string ultimaNotaCreditoA;
        private string ultimaNotaCreditoB;
        private string ultimaNotaCreditoC;
		private string ultimaNotaCreditoE;

		private int? puntoDeVenta;
        
		private string senderName;

        public Empresas()
            : base() {
            inicio = DateTime.Now;
        }

        public override string ToString() {
            return razonSocial;
        }

        public String RazonSocial {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        // Ultimos Comprobantes

        public String UltimaFacturaA
        {
            get { return ultimaFacturaA; }
            set { ultimaFacturaA = value; }
        }

        public String UltimaFacturaB
        {
            get { return ultimaFacturaB; }
            set { ultimaFacturaB = value; }
        }

		public String UltimaFacturaC
		{
			get { return ultimaFacturaC; }
			set { ultimaFacturaC = value; }
		}

		public String UltimaFacturaE
		{
			get { return ultimaFacturaE; }
			set { ultimaFacturaE = value; }
		}

		public String UltimaNotaDebitoA
        {
            get { return ultimaNotaDebitoA; }
            set { ultimaNotaDebitoA = value; }
        }

        public String UltimaNotaDebitoB
        {
            get { return ultimaNotaDebitoB; }
            set { ultimaNotaDebitoB = value; }
        }

		public String UltimaNotaDebitoC
		{
			get { return ultimaNotaDebitoC; }
			set { ultimaNotaDebitoC = value; }
		}

		public String UltimaNotaDebitoE
		{
			get { return ultimaNotaDebitoE; }
			set { ultimaNotaDebitoE = value; }
		}

        public String UltimaNotaCreditoA
        {
            get { return ultimaNotaCreditoA; }
            set { ultimaNotaCreditoA = value; }
        }

        public String UltimaNotaCreditoB
        {
            get { return ultimaNotaCreditoB; }
            set { ultimaNotaCreditoB = value; }
        }

        public String UltimaNotaCreditoC
        {
            get { return ultimaNotaCreditoC; }
            set { ultimaNotaCreditoC = value; }
        }

		public String UltimaNotaCreditoE
		{
			get { return ultimaNotaCreditoE; }
			set { ultimaNotaCreditoE = value; }
		}
        // Fin Ultimos Comprobantes
        
        public TiposContribuyentes TipoContribuyente {
            get { return tipoContribuyente; }
            set { tipoContribuyente = value; }
        }

        public String Direccion {
            get { return direccion; }
            set { direccion = value; }
        }

        public String CodigoPostal {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public String Cuit {
            get { return cuit; }
            set { cuit = value; }
        }

        public DateTime Inicio {
            get { return inicio; }
            set { inicio = value; }
        }

        public String Email {
            get { return email; }
            set { email = value; }
        }

        public Boolean IIBB
        {
            get { return iibb; }
            set { iibb = value; }
        }

        public String NroIIBB
        {
            get { return nroIIBB; }
            set { nroIIBB = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string SitioWeb
        {
            get { return sitioWeb; }
            set { sitioWeb = value; }
        }

        public Boolean VerReporte
        {
            get { return verReporte; }
            set { verReporte = value; }
        }
	
	
	
        public Boolean Percepciones {
            get { return percepciones; }
            set { percepciones = value; }
        }

        public Double MontoMinimoPerc {
            get { return montoMinimoPerc; }
            set { montoMinimoPerc = value; }
        }

        public Double PorcentajePerc {
            get { return porcentajePerc; }
            set { porcentajePerc = value; }
        }

        public Usuarios UserUpd {
            get { return userUpd; }
            set { userUpd = value; }
        }

        public Ivas Iva1 {
            get { return iva1; }
            set { iva1 = value; }
        }

        public Ivas Iva2 {
            get { return iva2; }
            set { iva2 = value; }
        }

        public String CAI {
            get { return cai; }
            set { cai = value; }
        }

        public DateTime FechaVtoCAI {
            get { return fechaVtoCAI; }
            set { fechaVtoCAI = value; }
        }

        public byte[] LogoEmpresa {
            get { return logoEmpresa; }
            set { logoEmpresa = value; }
        }

        public Image ImageLogoEmpresa {
            get {
                if (logoEmpresa != null) {
                    return Image.FromStream(new MemoryStream(logoEmpresa));
                }
                else
                    return null;
            }
        }

        public String LogoEmpresaFileName {
            get { return logoEmpresaFileName; }
            set { logoEmpresaFileName = value; }
        }

        public byte[] LoginTicket {
            get { return loginTicket; }
            set { loginTicket = value; }
        }

        public String LoginTicketFileName {
            get { return loginTicketFileName; }
            set { loginTicketFileName = value; }
        }

        public byte[] Certificado {
            get { return certificado; }
            set { certificado = value; }
        }

        public String CertificadoFileName {
            get { return certificadoFileName; }
            set { certificadoFileName = value; }
        }

        public String CertificadoPassword {
            get { return certificadoPassword; }
            set { certificadoPassword = value; }
        }

        public byte[] CertificadoDestino {
            get { return certificadoDestino; }
            set { certificadoDestino = value; }
        }

        public String CertificadoDestinoFileName {
            get { return certificadoDestinoFileName; }
            set { certificadoDestinoFileName = value; }
        }

        public string DNOrigen {
            get { return dnOrigen; }
            set { dnOrigen = value; }
        }

        public string DNDestino {
            get { return dnDestino; }
            set { dnDestino = value; }
        }
        
        public String SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }

		public int? PuntoDeVenta
		{
			get { return puntoDeVenta; }
			set { puntoDeVenta = value; }
		}
    }
}