using System;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;
using Entities;
using FrameWork.CRUDModel;
using FrameWork.CRUDModel.Windows;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.DataBusinessModel.DataModel;
using Janus.Windows.GridEX;
using WindowsFormsControls;
using MFD.Clases;
using BusinessLogic;
using FrameWork.DataBusinessModel;

namespace MFD
{
    public partial class ComprobantesCRUD : CRUDForm {

        public event ComprobanteObjectOutEvent EmitirComprobante;
        public event ComprobanteObjectEvent AnularComprobante;
        public event ComprobanteObjectEvent ReenviarComprobante;
		private Clientes auxCliente = null;

		public ComprobantesCRUD()
		{
			InitializeComponent();
			stylesSheetManager.ApplyStyles();
		}

        new protected Comprobantes Persistent {
            get { return (Comprobantes)persistent; }
        }

        protected override void FillControls() {
            lblEstado.Text = Persistent.Estado;
            txtFecha.Value = Persistent.Emision;
            chkVerReporte.Checked = Persistent.Empresa.VerReporte;
            if (Persistent.Cliente != null) cmbTipo.SelectedItem = Persistent.Tipo;
            cmbPago.SelectedItem = Persistent.TipoPago;
            txtObservaciones.Text = Persistent.Observaciones;
            txtDescuentoCalc.Text = Persistent.Descuento.ToString();
            dcCliente.Selected = Persistent.Cliente;
			//auxCliente utilizado par apoder evaluar el PersitentChanged
			auxCliente = Persistent.Cliente;
            txtCAE.Text = Persistent.CAE;
			chkPagado.Checked = Persistent.Pagado;
			FillTotales();
            base.FillControls();

            
        }
        
        protected void FillTotales()
        {
            txtPercepciones.Text = Persistent.Percepciones.ToString("#0.#0");
            txtIva1.Text = Persistent.Iva1.ToString("#0.#0");
            txtIva2.Text = Persistent.Iva2.ToString("#0.#0");
            txtSubtotalAImp.Text = Persistent.SubtotalAImp.ToString("#0.#0");
            txtTotal.Text = Persistent.Total.ToString("#0.#0");
        }
        protected override void FillObject() {
            
            Persistent.Emision = txtFecha.Value;
            Persistent.Tipo = (TiposComprobantes) cmbTipo.SelectedItem;
            Persistent.TipoPago = (TiposPago)cmbPago.SelectedItem;
            Persistent.Observaciones = txtObservaciones.Text  ;
            Persistent.SetCliente((Clientes)dcCliente.Selected);
			//auxCliente utilizado par apoder evaluar el PersitentChanged
			auxCliente = Persistent.Cliente;
			Persistent.UserUpd = SecurityManager.Instance.UsuarioActual;
			Persistent.VerReporte = chkVerReporte.Checked;
			Persistent.Pagado = chkPagado.Checked;
			Persistent.GenerarXml = chkGenXML.Checked;
			
            base.FillObject();
        }

		public override void SetPersistentChanged()
		{
			persistentChanged |=
			!(
			Persistent.Emision == txtFecha.Value &&
			Persistent.Tipo == (TiposComprobantes)cmbTipo.SelectedItem &&
			Persistent.TipoPago == (TiposPago)cmbPago.SelectedItem &&
			((Persistent.Observaciones == null) ? "" : Persistent.Observaciones) == txtObservaciones.Text &&
			auxCliente == ((Clientes)dcCliente.Selected) &&
			Persistent.VerReporte == chkVerReporte.Checked &&
			Persistent.Pagado == chkPagado.Checked
			);
		}

        protected override void RefreshControls() {
            base.RefreshControls();
            cmbTipo.DataSource = RequirePropertyValueList("Tipo");
            cmbPago.DataSource = RequirePropertyValueList("TipoPago");
            dcCliente.DataType = typeof(Clientes);
            InicializarGrillaDetalles();

        }

