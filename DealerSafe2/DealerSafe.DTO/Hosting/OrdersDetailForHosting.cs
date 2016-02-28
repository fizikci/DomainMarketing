using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class OrdersDetailForHosting
    {
        public int ID { get; set; }
        public decimal OrderID { get; set; }
        public decimal ProductID { get; set; }
        public decimal MemberID { get; set; }
        public string ProductName { get; set; }
        public float ProductQuantity { get; set; }
        public string ProductQuantityType { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPriceType { get; set; }
        public float ProductTax { get; set; }
        public int Status { get; set; }
        public float ProductPriceWithQuantity { get; set; }
        public int HostingID { get; set; }
        public int DomainID { get; set; }
        public int TargetID { get; set; }
        public int ProductTypeId { get; set; }
        public int EkstraUzatma { get; set; }
    }
}
