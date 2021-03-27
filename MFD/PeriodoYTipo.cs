using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace MFD
{
    public partial class PeriodoYTipo : Form
    {
        public delegate void ExitDatesAndTypeEvent(DateTime fechaDesde, DateTime fechaHasta,TipoPeriodo tipo);
        public event ExitDatesAndTypeEvent Exit;

        public PeriodoYTipo()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        
        }
        public void SetTipoDataSource(IList list)
        {
            cmbTipo.DataSource = list ;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (Exit != null)
                Exit(txtFechaDesde.Value, txtFechaHasta.Value, (TipoPeriodo)  cmbTipo.SelectedItem);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close(); 
        }

    }
}