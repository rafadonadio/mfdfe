using System;
using System.IO;
using System.Text;
using System.Xml;
using MFDService.ar.gov.afip.wswhomo;
using Tools.XML.Generator;
using Entities;
using System.Configuration;

namespace MFDService.Clases.Adapters
{
	public class ComprobantesAdapter
	{
		private Comprobantes comprobante;
		private Empresas empresa;

		public ComprobantesAdapter(Comprobantes comprobante, Empresas empresa)
		{
			this.comprobante = comprobante;
			this.empresa = empresa;
		}

		#region Formatting Functions
		protected static string FormatDate(DateTime? fecha)
		{
			if (fecha != null) return FormatDate(fecha.Value);
			else return "        ";
		}

		protected static string FormatDate(DateTime fecha)
		{
			return String.Format("{0:yyyyMMdd}", fecha);
		}

		//        protected static string FormatInt(int number) {
		//            return FormatInt(number, 8);
		//        }

		//        protected static string FormatInt(int number, int length) {
		//            return FormatDouble((double)number, length, 0);
		//        }

		//        protected static string FormatDouble(double number) {
		//            return FormatDouble(number, 15);
		//        }

		//        protected static string FormatDouble(double number, int length) {
		//            return FormatDouble(number, length, 2);
		//        }

		//        protected static string FormatDouble(double number, int length, int precision) {
		//            string formatter = String.Empty.PadLeft(length - precision, '0') + "." + String.Empty.PadLeft(precision, '0');
		//            return number.ToString(formatter).Replace(".", "").Replace(",", "");
		//        }
		#endregion

		public FERequest GenerarFERequest(long idCabecera)
		{
			//Cabecera
			FECabeceraRequest cabecera = new FECabeceraRequest();
			cabecera.id = idCabecera;
			cabecera.cantidadreg = 1;
			cabecera.presta_serv = 1; //TODO: por ahora todo lo que se facturan son servicios

			//Detalle
			FEDetalleRequest detalle = new FEDetalleRequest();
			detalle.tipo_doc = 80;
			detalle.nro_doc = Convert.ToInt64(comprobante.Cliente.CUIT.Replace("-", ""));
			detalle.tipo_cbte = Convert.ToInt32(comprobante.Tipo.Codigo);
			if (string.IsNullOrEmpty(comprobante.NroCbante))
			{
				comprobante.NroCbante = ObtenerNroComprobante();
			}
			detalle.punto_vta = Convert.ToInt32(comprobante.NroCbante.Substring(0, 4));
			detalle.cbt_desde = Convert.ToInt64(comprobante.NroCbante.Substring(5, 8));
			detalle.cbt_hasta = Convert.ToInt64(comprobante.NroCbante.Substring(5, 8));
			detalle.imp_total = comprobante.Total;
			detalle.imp_tot_conc = 0;
			detalle.imp_neto = comprobante.SubtotalNeto;
			detalle.impto_liq = comprobante.Iva1 + comprobante.Iva2;
			detalle.impto_liq_rni = 0;
			detalle.imp_op_ex = 0;
			detalle.fecha_serv_desde = FormatDate(comprobante.Emision); //TODO: verificar que sea la fecha correcta
			detalle.fecha_serv_hasta = FormatDate(comprobante.Emision); //TODO: verificar que sea la fecha correcta
			detalle.fecha_cbte = FormatDate(comprobante.Emision);
			detalle.fecha_venc_pago = FormatDate(comprobante.Emision);//TODO: verificar que sea la fecha correcta

			//Armado del FERequest
			FERequest result = new FERequest();
			result.Fecr = cabecera;
			result.Fedr = new FEDetalleRequest[1];
			result.Fedr[0] = detalle;

			return result;
		}
		//TODO: Repetido
		private string ObtenerNroComprobante()
		{
			string ultimoComprobante = string.Empty;
			TiposComprobantes tipo = comprobante.Tipo;
			try
			{
				if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaA"]) ultimoComprobante = comprobante.Empresa.UltimaFacturaA;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaB"]) ultimoComprobante = comprobante.Empresa.UltimaFacturaB;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaC"]) ultimoComprobante = comprobante.Empresa.UltimaFacturaC;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.FacturaE"]) ultimoComprobante = comprobante.Empresa.UltimaFacturaE;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoA"]) ultimoComprobante = comprobante.Empresa.UltimaNotaDebitoA;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoB"]) ultimoComprobante = comprobante.Empresa.UltimaNotaDebitoB;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoC"]) ultimoComprobante = comprobante.Empresa.UltimaNotaDebitoC;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaDebitoE"]) ultimoComprobante = comprobante.Empresa.UltimaNotaDebitoE;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoA"]) ultimoComprobante = comprobante.Empresa.UltimaNotaCreditoA;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoB"]) ultimoComprobante = comprobante.Empresa.UltimaNotaCreditoB;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoC"]) ultimoComprobante = comprobante.Empresa.UltimaNotaCreditoC;
				else if (tipo.Codigo == ConfigurationManager.AppSettings["tipoComprobante.NotaCreditoE"]) ultimoComprobante = comprobante.Empresa.UltimaNotaCreditoE;

				string[] partes = ultimoComprobante.Split(new char[] { '-' });

				int? nroC;
				if (partes.Length >= 2)
				{
					int nro = Convert.ToInt32(partes[1]);
					nro++;
					comprobante.NroCbante = partes[0] + "-" + nro.ToString().PadLeft(8, '0');
					nroC = MFDService.GetUltimoNroComprobante(comprobante);
					if (nroC.HasValue)
					{
						nroC++;
					}
					else
					{
						nroC = 1;
					}
				}
				else
				{
					throw new Exception("Error al intentar obtener el último nro de comprobante: " + tipo.Nombre);
				}

				return partes[0] + "-" + nroC.ToString().PadLeft(8, '0');
			}
			catch
			{
				throw new Exception("Error al intentar obtener el último nro de comprobante: " + tipo.Nombre);
			}
		}

		//public FELastCMPtype GenerarFELastCMPtype() {
		//    FELastCMPtype feLastCMPtype = new FELastCMPtype();
		//    feLastCMPtype.TipoCbte = Convert.ToInt32(comprobante.Tipo.Codigo);
		//    feLastCMPtype.PtoVta = Convert.ToInt32(comprobante.NroCbante.Substring(0, 4));
		//    return feLastCMPtype;

		//}
		public FELastCMPtype GenerarFELastCMPtype()
		{
			if (empresa.PuntoDeVenta.HasValue)
			{
				FELastCMPtype feLastCMPtype = new FELastCMPtype();
				feLastCMPtype.TipoCbte = Convert.ToInt32(comprobante.Tipo.Codigo);
				feLastCMPtype.PtoVta = empresa.PuntoDeVenta.Value;//1;// Convert.ToInt32(comprobante.NroCbante.Substring(0, 4));
				return feLastCMPtype;
			}
			else
			{
				throw new Exception("La empresa debe tener un puento de venta asociado.");
			}

		}

	}
}
