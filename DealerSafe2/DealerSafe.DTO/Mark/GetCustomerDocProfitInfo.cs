using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetCustomerDocProfitInfo
    {
        public List<CustomerDocProfitDetail> CustomerDocProfitList { get; set; }
    }
    public class CustomerDocProfitDetail
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string PayDesc { get; set; }
        public double Price { get; set; }
        public DateTime TaxPaymentDate { get; set; }
    }
}
