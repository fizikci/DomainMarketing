using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class GetPaymentTypeInfo
    {
        public bool Process { get; set; }
        public List<PaymentTypeDetail> PaymentTypes { get; set; }
        public class PaymentTypeDetail
        {
            public int Id { get; set; }
            public int IntPaymentType { get; set; }
            public string strPaymentType { get; set; }
            public int IntStatus { get; set; }
            public int LngSequenceID { get; set; }
            public string PaymnetAbbr { get; set; }
        }
    }
}
