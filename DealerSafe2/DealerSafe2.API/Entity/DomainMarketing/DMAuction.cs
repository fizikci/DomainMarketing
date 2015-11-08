using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMAuction : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the auction item(domain/web project), fk referencing item table")]
        public string DMItemId { get; set; }

        [Description("just a toggle")]
        public bool ShowBidlist { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 15), Description("0:open; 1:completed successfully; 2:direct buy(offered the buy it price and seller accepted) ; 3: suspended; 4:cancelled by the seller; 5:due date reached but no successful bid available")]
        public DMAuctionStates Status { get; set; }

        [Description("starting date of the auction")]
        public DateTime StartDate { get; set; }

        [ColumnDetail(Length = 12), Description("used if there exists a date due for the auction")]
        public DateTime PlannedCloseDate { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("the date, the auction is closed")]
        public DateTime ActualCloseDate { get; set; }

        [Description("direct buy price without participating in the auction, namely reserve price")]
        public int BuyItNowPrice { get; set; }

        [Description("the smallest bid so far")]
        public int SmallestBid { get; set; }

        [Description("the biggest bid so far")]
        public int BiggestBid { get; set; }

        [Description("the successfull bid value accepted by the seller")]
        public int ActualSellingPrice { get; set; }

        [Description("total value of the payments made")]
        public int PaymentAmount { get; set; }

        [Description("date of the payment, if there is")]
        public DateTime PaymentDate { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the winner, fk referencing member table")]
        public string WinnerMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("comments about the auction")]
        public string Comments { get; set; }

        private DMItem _Item;

        public DMItem Item
        {
            get
            {
                if (_Item == null)
                    _Item = Provider.Database.Read<DMItem>("select * from DMItem where Id = {0}", this.DMItemId);
                
                return _Item;
            }
        }
    }

}