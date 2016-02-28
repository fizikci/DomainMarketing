using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DealerSafe.DTO.Membership;
using DealerSafe.DTO.SSL;
using Newtonsoft.Json;

namespace DealerSafe.ServiceClient
{
    public class SSLAPI : BaseAPI
    {
        public SSLAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public SSLAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }


        [Description("Returns contact info encoded into CSR code")]
        public ResolvedCSRInfo ResolveCSR(ReqResolveCSR request)
        {
            return this.Call<ResolvedCSRInfo, ReqResolveCSR>(request, "ResolveCSR");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["sslServiceURL"]; ;
        }
    }
}
