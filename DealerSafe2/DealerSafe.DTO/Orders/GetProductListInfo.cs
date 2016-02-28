using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetProductListInfo
    {
        public bool Process { get; set; }
        public List<ProductInfo> ProductList { get; set; }
        public class ProductInfo
        {
            public int OrderNumber { get; set; }
            public string ProductName { get; set; }
        }
    }
}
