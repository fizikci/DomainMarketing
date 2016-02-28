using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain.TransferIn
{
    public class ResDomainTransferInListStaff
    {
        public int DomainId { get; set; }

        public decimal OrderID { get; set; }

        public int MemberId { get; set; }

        public string Username { get; set; }

        public int Approved { get; set; }

        public int GSMApproved { get; set; }

        public string DomainName { get; set; }

        public DateTime? CreateDate { get; set; }

        public string PaymentType { get; set; }

        public string StatuName { get; set; }

        public string Password { get; set; }
    }
}
