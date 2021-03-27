using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MFDService;
using System.Xml;
//using TestMFDService.ar.com.travelpay.www;
//using TestMFDService.LocalMFDWebService;

namespace TestMFDService
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		#region Service
		private void btnCAE_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			XmlDocument xmlEmpresa = new XmlDocument();
			xmlEmpresa.Load(txtXmlEmpresa.Text);
			XmlDocument xmlComprobante = new XmlDocument();
			xmlComprobante.Load(txtXmlComprobante.Text);
			
			string error, nroComprobante, cae;
			
			long idDate = DateTime.Now.Year * 10000000000;
			idDate += DateTime.Now.Month * 100000000;
			idDate += DateTime.Now.Day * 1000000;
			idDate += DateTime.Now.Hour * 10000;
			idDate += DateTime.Now.Minute * 100;
			idDate += DateTime.Now.Second;
			long idCabeceraWS = idDate;
			txtCAE.Text = "";
			txtError.Text = "";
			txtNroComprobante.Text = "";

			//CaeCounter wsCaeCounter = new CaeCounter();
			//wsCaeCounter.SetCAEByCUIT("", "", "", 10); 
			cae = MFDService.MFDService.GetCAE(xmlEmpresa, xmlComprobante, out error, out nroComprobante, ref idCabeceraWS);
			

			txtCAE.Text = cae;
			txtError.Text = error;
			txtNroComprobante.Text = nroComprobante;
			Cursor.Current = Cursors.Default;
		}

		private void btnUltimoId_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			txtUltimoId.Text = "";
			txtUltimoId.Refresh();
			XmlDocument xmlEmpresa = new XmlDocument();
			xmlEmpresa.Load(txtXmlEmpresa.Text);
			long? ultimoId = MFDService.MFDService.GetUltimoId(xmlEmpresa);
			if (ultimoId.HasValue)
				txtUltimoId.Text = ultimoId.Value.ToString();
			else
				txtUltimoId.Text = "No se pudo obtener el último Id";
			Cursor.Current = Cursors.Default;

		}

		private void btnUltimoComprobante_Click(object sender, EventArgs e)
		{

			txtUltimoNroComp.Text = "";
			txtUltimoNroComp.Refresh(); 
			XmlDocument xmlEmpresa = new XmlDocument();
			xmlEmpresa.Load(txtXmlEmpresa.Text);
			XmlDocument xmlComprobante = new XmlDocument();
			xmlComprobante.Load(txtXmlComprobante.Text);
			int? ultimoNro = MFDService.MFDService.GetUltimoNroComprobante(xmlEmpresa, xmlComprobante);
			if (ultimoNro.HasValue)
				txtUltimoNroComp.Text = ultimoNro.Value.ToString();
			else
				txtUltimoId.Text = "No se pudo obtener el último Id";
		}
		#endregion Service

		#region WebService
		private void btnWebCAE_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				XmlDocument xmlEmpresa = new XmlDocument();
				xmlEmpresa.Load(txtWebXmlEmpresa.Text);
				XmlDocument xmlComprobante = new XmlDocument();
				xmlComprobante.Load(txtWebXmlComprobante.Text);

				string error, nroComprobante, cae;
				txtWebCAE.Text = "";
				txtWebError.Text = "";
				txtWebNroComprobante.Text = "";

				//TestMFDService.LocalMFDWebService.MFDWebService mfdWebService = new TestMFDService.LocalMFDWebService.MFDWebService();
				localhost.MFDWebService mfdWebService = new localhost.MFDWebService();
				localhost1.Service1 mfdWebService1 = new localhost1.Service1();
				mfdWebService1.Credentials = System.Net.CredentialCache.DefaultCredentials;
				
				
				//localhost.MFDWebService mfdWebService = new localhost.MFDWebService();
				mfdWebService.Credentials = System.Net.CredentialCache.DefaultCredentials;
				//mfdWebService.Timeout = 1000000;
				cae = mfdWebService1.GetCAE(xmlEmpresa, xmlComprobante, out error, out nroComprobante);
				//cae = mfdWebService.GetCAE(xmlEmpresa, xmlComprobante, out error, out nroComprobante);
				txtWebCAE.Text = cae;
				txtWebError.Text = error;
				txtWebNroComprobante.Text = nroComprobante;
			}
			catch (Exception ex) {
				txtWebError.Text = ex.Message;
			}
			Cursor.Current = Cursors.Default;
		}

		private void btnWebUltimoId_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			txtWebUltimoId.Text = "";
			txtWebUltimoId.Refresh();
			XmlDocument xmlEmpresa = new XmlDocument();
			xmlEmpresa.Load(txtWebXmlEmpresa.Text);
			//TestMFDService.LocalMFDWebService.MFDWebService mfdWebService = new TestMFDService.LocalMFDWebService.MFDWebService();
			localhost.MFDWebService mfdWebService = new localhost.MFDWebService();
			//mfdWebService.Credentials = System.Net.CredentialCache.DefaultCredentials;
			long? ultimoId = mfdWebService.GetUltimoId(xmlEmpresa);
			if (ultimoId.HasValue)
				txtWebUltimoId.Text = ultimoId.Value.ToString();
			else
				txtWebUltimoId.Text = "No se pudo obtener el último Id";
			Cursor.Current = Cursors.Default;

		}

		private void btnWebUltimoComprobante_Click(object sender, EventArgs e)
		{

			Cursor.Current = Cursors.WaitCursor;
			txtWebUltimoNroComp.Text = "";
			txtWebUltimoNroComp.Refresh();
			XmlDocument xmlEmpresa = new XmlDocument();
			xmlEmpresa.Load(txtWebXmlEmpresa.Text);
			XmlDocument xmlComprobante = new XmlDocument();
			xmlComprobante.Load(txtWebXmlComprobante.Text);
			localhost.MFDWebService mfdWebService = new localhost.MFDWebService();
			//TestMFDService.LocalMFDWebService.MFDWebService mfdWebService = new TestMFDService.LocalMFDWebService.MFDWebService();
			//mfdWebService.Credentials = System.Net.CredentialCache.DefaultCredentials;
			int? ultimoNro = mfdWebService.GetUltimoNroComprobante(xmlEmpresa, xmlComprobante);
			if (ultimoNro.HasValue)
				txtWebUltimoNroComp.Text = ultimoNro.Value.ToString();
			else
				txtWebUltimoId.Text = "No se pudo obtener el último Id";
			Cursor.Current = Cursors.Default;
		}

		#endregion WebService
	}
}
