using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqGetPrices
    {
        public int ServerId { get; set; }
        public List<int> Products { get; set; }
    }
}
