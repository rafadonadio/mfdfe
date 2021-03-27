using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Entities;

namespace MFD
{
    public partial class HacerBackup : Form
    
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
		
		public HacerBackup()
        {
            InitializeComponent();
			this.stylesSheetManager.ApplyStyles(); 
        }
        

        public void Open()
        {
			csb = new SqlConnectionStringBuilder(((System.Collections.Specialized.NameValueCollection)(ConfigurationManager.GetSection("nhibernate")))["hibernate.connection.connection_string"]);
			this.txtBase.Text = csb.InitialCatalog;
			this.txtServidor.Text = csb.DataSource;
			this.txtBackup.Text = setting.FileBackUp;
			ShowDialog();
        }
        
        public void btnHacerBackup_Click(object sender, EventArgs e)
        {
			setting.FileBackUp = this.txtBackup.Text;
			if (SaveObject != null)
				SaveObject(setting);
			
			string sBackup = "BACKUP DATABASE " + csb.InitialCatalog + " TO  DISK = N'" + txtBackup.Text + "' WITH NOFORMAT, INIT,  NAME = N'strghomo-Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmdBackUp = new SqlCommand(sBackup, con);

                    cmdBackUp.ExecuteNonQuery();

                    MessageBox.Show("Se ha creado un BackUp de La base de datos satisfactoriamente",
                        "Copia de seguridad de base de datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
					this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Error al copiar la base de datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

		private void btnPath_Click(object sender, EventArgs e)
		{
			if (txtBackup.Text != String.Empty)
				openFileDialog.FileName = txtBackup.Text;

			DialogResult result = openFileDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtBackup.Text = openFileDialog.FileName;
			}
		}
   }
}