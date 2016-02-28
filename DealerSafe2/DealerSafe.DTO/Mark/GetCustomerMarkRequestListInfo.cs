using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetCustomerMarkRequestListInfo
    {
        public List<RequestDetail> RequestList { get; set; }
    }
    public class RequestDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public string OrdersDate { get; set; }
        public int MemberID { get; set; }
        public string BrandOwner { get; set; }
        public string BrandName { get; set; }
        public string NewBrandName { get; set; }
        public string NewBrandNameConfirmCode { get; set; }
        public DateTime ChangeBrandNameDate { get; set; }
        public string ClassList { get; set; }
        public string OwnerEmail { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerMobile { get; set; }
        public string CustomerNotes { get; set; }
        public string StaffNotes { get; set; }
        public int RequestStatus { get; set; }
        public int ProcessStatus { get; set; }
        public int ReviewofResultStatus { get; set; }
        public string AnswerResult { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ContactNextDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
