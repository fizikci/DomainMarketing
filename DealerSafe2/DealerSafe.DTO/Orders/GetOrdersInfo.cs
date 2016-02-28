using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetOrdersInfo
    {
        public bool Process { get; set; }
        public List<OrdersDetail> OrdersList { get; set; }
        public class OrdersDetail
        {
            public int OrderID { get; set; }
            public int MemberID { get; set; }
            public string PaymentTypeID { get; set; }
            public int BankID { get; set; }
            public int Rate { get; set; }
            public string OrderTime { get; set; }
            public string OrderDate { get; set; }
            public string ShipTime { get; set; }
            public string ShipDate { get; set; }
            public string InvoiceName { get; set; }
            public string InvoiceAddress { get; set; }
            public string TaxOffice { get; set; }
            public string TaxNumber { get; set; }
            public double USDselling { get; set; }
            public double EUROselling { get; set; }
            public int Process { get; set; }
            public int Status { get; set; }
            public string IPAdresi { get; set; }
            public string KrediKartiNo { get; set; }
            public double OrderAmountYTL { get; set; }
            public double OrderAmountDolar { get; set; }
            public int IsCustomerDebit { get; set; }
            public bool IsThreeDSecureEnabled { get; set; }
            public string CardHolderName { get; set; }
            public int InvoiceCompanyID { get; set; }
            public int ExecutedCouponId { get; set; }
            public int ExecutedCreditReportsId { get; set; }
            public int InvoiceAddressID { get; set; }
            public int ExecutedVoucherId { get; set; }
            public int IsDebitCard { get; set; }
        }
    }
}
