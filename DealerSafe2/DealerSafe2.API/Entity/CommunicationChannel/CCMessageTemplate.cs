using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.DTO.Enums;


namespace DealerSafe2.API.Entity.CommunicationChannel
{
    public class CCMessageTemplate : BaseEntity
    {

        public string CCMessageGroupId { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string SqlCommand { get; set; }

    }

    public class ListViewCCMessageTemplate : BaseEntity
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public string CCMessageGroupName { get; set; }
    }

    public class ViewCCMessageTemplate : CCMessageTemplate
    {
        public string CCMessageGroupName { get; set; }
    }
}