namespace DealerSafe.DTO.Hosting
{
    using System.Collections.Generic;

    public class ReqGetAvailableServer
    {
        public int ServerId { get; set; }
        public List<tblServersInfo> ServerList { get; set; }
        public int MemberProductId { get; set; }
    }
}
