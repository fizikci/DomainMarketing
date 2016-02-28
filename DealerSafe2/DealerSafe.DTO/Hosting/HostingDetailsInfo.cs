using System;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class HostingDetailsInfo
    {
        public string NameSurname { get; set; }
        public string PanelAddress { get; set; }
        public string PanelIp { get; set; }
        public string PanelUserName { get; set; }
        public string PanelPassword { get; set; }

        public string PanelIpOnly { get; set; }

        public string FTPServer1 { get; set; }
        public string FTPUserName1 { get; set; }
        public string FTPPassword1 { get; set; }
        public string FTPServer2 { get; set; }
        public string FTPUserName2 { get; set; }
        public string FTPPassword2 { get; set; }

        public bool WebklavuzuRigth { get; set; }
        public string WebklavuzuFTP { get; set; }
        public string WebklavuzuIpFTP { get; set; }
        public string WebklavuzuUserName { get; set; }
        public string WebklavuzuPassword { get; set; }


        public int MemberId { get; set; }
        public int HostingId { get; set; }
        public int DomainId { get; set; }
        public string DomainName { get; set; }

        public string OperatingSystem { get; set; }

        public string DNS1 { get; set; }
        public string IP1 { get; set; }
        public string DNS2 { get; set; }
        public string IP2 { get; set; }


    }
}
