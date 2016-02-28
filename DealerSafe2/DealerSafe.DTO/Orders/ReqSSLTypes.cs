using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqSSLTypes
    {
        public int SSLTypeID { get; set; }
        public bool SSLTypeIDSpecified { get; set; }

        public int Status { get; set; }
        public bool StatusSpecified { get; set; }

        public int CompanyID { get; set; }
        public bool CompanyIDSpecified { get; set; }
    }
}
