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
    public partial class EnterSerialKey : Form
    {
        public string sMessage;
        public bool bCancelPressed;

        public EnterSerialKey()
        {
            InitializeComponent();
            this.stylesSheetManager.ApplyStyles();
        }

        public event StringEventReturnBool AcceptSerialKey;

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (AcceptSerialKey != null)
            {
                if (AcceptSerialKey(txtSerialKey.Text))
                {
                    MessageBox.Show("Ha ingresado el Serial correctamente."); 
                    Close(); 
                }
                else
                { 
                    MessageBox.Show("El Serial ingresado no es correcto."); 
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bCancelPressed = true;
            Close();
        }

        public void Open() 
        {            
            ShowDialog(); 
        }
        
        public delegate Boolean StringEventReturnBool(String str);

        private void EnterSerialKey_Load(object sender, EventArgs e)
        {
            txtSerialKey.Text = Licenses.Instance.Serial;
            lblMessage.Text = sMessage;

        }

    }    
}