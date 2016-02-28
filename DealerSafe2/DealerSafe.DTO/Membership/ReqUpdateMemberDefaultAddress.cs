using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateMemberDefaultAddress
    {
        [Description("Address ID of the member's address")]
        public int Id { get; set; }

        [Description("Member Id of the membber")]
        public int MemberId { get; set; }

        [Description("Type of the member's address")]
        public enmAddressType AddressType { get; set; }
    }

    public enum enmAddressType
    {
        Invoice = 1,
        Shipment = 2,
        Communication = 3,
        //Detail = 2,
    }
}
