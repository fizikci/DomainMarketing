using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinar.Database;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.DTO;

namespace DealerSafe2.API.Entity.Orders
{
    public class MdfResellerNote : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MdfResellerId { get; set; }
        [ColumnDetail(Length = 12)]
        public string StaffMemberId { get; set; }
        public string Note {get; set;}

        public MdfReseller MdfReseller() { return Provider.ReadEntityWithRequestCache<MdfReseller>(MdfResellerId); }
        public Member StaffMember() { return Provider.ReadEntityWithRequestCache<Member>(StaffMemberId); }

    }

}
