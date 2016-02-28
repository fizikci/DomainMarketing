using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
   public class ReqSaveBrandDekont
    {
       public int MarkId { get; set; }

       public string FileName { get; set; }

       public string DekontNo { get; set; }

       public DateTime BankReceiptNumberDate { get; set; }

    }
}
