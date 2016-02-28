using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetCustomerProfitInfo
    {
        public List<CustomerProfitDetail> CustomerProfitList { get; set; }
      
    }
    public class CustomerProfitDetail
    {
        public int Id { get; set; }
        public int ClassNumber { get; set; }
        public string BrandName { get; set; }
        public string PayDesc { get; set; }
        public double Price { get; set; }
    }
  
}
