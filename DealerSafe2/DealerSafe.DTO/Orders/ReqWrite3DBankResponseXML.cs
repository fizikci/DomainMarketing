using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqWrite3DBankResponseXML
    {
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public int BankID { get; set; }
        public string CardNumber { get; set; }
        public int IslemSonuc { get; set; }
        public string XMLResponse { get; set; }
        public DateTime OperationDate { get; set; }
        public string XMLRequest { get; set; }
    }
}
