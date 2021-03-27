using System;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Entities;
using FrameWork.Tools.Validation;

namespace BusinessLogic
{
    public class EmpresasBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            return result;
        }
        public override bool BusinessValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.BusinessValidator(persistentObject, messages);
            return result;
        }
        public override Type PersistentType
        {
            get { return typeof(Empresas); }
        }
        public override object GetModule()
        {
            return new ModuloParametros();
        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            return false;
        }

		public override System.Collections.IList GetPropertyValueList(string propertyName, FrameWork.DataBusinessModel.DataModel.Persistent persistent)
		{
			if (propertyName == "TipoContribuyente")
			{
				NHibernate.ICriteria crit = DBConnection.Session.CreateCriteria(typeof(TiposContribuyentes));
				NHibernate.Expression.EqExpression cod01 = new NHibernate.Expression.EqExpression("Codigo", "01");
				NHibernate.Expression.EqExpression  cod06=  new NHibernate.Expression.EqExpression("Codigo", "06");
				crit.Add(new NHibernate.Expression.OrExpression(cod01, cod06));
				return crit.List();
			}
			
			return base.GetPropertyValueList(propertyName, persistent);
		}
    }
}
