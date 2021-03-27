using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Entities;
using MFD.Clases;

namespace MFD
{
    public partial class ImportarExcel : Form
    
    {
		SqlConnectionStringBuilder csb;
		public event ObjectEvent SaveObject;
		public event GetObjectEvent GetObjectById;
		protected GeneralSettings setting;
		public event PropertyValueListNeeded PropertyValueListNeeded;

		public GeneralSettings Setting
		{
			get { return setting; }
			set { setting = value; }
		}
		
		public ImportarExcel()
        {
            InitializeComponent();
			this.stylesSheetManager.ApplyStyles();

        }
        

        public void Open()
        {
			csb = new SqlConnectionStringBuilder(((System.Collections.Specialized.NameValueCollection)(ConfigurationManager.GetSection("nhibernate")))["hibernate.connection.connection_string"]);
			cboEntidad.SelectedIndex = 0;
			txtFileProductos.Text = "";
			ShowDialog();
        }
        
		const string CLIENTES = "Clientes";
		const string PRODUCTOS = "Productos";
        public void btnImportarExcel_Click(object sender, EventArgs e)
        {
			int cantExitosos=0;
			StringBuilder logError=null;
			string entidad="";
			if (!String.IsNullOrEmpty(txtFileProductos.Text))
			{
				if (cboEntidad.SelectedItem == CLIENTES)
				{
					entidad = CLIENTES.ToLower();
					ImportarClientes(txtFileProductos.Text, out cantExitosos, out logError);
				}
				else
				{
					entidad = PRODUCTOS.ToLower();
					ImportarProductos(txtFileProductos.Text, out cantExitosos, out logError);
				}
			}
			StringBuilder msg = new StringBuilder();
			msg.Append("Se han importado " + cantExitosos.ToString() + " " + entidad + " a la base de datos correctamente." + Environment.NewLine);
			if (logError.Length > 0)
			{
				string path = AppDomain.CurrentDomain.BaseDirectory + "LogImportacionDeDatos.txt";
				msg.Append("Ver log de errores en el archivo: " + path);
				FileStream file = File.Open(path, FileMode.Append);//, FileAccess.ReadWrite, FileShare.ReadWrite);
				using (StreamWriter sw = new StreamWriter(file, System.Text.Encoding.Default))
				{
					System.Globalization.CultureInfo cultura = new System.Globalization.CultureInfo("es-ar");
					logError.Insert(0, Environment.NewLine + "LOG DE ERRORES - IMPORTACIÓN DE " + entidad.ToUpper() + " - " + DateTime.Now.ToString(cultura) + Environment.NewLine + Environment.NewLine);
					logError.Insert(0, Environment.NewLine + Environment.NewLine + Environment.NewLine + "-------------------------------------------------------------------------------------");
					sw.Write(logError.ToString());
				}
				file.Close();

			}
			MessageBox.Show(msg.ToString(), "Importación de " + entidad, MessageBoxButtons.OK, MessageBoxIcon.Information);

			
			this.Close();
			
        }
		private void ImportarClientes(string path, out int cantExitosos, out StringBuilder logError)
		{//TODO: Ver con excel 2003
			String strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties=Excel 8.0;";

			DataSet ds = new DataSet();
			System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
			da.Fill(ds);
			int indexRow = 0;
			cantExitosos = 0;
			logError = new StringBuilder();
			if (ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					using (SqlConnection con = new SqlConnection(csb.ConnectionString))
					{
						try
						{
							indexRow++;
							con.Open();
							SqlCommand cmd = new SqlCommand();
							cmd.Connection = con;
							cmd.CommandType = CommandType.StoredProcedure;
							bool iibbexento = false;
							if (dr["iibbexento"].ToString().ToLower() == "si")
								iibbexento = true;
							cmd.CommandText = "strg_tcliente_Importar";
							cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = dr["nombre"];
							cmd.Parameters.Add("@cuit", SqlDbType.NVarChar).Value = dr["cuit"];
							cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = dr["email"];
							cmd.Parameters.Add("@user_upd", SqlDbType.Int).Value = SecurityManager.Instance.UsuarioActual.Id;
							cmd.Parameters.Add("@desc_tipocontrib", SqlDbType.NVarChar).Value = dr["desc_tipocontrib"];
							cmd.Parameters.Add("@desc_clase", SqlDbType.NVarChar).Value = dr["desc_clase"];
							cmd.Parameters.Add("@filtraclase", SqlDbType.Bit).Value = false;
							cmd.Parameters.Add("@iibbexento", SqlDbType.Bit).Value = iibbexento;
							cmd.Parameters.Add("@desc_tipopago", SqlDbType.NVarChar).Value = dr["desc_tipopago"];
							cmd.Parameters.Add("@desc_provincia", SqlDbType.NVarChar).Value = dr["desc_provincia"];
							cmd.Parameters.Add("@desc_pais", SqlDbType.NVarChar).Value = dr["desc_pais"];
							cmd.Parameters.Add("@domicilio", SqlDbType.NVarChar).Value = dr["domicilio"];
							cmd.Parameters.Add("@localidad", SqlDbType.NVarChar).Value = dr["localidad"];
							cmd.Parameters.Add("@telefonos", SqlDbType.NVarChar).Value = dr["telefonos"];
							cmd.Parameters.Add("@codigopostal", SqlDbType.NVarChar).Value = dr["codigopostal"];
							cmd.Parameters.Add("@nroLinea", SqlDbType.NVarChar).Value = indexRow.ToString();
							cmd.ExecuteNonQuery();
							con.Close();
							this.Close();
							cantExitosos++;
						}
						catch (Exception ex)
						{
							string error = ex.Message;
							if (error.Contains("no pertenece a la tabla Table."))
							{
								error = error.Replace("no pertenece a la tabla Table." , "debe existir en el archivo de importación.");
							}
							logError.Append(error);
						}
					}

				}

			}
		}

