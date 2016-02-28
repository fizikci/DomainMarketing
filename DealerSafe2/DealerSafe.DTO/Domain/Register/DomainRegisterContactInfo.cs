using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Domain.Register
{
    public class DomainRegisterContactInfo
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public int Status { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int ContactType { get; set; }
        public int ContactCompatibility { get; set; }
        public string IdentityNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public int ReferenceId { get; set; }
    }
}
