using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe2.DTO.Request
{
    public class ReqPaymentInfo: BaseRequest
    {
        public string Id { get; set; }
        public string CardNumber { get; set; }
        public string NameOnTheCard { get; set; }
        public int LastValidMonth { get; set; }
        public int LastValidYear { get; set; }
        public int CCV { get; set; }
        public string PaymentDescription { get; set; }
    }
}
