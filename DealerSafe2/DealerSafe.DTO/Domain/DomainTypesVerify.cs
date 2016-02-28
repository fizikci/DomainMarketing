using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqDomainTypesAndPrices
    {
    }
    public class ResDomainTypesAndPrices
    {
        public int Id { get; set; }
        public string Tld { get; set; }
        public decimal Price { get; set; }
        public short Prerequisite { get; set; }
        public string Description { get; set; }
        public int IsIdn { get; set; }
    }
}
