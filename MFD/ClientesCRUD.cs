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
    public partial class ClientesCRUD : CRUDForm
    {
        public ClientesCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        new public Clientes Persistent
        {
            get { return (Clientes)persistent; }
            set { persistent = value; }
        }

        protected override void FillControls()
        {
            lblId.Text = Persistent.Cliente;
            
            txtNombre.Text = Persistent.Nombre;
            txtCUIT.Text = Persistent.CUIT;
            txtEmail.Text = Persistent.Email;
            dcClase.Selected = Persistent.Clase;
            dcTipoContribuyente.Selected = Persistent.TipoContribuyente;
            dcTipoPago.Selected = Persistent.TipoPago;
            txtDomicilio.Text = Persistent.Domicilio;
            txtLocalidad.Text = Persistent.Localidad;
            txtTelefonos.Text = Persistent.Telefonos;
            dcProvincia.Selected = Persistent.Provincia;
            dcPais.Selected = Persistent.Pais;
            chkIIBBExcento.Checked = Persistent.IibbExento;
            txtCodigoPostal.Text = Persistent.CodigoPostal;
			chkEnDolares.Checked = Persistent.EnDolares; 
			base.FillControls();
        }

        protected override void FillObject()
        {
            Persistent.Nombre = txtNombre.Text;
            Persistent.CUIT = txtCUIT.Text;
            Persistent.Email = txtEmail.Text;
            Persistent.Clase = (Entities.Clases) dcClase.Selected;
            Persistent.TipoContribuyente = (TiposContribuyentes)dcTipoContribuyente.Selected;
            Persistent.TipoPago = (TiposPago)dcTipoPago.Selected;
            Persistent.Domicilio = txtDomicilio.Text;
            Persistent.Localidad = txtLocalidad.Text;
            Persistent.Telefonos = txtTelefonos.Text;
            Persistent.Provincia = (Provincias)dcProvincia.Selected;
            Persistent.Pais = (Paises)dcPais.Selected; 
            Persistent.FiltraClase = false;
            Persistent.IibbExento = chkIIBBExcento.Checked;
            Persistent.CodigoPostal = txtCodigoPostal.Text;
			Persistent.EnDolares = chkEnDolares.Checked;
			Persistent.UserUpd = SecurityManager.Instance.UsuarioActual;
            base.FillObject();
        }

        public  override void SetPersistentChanged()
        {
            persistentChanged =
            !(
			((Persistent.Nombre == null) ? "" : Persistent.Nombre) == txtNombre.Text &&
			((Persistent.CUIT == null) ? txtCUIT.MaskedTextProvider.ToString() : Persistent.CUIT) == txtCUIT.Text &&
            ((Persistent.Email == null) ? "" : Persistent.Email) == txtEmail.Text &&
            Persistent.Clase == (Entities.Clases)dcClase.Selected &&
            Persistent.TipoContribuyente == (TiposContribuyentes)dcTipoContribuyente.Selected &&
            Persistent.TipoPago == (TiposPago)dcTipoPago.Selected &&
            ((Persistent.Domicilio == null) ? "" : Persistent.Domicilio) == txtDomicilio.Text &&
            ((Persistent.Localidad == null) ? "" : Persistent.Localidad) == txtLocalidad.Text &&
            ((Persistent.Telefonos == null) ? "" : Persistent.Telefonos) == txtTelefonos.Text &&
            Persistent.Provincia == (Provincias)dcProvincia.Selected &&
            Persistent.Pais == (Paises)dcPais.Selected &&
            Persistent.IibbExento == chkIIBBExcento.Checked &&
			((Persistent.CodigoPostal == null) ? "" : Persistent.CodigoPostal) == txtCodigoPostal.Text &&
            Persistent.EnDolares == chkEnDolares.Checked 
			);

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
        }

        private void dcClase_Load(object sender, EventArgs e)
        {
            dcClase.DataType = typeof(Entities.Clases);
        }

        private void dcClase_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }

        private void dcTipoContribuyente_Load(object sender, EventArgs e)
        {
            dcTipoContribuyente.DataType = typeof(TiposContribuyentes);
        }

        private void dcTipoContribuyente_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }

        private void dcTipoPago_Load(object sender, EventArgs e)
        {
            dcTipoPago.DataType = typeof(TiposPago);
        }

        private void dcTipoPago_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }

        private void dcProvincia_Load(object sender, EventArgs e)
        {
            dcProvincia.DataType = typeof(Provincias);
        }

        private void dcPais_Load(object sender, EventArgs e)
        {
            dcPais.DataType = typeof(Paises);
        }

        private void dcPais_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }

        private void dcProvincia_BrowseClick(DataCombo dc, Type dataType)
        {
            RequireGridSel(dc, dataType);
        }
    }
}