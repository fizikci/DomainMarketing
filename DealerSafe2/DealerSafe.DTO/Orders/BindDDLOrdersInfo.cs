using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class BindDDLOrdersInfo
    {
        public bool Process { get; set; }
        public List<Int32> OrderIDList { get; set; }
    }
}
