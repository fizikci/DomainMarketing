namespace DealerSafe.DTO.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class TblDnsTo
    {
        public int Id { get; set; }
        public string PrimaryNS { get; set; }
        public string SecondaryNS { get; set; }
        public string WebserverIP { get; set; }
        public string MailServerIP { get; set; }
        public decimal Refresh { get; set; }
        public decimal Retry { get; set; }
        public decimal Expire { get; set; }
        public decimal MinimumTTL { get; set; }
        public string FtpserverIP { get; set; }
        public string MailserverPriority { get; set; }
        public string MailServerHostname { get; set; }
        public string ServerIP { get; set; }
        public string Password { get; set; }
        public decimal Port { get; set; }
        public string DomainType { get; set; }
        public string MxServer { get; set; }
        public string MxIP { get; set; }
        public string Pop3IP { get; set; }
        public string SmtpIP { get; set; }
        public string WebMailIP { get; set; }
    }
}
