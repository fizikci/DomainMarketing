using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqReadUserMessage
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
    }
}
