using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    [TableDetail(ViewSQL= @"
        CREATE VIEW [ListViewWonAuctions] 
        AS
        SELECT
	        I.Id AS DMItemId,
	        A.Id AS DMAuctionId,
	        I.DomainName,
	        I.Type,
	        A.StartDate,
	        S.InsertDate AS CloseDate,
	        A.InsertDate,
	        A.BuyItNowPrice,
	        S.SaleValue,
	        S.BuyerMemberId,
	        S.Status,
	        S.Id,
	        A.IsDeleted
        FROM DMSale AS S
        INNER JOIN Member as M ON M.Id = S.BuyerMemberId
        INNER JOIN DMItem as I ON I.Id = S.DMItemId
        LEFT JOIN DMAuction AS A ON A.DMItemId = S.DMItemId
    ")]
    public class ListViewWonAuctions : BaseEntity 
    {
        public string DMItemId { get; set; }
        public string DMAuctionId { get; set; }
        public string DomainName { get; set; }
        public DMItemTypes Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int BuyItNowPrice { get; set; }
        public int SaleValue { get; set; }
        public string BuyerMemberId { get; set; }
        public DMSaleStates Status { get; set; }

    }
}