using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqComment : BaseRequest
    {
        public string ToMemberId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
