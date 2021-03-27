using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net;
using System.Net.Cache;
//using System.Runtime.InteropServices;


namespace MFD.Clases
{

	public class Status
	{
		static Status()
        {
        }

        ////Creating the extern function...
        //[DllImport("wininet.dll")]
        //private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        ////Creating a function that uses the API function...
        //public static bool IsConnectedToInternet()
        //{
        //    int Desc;
        //    return InternetGetConnectedState(out Desc, 0);
        //}
        //////Use function 
        ////if (IsConnectedToInternet())
        ////{
        ////MessageBox.Show("Netwok Connection Up");
        ////}
        ////else
        ////{
        ////MessageBox.Show("Sorry! Network Connection down.");
        ////}


        public static void CheckStatus(object form)
        {
            try
            {
                if (ChequearConexion())
                {
                    ((MFD.Main)(form)).StatusConn.Image = global::MFD.Properties.Resources.green;// Image.FromFile("Resources/green.ico");
                    if (Status.ChequearWS())
                        ((MFD.Main)(form)).StatusWS.Image = global::MFD.Properties.Resources.green;//Image.FromFile("Resources/green.ico");

                    else
                        ((MFD.Main)(form)).StatusWS.Image = global::MFD.Properties.Resources.red;// Image.FromFile("Resources/red.ico");
                }
                else
                {
                    ((MFD.Main)(form)).StatusConn.Image = global::MFD.Properties.Resources.red;// Image.FromFile("Resources/red.ico");
                    ((MFD.Main)(form)).StatusWS.Image = global::MFD.Properties.Resources.red;// Image.FromFile("Resources/red.ico");
                }
            }
            catch (Exception ex)
            {
               string err = ex.Message;
                //throw ex;
            }
        }

		public static bool ChequearWS()
		{
			//return ChequearUrl("https://servicios1.afip.gov.ar/wsfe/service.asmx");
			//return ChequearUrl(Properties.Settings.Default.MFD_ar_gov_afip_wswhomo_Service);
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
				ConfigurationSectionGroup configGroup = config.SectionGroups["applicationSettings"];
				ClientSettingsSection settingsSection = (ClientSettingsSection)configGroup.Sections["MFDService.Properties.Settings"];
				SettingElementCollection elements = settingsSection.Settings;
				SettingElement ele = settingsSection.Settings.Get("MFDService_ar_gov_afip_wswhomo_Service");
				string url = ele.Value.ValueXml.InnerXml;
				return ChequearUrl(url);
		}
		public static bool ChequearConexion()
		{
			return ChequearUrl("http://www.google.com");
			//return  IsConnectedToInternet();
		}
		private static bool ChequearUrl(string url)
		{
			HttpWebRequest req;
			HttpWebResponse resp;
			try
			{
				// Set a default policy level for the "http:" and "https" schemes.
				HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
				HttpWebRequest.DefaultCachePolicy = policy; 
				req = (HttpWebRequest)WebRequest.Create(url);
				req.Timeout = 100000;

				// Define a cache policy for this request only. 
				HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
				req.CachePolicy = noCachePolicy;
				resp = (HttpWebResponse)req.GetResponse();
				req = null;
				if (resp.StatusCode.ToString().Equals("OK"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex) 
			{
				string error = ex.Message;
				return false;
			}
		}
	}
}
