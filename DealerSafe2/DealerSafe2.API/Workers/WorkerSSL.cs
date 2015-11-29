using System;
using System.Collections.Generic;
using System.Web;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using System.Linq;
using DealerSafe2.API.Entity.Products.SSL;
using DealerSafe2.DTO.EntityInfo.Products.SSL;
using DealerSafe2.API.Entity.Products;

namespace DealerSafe2.API.Workers
{
    public class WorkerSSL : BaseWorker
    {

        public override void CreateJobsFor(Order order)
        {
            foreach (var item in order.Items.Where(item => item.Product().ProductType().Name == "SSL"))
            {
                try
                {
                    Provider.Database.Begin();

                    var job = new Job()
                    {
                        Command = JobCommands.SSLNewOrder,
                        Name = item.DisplayName,
                        RelatedEntityName = "OrderItem",
                        RelatedEntityId = item.Id,
                        State = JobStates.NotStarted,
                        Executer = JobExecuters.Member,
                        ExecuterId = order.MemberId
                    };
                    job.Save();

                    var memberSSL = new MemberSSL();
                    //memberSSL.OrderItemId = item.Id;
                    memberSSL.State = SSLStates.None;
                    memberSSL.Save();

                    var now = Provider.Database.Now;

                    var memberProduct = new MemberProduct();
                    memberProduct.Id = memberSSL.Id;
                    memberProduct.OrderItemId = item.Id;
                    memberProduct.StartDate = now;
                    memberProduct.EndDate = now.AddYears(item.Amount);
                    memberProduct.InsertDate = now;
                    memberProduct.Name = item.DisplayName;
                    Provider.Database.Insert("MemberProduct", memberProduct);

                    Provider.Database.Commit();
                }
                catch (Exception ex)
                {
                    Provider.Database.Rollback();
                    throw;
                }
            }
        }

