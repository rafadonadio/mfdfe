using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Entities;
using FrameWork.DataBusinessModel;

namespace BusinessLogic
{
    public class GeneralSettingsBL : SettingsBL 
    {
        public GeneralSettingsBL(DBase db) : base(db) { }
        public override IList GetPropertyValueList(string propertyName, Settings persistent)
        {
            if (propertyName == "EmpresaDefault")
            {
                EmpresasBL empBL = new EmpresasBL();
                empBL.SetParameters(db);
                return empBL.GetDataSource();
            }
            else if(propertyName=="FormatoComprobante") {
                IList result = new ArrayList();
                foreach (FormatoComprobante formatoComprobante in Enum.GetValues(typeof(FormatoComprobante))) 
                    result.Add(formatoComprobante);
                return result;
            }
            else
                return DefaultProperyValueList(persistent.GetType().GetProperty(propertyName).PropertyType);
        }

        public virtual Object GetObjectById(Object obj, String objName)
        {
            if (objName == "Empresas")
            {
                EmpresasBL empBL = new EmpresasBL();
                empBL.SetParameters(db);
                return empBL.GetObject((int)obj);
            }
            else
                return null;
            
        }
    }
}
