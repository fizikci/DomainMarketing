using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class MarkExpressCheckoutInfo
    {
        public bool Process { get; set; }
        public string Token { get; set; }
        public string RetMsg { get; set; }
        public int CountryCode { get; set; }
    }
}
