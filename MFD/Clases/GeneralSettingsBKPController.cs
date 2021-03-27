using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BusinessLogic;
using FrameWork.DataBusinessModel.DataModel;
using System.Collections;
namespace MFD.Clases
{
    class GeneralSettingsBKPController
    {
		protected HacerBackup settingsForm;
        protected GeneralSettingsBL settingsLogic;

        public GeneralSettingsBKPController(GeneralSettingsBL sl)
        {
            settingsLogic = sl;
            settingsForm = new HacerBackup();
            settingsLogic.UpdateObject(GeneralSettings.Instance);
            settingsForm.Setting = GeneralSettings.Instance;
            settingsForm.SaveObject += new ObjectEvent(SaveObject);
            settingsForm.GetObjectById += new GetObjectEvent(GetObjectById);
            settingsForm.PropertyValueListNeeded += new PropertyValueListNeeded(PropertyValueListNeeded);
        }

        public void SetSettingsLogic(GeneralSettingsBL sl)
        {
            settingsLogic = sl;
        }


        public void SaveObject(Object set)
        {
            settingsLogic.SaveOrUpdate(set as GeneralSettings);
        }


        public void ShowForm()
        {
            if (settingsForm != null)
            {
                settingsForm.Open();
            }
        }
        public void HideForm()
        {
            if (settingsForm != null)
            {
                settingsForm.Hide();
            }
        }

        protected virtual IList PropertyValueListNeeded(string propertyName, Settings persistentObject)
        {
            return settingsLogic.GetPropertyValueList(propertyName, persistentObject);
        }

        protected virtual Object GetObjectById(Object obj, String objName)
        { 
            return settingsLogic.GetObjectById(obj, objName);
        }
    }
}
