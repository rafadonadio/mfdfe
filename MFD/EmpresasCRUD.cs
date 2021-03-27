using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Entities;
using FrameWork.CRUDModel.Windows.UI;
using MFD.Clases;

namespace MFD {
    public partial class EmpresasCRUD : CRUDForm {
        public EmpresasCRUD() {
            InitializeComponent();
			//cmbTipoContrib.Text = "Inscripto";
            stylesSheetManager.ApplyStyles();
        }

        new public Empresas Persistent {
            get { return (Empresas) persistent; }
            set { persistent = value; }
        }

        protected override void FillControls() {
            txtRazonSocial.Text = Persistent.RazonSocial;
            txtDireccion.Text = Persistent.Direccion;
            txtCodigoPostal.Text = Persistent.CodigoPostal;
            txtTelefono.Text = Persistent.Telefono;
            txtEmail.Text = Persistent.Email;
            txtSitioWeb.Text = Persistent.SitioWeb;
            txtCUIT.Text = Persistent.Cuit;
            //dcTipoContribuyente.Selected = Persistent.TipoContribuyente;
			cmbTipoContrib.SelectedItem = Persistent.TipoContribuyente;
            txtFecha.Value = Persistent.Inicio;
            txtNroIIBB.Text = Persistent.NroIIBB;
            txtLogoEmpresa.Text = Persistent.LogoEmpresaFileName;
            chkVerReporte.Checked = Persistent.VerReporte;
            
            chkPercepciones.Checked = Persistent.Percepciones;
            txtMontoMinimoPerc.Text = Persistent.MontoMinimoPerc.ToString();
            txtPorcentajePerc.Text = Persistent.PorcentajePerc.ToString();
            cmbIva1.SelectedItem = Persistent.Iva1;
            cmbIva2.SelectedItem = Persistent.Iva2;
            txtLoginTicket.Text = Persistent.LoginTicketFileName;
            txtCertificado.Text = Persistent.CertificadoFileName;
            txtCertificadoDestino.Text = Persistent.CertificadoDestinoFileName;
            txtCertificadoPassword.Text = Persistent.CertificadoPassword;
            txtDNOrigen.Text = Persistent.DNOrigen;
            txtDNDestino.Text = Persistent.DNDestino;
            txtUltimaFacturaA.Text = Persistent.UltimaFacturaA;
            txtUltimaFacturaB.Text = Persistent.UltimaFacturaB;
            txtUltimaFacturaC.Text = Persistent.UltimaFacturaC;
			txtUltimaFacturaE.Text = Persistent.UltimaFacturaE;
            txtUltimaNotaCreditoA.Text = Persistent.UltimaNotaCreditoA;
            txtUltimaNotaCreditoB.Text = Persistent.UltimaNotaCreditoB;
			txtUltimaNotaCreditoC.Text = Persistent.UltimaNotaCreditoC;
			txtUltimaNotaCreditoE.Text = Persistent.UltimaNotaCreditoE;
			txtUltimaNotaDebitoA.Text = Persistent.UltimaNotaDebitoA;
            txtUltimaNotaDebitoB.Text = Persistent.UltimaNotaDebitoB;
			txtUltimaNotaDebitoC.Text = Persistent.UltimaNotaDebitoC;
			txtUltimaNotaDebitoE.Text = Persistent.UltimaNotaDebitoE;
			txtSenderName.Text = Persistent.SenderName;
			nudPtoVenta.Value = (Persistent.PuntoDeVenta.HasValue)?Persistent.PuntoDeVenta.Value:1;
			toolTipDNO.SetToolTip(txtDNOrigen, txtDNOrigen.Text);
			toolTipDND.SetToolTip(txtDNDestino, txtDNDestino.Text);

            base.FillControls();
        }

