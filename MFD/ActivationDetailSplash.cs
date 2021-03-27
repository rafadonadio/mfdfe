using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MFD
{
    public partial class ActivationDetailSplash : Form {
        public ActivationDetailSplash()
        {
            InitializeComponent();
            stylesSheetManager.ApplyStyles();
        }
        
        public void Open (string message, int displayTime) {
            lblMessage.Text = message;
            tmrTimeout.Interval = displayTime*1000;
            tmrTimeout.Enabled = true;
            ShowDialog();
        }

        private void tmrTimeout_Tick(object sender, EventArgs e) {
            Close();
        }
    }
}