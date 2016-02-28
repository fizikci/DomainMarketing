using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqChangeOrderAndPayType
    {
        public int OrderID { get; set; }
        public PaymentType PayType { get; set; }
    }
    public enum PaymentType
    {
        BankaHavalesi = 1,
        MailOrder = 2,
        KrediKartıPeşin = 3,
        KrediKartıTaksit = 4,
        MailOrderTaksit = 5,
        Kredili = 6,
        PostaÇeki = 7,
        BonusPay = 8,
        PayPal = 9,
        ÖdemeYapılmamış = 0,
        OdemeTamamlandi = 10,
        Mobile = 12
    }
}
