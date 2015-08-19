using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewDMBrokerage : BaseEntity
    {
        public string RequesterMemberId { get; set; }
        public string BrokerFullName { get; set; }
        public string BrokerMemberId { get; set; }
        public string DMItemId { get; set; }
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public string Status { get; set; }
        public string ReportContent { get; set; }
    }
}