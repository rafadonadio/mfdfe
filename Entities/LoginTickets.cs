using System;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities {
    public class LoginTickets:Persistent {
        private long idLoginTicket;
        private LoginTicketRequests loginTicketRequest;
        private DateTime generationTime;
        private DateTime expirationTime;
        private string token;
        private string sign;

        protected LoginTickets():this(0, null,DateTime.Now,DateTime.Now,String.Empty,String.Empty) {}
        
        public LoginTickets(long idLoginTicket, LoginTicketRequests loginTicketRequest, DateTime generationTime, DateTime expirationTime, string token, string sign) {
            IdLoginTicket = idLoginTicket;
            this.loginTicketRequest = loginTicketRequest;
            this.generationTime = generationTime;
            this.expirationTime = expirationTime;
            this.token = token;
            this.sign = sign;
        }

        public LoginTicketRequests LoginTicketRequest {
            get { return loginTicketRequest; }
        }

        public string Token {
            get { return token; }
        }

        public string Sign {
            get { return sign; }
        }

        public DateTime GenerationTime {
            get { return generationTime; }
        }

        public DateTime ExpirationTime {
            get { return expirationTime; }
        }

        public long IdLoginTicket {
            get { return idLoginTicket; }
            protected set { idLoginTicket = value; }
        }
    }
}
