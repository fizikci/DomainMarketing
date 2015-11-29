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

namespace DealerSafe2.API.Workers
{
    public class WorkerSiteProtection : BaseWorker
    {

        public override void CreateJobsFor(Order order)
        {
            foreach (var item in order.Items.Where(item => item.Product().ProductType().Name == "SiteProtection"))
            {
                try
                {

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

                default:
                    throw new ArgumentOutOfRangeException();
            }
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
            return new List<DashboardItem>();
        }

        public override Departments GetWorkerDepartment()
        {
            return Departments.SSL;
        }

    }
}