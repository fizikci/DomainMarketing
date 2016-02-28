using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Common
{
    public class ResCampingPublicCustomerYearList
    {
        public List<ResCampingPublicCustomerYear> List { get; set; }  

        public List<ControlCookieAndIp> ListcontrolCookieAndIp { get; set; }  
    }

    public class ResCampingPublicCustomerYear
    {

        public int RowNumber { get; set; }

        public int Id { get; set; }

        public byte[] PhotoFile { get; set; }

        public string NameSurName { get; set; }

        public string ServiceContent { get; set; }

        public int Puan { get; set; }

        public bool PuanControl { get; set; }

        public DateTime Date { get; set; }

        public int MemberId { get; set; }

    }

    public class ControlCookieAndIp
    {
        public int MemberId { get; set; }  

        public string Ip { get; set; }

        public string Cookie { get; set; }
    }
}
