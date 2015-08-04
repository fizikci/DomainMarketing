using DealerSafe2.DTO.Enums;

namespace DealerSafe2.DTO.Request
{
    public class ReqComodoAutoApplySSL : BaseRequest
    {
        /// <summary>
        /// Required
        /// </summary>
        public string product { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public int years { get; set; }


        /// <summary>
        /// Number of server licences. Wildcard products 1 to 100, otherwise: ignored.
        /// </summary>
        public int servers { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public ComodoServerSoftware serverSoftware { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string csr { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string postalCode { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public string streetAddress1 { get; set; }

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
