using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Jobs
{
    /// <summary>
    /// 1. Yeni bir Job state'i New olacak şekilde veritabanına eklenir.
    /// 2. JobExecuter bu job'ı yakalar State'ini derhal Processing yapıp ilgili Worker'a havale eder
    /// 3. Worker işi yapar; başarılı olursa state'i Done, başarısız olursa Failed yapar.
    /// 4. Bazı workerlar, job'ın başarısız olması veya devam etmesi gerektiği durumlarda state'i TryAgain yapabilir
    ///    Bu durumda CompletePercentage'a 0-100 arasında bir değer atayabilir
    /// 5. JobExecuter state'i TryAgain olan jobları yakalar, worker tarafından belirlenen süre geçmişse tekrar workera çalıştırtır
    /// </summary>
    public class Job : BaseEntity
    {
        public Job() {
            StartDate = Provider.Database.Now;
        }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 50)]
        public JobCommands Command { get; set; }

        public string Name { get; set; }

        public string CommandParameter { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 50)]
        public JobStates State { get; set; }

        [ColumnDetail(Length = 12)]
        public string ParentJobId { get; set; }

        public DateTime StartDate { get; set; }
        public int ProcessTime { get; set; }

        public int TryCount { get; set; }
        public int CompletePercentage { get; set; }

        public string RelatedEntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string RelatedEntityId { get; set; }

        public JobExecuters Executer { get; set; }
        [ColumnDetail(Length = 12)]
        public string ExecuterId { get; set; }

        public Job ParentJob() { return Provider.ReadEntityWithRequestCache<Job>(ParentJobId); }

        public override void Delete()
        {
            Provider.Database.Execute(() =>
            {
                foreach (var jobData in Provider.Database.ReadList<JobData>("select * from JobData where JobId={0}", this.Id))
                    jobData.Delete();

                base.Delete();
            });
        }

        public override void AfterSave(bool isUpdate)
        {
            base.AfterSave(isUpdate);

            if (!isUpdate)
            {
                if (Executer == JobExecuters.Staff)
                {
                    var teknisyen = Provider.Database.Read<Member>("select * from Member where Id = {0} AND IsDeleted = 0", ExecuterId);
                    var res = Provider.Api.ApiClient;

                    Utility.SendMail(res.MailFrom, res.Client().Name, teknisyen.Email, teknisyen.FullName, this.Name, @"
                        Dear #{FullName},<br/>
                        <br/>
                        There is a job waiting for you<br/>
                        <br/>
                        Please go to staff:<br/>
                        http://api.signsec.com/Staff
                        ".EvaluateAsTemplate(new { teknisyen.FullName }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
                }
            }
        }
    }

}