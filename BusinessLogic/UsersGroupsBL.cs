using System;
using System.Collections.Generic;
using System.Text;
using Security;
using FrameWork.DataBusinessModel;


namespace BusinessLogic
{
    public class UsersGroupsBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public UsersGroupsBL()
        { }
        public UsersGroupsBL(DBase db) : base(db)
        {
			
		}

        public override object GetModule()
        {
            return new ModuloUsuarios();
        }
        
        public override Type PersistentType
        {
            get { return typeof(UsersGroups); }
        }
        //public bool SaveOrUpdate(UsersGroups usergroup)
        //{
        //    bool res = true;
        //    DBConnection.Session.Clear();
        //    try
        //    {
        //        DBConnection.Session.SaveOrUpdate(usergroup);
        //    }
        //    catch
        //    {
        //        res = false;
        //    }

        //    DBConnection.Session.Flush();
        //    return res;
        //}
        //public bool Save(UsersGroups usergroup)
        //{
        //    bool res = true;
        //    DBConnection.Session.Clear();
        //    try
        //    {
        //        DBConnection.Session.Save(usergroup);
        //    }
        //    catch
        //    {
        //        res = false;
        //    }

        //    DBConnection.Session.Flush();
        //    return res;
        //}
    }
}
