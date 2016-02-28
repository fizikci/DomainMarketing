using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveBrandDetail
    {
        public int MarkId { get; set; }
        public int ProductId { get; set; }
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public string BrandOwner { get; set; }
        public string NewBrandOwner { get; set; }
        public string NewBrandOwnerConfirmCode { get; set; }
        public DateTime ChangeBrandOwnerDate { get; set; }
        public string BrandName { get; set; }
        public string NewBrandName { get; set; }
        public string NewBrandNameConfirmCode { get; set; }
        public DateTime ChangeBrandNameDate { get; set; }
        public string CustomerNotes { get; set; }
        public string StaffNotes { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string BankReceiptNumber { get; set; }
        public int BrandStatus { get; set; }
        public int TPEStatus { get; set; }
        public DateTime TaxPaymentDate { get; set; }
        public DateTime CreateDate { get; set; }

        public string TPEApplyNumber { get; set; }
    }
}
