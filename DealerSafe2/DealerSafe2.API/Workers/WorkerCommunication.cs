using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net.Mail;
using Cinar.Database;
using DealerSafe.DTO.Common;
using DealerSafe2.API.Api.Library;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.CommunicationChannel;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using System.Linq;
using DealerSafe2.API.Entity.Products.Domain;
using DealerSafe.ServiceClient;
using DealerSafe2.API.Entity.Members;
using Cinar.Scripting;
using Newtonsoft.Json;
using Order = DealerSafe2.API.Entity.Orders.Order;
using DealerSafe2.DTO.Request;

namespace DealerSafe2.API.Workers
{
    public class WorkerCommunication : BaseWorker
    {
        public override void CreateJobsFor(Order order)
        {
            // ileride kullanıcıya siparişiyle ilgili bir mail buradan gönderilebilir.

        }

        public override void Execute(Job job)
        {
            switch (job.Command)
            {
                case JobCommands.CCSendMessage:
                    SendMessage(job);
                    break;
                default:
                    break;
            }
        }

        private void SendMessage(Job job)
        {
            JobData jd = Provider.Database.Read<JobData>("JobId={0}", job.Id);
            if (jd == null) throw new Exception("CCSendMessage jobs should have corresponding JobData. This one doesn't.");

            ReqSendMessage req = JsonConvert.DeserializeObject<ReqSendMessage>(jd.Request);

            // CCMessageTemplate
            var msgTemplate = Provider.Database.Read<CCMessageTemplate>("Id={0}", job.RelatedEntityId);
            if (msgTemplate == null)
                throw new Exception("CCMessageTemplate record not found");
            // CCMessageGroup
            var msgMsgGroup = Provider.Database.Read<CCMessageGroup>("Id = {0}", msgTemplate.CCMessageGroupId);
            if (msgMsgGroup == null)
                throw new Exception("CCProfile record not found");
            // CCProfile
            var msgProfile = Provider.Database.Read<CCProfile>("Id={0}", msgMsgGroup.CCProfileId);
            if (msgProfile == null)
                throw new Exception("CCProfile record not found");
            // Client
            var client = Provider.Database.Read<Client>("Id = {0}", msgProfile.ClientId);
            if (msgProfile == null)
                throw new Exception("Client record not found");



            // 1. template'i veritabanından oku
            //string[] arr = job.CommandParameter.Split(new string[] { "___" }, StringSplitOptions.None);
            //string sqlPrm = arr[0];
            //string memberId = arr[1];

            string msgBody = "";

            if (req.SqlParam != "")
            {
                // 2. SqlCommand'dan parametre ile script engine marifetiyle SQL'i elde et
                var engine = new Interpreter(msgTemplate.SqlCommand, new List<string>());
                engine.SetAttribute("SqlParam", req.SqlParam);
                engine.SetAttribute("Parameters", req.Parameters);
                engine.Parse();
                engine.Execute();

                // 3. SQL'i çalıştır, sonucu DataRow olarak al
                string sql = engine.Output;
                //DataRow rs = Provider.Database.GetDataRow(sql); 
                DataRow rs = GetDataRow(sql, client.ConnectionStrings);

                // 4. Message alanındaki HTML'i script engine ve datarow'u kullanarak mesaj metnine dönüştür
                var engine2 = new Interpreter(msgTemplate.Message, new List<string>());
                engine2.SetAttribute("rs", rs);
                engine2.SetAttribute("Parameters", req.Parameters);
                engine2.Parse();
                engine2.Execute();

                msgBody = engine2.Output;
            }
            else
            {
                msgBody = msgTemplate.Message;
            }



            string msgSubject = "";
            if (!req.AddMessage.IsEmpty()) // 3.parametre varsa dışardan mesaj gelmiştir
            {
                msgBody = msgBody.Replace("$=msg$", req.AddMessage); // gönderilen mesajı ekle
                msgSubject = req.AddSubject.IsEmpty() ? "" : req.AddSubject;
            }


            // 5. Profil'i kullanarak mesajı gönder
            //  var msgMember = Provider.Database.Read<Member>("Id = {0}", memberId);
            string eMail = "";
            string nameSurname = "";
            string phone = "";

            if (!req.Email.IsEmpty()) // memberId 'nin içinde '@' varsa maildir.
            {
                eMail = req.Email;
                nameSurname = req.Email;
            }
            else
            {
                var msgMember = GetMemberRow(req.MemberId, client.ConnectionStrings);
                if (msgMember == null)
                    throw new Exception("Members record not found");

                // Member Info
                eMail = msgMember["EMail"].ToString();
                nameSurname = msgMember["NameSurname"].ToString();
                phone = msgMember["Phone2"].ToString();
            }

            // JobName
            job.Name = eMail;

            if (msgProfile.ProfileType == ProfileType.Email)
            {

                var emailSocket = Provider.Database.Read<CCEmailSocket>("Id = {0}", msgProfile.CCEmailSocketId);
                if (emailSocket == null)
                    throw new Exception("CCEmailSocket record not found");


                string sendMail = (!string.IsNullOrEmpty(msgProfile.SendMail))
                    ? msgProfile.SendMail
                    : emailSocket.Username;


                // e-mail için kodlar
                Utility.SendMail(sendMail, msgProfile.SendName, eMail, nameSurname,
                    (msgSubject.Trim() == "") ? msgTemplate.Subject : msgSubject, msgBody, emailSocket.Host, emailSocket.Port, emailSocket.Username,
                    emailSocket.Password, null, emailSocket.EnableSsl);

            }
            else if (msgProfile.ProfileType == ProfileType.Sms)
            {
                var smsSocket = Provider.Database.Read<CCSmsSocket>("Id = {0}", msgProfile.CCSmsSocketId);
                if (smsSocket == null)
                    throw new Exception("CCEmailSocket record not found");

                // sms için kodlar
                var sms = new SendSms(smsSocket.Username, smsSocket.Password, smsSocket.ApiId);
                String[] number = { phone };

                sms.addSMS(msgBody, number);
                sms.gonder();
            }
            else
            {
                throw new Exception("ProfileType record not found");
            }


            // 6. SentMessage tablosuna gönderilen mesajı logla 
            var sentMessage = new CCSentMessage
            {
                Body = msgBody,
                ToEmail = eMail,
                Subject = msgTemplate.Subject,
                CCMessageTemplateId = msgTemplate.Id,
                JobId = job.Id,
                MessageType = msgProfile.ProfileType.ToString(),
                MemberId = req.MemberId
            };
            sentMessage.Save();


            // 7. Bitti
            job.State = JobStates.Done;

        }


        public DataRow GetMemberRow(string memberId, string sqlCon)
        {
            string cmd = string.Format("Select top 1 EMail,Phone2CC,Phone2,NameSurname from Members Where ID={0}", memberId);

            return GetDataRow(cmd, sqlCon);
        }


        public DataRow GetDataRow(string sqlCmd, string sqlCon)
        {
            var da = new SqlDataAdapter(sqlCmd, sqlCon);
            var dt = new DataTable();
            da.Fill(dt);

            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }


        public override int GetMaxTryCount(JobCommands jobCommand)
        {
            return 1;
        }

        public override List<DashboardItem> GetDashboardMessages()
        {
            var res = new List<DashboardItem>();
            return res;
        }


        public override Departments GetWorkerDepartment()
        {
            return Departments.Marketing;
        }
    }
}