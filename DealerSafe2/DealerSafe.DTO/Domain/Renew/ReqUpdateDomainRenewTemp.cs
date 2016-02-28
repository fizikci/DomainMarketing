using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Renew
{
   public class ReqUpdateDomainRenewTemp
    {
       public int Id { get; set; }
       public int DomainId { get; set; }
       public int MemberId { get; set; }
       public DomainRenewStatus DomainRenewStatus { get; set; }
    }
}
