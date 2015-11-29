using System.Collections.Generic;
namespace DealerSafe2.DTO.Request
{
    public class ReqUpdateDomainNameServers : BaseRequest
    {
        public string DomainName { get; set; }
        public List<string> NameServers { get; set; }
    }
}
