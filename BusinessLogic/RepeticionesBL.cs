using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Entities;
using NHibernate;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class RepeticionesBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override Type PersistentType
        {
            get { return typeof(Repeticiones ); }
        }
		public override object GetModule()
		{
			return new ModuloParametros();
		}

		public override bool CreateAllowed(Persistent persistentParent, ErrorMessages messages)
		{
			//bool result = base.CreateAllowed(persistentParent, messages);
			messages.Add("No se pueden crear repeticiones desde esta grilla, debe hacerse desde el comprobante.");
			return false;
		}
		public override bool CreateAllowed(ErrorMessages messages)
		{
			messages.Add("No se pueden crear repeticiones desde esta grilla, debe hacerse desde el comprobante.");
			return false;
		}
		public override bool Delete(Persistent persistent)
		{
			bool result = base.Delete(persistent);
			if (result)
			{
				try
				{
					ActualizarComprobantes(persistent.Id);
				}
				catch {
					return false;
				}
			}
			return result;

		}

		public void ActualizarComprobantes(int id)
		{
			StringBuilder query = new StringBuilder();
			query.Append("UPDATE strg_tcbante SET Tiene_Repeticion=0 WHERE id_cbante = "+ id.ToString());
			ISQLQuery crit = DBConnection.Session.CreateSQLQuery(query.ToString());
			crit.AddScalar("Result", NHibernateUtil.Object);
			Object obj = crit.UniqueResult<Object>();

		}
		/*protected DBase db;        
        
		public RepeticionesBL() {
		}

        public RepeticionesBL(DBase db)
        {
			this.SetParameters(db);
		}

		public void SetParameters(DBase db) {
			this.db = db;
		}
        
        public bool SaveOrUpdate(Repeticiones repeticiones)
        {

            bool res = true;
            db.Session.Clear();

            ITransaction transaction = db.Session.BeginTransaction();
            try
            {
                db.Session.Save(repeticiones);
                transaction.Commit();
            }
            catch  {
                transaction.Rollback();
                db.Session.Clear();
                transaction = db.Session.BeginTransaction();
                try
                {
                    db.Session.SaveOrUpdate(repeticiones);
                    transaction.Commit();
                }
                catch 
                {
                    res = false;
                }
            }

            db.Session.Flush(); 
            return res;
        }

		public void UpdateObject(Repeticiones obj)
        {
			db.Session.Get(obj.GetType() , obj.GetType().Name);
        }


		public override Persistent GetNewInstance()
		{
			return (Repeticiones)Activator.CreateInstance(PersistentType);
			
		}
        protected IList DefaultProperyValueList(Type persistentType)
        {
            return db.Session.CreateCriteria(persistentType).List();
        }

        public virtual IList GetPropertyValueList(string propertyName, Repeticiones persistent)
        {
            return DefaultProperyValueList(persistent.GetType().GetProperty(propertyName).PropertyType);
        }*/
    }
}