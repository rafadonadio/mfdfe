using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Entities;
using FrameWork.Tools.Validation;
using NHibernate;
using NHibernate.Expression;
using Security;

namespace BusinessLogic
{
	[Serializable]
	public class ModuloComprobantes : Modules
	{
		public ModuloComprobantes() { }
	}

	public class ComprobantesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
	{
		protected TiposComprobantesList tipo = TiposComprobantesList.Factura;
		IList<TiposComprobantesList> tipos;
		protected string estado = null;
		protected bool emisionHoy = false;
		public void SetTiposFilter(IList<TiposComprobantesList> tipos)
		{
			this.tipos = tipos;
		}

		public void SetEstadoFilter(string estado)
		{
			this.estado = estado;
		}
		public void SetEmisionHoyFilter()
		{
			this.emisionHoy = true;
		}

		public override IList GetDataSource()
		{
			ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
			if (tipos == null || tipos.Count == 0)
			{
				crit.Add(new EqExpression("Supertipo", tipo));
			}
			else if (tipos.Count == 1)
			{
				crit.Add(new EqExpression("Supertipo", tipos[0]));
			}
			else
			{
				/*EqExpression eqTipo1 =  new EqExpression("Supertipo", tipo);
				EqExpression eqTipoNC = new EqExpression("Supertipo", TiposComprobantesList.NotaCredito);
				OrExpression orExp = new OrExpression(eqTipo1, eqTipoNC);
				crit.Add(orExp);*/

				if (tipos.Count > 1) {
					OrExpression orExp = null;
					ICriterion eqTipo1;
					EqExpression eqTipo2;
					int i = 0;
					for (int j = 0; j < tipos.Count - 1; j++ )
					{
						if (orExp == null)
						{
							eqTipo1 = new EqExpression("Supertipo", tipos[j]);
						}
						else {
							eqTipo1 = orExp;
						}
						eqTipo2 = new EqExpression("Supertipo", tipos[j+1]);
						orExp = new OrExpression(eqTipo1, eqTipo2);
					}
					crit.Add(orExp);
					/*EqExpression eqTipo1 =  new EqExpression("Supertipo", tipo);
					EqExpression eqTipoNC = new EqExpression("Supertipo", TiposComprobantesList.NotaCredito);
					OrExpression orExp = new OrExpression(eqTipo1, eqTipoNC);
					crit.Add(orExp);*/
				
				}
			}
			
			if (!String.IsNullOrEmpty(estado)) {
				crit.Add(new EqExpression("Estado", estado));
			}
			if (emisionHoy)
			{
				DateTime fechaDesde = DateTime.Now.Date;
				DateTime fechaHasta = DateTime.Now.Date.AddDays(1);
				crit.Add(Expression.Between("Emision", fechaDesde, fechaHasta));
            
			}
			emisionHoy = false;
			return crit.List();
		}

		public override object GetModule()
		{
			return new ModuloComprobantes();
		}

		public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages)
		{
			bool result = base.RequiredFieldsValidator(persistentObject, messages);
			Comprobantes comprobante = persistentObject as Comprobantes;
			result &= new RequiredFieldValidator(messages).Validate(comprobante.Tipo, "Debe ingresar un Tipo");
			result &= new RequiredFieldValidator(messages).Validate(comprobante.TipoPago, "Debe ingresar un Tipo de Pago");
			result &= new RequiredFieldValidator(messages).Validate(comprobante.Cliente, "Debe ingresar un Cliente");
			DateTime fechaEmisionCorta = Convert.ToDateTime(comprobante.Emision.ToShortDateString());
			DateTime fechaHoyCorta = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			/*bool fechaValida = (fechaEmisionCorta >= fechaHoyCorta) ;
			if(!fechaValida ){
				messages.Add("La fecha de emisión deber ser mayor o igual a la fecha actual");
			}
			result &= fechaValida;*/
			return result;
		}

		public override bool BusinessValidator(Persistent persistentObject, ErrorMessages messages)
		{
			// bool result = base.BusinessValidator(persistentObject, messages);
			bool result = true;
			return result;
		}

		public override Type PersistentType
		{
			get { return typeof(Comprobantes); }
		}

		public override Type DTOType
		{
			get { return typeof(ComprobantesDTO); }
		}

		public override IList GetDTODataSource(DateTime fechaDesde, DateTime fechaHasta)
		{

			ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);

			//se quita un día a la fecha desde para que el between tome bien
			crit.Add(new BetweenExpression("Emision", fechaDesde.Subtract(new TimeSpan(1, 0, 0, 0)), fechaHasta));
			crit.Add(new EqExpression("Estado", Comprobantes.EstadoEmitido));
			crit.AddOrder(new Order("Emision", true));

			IList resultados = crit.List();

			// en caso que el comprobante sea nota de débito el importe se resta
			//ConvertirNotasCreditoATotalesNegativos(resultados);

