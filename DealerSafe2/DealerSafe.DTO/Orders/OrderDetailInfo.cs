using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe.DTO.Orders
{
    public class OrderDetailInfo
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public string CouponKey { get; set; }

        public decimal UnitPrice { get; set; }
        public Currencies Currency { get; set; }
        public decimal ExchangeRate { get; set; }

        public decimal Amount { get; set; }
    }
}
