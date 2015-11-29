using System;
using Cinar.Database;
using DealerSafe2.API.Entity.Members;

namespace DealerSafe2.API.Entity.ApiRelated
{
    public class Client : NamedEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string AdminMemberId { get; set; }

        public string ConnectionStrings { get; set; }

        public Member AdminMember() { return Provider.ReadEntityWithRequestCache<Member>(AdminMemberId); }

        public override void BeforeSave(bool isUpdate)
        {
            base.BeforeSave(isUpdate);

            if (isUpdate) {
                if (AdminMember() != null && AdminMember().ClientId != this.Id)
                    throw new Exception("AdminMember's client must be equal to this client");
            }
        }
    }
}