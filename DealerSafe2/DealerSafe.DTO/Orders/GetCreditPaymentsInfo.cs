using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetCreditPaymentsInfo
    {
        public bool Process { get; set; }
        public List<CreditPaymentDetail> CreditPayments { get; set; }
        public class CreditPaymentDetail
        {
            public int Id { get; set; }
            public decimal CreditID { get; set; }
            public decimal MemberID { get; set; }
            public int BankID { get; set; }
            public string PostDate { get; set; }
            public string PostTime { get; set; }
            public string Notices { get; set; }
            public int PaymentTypeID { get; set; }
            public double OdenenMiktar { get; set; }
            public string OdenenMiktarTipi { get; set; }
            public int PaymentProcess { get; set; }
            public string AdminNotices { get; set; }
            public string PaymentDate { get; set; }
            public string OdemeYapanKisi { get; set; }
        }
    }
}
