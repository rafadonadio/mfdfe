using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeneradorClaves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            String serial = "";
            int total = 0;

            Random rnd = new Random();

            for (int i = 1; i <= 9; i++)
            {
                serial += Convert.ToChar(rnd.Next(65, 90));
            }

            foreach (char letra in serial)
            {
                total += Convert.ToInt32(Char.ToUpper(letra));
            }

            serial += Convert.ToChar(65 + (total % 26));

            txtKey.Text = serial;
        }
    }
}