using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetDiscountBulletinList
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public int DiscountRate { get; set; }
        public decimal Price { get; set; }
        public decimal SalesPrice { get; set; }
        public string LandingPage { get; set; }
        public bool Emphasis { get; set; }
        public string Title { get; set; }
        public int OrderNumber { get; set; }
    }                     
}
