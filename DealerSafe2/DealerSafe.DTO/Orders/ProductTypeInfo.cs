using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ProductTypeInfo
    {
        public bool Process { get; set; }
        public List<ProductTypeDetail> ProductTypes { get; set; }
        public class ProductTypeDetail
        {
            public int PrdNameId { get; set; }
            public int PrdGrpId { get; set; }
            public string PrdName { get; set; }
            public string PrdNameLngTr { get; set; }
            public bool PrdCouponUsage { get; set; }
            public bool PrdVoucherUsage { get; set; }
        }
    }
}
