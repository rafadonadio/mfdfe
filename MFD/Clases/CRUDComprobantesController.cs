using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Collections;
using System.Configuration;
using BusinessLogic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Entities;
using FrameWork.CRUDModel.Windows;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.Tools.NTP;
//todo:sacar ws using MFD.ar.gov.afip.wswhomo;
using MFD.Clases.Adapters;
//todo:sacar ws using MFD.ar.gov.afip.wsaa;
using Reporting;
using Tools.XML.Generator;
using MFDService;
using System.Windows.Forms;

namespace MFD.Clases
{
	internal class CRUDComprobantesController : CRUDController
	{
		private LoginTicketsBL loginTicketsBL;
		private LoginTicketRequestsBL loginTicketRequestsBL;
		private ComprobantesBL comprobantesBL;
        private EmpresasBL empresasBL;

		public ComprobantesBL Comprobantes {
			get {return comprobantesBL ;}

			set { comprobantesBL = value;}
		}
		public EmpresasBL Empresas
		{
			get { return empresasBL; }

			set { empresasBL = value; }
		}
		public CRUDComprobantesController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
										  string gridTitle, string crudFormTitle, Type crudFormType)
			: base(businessLogic, gridTitle, crudFormTitle, crudFormType)
		{
			InitializeBusinessLogicObjects();
		}