        protected override void FillObject() {
            Persistent.RazonSocial = txtRazonSocial.Text;
            Persistent.Direccion = txtDireccion.Text;
            Persistent.CodigoPostal = txtCodigoPostal.Text;
            Persistent.Telefono = txtTelefono.Text;
            Persistent.Email = txtEmail.Text;
            Persistent.SitioWeb = txtSitioWeb.Text;
            Persistent.Cuit = txtCUIT.Text;
            //Persistent.TipoContribuyente = (TiposContribuyentes)dcTipoContribuyente.Selected;
			Persistent.TipoContribuyente = (TiposContribuyentes)cmbTipoContrib.SelectedItem;
            Persistent.Inicio = txtFecha.Value;
            Persistent.NroIIBB = txtNroIIBB.Text;
            Persistent.LogoEmpresaFileName = txtLogoEmpresa.Text;
            Persistent.VerReporte = chkVerReporte.Checked;
            Persistent.Percepciones = chkPercepciones.Checked;
            Persistent.MontoMinimoPerc = Convert.ToDouble(txtMontoMinimoPerc.Value);
            Persistent.PorcentajePerc = Convert.ToDouble(txtPorcentajePerc.Value);
            Persistent.Iva1 = (Ivas) cmbIva1.SelectedItem;
            Persistent.Iva2 = (Ivas) cmbIva2.SelectedItem;
            Persistent.UserUpd = SecurityManager.Instance.UsuarioActual;
            Persistent.LoginTicketFileName = txtLoginTicket.Text;
            Persistent.CertificadoFileName = txtCertificado.Text;
            Persistent.CertificadoDestinoFileName = txtCertificadoDestino.Text;
            Persistent.CertificadoPassword = txtCertificadoPassword.Text;
            Persistent.DNOrigen = txtDNOrigen.Text;
            Persistent.DNDestino = txtDNDestino.Text;
            Persistent.UltimaFacturaA = txtUltimaFacturaA.Text;
            Persistent.UltimaFacturaB = txtUltimaFacturaB.Text;
			Persistent.UltimaFacturaC = txtUltimaFacturaC.Text;
			Persistent.UltimaFacturaE = txtUltimaFacturaE.Text;
			Persistent.UltimaNotaCreditoA = txtUltimaNotaCreditoA.Text;
            Persistent.UltimaNotaCreditoB = txtUltimaNotaCreditoB.Text;
            Persistent.UltimaNotaCreditoC = txtUltimaNotaCreditoC.Text;
            Persistent.UltimaNotaDebitoA = txtUltimaNotaDebitoA.Text;
            Persistent.UltimaNotaDebitoB = txtUltimaNotaDebitoB.Text;
            Persistent.UltimaNotaDebitoC = txtUltimaNotaDebitoC.Text;
            Persistent.SenderName = txtSenderName.Text;
			Persistent.PuntoDeVenta = Convert.ToInt32(nudPtoVenta.Value);
            base.FillObject();
        }

