using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.DataBusinessModel.DataModel;
using Janus.Windows.GridEX;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace MFD
{
    public partial class RepeticionesCRUD : CRUDForm
    {
		public event ObjectEvent SaveObject;
		public event GetObjectEvent GetObjectById;
		protected Repeticiones repeticiones;
		public event PropertyValueListNeeded PropertyValueListNeeded;
		private Repeticiones auxRepeticion = null;
		
		public RepeticionesCRUD()
        {
			 InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }
		public RepeticionesCRUD(Repeticiones rep)
		{
			InitializeComponent();
			this.stylesSheetManager.ApplyStyles();
			auxRepeticion = rep;
			txtId.Text = auxRepeticion.Id.ToString();
			DateTime hoy = DateTime.Today;
			cboDiaMes.Value = hoy.Day;
			txtHasta.Value = hoy.AddMonths(6);
			if (auxRepeticion.Comprobante != null)
			{
				if (auxRepeticion.Comprobante.NroCbante != null)
				{
					txtNroComprobante.Text = auxRepeticion.Comprobante.NroCbante.ToString();
				}
				txtTipoComprobante.Text = auxRepeticion.Comprobante.Tipo.Nombre;
			}

		}

		public void Open()
		{
			Show();
			FillControls();
		}
		


		public Repeticiones Repeticiones
		{
			get { return repeticiones; }
			set { repeticiones = value; }
		}
        

        protected override void FillObject()
        {
            base.FillObject();
			//Persistent.IdComprobante = Convert.ToInt32(txtId.Text);
			if (Persistent == null) { 
				//PAra cuando se crear desde el comprobante
				Persistent = new Repeticiones();
				Persistent.Comprobante = new Comprobantes();
			}
			Persistent.DiaMes = (int)cboDiaMes.Value;
			Persistent.Hasta = txtHasta.Value;
        }

        public override void SetPersistentChanged()
        {
			if (Persistent != null)
			{
				persistentChanged =
				!(
					(
					Persistent.DiaMes == cboDiaMes.Value &&
					Persistent.Hasta == txtHasta.Value)
				);
			}
        }

        protected override void FillControls()
        {
            //txtId.Text = Persistent.IdComprobante.ToString();
			//txtId.Text = Persistent.Comprobante.Id.ToString();
			txtId.Text = Persistent.Id.ToString();
            cboDiaMes.Value = Persistent.DiaMes;
			txtHasta.Value = Persistent.Hasta;
			if (Persistent.Comprobante != null)
			{
				if (Persistent.Comprobante.NroCbante != null)
				{
					txtNroComprobante.Text = Persistent.Comprobante.NroCbante.ToString();
				}
				txtTipoComprobante.Text = Persistent.Comprobante.Tipo.Nombre;
			}
        }

		new public Entities.Repeticiones Persistent
        {
			get { return (Entities.Repeticiones)persistent; }
            set { persistent = value; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
			if (auxRepeticion == null)
			{ if (AcceptForm()) Close(); }
			else { 
				CrearRepeticion(); 
				Close(); 
			}
				
        }

		private void CrearRepeticion()
		{
			SqlConnectionStringBuilder csb;
			csb = new SqlConnectionStringBuilder(((System.Collections.Specialized.NameValueCollection)(ConfigurationManager.GetSection("nhibernate")))["hibernate.connection.connection_string"]);
			
			using (SqlConnection con = new SqlConnection(csb.ConnectionString))
			{
				try
				{
					con.Open();
					SqlCommand cmd= new SqlCommand();
					cmd.Connection = con;
					cmd.CommandText = "INSERT INTO [strg_trepeticion]([id_comprobante],[dia_mes],[hasta]) VALUES (" + txtId.Text + ", " + cboDiaMes.Value.ToString() + ", '" + txtHasta.Value.Year.ToString() + txtHasta.Value.Month.ToString().PadLeft(2, '0') + txtHasta.Value.Day.ToString().PadLeft(2, '0') + "')" + Environment.NewLine;
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
					con.Close();
					//this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message,
						"Error al crear la repetición",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}