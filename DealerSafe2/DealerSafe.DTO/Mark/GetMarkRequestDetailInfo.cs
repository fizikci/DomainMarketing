using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class GetMarkRequestDetailInfo
    {
        public bool Process { get; set; }
        public string Message { get; set; }

        public int Id { get; set; }
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
        public List<RequestLogDetail> Logs { get; set; }
        public List<RequestAnswerDetail> RequestAnswers { get; set; }
    }
    public class RequestLogDetail
    {
        public int Id { get; set; }
        public int BrandRequestId { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public int RequestId { get; set; }
        public int ProcessStatus { get; set; }
        public DateTime ProcessDate { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class RequestAnswerDetail
    {
        public int AnswerType { get; set; }
        public string AnswerHtml { get; set; }
    }
}
