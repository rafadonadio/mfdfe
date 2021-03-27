using System;
using System.Collections.Generic;
using System.Text;
using Security;
using FrameWork.CRUDModel;

namespace FrameWork.CRUDModel.Windows
{
    public interface ICRUDSecurityManager
    {

        bool HavePermissions(Security.Modules module, CRUDAction action);
    
    }
}
