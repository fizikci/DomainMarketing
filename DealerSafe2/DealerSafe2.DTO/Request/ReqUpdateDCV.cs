using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.Request
{
    public class ReqUpdateDCV : BaseRequest
    {
        public int orderNumber { get; set; }
        public string domainName { get; set; }
        public ComodoDcvMethod newMethod { get; set; }
        public string newDCVEmailAddress { get; set; }
    }
}
