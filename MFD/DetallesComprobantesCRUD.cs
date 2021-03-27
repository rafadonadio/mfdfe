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
using MFD.Clases;

namespace MFD
{
    public partial class DetallesComprobantesCRUD : CRUDChildForm
    {
        public DetallesComprobantesCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        protected override void FillObject()
        {
            base.FillObject();
            Persistent.Producto = (Productos)dcProducto.Selected;
            if (Persistent.Producto != null)
            {
                Persistent.ImpUnitarioNetoSistema = Persistent.Producto.Impmc;
                Persistent.TipoIva = Persistent.Producto.TipoIva;
            }
            Persistent.Cantidad = Convert.ToInt32(txtCantidad.Value);
            Persistent.ImpUnitarioNeto = Convert.ToDouble (txtImporteUnitario.Text);
            Persistent.ImpTotalNeto = Persistent.Cantidad * Persistent.ImpUnitarioNeto;
            Persistent.UserUpd = SecurityManager.Instance.UsuarioActual;  
        }

        protected override void FillControls()
        {
            dcProducto.Selected = Persistent.Producto;
            txtCantidad.Text = Persistent.Cantidad.ToString();
            txtImporteUnitario.Text = Persistent.ImpUnitarioNeto.ToString();
			txtImporteUnitarioForm.Text = Persistent.ImpUnitarioForm.ToString();
        }
        protected override void AssignToParent()
        {
            Persistent.Comprobante = PersistentParent;
            PersistentParent.AddChild(Persistent);

        }

        protected override void RemoveFromParent()
        {
            PersistentParent.Items.Remove(Persistent);
        }

        new public DetallesComprobantes Persistent
        {
            get { return (DetallesComprobantes)persistent; }
        }

        new public Comprobantes PersistentParent
        {
            get { return (Comprobantes)persistentParent; }
        }

		public override void SetPersistentChanged()
		{
			persistentChanged = false;
		}
        private void btnAccept_Click(object sender, EventArgs e)
        {
			if (AcceptForm())
			{
				Close();
			}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dcProducto_Load(object sender, EventArgs e)
        {
            dcProducto.DataType = typeof(Productos);
        }

        private void dcProducto_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }

        private void dcProducto_ItemAssign()
        {
			if (dcProducto.Selected != null) //&& (Convert.ToDouble (txtImporteUnitario.Text) == 0))
			{
				Productos producto = dcProducto.Selected as Productos;
				txtImporteUnitario.Text = producto.Impmc.ToString();
				if(PersistentParent.Cliente.TipoContribuyente.ComputaIVA && !PersistentParent.Cliente.TipoContribuyente.DiscriminaIVA){
					txtImporteUnitarioForm.Text = (producto.Impmc * (1 + producto.TipoIva.Alicuota / 100)).ToString();
				}
				else{
					txtImporteUnitarioForm.Text = producto.Impmc.ToString();
				
				}
			}

        }

		private void txtImporteUnitarioForm_Validated(object sender, EventArgs e)
		{
			if (PersistentParent.Cliente.TipoContribuyente.ComputaIVA && !PersistentParent.Cliente.TipoContribuyente.DiscriminaIVA)
			{
				Productos producto = dcProducto.Selected as Productos;
				txtImporteUnitario.Text = Math.Round( (Convert.ToDouble(txtImporteUnitarioForm.Text) / (1 + producto.TipoIva.Alicuota / 100)), 2).ToString();
			}
			else {
				txtImporteUnitario.Text = txtImporteUnitarioForm.Text;
			}
		}
    }
}