namespace DealerSafe.DTO.Hosting
{
    using System;
    
    [Serializable]
    public class tblMailServersInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MailServerIP { get; set; }
        public string Pop3IP { get; set; }
        public string SmtpIP { get; set; }
        public string WebMailIP { get; set; }
        public string Mobile { get; set; }
        public string Spf { get; set; }
        public int Status { get; set; }
        public string MxIP { get; set; }
        public int MailServerPriority { get; set; }
        public string MailServerHostName { get; set; }
        public string MxServer { get; set; }
        public string MxIP2 { get; set; }
        public string MailServerHostName2 { get; set; }
        public string MailServerPriority2 { get; set; }
        public string MxServer2 { get; set; }
        public string MxIP3 { get; set; }
        public string MailServerHostName3 { get; set; }
        public string MailServerPriority3 { get; set; }
        public string MxServer3 { get; set; }
        public string MxIP4 { get; set; }
        public string MailServerHostName4 { get; set; }
        public string MailServerPriority4 { get; set; }
        public string MxServer4 { get; set; }
        public int EmailPanelTypeID { get; set; }
    }
}
