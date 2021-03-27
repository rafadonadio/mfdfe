using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;
using Security;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.CRUDModel.Windows;

namespace MFD
{
    public partial class UsuariosCRUD : CRUDForm
    {

        public UsuariosCRUD()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }
        new public Usuarios Persistent
        {
            get { return (Usuarios)persistent; }
            set { persistent = value; }
        }
        protected override void FillControls()
        {
            txtUserName.Text = Persistent.Nombre;
            txtPassword.Text = Persistent.Password;
            cmbPerfil.SelectedItem = Persistent.UserGroup;
            base.FillControls();
        }

        protected override void FillObject()
        {
            Persistent.Nombre = txtUserName.Text;
            Persistent.Password = txtPassword.Text;
            Persistent.UserGroup = cmbPerfil.SelectedItem as UsersGroups;  
            base.FillObject();
        }

		public override void SetPersistentChanged()
		{
			persistentChanged =
			!(
            ((Persistent.Nombre == null) ? "" : Persistent.Nombre) == txtUserName.Text &&
            ((Persistent.Password == null) ? "" : Persistent.Password) == txtPassword.Text &&
            Persistent.UserGroup == (cmbPerfil.SelectedItem as UsersGroups)
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
            cmbPerfil.DataSource = RequirePropertyValueList("UserGroup");
        }
    }
}