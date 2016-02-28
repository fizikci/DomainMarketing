using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class GetPaymentsInfo
    {
        public bool Process { get; set; }
        public List<PaymentDetail> PaymentList { get; set; }
    }
    public class PaymentDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int BankID { get; set; }
        public string PostDate { get; set; }
        public string PostTime { get; set; }
        public string Notices { get; set; }
        public int PaymentTypeID { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentAmountType { get; set; }
        public int Process { get; set; }
        public int Status { get; set; }
        public string AdminNotices { get; set; }
        public string PaymentDate { get; set; }
        public string OdemeYapanKisi { get; set; }
        public string TicketId { get; set; }
        public string WireTransferComment { get; set; }
        public int ConfirmingOpId { get; set; }
    }
}
