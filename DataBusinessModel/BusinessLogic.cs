using System;
using System.Collections;
using System.Reflection;
using FrameWork.DataBusinessModel.DataModel;
using NHibernate;

namespace FrameWork.DataBusinessModel.BusinessModel
{
    /// <summary>
    /// nothing
    /// </summary>
    public abstract class BusinessLogic
    {
        private DBase db;

        public BusinessLogic()
        {
        }

        public BusinessLogic(DBase db)
        {
            this.db = db;
        }

        public virtual void SetParameters(DBase db)
        {
            this.db = db;
        }

        public virtual bool BusinessValidator(Persistent persistentObject, ErrorMessages messages)
        {
            messages.Clear();

            return true;
        }

        public virtual bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages)
        {
            messages.Clear();

            return true;
        }

        public virtual bool Save(Persistent persistent)
        {
            bool res = true;

            try
            {
                db.Session.Save(persistent);
            }
            catch 
            {
                res = false;
            }

            return res;
        }

        public virtual bool SaveOrUpdate(Persistent persistent)
        {
            bool res = true;

            try
            {
                db.Session.SaveOrUpdate(persistent);
            }
            catch 
            {
                res = false;
            }

            return res;
        }

        public virtual bool Update(Persistent persistent)
        {
            bool res = true;
            ITransaction transaction = db.Session.BeginTransaction();

            try
            {
                db.Session.Update(persistent);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                res = false;
                transaction.Rollback();
                throw ex;
            }

            return res;
        }

        public virtual bool Delete(Persistent persistent)
        {
            bool res = true;
            ITransaction transaction = db.Session.BeginTransaction();

            try
            {
                db.Session.Delete(persistent);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                res = false;
                transaction.Rollback();
                throw ex;
            }

            return res;
        }

        public void Evict(Persistent persistent)
        {
            DBConnection.Session.Evict(persistent);
        }

        public void Refresh(Persistent persistent)
        {
            if (persistent.Id != 0) DBConnection.Session.Refresh(persistent);
        }

        public Persistent GetObject(int id)
        {
            return (Persistent)DBConnection.Session.Get(PersistentType, id);
        }

        public virtual Persistent GetNewInstance()
        {
            return (Persistent)Activator.CreateInstance(PersistentType);
        }

        protected IList DefaultProperyValueList(Type persistentType)
        {
            return DBConnection.Session.CreateCriteria(persistentType).List();
        }
        public virtual IList GetPropertyValueList(string propertyName, Persistent persistent)
        {
            return DefaultProperyValueList(persistent.GetType().GetProperty(propertyName).PropertyType);
        }

        public virtual IList GetDataSource()
        {
            try
            {
                return CreateDataSourceCriteria().List();
            }
            catch { return (IList)(new ArrayList()); }
        }

        protected virtual ICriteria CreateDataSourceCriteria()
        {
            return DBConnection.Session.CreateCriteria(PersistentType);
        }

        public virtual IList GetDTODataSource()
        {
            IList list = GetDataSource();
            return ConvertToDTOList(list);
        }

        protected IList ConvertToDTOList(IList list)
        {
            IList dtoList = new ArrayList();

            Type[] arrayType = new Type[1];
            Object[] arrayObj = new Object[1];

            arrayType[0] = PersistentType;
            ConstructorInfo constructor = DTOType.GetConstructor(arrayType);

            foreach (Persistent item in list)
            {
                arrayObj[0] = item;
                dtoList.Add(constructor.Invoke(arrayObj));
            }

            return dtoList;

        }

        public virtual IList GetDTODataSource(DateTime fechaDesde, DateTime fechaHasta)
        {
            throw new NotImplementedException();
        }
        public abstract Type PersistentType { get; }

        public virtual Type DTOType
        {
            get
            {
                return PersistentType;
            }
        }

        public DBase DBConnection
        {
            get { return db; }
            set { db = value; }
        }

        public virtual bool CreateAllowed(Persistent persistentParent, ErrorMessages messages)
        {
            return true;
        }

        public virtual bool CreateAllowed(ErrorMessages messages)
        {
            return true;
        }

        public virtual bool RetrieveAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            return true;
        }

        public virtual bool UpdateAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            return true;
        }

        public virtual bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            return true;
        }
        public virtual Object GetModule()
        {
            return null;
        }

    }
}