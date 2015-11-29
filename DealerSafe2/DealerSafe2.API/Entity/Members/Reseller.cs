using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinar.Database;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.DTO;
using DealerSafe2.DTO.Enums;
using Order = DealerSafe2.API.Entity.Orders.Order;

namespace DealerSafe2.API.Entity.Members
{
    public class Reseller : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string ResellerTypeId { get; set; }
        public DateTime ResellerEndDate { get; set; }
        public int SetupRegisterFee { get; set; }
        public int PrePaidCreditAmount { get; set; }
        public int MinAdditionalCreditAmount { get; set; }
        public int AdditionalDays0StartFee { get; set; }
        public int AdditionalDays0EndFee { get; set; }
        public int AdditionalDays30StartFee { get; set; }
        public int AdditionalDays30EndFee { get; set; }
        public int AdditionalDays90StartFee { get; set; }
        public int AdditionalDays90EndFee { get; set; }
        public string ListInPartnerNetwork { get; set; }
        public string SupportGroup { get; set; }
        public int RebateRate { get; set; }
        public bool CashRefund { get; set; }
        public int OrderNo { get; set; }

        public bool CanJoinMdf { get; set; }

        public ResellerType ResellerType() { return Provider.ReadEntityWithRequestCache<ResellerType>(ResellerTypeId); }
        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(Id); }


        public bool IsResellerActive()
        {
            if (Member().State == MemberStates.Suspended)
                return false;
            if (Member().IsDeleted)
                return false;

            if (Provider.Database.Now > ResellerEndDate)
                return false;

            return true;
        }


        public bool IsResellerActiveForMdf()
        {
            if (!IsResellerActive())
                return false;

            if (!CanJoinMdf)
                return false;

            return true;
        }

        public List<Orders.Order> Orders;

        public void ReadOrders(DateTime min, DateTime max)
        {
            if (Orders == null)
            {
                this.Orders = Provider.Database.ReadList<Orders.Order>("select * from [Order] where MemberId = {0} AND State='Order' AND IsDeleted=0 AND OrderDate>={1} AND OrderDate<={2}", this.Id, min, max) ?? new List<Order>();
                foreach (var order in Orders)
                    order.ReadItemsRecursive();
            }
        }
    }

    public class ListViewReseller : NamedEntity
    {
        public string ResellerName { get; set; }
        public string Email { get; set; }
        public string ResellerTypeName { get; set; }
    }

    public class ViewReseller : Reseller
    {
        public string ResellerName { get; set; }
        public string Email { get; set; }
        public string ResellerTypeName { get; set; }

    }

}
