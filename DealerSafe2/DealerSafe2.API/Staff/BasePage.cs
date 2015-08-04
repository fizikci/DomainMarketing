using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DealerSafe2.API;

namespace DealerSafe2.API.Staff
{
    public class BasePage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrWhiteSpace(Request["apiId"]))
                Provider.CurrentApi = Provider.Database.Read<Entity.ApiRelated.Api>("select * from Api where Id = {0}", Request["apiId"]);


            if (Request.RawUrl.Contains("Login.aspx"))
                return;

            if (string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
            {
                Response.Redirect("/Staff/Login.aspx?RedirectUrl="+Server.UrlEncode(Request.RawUrl), true);
                return;
            }
        }
    }
}