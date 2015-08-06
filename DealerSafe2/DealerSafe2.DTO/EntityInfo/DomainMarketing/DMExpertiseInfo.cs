using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.EntityInfo.DomainMarketing
{
    public class DMExpertiseInfo
    {
        public string RequesterMemberId { get; set; }
        public string ExpertMemberId { get; set; }
        public string DMItemId { get; set; }
        public DMExpertiseStates Status { get; set; }
        public string ReportContent { get; set; }
        public bool IsPublic { get; set; }
    }
}
