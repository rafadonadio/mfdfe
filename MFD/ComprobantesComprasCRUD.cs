using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using FrameWork.CRUDModel;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.DataBusinessModel.DataModel;

namespace MFD
{
	public partial class ComprobantesComprasCRUD : CRUDForm
	{
		public event ComprobanteCompraObjectEvent AnularComprobante;

		public ComprobantesComprasCRUD()
		{
			InitializeComponent();
		}

		new protected ComprobantesCompras Persistent
		{
			get { return (ComprobantesCompras)persistent; }
		}

		protected override void FillControls()
		{
			lblEstado.Text = Persistent.Estado;
			txtFecha.Value = Persistent.Emision;
			txtCantidadHojas.Value = Persistent.CantidadHojas;
			cmbTipo.SelectedItem = Persistent.Tipo;
			txtNumero.Text = Persistent.Numero;
			txtObservaciones.Text = Persistent.Observaciones;

			txtNombreProveedor.Text = Persistent.NombreProveedor;
			txtCUITProveedor.Text = Persistent.CUITProveedor;
			dcTipoContribuyenteProveedor.Selected = Persistent.TipoProveedor;
			txtCAIProveedor.Text = Persistent.CAIProveedor;
			txtFechaVencimientoCAIProveedor.Value = Persistent.FechaVencimientoCAIProveedor;

			chkImportacion.Checked = Persistent.Importacion;

			cmbDestinacion.SelectedItem = Persistent.Destinacion;
			cmbAduana.SelectedItem = Persistent.Aduana;
			txtNumeroDespacho.Text = Persistent.NumeroDespacho;
			txtDigitoVerificadorNumeroDespacho.Text = Persistent.DigitoVerificadorNumeroDespacho.ToString();
			if (Persistent.FechaDespacho != null) txtFechaDespacho.Value = Persistent.FechaDespacho.Value;
			else txtFechaDespacho.Value = DateTime.Now;

			//txtDescuentoCalc.Text = Persistent.Descuento.ToString();
			FillTotales();
			base.FillControls();
		}

		protected void FillTotales()
		{
			txtNetoGravado.Text = Persistent.NetoGravado.ToString("#0.#0");
			txtNetoNoGravado.Text = Persistent.TotalNoGravado.ToString("#0.#0");
			txtOperacionesExentas.Text = Persistent.ImporteOperacionesExentas.ToString("#0.#0");
			txtImpuestoLiquidado.Text = Persistent.ImpuestoLiquidado.ToString("#0.#0");
			txtPercepciones.Value = Persistent.Percepciones;
			txtPercepcionesIngresosBrutos.Value = Persistent.PercepcionesIngresosBrutos;
			txtPercepcionesMunicipales.Value = Persistent.PercepcionesMunicipales;
			txtImpuestosInternos.Value = Persistent.ImpuestosInternos;
			txtTotal.Text = Persistent.Total.ToString("#0.#0");
		}

		protected override void FillObject()
		{
			Persistent.Emision = txtFecha.Value;
			Persistent.CantidadHojas = Convert.ToInt32(txtCantidadHojas.Value);
			Persistent.Tipo = (TiposComprobantes)cmbTipo.SelectedItem;
			Persistent.Numero = txtNumero.Text;
			Persistent.Observaciones = txtObservaciones.Text;
			Persistent.NombreProveedor = txtNombreProveedor.Text;
			Persistent.CUITProveedor = txtCUITProveedor.Text;
			Persistent.TipoProveedor = dcTipoContribuyenteProveedor.Selected as TiposContribuyentes;
			Persistent.CAIProveedor = txtCAIProveedor.Text;
			Persistent.FechaVencimientoCAIProveedor = txtFechaVencimientoCAIProveedor.Value;

			Persistent.Importacion = chkImportacion.Checked;
			Persistent.Destinacion = cmbDestinacion.SelectedItem as Destinaciones;
			Persistent.Aduana = cmbAduana.SelectedItem as Aduanas;
			Persistent.NumeroDespacho = txtNumeroDespacho.Text;
			if (txtDigitoVerificadorNumeroDespacho.Text.Length > 0) Persistent.DigitoVerificadorNumeroDespacho = txtDigitoVerificadorNumeroDespacho.Text[0];
			else Persistent.DigitoVerificadorNumeroDespacho = '\0';
			Persistent.FechaDespacho = txtFechaDespacho.Value;

			Persistent.Percepciones = txtPercepciones.Value;
			Persistent.PercepcionesIngresosBrutos = txtPercepcionesIngresosBrutos.Value;
			Persistent.PercepcionesMunicipales = txtPercepcionesMunicipales.Value;
			Persistent.ImpuestosInternos = txtImpuestosInternos.Value;

			base.FillObject();
		}

