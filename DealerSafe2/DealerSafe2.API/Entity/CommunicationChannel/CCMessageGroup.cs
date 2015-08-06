using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.CommunicationChannel
{
    public class CCMessageGroup : NamedEntity
    {
        public string CCProfileId { get; set; }
    }

    public class ListViewCCMessageGroup : BaseEntity
    {
        public string Name { get; set; }

        public string CCProfileId { get; set; }

        public string CCProfileName { get; set; }

    }

}