using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DealerSafe.DTO;
using DealerSafe.DTO.BaseKit;
using DealerSafe.DTO.Hosting;
using DealerSafe.DTO.Mark;
using System.ComponentModel;
using System.Web;

namespace DealerSafe.ServiceClient
{
    public class BaseKitAPI : BaseAPI
    {
        public BaseKitAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["AdminMemberID"] != null)
                this.staffId = Convert.ToInt32(HttpContext.Current.Session["AdminMemberID"]);
        }
        public BaseKitAPI(int MemberID)
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["AdminMemberID"] != null)
                this.staffId = Convert.ToInt32(HttpContext.Current.Session["AdminMemberID"]);

            this.memberId = MemberID;
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["BaseKitServiceURL"];
        }

        [Description("Add New BaseKit")]
        public bool SaveItem(SalesItem request)
        {
            return this.Call<Boolean, SalesItem>(request, "SaveItem");
        }

        [Description("Add New Year of BaseKit")]
        public bool SaveAddYear(SalesItem request)
        {
            return this.Call<Boolean, SalesItem>(request, "SaveAddYear");
        }

        [Description("IsNewWebKlavuz")]
        public bool IsNewWebKlavuz(int request)
        {
            return this.Call<Boolean, int>(request, "IsNewWebKlavuz");
        }

        [Description("Mail List WebKlavuz")]
        public string GetMailByMembersDomainId(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "GetMailByMembersDomainId");
        }

        [Description("Delete EMail")]
        public string DeleteEmail(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "DeleteEmail");
        }

        [Description("Add EMail")]
        public string AddEmail(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "AddEmail");
        }
        
        [Description("Remove")]
        public string Remove(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "Remove");
        }

        [Description("Update EMail")]
        public string UpdateEmail(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "UpdateEmail");
        }

        [Description("Create Domain")]
        public string CreateDomain(DomainInfo request)
        {
            return this.Call<string, DomainInfo>(request, "CreateDomain");
        }

        [Description("Re Create Domain For Dns")]
        public string DeleteDomainForDns(DomainInfo request)
        {
            return this.Call<string, DomainInfo>(request, "DeleteDomainForDns");
        }

        [Description("Re Create Domain For Dns")]
        public string ReCreateDomainForDns(DomainInfo request)
        {
            return this.Call<string, DomainInfo>(request, "ReCreateDomainForDns");
        }

        [Description("Get Dns")]
        public string GetDns(string request)
        {
            return this.Call<string, string>(request, "GetDns");
        }

        [Description("Dns Detail Remove")]
        public string DnsTSil(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "DnsTSil");
        }

        [Description("Dns Detail Update")]
        public string DnsTGuncelle(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "DnsTGuncelle");
        }

        [Description("Dns Detail Remove")]
        public string LoginHash(SalesItem request)
        {
            return this.Call<string, SalesItem>(request, "LoginHash");
        }

        [Description("New Setup")]
        public string NewSetup(string request)
        {
            return this.Call<string, string>(request, "NewSetup");
        }

        [Description("Upgrade Setup")]
        public string UpgradeSetup(string request)
        {
            return this.Call<string, string>(request, "UpgradeSetup");
        }

        [Description("ListMyWebKlavuz")]
        public string ListMyWebKlavuz(int request)
        {
            return this.Call<string, int>(request, "ListMyWebKlavuz");
        }

        [Description("ListMyWebKlavuzByStaff")]
        public string ListMyWebKlavuzByStaff(int request)
        {
            return this.Call<string, int>(request, "ListMyWebKlavuzByStaff");
        }

        [Description("ListMyWebKlavuzByStaffMailHosting")]
        public string ListMyWebKlavuzByStaffMailHosting(int request)
        {
            return this.Call<string, int>(request, "ListMyWebKlavuzByStaffMailHosting");
        }
    }
}
