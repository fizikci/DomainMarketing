using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.Request
{
    public class ReqComodoAutoReplaceSSL : BaseRequest
    {
        /// <summary>
        /// Number of server licences. Wildcard products 1 to 100, otherwise: ignored.
        /// </summary>
        public int orderNumber { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public ComodoServerSoftware serverSoftware { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string csr { get; set; }

        /// <summary>
        /// Alternative issuance email address
        /// </summary>
        public string emailAddress { get; set; }

        public ComodoDcvMethod dcvMethod { get; set; }

        public string dcvEmailAddress { get; set; }

        public string isCustomerValidated { get { return "Y"; } }
        public string showCertificateID { get { return "Y"; } }
        
    }
}
