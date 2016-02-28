using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqMembersMobile
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string EMail { get; set; }
        public string Phone2 { get; set; }
        public int ActiveStatus { get; set; }
        public string CouponCode { get; set; }
        public string FirstPassword { get; set; }
        public bool Check { get; set; }
        public string Ip { get; set; }
        public DateTime CTime { get; set; }
    }
}
