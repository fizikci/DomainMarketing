using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqStaffMemberContactsApprove
    {
        public int contactId { get; set; }
        public int memberId { get; set; }
    }
}
