using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.TransferIn
{
    public class ReqDomainTransferInStart
    {
        public int DomainId { get; set; }

        public string Password { get; set; }

        public bool NotControl { get; set; }

    }
}
