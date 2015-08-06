// Created: Yalcin Gormez, 2015.01.07

namespace DealerSafe2.DTO.Request
{
    public class ReqCertificateKeyMatcher : BaseRequest
    {
        public string MatchType { get; set; }
        public string Certificate { get; set; }
        public string CSROrPrivateKey { get; set; }
    }
}
