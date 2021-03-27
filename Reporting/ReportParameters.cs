using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Reporting {
    public class ReportParameters {
        private DateTime fechaDesde;
        private DateTime fechaHasta;

        public ReportParameters(DateTime fechaDesde, DateTime fechaHasta) {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
        }
        
        public DateTime FechaDesde {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        public DateTime FechaHasta {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }
    }
}
