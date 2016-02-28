using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class DomainHunterInfo
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public bool Status { get; set; }
        public string DomainName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; } // domainprice tablosundan alınacak
    }
}
