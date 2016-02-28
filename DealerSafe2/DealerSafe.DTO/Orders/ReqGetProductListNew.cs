using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqGetProductListNew
    {
        [Description("Product id list")]
        public List<string> ProductIds { get; set; }
    }
}
