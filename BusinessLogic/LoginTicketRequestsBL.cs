using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Entities;
using Tools.XML.Generator;

namespace BusinessLogic
{
    public class LoginTicketRequestsBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic {
        private const string LoginTicketRequestNodeName = "loginTicketRequest";
        private const string HeaderNodeName = "header";
        private const string ServiceNodeName = "service";
        private const string SourceNodeName = "source";
        private const string DestinationNodeName = "destination";
        private const string UniqueIDNodeName = "uniqueId";
        private const string GenerationTimeNodeName = "generationTime";
        private const string ExpirationTimeNodeName = "expirationTime";
        
        public override Type PersistentType {
            get { return typeof(LoginTicketRequests); }
        }
        
        public LoginTicketRequests GenerateLoginTicket(Empresas empresa) {
            LoginTicketRequests loginTicketRequest = new LoginTicketRequests(empresa);
            Save(loginTicketRequest);
            return loginTicketRequest;
        }
        
        public XmlDocument GenerateLoginTicketRequestXML(LoginTicketRequests loginTicketRequest) {
            XmlQualifiedName qualifiedName=new XmlQualifiedName(LoginTicketRequestNodeName);
            //TODO: SACAR EL hardcode del XSD
            XMLGenerator generator = new XMLGenerator("LoginTicketRequest.xsd", qualifiedName);
            Stream xmlStream = new MemoryStream();
            XmlTextWriter writer=new XmlTextWriter(xmlStream,Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            generator.WriteXml(writer);
            XmlDocument document=new XmlDocument();
            xmlStream.Seek(0, SeekOrigin.Begin);
            XmlReader reader = new XmlTextReader(xmlStream);
            document.Load(reader);
            reader.Close();
            writer.Close();
            xmlStream.Close(); xmlStream.Dispose();

            EmpresasBL empresasBL = new EmpresasBL();
            empresasBL.SetParameters(DBConnection);
            
            
            XmlElement headerNode = document[LoginTicketRequestNodeName][HeaderNodeName];
            headerNode[SourceNodeName].InnerText = loginTicketRequest.Empresa.DNOrigen;
            headerNode[DestinationNodeName].InnerText = loginTicketRequest.Empresa.DNDestino;
            headerNode[UniqueIDNodeName].InnerText = loginTicketRequest.Id.ToString();
            headerNode[GenerationTimeNodeName].InnerText = XmlConvert.ToString(loginTicketRequest.GenerationTime, XmlDateTimeSerializationMode.RoundtripKind);
            headerNode[ExpirationTimeNodeName].InnerText = XmlConvert.ToString(loginTicketRequest.ExpirationTime, XmlDateTimeSerializationMode.RoundtripKind);
            document[LoginTicketRequestNodeName][ServiceNodeName].InnerText = GeneralSettings.Instance.WSNegocio;
            
            //writer = new XmlTextWriter("c:\\pepe.xml",Encoding.UTF8);
            //writer.Formatting = Formatting.Indented;
            //document.WriteTo(writer);
            //writer.Flush();
            //writer.Close();
            return document;
        }
    }
}
