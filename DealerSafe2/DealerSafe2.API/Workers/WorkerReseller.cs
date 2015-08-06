using System;
using System.Collections.Generic;
using System.Web;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using System.Linq;
using DealerSafe2.API.Entity.Members;

namespace DealerSafe2.API.Workers
{
    public class WorkerReseller : BaseWorker
    {
        public override void CreateJobsFor(Order order)
        {

        }

        public override void Execute(Job job)
        {
            switch (job.Command)
            {
                case JobCommands.CalculateResellerRefundAmounts:
                    {
                        List<MdfReseller> mrList = Provider.Database.ReadList<MdfReseller>(@"
                                                                SELECT 
	                                                                mr.*
                                                                from 
	                                                                Mdf m, MdfReseller mr
                                                                where 
	                                                                m.IsDeleted=0 AND 
	                                                                m.StartDate<=getdate() AND 
	                                                                m.EndDate>=getdate() AND
	                                                                mr.MdfId = m.Id AND
	                                                                mr.State = 'Confirmed';
                                                                ");

                        if (mrList.Count > 0)
                        {
                            foreach (var mr in mrList)
                            {
                                var mdf = mr.Mdf();
                                mdf.ReadProducts();

                                var r = mr.Reseller();
                                r.ReadOrders(mdf.StartDate, mdf.EndDate); // bugünkü siparişler

                                var total = 0;

                                foreach (Order o in r.Orders)
                                {
                                    var relatedItems = o.Items.Where(oi => mdf.Products.Select(p => p.Id).Contains(oi.ProductId)).ToList();

                                    foreach (var relatedItem in relatedItems)
                                        total += mdf.RebateRate > 0 ? relatedItem.Price * mdf.RebateRate / 100 : mdf.RebateAmount;// *oi.Amount;
                                }

                                mr.CreditsToRefund = total;
                                mr.Save();
                            }
                        }

                        job.State = JobStates.Done;

                        break;
                    }
            }
        }

        public override int GetMaxTryCount(JobCommands jobCommand)
        {
            return 1;
        }

        public override List<DashboardItem> GetDashboardMessages()
        {
            return null;
        }

        public override Departments GetWorkerDepartment()
        {
            return Departments.Marketing;
        }
    }
}