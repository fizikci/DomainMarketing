using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Membership
{
    public class MembersAddressInfo
    {
        public int Id { get; set; }
        public bool RecStatus { get; set; }
        public bool IsUse { get; set; }
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneCC { get; set; }
        public string Phone { get; set; }
        public string FaxCC { get; set; }
        public string Fax { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string InvoiceHeader { get; set; }
        public short ContactType { get; set; }

        public MembersAddressInfo()
        {
            Id = 0;
            RecStatus = false;
            IsUse = false;
            MemberID = 0;
            Name = "";
            Address = "";
            District = "";
            City = "";
            Country = "";
            ZipCode = "";
            PhoneCC = "";
            Phone = "";
            FaxCC = "";
            Fax = "";
            TaxOffice = "";
            TaxNumber = "";
            InvoiceHeader = "";
            ContactType = 1;
        }
    }
}
