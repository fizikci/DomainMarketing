using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetOrdersDetailsInfo
    {
        public bool Process { get; set; }
        public List<OrdersDetailType> OrdersDetails { get; set; }

        public class OrdersDetailType
        {
            public int Id { get; set; }
            public decimal OrderID { get; set; }
            public decimal ProductID { get; set; }
            public decimal MemberID { get; set; }
            public string ProductName { get; set; }
            public double ProductQuantity { get; set; }
            public string ProductQuantityType { get; set; }
            public decimal ProductPrice { get; set; }
            public string ProductPriceType { get; set; }
            public double ProductTax { get; set; }
            public int Status { get; set; }
            public double ProductPriceWithQuantity { get; set; }
            public int HostingID { get; set; }
            public int DomainID { get; set; }
            public int TargetID { get; set; }
            public int ProductTypeId { get; set; }
            public int EkstraUzatma { get; set; }
        }
    }
}
