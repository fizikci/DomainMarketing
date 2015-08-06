using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class ListViewDMExpertise : BaseEntity
    {
        public string RequesterMemberId { get; set; }
        public string ExpertMemberId { get; set; }
        public string DMItemId { get; set; }
        public string DomainName { get; set; }
        public string Status { get; set; }
        public string ReportContent { get; set; }
        public bool IsPublic { get; set; }
    }
}