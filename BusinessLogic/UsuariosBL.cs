using System;
using System.Collections;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Entities;
using FrameWork.Tools.Validation;
using NHibernate;
using Security;
namespace BusinessLogic
{
    [Serializable]
    public class ModuloUsuarios: Modules
    {
        public ModuloUsuarios()
        { }
    }

    public class UsuariosBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic 
    {
        public override Type PersistentType
        {
            get { return typeof(Usuarios); }
        }

        public Usuarios GetUserByNameAndPass(String username, String password)
        {
            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
            crit.Add(new NHibernate.Expression.EqExpression("Nombre", username));
            crit.Add(new NHibernate.Expression.EqExpression("Password", password ));

            return (Usuarios)crit.UniqueResult();
        }

        public override object GetModule()
        {
            return new ModuloUsuarios();
        }    
    }
}