        public override void SetPersistentChanged()
        {
            persistentChanged =
            !(
            ((Persistent.RazonSocial == null) ? "" : Persistent.RazonSocial) == txtRazonSocial.Text &&
            ((Persistent.Direccion == null) ? "" : Persistent.Direccion) == txtDireccion.Text &&
            ((Persistent.CodigoPostal == null) ? "" : Persistent.CodigoPostal) == txtCodigoPostal.Text &&
            ((Persistent.Telefono == null) ? "" : Persistent.Telefono) == txtTelefono.Text &&
            ((Persistent.Email == null) ? "" : Persistent.Email) == txtEmail.Text &&
            ((Persistent.SitioWeb == null) ? "" : Persistent.SitioWeb) == txtSitioWeb.Text &&
            ((Persistent.Cuit == null) ? txtCUIT.MaskedTextProvider.ToString() : Persistent.Cuit) == txtCUIT.Text &&
            //Persistent.TipoContribuyente == (TiposContribuyentes)dcTipoContribuyente.Selected &&
			Persistent.TipoContribuyente == (TiposContribuyentes)cmbTipoContrib.SelectedItem &&
            Persistent.Inicio == txtFecha.Value &&
            ((Persistent.NroIIBB == null) ? "" : Persistent.NroIIBB) == txtNroIIBB.Text &&
            ((Persistent.LogoEmpresaFileName == null) ? "" : Persistent.LogoEmpresaFileName) == txtLogoEmpresa.Text &&
            Persistent.VerReporte == chkVerReporte.Checked &&
            Persistent.Percepciones == chkPercepciones.Checked &&
            Persistent.MontoMinimoPerc == Convert.ToDouble(txtMontoMinimoPerc.Value) &&
            Persistent.PorcentajePerc == Convert.ToDouble(txtPorcentajePerc.Value) &&
            Persistent.Iva1 == (Ivas)cmbIva1.SelectedItem &&
            Persistent.Iva2 == (Ivas)cmbIva2.SelectedItem &&
            ((Persistent.LoginTicketFileName == null) ? "" : Persistent.LoginTicketFileName) == txtLoginTicket.Text &&
            ((Persistent.CertificadoFileName == null) ? "" : Persistent.CertificadoFileName) == txtCertificado.Text &&
            ((Persistent.CertificadoDestinoFileName == null) ? "" : Persistent.CertificadoDestinoFileName) == txtCertificadoDestino.Text &&
            ((Persistent.CertificadoPassword == null) ? "" : Persistent.CertificadoPassword) == txtCertificadoPassword.Text &&
            ((Persistent.DNOrigen == null) ? "" : Persistent.DNOrigen) == txtDNOrigen.Text &&
            ((Persistent.DNDestino == null) ? "" : Persistent.DNDestino) == txtDNDestino.Text &&
            ((Persistent.UltimaFacturaA == null) ? txtUltimaFacturaA.MaskedTextProvider.ToString() : Persistent.UltimaFacturaA) == txtUltimaFacturaA.Text &&
			((Persistent.UltimaFacturaB == null) ? txtUltimaFacturaB.MaskedTextProvider.ToString() : Persistent.UltimaFacturaB) == txtUltimaFacturaB.Text &&
			((Persistent.UltimaFacturaC == null) ? txtUltimaFacturaC.MaskedTextProvider.ToString() : Persistent.UltimaFacturaC) == txtUltimaFacturaC.Text &&
			((Persistent.UltimaNotaCreditoA == null) ? txtUltimaNotaCreditoA.MaskedTextProvider.ToString() : Persistent.UltimaNotaCreditoA) == txtUltimaNotaCreditoA.Text &&
			((Persistent.UltimaNotaCreditoB == null) ? txtUltimaNotaCreditoB.MaskedTextProvider.ToString() : Persistent.UltimaNotaCreditoB) == txtUltimaNotaCreditoB.Text &&
			((Persistent.UltimaNotaCreditoC == null) ? txtUltimaNotaCreditoC.MaskedTextProvider.ToString() : Persistent.UltimaNotaCreditoC) == txtUltimaNotaCreditoC.Text &&
			((Persistent.UltimaNotaDebitoA == null) ? txtUltimaNotaDebitoA.MaskedTextProvider.ToString() : Persistent.UltimaNotaDebitoA) == txtUltimaNotaDebitoA.Text &&
			((Persistent.UltimaNotaDebitoB == null) ? txtUltimaNotaDebitoB.MaskedTextProvider.ToString() : Persistent.UltimaNotaDebitoB) == txtUltimaNotaDebitoB.Text &&
			((Persistent.UltimaNotaDebitoC == null) ? txtUltimaNotaDebitoC.MaskedTextProvider.ToString() : Persistent.UltimaNotaDebitoC) == txtUltimaNotaDebitoC.Text &&
			((Persistent.SenderName == null) ? "" : Persistent.SenderName) == txtSenderName.Text &&
			((!Persistent.PuntoDeVenta.HasValue) ? 1 : Persistent.PuntoDeVenta.Value) == Convert.ToInt32(nudPtoVenta.Value)
            ); 
        }


