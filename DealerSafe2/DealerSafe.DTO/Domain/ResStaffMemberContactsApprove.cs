using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResStaffMemberContactsApprove
    {
        public int Id { get; set; }
        public DateTime DateOfApproving { get; set; }
        public int MemberId { get; set; }
        public int ContactId { get; set; }
        public int IsApproved { get; set; }
        public int TypeOfApproving { get; set; }
        public string CodeOfApproving { get; set; }
        public string SentTo { get; set; }
    }
}