        public override void EnableControls()
        {
			
			if (Persistent.IsEmitido)
			{
                FormUtils.Instance.ControlEnabler.Enable(this, false);
                btnCancel.Enabled = true;
                btnAccept.Enabled = true;
                btnReSend.Enabled = true;
				chkPagado.Enabled = true;
				lblPagado.Enabled = true;
            }
            else {
                base.EnableControls();
				chkPagado.Enabled = false;
				lblPagado.Enabled = false; 
				btnReSend.Enabled = false;
                btnEmitir.Enabled = !Persistent.IsAnulado;
            }
            
            if(Persistent.IsAnulado) {
                FormUtils.Instance.ControlEnabler.Enable(this, false);
                btnCancel.Enabled = true;
            }
            else {
                btnAnular.Enabled = Persistent.IsEmitido;
            }
			//TODO: descomentar
            //cmbTipo.Enabled = false;
			if (Persistent.Id != 0 && !Persistent.TieneRepeticion )
			{
				btnRepeticion.Enabled = true;
			}
			else
				btnRepeticion.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            if (AcceptForm())
            {
                //base.AcceptForm();
				persistentChanged = false;
                Close();
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
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
            DetallesGrid.ItemType = typeof(DetallesComprobantes);
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

        private void DetallesGrid_ResetLayout(GridEX grid, Type type)
        {
            RequireChildGridResetLayout(grid, type);
        }

        private void RefrescarTotales()
        {
            Persistent.SetCliente((Clientes)dcCliente.Selected);
            if (Persistent.Cliente != null) cmbTipo.SelectedItem = Persistent.Tipo;
            FillTotales();
        }

        private void dcCliente_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }

        private void dcCliente_ItemAssign()
        {
            if ((dcCliente.Selected != null) && (Persistent.TipoPago==null)) 
                cmbPago.SelectedItem = (dcCliente.Selected as Clientes).TipoPago;
            
            RefrescarGrillaDetalles();
        }

        private void lblEstado_DoubleClick(object sender, EventArgs e)
        {
            //if (lblEstado.Text == "EMITIDO")
            //    lblEstado.Text  = "ANULADO";
            //else
            //    lblEstado.Text  = "EMITIDO";
        }

        private void txtDescuentoCalc_Leave(object sender, EventArgs e)
        {
            Persistent.SetDescuento (Convert.ToDouble(txtDescuentoCalc.Value));
            FillTotales();
        }

        private void btnEmitir_Click(object sender, EventArgs e) {
            try
            {
                Thread thrdStatus = new Thread(new ParameterizedThreadStart(Status.CheckStatus));
                thrdStatus.IsBackground = true;
                thrdStatus.Start(((System.Windows.Forms.Form)this.MdiParent));
                
                
                string result;
                FillObject();
                if (AcceptForm())
                {
					persistentChanged = false; 
					DateTime fechaEmisionCorta = Convert.ToDateTime(Persistent.Emision.ToShortDateString());
                    DateTime fechaHoyCorta = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    DateTime fechaTopeCorta = fechaHoyCorta.AddDays(9); //Solo se pueden emitir facturas programadas con 9 dias de anticipación
                    bool fechaValida = (fechaEmisionCorta <= fechaTopeCorta) && (fechaEmisionCorta >= fechaHoyCorta);
                    if (!fechaValida)
                    {
                        MessageBox.Show("La fecha de emisión deber ser mayor o igual a la fecha actual\ny no la puede superar en más de 9 días");
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;

                    if (EmitirComprobante != null)
                    {

                        //Reloj y botón deshabilitado para que el usuario no se desespere
                        btnEmitir.Enabled = false;
                        Cursor.Current = Cursors.WaitCursor;
                        string nroComprobante;
                        Persistent.NroCbante = ObtenerNroComprobante();
						//Persistent.NroCbante = MFDService.MFDService.GetUltimoNroComprobante(Persistent).Value.ToString();
                        result = EmitirComprobante(Persistent,out nroComprobante, chkGenXML.Checked);
                        if (nroComprobante != "-1")
                        {
                            Persistent.NroCbante = nroComprobante;
                        }
                        else {
                            Persistent.NroCbante = "";
                        }
                        Cursor.Current = Cursors.Default;
                        this.btnEmitir.Enabled = true;

                        if (result != string.Empty)
                        {
                            MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            txtNumero.Text = nroComprobante;
                            txtCAE.Text = Persistent.CAE;
                            MessageBox.Show("El comprobante fue emitido exitosamente", "Emisión de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PersistirUltimoComprobante(Persistent.NroCbante);
                            AcceptForm();
							persistentChanged = false;
                            Close();

                        }

                    }
                }
            }
            catch(Exception ex)
            {
                Logger.EscribirEventLog(ex);
				MessageBox.Show(ex.Message);
            }
        }

        private void PersistirUltimoComprobante(string ultimo)
        {
            if (this.action == CRUDAction.Create)
            {
                if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaA"])
                    Persistent.Empresa.UltimaFacturaA = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaB"])
                    Persistent.Empresa.UltimaFacturaB = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaC"])
                    Persistent.Empresa.UltimaFacturaC = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoA"])
                    Persistent.Empresa.UltimaNotaDebitoA = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoB"])
                    Persistent.Empresa.UltimaNotaDebitoB = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoC"])
                    Persistent.Empresa.UltimaNotaDebitoC = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoA"])
                    Persistent.Empresa.UltimaNotaCreditoA = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoB"])
                    Persistent.Empresa.UltimaNotaCreditoB = ultimo;
                else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoC"])
                    Persistent.Empresa.UltimaNotaCreditoC = ultimo;
            }
        }
        
        private void btnAnular_Click(object sender, EventArgs e) {
            string result;
            FillObject();
            if (AcceptForm()) {
                if (AnularComprobante != null) {
                    result = AnularComprobante(Persistent);
                    if (result != "") MessageBox.Show(result);
                    
                    else Close();
                    base.AcceptForm();
                }
            }
        }

        private void btnReSend_Click(object sender, EventArgs e) {
            string result;
            FillObject();
            if (AcceptForm()) {
                if (ReenviarComprobante != null){
                    result = ReenviarComprobante(Persistent);
                    if (result != string.Empty)
                    {
                        MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("El comprobante fue enviado exitosamente", "Envío de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        base.AcceptForm();
						persistentChanged = false;
                        Close();
                    }
                }
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Persistent.Cliente != null)
            {
                if (!String.IsNullOrEmpty(Persistent.NroCbante))
                    txtNumero.Text = Persistent.NroCbante;//ObtenerNroComprobante();
            }
            else
                cmbTipo.SelectedIndex = -1;
        }

        private string ObtenerNroComprobante()
        {
			string ultimoComprobante = string.Empty;
			Persistent.Tipo = (TiposComprobantes)cmbTipo.SelectedItem;
			try
			{
				if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaA"]) ultimoComprobante = Persistent.Empresa.UltimaFacturaA;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaB"]) ultimoComprobante = Persistent.Empresa.UltimaFacturaB;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaC"]) ultimoComprobante = Persistent.Empresa.UltimaFacturaC;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoA"]) ultimoComprobante = Persistent.Empresa.UltimaNotaDebitoA;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoB"]) ultimoComprobante = Persistent.Empresa.UltimaNotaDebitoB;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoC"]) ultimoComprobante = Persistent.Empresa.UltimaNotaDebitoC;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoA"]) ultimoComprobante = Persistent.Empresa.UltimaNotaCreditoA;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoB"]) ultimoComprobante = Persistent.Empresa.UltimaNotaCreditoB;
				else if (Persistent.Tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoC"]) ultimoComprobante = Persistent.Empresa.UltimaNotaCreditoC;
				int nro;
				string[] partes = ultimoComprobante.Split(new char[] { '-' });
				if (partes.Length >= 2)
				{
					nro = Convert.ToInt32(partes[1]);
					nro++;
				}
				else
				{
					throw new Exception("Error al intentar obtener el último nro de comprobante: " + Persistent.Tipo.Nombre);
				}
				return partes[0] + "-" + nro.ToString().PadLeft(8, '0');
			}
			catch {
				throw new Exception("Error al intentar obtener el último nro de comprobante: " + Persistent.Tipo.Nombre);
			}
        }

		private void btnRepeticion_Click(object sender, EventArgs e)
		{
			Repeticiones rep = new Repeticiones();
			rep.Comprobante = this.Persistent;
			rep.Id = rep.Comprobante.Id;
			RepeticionesCRUD frmRep = new RepeticionesCRUD(rep);
			frmRep.ShowDialog();
			Persistent.TieneRepeticion = true;
			this.btnRepeticion.Enabled = false;
			this.btnRepeticion.Refresh();
		}
    }

    public delegate string ComprobanteObjectEvent(Comprobantes obj);
    public delegate string ComprobanteObjectOutEvent(Comprobantes obj, out string nroComprobante, bool generarXml);
}