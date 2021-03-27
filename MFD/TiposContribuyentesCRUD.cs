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

namespace MFD
{
    public partial class TiposContribuyentesCRUD : CRUDForm
    {
        public TiposContribuyentesCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        protected override void FillObject()
        {
            base.FillObject();
            Persistent.Descripcion = txtDescripcion.Text;
            Persistent.Codigo = txtCodigo.Text;
            Persistent.DiscriminaIVA = chkDiscriminaIVA.Checked;
			Persistent.ComputaIVA = chkComputaIVA.Checked;
            Persistent.Percepciones = chkPercepciones.Checked;
            Persistent.TipoComprobanteFactura = (TiposComprobantes)cmbTipoFactura.SelectedItem;
            Persistent.TipoComprobanteNotaCredito= (TiposComprobantes)cmbTipoNotaCredito.SelectedItem;
            Persistent.TipoComprobanteNotaDebito = (TiposComprobantes)cmbTipoNotaDebito.SelectedItem;
        }

        public override void SetPersistentChanged()
        {
            persistentChanged =
            !(
            ((Persistent.Descripcion == null) ? "" : Persistent.Descripcion) == txtDescripcion.Text &&
            ((Persistent.Codigo == null) ? "" : Persistent.Codigo) == txtCodigo.Text &&
            Persistent.DiscriminaIVA == chkDiscriminaIVA.Checked &&
			Persistent.ComputaIVA == chkComputaIVA.Checked &&
			Persistent.Percepciones == chkPercepciones.Checked &&
            Persistent.TipoComprobanteFactura == (TiposComprobantes)cmbTipoFactura.SelectedItem &&
            Persistent.TipoComprobanteNotaCredito == (TiposComprobantes)cmbTipoNotaCredito.SelectedItem &&
            Persistent.TipoComprobanteNotaDebito == (TiposComprobantes)cmbTipoNotaDebito.SelectedItem
            );
        }

        protected override void FillControls()
        {
            txtDescripcion.Text = Persistent.Descripcion;
            txtCodigo.Text = Persistent.Codigo;
            chkPercepciones.Checked = Persistent.Percepciones;
            chkDiscriminaIVA.Checked = Persistent.DiscriminaIVA;
			chkComputaIVA.Checked = Persistent.ComputaIVA;
            cmbTipoFactura.SelectedItem = Persistent.TipoComprobanteFactura ;
            cmbTipoNotaCredito.SelectedItem = Persistent.TipoComprobanteNotaCredito;
            cmbTipoNotaDebito.SelectedItem = Persistent.TipoComprobanteNotaDebito;
        }

        new public TiposContribuyentes Persistent
        {
            get { return (TiposContribuyentes)persistent; }
            set { persistent = value; }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AcceptForm()) Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void RefreshControls()
        {
            base.RefreshControls();
			try
			{
				cmbTipoFactura.DataSource = RequirePropertyValueList("TipoFactura");
				cmbTipoNotaDebito.DataSource = RequirePropertyValueList("TipoNotaDebito");
				cmbTipoNotaCredito.DataSource = RequirePropertyValueList("TipoNotaCredito");
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

    }
}