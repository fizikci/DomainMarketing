using System;
using Cinar.Database;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Members
{
    public class RoleRight : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string RoleId { get; set; }
        public Rights Right { get; set; }

        public Role Role() { return Provider.ReadEntityWithRequestCache<Role>(RoleId); }

    }

    public class ListViewRoleRight : RoleRight
    {
        public string RoleName { get; set; }
    }
}