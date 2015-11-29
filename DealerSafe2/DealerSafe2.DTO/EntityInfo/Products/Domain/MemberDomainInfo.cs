using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;

namespace DealerSafe2.DTO.EntityInfo.Products.Domain
{
    public class MemberDomainInfo : BaseEntityInfo
    {
        public string OrderItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MemberId { get; set; }

        public string DomainName { get; set; }
        public string DomainIDN { get; set; }
        public string ROID { get; set; }

        public DateTime UpdateDate { get; set; }

        public DomainRenewalModes RenewalMode { get; set; }
        public DomainTransferModes TransferMode { get; set; }

        public string RegistryStatus { get; set; } // List<RegistryStates>

        public string RGPStatus { get; set; }

        public string NameServers { get; set; }
        public string HostNames { get; set; }

        public string TldId { get; set; } // com, com.tr, computer gibi IDler çok şık olur


        public string OwnerDomainContactId { get; set; } // whois veritabanındaki ID aynen kullanılabilir
        public string AdminDomainContactId { get; set; }
        public string TechDomainContactId { get; set; }
        public string BillingDomainContactId { get; set; }

        public PrivacyProtectionOptions PrivacyProtection { get; set; }
        public string AuthInfo { get; set; } // EppCode transfer şifresi

        public OperationalStates OperationalStatus { get; set; }
    }

}
