using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MFD
{
	public partial class Splash : Form
	{
		public Splash()
		{
			InitializeComponent();
		}
		public string TextoContador { get { return lblContadorProgreso.Text; } set { lblContadorProgreso.Text = value;} }
	}
}
