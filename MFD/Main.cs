using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using BusinessLogic;
using Entities;
using FrameWork.CRUDModel.Windows;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel;
using Janus.Windows.ButtonBar;
using MFD.Clases;

using Reporting;
using Kings.KCHFtp;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MFD
{


	public partial class Main : Form
	{
		public const string FTPHost = "ftp.mfdsolutions.com.ar";
		public const int FTPPort = 21;
		public const string FTPName = "system@mfdsolutions.com.ar";
		public const string FTPPass = "43710182";
		public const int FTPTimeOut = 3000;
		public string empresaRazonSocial = "";


		private DBase db;
		private GeneralSettingsController genSettingsController;
		private FTPSettingsController ftpSettingsController;
		private GeneralSettingsBKPController genSettingsBKPController;
		private GeneralSettingsImportController genSettingsImportController;
		public RepeticionesController repeticionesController;

		public DialogResult showDialog;

		public void EnvioFTP()
		{
			EmpresasBL empBL = new EmpresasBL();
			empBL.SetParameters(db);
			ComprobantesBL compBL = new ComprobantesBL();
			compBL.SetParameters(db);

			Empresas empresa =  empBL.GetObject(GeneralSettings.Instance.IdEmpresaDefault) as Empresas;
			if (empresa != null)
			{
				Ftp FtpClient = new Ftp();
				FtpClient.HostAddress = FTPHost;
				FtpClient.Port = FTPPort;
				FtpClient.Username = FTPName;
				FtpClient.Password = FTPPass;
				FtpClient.Timeout = FTPTimeOut;
				FtpClient.Connect();
				
				string fileName = empresa.Cuit + "_" + DateTime.Now.ToString("yyyyMMdd_hhmm") + ".txt";
				StreamWriter tw = File.CreateText(fileName);

				FtpClient.MoveDirectory(empresa.Cuit);
				int cantidadEmitidos = 0;
				foreach (Comprobantes comp in compBL.GetDataSource())
				{
					if (comp.IsEmitido)
					{
						tw.Write(compBL.GetResumeStream(comp));
						cantidadEmitidos++;
					}
				}
				tw.Write("Cantidad de facturas emitidas: " + cantidadEmitidos.ToString() + "\r\n");
				tw.Close();

				FtpClient.PutFile(fileName);
				FtpClient.Quit();

				File.Delete(fileName);
			}
		}
		Splash frmSplash = new Splash();

		public Main()
		{
			frmSplash.Show();
			frmSplash.Refresh();
			//ByMFD: se agrego la linea de abajo.
			Application.EnableVisualStyles();
			string[] dbs = { "Entities", "CRUDModel" };
			InitializeComponent();
			db = new DBase(dbs);
			toolTipConn.SetToolTip(statusConn, "Estado conexión");
			toolTipAFIP.SetToolTip(statusWS, "Estado ws AFIP");

			CRUDControllerManager.Instance.SetCRUDChildControllerManager(new CRUDChildControllerManager());
			CRUDControllerManager.Instance.SetCRUDSecurityManager(SecurityManager.Instance);
			FormUtils.Instance.SetMainForm(this);
			FormUtils.Instance.SetGridLayoutManager(GridLayoutManager.Instance);
			SecurityManager.Instance.SetParameters(db);
			genSettingsController = new GeneralSettingsController(new GeneralSettingsBL(db));
			genSettingsBKPController = new GeneralSettingsBKPController(new GeneralSettingsBL(db));
			genSettingsImportController = new GeneralSettingsImportController(new GeneralSettingsBL(db));
			ftpSettingsController = new FTPSettingsController(new SettingsBL(db));
			GenerarRepeticiones();
			frmSplash.Hide();

		}

		private void GenerarRepeticiones()
		{
			SqlConnectionStringBuilder csb;
			csb = new SqlConnectionStringBuilder(((System.Collections.Specialized.NameValueCollection)(ConfigurationManager.GetSection("nhibernate")))["hibernate.connection.connection_string"]);

			using (SqlConnection con = new SqlConnection(csb.ConnectionString))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = con;
					cmd.CommandText = "strg_GenerarRepeticiones";
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
					//con.Close();
					//this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message,
						"Error al generarse las repeticiones de comprobantes",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void mnuArchivo_Salir_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(ClientesBL), typeof(ClientesCRUD), "Clientes", "Clientes").ShowGrid();
		}

		private void comprobantesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComprobantesBL FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			FacturasBL.SetTipoFilter(TiposComprobantesList.Factura);
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Facturas", "Facturas", typeof(ComprobantesCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
			result.ShowGrid();
		}

		private void rubrosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(RubrosBL), typeof(IdDescripcionCRUD), "Rubros", "Rubros").ShowGrid();
		}

		private void clasesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(ClasesBL), typeof(IdDescripcionCRUD), "Clases", "Clases").ShowGrid();
		}

		private void tiposContribuyenteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(TiposContribuyentesBL), typeof(TiposContribuyentesCRUD), "Tipos Contribuyentes", "Tipos Contribuyentes").ShowGrid();
		}

		private void productosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(ProductosBL), typeof(ProductosCRUD), "Productos", "Productos").ShowGrid();
		}

		private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(EmpresasBL), typeof(EmpresasCRUD), "Empresas", "Empresas").ShowGrid();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.OnLoad())
			{
				frmSplash.BringToFront();
				//if (IsValidLicense())
				//{
					Thread mThread = new Thread(new ThreadStart(this.EnvioFTP));
					mThread.IsBackground = true;
					mThread.Start();
					frmSplash.Hide();
					while ((SecurityManager.Instance.UsuarioActual == null) && !(SecurityManager.Instance.Canceled))
					{
						SecurityManager.Instance.ShowLogin();
					}

					this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesión ";
					if (SecurityManager.Instance.UsuarioActual != null)
						this.cerrarSesionToolStripMenuItem.Text += SecurityManager.Instance.UsuarioActual.Nombre;
					AvisoFacturasProgramadas();
				/*}
				else
				{
					frmSplash.Hide();
					MessageBox.Show("Su licencia a expirado.");
					Application.Exit();
				}*/

			}
			else
			{
				Application.Exit();
			}
		}
		private DateTime? lastLicenseCheck = (DateTime?)null;

		public DateTime? LastLicenseCheck { get { return lastLicenseCheck; } }

		public bool IsValidLicense()
		{
			if (!lastLicenseCheck.HasValue || lastLicenseCheck.Value.AddMonths(1) < DateTime.Today)
			{
				EmpresasBL empBL = new EmpresasBL();
				empBL.SetParameters(db);
				ComprobantesBL compBL = new ComprobantesBL();
				compBL.SetParameters(db);

				Empresas empresa = empBL.GetObject(GeneralSettings.Instance.IdEmpresaDefault) as Empresas;
				if (empresa != null )
				{
					Ftp FtpClient = new Ftp();
					FtpClient.HostAddress = FTPHost;
					FtpClient.Port = FTPPort;
					FtpClient.Username = FTPName;
					FtpClient.Password = FTPPass;
					FtpClient.Timeout = FTPTimeOut;
					FtpClient.Connect();

					string fileName = empresa.Cuit;

					FtpClient.MoveDirectory("Licencias");
					FtpItemCollection fic = new FtpItemCollection();
					FtpClient.FileList(ref fic);
					foreach (FtpItem item in fic)
					{
						if (item.Name.ToLower() == fileName.ToLower())
						{
							lastLicenseCheck = DateTime.Today; 
							return true;
						}
					}
					FtpClient.Quit();
				} 
				
				return false;
			}
			else {
				return true;
			}
		}

		private void AvisoFacturasProgramadas()
		{
			ComprobantesBL comprobantes = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			Int32 pendientesHoy = comprobantes.HasComprobantesProgramados();
			if (pendientesHoy > 0)
			{
				MessageBox.Show("Tiene " + pendientesHoy.ToString() + " comprobantes programados pendientes de emisión.");
			}

		}

		private void bbMain_ItemClick(object sender, ItemEventArgs e)
		{
			CRUDComprobantesController result;
			ComprobantesBL FacturasBL;

			switch (e.Item.Key)
			{
				case "Productos":
					{
						CRUDControllerManager.Instance.GetCRUDController(db, typeof(ProductosBL), typeof(ProductosCRUD), "Productos", "Productos").ShowGrid();
						break;
					}
				case "Clientes":
					{
						CRUDControllerManager.Instance.GetCRUDController(db, typeof(ClientesBL), typeof(ClientesCRUD), "Clientes", "Clientes").ShowGrid();
						break;
					}
				case "Rubros":
					{
						CRUDControllerManager.Instance.GetCRUDController(db, typeof(RubrosBL), typeof(IdDescripcionCRUD), "Rubros", "Rubros").ShowGrid();
						break;
					}
				case "Clases":
					{
						CRUDControllerManager.Instance.GetCRUDController(db, typeof(ClasesBL), typeof(IdDescripcionCRUD), "Clases", "Clases").ShowGrid();
						break;
					}
				case "Tipos Contribuyente":
					{
						CRUDControllerManager.Instance.GetCRUDController(db, typeof(TiposContribuyentesBL), typeof(TiposContribuyentesCRUD), "Tipos Contribuyentes", "Tipos Contribuyentes").ShowGrid();
						break;
					}
				case "Empresa":
					{
						CRUDControllerManager.Instance.GetCRUDController(db, typeof(EmpresasBL), typeof(EmpresasCRUD), "Empresas", "Empresas").ShowGrid();
						break;
					}
				case "Facturacion":
					{
						if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
							ShowPeriodoYTipo(ShowFacturacionReport);
						break;
					}
				case "ProductosTOP":
					{
						if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
							ShowPeriodo(ShowProductosReport);
						break;
					}
				case "LibroIVA":
					{
						if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
							ShowPeriodo(ShowComprobantesReport);
						break;
					}
				case "Usuarios":
					{
						if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
							ShowPeriodoYTipo(ShowFacturacionUsuariosReport);
						break;
					}
				case "Comprobantes":
					{
						//CRUDControllerManager.Instance.GetCRUDController(db, typeof(ComprobantesBL), typeof(ComprobantesCRUD), "Comprobantes", "Comprobantes").ShowGrid();
						//CRUDComprobantesController result = new CRUDComprobantesController(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)), "Comprobantes", "Comprobantes", typeof(ComprobantesCRUD));
						//CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
						//result.ShowGrid(); 

						FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
						FacturasBL.SetTipoFilter(TiposComprobantesList.Factura);
						result = new CRUDComprobantesController(FacturasBL, "Facturas", "Facturas", typeof(ComprobantesCRUD));
						CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);

						result.ShowGrid();

						break;
					}
				case "Pendientes":
					{
						FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
						//FacturasBL.SetTipoFilter(TiposComprobantesList.Factura);
						List<TiposComprobantesList> tipos = new List<TiposComprobantesList>();
						tipos.Add(TiposComprobantesList.Factura);
						tipos.Add(TiposComprobantesList.NotaCredito);
						tipos.Add(TiposComprobantesList.NotaDebito); 
						FacturasBL.SetTiposFilter(tipos);
						FacturasBL.SetEstadoFilter(Comprobantes.EstadoPendiente);
						result = new CRUDComprobantesController(FacturasBL, "Pendientes", "Facturas", typeof(ComprobantesCRUD));
						CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);

						result.ShowGrid();

						break;

					}
				case "EmitirComprobante":
					{

						Thread thrdStatus = new Thread(new ParameterizedThreadStart(Status.CheckStatus));
						thrdStatus.IsBackground = true;
						thrdStatus.Start(this);

						FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
						FacturasBL.SetTipoFilter(TiposComprobantesList.Factura);
						result = new CRUDComprobantesController(FacturasBL, "Facturas", "Facturas", typeof(ComprobantesCRUD));
						CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);

						result.ShowCRUDForm();
						break;

					}
				case "NotaCredito":
					{
						FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
						FacturasBL.SetTipoFilter(TiposComprobantesList.NotaCredito);
						result = new CRUDComprobantesController(FacturasBL, "Notas de Crédito", "Notas de Crédito", typeof(ComprobantesCRUD));
						CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
						result.ShowGrid();
						break;
					}
				case "NotaDebito":
					{
						FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
						FacturasBL.SetTipoFilter(TiposComprobantesList.NotaDebito);
						result = new CRUDComprobantesController(FacturasBL, "Notas de Débito", "Notas de Débito", typeof(ComprobantesCRUD));
						CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
						result.ShowGrid();
						break;
					}
			}

		}

		private void comprobantesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodo(ShowComprobantesReport);
		}
		public void ShowComprobantesReport(DateTime fechaDesde, DateTime fechaHasta)
		{
			new ReportViewer().Open(ReportManager.GetReportComprobantes(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)), fechaDesde, fechaHasta));
		}

		private void tiposIvaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(IvasBL), typeof(IvasCRUD), "Tipos IVA", "Tipos IVA").ShowGrid();
		}

		private void tiposPagoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(TiposPagoBL), typeof(IdDescripcionCRUD), "Tipos de Pago", "Tipos de Pago").ShowGrid();
		}

		private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodo(ShowProductosReport);
		}
		public void ShowProductosReport(DateTime fechaDesde, DateTime fechaHasta)
		{
			new ReportViewer().Open(ReportManager.GetReportProductos(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ProductosBL)), fechaDesde, fechaHasta));
		}

		private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodoYTipo(ShowFacturacionReport);
		}

		private void ShowPeriodo(Periodo.ExitDatesEvent ShowReport)
		{
			Periodo frmPeriodo = new Periodo();
			frmPeriodo.Exit += ShowReport;
			frmPeriodo.Show();
		}


		private void ShowPeriodoYTipo(PeriodoYTipo.ExitDatesAndTypeEvent ShowReport)
		{
			PeriodoYTipo frmPeriodo = new PeriodoYTipo();
			frmPeriodo.Exit += ShowReport;

			IList list = new ArrayList();

			list.Add(TipoPeriodo.Mensual);
			list.Add(TipoPeriodo.Trimestral);
			list.Add(TipoPeriodo.Semestral);
			frmPeriodo.SetTipoDataSource(list);
			frmPeriodo.Show();
		}


		public void ShowFacturacionReport(DateTime fechaDesde, DateTime fechaHasta, TipoPeriodo tipo)
		{
			new ReportViewer().Open(ReportManager.GetReportFacturacion(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)), fechaDesde, fechaHasta, tipo));
		}
		public void ShowFacturacionUsuariosReport(DateTime fechaDesde, DateTime fechaHasta, TipoPeriodo tipo)
		{
			new ReportViewer().Open(ReportManager.GetReportFacturacionUsuarios(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)), fechaDesde, fechaHasta, tipo));
		}


		private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(ProvinciasBL), typeof(IdDescripcionCRUD), "Provincias", "Provincias").ShowGrid();
		}

		private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(PaisesBL), typeof(IdDescripcionCRUD), "Paises", "Paises").ShowGrid();
		}

		private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(UsuariosBL), typeof(UsuariosCRUD), "Usuarios", "Usuarios").ShowGrid();
		}

		private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new CRUDUsersGroupsController(new UsersGroupsBL(db), "Perfiles", "Perfiles", typeof(UsersGroupsCRUD)).ShowGrid();
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionSettings()))
				genSettingsController.ShowForm();
		}

		private void ventasPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodoYTipo(ShowFacturacionUsuariosReport);
		}

		private void notasDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComprobantesBL FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			FacturasBL.SetTipoFilter(TiposComprobantesList.NotaCredito);
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Notas de Crédito", "Notas de Crédito", typeof(ComprobantesCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
			result.ShowGrid();
		}

		private void notasDeDébitoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComprobantesBL FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			FacturasBL.SetTipoFilter(TiposComprobantesList.NotaDebito);
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Notas de Débito", "Notas de Débito", typeof(ComprobantesCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
			result.ShowGrid();
		}

		private void emitirFacturaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Thread thrdStatus = new Thread(new ParameterizedThreadStart(Status.CheckStatus));
			thrdStatus.IsBackground = true;
			thrdStatus.Start(this);

			ComprobantesBL FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			FacturasBL.SetTipoFilter(TiposComprobantesList.Factura);
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Facturas", "Facturas", typeof(ComprobantesCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);

			result.ShowCRUDForm();

		}

		private void emitirNotaDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComprobantesBL FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			FacturasBL.SetTipoFilter(TiposComprobantesList.NotaCredito);
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Notas de Crédito", "Notas de Crédito", typeof(ComprobantesCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);

			result.ShowCRUDForm();

		}

		private void emitirNotaDeDébitoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ComprobantesBL FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			FacturasBL.SetTipoFilter(TiposComprobantesList.NotaDebito);
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Notas de Débito", "Notas de Débito", typeof(ComprobantesCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);

			result.ShowCRUDForm();

		}

		private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SecurityManager.Instance.Logout();
			while ((SecurityManager.Instance.UsuarioActual == null) && !(SecurityManager.Instance.Canceled))
				SecurityManager.Instance.ShowLogin();

			this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesión ";
			if (SecurityManager.Instance.UsuarioActual != null)
				this.cerrarSesionToolStripMenuItem.Text += SecurityManager.Instance.UsuarioActual.Nombre;

		}

		private void consultarCUITToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process myProcess = new Process();
			myProcess.StartInfo.FileName = @"iexplore.exe";
			myProcess.StartInfo.Arguments = ConfigurationManager.AppSettings["UrlConsultaCUIT"];// @"http://seti.afip.gov.ar/padron-puc-constancia-internet/ConsultaConstanciaAction.do";
			myProcess.Start();

		}

		private void validarLicenciaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SecurityManager.Instance.ShowActivateSerialKey();
		}


		private void mnuParametros_Aduanas_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(AduanasBL), "Aduanas").ShowGrid();
		}

		private void mnuParametros_Destinaciones_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(DestinacionesBL), "Destinaciones").ShowGrid();
		}

		private void mnuCompras_Facturas_Click(object sender, EventArgs e)
		{
			ComprobantesComprasBL facturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesComprasBL)) as ComprobantesComprasBL;
			facturasBL.SetTipoFilter(TiposComprobantesList.Factura);

			CRUDComprobantesComprasController result = new CRUDComprobantesComprasController(facturasBL, "Facturas de Proveedores", "Facturas de Proveedores", typeof(ComprobantesComprasCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
			result.ShowGrid();

		}

		private void mnuCompras_NotasCredito_Click(object sender, EventArgs e)
		{
			ComprobantesComprasBL notasCreditoBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesComprasBL)) as ComprobantesComprasBL;
			notasCreditoBL.SetTipoFilter(TiposComprobantesList.NotaCredito);

			CRUDComprobantesComprasController result = new CRUDComprobantesComprasController(notasCreditoBL, "Notas de Crédito de Proveedores", "Notas de Crédito de Proveedores", typeof(ComprobantesComprasCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
			result.ShowGrid();
		}

		private void mnuCompras_NotasDebito_Click(object sender, EventArgs e)
		{
			ComprobantesComprasBL notasDebitoBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesComprasBL)) as ComprobantesComprasBL;
			notasDebitoBL.SetTipoFilter(TiposComprobantesList.NotaDebito);

			CRUDComprobantesComprasController result = new CRUDComprobantesComprasController(notasDebitoBL, "Notas de Débito de Proveedores", "Notas de Débito de Proveedores", typeof(ComprobantesComprasCRUD));
			CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(result);
			result.ShowGrid();
		}

		private void mnuAfip_LibroIVAVentas_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				new LibroVentasAFIPController(
					BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL,
					BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(EmpresasBL)) as EmpresasBL
				).Generar();

			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodo(ShowComprobantesReport);
		}

		private void mnuReportes_LibroIVACompras_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodo(ShowComprobantesComprasReport);
		}

		public void ShowComprobantesComprasReport(DateTime fechaDesde, DateTime fechaHasta)
		{
			new ReportViewer().Open(ReportManager.GetReportComprobantesCompras(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesComprasBL)) as ComprobantesComprasBL, fechaDesde, fechaHasta));
		}

		private void mnuAfip_LibroIVACompras_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				new LibroComprasAFIPController(
					BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesComprasBL)) as ComprobantesComprasBL,
					BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(EmpresasBL)) as EmpresasBL
				).Generar();
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
				ShowPeriodo(ShowComprobantesComprasReport);
		}

		private void cabecerasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
			{
				CRUDComprobantesController crudComprobantes = new CRUDComprobantesController(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)), "Comprobantes", "Comprobantes", typeof(ComprobantesCRUD));
				crudComprobantes.Comprobantes = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
				crudComprobantes.Empresas = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(EmpresasBL)) as EmpresasBL;
				crudComprobantes.GenerarArchivoCabeceraPeriodo();
				MessageBox.Show("Se ha generado con éxito el archivo de cabeceras", "Archivo de cabeceras generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SecurityManager.Instance.HavePermissions(new FuncionReportes()))
			{
				CRUDComprobantesController crudComprobantes = new CRUDComprobantesController(BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)), "Comprobantes", "Comprobantes", typeof(ComprobantesCRUD));
				crudComprobantes.Comprobantes = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
				crudComprobantes.Empresas = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(EmpresasBL)) as EmpresasBL;
				crudComprobantes.GenerarArchivoDetallePeriodo();
				MessageBox.Show("Se ha generado con éxito el archivo de detalles", "Archivo de detalles generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}

		public PictureBox StatusConn
		{
			get { return statusConn; }
			set { statusConn = value; }
		}
		public PictureBox StatusWS
		{
			get { return statusWS; }
			set { statusWS = value; }
		}

		private void realizarBackUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//TODO: Ver de ponerle roles
			//if (SecurityManager.Instance.HavePermissions(new FuncionSettings()))
			genSettingsBKPController.ShowForm();
		}
		private void importarExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//TODO: Ver de ponerle roles
			//if (SecurityManager.Instance.HavePermissions(new FuncionSettings()))
			genSettingsImportController.ShowForm();

		}
		private void repeticionesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CRUDControllerManager.Instance.GetCRUDController(db, typeof(RepeticionesBL), typeof(RepeticionesCRUD), "Repeticiones", "Repeticiones").ShowGrid();

		}

		private void emitirPendientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			frmSplash.Show();
			EmpresasBL EmpresasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(EmpresasBL)) as EmpresasBL;
			ComprobantesBL FacturasBL;
			FacturasBL = BusinessLogicFactory.GetBusinessLogicInstance(db, typeof(ComprobantesBL)) as ComprobantesBL;
			//FacturasBL.SetTipoFilter(TiposComprobantesList.Factura);
			List<TiposComprobantesList> tipos = new List<TiposComprobantesList>();
			tipos.Add(TiposComprobantesList.Factura);
			tipos.Add(TiposComprobantesList.NotaCredito);
			tipos.Add(TiposComprobantesList.NotaDebito);
			FacturasBL.SetTiposFilter(tipos);
			FacturasBL.SetEstadoFilter(Comprobantes.EstadoPendiente);
			FacturasBL.SetEmisionHoyFilter();
			ArrayList facturasPend = new ArrayList();
			facturasPend.AddRange(FacturasBL.GetDataSource());
			CRUDComprobantesController result = new CRUDComprobantesController(FacturasBL, "Facturas", "Facturas", typeof(ComprobantesCRUD));

			bool verReporteAux;
			string nroComp;
			int index = 1;
			Empresas emp = null;
			foreach (Comprobantes comp in facturasPend)
			{
				frmSplash.TextoContador = String.Format("{0} de {1}", index.ToString(), facturasPend.Count.ToString());
				frmSplash.Refresh();
				nroComp = null;
				verReporteAux = comp.VerReporte;
				comp.VerReporte = false;
				result.EmitirComprobante(comp, out nroComp, false);
				if (nroComp == "-1")
				{
					throw new Exception("Hubo un error emitiendo los comprobantes.");
				}
				PersistirUltimoNroCbanteComprobante(comp);

				comp.VerReporte = verReporteAux;
				index++;
				emp = comp.Empresa;

			}
			EmpresasBL.SaveOrUpdate(emp);
			frmSplash.Hide();
			Cursor.Current = Cursors.Default;
		}

		//TODO: Repetido
		private void PersistirUltimoNroCbanteComprobante(Comprobantes comp)
		{
			if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaA"])
				comp.Empresa.UltimaFacturaA = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaB"])
				comp.Empresa.UltimaFacturaB = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaC"])
				comp.Empresa.UltimaFacturaC = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaE"])
				comp.Empresa.UltimaFacturaE = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoA"])
				comp.Empresa.UltimaNotaDebitoA = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoB"])
				comp.Empresa.UltimaNotaDebitoB = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoC"])
				comp.Empresa.UltimaNotaDebitoC = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoE"])
				comp.Empresa.UltimaNotaDebitoE = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoA"])
				comp.Empresa.UltimaNotaCreditoA = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoB"])
				comp.Empresa.UltimaNotaCreditoB = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoC"])
				comp.Empresa.UltimaNotaCreditoC = comp.NroCbante;
			else if (comp.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoE"])
				comp.Empresa.UltimaNotaCreditoE = comp.NroCbante;
		}





	}
}