using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace MFD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        public event LoginEvent AcceptLogin;
        public bool Canceled;
        protected Usuarios  usuario;

        public Usuarios Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        

        private void btnAccept_Click(object sender, EventArgs e)
        {
            FillObject();
            if (AcceptLogin != null)
            {    
                if (AcceptLogin(usuario))
                { 
                    Close(); 
                }
                else
                { 
                    MessageBox.Show("El nombre de usuario y/o la contraseña son incorrectos"); 
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            Close(); 
        }

        protected void FillObject()
        {
            Usuario.Password = txtPass.Text;
            Usuario.Nombre = txtUser.Text;
        }
        public void Open() 
        {            
            txtPass.Text = "";
            txtUser.Text = "";
			//if (System.Security.Principal.WindowsIdentity.GetCurrent().Name == @"KARENINA\Vero") {
			//    txtPass.Text = "nimda";
			//    txtUser.Text = "admin";
			//}
			this.ActiveControl = txtUser; 
            ShowDialog(); 
        }

    }
    public delegate Boolean LoginEvent(Usuarios obj);
}
