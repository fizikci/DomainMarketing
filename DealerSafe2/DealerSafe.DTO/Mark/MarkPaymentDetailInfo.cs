using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class MarkPaymentDetailInfo
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
        public DateTime ChangeBrandOwnerDate { get; set; }
        public string MarkName { get; set; }
        public string MemberDescription { get; set; }
        public string StaffDescription { get; set; }
        public DateTime LastProcessDate { get; set; }
        public double Price { get; set; }
        public double PurchasePrice { get; set; }
        public string Currency { get; set; }
        public int BrandStatus { get; set; }
        public int TPEStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public string BankReceiptNumber { get; set; }
        public string ClassList { get; set; }
        public string ClassIdList { get; set; }
        public DateTime FileOrderDate { get; set; }
        public string FileName { get; set; }
        public DateTime BankReceiptNumberDate { get; set; }


    }
}
