using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqBrandApplyCheck
    {
        public int MarkId { get; set; }
        public string BankReceiptNumber { get; set; }
        public string TPEApplyNumber { get; set; }
    }
}
