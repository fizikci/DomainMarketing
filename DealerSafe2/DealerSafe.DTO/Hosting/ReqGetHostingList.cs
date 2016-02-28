namespace DealerSafe.DTO.Hosting
{
    using Enums;

    public class ReqGetHostingList
    {
        public EnmListTypes EnumListType { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int MemberId { get; set; }
        public string Search { get; set; }
    }
}
