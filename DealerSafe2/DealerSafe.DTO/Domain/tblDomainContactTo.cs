using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class tblDomainContactTo
    {
        public int Id { get; set; }

        public decimal MemberID { get; set; }
        public decimal ParentID { get; set; }
        public int ContactType { get; set; }
        public decimal CitizenNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int DefaultStatus { get; set; }
        public int Status { get; set; }
        public string CreatedTime { get; set; }
        public int IsFirstContact { get; set; }
        public int IsTrContact { get; set; }
        public int ContactCompatibility { get; set; }
    }
}
