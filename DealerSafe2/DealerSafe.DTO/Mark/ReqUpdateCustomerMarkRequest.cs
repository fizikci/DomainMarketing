using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqUpdateCustomerMarkRequest
    {
        public int RequestID { get; set; }
        public string BrandName { get; set; }
        public string BrandOwner { get; set; }
        public string CustomerDesc { get; set; }
    }
}
