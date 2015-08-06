using System.Security.Cryptography.X509Certificates;
using Cinar.Database;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Orders
{
    public class MdfReseller : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MdfId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ResellerId { get; set; }
        public MdfStates State { get; set; }
        public int CreditsToRefund { get; set; }

        public Mdf Mdf() { return Provider.ReadEntityWithRequestCache<Mdf>(MdfId); }
        public Reseller Reseller() { return Provider.ReadEntityWithRequestCache<Reseller>(ResellerId); }

        public override void AfterSave(bool isUpdate)
        {
            base.AfterSave(isUpdate);

            if (isUpdate && State == MdfStates.Confirmed)
            {
                Job j = Provider.Database.Read<Job>("RelatedEntityName={0} AND RelatedEntityId={1}", "MdfReseller", Id);
                if (j != null && j.State != JobStates.Done)
                {
                    j.State = JobStates.Done;
                    j.ProcessTime = (DateTime.Now - j.StartDate).Milliseconds;
                    j.Save();

                    var res = Provider.Api == null ? Provider.CurrentApiClient : Provider.Api.ApiClient;
                    string siteAddress = res.Url;

                    Utility.SendMail(res.MailFrom, res.Client().Name, Reseller().Member().Email, Reseller().Member().FullName, "Congratulations! Your application is confirmed", @"
                            Dear #{FullName},<br/>
                            <br/>
                            You recently applied to MDF program : #{MdfName}<br/>
                            Your application is confirmed. Please fullfill the MDF requirements.<br/>
                            <br/>
                            #{siteAddress}
                            ".EvaluateAsTemplate(new { MdfName= Mdf().Name, siteAddress }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
                }
            }
        }
    }

    public class ListViewMdfReseller : MdfReseller
    {
        public string ResellerName { get; set; }
        public string MdfName { get; set; }
    }

}
