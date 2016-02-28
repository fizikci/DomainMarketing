using System;

namespace DealerSafe.DTO.Membership
{
    public class ReqGetMemberMarketingAuthList
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool CheckEmailPermission { get; set; }
        public bool CheckMobilePermission { get; set; }
        public bool CheckIvrPermission { get; set; }

        public int PermissionType { get; set; }
        public int ViewOnPage { get; set; }
    }
}