		public override void SetPersistentChanged()
		{
			persistentChanged |=
			!(
			Persistent.Emision == txtFecha.Value &&
			Persistent.CantidadHojas == Convert.ToInt32(txtCantidadHojas.Value) &&
			Persistent.Tipo == (TiposComprobantes)cmbTipo.SelectedItem &&
			((Persistent.Numero == null) ? txtNumero.MaskedTextProvider.ToString() : Persistent.Numero) == txtNumero.Text &&
			((Persistent.Observaciones == null) ? "" : Persistent.Observaciones) == txtObservaciones.Text &&
			((Persistent.NombreProveedor == null) ? "" : Persistent.NombreProveedor) == txtNombreProveedor.Text &&
			((Persistent.CUITProveedor == null) ? txtCUITProveedor.MaskedTextProvider.ToString() : Persistent.CUITProveedor) == txtCUITProveedor.Text &&
			Persistent.TipoProveedor == dcTipoContribuyenteProveedor.Selected as TiposContribuyentes &&
			((Persistent.CAIProveedor == null) ? "" : Persistent.CAIProveedor) == txtCAIProveedor.Text &&
			Persistent.FechaVencimientoCAIProveedor == txtFechaVencimientoCAIProveedor.Value &&
			Persistent.Importacion == chkImportacion.Checked &&
			Persistent.Destinacion == cmbDestinacion.SelectedItem as Destinaciones &&
			Persistent.Aduana == cmbAduana.SelectedItem as Aduanas &&
			((Persistent.NumeroDespacho == null && txtNumeroDespacho.Text == "") || (Persistent.NumeroDespacho == txtNumeroDespacho.Text)) &&
			((Persistent.FechaDespacho == null) ? true : Persistent.FechaDespacho == txtFechaDespacho.Value) &&
			Persistent.Percepciones == txtPercepciones.Value &&
			Persistent.PercepcionesIngresosBrutos == txtPercepcionesIngresosBrutos.Value &&
			Persistent.PercepcionesMunicipales == txtPercepcionesMunicipales.Value &&
			Persistent.ImpuestosInternos == txtImpuestosInternos.Value
			);
		}


		protected override void RefreshControls()
		{
			base.RefreshControls();
			cmbTipo.DataSource = RequirePropertyValueList("Tipo");
			cmbDestinacion.DataSource = RequirePropertyValueList("Destinacion");
			cmbAduana.DataSource = RequirePropertyValueList("Aduana");
			dcTipoContribuyenteProveedor.DataType = typeof(TiposContribuyentes);
			InicializarGrillaDetalles();
		}

		public override void EnableControls()
		{
			base.EnableControls();

			if (Persistent.IsAnulado)
			{
				FormUtils.Instance.ControlEnabler.Enable(this, false);
				btnCancel.Enabled = true;
			}
			else
			{
				btnAnular.Enabled = (action == CRUDAction.Update);
			}
			chkImportacion_CheckedChanged(chkImportacion, new EventArgs());
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			if (AcceptForm())
			{
				persistentChanged = false; 
				Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		public override void RefreshChildGrid(Type childType)
		{
			base.RefreshChildGrid(childType);
			if (childType == DetallesGrid.ItemType)
				RefrescarGrillaDetalles();
		}

		private void InicializarGrillaDetalles()
		{
			DetallesGrid.ItemType = typeof(DetallesComprobantesCompras);
			DetallesGrid.SetDataSource(Persistent.Items, true);
			DetallesGrid.RefreshDataSource();
		}

		private void RefrescarGrillaDetalles()
		{
			if (Persistent.Items.Count == 1) InicializarGrillaDetalles();
			else DetallesGrid.RefreshDataSource();
			RefrescarTotales();
		}

		private void DetallesGrid_CreateItemRequired(Type itemType)
		{
			RequireChildCreate(itemType);
		}

		private void DetallesGrid_DeleteItemRequired(object obj)
		{
			RequireChildDelete(obj as Persistent);
		}

		private void DetallesGrid_RetrieveItemRequired(object obj)
		{
			RequireChildRetrieve(obj as Persistent);
		}

		private void DetallesGrid_UpdateItemRequired(object obj)
		{
			RequireChildUpdate(obj as Persistent);
		}

		private void DetallesGrid_ResetLayout(Janus.Windows.GridEX.GridEX grid, Type type)
		{
			RequireChildGridResetLayout(grid, type);
		}

		private void RefrescarTotales()
		{
			Persistent.Percepciones = txtPercepciones.Value;
			Persistent.PercepcionesIngresosBrutos = txtPercepcionesIngresosBrutos.Value;
			Persistent.PercepcionesMunicipales = txtPercepcionesMunicipales.Value;
			Persistent.ImpuestosInternos = txtImpuestosInternos.Value;
			Persistent.CalcularTotales();
			FillTotales();
		}

		private void btnAnular_Click(object sender, EventArgs e)
		{
			string result;
			FillObject();
			if (AnularComprobante != null)
			{
				result = AnularComprobante(Persistent);
				if (result != "")
					MessageBox.Show(result);
			}
			if (AcceptForm()) Close();
		}

		private void chkImportacion_CheckedChanged(object sender, EventArgs e)
		{
			pnlImportacion.Enabled = chkImportacion.Checked;
		}

		private void dcTipoContribuyenteProveedor_BrowseClick(DataCombo dc, Type dataType)
		{
			RequireGridSel(dc, dataType);
		}

		private void txtImporte_Leave(object sender, EventArgs e)
		{
			RefrescarTotales();
		}
	}

	public delegate string ComprobanteCompraObjectEvent(ComprobantesCompras obj);
}