using Cinar.Database;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Crm
{
    public class CrmActivity : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }

        public Departments Department { get; set; }
        public ActivityTypes ActivityType { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }

    }

    public class CrmActivityMessage : BaseEntity
    {
        public string CrmActivityId { get; set; }
        public string MemberId { get; set; }
        public string Message { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }
        public CrmActivity CrmActivity() { return Provider.ReadEntityWithRequestCache<CrmActivity>(CrmActivityId); }

        public override void BeforeSave(bool isUpdate)
        {
            base.BeforeSave(isUpdate);

            if (this.MemberId.IsEmpty())
                this.MemberId = Provider.CurrentMember.Id;
        }

        public override void AfterSave(bool isUpdate)
        {
            base.AfterSave(isUpdate);

            if (!isUpdate && Member().IsStaffMember)
            {
                var res = Provider.Api == null ? Provider.CurrentApiClient : Provider.Api.ApiClient;
                string siteAddress = res.Url;

                var crmAct = CrmActivity();

                Utility.SendMail(res.MailFrom, res.Client().Name, crmAct.Member().Email, crmAct.Member().FullName, "Your ticket is replied", @"
                            Dear #{FullName},<br/>
                            <br/>
                            Your ticket has received the following reply:<br/>
                            <br/>
                            #{Message}<br/>
                            <br/>
                            #{siteAddress}
                            ".EvaluateAsTemplate(new {crmAct.Member().FullName, Message, siteAddress }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
            }
        }
    } 

    public class ListViewCrmActivity : NamedEntity
    {
        public string MemberId { get; set; }
        public string Email { get; set; }
        public JobStates State { get; set; }
        public string Department { get; set; }
        public string Subject { get; set; }
    }

    public class ViewCrmActivity : CrmActivity
    {
        public string JobId { get; set; }
        public JobStates State { get; set; }
        public string ExecuterId { get; set; }
        public string Email { get; set; }
        public string MemberName { get; set; }
    }

    public class ListViewCrmActivityMessage : CrmActivityMessage
    {
        public string MemberName { get; set; }
    }
}
