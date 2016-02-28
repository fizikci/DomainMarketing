using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class MembersHostTo
    {
        public int Id { get; set; }
        public decimal OrderID { get; set; }
        public decimal MemberID { get; set; }
        public decimal DomainID { get; set; }
        public string DomainName { get; set; }
        public decimal ProductID { get; set; }
        public int DiscSize { get; set; }
        public int DomainHost { get; set; }
        public int MailCount { get; set; }
        public int FTPCount { get; set; }
        public int SQL { get; set; }
        public int Access { get; set; }
        public int WEBMail { get; set; }
        public int BandWidth { get; set; }
        public int Setup { get; set; }
        public int OnlineHelp { get; set; }
        public int Backup { get; set; }
        public int Report { get; set; }
        public int RealAudio { get; set; }
        public int OldHostingPeriod { get; set; }
        public int HostingPeriod { get; set; }
        public string OldActivityDate { get; set; }
        public string ActivityDate { get; set; }
        public int Activity { get; set; }
        public int Status { get; set; }
        public int HostingProcess { get; set; }
        public string HostingDetail { get; set; }
        public int PleskConfigured { get; set; }
        public string Explanation { get; set; }
        public DateTime ExplanationDate { get; set; }
        public string PleskServerIP { get; set; }
        public decimal HostingTypeID { get; set; }
        public decimal ClientTemplateID { get; set; }
        public decimal DomainTemplateID { get; set; }
        public int DomainRemains { get; set; }
        public int MailRemains { get; set; }
        public int PanelType { get; set; }
        public string PanelUserName { get; set; }
        public bool IsPacketChanged { get; set; }
        public int DomainChangeCount { get; set; }
        public int EmailPanelType { get; set; }
        public int EmailServerID { get; set; }
        public int Suspended { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int LastPeriod { get; set; }
    }
}
