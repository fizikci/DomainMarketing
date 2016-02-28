using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqOrder
    {
        public List<int> Products { get; set; }
        public int Period { get; set; }
    }
}
