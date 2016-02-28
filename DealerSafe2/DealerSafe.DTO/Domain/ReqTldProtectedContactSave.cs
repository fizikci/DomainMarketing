using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ReqTldProtectedContactSave
    {
        public string Name { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string AddressLineFirst { get; set; }

        public string AddressLineLast { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string PhoneCc { get; set; }

        public string Phone { get; set; }

        public string FaxCc { get; set; }

        public string Fax { get; set; }

        public int CustomerId { get; set; }

        public string Attributes { get; set; }

        public int ContactType { get; set; }

        public string DomainTld { get; set; }

        public int ResellerId { get; set; }
    }
}