        public override void Execute(Job job)
        {
            switch (job.Command)
            {
                case JobCommands.SSLNewOrder:
                    {
                        job.State = JobStates.Done;
                        job.Save();

                        var job2 = new Job()
                        {
                            Command = JobCommands.SSLGenerate,
                            Name = job.Name,
                            RelatedEntityName = job.RelatedEntityName,
                            RelatedEntityId = job.RelatedEntityId,
                            State = JobStates.NotStarted,
                            Executer = JobExecuters.Machine
                            //ExecuterId = GetNextAvailableMachine()
                        };
                        job2.Save();
                        break;
                    }
                case JobCommands.SSLGenerate:
                    {
                        var res = sendSSLInfoToComodoAPI(job);

                        switch (res)
                        {
                            case JobStates.TryAgain:
                                job.StartDate = Provider.Database.Now.AddMinutes(1);
                                job.State = JobStates.TryAgain;
                                job.Save();
                                break;
                            case JobStates.Done:
                                // set job's state
                                job.State = JobStates.Done;
                                job.Save();

                                // create next job
                                var newJob = new Job()
                                    {
                                        Command = JobCommands.SSLCheckResult,
                                        RelatedEntityName = job.RelatedEntityName,
                                        RelatedEntityId = job.RelatedEntityId,
                                        StartDate = DateTime.Now.AddSeconds(10),
                                        ParentJobId = job.ParentJobId,
                                        State = JobStates.NotStarted,
                                        Executer = JobExecuters.Machine
                                    };
                                newJob.Save();
                                break;
                            case JobStates.Failed:
                                job.State = JobStates.Failed;
                                job.Save();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                case JobCommands.SSLCheckResult:
                    {

                        var memberProduct = Provider.Database.Read<MemberProduct>("OrderItemId={0}", job.RelatedEntityId);
                        if (memberProduct == null)
                            throw new Exception("MemberProduct record not found for the job: " + job.ParentJobId);

                        var res = checkSSLResult(job);

                        switch (res)
                        {
                            case JobStates.TryAgain:
                                job.StartDate = DateTime.Now.AddMinutes(job.TryCount > 60 ? 60 : job.TryCount);
                                job.State = JobStates.TryAgain;
                                job.Save();
                                break;
                            case JobStates.Done:
                                // set job's state
                                job.State = JobStates.Done;
                                job.Save();

                                // create next job
                                // finish... no next job.
                                break;
                            case JobStates.Failed:
                                job.State = JobStates.Failed;
                                job.Save();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private JobStates sendSSLInfoToComodoAPI(Job job)
        {
            try
            {
                var memberProduct = Provider.Database.Read<MemberProduct>("OrderItemId={0}", job.RelatedEntityId);
                if (memberProduct == null)
                    throw new Exception("MemberSSL record not found for the job: " + job.ParentJobId);

                var memberSSLInfo = Provider.Database.Read<MemberSSL>("Id={0}", memberProduct.Id).ToEntityInfo<MemberSSLInfo>();
                memberProduct.CopyPropertiesWithSameName(memberSSLInfo);

                Provider.Api.GenerateSSL(memberSSLInfo);

                return JobStates.Done;
            }
            catch (Exception ex)
            {
                return JobStates.TryAgain;
            }
        }

        private JobStates checkSSLResult(Job job)
        {
            try
            {
                var memberProduct = Provider.Database.Read<MemberProduct>("OrderItemId={0}", job.RelatedEntityId);
                if (memberProduct == null)
                    throw new Exception("MemberProduct record not found for the job: " + job.ParentJobId);

                var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", memberProduct.Id);
                if (memberSSL == null)
                    throw new Exception("MemberSSL record not found for the job: " + job.ParentJobId);

                var res = Provider.Api.CollectSSL(job.RelatedEntityId);

                if (!string.IsNullOrWhiteSpace(res.zipFile))
                {
                    memberSSL.State = SSLStates.Completed;
                    memberSSL.Save();
                    return JobStates.Done;
                }

                if (res.certificateStatus.ToLowerInvariant() == "issued")
                {
                    memberSSL.State = SSLStates.Completed;
                    memberSSL.Save();
                    return JobStates.Done;
                }
                if (res.certificateStatus.ToLowerInvariant() == "valid")
                {
                    memberSSL.State = SSLStates.DomainValidated;
                    memberSSL.Save();
                }

                if (res.certificateStatus.IndexOf("awaiting", StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    if (
                        res.validationStatus.IndexOf("Awaiting Legal Documents",
                                                     StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        memberSSL.State = SSLStates.WaitingDocument;
                        memberSSL.Save();
                    }
                    else if (res.dcvStatus == "1")
                    {
                        memberSSL.State = SSLStates.DomainValidated;
                        memberSSL.Save();
                    }
                }

                return JobStates.TryAgain;

            }
            catch (APIException ex)
            {
                if (ex.ErrorCode == ErrorCodes.TheCertificateHasBeenRevoked ||
                    ex.ErrorCode == ErrorCodes.TheCertificateRequestHasBeenRejected)
                    return JobStates.Failed;
            }
            catch
            {

            }

            return JobStates.TryAgain;
        }

        public override int GetMaxTryCount(JobCommands jobCommand)
        {
            switch (jobCommand)
            {
                case JobCommands.SSLNewOrder:
                    return 1;
                case JobCommands.SSLGenerate:
                    return 3;
                case JobCommands.SSLCheckResult:
                    return 200; // 1 haftaya kadar check eder (30 saate kadar 60 defa, ondan sonra saat başı.)
                default:
                    throw new ArgumentOutOfRangeException("jobCommand");
            }
        }

        public override List<DashboardItem> GetDashboardMessages()
        {
            return
                Provider.Api.GetMemberSSLList(null)
                        .Where(l=>l.State == SSLStates.None)
                        .Select(
                            l =>
                            new DashboardItem()
                                {
                                    Title = "You have tasks to do",
                                    Description = "Generate your " + l.ProductName + " SSL Certificate.",
                                    Link = "GenerateSSL.aspx?Id=" + l.Id,
                                    LinkText = "Generate now"
                                })
                        .ToList();
        }

        public override Departments GetWorkerDepartment()
        {
            return Departments.SSL;
        }
    }
}