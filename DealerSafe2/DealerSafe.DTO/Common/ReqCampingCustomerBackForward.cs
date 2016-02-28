using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ReqCampingCustomerBackForward
    {
        public int CustomerId { get; set; }

        public string IpAdress { get; set; }  

        public EnmCampingCustomerBackForward Status { get; set; }
    }

    public enum EnmCampingCustomerBackForward
    {
        Back = 1,
        Forward = 2
    }
}
