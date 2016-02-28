using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ReqArkadasimaDevretHosting
    {
        public int CreatorMemberId {get; set;}
        public string NameSurname {get; set; }
        public DateTime TodayDate {get; set; }
        public string Email {get; set; }
    }
}
