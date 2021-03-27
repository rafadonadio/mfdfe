using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public enum FormatoComprobante {RTF, PDF, HTML, XML};
    [Serializable]
    public class GeneralSettings : Settings
    {
        protected Int32 idEmpresaDefault;
        protected String codigoCUIT;
        protected String codigoMoneda;
        protected String filesFolder;

        protected String smtpUser;
        protected String smtpPass;
        protected String smtpServer;
        protected Int32 smtpServerPort;
        protected bool smtpSSLEnabled;
        protected String email;
        protected String emailSubject;
        protected String emailReclamos;
		protected String emailTexto;
		protected FormatoComprobante formatoComprobante;
        protected string ntpServer;
        private string wsNegocio;
        private string wsPublicacion;
		protected String fileBackUp;
		protected double cotizacionUS;

        private GeneralSettings() {
            FormatoComprobante = FormatoComprobante.RTF;
        }
        
        private static GeneralSettings instance = null;

        public static GeneralSettings Instance
        {
            get
            {
                if (instance == null) instance = new GeneralSettings();
                return instance;
            }
        }
        protected override void SetInstance(Settings s)
        {
            if (s is GeneralSettings) instance = s as GeneralSettings;
        }
        protected override Settings GetInstance()
        {
            return instance;
        }


        public Int32 IdEmpresaDefault {
            get { return idEmpresaDefault ; }
            set { idEmpresaDefault = value; }
        }

        public String CodigoCUIT {
            get { return codigoCUIT ; }
            set { codigoCUIT = value; }
        }
        
        public String CodigoMoneda
        {
            get { return codigoMoneda ; }
            set { codigoMoneda = value; }
        }
        public String FilesFolder
        {
            get { return filesFolder ; }
            set { filesFolder = value; }
        }
        public String SmtpServer
        {
            get { return smtpServer; }
            set { smtpServer = value; }
        }
        public Int32 SmtpServerPort
        {
            get { return smtpServerPort; }
            set { smtpServerPort = value; }
        }
        public String SmtpUser
        {
            get { return smtpUser; }
            set { smtpUser = value; }
        }
        public String SmtpPass
        {
            get { return smtpPass; }
            set { smtpPass = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String EmailReclamos {
            get { return emailReclamos; }
            set { emailReclamos = value; }
        }
		public String EmailTexto
		{
			get { return emailTexto; }
			set { emailTexto = value; }
		}
        public String EmailSubject
        {
            get { return emailSubject; }
            set { emailSubject = value; }
        }

        public FormatoComprobante FormatoComprobante {
            get { return formatoComprobante; }
            set { formatoComprobante = value; }
        }

        public bool SmtpSSLEnabled {
            get { return smtpSSLEnabled; }
            set { smtpSSLEnabled = value; }
        }

        public string NTPServer {
            get { return ntpServer; }
            set { ntpServer = value; }
        }

        public string WSNegocio {
            get { return wsNegocio; }
            set { wsNegocio = value; }
        }
        public string WSPublicacion
        {
            get { return wsPublicacion; }
            set { wsPublicacion = value; }
        }
		public String FileBackUp
		{
			get { return fileBackUp; }
			set { fileBackUp = value; }
		}
		public double CotizacionUS
		{
			get { return cotizacionUS; }
			set { cotizacionUS = value; }
		}
    }
}
