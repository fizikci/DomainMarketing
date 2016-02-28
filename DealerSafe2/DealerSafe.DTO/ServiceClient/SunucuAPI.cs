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
    public class SunucuAPI : BaseAPI
    {
        public SunucuAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["AdminMemberID"] != null)
                this.staffId = Convert.ToInt32(HttpContext.Current.Session["AdminMemberID"]);
        }
        public SunucuAPI(int MemberID)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["AdminMemberID"] != null)
                this.staffId = Convert.ToInt32(HttpContext.Current.Session["AdminMemberID"]);

            this.memberId = MemberID;
        }
        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["SunucuServiceURL"];
        }
    }
}
