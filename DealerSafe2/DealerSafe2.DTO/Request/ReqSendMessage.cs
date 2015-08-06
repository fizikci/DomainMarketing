using System;
namespace DealerSafe2.DTO.Request
{
    public class ReqSendMessage : BaseRequest
    {
        public string MemberId { get; set; }
        public string TemplateId { get; set; }
        public string SqlParam { get; set; }
        public DateTime SendDate { get; set; }
        public string AddMessage { get; set; }
        public string AddSubject { get; set; }

    }

}
