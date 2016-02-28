namespace DealerSafe.DTO.Membership
{
    public class ReqUpdateMembersDefaultContact
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public short ContactType { get; set; }
    }
}
