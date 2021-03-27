using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BusinessLogic;
using FrameWork.DataBusinessModel.DataModel;
using System.Collections;
namespace MFD.Clases
{
    public class RepeticionesController
    {
		protected RepeticionesCRUD repeticionesForm;
		protected RepeticionesBL repeticionesLogic;

        public RepeticionesController(RepeticionesBL sl)
        {
            repeticionesLogic = sl;
            repeticionesForm = new RepeticionesCRUD();
			/*repeticionesLogic.UpdateObject(Repeticiones.Instance);
			repeticionesForm.Repeticiones = Repeticiones.Instance;
			*/
			Repeticiones rep = new Repeticiones();
			/*rep.Id = 154;
			rep.IdComprobante = 154;
			*/
			//rep.DiaMes = 25;
			//repeticionesLogic.UpdateObject(rep);
			//repeticionesForm.Repeticiones = rep;// new Repeticiones();
			//repeticionesForm.SaveObject += new ObjectEvent(SaveObject);
			//repeticionesForm.GetObjectById += new GetObjectEvent(GetObjectById);
			//repeticionesForm.PropertyValueListNeeded += new PropertyValueListNeeded(PropertyValueListNeeded);
        }

        public void SetRepeticionesLogic(RepeticionesBL sl)
        {
            repeticionesLogic = sl;
        }


        public void SaveObject(Object set)
        {
            repeticionesLogic.SaveOrUpdate(set as Repeticiones);
        }


        public void ShowForm()
        {
            if (repeticionesForm != null)
            {
                repeticionesForm.Open();
            }
        }
        public void HideForm()
        {
            if (repeticionesForm != null)
            {
                repeticionesForm.Hide();
            }
        }
/*
        protected virtual IList PropertyValueListNeeded(string propertyName, Settings persistentObject)
        {
            return repeticionesLogic.GetPropertyValueList(propertyName, persistentObject);
        }

        protected virtual Object GetObjectById(Object obj, String objName)
        { 
            return repeticionesLogic.GetObjectById(obj, objName);
        }
 */
    }
}
