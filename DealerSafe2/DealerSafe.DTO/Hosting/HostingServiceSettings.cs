using System;
using System.Collections.Generic;
using DealerSafe.DTO.Enums;
using DealerSafe.DTO.Membership;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class HostingServiceSettings
    {
        public int MemberId { get { if (Member != null)return (int)Member.Id; throw new Exception(); } }

        public MemberInfo Member { get; set; }
        public List<HostingProperty> HostingProperties { get; set; }
        public MemberProductsInfo MemberProduct { get; set; }

        public EnmPanelTypes PanelType
        {
            get
            {
                if (Server != null) return (EnmPanelTypes)Server.PanelType; throw new Exception();
            }
            set
            {

            }
        }
        public int HostingId { get { if (MemberProduct != null)return MemberProduct.Id; throw new Exception(); } }

        public List<MemberProductDomainsInfo> Domains { get; set; }
        public string TempDomain { get; set; }

        public string PanelUserName { get; set; }
        public string PanelPassword { get; set; }

        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }

        public tblMailServersInfo MailServer { get; set; }
        public int MailServerId { get { if (MailServer != null)return MailServer.Id; throw new Exception(); } }
        public string MailServerIP { get { if (MailServer != null)return MailServer.MailServerIP; throw new Exception(); } }

        public tblServersInfo Server { get; set; }
        public int ServerId { get { if (Server != null)return Server.Id; throw new Exception(); } }
        public string HostIp { get { if (Server != null) return Server.ServerIP; throw new Exception(); } }
        public string HostUserName { get { if (Server != null) return Server.Username; throw new Exception(); } }
        public string HostPassword { get { if (Server != null) return Server.Password; throw new Exception(); } }


        public MemberProductDomainsInfo SelectDomain { get; set; }
        public int DomainId { get { if (SelectDomain != null) return SelectDomain.Id; throw new Exception(); } }
        public string DomainName { get { if (SelectDomain != null) return SelectDomain.DomainName; throw new Exception(); } }

        public string Description { get; set; }

    }
}