			// en caso que el comprobante sea nota de crédito el importe se resta
			ConvertirNotasCreditoAValoresNegativos(resultados);

			return ConvertToDTOList(resultados);
		}

		public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
		{
			bool result = base.DeleteAllowed(persistentObject, messages);
			bool isPendiente = !(((Comprobantes)(persistentObject)).IsEmitido || ((Comprobantes)(persistentObject)).IsAnulado);
			if (!isPendiente)
			{
				messages.Add("No se puede eliminar la factura, porque no tiene estado pendiente");
			}
			return (result && isPendiente);
		}

		/// <summary>
		/// Convierte los totaltes de los comprobantes del tipo nota de débito en negativos para 
		/// que resten en el reporte
		/// </summary>
		/// <param name="resultados"></param>
		private static void ConvertirNotasCreditoATotalesNegativos(IList resultados)
		{
			foreach (Entities.Comprobantes item in resultados)
			{
				if (item.Supertipo.Equals(TiposComprobantesList.NotaCredito))
					item.Total = item.Total * -1;
			}
		}

		/// <summary>
		/// Convierte los valores de los comprobantes del tipo nota de crédito en negativos para 
		/// que resten en el reporte
		/// </summary>
		/// <param name="resultados"></param>
		private static void ConvertirNotasCreditoAValoresNegativos(IList resultados)
		{
			foreach (Entities.Comprobantes item in resultados)
			{
				if (item.Supertipo.Equals(TiposComprobantesList.NotaCredito))
				{
					if (item.SubtotalAImp >= 0)
						item.SubtotalAImp = item.SubtotalAImp * -1;
					if (item.Subtotal >= 0)
						item.Subtotal = item.Subtotal * -1;
					if (item.Iva1 >= 0)
						item.Iva1 = item.Iva1 * -1;
					if (item.Iva2 >= 0)
						item.Iva2 = item.Iva2 * -1;
					if (item.Percepciones >= 0)
						item.Percepciones = item.Percepciones * -1;
					if (item.Total >= 0)
						item.Total = item.Total * -1;
				}

			}
		}


		public virtual IList GetDTODetalle(Comprobantes comp)
		{
			ArrayList list = new ArrayList();
			foreach (DetallesComprobantes item in comp.Items)
				list.Add(new DetallesComprobantesDTO(item));
			return list;
		}

		public IList GetDTODataSource(DateTime fechaDesde, DateTime fechaHasta, TipoPeriodo tipo)
		{
			FacturacionDTO fact;
			ArrayList DTOList = new ArrayList();
			IQuery query;
			String sNombreQuery;
			switch (tipo)
			{
				case TipoPeriodo.Mensual:
					sNombreQuery = "FacturacionMensual";
					break;
				case TipoPeriodo.Trimestral:
					sNombreQuery = "FacturacionTrimestral";
					break;
				case TipoPeriodo.Semestral:
					sNombreQuery = "FacturacionSemestral";
					break;
				default:
					sNombreQuery = "FacturacionMensual";
					break;
			}

			query = DBConnection.Session.GetNamedQuery(sNombreQuery);

			query.SetDateTime("FECHADESDE", fechaDesde);
			query.SetDateTime("FECHAHASTA", fechaHasta);
			query.SetAnsiString("ESTADO", Comprobantes.EstadoEmitido);
			query.SetInt32("NOTACREDITO", Convert.ToInt32(TiposComprobantesList.NotaCredito));

			foreach (Object[] ret in query.List())
			{
				fact = new FacturacionDTO();
				fact.cliente = ret[0].ToString();
				fact.facturacion = Convert.ToDouble(ret[1]);
				fact.periodo = Convert.ToInt32(ret[2]).ToString() + "/" + ret[3].ToString();
				DTOList.Add(fact);
			}
			return DTOList;

		}

		public IList GetDTODataSourcePorUsuario(DateTime fechaDesde, DateTime fechaHasta, TipoPeriodo tipo, out string empresa)
		{
			ICriteria crit = DBConnection.Session.CreateCriteria(typeof(Empresas));
			empresa = ((Entities.Empresas)((ArrayList)crit.List())[0]).RazonSocial;
			
			FacturacionUsuariosDTO fact;
			ArrayList DTOList = new ArrayList();
			IQuery query;
			String sNombreQuery;

			switch (tipo)
			{
				case TipoPeriodo.Mensual:
					sNombreQuery = "VentasUsuarioMensual";
					break;
				case TipoPeriodo.Trimestral:
					sNombreQuery = "VentasUsuarioTrimestral";
					break;
				case TipoPeriodo.Semestral:
					sNombreQuery = "VentasUsuarioSemestral";
					break;
				default:
					sNombreQuery = "VentasUsuarioMensual";
					break;
			}

			query = DBConnection.Session.GetNamedQuery(sNombreQuery);

			query.SetDateTime("FECHADESDE", fechaDesde);
			query.SetDateTime("FECHAHASTA", fechaHasta);
			query.SetAnsiString("ESTADO", Comprobantes.EstadoEmitido);
			query.SetInt32("NOTACREDITO", Convert.ToInt32(TiposComprobantesList.NotaCredito));

			foreach (Object[] ret in query.List())
			{
				fact = new FacturacionUsuariosDTO();
				fact.usuario = ret[0].ToString();
				fact.facturacion = Convert.ToDouble(ret[1]);
				fact.periodo = Convert.ToInt32(ret[2]).ToString() + "/" + ret[3].ToString();
				DTOList.Add(fact);
			}
			return DTOList;

		}

		public override Persistent GetNewInstance()
		{
			EmpresasBL empBL = new EmpresasBL();
			empBL.SetParameters(DBConnection);

			Comprobantes newComp = (Comprobantes)Activator.CreateInstance(PersistentType);
			newComp.Empresa = empBL.GetObject(GeneralSettings.Instance.IdEmpresaDefault) as Empresas;
			newComp.Supertipo = tipo;
			return newComp;
		}

		public String GetStreamDetalle(Comprobantes comp)
		{
			StringBuilder ret = new StringBuilder();

			foreach (DetallesComprobantes item in comp.Items)
			{
				//Campo 1: Tipo de Comprobante
				ret.Append(comp.Tipo.Codigo.Substring(0, 2));
				//Campo 2: Controlador Fiscal
				ret.Append(" ");
				//Campo 3: Fecha del Comprobante
				ret.Append(comp.Emision.ToString("yyyyMMdd"));
				//Campo 4: Punto de Venta
				ret.Append(comp.NroCbante.Substring(0, 4));
				//Campo 5: Número de Comprobante
				ret.Append(comp.NroCbante.Substring(5, 8));
				//Campo 6: Número de Comprobante Registrado
				ret.Append(comp.NroCbante.Substring(5, 8));
				//Campo 7: Cantidad
				ret.Append(item.Cantidad.ToString().PadLeft(7, '0').PadRight(12, '0'));
				//Campo 8: Unidad de medida
				ret.Append("07");  //UNIDAD
				//Campo 9: Precio unitario - 16 caracteres
				ret.Append((item.ImpUnitarioNeto * (1 - comp.Descuento / 100)).ToString("#0.#00").Replace(".", "").Replace(",", "").PadLeft(16, '0'));
				//Campo 10: Importe de bonificación  - 15 caracteres
				ret.Append("000000000000000");
				//Campo 11: Importe de ajuste  - 16 caracteres
				ret.Append("0000000000000000");
				//Campo 12: Subtotal por registro  - 16 caracteres 
				//precio unitario (campo 9) multiplicado por la cantidad (campo 7) , menos el importe de la bonificación si las hubiere (campo 10) más el importe de ajuste (campo 11) de corresponder
				ret.Append(((item.ImpTotalNeto * (1 - comp.Descuento / 100)) * item.Cantidad).ToString("#0.#00").Replace(".", "").Replace(",", "").PadLeft(16, '0'));
				//Campo 13: Alícuota de IVA aplicable
				ret.Append(item.TipoIva.Alicuota.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(4, '0'));
				//Campo 14: Indicación de exento o gravado
				if (item.TipoIva.Alicuota != 0) ret.Append('G');
				else ret.Append('E');
				//Campo 15: Indicación de anulación
				if (item.Comprobante.Estado == Comprobantes.EstadoAnulado) ret.Append("A");
				else ret.Append(" ");
				//Campo 16: Diseño libre (nombre del producto)
				ret.Append(item.Producto.Nombre.PadRight(75, ' '));
				//Fin de registro
				ret.Append("\r\n");// "\r\n";
			}
			return ret.ToString();
		}

		public String GetStreamUnComprobante(Comprobantes comp)
		{
			#region Registro Tipo 1
			//Registro Tipo 1
			//Campo 1: Tipo de registro
			StringBuilder ret = new StringBuilder();
			ret.Append("1");
			//Campo 2: Fecha del comprobante
			ret.Append(comp.Emision.ToString("yyyyMMdd"));
			//Campo 3: Tipo de Comprobante
			ret.Append(comp.Tipo.Codigo.Substring(0, 2));
			//Campo 4: Controlador Fiscal (no corresponde a facturacion electronica)
			ret.Append(" ");
			//Campo 5: Punto de Venta
			ret.Append(comp.NroCbante.Substring(0, 4));
			//Campo 6: Número de Comprobante
			ret.Append(comp.NroCbante.Substring(5, 8));
			//Campo 7: Número de Comprobante Registrado
			ret.Append(comp.NroCbante.Substring(5, 8));
			//Campo 8: Cantidad de Hojas 
			ret.Append("001"); //Ver si puede haber mas de una hoja
			//Campo 9: Código de documento identificatorio del comprador.
			ret.Append(comp.Tipo.Codigo);
			//Campo 10: Número de identificación del comprador
			ret.Append(comp.CUITCliente.Replace("-", "").PadRight(11, ' '));
			//Campo 11: Apellido y nombres o denominación del comprador
			ret.Append(comp.NombreCliente.PadRight(30, ' '));
			//Campo 12: Importe total de la operación
			ret.Append(comp.Total.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 13: Importe total de conceptos que no integran el precio neto gravado
			ret.Append("000000000000000");
			//Campo 14: Importe Neto Gravado
			ret.Append(comp.SubtotalNeto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 15: Impuesto liquidado
			ret.Append((comp.Iva1 + comp.Iva2).ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 16: Impuesto liquida    do a RNI o percepción a no categorizados
			//TODO: si el comprador es no inscripto o no categorizado (campo 23 = 02 o 07), esto es el 50% del campo 15
			ret.Append("000000000000000");
			//Campo 17: Importe de operaciones exentas
			ret.Append("000000000000000");
			//Campo 18: Importe de percepciones o pagos a cuenta sobre impuestos nacionales
			ret.Append("000000000000000");
			//Campo 19: Importe de percepción de ingresos brutos
			ret.Append(comp.Percepciones.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 20: Importe de percepciones por impuestos municipales
			ret.Append("000000000000000");
			//Campo 21: Importe de impuestos internos
			ret.Append("000000000000000");
			//Campo 22: Transporte 
			ret.Append("000000000000000"); //Solo si hay una unica hoja (Campo 8) debe ir "000000000000000"
			//Campo 23: Tipo de responsable
			ret.Append(comp.TipoCliente.Codigo.Substring(0, 2));
			//Campo 24: Códigos de Moneda (no corresponde a facturacion electronica)
			ret.Append(GeneralSettings.Instance.CodigoMoneda.Substring(0, 3));
			//Campo 25: Tipo de Cambio (no corresponde a facturacion electronica)
			ret.Append("0000000000");
			//Campo 26: Cantidad de alícuotas de IVA (no corresponde a facturacion electronica)
			ret.Append("1");
			//Campo 27: Código de operación
			ret.Append(" ");
			//Campo 28: CAI
			ret.Append(comp.Empresa.CAI.ToString().PadRight(14, ' '));
			//Campo 29: Fecha de vencimiento
			ret.Append(comp.Empresa.FechaVtoCAI.ToString("yyyyMMdd"));
			//Campo 30: Fecha anulación del comprobante
			//if (comp.Estado != Comprobantes.EstadoAnulado) ret.Append("        ";
			if (comp.Estado != Comprobantes.EstadoAnulado) ret.Append("00000000");
			else ret.Append(comp.Anulacion.Value.ToString("yyyyMMdd"));
			//Fin de registro
			ret.Append("\r\n");
			#endregion
			#region Registro Tipo 2
				//Registro Tipo 2
				//Campo 1: Tipo de Registro
				ret.Append("2");
				//Campo 2: Período
				ret.Append(comp.Emision.ToString("yyyyMM"));
				//Campo 3: Relleno
				ret.Append(String.Empty.PadLeft(13, ' '));
				//Campo 4: Cantidad de Registros de tipo 1
				ret.Append("1".PadLeft(8, '0'));
				//Campo 5: Relleno
				ret.Append(String.Empty.PadLeft(17, ' '));
				//Campo 6: CUIT del informante
				ret.Append(comp.Empresa.Cuit.Replace("-", "").PadLeft(11, ' '));
				//Campo 7: Relleno
				ret.Append(String.Empty.PadLeft(22, ' '));
				//Campo 8: Importe total de la operación
				ret.Append(comp.Total.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 9: Importe total de conceptos que no integran el precio neto gravado
				ret.Append("000000000000000");
				//Campo 10: Importe Neto Gravado
				ret.Append(comp.SubtotalNeto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 11: Impuesto liquidado
				ret.Append((comp.Iva1 + comp.Iva2).ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 12: Impuesto liquidado a RNI o percepción a no categorizados
				ret.Append("000000000000000");
				//Campo 13: Importe de operaciones exentas
				ret.Append("000000000000000");
				//Campo 14: Importe de percepciones o pagos a cuenta de impuestos nacionales
				ret.Append("000000000000000");
				//Campo 15: Importe de percepción de ingresos brutos
				ret.Append(comp.Percepciones.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 16: Importe de percepción de impuestos municipales
				ret.Append("000000000000000");
				//Campo 17: Importe de impuestos internos
				ret.Append("000000000000000");
				//Campo 18: Relleno
				ret.Append(String.Empty.PadLeft(62, ' '));
				//Fin de registro
				ret.Append("\r\n");
				#endregion
			return ret.ToString();
		}

		#region Libro IVA Ventas
		protected class LibroVentasTotal
		{
			private int cantidadRegistros;
			private double importeTotal, importeNeto, importeImpuesto;

			public LibroVentasTotal()
			{
				CantidadRegistros = 0;
				ImporteTotal = ImporteNeto = ImporteImpuesto = 0;
			}

			public int CantidadRegistros
			{
				get { return cantidadRegistros; }
				set { cantidadRegistros = value; }
			}

			public double ImporteTotal
			{
				get { return importeTotal; }
				set { importeTotal = value; }
			}

			public double ImporteNeto
			{
				get { return importeNeto; }
				set { importeNeto = value; }
			}

			public double ImporteImpuesto
			{
				get { return importeImpuesto; }
				set { importeImpuesto = value; }
			}
		}

		protected string GetStreamVentas(Comprobantes comp, LibroVentasTotal total)
		{
			StringBuilder ret1 = new StringBuilder();
			StringBuilder ret2 = new StringBuilder();
			StringBuilder ret3 = new StringBuilder();
			IDictionary<Ivas, IList<DetallesComprobantes>> detallesPorIva = GetDetallesPorIva(comp);

			#region Campos 1 a 10 (comunes)
			//Campo 1: Tipo de registro
			ret1.Append("1");
			//Campo 2: Fecha del comprobante
			ret1.Append(comp.Emision.ToString("yyyyMMdd"));
			//Campo 3: Tipo de Comprobante
			ret1.Append(comp.Tipo.Codigo.Substring(0, 2));
			//Campo 4: Controlador Fiscal 
			ret1.Append(" ");
			//Campo 5: Punto de Venta
			ret1.Append(comp.NroCbante.Substring(0, 4));
			//Campo 6: Número de Comprobante
			ret1.Append(comp.NroCbante.Substring(5, 8).PadLeft(20, '0'));
			//Campo 7: Número de Comprobante Registrado
			ret1.Append(comp.NroCbante.Substring(5, 8).PadLeft(20, '0'));
			//Campo 8: Código de documento identificatorio del comprador
			ret1.Append(GeneralSettings.Instance.CodigoCUIT.Substring(0, 2));
			//Campo 9: Número de identificación del comprador
			ret1.Append(comp.CUITCliente.Replace("-", "").PadRight(11, ' '));
			//Campo 10: Apellido y nombres o denominación del comprador
			ret1.Append((comp.NombreCliente.Length < 30) ? comp.NombreCliente.PadRight(30, ' ') : comp.NombreCliente.Substring(0, 30));
			#endregion

			#region Campos 22 a 30 (comunes)
			//Campo 22: Tipo de responsable
			ret3.Append(comp.TipoCliente.Codigo.Substring(0, 2));
			//Campo 23: Códigos de Moneda 
			ret3.Append(GeneralSettings.Instance.CodigoMoneda.Substring(0, 3));
			//Campo 24: Tipo de Cambio 
			ret3.Append("0001000000");
			//Campo 25: Cantidad de alícuotas de IVA 
			ret3.Append("1");
			//Campo 26: Código de operación
			ret3.Append(" ");
			//Campo 27: CAI
			ret3.Append(comp.Empresa.CAI.ToString().PadRight(14, ' '));
			//Campo 28: Fecha de vencimiento
			ret3.Append(comp.Empresa.FechaVtoCAI.ToString("yyyyMMdd"));
			//Campo 29: Fecha anulación del comprobante
			if (comp.Estado != Comprobantes.EstadoAnulado) ret3.Append("00000000");
			else ret3.Append(comp.Anulacion.Value.ToString("yyyyMMdd"));
			//Campo 30: Información adicional
			ret3.Append(String.Empty.PadRight(75, ' '));
			#endregion

			#region Campos 11 a 21 (por alicuota de iva)

			foreach (KeyValuePair<Ivas, IList<DetallesComprobantes>> pair in detallesPorIva)
			{
				Comprobantes comprobanteAuxiliar = new Comprobantes();
				comprobanteAuxiliar.Items = pair.Value;
				comprobanteAuxiliar.Cliente = comp.Cliente;
				comprobanteAuxiliar.Empresa = comp.Empresa;
				comprobanteAuxiliar.CalcularTotales(comprobanteAuxiliar);

				total.CantidadRegistros++;
				total.ImporteTotal += comprobanteAuxiliar.Total;
				total.ImporteNeto += comprobanteAuxiliar.SubtotalNeto;
				total.ImporteImpuesto += (comprobanteAuxiliar.Iva1 + comprobanteAuxiliar.Iva2);

				//Campo 11: Importe total de la operación
				ret2.Append(comprobanteAuxiliar.Total.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 12: Importe total de conceptos que no integran el precio neto gravado
				ret2.Append("000000000000000");
				//Campo 13: Importe Neto Gravado
				ret2.Append(comprobanteAuxiliar.SubtotalNeto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 14: Alicuota de iva
				ret2.Append(pair.Key.Alicuota.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(4, '0'));
				//Campo 15: Impuesto liquidado
				//ret2.Append((comprobanteAuxiliar.Iva1 + comprobanteAuxiliar.Iva2).ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				ret2.Append((comprobanteAuxiliar.Iva1 + comprobanteAuxiliar.Iva2).ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 16: Impuesto liquidado a RNI o percepción a no categorizados
				//TODO: si el comprador es no inscripto o no categorizado (campo 23 = 02 o 07), esto es el 50% del campo 15
				ret2.Append("000000000000000");
				//Campo 17: Importe de operaciones exentas
				ret2.Append("000000000000000");
				//Campo 18: Importe de percepciones o pagos a cuenta sobre impuestos nacionales
				ret2.Append("000000000000000");
				//Campo 19: Importe de percepción de ingresos brutos
				ret2.Append(comprobanteAuxiliar.Percepciones.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				//Campo 20: Importe de percepciones por impuestos municipales
				ret2.Append("000000000000000");
				//Campo 21: Importe de impuestos internos
				ret2.Append("000000000000000");

			}
			#endregion
			//Registro
			return ret1.Append(ret2).Append(ret3).Append("\r\n").ToString();
		}

		protected IList GetComprobantes(Empresas empresa, DateTime fechaDesde, DateTime fechaHasta)
		{
			ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
			crit.Add(Expression.Eq("Empresa", empresa));
			crit.Add(Expression.Between("Emision", fechaDesde, fechaHasta));
			crit.Add(Expression.Eq("Estado", Comprobantes.EstadoEmitido));
			return crit.List();
		}

		public string GetFileNameVentas(Empresas empresa, int anio, int mes)
		{
			return String.Format("VENTAS_{0:0000}{1:00}.txt", anio, mes);
		}
		public string GetFileNameCabeceras(int anio, int mes)
		{
			return String.Format("CABECERA_{0:0000}{1:00}.txt", anio, mes);
		}
		public string GetFileNameDetalles(int anio, int mes)
		{
			return String.Format("DETALLE_{0:0000}{1:00}.txt", anio, mes);
		}

		
		public string GetStreamVentas(Empresas empresa, int anio, int mes)
		{
			DateTime fechaDesde = new DateTime(anio, mes, 1);
			DateTime fechaHasta = fechaDesde.AddMonths(1).AddSeconds(-1);
			StringBuilder builder = new StringBuilder();
			LibroVentasTotal total = new LibroVentasTotal();
			StringBuilder registroTotal = new StringBuilder();

			IList comprobantes = GetComprobantes(empresa, fechaDesde, fechaHasta);
			foreach (Comprobantes comprobante in comprobantes)
			{
				builder.Append(GetStreamVentas(comprobante, total));
			}

			#region Registro Tipo 2
			//Campo 1: Tipo de Registro
			registroTotal.Append("2");
			//Campo 2: Período
			registroTotal.Append(String.Format("{0:yyyyMM}", fechaDesde));
			//Campo 3: Relleno - 29 caracteres
			registroTotal.Append(String.Empty.PadLeft(29));
			//Campo 4: Cantidad de Registros de tipo 1 - 12 caracteres
			registroTotal.Append(total.CantidadRegistros.ToString().PadLeft(12, '0'));
			//Campo 5: Relleno - 10 caracteres
			registroTotal.Append(String.Empty.PadLeft(10));
			//Campo 6: CUIT del informante
			registroTotal.Append(empresa.Cuit.Replace("-", "").PadLeft(11));
			//Campo 7: Relleno - 30 caracteres
			registroTotal.Append(String.Empty.PadLeft(30));
			//Campo 8: Importe total de la operación
			registroTotal.Append(total.ImporteTotal.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 9: Importe total de conceptos que no integran el precio neto gravado
			registroTotal.Append("000000000000000");
			//Campo 10: Importe neto gravado
			registroTotal.Append(total.ImporteNeto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 11: Relleno - 4 caracteres
			registroTotal.Append(String.Empty.PadLeft(4));
			//Campo 12: Impuesto liquidado
			registroTotal.Append(total.ImporteImpuesto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 13: Impuesto liquidado a RNI o percepción a no categorizados
			registroTotal.Append("000000000000000");
			//Campo 14: Importe de operaciones exentas
			registroTotal.Append("000000000000000");
			//Campo 15: Importe de percepciones o pagos a cuenta sobre impuestos nacionales
			registroTotal.Append("000000000000000");
			//Campo 16: Importe de percepción de ingresos brutos
			registroTotal.Append("000000000000000");
			//Campo 17: Importe de percepción de impuestos municipales
			registroTotal.Append("000000000000000");
			//Campo 18: Importe de impuestos internos
			registroTotal.Append("000000000000000");
			//Campo 19: Relleno - 122 caracteres
			registroTotal.Append(String.Empty.PadLeft(122));
			//Fin de registro
			registroTotal.Append("\r\n");
			#endregion

			builder.Append(registroTotal);
			return builder.ToString();
		}

		protected IDictionary<Ivas, IList<DetallesComprobantes>> GetDetallesPorIva(Comprobantes comp)
		{
			IDictionary<Ivas, IList<DetallesComprobantes>> result = new Dictionary<Ivas, IList<DetallesComprobantes>>();
			foreach (DetallesComprobantes detalle in comp.Items)
			{
				if (!result.ContainsKey(detalle.TipoIva)) result.Add(detalle.TipoIva, new List<DetallesComprobantes>());
				result[detalle.TipoIva].Add(detalle);
			}

			return result;
		}
		#endregion

		public string GetStreamCabeceras(Empresas empresa, int anio, int mes)
		{
			DateTime fechaDesde = new DateTime(anio, mes, 1);
			DateTime fechaHasta = fechaDesde.AddMonths(1).AddSeconds(-1);
			StringBuilder builder = new StringBuilder();

			IList comprobantes = GetComprobantes(empresa, fechaDesde, fechaHasta);
			int cantidadReg = 0;
			Double importeTotalOper = 0, importeTotalSubtotalNeto = 0, impuestoLiquidadoTotal = 0, importePercepcionesTotal = 0;

			foreach (Comprobantes comprobante in comprobantes)
			{
				cantidadReg++;
				#region Registro Tipo 1
				//Registro Tipo 1
				//Campo 1: Tipo de registro
				builder.Append("1");
				//Campo 2: Fecha del comprobante
				builder.Append(comprobante.Emision.ToString("yyyyMMdd"));
				//Campo 3: Tipo de Comprobante
				builder.Append(comprobante.Tipo.Codigo.Substring(0, 2));
				//Campo 4: Controlador Fiscal (no corresponde a facturacion electronica)
				builder.Append(" ");
				//Campo 5: Punto de Venta
				builder.Append(comprobante.NroCbante.Substring(0, 4));
				//Campo 6: Número de Comprobante
				builder.Append(comprobante.NroCbante.Substring(5, 8));
				//Campo 7: Número de Comprobante Registrado
				builder.Append(comprobante.NroCbante.Substring(5, 8));
				//Campo 8: Cantidad de Hojas 
				builder.Append("001"); //Ver si puede haber mas de una hoja
				//Campo 9: Código de documento identificatorio del comprador.
				builder.Append(comprobante.Tipo.Codigo);
				//Campo 10: Número de identificación del comprador
				builder.Append(comprobante.CUITCliente.Replace("-", "").PadRight(11, ' '));
				//Campo 11: Apellido y nombres o denominación del comprador
				builder.Append(comprobante.NombreCliente.PadRight(30, ' '));
				//Campo 12: Importe total de la operación
				builder.Append(comprobante.Total.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				importeTotalOper += comprobante.Total;
				//Campo 13: Importe total de conceptos que no integran el precio neto gravado
				builder.Append("000000000000000");
				//Campo 14: Importe Neto Gravado
				builder.Append(comprobante.SubtotalNeto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				importeTotalSubtotalNeto += comprobante.SubtotalNeto;
				//Campo 15: Impuesto liquidado
				builder.Append((comprobante.Iva1 + comprobante.Iva2).ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				impuestoLiquidadoTotal += (comprobante.Iva1 + comprobante.Iva2);
				//Campo 16: Impuesto liquida    do a RNI o percepción a no categorizados
				//TODO: si el comprador es no inscripto o no categorizado (campo 23 = 02 o 07), esto es el 50% del campo 15
				builder.Append("000000000000000");
				//Campo 17: Importe de operaciones exentas
				builder.Append("000000000000000");
				//Campo 18: Importe de percepciones o pagos a cuenta sobre impuestos nacionales
				builder.Append("000000000000000");
				//Campo 19: Importe de percepción de ingresos brutos
				builder.Append(comprobante.Percepciones.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
				importePercepcionesTotal += comprobante.Percepciones;
				//Campo 20: Importe de percepciones por impuestos municipales
				builder.Append("000000000000000");
				//Campo 21: Importe de impuestos internos
				builder.Append("000000000000000");
				//Campo 22: Transporte 
				builder.Append("000000000000000"); //Solo si hay una unica hoja (Campo 8) debe ir "000000000000000"
				//Campo 23: Tipo de responsable
				builder.Append(comprobante.TipoCliente.Codigo.Substring(0, 2));
				//Campo 24: Códigos de Moneda (no corresponde a facturacion electronica)
				builder.Append(GeneralSettings.Instance.CodigoMoneda.Substring(0, 3));
				//Campo 25: Tipo de Cambio (no corresponde a facturacion electronica)
				builder.Append("0000000000");
				//Campo 26: Cantidad de alícuotas de IVA (no corresponde a facturacion electronica)
				builder.Append("1");
				//Campo 27: Código de operación
				builder.Append(" ");
				//Campo 28: CAI
				builder.Append(comprobante.Empresa.CAI.ToString().PadRight(14, ' '));
				//Campo 29: Fecha de vencimiento
				builder.Append(comprobante.Empresa.FechaVtoCAI.ToString("yyyyMMdd"));
				//Campo 30: Fecha anulación del comprobante
				//if (comprobante.Estado != Comprobantes.EstadoAnulado) builder.Append("        ";
				if (comprobante.Estado != Comprobantes.EstadoAnulado) builder.Append("00000000");
				else builder.Append(comprobante.Anulacion.Value.ToString("yyyyMMdd"));
				//Fin de registro
				builder.Append("\r\n");
				#endregion

			}
			#region Registro Tipo 2
			//Registro Tipo 2
			//Campo 1: Tipo de Registro
			builder.Append("2");
			//Campo 2: Período
			builder.Append(String.Format("{0:0000}{1:00}", anio, mes));
			//Campo 3: Relleno
			builder.Append(String.Empty.PadLeft(13, ' '));
			//Campo 4: Cantidad de Registros de tipo 1
			builder.Append(cantidadReg.ToString().PadLeft(8, '0'));
			//Campo 5: Relleno
			builder.Append(String.Empty.PadLeft(17, ' '));
			//Campo 6: CUIT del informante
			builder.Append(empresa.Cuit.Replace("-", "").PadLeft(11, ' '));
			//Campo 7: Relleno
			builder.Append(String.Empty.PadLeft(22, ' '));
			//Campo 8: Importe total de la operación
			builder.Append(importeTotalOper.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 9: Importe total de conceptos que no integran el precio neto gravado
			builder.Append("000000000000000");
			//Campo 10: Importe Neto Gravado
			builder.Append(importeTotalSubtotalNeto.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 11: Impuesto liquidado
			builder.Append(impuestoLiquidadoTotal.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 12: Impuesto liquidado a RNI o percepción a no categorizados
			builder.Append("000000000000000");
			//Campo 13: Importe de operaciones exentas
			builder.Append("000000000000000");
			//Campo 14: Importe de percepciones o pagos a cuenta de impuestos nacionales
			builder.Append("000000000000000");
			//Campo 15: Importe de percepción de ingresos brutos
			builder.Append(importePercepcionesTotal.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
			//Campo 16: Importe de percepción de impuestos municipales
			builder.Append("000000000000000");
			//Campo 17: Importe de impuestos internos
			builder.Append("000000000000000");
			//Campo 18: Relleno
			builder.Append(String.Empty.PadLeft(62, ' '));
			//Fin de registro
			builder.Append("\r\n");
			#endregion
			return builder.ToString();
		}
		public string GetStreamDetalles(Empresas empresa, int anio, int mes)
		{
			DateTime fechaDesde = new DateTime(anio, mes, 1);
			DateTime fechaHasta = fechaDesde.AddMonths(1).AddSeconds(-1);
			StringBuilder builder = new StringBuilder();
			
			IList comprobantes = GetComprobantes(empresa, fechaDesde, fechaHasta);
			
			foreach (Comprobantes comprobante in comprobantes)
			{
				builder.Append(GetStreamDetalle(comprobante));
			}
			return builder.ToString();
		}

		public string GetResumeStream(Comprobantes comp)
		{
			//return "Fecha: " + comp.Emision.ToString("yyyyMMdd") + " Nro: " + comp.NroCbante + " Importe: " + comp.Total + "\r\n";
			return "Fecha: " + comp.Emision.ToString("yyyyMMdd") + " Nro: " + comp.NroCbante + "\r\n";
		}
		public int HasComprobantesProgramados()
		{
			StringBuilder query = new StringBuilder();
			query.Append("SELECT Count(id_cbante) as Pendientes ");
			query.Append("FROM dbo.strg_tcbante ");
			query.Append("WHERE estado = 'Pendiente' ");
			query.Append("AND emision <= CONVERT(VARCHAR(8), GETDATE()+1, 112) ");

			ISQLQuery crit = DBConnection.Session.CreateSQLQuery(query.ToString());
			crit.AddScalar("Pendientes", NHibernateUtil.Int32);
			return crit.UniqueResult<Int32>();
			
		}
		

	}

	public enum TipoPeriodo
	{
		Mensual,
		Trimestral,
		Semestral
	}
}
