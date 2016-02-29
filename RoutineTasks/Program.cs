using DealerSafe2.API;
using DealerSafe2.API.Entity.DomainMarketing;
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
            while (true)
            {
                var items = Provider.Database.ReadList<DMItem>("select * from DMItem");
                var now = Provider.Database.Now;
                foreach (var item in items)
                {
                    if (item.Status == DealerSafe2.DTO.Enums.DMAuctionStates.Open
                        && item.PlannedCloseDate.Date < now.Date)
                    {
                        
                        item.Status = DealerSafe2.DTO.Enums.DMAuctionStates.Cancelled;
                        item.StatusReason = DealerSafe2.DTO.Enums.DMAuctionStateReasons.DueDate;
                        item.PaymentStatus = DealerSafe2.DTO.Enums.DMSaleStates.None;
                        item.ActualCloseDate = now;
                        item.Save();
                    }
                    else if (item.PaymentStatus == DealerSafe2.DTO.Enums.DMSaleStates.WaitingForPayment 
                        && item.ActualCloseDate.Date.AddDays(14) < now.Date)
                    {
                        item.Status = DealerSafe2.DTO.Enums.DMAuctionStates.Cancelled;
                        item.StatusReason = DealerSafe2.DTO.Enums.DMAuctionStateReasons.None;
                        item.PaymentStatus = DealerSafe2.DTO.Enums.DMSaleStates.TimeoutForPayment;
                        item.Save();
                    }
                }

                // sleep for 5 minutes
                System.Threading.Thread.Sleep(
                    1000 // miliseconds
                    * 60 // seconds
                    * 5 // minutes
                    );
            }
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
