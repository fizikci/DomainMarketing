using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.API.Entity.Products;
using Cinar.Database;
using DealerSafe2.DTO.Enums;
using DealerSafe2.API.Entity.LifeCycles;

namespace DealerSafe2.API.Entity.Products
{
    public class MemberProduct : BaseEntity
    {
        public string Name { get; set; }

        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        [ColumnDetail(Length = 12)]
        public string OrderItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ProductId { get; set; }
        public string ProductTypeId { get; set; }
        public DateTime RenewalDate { get; set; }
        public DateTime RestoreDate { get; set; }
        public LifeCyclePhases CurrentPhase { get; set; }

        public OrderItem OrderItem() { return Provider.ReadEntityWithRequestCache<OrderItem>(OrderItemId); }
        public Product Product() { return Provider.ReadEntityWithRequestCache<Product>(ProductId); }

        public LifeCyclePhases CalculatePhase()
        {
            var res = LifeCyclePhases.None;

            LifeCycle lifeCycle = Product().LifeCycle();
            if (lifeCycle == null)
                throw new Exception("This product has no life cycle defined: " + this.ProductId);

            /*
             * Öncelikle Active fazların süresi hesaplanır. (ActiveDays)
             * Eğer max(StartDate,RenewalDate) + ActiveDays <= DateTime.Now ise faz = ACTIVE demektir.
             * Else max(StartDate,RenewalDate) + ActiveDays + RenewalDays <= DateTime.Now ise faz = WaitingForRenewal demektir.
             * Else max(StartDate,RenewalDate) + ActiveDays + RenewalDays + RestoreDays <= DateTime.Now ise faz = WaitingForRestore demektir.
             * Else faz = Deleted or Backup
             */

            var phases = Provider.Database.ReadList<LifeCyclePhase>("select * from LifeCyclePhase where LifeCycleId={0} AND IsDeleted <> 1", lifeCycle.Id);
            if (phases.Count == 0)
                throw new Exception("There is no phase of the life cycle: " + lifeCycle.Id);

            var activeDays = phases.Where(p=>p.PhaseType == LifeCyclePhases.Active).Sum(p => p.Days);
            if (activeDays <= 0)
                throw new Exception("The number of days cannot be zero for the active phases of life cycle: " + lifeCycle.Id);

            var startDate = RenewalDate > StartDate ? RenewalDate : StartDate;

            if (startDate.AddDays(activeDays) <= Provider.Database.Now)
                res = LifeCyclePhases.Active;
            else {
                var renewalDays = phases.Where(p => p.PhaseType == LifeCyclePhases.WaitingForRenewal).Sum(p => p.Days);

                if (startDate.AddDays(activeDays+renewalDays) <= Provider.Database.Now)
                    res = LifeCyclePhases.WaitingForRenewal;
                else
                {
                    var restoreDays = phases.Where(p => p.PhaseType == LifeCyclePhases.WaitingForRestore).Sum(p => p.Days);

                    if (startDate.AddDays(activeDays + renewalDays + restoreDays) <= Provider.Database.Now)
                        res = LifeCyclePhases.WaitingForRestore;
                    else
                        res = LifeCyclePhases.Deleted;
                }
            }

            if (res == LifeCyclePhases.None)
                throw new Exception("Phase cannot be calculated!");

            return res;
        }
    }
}