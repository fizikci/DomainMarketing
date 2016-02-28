using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateInvoiceCompany
    {
        [Description("ID of the Invoice Company")]
        public int InvoiceCompanyID { get; set; }
    }
}
