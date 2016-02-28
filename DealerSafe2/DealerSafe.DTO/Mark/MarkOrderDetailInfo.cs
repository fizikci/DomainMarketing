using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class MarkOrderDetailInfo
    {
        public int MarkID { get; set; }
        public int ProductId { get; set; }
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string BrandOwner { get; set; }
        public string NewBrandOwner { get; set; }
        public string NewBrandOwnerConfirmCode { get; set; }
        public DateTime ChangeBrandOwnerDate { get; set; }
        public string MarkName { get; set; }
        public string NewBrandName { get; set; }
        public string NewBrandNameConfirmCode { get; set; }
        public DateTime ChangeBrandNameDate { get; set; }
        public List<MarkOrderClassDetail> ClassList { get; set; }
        public List<MarkOrderClassDetail> AddClassList { get; set; }
        public string MemberDescription { get; set; }
        public string StaffDescription { get; set; }
        public DateTime LastProcessDate { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public int BrandStatus { get; set; }
        public int TPEStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime TaxPaymentDate { get; set; }
        public string BankReceiptNumber { get; set; }
        public string TPEApplyNumber { get; set; }
        public int OrdersDetailID { get; set; }


        public class MarkOrderClassDetail
        {
            public int ClassNumber { get; set; }
            public decimal Price { get; set; }
            public int PaymentStatus { get; set; }
        }
    }
}
