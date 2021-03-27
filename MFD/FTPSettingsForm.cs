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
    public partial class FTPSettingsForm : Form
    {
        public event ObjectEvent SaveObject;
        protected FTPSettings setting;

        public FTPSettings Setting
        {
            get { return setting; }
            set { setting = value; }
        }
        
        public FTPSettingsForm()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            FillObject();
            if (SaveObject != null)
                SaveObject(setting);
            Hide(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide(); 
        }

        protected void FillObject()
        {
            Setting.Host = txtHost.Text;
            Setting.Port = Convert.ToInt32 (txtPort.Text);
            Setting.User = txtUser.Text;
            Setting.Pass = txtPass.Text;
        }
        protected void FillControls()
        {
            txtHost.Text = Setting.Host;
            txtPort.Text = Setting.Port.ToString() ;
            txtUser.Text = Setting.User;
            txtPass.Text = Setting.Pass;
        }

        public void Open() 
        {
            FillControls();
            Show(); 
        }

    }


}