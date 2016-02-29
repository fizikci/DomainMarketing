using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMBrokerageInfo : BaseEntityInfo
    {
        public string RequesterMemberId { get; set; }
        public string BrokerFullName { get; set; }
        public string BrokerMemberId { get; set; }
        public string DMItemId { get; set; }
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public DMBrokerageStates Status { get; set; }
        public string ReportContent { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
