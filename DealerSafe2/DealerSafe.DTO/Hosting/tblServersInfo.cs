namespace DealerSafe.DTO.Hosting
{
    using System;

    [Serializable]
    public class tblServersInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServerIP { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PanelType { get; set; }
        public int EmailServerID { get; set; }
        public int DnsServerID { get; set; }
        public string NetScalarIP { get; set; }
        public int OperatingSystem { get; set; }
        public int AlternativeServerID { get; set; }
        public int AccountLimit { get; set; }
        public int AccountCount { get; set; }
        public string ClientTemplateName { get; set; }
        public string DomainTemplateName { get; set; }
        public int Status { get; set; }
        public string DNS1 { get; set; }
        public string DNS2 { get; set; }
        public string DNS3 { get; set; }
        public string DNS4 { get; set; }
        public string IP1 { get; set; }
        public string IP2 { get; set; }
        public string IP3 { get; set; }
        public string IP4 { get; set; }
        // 21.04.2015
        public int WhichDnsServer { get; set; }
    }
}
