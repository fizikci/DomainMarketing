using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Hosting
{
    public class TempEntity
    {
        public decimal ID { get; set; }
        public decimal OrderId { get; set; }
        public decimal OrderDetailId { get; set; }
        public string DomainName { get; set; }
        public string PanelUserName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal MemberID { get; set; }
        public string ProductName { get; set; }
        public double ProductQuantity { get; set; }
        public string ProductQuantityType { get; set; }
    }
}
