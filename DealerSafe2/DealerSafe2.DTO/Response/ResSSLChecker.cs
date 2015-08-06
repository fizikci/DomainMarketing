using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerSafe2.DTO.Response
{
    public class ResSSLChecker
    {
        public Server server { get; set; }
        public Cert cert { get; set; }
        public Chain chain { get; set; }
        public NextIssuer next_issuer { get; set; }

        public class Server
        {
            public string url { get; set; }
            public string domain { get; set; }
            public string domain_isIDN { get; set; }
            public string hostname { get; set; }
            public string ip { get; set; }
            public string port { get; set; }
            public string gmtUnixTime { get; set; }
            public string gmtUnixTime_skew { get; set; }
            public string nameindication { get; set; }
            public string software { get; set; }
        }

        public class Cert
        {
            public string serialNumber { get; set; }
            public string notBefore { get; set; }
            public string validity_notBefore { get; set; }
            public string notAfter { get; set; }
            public string validity_notAfter { get; set; }
            public string key_size { get; set; }
            public string key_algorithm { get; set; }
            public string signature_hash_algorithm { get; set; }
            public string signature_key_algorithm { get; set; }
            public string subject_DN { get; set; }
            public string subject_C { get; set; }
            public string subject_postalCode { get; set; }
            public string subject_S { get; set; }
            public string subject_L { get; set; }
            public string subject_streetAddress_1 { get; set; }
            public string subject_OU { get; set; }
            public string subject_O { get; set; }
            public string subject_CN { get; set; }
            public string url_isNameMatch { get; set; }
            public string isMultiDomain { get; set; }
            public string isWildcard { get; set; }
            public string issuer_DN { get; set; }
            public string issuer_CN { get; set; }
            public string issuer_OU { get; set; }
            public string issuer_O { get; set; }
            public string issuer_C { get; set; }
            public string issuer_brand { get; set; }
            public string policyOID { get; set; }
            public string ev_businessCategory { get; set; }
            public string validation { get; set; }
            public string hasEVPolicyOID { get; set; }
            public string status_ocsp_stapled { get; set; }
        }

        public class Chain
        {
            public string isTrusted_microsoft { get; set; }
            public string isTrusted_mozilla { get; set; }
        }

        public class NextIssuer
        {
            public string DN { get; set; }
            public string CN { get; set; }
            public string OU { get; set; }
            public string O { get; set; }
            public string C { get; set; }
            public string brand { get; set; }
        }
    }
}

