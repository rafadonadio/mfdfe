using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using FrameWork.CRUDModel.Windows.UI;
namespace MFD
{
    public partial class IdDescripcionCRUD : CRUDForm
    {
        public IdDescripcionCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        new public IdDescripcion Persistent
        {
            get { return (IdDescripcion)persistent; }
            set { persistent = value; }
        }

        protected override void FillControls()
        {
            txtDescripcion.Text = Persistent.Descripcion ;
            base.FillControls();
        }

        protected override void FillObject()
        {
            Persistent.Descripcion = txtDescripcion.Text;
            base.FillObject();
        }

        public override void SetPersistentChanged()
        {
            persistentChanged =!(((Persistent.Descripcion == null) ? "" : Persistent.Descripcion) == txtDescripcion.Text);

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