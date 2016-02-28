using System;

namespace Fbs.Core.Entities
{
    public class tblAdminNoticeInfo
    {
        public int ID { get; set; }
        public int recStatus { get; set; }
        public int User_ID { get; set; }
        public int Member_ID { get; set; }
        public string Topic { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public int forWho { get; set; }
        public int isRead { get; set; }
    }
}
