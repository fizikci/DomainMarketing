using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqStaffCheckContactApprove
    {
        public int contactId { get; set; }

        public int SessionMemberId { get; set; }
    }
}
