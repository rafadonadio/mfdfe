using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel;
using NHibernate;
using Entities;
using System.Collections;

namespace BusinessLogic
{

    public class SettingsBL
    {
        protected DBase db;        
        
		public SettingsBL() {
		}

        public SettingsBL(DBase db)
        {
			this.SetParameters(db);
		}

		public void SetParameters(DBase db) {
			this.db = db;
		}
        
        public bool SaveOrUpdate(Settings settings)
        {

            bool res = true;
            db.Session.Clear();

            ITransaction transaction = db.Session.BeginTransaction();
            try
            {
                db.Session.Save(settings);
                transaction.Commit();
            }
            catch  {
                transaction.Rollback();
                db.Session.Clear();
                transaction = db.Session.BeginTransaction();
                try
                {
                    db.Session.SaveOrUpdate(settings);
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

        public void UpdateObject(Settings obj)
        {
            db.Session.Get(obj.GetType() , obj.GetType().Name);
        }

        protected IList DefaultProperyValueList(Type persistentType)
        {
            return db.Session.CreateCriteria(persistentType).List();
        }

        public virtual IList GetPropertyValueList(string propertyName, Settings persistent)
        {
            return DefaultProperyValueList(persistent.GetType().GetProperty(propertyName).PropertyType);
        }
    }
}
