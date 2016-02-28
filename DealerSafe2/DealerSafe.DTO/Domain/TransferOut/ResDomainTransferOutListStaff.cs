using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.TransferOut
{
    public class ResDomainTransferOutListStaff
    {
        public int DomainId { get; set; }

        public string DomainName { get; set; }

        public string UserName { get; set; }

        public string enmOutTransferMemberStatus { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public string IpAdress { get; set; }

        public string SendEmailAdreses { get; set; }

        public int MemberId { get; set; }

    }
}
