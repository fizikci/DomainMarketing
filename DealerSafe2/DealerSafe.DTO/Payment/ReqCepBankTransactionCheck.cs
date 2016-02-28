using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqCepBankTransactionCheck
    {
        [Description("Transaction Id for Cep bank check")]
        public string TransactionId { get; set; }

        [Description("Total price for Cep bank check")]
        public double TotalPrice { get; set; }

        [Description("Mobile number for Cep bank check")]
        public string CepNo { get; set; }

        [Description("pType for Cep bank check")]
        public string pType { get; set; }

        [Description("Transaction date for Cep bank check")]
        public string TransactionDate { get; set; }

        [Description("Order number for Cep bank check")]
        public int OrderID { get; set; }
    }
}
