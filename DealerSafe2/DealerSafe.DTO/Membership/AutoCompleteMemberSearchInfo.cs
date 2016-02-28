using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class AutoCompleteMemberSearchInfo
    {
        public List<MemberDetail> Members { get; set; }
    }
    public class MemberDetail
    {
        public int MemberID { get; set; }
        public string Fullname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Username { get; set; }
        public string Remarks { get; set; }
    }
}
