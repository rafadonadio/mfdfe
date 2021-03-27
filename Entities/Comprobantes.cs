using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;
using Security;
namespace Entities
{
	[ColumnAttributes("Emision", true, 1, 10, "Emisión", "dd/MM/yyyy"),
	ColumnAttributes("SupertipoGrilla", true, 2, 10, "Comprobante"),
	ColumnAttributes("Letra", true, 3, 4),
	ColumnAttributes("NroCbante", true, 4, 15, "Número"),
	ColumnAttributes("NombreCliente", true, 5, 15, "Cliente"),
	ColumnAttributes("CUITCliente", true, 6, 15, "CUIT"),
	ColumnAttributes("EstadoGrilla", true, 7, 10, "Estado"),
	ColumnAttributes("CAE", true, 8, 10)
	]
	public class Comprobantes : Persistent
	{
		//,	 ColumnAttributes("Observaciones", true, 8, 10, "EstadoGrilla")
		public const string EstadoPendiente = "PENDIENTE";
		public const string EstadoEmitido = "EMITIDO";
		public const string EstadoAnulado = "ANULADO";

		private TiposComprobantesList supertipo;
		private TiposComprobantes tipo;
		private String nrocbante;
		private DateTime emision;
		private Clientes cliente;
		private Empresas empresa;
		private TiposPago tipoPago;
		private Boolean verReporte;

		private String nombreCliente;
		private String cuitCliente;
		private Boolean enDolares;
		private TiposContribuyentes tipoCliente;
		private String estado;

		private String observaciones;
		private Double percepciones;
		private Double descuento;
		private Double subtotalneto;
		private Double subtotalaimp;
		private Double subtotalForm;
		private Double iva1;
		private Double iva2;
		private Double iva1Form;
		private Double iva2Form;
		private Double subtotal;
		private Double total;

		private Usuarios userUpd;
		private IList<DetallesComprobantes> items;
		private string cae;
		private Nullable<DateTime> anulacion;
		private Int64? idCabeceraWS;
		private Boolean pagado;
		private Int64? idRepeticion;
		private Boolean tieneRepeticion;
		private Boolean generarXml;



		public Comprobantes()
			: base()
		{
			Items = new List<DetallesComprobantes>();
			emision = DateTime.Now;
			estado = EstadoPendiente;
			anulacion = null;
		}

		public IList<DetallesComprobantes> Items
		{
			get { return items; }
			set { items = value; }
		}

		public Clientes Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}

		public void SetCliente(Clientes c)
		{
			cliente = c;
			if (cliente != null)
			{
				nombreCliente = cliente.Nombre;
				cuitCliente = cliente.CUIT;
				tipoCliente = cliente.TipoContribuyente;
				enDolares = cliente.EnDolares;
				switch (supertipo)
				{
					case TiposComprobantesList.Factura:
						tipo = cliente.TipoContribuyente.TipoComprobanteFactura;
						break;
					case TiposComprobantesList.NotaCredito:
						tipo = cliente.TipoContribuyente.TipoComprobanteNotaCredito;
						break;
					case TiposComprobantesList.NotaDebito:
						tipo = cliente.TipoContribuyente.TipoComprobanteNotaDebito;
						break;
				}
			}
			CalcularTotales(this);
		}

		public void SetDescuento(Double desc)
		{
			descuento = desc;
			CalcularTotales(this);
		}

