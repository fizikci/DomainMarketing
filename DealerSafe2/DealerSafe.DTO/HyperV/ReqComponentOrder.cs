using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqComponentOrder: ReqOrder
    {
        public int ServerId { get; set; }
    }
}
