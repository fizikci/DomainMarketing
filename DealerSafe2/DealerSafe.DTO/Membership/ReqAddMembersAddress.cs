using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class ReqAddMembersAddress
    {
        [Description("MemberId of the member address")]
        public int MemberId { get; set; }

        [Description("Name of the member address")]
        public string Name { get; set; }

        [Description("Invoice header name of the member address")]
        public string InvoiceHeader { get; set; }

        [Description("Address of the member")]
        public string Address { get; set; }

        [Description("District of the member address")]
        public string District { get; set; }

        [Description("City of the member address")]
        public string City { get; set; }

        [Description("Country ID of the member address")]
        public string Country { get; set; }

        [Description("Zip Code of the member address")]
        public string ZipCode { get; set; }

        [Description("Fax Country Code of the member address")]
        public string FaxCC { get; set; }

        [Description("Fax of the member address")]
        public string Fax { get; set; }

        [Description("Phone Country Code of the member address")]
        public string PhoneCC { get; set; }

        [Description("Phone of the member address")]
        public string Phone { get; set; }

        [Description("Tax Office of the member address")]
        public string TaxOffice { get; set; }

        [Description("Tax Number of the member address")]
        public string TaxNumber { get; set; }

        [Description("Type of the member address")]
        public short ContactType { get; set; }
    }
}
