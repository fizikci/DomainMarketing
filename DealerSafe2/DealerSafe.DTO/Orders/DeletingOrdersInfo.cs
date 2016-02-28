using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class DeletingOrdersInfo
    {
        public bool Process { get; set; }
        public List<int> OrderIDList { get; set; }
    }
}
