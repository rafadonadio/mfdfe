using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BusinessLogic;
namespace MFD.Clases
{
    class FTPSettingsController
    {
        protected FTPSettingsForm settingsForm;
        protected SettingsBL settingsLogic;

        public FTPSettingsController(SettingsBL sl)
        {
            settingsLogic = sl;
            settingsForm = new FTPSettingsForm();
            settingsLogic.UpdateObject(FTPSettings.Instance);
            settingsForm.Setting = FTPSettings.Instance;
            settingsForm.SaveObject += new ObjectEvent(SaveObject);
        }

        public void SetSettingsLogic(SettingsBL sl)
        {
            settingsLogic = sl;
        }


        public void SaveObject(Object set)
        {
            settingsLogic.SaveOrUpdate(set as FTPSettings);
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
    }
}
