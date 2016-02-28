using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateMemberInvoiceInfo
    {
        public int MemberId { get; set; }
        public bool InvoiceSend { get; set; }
        public int InvoiceCompanyId { get; set; }
    }
}
