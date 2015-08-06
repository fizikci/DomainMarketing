// Created: Yalcin Gormez, 2015.01.07

namespace DealerSafe2.DTO.Response
{
    public class ResCertificateKeyMatcher
    {
        public string CertificateHash { get; set; }
        public string CSROrPrivateKeyHash { get; set; }
        public bool IsMatch { get; set; }
    }
}
