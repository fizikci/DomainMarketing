using System.Collections.Generic;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Workers
{
    public class WorkerHosting : BaseWorker
    {
        public override void CreateJobsFor(Order order)
        {
        }

        public override void Execute(Job job)
        {
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
            return Departments.Hosting;
        }
    }
}