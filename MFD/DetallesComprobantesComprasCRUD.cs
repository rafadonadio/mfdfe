using System;
using Entities;
using FrameWork.CRUDModel.Windows.UI;

namespace MFD {
    public partial class DetallesComprobantesComprasCRUD : CRUDChildForm {
        public DetallesComprobantesComprasCRUD() {
            InitializeComponent();
            stylesSheetManager.ApplyStyles();
        }

        new public DetallesComprobantesCompras Persistent {
            get { return (DetallesComprobantesCompras)persistent; }
        }

        new public ComprobantesCompras PersistentParent {
            get { return (ComprobantesCompras)persistentParent; }
        }

        protected override void AssignToParent() {
            Persistent.Comprobante = PersistentParent;
            PersistentParent.AddChild(Persistent);

        }

        protected override void RemoveFromParent() {
            PersistentParent.Items.Remove(Persistent);
        }

        protected override void FillObject() {
            Persistent.TipoIva = cmbTipoIva.SelectedItem as Ivas;
            Persistent.ImporteGravado = txtImporteGravado.Value;
            Persistent.ImporteNoGravado = txtImporteNoGravado.Value;
            Persistent.ImporteOperacionesExentas = txtImporteOperacionesExentas.Value;
            base.FillObject();
        }

        protected override void FillControls() {
            cmbTipoIva.SelectedItem = Persistent.TipoIva;
            txtImporteGravado.Value = Persistent.ImporteGravado;
            txtImporteNoGravado.Value = Persistent.ImporteNoGravado;
            txtImporteOperacionesExentas.Value = Persistent.ImporteOperacionesExentas;
        }

        protected override void RefreshControls() {
            base.RefreshControls();
            cmbTipoIva.DataSource = RequirePropertyValueList("TipoIva");
        }

		public override void SetPersistentChanged()
		{
			persistentChanged = false;
		}
		
		private void btnAccept_Click(object sender, EventArgs e)
		{
            if (AcceptForm()) Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}