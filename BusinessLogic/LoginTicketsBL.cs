using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Entities;
using NHibernate;
using NHibernate.Expression;

namespace BusinessLogic
{
    public class LoginTicketsBL:FrameWork.DataBusinessModel.BusinessModel.BusinessLogic {
        private const string LoginTicketResponseNodeName = "loginTicketResponse";
        private const string HeaderNodeName = "header";
        private const string SourceNodeName = "source";
        private const string DestinationNodeName = "destination";
        private const string UniqueIDNodeName = "uniqueId";
        private const string GenerationTimeNodeName = "generationTime";
        private const string ExpirationTimeNodeName = "expirationTime";
        private const string CredentialsNodeName = "credentials";
        private const string TokenNodeName = "token";
        private const string SignNodeName = "sign";
        
        public override Type PersistentType {
            get { return typeof (LoginTickets); }
        }


        public LoginTickets GetLoginTicketFromXML(XmlDocument document, LoginTicketRequests request) {
            LoginTickets result = null;
            
            XmlNode headerNode = document[LoginTicketResponseNodeName][HeaderNodeName];
            XmlNode credentialsNode = document[LoginTicketResponseNodeName][CredentialsNodeName];
            DateTime generationTime = XmlConvert.ToDateTime(headerNode[GenerationTimeNodeName].InnerText, XmlDateTimeSerializationMode.RoundtripKind);
            DateTime expirationTime = XmlConvert.ToDateTime(headerNode[ExpirationTimeNodeName].InnerText, XmlDateTimeSerializationMode.RoundtripKind);
            long requestID = XmlConvert.ToInt64(headerNode[UniqueIDNodeName].InnerText);
            
            
            
            //TODO: validar que lo que devolvio el WS sea válido (expiration, source, destination, etc)
            result=new LoginTickets(requestID, request, generationTime, expirationTime, credentialsNode[TokenNodeName].InnerText, credentialsNode[SignNodeName].InnerText);
            Save(result);

            return result;
        }
        
        public LoginTickets GetCurrentLoginTicket(Empresas empresa) {
            LoginTickets result = null;
            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
            crit.Add(Expression.Le("GenerationTime", DateTime.Now));
            crit.Add(Expression.Ge("ExpirationTime", DateTime.Now));
            crit.CreateCriteria("LoginTicketRequest").Add(Expression.Eq("Empresa", empresa));
            crit.SetMaxResults(1);
            IList results = crit.List();
            if (results.Count > 0) result = results[0] as LoginTickets;
            
            return result;
        }
    }
}
