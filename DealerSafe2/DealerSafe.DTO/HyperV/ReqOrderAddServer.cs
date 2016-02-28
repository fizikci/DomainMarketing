using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.HyperV
{
    public class ReqOrderAddServer: ReqOrder
    {
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public string ProductName { get; set; }
    }
}
