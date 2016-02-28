using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqBrandBankReceiptNumbers
    {
        public int BrandID { get; set; }
        public bool BrandIDSpecified { get; set; }
        public int ReceiptNumberType { get; set; }
    }
}
