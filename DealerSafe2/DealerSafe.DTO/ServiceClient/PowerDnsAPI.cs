using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DealerSafe.DTO;
using DealerSafe.DTO.Mark;
using System.ComponentModel;
using System.Web;

namespace DealerSafe.ServiceClient
{
    public class PowerDNSAPI : BaseAPI
    {
        public PowerDNSAPI(int memberId)
        {
            this.memberId = memberId;
        }

        public PowerDNSAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["PowerDNSServiceURL"];
        }

        [Description("Check")]
        public string Check(ReqEmpty request)
        {
            return this.Call<string, ReqEmpty>(request, "Check");
        }
    }
}
