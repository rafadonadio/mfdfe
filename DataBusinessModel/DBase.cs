using System;
using NHibernate;
using NHibernate.Cfg;

namespace FrameWork.DataBusinessModel {
	/// <summary>
	/// Encapsula el manejo de la sesión de NHibernate
	/// </summary>
	public class DBase {
		private Configuration cfg;
		private ISessionFactory factory;
		private ISession session;
		ITransaction transaction;

	    public DBase() {
            factory = null;
	        session = null;
	    }
        
	    public void ConfigureFromXML(string xmlPath) {
            ConfigureFromXML(xmlPath, null);
        }
	    
	    public void ConfigureFromXML(string xmlPath, string configurationPath) {
            cfg = new Configuration();
	        if((configurationPath!=null) && (configurationPath.Trim().Length>0))
	            cfg.Configure(configurationPath);
            cfg.AddXmlFile(xmlPath);
            factory = cfg.BuildSessionFactory();
            session = factory.OpenSession();
	    }
		public DBase(string assemblyName) : this(assemblyName, null) {
		}
	    
	    public DBase(string[] assembliesNames) : this(assembliesNames, null) {
	    }

	    public DBase(string assemblyName, string configurationPath) {
            cfg = new Configuration();
	        if((configurationPath!=null) && (configurationPath.Trim().Length>0))
	            cfg.Configure(configurationPath);
            cfg.AddAssembly(assemblyName);
            factory = cfg.BuildSessionFactory();
            session = factory.OpenSession();
        }

        public DBase(string[] assembliesNames, string configurationPath) {
            cfg = new Configuration();
            if ((configurationPath != null) && (configurationPath.Trim().Length > 0))
                cfg.Configure(configurationPath);
            foreach (string assemblyName in assembliesNames) cfg.AddAssembly(assemblyName);
            factory = cfg.BuildSessionFactory();
            session = factory.OpenSession();

        }

		~DBase() {
			session.Dispose();
			factory.Close();
			cfg = null;
		}

		public void BeginTransaction() {
			transaction = Session.BeginTransaction();
		}

		public void CommitTransaction() {
			transaction.Commit();
		}

		public void RollBackTransaction() {
			transaction.Rollback();
		}


		public ISession Session {
			get { return session; }
		}

		public void Save(object dataObject) {
			try {
				session.Save(dataObject);
				session.Flush();
			}
			catch (Exception exc) {
				throw exc;
			}

		}

		public void Update(object dataObject) {
			try {
				session.Update(dataObject);
				session.Flush();
			}
			catch (Exception exc) {
				throw exc;
			}
		}

		public void Delete(object dataObject) {
			try {
				session.Delete(dataObject);
				session.Flush();
			}
			catch (Exception exc) {
				throw exc;
			}
		}

	}
}