using System.ComponentModel;

namespace DealerSafe.DTO.Domain
{
    public class ReqSetPrivacyProtectionToDirecti
    {
        [Description("Directi's order id")]
        public int DirectiOrderId { get; set; }

        [Description("Who is locking this domain")]
        public string LockerId { get; set; }

        [Description("Why is being locked this domain")]
        public string Reason { get; set; }

        [Description("Want to lock or unlock")]
        public bool ToLock { get; set; }
    }
}
