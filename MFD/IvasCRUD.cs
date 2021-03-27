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
    public partial class IvasCRUD : CRUDForm
    {
        public IvasCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        protected override void FillObject()
        {
            base.FillObject();
            Persistent.Descripcion = txtDescripcion.Text;
            Persistent.Alicuota = txtAlicuota.Value ;
        }

        public override void SetPersistentChanged()
        {
            persistentChanged =
            !(
                ((Persistent.Descripcion == null) ? "" : Persistent.Descripcion) == txtDescripcion.Text &&
				Persistent.Alicuota == txtAlicuota.Value 
            );
        }

        protected override void FillControls()
        {
            txtDescripcion.Text = Persistent.Descripcion;
            txtAlicuota.Text = Persistent.Alicuota.ToString(); 

        }

        new public Ivas Persistent
        {
            get { return (Ivas)persistent; }
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

    }
}