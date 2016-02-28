using System;
using System.Collections.Generic;
using DealerSafe.DTO.Membership;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class HostingDetail
    {
        public Enums.EnmPanelTypes enmPanelTypes { get; set; }
        public string ProductCode { get; set; }
        public string DomainTemplate { get; set; }
        public string ClientTemplate { get; set; }
        public bool Reseller { get; set; }
        public tblServersInfo Server { get; set; }
        public MemberInfo Member { get; set; }
        public List<MemberProductDetailsInfo> MemberProductDetails { get; set; }
        public MemberProductDomainsInfo Domain { get; set; }
        public List<MemberProductDomainsInfo> Domains { get; set; }
        public tblMailServersInfo MailServer { get; set; }
        public DnsByTldInfo DnSbyTld { get; set; }
        public MemberProductsInfo MemberProduct { get; set; }
        private MembersAddressInfo _MemberAdress;
        public MembersAddressInfo MemberAddress
        {
            get
            {
                if (_MemberAdress != null)
                {
                    _MemberAdress.InvoiceHeader = Member.Email;
                    return _MemberAdress;
                }
                return new MembersAddressInfo()
                {
                    Phone = "2163299393",
                    Fax = "2163292333",
                    InvoiceHeader = "muhammed@fbs.com.tr",
                    Address = "Lutfen adres bilgilerinizi duzenleyiniz",
                    City = "Sehir belirtiniz",
                    District = "Bolge belirtiniz",
                    ZipCode = "34764"
                };
            }
            set { _MemberAdress = value; }
        }
    }
}
