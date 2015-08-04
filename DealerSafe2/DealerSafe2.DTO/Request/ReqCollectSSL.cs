using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.Request
{
    public class ReqCollectSSL : BaseRequest
    {
        public string orderNumber { get; set; }
        public string certificateId { get; set; }
        public string baseOrderNumber { get; set; }
        public ComodoResponseType responseType { get; set; }
        public ComodoResponseEncoding responseEncoding { get; set; }

    }
}
