using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.Renew
{
    public class ReqGetDomainRenewRequestByOrderId
    {
        public int OrderId { get; set; }
        public int DomainId { get; set; }
    }
}
