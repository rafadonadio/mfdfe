using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel;
using NHibernate;
using Entities;
using System.Collections;

namespace BusinessLogic
{
    public class LicensesBL
    {
        protected DBase db;        
        
		public LicensesBL() {
		}

        public LicensesBL(DBase db)
        {
			this.SetParameters(db);
		}

		public void SetParameters(DBase db) 
		{
			this.db = db;
		}

        public bool SaveOrUpdate(Licenses license)
        {

            bool res = true;
            db.Session.Clear();

            ITransaction transaction = db.Session.BeginTransaction();
            try
            {
                db.Session.Save(license);
                transaction.Commit();
            }
            catch  {
                transaction.Rollback();
                db.Session.Clear();
                transaction = db.Session.BeginTransaction();
                try
                {
                    db.Session.SaveOrUpdate(license);
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

        public void UpdateObject(Licenses obj)
        {
            db.Session.Get(obj.GetType() , obj.PcName );
        }
    }
}
