using System;
using System.Collections;
using Entities;

namespace BusinessLogic {
    public class LibroIVAComprasBL {
        private ComprobantesComprasBL comprobantesComprasBL;
        public LibroIVAComprasBL(ComprobantesComprasBL comprobantesComprasBL) {
            this.comprobantesComprasBL = comprobantesComprasBL;
        }
        
        public LibroIVACompras GetLibroIVACompras(Empresas empresa, int anio, int mes) {
            DateTime fechaDesde=new DateTime(anio,mes,1);
            DateTime fechaHasta = fechaDesde.AddMonths(1).AddDays(-1);
            IList comprobantes = comprobantesComprasBL.GetComprobantes(empresa, fechaDesde, fechaHasta);
            return new LibroIVACompras(empresa, anio, mes, comprobantes);
        }
        
        public string GetFileName(LibroIVACompras libroIVACompras) {
            return String.Format("COMPRAS_{0:0000}{1:00}.txt", libroIVACompras.Anio, libroIVACompras.Mes);
        }
    }
}
