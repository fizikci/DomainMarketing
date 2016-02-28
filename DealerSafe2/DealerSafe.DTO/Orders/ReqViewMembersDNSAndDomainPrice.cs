using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqViewMembersDNSAndDomainPrice
    {
        public string DomainName { get; set; }
        public bool DomainNameSpecified { get; set; }
        public int MemberID { get; set; }
        public bool MemberIDSepcified { get; set; }
        public int OrderID { get; set; }
        public bool OrderIDSepcified { get; set; }
    }
}
