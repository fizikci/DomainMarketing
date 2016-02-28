using System.ComponentModel;
namespace DealerSafe.DTO.Domain
{
    public class DomainTransferLogTo
    {
        [Description("Primary Key of Domain")]
        public int DomainId { get; set; }

        [Description("Id of members owner")]
        public int MemberId { get; set; }

        [Description("Info Status")]
        public string InfoStatus { get; set; }

        [Description("Error record")]
        public string Error { get; set; }
    }
}
