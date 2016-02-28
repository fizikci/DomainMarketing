using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ReqGetExpiringProductList
    {
        public int MemberId { get; set; }
        public int TimeRemaining { get; set; }
        public int FirstIndex { get; set; }
        public int LastIndex { get; set; }
    }
}