        private void btnAccept_Click(object sender, EventArgs e) {
			ActualizarDNs();
			if (AcceptForm()) Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        protected override void RefreshControls() {
            base.RefreshControls();
            cmbIva1.DataSource = RequirePropertyValueList("Iva1");
            cmbIva2.DataSource = RequirePropertyValueList("Iva2");
			cmbTipoContrib.DataSource = RequirePropertyValueList("TipoContribuyente");
        }

        /*private void dcTipoContribuyente_Load(object sender, EventArgs e) {
            dcTipoContribuyente.DataType = typeof (TiposContribuyentes);
        }

        private void dcTipoContribuyente_BrowseClick(DataCombo dc, Type dataType) {
			dc.Text = "Inscripto";
			//RequireGridSel(dc, dataType);
			RequireGridSelFilter(dc, dataType, "Inscripto, Monotributo");
			
			
			int i = 0;
        }*/

        private void btnLogoEmpresa_Click(object sender, EventArgs e) {
            if (txtLogoEmpresa.Text != String.Empty)
                openFileDialog.FileName = txtLogoEmpresa.Text;

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName)) {
                txtLogoEmpresa.Text = openFileDialog.FileName;
                Persistent.LogoEmpresaFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.LogoEmpresa = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.LogoEmpresa, 0, Convert.ToInt32(fs.Length));
            }
        }

        private void btnLoginTicket_Click(object sender, EventArgs e) {
            if (txtLoginTicket.Text != String.Empty)
                openFileDialog.FileName = txtLoginTicket.Text;
			openFileDialog.AddExtension = true;
			openFileDialog.Filter = "XML Files (*.xml)|*.xml";

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName)) {
                txtLoginTicket.Text = openFileDialog.FileName;
                Persistent.LoginTicketFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.LoginTicket = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.LoginTicket, 0, Convert.ToInt32(fs.Length));
				fs.Close();
				ActualizarDNs();
            }
        }

        private void btnCertificado_Click(object sender, EventArgs e) {
            if (txtCertificado.Text != String.Empty)
                openFileDialog.FileName = txtCertificado.Text;
			openFileDialog.AddExtension = true;
			openFileDialog.Filter = "Certificado Origen (*.crt)|*.crt";

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName)) {
                txtCertificado.Text = openFileDialog.FileName;
                Persistent.CertificadoFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.Certificado = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.Certificado, 0, Convert.ToInt32(fs.Length));
            }
        }

        private void btnCertificadoDestino_Click(object sender, EventArgs e) {
            if (txtCertificadoDestino.Text != String.Empty)
                openFileDialog.FileName = txtCertificadoDestino.Text;
			openFileDialog.AddExtension = true;
			openFileDialog.Filter = "Certificado Destino (*.cer)|*.cer";

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName)) {
                txtCertificadoDestino.Text = openFileDialog.FileName;
                Persistent.CertificadoDestinoFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.CertificadoDestino = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.CertificadoDestino, 0, Convert.ToInt32(fs.Length));
            }
        }

        private void btnLoginTicket_Click_1(object sender, EventArgs e)
        {
            if (txtLoginTicket.Text != String.Empty)
                openFileDialog.FileName = txtLoginTicket.Text;

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName))
            {
                txtLoginTicket.Text = openFileDialog.FileName;
                Persistent.LoginTicketFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.LoginTicket = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.LoginTicket, 0, Convert.ToInt32(fs.Length));
            }
        }

        private void btnCertificado_Click_1(object sender, EventArgs e)
        {
            if (txtCertificado.Text != String.Empty)
                openFileDialog.FileName = txtCertificado.Text;

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName))
            {
                txtCertificado.Text = openFileDialog.FileName;
                Persistent.CertificadoFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.Certificado = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.Certificado, 0, Convert.ToInt32(fs.Length));
            }
        }

        private void btnCertificadoDestino_Click_1(object sender, EventArgs e)
        {
            if (txtCertificadoDestino.Text != String.Empty)
                openFileDialog.FileName = txtCertificadoDestino.Text;

            DialogResult result = openFileDialog.ShowDialog();
            if ((result == DialogResult.OK) && File.Exists(openFileDialog.FileName))
            {
                txtCertificadoDestino.Text = openFileDialog.FileName;
                Persistent.CertificadoDestinoFileName = openFileDialog.FileName;
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open);
                Persistent.CertificadoDestino = new byte[Convert.ToInt32(fs.Length)];
                fs.Read(Persistent.CertificadoDestino, 0, Convert.ToInt32(fs.Length));
            }
        }

		private void btnActualizarDN_Click(object sender, EventArgs e)
		{
			ActualizarDNs();
		}

		private void ActualizarDNs()
		{
			XmlDocument doc = new XmlDocument();
			try
			{
				//doc.Load(txtLoginTicket.Text);
				System.IO.FileStream fs1 = new System.IO.FileStream(txtLoginTicket.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

				using (StreamReader srXML = new StreamReader(fs1, System.Text.Encoding.Default))
				{
					doc.Load(srXML);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Problemas en la lectura '" + txtLoginTicket.Text + "'.\n" + ex.Message);
			}
			XmlNode source = doc.SelectSingleNode("//source");
			txtDNOrigen.Text = source.InnerText;
			XmlNode destination = doc.SelectSingleNode("//destination");
			string[] valuesDND = destination.InnerText.Split(",".ToCharArray());
			if(valuesDND.Length==1)
				valuesDND = destination.InnerText.Split(";".ToCharArray());
			string dest = "";
			if (valuesDND.Length == 4)
			{
				//CN
				dest += (valuesDND[0].Trim().ToUpper().StartsWith("CN=")) ? (valuesDND[0].Trim() + "; ") : string.Empty;
				dest += (valuesDND[1].Trim().ToUpper().StartsWith("CN=")) ? (valuesDND[1].Trim() + "; ") : string.Empty;
				dest += (valuesDND[2].Trim().ToUpper().StartsWith("CN=")) ? (valuesDND[2].Trim() + "; ") : string.Empty;
				dest += (valuesDND[3].Trim().ToUpper().StartsWith("CN=")) ? (valuesDND[3].Trim() + "; ") : string.Empty;
				//O
				dest += (valuesDND[0].Trim().ToUpper().StartsWith("O=")) ? (valuesDND[0].Trim() + "; ") : string.Empty;
				dest += (valuesDND[1].Trim().ToUpper().StartsWith("O=")) ? (valuesDND[1].Trim() + "; ") : string.Empty;
				dest += (valuesDND[2].Trim().ToUpper().StartsWith("O=")) ? (valuesDND[2].Trim() + "; ") : string.Empty;
				dest += (valuesDND[3].Trim().ToUpper().StartsWith("O=")) ? (valuesDND[3].Trim() + "; ") : string.Empty;
				//C
				dest += (valuesDND[0].Trim().ToUpper().StartsWith("C=")) ? (valuesDND[0].Trim() + "; ") : string.Empty;
				dest += (valuesDND[1].Trim().ToUpper().StartsWith("C=")) ? (valuesDND[1].Trim() + "; ") : string.Empty;
				dest += (valuesDND[2].Trim().ToUpper().StartsWith("C=")) ? (valuesDND[2].Trim() + "; ") : string.Empty;
				dest += (valuesDND[3].Trim().ToUpper().StartsWith("C=")) ? (valuesDND[3].Trim() + "; ") : string.Empty;
				//serialNumber=
				dest += (valuesDND[0].Trim().ToUpper().StartsWith("SERIALNUMBER=")) ? (valuesDND[0].Trim()) : string.Empty;
				dest += (valuesDND[1].Trim().ToUpper().StartsWith("SERIALNUMBER=")) ? (valuesDND[1].Trim()) : string.Empty;
				dest += (valuesDND[2].Trim().ToUpper().StartsWith("SERIALNUMBER=")) ? (valuesDND[2].Trim()) : string.Empty;
				dest += (valuesDND[3].Trim().ToUpper().StartsWith("SERIALNUMBER=")) ? (valuesDND[3].Trim()) : string.Empty;

			}
			txtDNDestino.Text = dest;
			toolTipDNO.SetToolTip(txtDNOrigen, txtDNOrigen.Text);
			toolTipDND.SetToolTip(txtDNDestino, txtDNDestino.Text);
		}


		
    }
}