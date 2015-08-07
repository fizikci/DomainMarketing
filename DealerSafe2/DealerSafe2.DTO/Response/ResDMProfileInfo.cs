using DealerSafe2.DTO.EntityInfo.DomainMarketing;
using System.Collections.Generic;

namespace DealerSafe2.DTO.Response
{
    public class ResDMProfileInfo
    {
        public List<EntityCommentInfo> Comments { get; set; }

        public List<EntityCommentInfo> Complaints { get; set; }

        public List<ListViewSalesInfo> Sales { get; set; }

        public DMMemberInfo MemberInfo { get; set; }
    }
}
