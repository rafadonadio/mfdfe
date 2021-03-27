using System;
using System.Xml;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities {
    public class LoginTicketRequests:Persistent {
        private Empresas empresa;
        private DateTime generationTime;
        private DateTime expirationTime;
        protected LoginTicketRequests():this(null){}
        public LoginTicketRequests(Empresas empresa) {
            this.empresa = empresa;
            generationTime = DateTime.Now;
            expirationTime = GenerationTime.AddMinutes(10);
        }

        public Empresas Empresa {
            get { return empresa; }
        }

        public DateTime GenerationTime {
            get { return generationTime; }
        }

        public DateTime ExpirationTime {
            get { return expirationTime; }
        }
        
        //public string Serialize() {
        //    XmlDocument document = new XmlDocument();
        //    XmlNode rootNode = document.CreateNode("loginTicketRequestType", "loginTicketRequest", "");
        //    rootNode.Attributes.Append(document.CreateAttribute("version"));
        //    rootNode.Attributes["version"].Value = "1.0";
        //    XmlNode headerNode = document.CreateNode("headerType", "header", "");
        //    headerNode.AppendChild(document.CreateNode("xsd:string","source",""));
        //    headerNode.AppendChild(document.CreateNode("xsd:string","destination",""));
        //    headerNode.AppendChild(document.CreateNode("xsd:string","uniqueId",""));
        //    headerNode.AppendChild(document.CreateNode("xsd:string","generationTime",""));
        //    headerNode.AppendChild(document.CreateNode("xsd:string","expirationTime",""));
            
        //    XmlNode serviceNode = document.CreateNode("serviceType", "service", "");
        //    serviceNode.Value = "wsfe";
        //    rootNode.AppendChild(headerNode);
        //    rootNode.AppendChild(serviceNode);
        //    document.AppendChild(rootNode);
                                               
        //    return document.ToString();
        //}
    }
}
