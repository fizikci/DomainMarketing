using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqChangeUserName
    {
        [Description("Member Number of the member")]
        public int MemberId { get; set; }

        [Description("Security code of the member")]
        public string SecurityCode { get; set; }

        [Description("Member UserName of the member")]
        public string OldUserName { get; set; }

        [Description("Member UserName of the member")]
        public string NewUserName { get; set; }
    }
}
