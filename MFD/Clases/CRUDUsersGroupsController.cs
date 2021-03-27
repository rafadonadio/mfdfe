using System;
using Entities;
using Security;
using FrameWork.CRUDModel.Windows;
using FrameWork.DataBusinessModel.BusinessModel;
using System.Collections;
using FrameWork.CRUDModel;


namespace MFD.Clases
{
    public class CRUDUsersGroupsController : CRUDController 
    {
        public CRUDUsersGroupsController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType)
            : base(businessLogic, gridTitle, crudFormTitle, crudFormType)
        {
		}

        public CRUDUsersGroupsController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic, string crudFormTitle, Type crudFormType)
            : base( businessLogic, crudFormTitle, crudFormType)
        {
		}

        public CRUDUsersGroupsController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType, CRUDSelController parentController)
            : base(businessLogic, gridTitle, crudFormTitle, crudFormType, parentController)
        {
		}

        protected override void AdditionalInitializeCRUDForm(FrameWork.CRUDModel.Windows.UI.ICRUDForm form)
        {
            base.AdditionalInitializeCRUDForm(form);
            (form as UsersGroupsCRUD).PermissionCreateRequired += new PermissionEvent(CreatePermission);
            (form as UsersGroupsCRUD).PermissionDeleteRequired += new PermissionEvent(DeletePermission);
            (form as UsersGroupsCRUD).CreateCRUDFunction += new CreateCRUDFunctionEvent(CreateCRUDFunction);
            (form as UsersGroupsCRUD).CreateSpecialFunction += new CreateSpecialFunctionEvent(CreateSpecialFunction);
        }

        protected void CreatePermission(UsersGroups userGroup, IList functionsList)
        {
            foreach (Functions function in functionsList)
                if (!userGroup.FunctionsList.Contains(function)) 
                    userGroup.FunctionsList.Add(function);
        
            (crudForm as UsersGroupsCRUD).RefreshPermissionsList();
        }
        protected void DeletePermission(UsersGroups userGroup, IList functionsList)
        {
            foreach (Functions function in functionsList)
                if (userGroup.FunctionsList.Contains (function))
                    userGroup.FunctionsList.Remove(function);

            (crudForm as UsersGroupsCRUD).RefreshPermissionsList(); 
        }
        protected Functions CreateCRUDFunction(Modules module, CRUDAction action)
        {
            return new CRUDFunctions(module, action);
        }
        protected Functions CreateSpecialFunction(Modules module, Actions action)
        {
            SpecialFunctions function = new SpecialFunctions();
            function.Module = module;
            function.Action  = action;
            return function;
        }
    }
}
