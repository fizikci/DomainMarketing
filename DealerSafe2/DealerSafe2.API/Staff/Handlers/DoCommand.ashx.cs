using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using DealerSafe2.API.Entity.Crm;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO;
using DealerSafe2.DTO.Enums;
using DealerSafe2.API.Entity.Common;

namespace DealerSafe2.API.Staff.Handlers
{
    /// <summary>
    /// Summary description for Report
    /// </summary>
    public class DoCommand : IHttpHandler, IRequiresSessionState
    {
        HttpContext context;

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;

            switch (context.Request["method"])
            {
                case "saveLocale":
                    {
                        saveLocale();
                        break;
                    }
                case "redirectForJob":
                    {
                        redirectForJob();
                        break;
                    }
                case "cancelOrderItem":
                    {
                        cancelOrderItem();
                        break;
                    }
                case "sendFeedbackReply":
                    {
                        sendFeedbackReply();
                        break;
                    }
                default:
                    {
                        sendErrorMessage("Henüz " + context.Request["method"] + " isimli metod yazılmadı.");
                        break;
                    }
            }
        }
        protected void sendErrorMessage(string message)
        {
            context.Response.Write("ERR: " + message);
        }
        protected void sendErrorMessage(Exception ex)
        {
            sendErrorMessage(ex.ToStringBetter());
        }

        private void redirectForJob()
        {
            var jid = context.Request["jid"];

            Job j = Provider.Database.Read<Job>("Id = {0}", jid);
            if (j == null)
            {
                context.Response.Redirect("/Staff", true);
                return;
            }

            if (j.State == JobStates.NotStarted)
            {
                j.State = JobStates.Processing;
                j.Save();
            }

            switch (j.Command)
            {
                case JobCommands.CancelRefundReq:
                    context.Response.Redirect("/Staff/#/View/OrderItem/" + j.RelatedEntityId, true);
                    break;
                case JobCommands.MdfApplication:
                    context.Response.Redirect("/Staff/#/View/Mdf/" + Provider.Database.GetString("select MdfId from MdfReseller where Id={0}", j.RelatedEntityId), true);
                    break;
                case JobCommands.DomainRegister:
                    break;
                case JobCommands.DomainRenewal:
                    break;
                case JobCommands.HostingCreate:
                    break;
                case JobCommands.HostingSuspend:
                    break;
                case JobCommands.SSLNewOrder:
                    break;
                case JobCommands.SSLGenerate:
                    break;
                case JobCommands.SSLCheckResult:
                    break;
                case JobCommands.SSLUpdateDCV:
                    break;
                case JobCommands.SiteProtectionNewOrder:
                    break;
                case JobCommands.NewTicket:
                    context.Response.Redirect("/Staff/#/View/CrmActivity/" + j.RelatedEntityId, true);
                    break;
                case JobCommands.NewFeedback:
                    context.Response.Redirect("/Staff/#/View/Feedback/" + j.RelatedEntityId, true);
                    break;
                default:
                    context.Response.Redirect("/Staff/#/View/Job/"+j.Id, true);
                    break;
            }
        }

        private void cancelOrderItem()
        {
            var orderItemId = context.Request["orderItemId"];

            var oi = Provider.Database.Read<OrderItem>("Id = {0}", orderItemId);
            oi.Cancel();

            context.Response.Redirect("/Staff");
        }

        private void saveLocale()
        {
            LanguageValue lv = Provider.Database.Read<LanguageValue>("Id={0}", context.Request[context.Request["langName"] + "Id"]);
            if (lv == null)
                lv = new LanguageValue() {
                    EntityId = context.Request["EntityId"],
                    EntityName = context.Request["EntityName"],
                    FieldName = context.Request["FieldName"],
                    LanguageId = context.Request["langId"]
                };

            lv.FieldValue = context.Request[context.Request["langName"]];
            lv.Save();
        }

        private void sendFeedbackReply()
        {
            var id = context.Request["id"];

            var fb = Provider.Database.Read<Feedback>("Id = {0}", id);
            fb.Save();

            var res = Provider.Api == null ? Provider.CurrentApiClient : Provider.Api.ApiClient;

            Utility.SendMail(res.MailFrom, res.Client().Name, fb.Email, fb.Name, "Feedback Reply", @"
                Dear " + fb.Name + ",<br/> <br/> " + fb.ReplyMessage + "<br/> <br/> ", res.MailHost,
                res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);

            context.Response.Redirect("/Staff/Default.aspx#/View/Feedback/" + id);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class InternalProvider
        {
            public class Configuration
            {

                public static int ImageUploadMaxWidth { get { return 1000; } }

                public static int ThumbQuality { get { return 100; } }
            }

            internal static string MapPath(string folderName)
            {
                return HttpContext.Current.Server.MapPath(folderName);
            }

            public static NameValueCollection AppSettings { get { return ConfigurationManager.AppSettings; } }
        }
    }


}