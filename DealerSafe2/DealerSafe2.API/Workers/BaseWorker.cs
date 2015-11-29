using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Workers
{
    public abstract class BaseWorker
    {
        public static BaseWorker GetWorker(JobCommands command)
        {
            switch (command)
            {
                case JobCommands.DomainRegister:
                case JobCommands.DomainRenewal:
                case JobCommands.DomainDelete:
                case JobCommands.DomainTransferRequest:
                case JobCommands.DomainTransferQuery:
                case JobCommands.DomainRestore:
                case JobCommands.DomainCancel:
                case JobCommands.ReadPollMessages:
                case JobCommands.HandlePollMessage:
                    return new WorkerDomain();

                case JobCommands.HostingCreate:
                case JobCommands.HostingSuspend:
                    return new WorkerHosting();

                case JobCommands.SSLNewOrder:
                case JobCommands.SSLGenerate:
                case JobCommands.SSLCheckResult:
                    return new WorkerSSL();

                case JobCommands.CalculateResellerRefundAmounts:
                    return new WorkerReseller();

                case JobCommands.CCSendMessage:
                    return new WorkerCommunication();

                default:
                    throw new Exception("Critical error: Please define the worker of this command (" + command + ") at BaseWorker.GetWorker method.");
            }
        }

        public abstract Departments GetWorkerDepartment();

        public abstract void CreateJobsFor(Order order);

        public abstract void Execute(Job job);

        public abstract int GetMaxTryCount(JobCommands jobCommand);

        public void ExecuteInternal(Job job)
        {
            // bu job çalıştırılabilir mi?

            if (job.Executer != JobExecuters.Machine)
                throw new Exception("The executer of this job (" + job.Id + ") is not machine!");

            if (job.State == JobStates.TryAgain)
            {
                if (job.StartDate > Provider.Database.Now)
                    return; // let this job wait until StartDate

                if (job.TryCount >= GetMaxTryCount(job.Command)) // we assign this Job to a staff if the MaxTryCount is reached.
                {
                    job.Executer = JobExecuters.Staff;
                    job.State = JobStates.NotStarted;
                    job.ExecuterId = Provider.Api.GetNextIdleStaffMemberId(GetWorkerDepartment());
                    job.Save();
                    return;
                }
            }

            job.TryCount++;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Execute(job); // programmer code runs here

            sw.Stop();

            job.ProcessTime = (int)sw.ElapsedMilliseconds;
            job.Save();

            if (HttpContext.Current.Items.Contains("request"))
                new JobData()
                {
                    JobId = job.Id,
                    RequestUrl = HttpContext.Current.Items["requestUrl"].ToString(),
                    Request = HttpContext.Current.Items["request"].ToString(),
                    Response = HttpContext.Current.Items["response"].ToString(),
                    ProcessTime = job.ProcessTime
                }.Save();
        }

        public abstract List<DashboardItem> GetDashboardMessages();

        public virtual void CancelOrderItem(string orderItemId, string cancelReason)
        {
            var resellerResponsibleEmployeeId = Provider.Database.GetString(@"
                select StaffMemberId FROM Member where Id = (select MemberId from [Order] where Id = (select OrderId from OrderItem where Id = {0}))
            ", orderItemId);


            var job = new Job()
            {
                Command = JobCommands.CancelRefundReq,
                Name = cancelReason,
                RelatedEntityName = "OrderItem",
                RelatedEntityId = orderItemId,
                State = JobStates.NotStarted,
                Executer = JobExecuters.Staff,
                ExecuterId = string.IsNullOrWhiteSpace(resellerResponsibleEmployeeId) ? Provider.Api.GetNextIdleStaffMemberId(GetWorkerDepartment()) : resellerResponsibleEmployeeId
            };

            job.Save();
        }
    }
}