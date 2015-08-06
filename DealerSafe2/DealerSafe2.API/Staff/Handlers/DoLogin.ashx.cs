using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Members;

namespace DealerSafe2.API.Staff.Handlers
{
    /// <summary>
    /// Summary description for Report
    /// </summary>
    public class DoLogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["logout"] == "1")
            {
                Provider.CurrentMember = null;
                context.Response.Redirect("/Staff/Login.aspx", true);
                return;
            }

            //do login and set session(user and roles)
            Member member = Provider.Database.Read<Member>("Email={0} AND Password={1} AND IsStaffMember=1", context.Request["Email"], Utility.MD5(context.Request["Passwd"]));

            if (member != null)
            {
                // login başarılı, RedirectURL sayfasına gönderelim.
                Provider.CurrentApiClient = Provider.Database.ReadList<ApiClient>("select * from ApiClient where ClientId = {0}", member.ClientId).FirstOrDefault();
                Provider.CurrentMember = member;
                Provider.CurrentApi = Provider.CurrentApiClient.Api();

                string redirect = context.Request["RedirectUrl"];
                if (string.IsNullOrWhiteSpace(redirect))
                    context.Response.Redirect("/Staff/Default.aspx");
                else
                    context.Response.Redirect(redirect);
            }
            else
            {
                // login başarıSIZ, login formunun olduğu sayfaya geri gönderelim
                context.Session["loginError"] = "Email veya şifre geçersiz.";
                context.Response.Redirect("/Staff/Login.aspx");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}