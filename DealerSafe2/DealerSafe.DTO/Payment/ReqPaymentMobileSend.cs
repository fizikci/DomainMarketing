using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class ReqPaymentMobileSend
    {
        public string PhoneNumber { get; set; }

        public int OrderId { get; set; }

        public double Total { get; set; }

        public string Product { get; set; }
      
    }
}
