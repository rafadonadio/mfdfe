using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace MFD
{
    public partial class TestConexion : Form
    {
        public TestConexion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChequearConexion();
            ChequearWS();
        }

        private void ChequearWS()
        {
            if (ChequearUrl("https://servicios1.afip.gov.ar/wsfe/service.asmx"))
            {
                lblWs.Text = "Está disponible el ws";
            }
            else
            {
                lblWs.Text = "No está disponible el ws";
            }
        }

        private void ChequearConexion()
        {
            if(ChequearUrl("http://www.google.com"))
            {
                lblConexion.Text = "Hay conexion";
            }
            else
            {
                lblConexion.Text = "No hay conexion";
            }
        }
        private bool ChequearUrl(string url)
        {
            HttpWebRequest req;
            HttpWebResponse resp;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                resp = (HttpWebResponse)req.GetResponse();

                if (resp.StatusCode.ToString().Equals("OK"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}