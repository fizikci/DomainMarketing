using DealerSafe2.DTO.Enums;
namespace DealerSafe2.DTO.Request
{
    public class ReqPlaceOrderForDomain : BaseRequest
    {
        public string DomainName { get; set; }
        public int Years { get; set; }

        public string TransferCode { get; set; }
    }
}