		public DateTime Emision
		{
			get { return emision; }
			set { emision = value; }
		}
		public TiposComprobantes Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}
		public Char Letra
		{
			get
			{
				if (Tipo != null)
					return Tipo.Letra;
				else
					return ' ';
			}
		}
		public string SupertipoGrilla
		{
			get
			{
				if (Supertipo == TiposComprobantesList.Factura)
					return "Factura";
				if (Supertipo == TiposComprobantesList.NotaCredito)
					return "Nota de Crédito";
				if (Supertipo == TiposComprobantesList.NotaDebito)
					return "Nota de Débito";
				return "";
			}
		}

		public TiposComprobantesList Supertipo
		{
			get { return supertipo; }
			set { supertipo = value; }
		}
		public String NroCbante
		{
			get { return nrocbante; }
			set { nrocbante = value; }
		}
		public String Observaciones
		{
			get { return observaciones; }
			set { observaciones = value; }
		}
		public Double Percepciones
		{
			get { return percepciones; }
			set { percepciones = value; }
		}
		public Double Descuento
		{
			get { return descuento; }
			set { descuento = value; }
		}
		public Double SubtotalNeto
		{
			get { return subtotalneto; }
			set { subtotalneto = value; }
		}
		public Double SubtotalAImp
		{
			get { return subtotalaimp; }
			set { subtotalaimp = value; }
		}
		public Double SubtotalForm
		{
			get { return Math.Round(subtotalForm, 2); }
			set { subtotalForm = value; }
		}
		public Double Iva1
		{
			get { return iva1; }
			set { iva1 = value; }
		}
		public Double Iva2
		{
			get { return iva2; }
			set { iva2 = value; }
		}
		public Double Iva1Form
		{
			get { return Math.Round(iva1Form, 2); }
			set { iva1Form = value; }
		}
		public Double Iva2Form
		{
			get { return Math.Round(iva2Form, 2); }
			set { iva2Form = value; }
		}
		public Double Subtotal
		{
			get { return subtotal; }
			set { subtotal = value; }
		}
		public Double Total
		{
			get { return total; }
			set { total = value; }
		}

		public String NombreCliente
		{
			get { return nombreCliente; }
			set { nombreCliente = value; }
		}
		public String CUITCliente
		{
			get { return cuitCliente; }
			set { cuitCliente = value; }
		}

		public Boolean EnDolares
		{
			get { return enDolares; }
			set { enDolares = value; }
		}

		public TiposContribuyentes TipoCliente
		{
			get { return tipoCliente; }
			set { tipoCliente = value; }
		}

		public String Estado
		{
			get { return estado; }
			protected set
			{ estado = value; }
		}
		public String EstadoGrilla
		{
			get
			{
				if (pagado)
					return "PAGADO";
				else
					return estado;
			}


		}

		public bool IsEmitido
		{
			get { return (Estado == EstadoEmitido); }
		}

		public bool IsAnulado
		{
			get { return (Estado == EstadoAnulado); }
		}

		public void Emitir()
		{
			Estado = EstadoEmitido;
		}

		public void Anular()
		{
			Estado = EstadoAnulado;
			anulacion = DateTime.Now;
		}

		public Empresas Empresa
		{
			get { return empresa; }
			set { empresa = value; }
		}
		public Boolean VerReporte
		{
			get { return verReporte; }
			set { verReporte = value; }
		}
		public TiposPago TipoPago
		{
			get { return tipoPago; }
			set { tipoPago = value; }
		}
		public Usuarios UserUpd
		{
			get { return userUpd; }
			set { userUpd = value; }
		}
		public string CAE
		{
			get { return cae; }
			set { cae = value; }
		}

		public DateTime? Anulacion
		{
			get { return anulacion; }
			set { anulacion = value; }
		}

		public Int64? IdCabeceraWS
		{
			get { return idCabeceraWS; }
			set { idCabeceraWS = value; }
		}

		public Boolean Pagado
		{
			get { return pagado; }
			set { pagado = value; }
		}
		public Int64? IdRepeticion
		{
			get { return idRepeticion; }
			set { idRepeticion = value; }
		}

		public Boolean TieneRepeticion
		{
			get { return tieneRepeticion; }
			set
			{
				if ((Boolean)value == null)
				{
					tieneRepeticion = false;
				}
				else
				{
					tieneRepeticion = value;
				}
			}
		}

		public Boolean GenerarXml
		{
			get { return generarXml; }
			set { generarXml = value; }
		}

		public void AddChild(DetallesComprobantes det)
		{
			if (!items.Contains(det))
				items.Add(det);

			CalcularTotales(this);
		}

		public void CalcularTotales(Comprobantes comp)
		{
			// Se inicializan las variables de totales
			comp.SubtotalNeto = 0;
			comp.SubtotalAImp = 0;
			comp.Iva1 = 0;
			comp.Iva2 = 0;
			comp.Subtotal = comp.SubtotalForm = 0;
			comp.Total = 0;

			foreach (DetallesComprobantes item in comp.Items)
			{
				comp.SubtotalNeto += item.ImpTotalNeto;
				comp.SubtotalAImp += item.ImpTotal;

				if (comp.Cliente != null)
				{
					if (comp.Cliente.TipoContribuyente.ComputaIVA)
					{
						if (item.TipoIva != null)
						{
							if (item.TipoIva.Id == comp.Empresa.Iva1.Id)
							{
								comp.Iva1 += item.ImpTotalNeto * item.TipoIva.Alicuota / 100;
							}
							else
							{
								comp.Iva2 += item.ImpTotalNeto * item.TipoIva.Alicuota / 100;
							}
							if (comp.Cliente.TipoContribuyente.ComputaIVA && !comp.Cliente.TipoContribuyente.DiscriminaIVA)
							{
								comp.subtotalForm += item.ImpTotalNeto + (item.ImpTotalNeto * item.TipoIva.Alicuota / 100);
							}
							else
							{ // No discriminaIVA
								comp.subtotalForm = comp.SubtotalAImp;
							}
						}
					}
					else
					{ // No computaIVA
						comp.subtotalForm = comp.SubtotalAImp;
					}
				}
			}
			comp.SubtotalNeto = comp.SubtotalNeto * (1 - comp.Descuento / 100);
			comp.SubtotalAImp = comp.SubtotalAImp * (1 - comp.Descuento / 100);
			comp.Iva1 = comp.Iva1 * (1 - comp.Descuento / 100);
			comp.Iva2 = comp.Iva2 * (1 - comp.Descuento / 100);
			if (comp.Cliente != null && !comp.Cliente.TipoContribuyente.DiscriminaIVA)
			{
				comp.iva1Form = 0;
				comp.iva2Form = 0;
			}
			else {
				comp.iva1Form = comp.Iva1;
				comp.iva2Form = comp.Iva2;
			}
			{ }

			if (comp.Cliente != null)
			{
				if ((comp.SubtotalNeto > comp.Empresa.MontoMinimoPerc) && (comp.Cliente.TipoContribuyente.Percepciones) && (!comp.Cliente.IibbExento))
					comp.Percepciones = comp.SubtotalNeto * comp.Empresa.PorcentajePerc / 100;
				else
					comp.Percepciones = 0;

				comp.cuitCliente = Cliente.CUIT;
				comp.nombreCliente = Cliente.Nombre;
				comp.tipoCliente = Cliente.TipoContribuyente;
			}
			else
				comp.Percepciones = 0;

			comp.Subtotal = comp.SubtotalAImp + comp.Iva1 + comp.Iva2 + comp.Percepciones;
			comp.Total = comp.Subtotal;
		}
		public string GetFileName(string extension)
		{
			return string.Format(tipo.Nombre + "_{0}_{1}.{2}", Emision.ToString("yyyyMMdd"), NroCbante, extension);
		}
		public string GetFileNameDetalle(string extension)
		{
			return string.Format("DETALLE_{0}.{1}", Emision.ToString("yyyyMM"), extension);
		}

		public string GetFileNameDetalle()
		{
			return GetFileNameDetalle("TXT");
		}

		public string GetFileNameCabecera()
		{
			return string.Format("CABECERA_{0}.TXT", Emision.ToString("yyyyMM"));
		}

	}
}
