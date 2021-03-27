using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
	[ColumnAttributes("CompTipo", true, 1, 10, "Tipo"),
	ColumnAttributes("NroComp", true, 2, 10, "NroComp"),
	ColumnAttributes("Hasta", true, 3, 10, "Hasta", "dd/MM/yyyy"),
	ColumnAttributes("DiaMes", true, 4, 5, "DiaMes")]
	[Serializable]
	public class Repeticiones : Persistent 
    {
		/*private static Repeticiones instance = null;

		public static Repeticiones Instance
		{
			get
			{
				if (instance == null) instance = new Repeticiones();
				return instance;
			}
		}
		protected void SetInstance(Repeticiones s)
		{
			if (s is Repeticiones) instance = s as Repeticiones;
		}
		protected Repeticiones GetInstance()
		{
			return instance;
		}

		*/

		//public Repeticiones() : base() {
		//    int i = 0;
		//}

		
		/*private Int32 idComprobante;
		public Int32 IdComprobante
		{
			get { return idComprobante; }
			set { idComprobante = value; }
		}*/
		
		public String CompTipo
		{
			get { return comprobante.Tipo.Nombre; }
		}
		public String CompLetra
		{
			get { return comprobante.Letra.ToString(); }
		}
		public String NroComp
		{
			get { return comprobante.NroCbante; }
		}

		private Comprobantes comprobante;
		public Comprobantes Comprobante
		{
			get { return comprobante; }
			set { comprobante = value; }
		}

		private Int32 diaMes=1;
		public Int32 DiaMes
		{
			get { return diaMes; }
			set { diaMes = value; }
		}
		
		private DateTime hasta = DateTime.Today.AddMonths(6);
		public DateTime Hasta
		{
			get { return hasta; }
			set { hasta = value; }
		}
	}
}
