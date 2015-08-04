using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.EntityInfo.Crm
{
    public class CrmActivityInfo : BaseEntityInfo
    {
        public string MemberId { get; set; }

        public Departments Department { get; set; }
        public ActivityTypes ActivityType { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }

        public JobStates State { get; set; }
        public int ReplyCount { get; set; }
    }

    public class CrmActivityMessageInfo : BaseEntityInfo
    {
        public string CrmActivityId { get; set; }
        public string MemberId { get; set; }
        public string Message { get; set; }

        public string MemberName { get; set; }
    }
}
