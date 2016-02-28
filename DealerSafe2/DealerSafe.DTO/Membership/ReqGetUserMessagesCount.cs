using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetUserMessages
    {
        public int MemberId { get; set; }
        public bool LookIsRead { get; set; }
        public int IsRead { get; set; }
        public int RecStatus { get; set; }
    }
}
