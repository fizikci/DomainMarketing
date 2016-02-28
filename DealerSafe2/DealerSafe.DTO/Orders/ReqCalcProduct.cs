using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DealerSafe.DTO.Orders
{
    public class ReqCalcProduct
    {
        [Description("Order number of the member order's")]
        public int OrderID { get; set; }
    }
}
