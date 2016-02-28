using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class ReqGetSubBankList
    {
        //Hata Yapılmış Düzenlendi fakat tekrar üzerinden geçilmesi gerekmekte 

        public int ID { get; set; }

        [Description("Request of the sub bank list.Default value : 0")]
        public int BankID { get; set; }
    }
}
