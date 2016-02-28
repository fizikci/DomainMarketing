using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ReqCustomerOftheYearCampingControl
    {
        public int CustomerId { get; set; }  

        public int MemberId { get; set; }

        public string Cookie { get; set; }

        public string Ip { get; set; }  
    }
}
