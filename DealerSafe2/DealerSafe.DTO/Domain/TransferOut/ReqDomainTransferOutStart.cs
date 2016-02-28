using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.TransferOut
{
    public class ReqDomainTransferOutStart
    {
        public DateTime CreateDate { get; set; }

        public string IpAdress { get; set; }

        public int MemberStatus { get; set; }

        public string MemberExplanation { get; set; }

        public int DomainId { get; set; }

    }
}
