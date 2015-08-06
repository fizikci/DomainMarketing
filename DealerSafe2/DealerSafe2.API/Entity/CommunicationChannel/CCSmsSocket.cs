using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.CommunicationChannel
{
    public class CCSmsSocket:NamedEntity
    {
        public string ApiId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Pattern { get; set; }
    }

}