		public CRUDComprobantesController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
										  string crudFormTitle, Type crudFormType)
			: base(businessLogic, crudFormTitle, crudFormType)
		{
			InitializeBusinessLogicObjects();
		}

		public CRUDComprobantesController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
										  string gridTitle, string crudFormTitle, Type crudFormType,
										  CRUDSelController parentController)
			: base(businessLogic, gridTitle, crudFormTitle, crudFormType, parentController)
		{
			InitializeBusinessLogicObjects();
		}

		public CRUDComprobantesController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
										  string gridTitle, string crudFormTitle, Type crudFormType,
										  CRUDSelController parentController, TiposComprobantesList tipo)
			: base(businessLogic, gridTitle, crudFormTitle, crudFormType, parentController)
		{
			InitializeBusinessLogicObjects();
		}

		private void InitializeBusinessLogicObjects()
		{
			loginTicketRequestsBL = new LoginTicketRequestsBL();
			loginTicketRequestsBL.SetParameters(businessLogic.DBConnection);

			loginTicketsBL = new LoginTicketsBL();
			loginTicketsBL.SetParameters(businessLogic.DBConnection);
		}

		protected override void AdditionalInitializeCRUDForm(ICRUDForm form)
		{
			base.AdditionalInitializeCRUDForm(form);
			(form as ComprobantesCRUD).EmitirComprobante += new ComprobanteObjectOutEvent(EmitirComprobante);
			(form as ComprobantesCRUD).AnularComprobante += new ComprobanteObjectEvent(AnularComprobante);
			(form as ComprobantesCRUD).ReenviarComprobante += new ComprobanteObjectEvent(ReenviarComprobante);
		}

		public X509Certificate2 GetSigner()
		{
			X509Store store = null;

			store = new X509Store(StoreName.My, StoreLocation.CurrentUser);

			// open store and show certificate picker
			store.Open(OpenFlags.ReadOnly);
			X509Certificate2Collection tempCollection =
				X509Certificate2UI.SelectFromCollection(store.Certificates, "Crypter",
														"Select a Certificate for Signing",
														X509SelectionFlag.SingleSelection);
			return new X509Certificate2("MFDsolutions.pfx", "diego");
			store.Close();

			if (tempCollection.Count == 1)
			{
				return tempCollection[0];
			}

			return null;
		}

		public string GetFolder(Comprobantes obj)
		{
			DirectoryInfo folderInfo = new DirectoryInfo(GeneralSettings.Instance.FilesFolder + @"\" + obj.Tipo.Nombre + @"\" + obj.NroCbante);
			if (!folderInfo.Exists)
			{
				folderInfo.Create();
			}
			return folderInfo.FullName + @"\";
		}

		IList form_PropertyValueListNeeded(string propertyName, FrameWork.DataBusinessModel.DataModel.Persistent persistentObject)
		{
			IList result = null;
			if (propertyName == "Empresa") result = empresasBL.GetDataSource();
			return result;
		}
		public void GenerarArchivoCabeceraPeriodo()
		{
			MesYEmpresa form = new MesYEmpresa();
			form.Exit += new MesYEmpresa.ExitMesYEmpresaEvent(EmitirCabecerasPeriodo);
			form.PropertyValueListNeeded += new FrameWork.CRUDModel.Windows.UI.PropertyValueListNeeded(form_PropertyValueListNeeded);
			form.Open("Generar Cabeceras AFIP");
		}

		public void GenerarArchivoDetallePeriodo()
		{
			MesYEmpresa form = new MesYEmpresa();
			form.Exit += new MesYEmpresa.ExitMesYEmpresaEvent(EmitirDetallesPeriodo);
			form.PropertyValueListNeeded += new FrameWork.CRUDModel.Windows.UI.PropertyValueListNeeded(form_PropertyValueListNeeded);
			form.Open("Generar Detalles AFIP");
		}
				
		private void EmitirCabecerasPeriodo(Empresas empresa, int anio, int mes)
		{
			String fileName = GetFolderCabeceras() + comprobantesBL.GetFileNameCabeceras(anio, mes);
			TextWriter tw = new StreamWriter(fileName, false, Encoding.Default);
			tw.Write(comprobantesBL.GetStreamCabeceras(empresa, anio, mes));
			tw.Close();
			tw.Dispose();
		}

		private void EmitirDetallesPeriodo(Empresas empresa, int anio, int mes)
		{
			String fileName = GetFolderDetalles() + comprobantesBL.GetFileNameDetalles(anio, mes);
			TextWriter tw = new StreamWriter(fileName, false, Encoding.Default);
			tw.Write(comprobantesBL.GetStreamDetalles(empresa, anio, mes));
			tw.Close();
			tw.Dispose();
		}
		
		private string GetFolderCabeceras()
		{
			DirectoryInfo folderInfo = new DirectoryInfo(GeneralSettings.Instance.FilesFolder + @"\CABECERAS");
			if (!folderInfo.Exists)
			{
				folderInfo.Create();
			}
			return folderInfo.FullName + @"\";
		}

		private string GetFolderDetalles()
		{
			DirectoryInfo folderInfo = new DirectoryInfo(GeneralSettings.Instance.FilesFolder + @"\DETALLES");
			if (!folderInfo.Exists)
			{
				folderInfo.Create();
			}
			return folderInfo.FullName + @"\";
		}

		private void GenerarArchivoCabecera(Comprobantes obj)
		{
			string filename = GetFolder(obj) + obj.GetFileNameCabecera();
			TextWriter tw = new StreamWriter(filename, false, Encoding.Default);
			tw.Write((businessLogic as ComprobantesBL).GetStreamUnComprobante(obj));
			tw.Close();
		}

		private void GenerarArchivoDetalle(Comprobantes obj)
		{
			string filename = GetFolder(obj) + obj.GetFileNameDetalle();
			TextWriter tw = new StreamWriter(filename, false, Encoding.Default);
			tw.Write((businessLogic as ComprobantesBL).GetStreamDetalle(obj));
			tw.Close();
		}

		private ExportFormatType FormatoExportacionComprobante(FormatoComprobante formato)
		{
			ExportFormatType result = ExportFormatType.RichText;
			switch (formato)
			{
				case FormatoComprobante.HTML:
					result = ExportFormatType.HTML40;
					break;
				case FormatoComprobante.PDF:
					result = ExportFormatType.PortableDocFormat;
					break;
				case FormatoComprobante.RTF:
					result = ExportFormatType.RichText;
					break;
				case FormatoComprobante.XML:
					result = ExportFormatType.NoFormat;
					break;
			}
			return result;
		}

		private ReportDocument GenerarReporteDetalle(Comprobantes obj, Boolean show, string filename)
		{
			ReportDocument report = ReportManager.GetReportDetalleComprobantes(businessLogic as ComprobantesBL, obj);
			ExportFormatType formatType= FormatoExportacionComprobante(GeneralSettings.Instance.FormatoComprobante);
			if (formatType != ExportFormatType.NoFormat)
			{ report.ExportToDisk(formatType, filename); }
			else { GenerarXML(obj); }
			if (obj.VerReporte) new ReportViewer().Open(report);
			return report;
		}

		private void EnviarComprobante(Comprobantes obj, bool show)
		{
			try
			{
				string homologacion = "", validezLegal = "";
				if (ConfigurationManager.AppSettings["FlagEnvir"] == "0")
				{
					homologacion = "HOMOLOGACIÓN";
					validezLegal = " TENGA PRESENTE QUE EL COMPROBANTE QUE SE ADJUNTA ES SOLO DE PRUEBA Y EL MISMO NO POSEE VALIDEZ LEGAL";
				}

				string filename = GetFolder(obj) + obj.GetFileName(GeneralSettings.Instance.FormatoComprobante.ToString().ToLower().Substring(0, 3));

				if (!File.Exists(filename))
					GenerarReporteDetalle(obj, show, filename);

				SmtpClient client = new SmtpClient(GeneralSettings.Instance.SmtpServer, GeneralSettings.Instance.SmtpServerPort);
				client.Credentials = new System.Net.NetworkCredential(GeneralSettings.Instance.SmtpUser, GeneralSettings.Instance.SmtpPass);

				MailAddress from = new MailAddress(GeneralSettings.Instance.SmtpUser, "Factura electronica de " + obj.Empresa.RazonSocial, System.Text.Encoding.UTF8);
                //MailAddress from = new MailAddress(GeneralSettings.Instance.SmtpUser, "Factura electronica " + ((homologacion != "") ? ("(" + homologacion + ") ") : ("")) + obj.Empresa.RazonSocial, System.Text.Encoding.UTF8);
				MailAddress to = new MailAddress(obj.Cliente.Email);
				MailMessage message = new MailMessage(from, to);
				message.BodyEncoding = System.Text.Encoding.UTF8;
				message.Subject = GeneralSettings.Instance.EmailSubject;
				message.SubjectEncoding = System.Text.Encoding.UTF8;
				string userState = "Fact elect";
				//if (GeneralSettings.Instance.FormatoComprobante == FormatoComprobante.HTML) {
				//    string body = GenerarBodyHTML(filename, obj.GetFileNameDetalle());
				//    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
				//    //create the LinkedResource (embedded image)
				//    LinkedResource logo = new LinkedResource(obj.Empresa.LogoEmpresaFileName);
				//    logo.ContentId = "logo";
				//    //add the LinkedResource to the appropriate view
				//    htmlView.LinkedResources.Add(logo);
				//    //add the views
				//    message.AlternateViews.Add(htmlView);
				//}
				message.Attachments.Add(new Attachment(filename));
				ExportFormatType formatType = FormatoExportacionComprobante(GeneralSettings.Instance.FormatoComprobante);
				if (formatType == ExportFormatType.NoFormat)
				{
					string filenameXSL = AppDomain.CurrentDomain.BaseDirectory + "Factura_v1.22.xsl";
					message.Attachments.Add(new Attachment(filenameXSL));
				}		
				//message.Body = ("Ha recibido una factura electrónica de " + obj.Empresa.RazonSocial + ", por favor compruebe que la ha recepcionado correctamente, en caso de no ser así sepa disculpar y contactese con la empresa." + "La informacion contenida en el documento adjunto es de indole estrictamente confidencial.");
				message.Body = GeneralSettings.Instance.EmailTexto;
                message.Headers.Add("Disposition-Notification-To", GeneralSettings.Instance.SmtpUser);

				try
				{
					client.SendAsync(message, userState);
				}
				catch (Exception ex)
				{
					string err = ex.Message;
					throw ex;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private string GenerarBodyHTML(string path, string filename)
		{
			string body = "";
			using (StreamReader srFactura = new StreamReader(path, System.Text.Encoding.Default))
			{
				body = srFactura.ReadToEnd();
			}
			int posSrc = 0;
			string prefixSrc = "images/" + System.Web.HttpUtility.UrlPathEncode(filename.Substring(0, filename.Length - 4));
			posSrc = body.IndexOf(prefixSrc);
			string valorARemplazar = body.Substring(posSrc, prefixSrc.Length + 41);
			body = body.Replace(valorARemplazar, "cid:logo");
			return body;
		}
		//private
		public string EmitirComprobante(Comprobantes obj, out string nroComprobante, bool generarXML)
		{
			nroComprobante = "-1";
			
			//Generación de otro ID
			long idDate = DateTime.Now.Year * 10000000000;
			idDate += DateTime.Now.Month * 100000000;
			idDate += DateTime.Now.Day * 1000000;
			idDate += DateTime.Now.Hour * 10000;
			idDate += DateTime.Now.Minute * 100;
			idDate += DateTime.Now.Second;
			long idCabeceraWS = idDate;

			/*if (Status.ChequearConexion())
			{*/
				if (((MFD.Main)(CRUDFormParent)).IsValidLicense())
				{
					try
					{

						string errorLog;
						//Reemplazado en MFDService
						//obj.CAE = GetCAE(obj, out nroComprobante);
						string result = MFDService.MFDService.GetCAE(obj, out errorLog, out nroComprobante, ref idCabeceraWS, loginTicketsBL, loginTicketRequestsBL, true);
						//string result = "";
						obj.NroCbante = nroComprobante;
						obj.IdCabeceraWS = idCabeceraWS;

						if (obj.CAE != "NULL" && nroComprobante != "-1")
						{
							obj.CAE = result;
							obj.Emitir();
							((MFD.Main)(CRUDFormParent)).StatusConn.Image = global::MFD.Properties.Resources.green;
							((MFD.Main)(CRUDFormParent)).StatusWS.Image = global::MFD.Properties.Resources.green;
						}
						else
						{
							nroComprobante = "-1";
							obj.NroCbante = "-1";
							string error = "No se pudo obtener el CAE. CAE='NULL'.\nPara más información revisar el eventLog en la vista MFD";
							Logger.EscribirEventLog(error + Environment.NewLine + result);
							return error;
						}

					}
					catch (Exception ex)
					{
						nroComprobante = "-1";
						Logger.EscribirEventLog(ex);
						return "No se pudo obtener el CAE. " + ex.Message;
					}

					try
					{
						//En estos momentos no se esta utilizando el check de Generar xml desde el formulario del comprobante
						if (obj.GenerarXml)
						{
							GenerarXML(obj);
						}
					}
					catch (Exception ex)
					{
						Logger.EscribirEventLog(ex);
						return "No se pudo generar el archivo xml correspondiente al comprobante";
					}
					try
					{
						EnviarComprobante(obj, obj.VerReporte);//true;
					}
					catch (Exception ex)
					{
						Logger.EscribirEventLog(ex);
						return "No se pudo enviar el comprobante a la cuenta de email del cliente";
					}
					//	return string.Empty;
				}
				else
				{
					MessageBox.Show("Su licencia a expirado.");
					Application.Exit();

				}
			/*}
			else {
				string error = "No se puede emitir el comprobante porque no hay conexión a internet.";
				Logger.EscribirEventLog(error);
				return error;
				//MessageBox.Show();
			}*/
			return string.Empty;
		}

		private string ArmarNroString(string nroAnterior, int nroWSA)
		{
			string[] partes = nroAnterior.Split(new char[] { '-' });
			nroWSA++;
			return partes[0] + "-" + nroWSA.ToString().PadLeft(8, '0');

		}

		private void GenerarXML(Comprobantes obj)
		{
			string filename = GetFolder(obj) + obj.GetFileName("xml");

			XmlTextWriter writer = new XmlTextWriter(filename, Encoding.GetEncoding("iso-8859-1")); //Encoding.UTF8
			writer.Formatting = Formatting.Indented;
			XmlDocument factura = new ComprobantesAdapter(obj).GenerarXml();
			factura.WriteTo(writer);
			writer.Flush();
			writer.Close();
			if (!File.Exists(GetFolder(obj) + "Factura_v1.22.xsl"))
			{
				File.Copy(AppDomain.CurrentDomain.BaseDirectory + "Factura_v1.22.xsl", GetFolder(obj) + "Factura_v1.22.xsl");
			}
		}

		private string AnularComprobante(Comprobantes obj)
		{
			obj.Anular();
			try
			{
				EnviarComprobante(obj, obj.VerReporte);//true;
			}
			catch (Exception ex)
			{
				Logger.EscribirEventLog(ex);
				return "No se pudo enviar el comprobante a la cuenta de email del cliente";
			}
			return "";
		}

		//private string ConectaraWSAA(Comprobantes obj)
		//{
		//    if ((obj.Empresa.LoginTicket == null) || (obj.Empresa.Certificado == null))
		//    {
		//        Logger.EscribirEventLog("No se pueden encontrar los archivos del certificado digital");
		//        return "No se pueden encontrar los archivos del certificado digital";
		//    }
		//    try
		//    {
		//        X509Certificate2 certOrigen = new X509Certificate2(obj.Empresa.Certificado, obj.Empresa.CertificadoPassword);
		//        byte[] LoginTicketCMS = Sign(obj.Empresa.LoginTicket, certOrigen);

		//        X509Certificate2 certDestino = new X509Certificate2(obj.Empresa.CertificadoDestino);
		//        byte[] encryptedTicket = Encrypt(LoginTicketCMS, certDestino);

		//        string ticket = Convert.ToBase64String(encryptedTicket);
		//        LoginCMSService loginService = new LoginCMSService();
		//        loginService.loginCms(ticket);
		//    }
		//    catch (Exception ex)
		//    {
		//        Logger.EscribirEventLog(ex);
		//        return "No se pudo Firmar Digitalmente el comprobante.";
		//    }

		//    return "";

		//    //X509Certificate2 cert = new X509Certificate2(obj.Empresa.Certificado);
		//    //CmsSigner sig = new CmsSigner(cert);
		//    //SignedCms cms = new SignedCms(new ContentInfo());
		//    //cms.ComputeSignature(sig);
		//    //byte[] LoginTicketCMS = cms.Encode();


		//    ////string filename;
		//    ////string folder = "";
		//    ////string str = (businessLogic as ComprobantesBL).GetStream(obj as Comprobantes);

		//    ////DirectoryInfo folderInfo = new DirectoryInfo(GeneralSettings.Instance.FilesFolder);
		//    ////if (folderInfo.Exists)
		//    ////    folder = GeneralSettings.Instance.FilesFolder + @"\";


		//    ////filename = folder + "CABECERA_200703_" + (obj as Comprobantes).NroCbante + ".TXT";
		//    ////TextWriter tw = new StreamWriter(filename);
		//    ////tw.Write(str);
		//    ////tw.Close();


		//    ////str = (businessLogic as ComprobantesBL).GetStreamDetalle(obj as Comprobantes);

		//    ////filename = folder + "DETALLE_200703_" + (obj as Comprobantes).NroCbante + ".TXT";
		//    ////tw = new StreamWriter(filename);
		//    ////tw.Write(str);
		//    ////tw.Close();
		//}

		#region WebService de Autorizacion (WSAA)
		#region Reemplazado en MFDService
		//private LoginTickets GetLoginTicket(Empresas empresa)
		//{
		//    LoginTickets result = loginTicketsBL.GetCurrentLoginTicket(empresa);

		//    if (result == null)
		//    {
		//        //Sincronización de reloj por NTP
		//        NTPClient ntp = new NTPClient(GeneralSettings.Instance.NTPServer);
		//        ntp.Connect(true);

		//        //Generacion del Ticket de Requerimiento de Acceso
		//        LoginTicketRequests loginTicketRequest = loginTicketRequestsBL.GenerateLoginTicket(empresa);
		//        XmlDocument xmlDocument = loginTicketRequestsBL.GenerateLoginTicketRequestXML(loginTicketRequest);
		//        // Conversion del XML a bytes
		//        StringWriter sw = new StringWriter();
		//        xmlDocument.WriteTo(new XmlTextWriter(sw));
		//        byte[] loginTicketRequestXml = new ASCIIEncoding().GetBytes(sw.ToString());

		//        //Firma del Ticket de Requerimiento de Acceso
		//        X509Certificate2 certOrigen = GetSenderCertificate(empresa);
		//        byte[] loginTicketRequestCMS = Sign(loginTicketRequestXml, certOrigen);

		//        ////Empaquetado de Ticket de Requerimiento de Acceso en un mensaje CMS
		//        //X509Certificate2 certDestino = new X509Certificate2(empresa.CertificadoDestino);
		//        //certDestino = GetRecipientCert();
		//        //byte[] encryptedTicket = Encrypt(loginTicketRequestCMS, certDestino);

		//        //Codificacion a base 64
		//        //string loginTicketRequestBase64 = Convert.ToBase64String(encryptedTicket);
		//        string loginTicketRequestBase64 = Convert.ToBase64String(loginTicketRequestCMS);

		//        //Transmisión del Ticket de Requerimiento de Acceso al WSAA
		//        LoginCMSService loginService = new LoginCMSService();
		//        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
		//        string loginServiceResponse = loginService.loginCms(loginTicketRequestBase64);

		//        //Extracción del Ticket de Acceso devuelto por el WSAA
		//        XmlDocument loginTicketXml = new XmlDocument();
		//        loginTicketXml.LoadXml(loginServiceResponse);
		//        result = loginTicketsBL.GetLoginTicketFromXML(loginTicketXml, loginTicketRequest);
		//    }
		//    return result;
		//}
		#endregion Reemplazado en MFDService

		static public X509Certificate2 GetSenderCertificate(Empresas empresa)
		{
			if (String.IsNullOrEmpty(empresa.SenderName))
			{
				string error = "Error en GetSenderCertificate: Es necesario configurar el Sender Name, en parametros empresas.";
				Logger.EscribirEventLog(error);
				throw new Exception(error);
			}
			String senderName = empresa.SenderName;//"MFD Solutions"
			//  Open the AddressBook local user X509 certificate store.
			X509Store storeAddressBook = new X509Store(StoreName.My, StoreLocation.CurrentUser);
			storeAddressBook.Open(OpenFlags.ReadOnly);

			X509Certificate2 result = storeAddressBook.Certificates[0];
			X509Certificate2Collection certColl = storeAddressBook.Certificates.Find(X509FindType.FindBySubjectName, senderName, false);

			//  Check to see if the certificate suggested by the example
			//  requirements is not present.
			if (certColl.Count > 0) result = certColl[0];
			storeAddressBook.Close();

			return result;
		}

		static public X509Certificate2 GetRecipientCertificate()
		{
			const String recipientName = "wsaa.afip.gov.ar";
			//  Open the AddressBook local user X509 certificate store.
			X509Store storeAddressBook = new X509Store(StoreName.AddressBook, StoreLocation.CurrentUser);
			storeAddressBook.Open(OpenFlags.ReadOnly);

			X509Certificate2 result = storeAddressBook.Certificates[0];
			X509Certificate2Collection certColl = storeAddressBook.Certificates.Find(
				X509FindType.FindBySubjectName, recipientName, false);

			//  Check to see if the certificate suggested by the example
			//  requirements is not present.
			if (certColl.Count > 0) result = certColl[0];

			storeAddressBook.Close();

			return result;
		}


		private byte[] Sign(byte[] data, X509Certificate2 signingCert)
		{
			// create ContentInfo
			ContentInfo content = new ContentInfo(data);

			// SignedCms represents signed data
			SignedCms signedMessage = new SignedCms(content);

			// create a signer
			CmsSigner signer = new CmsSigner(signingCert);

			// sign the data
			signedMessage.ComputeSignature(signer);

			// create PKCS #7 byte array
			byte[] signedBytes = signedMessage.Encode();

			// return signed data
			return signedBytes;
		}

		private byte[] Encrypt(byte[] data, X509Certificate2 encryptingCert)
		{
			// create ContentInfo
			ContentInfo plainContent = new ContentInfo(data);

			// EnvelopedCms represents encrypted data
			EnvelopedCms encryptedData = new EnvelopedCms(plainContent);

			// add a recipient
			CmsRecipient recipient = new CmsRecipient(SubjectIdentifierType.IssuerAndSerialNumber, encryptingCert);

			// encrypt data with public key of recipient
			encryptedData.Encrypt(recipient);

			// create PKCS #7 byte array
			byte[] encryptedBytes = encryptedData.Encode();

			// return encrypted data
			return encryptedBytes;
		}

		protected string FakeLoginCMS(string loginTicketRequestBase64)
		{
			string result = null;
			EnvelopedCms encriptedData = new EnvelopedCms();
			encriptedData.Decode(Convert.FromBase64String(loginTicketRequestBase64));
			SignedCms signedCms = new SignedCms();
			signedCms.Decode(encriptedData.ContentInfo.Content);
			string xml = new ASCIIEncoding().GetString(signedCms.ContentInfo.Content);

			return result;
		}

		#endregion
		
		#region Reemplazado en MFDService
		//#region WebService de Requerimiento de CAE (FEAutRequest)
		//protected string GetCAE(Comprobantes comprobante, out string nroComprobante)
		//{
		//    string result = String.Empty;
		//    LoginTickets loginTicket = GetLoginTicket(comprobante.Empresa);
		//    nroComprobante = "-1";
		//    if (loginTicket != null)
		//    {
		//        FEAuthRequest authRequest = new FEAuthRequest();
		//        authRequest.Token = loginTicket.Token;
		//        authRequest.Sign = loginTicket.Sign;
		//        authRequest.cuit = Convert.ToInt64(comprobante.Empresa.Cuit.Replace("-", ""));
		//        ComprobantesAdapter adapter = new ComprobantesAdapter(comprobante);
		//        FERequest request = adapter.GenerarFERequest(comprobante.Id);
		//        Service service = new Service();
		//        FEResponse response = service.FEAutRequest(authRequest, request);

		//        if (response.FedResp != null && response.FedResp[0].resultado == "R" && response.FedResp[0].motivo.StartsWith("11") && response.FedResp[0].cae == "NULL")
		//        {
		//            //Caso en que falla por correlatividad de comprobantes
		//            FERecuperaLastCMPResponse ultimoComEmitido = service.FERecuperaLastCMPRequest(authRequest, adapter.GenerarFELastCMPtype());
		//            comprobante.NroCbante = comprobante.NroCbante.Substring(0, 5) + (ultimoComEmitido.cbte_nro + 1).ToString().PadLeft(8, '0');
		//            adapter = new ComprobantesAdapter(comprobante);
		//            request = new FERequest();
		//            //Generación de otro ID
		//            long idDate = DateTime.Now.Year * 10000000000;
		//            idDate += DateTime.Now.Month * 100000000;
		//            idDate += DateTime.Now.Day * 1000000;
		//            idDate += DateTime.Now.Hour * 10000;
		//            idDate += DateTime.Now.Minute * 100;
		//            idDate += DateTime.Now.Second;
		//            request = adapter.GenerarFERequest(idDate);
		//            service = new Service();
		//            response = service.FEAutRequest(authRequest, request);
		//        }
		//        else
		//        {
		//            if (response.FedResp != null && response.FedResp[0].resultado == "R" && !String.IsNullOrEmpty(response.FedResp[0].motivo))
		//            {
		//                ArrayList motivos = new ArrayList();
		//                motivos.AddRange(response.FedResp[0].motivo.Split(";".ToCharArray()));
		//                StringBuilder logMotivos = new StringBuilder();
		//                if (motivos.Contains("01")) logMotivos.Append("01 \"La cuit informada no corresponde a un responsable inscripto en el iva activo\\n");
		//                if (motivos.Contains("02")) logMotivos.Append("02 \"La cuit informada no se encuentra autorizada a emitir comprobantes electronicos originales o el periodo de inicio autorizado es posterior al de la generacion de la solicitud\"\n");
		//                if (motivos.Contains("03")) logMotivos.Append("03 \"La cuit informada registra inconvenientes con el domicilio fiscal\"\n");
		//                if (motivos.Contains("04")) logMotivos.Append("04 \"El punto de venta informado no se encuentra declarado para ser utilizado en el presente regimen\"\n");
		//                if (motivos.Contains("05")) logMotivos.Append("05 \"La fecha del comprobante indicada no puede ser anterior en mas de cinco dias, si se trata de una venta, o anterior o posterior en mas de diez dias, si se trata de una prestacion de servicios, consecutivos de la fecha de remision del archivo art. 22 De la rg nro 2177-\"\n");
		//                if (motivos.Contains("06")) logMotivos.Append("06 \"La cuit informada no se encuentra autorizada a emitir comprobantes clase \"a\"\"\n");
		//                if (motivos.Contains("07")) logMotivos.Append("07 \"Para la clase de comprobante solicitado -comprobante clase a- debera consignar en el campo codigo de documento identificatorio del comprador el codigo \"80\"\n");
		//                if (motivos.Contains("08")) logMotivos.Append("08 \"La cuit indicada en el campo nro de identificacion del comprador es invalida\"\n");
		//                if (motivos.Contains("09")) logMotivos.Append("09 \"La cuit indicada en el campo nro de identificacion del comprador no existe en el padron unico de contribuyentes\"\n");
		//                if (motivos.Contains("10")) logMotivos.Append("10 \"La cuit indicada en el campo nro de identificacion del comprador no corresponde a un responsable inscripto en el iva activo\"\n");
		//                if (motivos.Contains("11")) logMotivos.Append("11 \"El nro de comprobante desde informado no es correlativo al ultimo nro de comprobante registrado/hasta solicitado para ese tipo de comprobante y punto de venta\"\n");
		//                if (motivos.Contains("12")) logMotivos.Append("12 \"El rango informado se encuentra autorizado con anterioridad para la misma cuit, tipo de comprobante y punto de venta\"\n");
		//                if (motivos.Contains("13")) logMotivos.Append("13 \"La cuit indicada se encuentra comprendida en el regimen establecido por la resolucion general nro 2177 y/o en el titulo I de la resolucion general nro 1361 art. 24 De la rg nro 2177\"\n");
		//                if (logMotivos.Length > 0) {
		//                    Logger.EscribirEventLog(logMotivos.ToString());
		//                }
		//            }
		//        }
		//        nroComprobante = comprobante.NroCbante;
		//        try
		//        {
		//            result = response.FedResp[0].cae;
		//        }
		//        catch (Exception ex)
		//        {
		//            nroComprobante = "-1";
		//            result = ex.Message;
		//        }
		//    }
		//    return result;
		//}
		//#endregion
		#endregion


		private string ReenviarComprobante(Comprobantes obj)
		{
			try
			{
				EnviarComprobante(obj, false);
			}
			catch (Exception)
			{
				return "No se pudo enviar el comprobante a la cuenta de email del cliente";
			}
			return string.Empty;
		}

		public static bool ValidateServerCertificate(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			//TODO: creo que debería validar que el certificado sea el de la AFIP
			return true;
		}
	}

}