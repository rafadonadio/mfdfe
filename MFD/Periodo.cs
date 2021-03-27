using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
namespace MFD
{
    public partial class Periodo : Form
    {
		public delegate void ExitDatesEvent(DateTime fechaDesde, DateTime fechaHasta);
		//public delegate void ExitEmpresaAndDatesEvent(string razonSocial, DateTime fechaDesde, DateTime fechaHasta);
		public event ExitDatesEvent Exit;
		//public event ExitEmpresaAndDatesEvent ExitEmpresa;
		private string razonSocial;
        public Periodo()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Exit != null)
                Exit(txtFechaDesde.Value, txtFechaHasta.Value);
			
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}