using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Membership
{
    public class GetMemberInvoiceListInfo
    {
        public List<InvoiceDetail> InvoiceList { get; set; }
    }
    public class InvoiceDetail
    {
        public int ID { get; set; }
        public decimal MemberID { get; set; }
        public decimal OrderID { get; set; }
        public string InvoiceID { get; set; }
        public string InvoiceSerailNumber { get; set; }
        public string InvoiceDate { get; set; }
        public int InvoiceCompanyID { get; set; }
        public string AdminNotice { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceAddress { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public int InvoiceProcess { get; set; }
        public int IsCustomerDebit { get; set; }
        public decimal DbPaymentAmount { get; set; }
        public decimal AddressID { get; set; }
    }
}