		private void ImportarProductos(string path, out int cantExitosos, out StringBuilder logError)
		{
			//TODO: Ver con excel 2003
			String strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source="+path+";" + "Extended Properties=Excel 8.0;";

			DataSet ds = new DataSet();
			System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn); 
			da.Fill(ds);
			int indexRow=0;
			cantExitosos = 0;
			logError = new StringBuilder();
			if (ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					using (SqlConnection con = new SqlConnection(csb.ConnectionString))
					{
						try
						{
							indexRow++;
							con.Open();
							double alicuota, importe;
							try
							{
								importe = Convert.ToDouble(dr["Importe"]);
							}
							catch {
								throw new Exception("Valor de importe inválido, debe ser un valor numérico. Línea " + indexRow.ToString() + Environment.NewLine);
							}
							try
							{
								alicuota = Convert.ToDouble(dr["IVA"]);
							}
							catch
							{
								throw new Exception("Valor de alicuota inválido, debe ser un valor numérico. Línea " + indexRow.ToString() + Environment.NewLine);
							}
							SqlCommand cmd = new SqlCommand();
							cmd.Connection = con;
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.CommandText = "strg_tproducto_Insertar";
							cmd.Parameters.Add("@identificacion", SqlDbType.NVarChar).Value = dr["Identificación"];
							cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = dr["Descripción"];
							cmd.Parameters.Add("@impmc", SqlDbType.Decimal).Value = importe;
							cmd.Parameters.Add("@user_upd", SqlDbType.Int).Value = SecurityManager.Instance.UsuarioActual.Id;
							cmd.Parameters.Add("@desc_rubro", SqlDbType.NVarChar).Value = dr["Rubro"];
							cmd.Parameters.Add("@desc_clase", SqlDbType.NVarChar).Value = dr["Clase"];
							cmd.Parameters.Add("@alicuta_iva", SqlDbType.Float).Value = alicuota;
							cmd.Parameters.Add("@nroLinea", SqlDbType.NVarChar).Value = indexRow.ToString();
							cmd.ExecuteNonQuery();
							con.Close();
							this.Close();
							cantExitosos++;
						}
						catch (Exception ex)
						{
							string error = ex.Message;
							if (error.Contains("no pertenece a la tabla Table."))
							{
								error = error.Replace("no pertenece a la tabla Table.", "debe existir en el archivo de importación.");
							}
							logError.Append(error);
						}
					}

				}

			}
		}

		private void btnPathProductos_Click(object sender, EventArgs e)
		{
			openFileDialog.Filter = "Excel Worksheets|*.xls";
			if (txtFileProductos.Text != String.Empty)
				openFileDialog.FileName = txtFileProductos.Text;

			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtFileProductos.Text = openFileDialog.FileName;
			}
		}

		
   }
}