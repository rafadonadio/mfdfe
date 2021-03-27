using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using MFD.Clases;
using FrameWork.CRUDModel.Windows.UI;

namespace MFD
{
    public partial class ProductosCRUD : CRUDForm
    {
        public ProductosCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        new public Productos Persistent
        {
            get { return (Productos)persistent; }
            set { persistent = value; }
        }

        protected override void FillControls()
        {
            txtIdentificacion.Text = Persistent.Identificacion;
            txtNombre.Text = Persistent.Nombre;
            txtImporte.Text = Persistent.Impmc.ToString();
            cmbIva.SelectedItem = Persistent.TipoIva;  
            dcClase.Selected = Persistent.Clase;
            dcRubro.Selected = Persistent.Rubro;
            base.FillControls();
        }

        protected override void FillObject()
        {
            Persistent.Identificacion = txtIdentificacion.Text;
            Persistent.Nombre = txtNombre.Text;
            Persistent.Impmc = Convert.ToDouble(txtImporte.Value);
            Persistent.TipoIva = (Ivas) cmbIva.SelectedItem ;
            Persistent.Clase = (Entities.Clases)dcClase.Selected;
            Persistent.Rubro = (Rubros) dcRubro.Selected;
            Persistent.UserUpd = SecurityManager.Instance.UsuarioActual;
            base.FillObject();
        }

        public override void SetPersistentChanged()
        {
            persistentChanged =
            !(
                ((Persistent.Identificacion == null) ? "" : Persistent.Identificacion) == txtIdentificacion.Text &&
                ((Persistent.Nombre == null) ? "" : Persistent.Nombre) == txtNombre.Text &&
                Persistent.Impmc == Convert.ToDouble(txtImporte.Value) &&
                Persistent.TipoIva == (Ivas) cmbIva.SelectedItem  &&
                Persistent.Clase == (Entities.Clases)dcClase.Selected &&
                Persistent.Rubro == (Rubros) dcRubro.Selected
            );

        }

        protected override void RefreshControls()
        {
            base.RefreshControls();
            cmbIva.DataSource = RequirePropertyValueList("TipoIva");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AcceptForm()) Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dcClase_Load(object sender, EventArgs e)
        {
            dcClase.DataType = typeof(Entities.Clases);

        }

        private void dcClase_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);

        }

        private void dcRubro_Load(object sender, EventArgs e)
        {
            dcRubro.DataType = typeof(Rubros);
        }

        private void dcRubro_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);

        }






    }
}