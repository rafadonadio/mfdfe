using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class TiposContribuyentesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(TiposContribuyentes ); }
        }

        public override System.Collections.IList GetPropertyValueList(string propertyName, FrameWork.DataBusinessModel.DataModel.Persistent persistent)
        {
			int idEmpresaDefault = GeneralSettings.Instance.IdEmpresaDefault;
			NHibernate.ICriteria critEmpresa = DBConnection.Session.CreateCriteria(typeof(Empresas));
			critEmpresa.Add(new NHibernate.Expression.EqExpression("Id", idEmpresaDefault));
			Empresas empresa= (Empresas)critEmpresa.UniqueResult();
			if (empresa.TipoContribuyente.Codigo != "01" && empresa.TipoContribuyente.Codigo != "06")
			{
				throw new Exception("La empresa "+empresa.RazonSocial+" no tiene asociado un tipo de contribuyente válido." + Environment.NewLine +"Debe ser Responsable Inscripto o Monotributista.");
			}
			if (propertyName == "TipoFactura")
            {
                NHibernate.ICriteria crit = DBConnection.Session.CreateCriteria(typeof(TiposComprobantes));
                crit.Add (new NHibernate.Expression.EqExpression ("Tipo",TiposComprobantesList.Factura ));
				if (empresa.TipoContribuyente.Codigo == "01") //R. Inscripto - a - b - e
				{
					EqExpression cod01 = new NHibernate.Expression.EqExpression("Codigo", "01");
					EqExpression cod06 = new NHibernate.Expression.EqExpression("Codigo", "06");
					EqExpression cod19 = new NHibernate.Expression.EqExpression("Codigo", "19");
					OrExpression c01or06 = new OrExpression(cod01, cod06);
					OrExpression c01or06or19 = new OrExpression(c01or06, cod19);
					crit.Add(c01or06or19);
				}
				else if (empresa.TipoContribuyente.Codigo == "06") //Monotributista  -c - e
				{
					EqExpression cod11 = new NHibernate.Expression.EqExpression("Codigo", "11");
					EqExpression cod19 = new NHibernate.Expression.EqExpression("Codigo", "19");
					OrExpression c11or19 = new OrExpression(cod11, cod19);
					crit.Add(c11or19);
				}
				return crit.List(); 
            }
            if (propertyName == "TipoNotaDebito")
            {
                NHibernate.ICriteria crit = DBConnection.Session.CreateCriteria(typeof(TiposComprobantes));
                crit.Add (new NHibernate.Expression.EqExpression ("Tipo",TiposComprobantesList.NotaDebito ) );
				if (empresa.TipoContribuyente.Codigo == "01") //R. Inscripto
				{
					EqExpression cod02 = new NHibernate.Expression.EqExpression("Codigo", "02");
					EqExpression cod07 = new NHibernate.Expression.EqExpression("Codigo", "07");
					EqExpression cod20 = new NHibernate.Expression.EqExpression("Codigo", "20");
					OrExpression c02or07 = new OrExpression(cod02, cod07);
					OrExpression c02or07or20 = new OrExpression(c02or07, cod20);
					crit.Add(c02or07or20);
				}
				else if (empresa.TipoContribuyente.Codigo == "06") //Monotributista
				{
					EqExpression cod12 = new NHibernate.Expression.EqExpression("Codigo", "12");
					EqExpression cod20 = new NHibernate.Expression.EqExpression("Codigo", "20");
					OrExpression c12or20 = new OrExpression(cod12, cod20);
					crit.Add(c12or20);
				} 
				return crit.List(); 
            }
            if (propertyName == "TipoNotaCredito")
            {
                NHibernate.ICriteria crit = DBConnection.Session.CreateCriteria(typeof(TiposComprobantes));
                crit.Add (new NHibernate.Expression.EqExpression ("Tipo",TiposComprobantesList.NotaCredito  ));
				if (empresa.TipoContribuyente.Codigo == "01") //R. Inscripto
				{
					EqExpression cod03 = new NHibernate.Expression.EqExpression("Codigo", "03");
					EqExpression cod08 = new NHibernate.Expression.EqExpression("Codigo", "08");
					EqExpression cod21 = new NHibernate.Expression.EqExpression("Codigo", "21");
					OrExpression c03or08 = new OrExpression(cod03, cod08);
					OrExpression c03or08or21 = new OrExpression(c03or08, cod21);
					crit.Add(c03or08or21);
				}
				else if (empresa.TipoContribuyente.Codigo == "06") //Monotributista
				{
					EqExpression cod13 = new NHibernate.Expression.EqExpression("Codigo", "13");
					EqExpression cod21 = new NHibernate.Expression.EqExpression("Codigo", "21");
					OrExpression c13or21 = new OrExpression(cod13, cod21);
					crit.Add(c13or21);
				} 
				return crit.List(); 
            }
                
            return base.GetPropertyValueList(propertyName, persistent);
        }


        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayClientes(persistentObject as TiposContribuyentes))
            {
                result = false;
                messages.Add("No se puede eliminar el tipo de contribuyente porque existen clientes asociados");
            }
            return result;
        }

        private bool HayClientes(TiposContribuyentes tiposContribuyentes)
        {
            return DBConnection.Session.CreateCriteria(typeof(Clientes)).Add(Expression.Eq("TipoContribuyente",tiposContribuyentes)).
                SetMaxResults(1).List().Count > 0;
        }
        
        
        
        public override object GetModule()
        {
            return new ModuloParametros();
        }
    }
}
