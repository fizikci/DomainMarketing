using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class BrandBankReceiptNumbersInfo
    {
        public bool Process { get; set; }
        public List<BrandBankReceiptNumberDetail> BrandBankReceiptNumbers { get; set; }
    }
    public class BrandBankReceiptNumberDetail
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public string BankName { get; set; }
        public string BankReceiptNumber { get; set; }
        public int ReceiptNumberType { get; set; }
        public int Process { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
