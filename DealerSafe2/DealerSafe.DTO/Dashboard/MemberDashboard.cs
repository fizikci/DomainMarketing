using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Web.UI;
using DealerSafe.DTO.HyperV;
using DealerSafe.DTO.Membership;

namespace DealerSafe.DTO.Dashboard
{
    public class MemberDashboard : DashboardReport
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime RegDate { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public int UnreadMessageCount { get; set; }
        public int ProfileCompletion { get; set; }
        public List<KayakoTicket> Tickets { get; set; } //Üye yönetim sayfasındaki GetLatestTicket() metodundan yararlan sonra metodu sil
        public List<DiscountBulletinInfo> DiscountBulletins { get; set; }
        public string ExpiringProducts { get; set; }
        public List<ResGetDomainMove> DomainMoves { get; set; } 

        public MemberDashboard()
        {
            Domain = 0;
            Hosting = 0;
            TradeMark = 0;
            PreRequest = 0;
            VirtualServer = 0;
            SslPci = 0;
            BackOrder = 0;
            DedicatedServer = 0;
            WebKlavuzu = 0;
            Coupon = 0;
            Credit = 0;
            PendingPayment = 0;
            PendingPaymentCount = 0;
            UnreadMessageCount = 0;
            MemberRegisterYear = 0;
        }

    }

    public class DashboardReport
    {
        public int Domain { get; set; }
        public int Hosting { get; set; }
        public int TradeMark { get; set; }
        public int PreRequest { get; set; }
        public int VirtualServer { get; set; }
        public int SslPci { get; set; }
        public int BackOrder { get; set; }
        public int DedicatedServer { get; set; }
        public int WebKlavuzu { get; set; }

        public int Coupon { get; set; }
        public decimal Credit { get; set; }
        public decimal PendingPayment { get; set; }
        public int PendingPaymentCount { get; set; }
        public int MemberRegisterYear { get; set; }
    }
    
    public class KayakoTicket
    {
        public int TicketId { get; set; }
        public string Subject { get; set; }
        public DateTime LastDate { get; set; }
        public string Status { get; set; }
    }

    public class Notice
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int IsRead { get; set; }
    }

    public class ExpiringProduct
    {
        public string Name { get; set; }
        public int ExpireDuration { get; set; }
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public decimal RenewPrice { get; set; }
        public int Count { get; set; }
    }

    public class BulletinCookie
    {
        public DateTime ExpiringDate { get; set; }
        public int MemberId { get; set;}
        public int ShowAgain { get; set; }
        public int BulletinId { get; set; }

        public BulletinCookie()
        {
            MemberId = 0;
            ShowAgain = 0;
            BulletinId = 0;
        }

    }

}
