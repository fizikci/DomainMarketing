using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Dashboard
{
    public class ResApprovedMarketingMember
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone2Cc { get; set; }
        public string Phone2 { get; set; }
        public string RequestType { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool EmailPermission { get; set; }
        public bool MobilePermission { get; set; }
        public bool IvrPermission { get; set; }
        public string NameSurname { get; set; }
    }

    public class ReqMemberMarketingAuth
    {
        public int MemberId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool EmailPermission { get; set; }
        public DateTime EmailPermissionDate { get; set; }
        public bool MobilePermission { get; set; }
        public DateTime MobilePermissionDate { get; set; }
        public bool IvrPermission { get; set; }
        public DateTime IvrPermissionDate { get; set; }
    }

    public class ResMemberMarketingAuth
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool EmailPermission { get; set; }
        public DateTime EmailPermissionDate { get; set; }
        public bool MobilePermission { get; set; }
        public DateTime MobilePermissionDate { get; set; }
        public bool IvrPermission { get; set; }
        public DateTime IvrPermissionDate { get; set; }
    }
}
