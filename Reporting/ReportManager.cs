using System;
using System.Collections;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using Entities;
using BusinessLogic;
namespace Reporting{
    public class ReportManager {
        public static ReportDocument GetReport(IList dataSource)
        {
            ReportDocument result = null;

            result = new ComprobantesRpt();
            result.SetDataSource(dataSource);
            return result;
        }

        public static ReportDocument GetReportComprobantes(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic comprobantesBL)
        {
            ComprobantesRpt result = new ComprobantesRpt();

            result.SetDataSource(comprobantesBL.GetDTODataSource());
            return result;
        }

        public static ReportDocument GetReportDetalleComprobantes(ComprobantesBL comprobantesBL, Comprobantes comp)
        {
            ComprobanteDetalleRpt result = new ComprobanteDetalleRpt();
            result.SetDataSource(comprobantesBL.GetDTODetalle(comp));
            return result;
        }

        public static ReportDocument GetReportComprobantes(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic comprobantesBL, DateTime fechaDesde, DateTime fechaHasta)
        {
            ComprobantesRpt result = new ComprobantesRpt();

            result.SetDataSource(comprobantesBL.GetDTODataSource(fechaDesde, fechaHasta));
            result.SetParameterValue(result.Parameter_FechaDesde.ParameterFieldName, fechaDesde.ToString ("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_FechaHasta.ParameterFieldName, fechaHasta.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_Empresa.ParameterFieldName, "");
            return result;
        }

		public static ReportDocument GetReportComprobantesCompras(ComprobantesComprasBL comprobantesComprasBL, DateTime fechaDesde, DateTime fechaHasta)
		{
            ComprobantesComprasRpt result = new ComprobantesComprasRpt();

            result.SetDataSource(comprobantesComprasBL.GetDTODataSource(fechaDesde, fechaHasta));
            result.SetParameterValue(result.Parameter_FechaDesde.ParameterFieldName, fechaDesde.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_FechaHasta.ParameterFieldName, fechaHasta.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_Empresa.ParameterFieldName, "");
            return result;
        }

        public static ReportDocument GetReportProductos(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic productosBL, DateTime fechaDesde, DateTime fechaHasta)
        {
            ProductosRpt result = new ProductosRpt();

            result.SetDataSource(productosBL.GetDTODataSource(fechaDesde, fechaHasta));
            result.SetParameterValue(result.Parameter_FechaDesde.ParameterFieldName, fechaDesde.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_FechaHasta.ParameterFieldName, fechaHasta.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_Empresa.ParameterFieldName, "");
            return result;
        }


        public static ReportDocument GetReportFacturacion(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic comprobantesBL, DateTime fechaDesde, DateTime fechaHasta, TipoPeriodo tipo)
        {
            FacturacionRpt result = new FacturacionRpt();

            result.SetDataSource((comprobantesBL as ComprobantesBL).GetDTODataSource(fechaDesde,fechaHasta,tipo));
            result.SetParameterValue(result.Parameter_FechaDesde.ParameterFieldName, fechaDesde.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_FechaHasta.ParameterFieldName, fechaHasta.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_Empresa.ParameterFieldName, "");
            return result;
        }
        public static ReportDocument GetReportFacturacionUsuarios(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic comprobantesBL, DateTime fechaDesde, DateTime fechaHasta, TipoPeriodo tipo)
        {
            FacturacionUsuariosRpt result = new FacturacionUsuariosRpt();
			string empresa;
            result.SetDataSource((comprobantesBL as ComprobantesBL).GetDTODataSourcePorUsuario (fechaDesde, fechaHasta, tipo, out empresa));
            result.SetParameterValue(result.Parameter_FechaDesde.ParameterFieldName, fechaDesde.ToString("dd/MM/yyyy"));
            result.SetParameterValue(result.Parameter_FechaHasta.ParameterFieldName, fechaHasta.ToString("dd/MM/yyyy"));
			result.SetParameterValue(result.Parameter_Empresa.ParameterFieldName, empresa);
            return result;
        }
    }
}