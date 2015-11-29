using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.Enums;
using DealerSafe2.API.Entity.Members;

namespace DealerSafe2.API.Entity.Orders
{
    public class MemberTransaction : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public string RelatedEntityName { get; set; }
        [ColumnDetail(Length = 12)]
        public string RelatedEntityId { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public string ExternalPaymentCode { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }

        public override void AfterSave(bool isUpdate)
        {
            base.AfterSave(isUpdate);

            if (!isUpdate) //TODO: what if isUpdate is true?
            {
                var m = this.Member();
                m.CreditBalance -= Amount;
                m.Save();
            }


        }
    }

    public class ListViewMemberTransaction : MemberTransaction
    {
        public string MemberName { get; set; }
    }
}