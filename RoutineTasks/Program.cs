using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutineTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Auction expire date kontrolü
            
            // 2. WaitingPayment item'ların 14 gün geçmesi halinde TimeoutForPayment moduna alınması

                // - Example code:
                // if (item.InsertDate.AddDays(14) > DateTime.Now)
                // {
                //     item.Status = DMAuctionStates.Cancelled;
                //     item.PaymentStatus = DMSaleStates.TimeoutForPayment;
                //     item.Save();
                // }

            // 3. If the biggest bid is less than the BuyItNowPrice, than the auction has to end with no success.

                // - See page 23, also note that "Max Price" term is only used on this page in the document. 
                // So it is unclear and we took it as BuyItNowPrice. 
            
                // - This means aucitons will not be sold until they reach to BuyItNowPrice 
                // This is just selling the domain from the "BuyItNowPrice" directly.
        }
    }
}
