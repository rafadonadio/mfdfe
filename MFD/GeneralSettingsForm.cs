using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using System.Collections;
using FrameWork.DataBusinessModel.DataModel;
using MFD.net.webservicex.www;

namespace MFD
{
    public partial class GeneralSettingsForm : Form
    {
        public event ObjectEvent SaveObject;
        public event GetObjectEvent GetObjectById;
        protected GeneralSettings setting;
        public event PropertyValueListNeeded PropertyValueListNeeded;

        public GeneralSettings Setting
        {
            get { return setting; }
            set { setting = value; }
        }
        
        public GeneralSettingsForm()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
			toolTip.SetToolTip(btnObtenerCotizacion, "Obtener cotización actual del dolar.");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
			Accept();
        }

		private void Accept()
		{
			FillObject();
			if (SaveObject != null)
				SaveObject(setting);
			Hide();
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide(); 
        }

        protected void FillObject()
        {
            Setting.CodigoCUIT =  txtCodigoCUIT.Text;
            Setting.CodigoMoneda = txtCodigoMoneda.Text;   
            Setting.IdEmpresaDefault = (cmbEmpresas.SelectedItem as Empresas).Id;
            Setting.FilesFolder = txtFilesFolder.Text;
            Setting.Email = txtEmail.Text;
            Setting.EmailSubject = txtEmailSubject.Text;
            Setting.EmailReclamos = txtEmailReclamos.Text;
			Setting.EmailTexto = txtEmailTexto.Text;
            Setting.SmtpServer = txtSmtpServer.Text;
            Setting.SmtpServerPort = Convert.ToInt32 (txtSmtpServerPort.Text);
            Setting.SmtpUser = txtSmtpUser.Text;
            Setting.SmtpPass = txtSmtpPass.Text;
            setting.SmtpSSLEnabled = chkSmtpSSLEnabled.Checked;
            Setting.FormatoComprobante = (FormatoComprobante) cmbFormatoComprobante.SelectedItem;
            Setting.NTPServer = txtNTPServer.Text;
            Setting.WSNegocio = txtWSNegocio.Text;
            Setting.WSPublicacion = txtWSPublicacion.Text;
			Setting.CotizacionUS = Convert.ToDouble(txtCotizacionUS.Text.Trim());

        }
		bool persistentChanged = false;
		public  void SetPersistentChanged()
		{
			persistentChanged =
			!(
				Setting.CodigoCUIT ==  txtCodigoCUIT.Text &&
				Setting.CodigoMoneda == txtCodigoMoneda.Text &&   
				Setting.IdEmpresaDefault == (cmbEmpresas.SelectedItem as Empresas).Id &&
				Setting.FilesFolder == txtFilesFolder.Text &&
				Setting.Email == txtEmail.Text &&
				Setting.EmailSubject == txtEmailSubject.Text &&
				Setting.EmailReclamos == txtEmailReclamos.Text &&
				Setting.EmailTexto == txtEmailTexto.Text &&
				Setting.SmtpServer == txtSmtpServer.Text &&
				Setting.SmtpServerPort == Convert.ToInt32 (txtSmtpServerPort.Text) &&
				Setting.SmtpUser == txtSmtpUser.Text &&
				Setting.SmtpPass == txtSmtpPass.Text &&
				setting.SmtpSSLEnabled == chkSmtpSSLEnabled.Checked &&
				Setting.FormatoComprobante == (FormatoComprobante) cmbFormatoComprobante.SelectedItem &&
				Setting.NTPServer == txtNTPServer.Text &&
				Setting.WSNegocio == txtWSNegocio.Text &&
				Setting.WSPublicacion == txtWSPublicacion.Text &&
				Setting.CotizacionUS == ((txtCotizacionUS.Text.Trim()=="")? 0.0 : Convert.ToDouble(txtCotizacionUS.Text.Trim()))
			);
		}


        protected void FillControls()
        {
            txtCodigoCUIT.Text = Setting.CodigoCUIT;
            txtCodigoMoneda.Text = Setting.CodigoMoneda;
            cmbEmpresas.SelectedItem = GetObjectById(Setting.IdEmpresaDefault, "Empresas");
            txtFilesFolder.Text = Setting.FilesFolder;
            txtEmail.Text = Setting.Email;
            txtEmailSubject.Text = Setting.EmailSubject;
            txtEmailReclamos.Text = Setting.EmailReclamos;
			txtEmailTexto.Text = Setting.EmailTexto; 
			txtSmtpServer.Text = Setting.SmtpServer;
            txtSmtpServerPort.Text = Setting.SmtpServerPort.ToString() ;
            txtSmtpUser.Text = Setting.SmtpUser;
            txtSmtpPass.Text = Setting.SmtpPass;
            chkSmtpSSLEnabled.Checked = setting.SmtpSSLEnabled;
            cmbFormatoComprobante.SelectedItem = Setting.FormatoComprobante;
            txtNTPServer.Text = Setting.NTPServer;
            txtWSNegocio.Text = Setting.WSNegocio;
            txtWSPublicacion.Text = Setting.WSPublicacion;
			txtCotizacionUS.Text = Setting.CotizacionUS.ToString();
        }

        public void Open() 
        {
            RefreshControls();
            
            Show();
			FillControls();
        }
        protected void RefreshControls()
        {
            cmbEmpresas.DataSource = PropertyValueListNeeded("EmpresaDefault",Setting);
            cmbFormatoComprobante.DataSource = PropertyValueListNeeded("FormatoComprobante", Setting);
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (txtFilesFolder.Text != String.Empty)
                folderBrowserDialog.SelectedPath = txtFilesFolder.Text;

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFilesFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

		private void GeneralSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SetPersistentChanged();
			if (persistentChanged)
			{
				switch (MessageBox.Show("¿Desea grabar antes de salir?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
				{
					case DialogResult.Yes:
						try
						{
							Accept();
						}
						catch
						{
							e.Cancel = true;
						}

						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
			//Close();
		}

		

		private void btnObtenerCotizacion_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			CurrencyConvertor currencyConvertor = new CurrencyConvertor();
			double convertion = currencyConvertor.ConversionRate(Currency.USD, Currency.ARS);
			txtCotizacionUS.Text = convertion.ToString();
			Cursor.Current = Cursors.Default;
		}

		private void txtCotizacionUS_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtCotizacionUS, "");
			if (txtCotizacionUS.Text.Contains(","))
				errorProvider1.SetError(txtCotizacionUS, "Valor inválido. Usar el '.' como punto decimal.");
			else
			{
				try
				{
					System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-us");
					double cotUS = Convert.ToDouble(txtCotizacionUS.Text, ci);
				}
				catch (Exception ex)
				{
					errorProvider1.SetError(txtCotizacionUS, "Valor inválido. Usar el '.' como punto decimal.");
				}
			}
		}
     }

    public delegate void NonObjectEvent();
    public delegate void ObjectEvent(object obj);
    public delegate Object GetObjectEvent(object obj, string objName);
    public delegate IList PropertyValueListNeeded(string propertyName, Settings persistentObject);

}