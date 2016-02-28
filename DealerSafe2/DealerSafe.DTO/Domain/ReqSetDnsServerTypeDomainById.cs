using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain
{
    public class ReqSetDnsServerTypeDomainById
    {
        public int userId {get;set;}
		public int DomainId {get;set;}
		public EnmDnsServerType type {get;set;}
    }
}
