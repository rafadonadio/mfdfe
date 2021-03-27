using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace MFDService
{
	public class ReadUrlWSConfig
	{
		static ReadUrlWSConfig()
        {}
		public static string UrlWSConfig(string key) {

			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			ConfigurationSectionGroup configGroup = config.SectionGroups["applicationSettings"];
			if (configGroup != null)
			{
				ClientSettingsSection settingsSection = (ClientSettingsSection)configGroup.Sections["MFDService.Properties.Settings"];
				if (settingsSection != null)
				{
					SettingElementCollection elements = settingsSection.Settings;
					if(elements!=null){
						SettingElement ele = settingsSection.Settings.Get(key);
						if(ele!=null)
							return ele.Value.ValueXml.InnerXml;
					}
				}
			}
			return ReadDllConfig(key);

		}

		private static string ReadDllConfig(string key)
		{
			XmlDocument config = new XmlDocument();
			config.Load( AppDomain.CurrentDomain.BaseDirectory + @"MFDService.dll.config");
			//MFDService.Properties.Settings/setting[@name='MFDService_ar_gov_afip_wswhomo_Service']
			XmlNode node = config.SelectSingleNode("//MFDService.Properties.Settings/setting[@name='"+key+"']");
			return node.InnerText;
		}
	}
}
