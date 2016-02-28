namespace DealerSafe.DTO.Domain
{
    public class DomainContactsTo
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int ContactCompatibility { get; set; } //enmContactCompatibility
        public int ContactType { get; set; } //enmMemberType
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Zip { get; set; }
        public string PhoneCC { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public int RowCount { get; set; }
    }
}
