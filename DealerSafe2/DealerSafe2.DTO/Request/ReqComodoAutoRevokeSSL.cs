namespace DealerSafe2.DTO.Request
{
    public class ReqComodoAutoRevokeSSL: BaseRequest
    {
        /// <summary>
        /// Required
        /// </summary>
        public int orderNumber { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public int certificateId { get; set; }
        
        /// <summary>
        /// Required
        /// </summary>
        public string revocationReason { get; set; }
    }
}
