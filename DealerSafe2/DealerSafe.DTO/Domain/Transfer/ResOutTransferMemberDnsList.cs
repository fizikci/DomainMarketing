using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Transfer
{
    public class ResOutTransferMemberDnsList
    {
        public int Id { get; set; }
        public string DomainName { get; set; }
        public EnmOutTransferDomainProcess Durum { get; set; }
    }
}
