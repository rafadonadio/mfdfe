using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using Entities;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.Tools.Validation;
using NHibernate;
using NHibernate.Expression;
using Security;

namespace BusinessLogic {
    [Serializable]
    public class ModuloComprobantesCompras : Modules {
    }

    public class ComprobantesComprasBL: FrameWork.DataBusinessModel.BusinessModel.BusinessLogic {
        protected TiposComprobantesList tipo = TiposComprobantesList.Factura;

        public void SetTipoFilter(TiposComprobantesList tipo) {
            this.tipo = tipo;
        }

        public override IList GetDataSource() {
            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
            crit.Add(new EqExpression("Supertipo", tipo));
            return crit.List ();
        }

        public override object GetModule() {
            return new ModuloComprobantesCompras();
        }
        
        public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages) {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            ComprobantesCompras comprobante = persistentObject as ComprobantesCompras ;
            
            ActualizarCamposImportacion(comprobante);
            
            RequiredFieldValidator requiredValidator=new RequiredFieldValidator(messages);
            result &= requiredValidator.Validate(comprobante.Tipo, "Debe ingresar un Tipo");
            result &= requiredValidator.Validate(comprobante.NombreProveedor, "Debe ingresar el nombre del Proveedor");
            result &= requiredValidator.Validate(comprobante.CUITProveedor, "Debe ingresar el CUIT del Proveedor");
            result &= requiredValidator.Validate(comprobante.CAIProveedor, "Debe ingresar el CAI del Proveedor");
            result &= requiredValidator.Validate(comprobante.TipoProveedor, "Debe ingresar el Tipo de Contribuyente del Proveedor");
            result &= new NoComprobanteValidator(messages).Validate(comprobante.Numero, "Debe ingresar un Número de Comprobante");
            if(comprobante.Importacion) {
                result &= requiredValidator.Validate(comprobante.Destinacion, "Debe ingresar una Destinación");
                result &= requiredValidator.Validate(comprobante.Aduana, "Debe ingresar una Aduana");
                result &= requiredValidator.Validate(comprobante.NumeroDespacho, "Debe ingresar un Número de Despacho");
                if(comprobante.FechaDespacho==null) {
                    result = false;
                    messages.Add("Debe ingresar una fecha de despacho");
                }
            }
            return result;
        }
        
        public override Type PersistentType {
            get { return typeof(ComprobantesCompras); }
        }
        
        public override Type DTOType {
            get { return typeof(ComprobantesComprasDTO); }
        }

        public override Persistent GetNewInstance() {
            EmpresasBL empBL = new EmpresasBL();
            empBL.SetParameters(DBConnection); 

            ComprobantesCompras newComp = (ComprobantesCompras) Activator.CreateInstance(PersistentType);
            newComp.Empresa = empBL.GetObject(GeneralSettings.Instance.IdEmpresaDefault) as Empresas;
            newComp.Supertipo = tipo;
            return newComp;
        }

        public override IList GetDTODataSource() {
            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);

            //se toman todos los supertipos, es decir todos los tipos de comprobantes
            crit.Add(new EqExpression("Estado", ComprobantesCompras.EstadoEmitido));
            crit.AddOrder(new Order("Emision", true));

            IList resultados = crit.List();
            // en caso que el comprobante sea nota de débito el importe se resta
            //ConvertirNotasCreditoATotalesNegativos(resultados);
			// en caso que el comprobante sea nota de crédito el importe se resta
			ConvertirNotasCreditoAValoresNegativos(resultados);

            return ConvertToDTOList(resultados);
        }

        public override IList GetDTODataSource(DateTime fechaDesde, DateTime fechaHasta) {

            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);

            //se quita un día a la fecha desde para que el between tome bien
            crit.Add(new BetweenExpression("Emision", fechaDesde.Subtract(new TimeSpan(1, 0, 0, 0)), fechaHasta));

            //se toman todos los supertipos, es decir todos los tipos de comprobantes
            crit.Add(new EqExpression("Estado", ComprobantesCompras.EstadoEmitido));
            crit.AddOrder(new Order("Emision", true));
            
            IList resultados = crit.List();
            // en caso que el comprobante sea nota de credito el importe se resta
            //ConvertirNotasCreditoAValoresNegativos(resultados);
			// en caso que el comprobante sea nota de crédito el importe se resta
			ConvertirNotasCreditoAValoresNegativos(resultados);

            return ConvertToDTOList(resultados);
            
        }

        /// <summary>
        /// Convierte los totaltes de los comprobantes del tipo nota de débito en negativos para 
        /// que resten en el reporte
        /// </summary>
        /// <param name="resultados"></param>
        
        private static void ConvertirNotasCreditoATotalesNegativos(IList resultados)
        {
            foreach (Entities.ComprobantesCompras item in resultados)
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
			foreach (Entities.ComprobantesCompras item in resultados)
			{
				if (item.Supertipo.Equals(TiposComprobantesList.NotaCredito))
				{
					if (item.NetoGravado >= 0)
						item.NetoGravado = item.NetoGravado * -1;
					if (item.TotalNoGravado >= 0)
						item.TotalNoGravado = item.TotalNoGravado * -1;
					if (item.ImpuestoLiquidado >= 0)
						item.ImpuestoLiquidado = item.ImpuestoLiquidado * -1;
					if (item.Percepciones >= 0)
						item.Percepciones = item.Percepciones * -1;
					if (item.ImpuestosInternos >= 0)
						item.ImpuestosInternos = item.ImpuestosInternos * -1; 
					if (item.Total >= 0)
						item.Total = item.Total * -1;
				} 

			}
		}

        public IList GetComprobantes(Empresas empresa, DateTime fechaDesde, DateTime fechaHasta) {
            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
            crit.Add(Expression.Eq("Empresa", empresa));
            crit.Add(Expression.Between("Emision", fechaDesde, fechaHasta));
            crit.Add(Expression.Eq("Estado", ComprobantesCompras.EstadoEmitido));
            return crit.List();
        }

        protected void ActualizarCamposImportacion(ComprobantesCompras comprobante) {
            if(!comprobante.Importacion) {
                comprobante.Destinacion = null;
                comprobante.Aduana = null;
                comprobante.NumeroDespacho = null;
                comprobante.DigitoVerificadorNumeroDespacho = '\0';
                comprobante.FechaDespacho = null;
            }
        }

        public override IList GetPropertyValueList(string propertyName, Persistent persistent) {
            IList result;
            if (propertyName == "Tipo") {
                TiposComprobantesBL tiposComprobantesBL = new TiposComprobantesBL();
                tiposComprobantesBL.SetParameters(DBConnection);
                result = tiposComprobantesBL.GetDataSource(tipo);
            }
            else result = base.GetPropertyValueList(propertyName, persistent);
            
            return result;
        }
    }
}
