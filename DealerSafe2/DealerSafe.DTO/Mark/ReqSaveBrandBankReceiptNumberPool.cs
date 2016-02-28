using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class ReqSaveBrandBankReceiptNumberPool
    {
        public int Id { get; set; }
        public int MarkId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal PurchasePrice { get; set; }
        public string FileName { get; set; }
        public string BankReceiptNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public Int16 Statu { get; set; }
        public int TotalClassNumber { get; set; }
        public string MemberMail { get; set; }
        public DateTime BankReceiptNumberDate { get; set; }
        public List<ReqSaveBrandBankReceiptNumberPoolClass> MarkClassList { get; set; }

    }
    public class ReqSaveBrandBankReceiptNumberPoolClass
    {
        public int Id { get; set; }
        public int PoolId { get; set; }
        public string ClassNumber { get; set; }
        public int ProductId { get; set; }
    }
}
