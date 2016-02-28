using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetMemberMessageCount
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }
    }
}
