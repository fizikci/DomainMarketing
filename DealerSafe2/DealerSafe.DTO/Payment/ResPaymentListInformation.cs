using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Payment
{
    public class ResPaymentListInformation
    {
        public bool Status { get; set; }
        public string ReturnMessage { get; set; }


        public double OrderPrice { get; set; }
        public double ShippingCosts { get; set; }


        public bool CrediCardStatus { get; set; }
        public double CrediCardPrice { get; set; }

        public bool CrediCardInstallmentStatus { get; set; }
        public List<CrediCardInstallment> CrediCardInstallments { get; set; }

        public bool RemittanceStatus { get; set; }
        public double RemittancePrice { get; set; }

        public bool PostalCheckStatus { get; set; }
        public double PostalCheckPrice { get; set; }

        public bool MailOrderStatus { get; set; }
        public double MailOrderPrice { get; set; }

        public bool MailOrderInstallmentStatus { get; set; }
        public List<MailOrderInstallment> MailOrderInstallments { get; set; }

        public bool PaypalStatus { get; set; }
        public double PaypalPrice { get; set; }

        public bool MobileStatus { get; set; }
        public double MobilePrice { get; set; }

        public double CreditPrice { get; set; }
    }

    public class MailOrderInstallment
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int Installment { get; set; }
        public double Price { get; set; }
    }

    public class CrediCardInstallment
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public int Installment { get; set; }
        public double Price { get; set; }
    }

}
