using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.Members
{
    public class MemberRole : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        [ColumnDetail(Length = 12)]
        public string RoleId { get; set; }

        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }
        public Role Role() { return Provider.ReadEntityWithRequestCache<Role>(RoleId); }

    }

    public class ListViewMemberRole : MemberRole
    {
        public string MemberName { get; set; }
        public string RoleName { get; set; }
    }
}