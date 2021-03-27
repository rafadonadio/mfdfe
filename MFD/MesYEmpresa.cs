using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace MFD
{
    public partial class MesYEmpresa : Form {
        public delegate void ExitMesYEmpresaEvent(Empresas empresa, int anio, int mes);
        public event ExitMesYEmpresaEvent Exit;
        public event FrameWork.CRUDModel.Windows.UI.PropertyValueListNeeded PropertyValueListNeeded;
        
        public MesYEmpresa() {
            InitializeComponent();
            stylesSheetManager.ApplyStyles();
        }
        
        public void Open(string title) {
            Text = title;
            if (PropertyValueListNeeded != null) cmbEmpresa.DataSource = PropertyValueListNeeded("Empresa", null);
            CargarComboMeses();
            FillControls();
            ShowDialog();
        }
        
        private void CargarComboMeses() {
            cmbMes.Items.Clear();
            for (int mes = 1; mes <= 12; mes++) cmbMes.Items.Add(mes);
        }
        
        private void FillControls() {
            Empresas empresaDefault=null;
            IEnumerator enumerator = cmbEmpresa.Items.GetEnumerator();
            
            while ((empresaDefault==null) && enumerator.MoveNext()) {
                if ((enumerator.Current as Empresas).Id == GeneralSettings.Instance.IdEmpresaDefault)
                    empresaDefault = (enumerator.Current as Empresas);
            }
            
            cmbEmpresa.SelectedItem = empresaDefault;
            txtAnio.Value = DateTime.Now.Year;
            cmbMes.SelectedItem = DateTime.Now.Month;
        }
        private void btnAccept_Click(object sender, EventArgs e) {
			if (Exit != null)
                Exit(cmbEmpresa.SelectedItem as Empresas, Convert.ToInt32(txtAnio.Value), (int) cmbMes.SelectedItem);
        }
        
    }
}