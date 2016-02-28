using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class PremiumTvDomainsInfo
    {
        public bool Process { get; set; }
        public List<PremiumTvDomainsDetail> PremiumTvDomainsList { get; set; }

        public class PremiumTvDomainsDetail
        {
            public int Id { get; set; }
            public string DomainName { get; set; }
            public string PremiumPrice { get; set; }
            public string RenewalPrice { get; set; }
            public string Availability { get; set; }
        }
    }
}
