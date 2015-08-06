using DealerSafe2.API.Entity.Common;
using DealerSafe2.API.Entity.DomainMarketing;
using DealerSafe2.DTO.EntityInfo.DomainMarketing;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        #region Search

        public List<DMAuctionSearchInfo> GetSearchResults(ReqSearchAuction req)
        {
            if (req == null)
                return new List<DMAuctionSearchInfo>();

            var sql = @"SELECT * FROM ListViewDMSearch WHERE 
                            IsPrivateSales = 0
                            AND BiggestBid >= {0} AND BuyItNowPrice >= {0}
                            AND ({1} = 0 OR BiggestBid < {1} OR BuyItNowPrice < {1})
                            AND (Type = {2})
                            AND (DomainName LIKE {3})
                            AND (DomainName LIKE {4})
                            AND (DomainName LIKE {5})
                            AND (DomainName LIKE {6})";
            var res = Provider.Database.ReadList<ListViewDMSearch>(sql,
                    req.MinPrice, 
                    req.MaxPrice, 
                    req.Type.ToString(), 
                    req.StartsWith + "%",
                    "%" + req.EndsWith, 
                    "%" + req.Including + "%", 
                    "%" + req.Extention
                ).ToList();
            return res.ToEntityInfo<DMAuctionSearchInfo>();
        }

        public DMItemInfo GetPrivateSale(string id)
        {
            var sql = "select * from DMItem where Id = {0}";
            var item = Provider.Database.Read<DMItem>(sql, id);
            return item.ToEntityInfo<DMItemInfo>();
        }

        #endregion

        #region Auctions
        public DMAuctionSearchInfo GetAuction(string req)
        {
            var sql = "select * from ListViewDMSearch where  Id = {0}";
            return Provider.Database.Read<ListViewDMSearch>(sql,req).ToEntityInfo<DMAuctionSearchInfo>();
        }

        public DMAuctionSearchInfo CreateAuction(ReqAuction req)
        {
            DMAuction auc = new DMAuction();
            auc.PlannedCloseDate = auc.ActualCloseDate = req.PlannedCloseDate;
            auc.DMItemId = req.DMItemId;
            auc.Comments = req.Comments;
            auc.PaymentDate = DateTime.MinValue;
            auc.StartDate = DateTime.Now;
            auc.BiggestBid = auc.SmallestBid;
            auc.Save();

            auc.Item.Status = DMItemStates.OnAuction;

            return auc.ToEntityInfo<DMAuctionSearchInfo>();
        }

        public ResOpenAucsListWithRowCount GetOpenAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewDMSearch 
                        where DMItemId in 
	                        (select DMItemId from DMAuction) 
                        order by StartDate desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            ResOpenAucsListWithRowCount res =new ResOpenAucsListWithRowCount();
            res.Auctions = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMAuctionSearchInfo>();
            res.rowCount = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMSearch ");
            return res;
        }

        public List<DMItemInfo> GetMyItemsOnAuction(ReqEmpty req)
        {
            var sql = "select * from DMItem where Id in (select DMItemId from DMAuction) and SellerMemberId = {0}";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public List<DMItemInfo> GetMyItemsNotOnAuction(ReqEmpty req)
        {
            var sql = "select * from DMItem where Id not in (select DMItemId from DMAuction) and SellerMemberId = {0}";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public List<IdName> GetMyItemsNameIdNotOnAuction(ReqEmpty req)
        {
            var sql = "select Id, DomainName from DMItem where Id not in (select DMItemId from DMAuction) and SellerMemberId = {0}";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).Select(item => new IdName() { Id = item.Id, Name = item.DomainName }).ToList();
        }

        #endregion

        #region Items

        public List<IdName> GetItemCategoryList(ReqEmpty req)
        {
            return Provider.Database.ReadList<DMCategory>("select Id, Name from DMCategory where IsDeleted is null or IsDeleted=0 order by OrderNo, Name")
                .Select(x => new IdName { Id = x.Id, Name = x.Name }).ToList();
        }

        public List<string> GetItemTypesList(ReqEmpty req)
        {
            return Enum.GetNames(typeof(DMItemTypes)).ToList();
        }

        public List<IdName> GetLanguageList(ReqEmpty req)
        {
            return Provider.Database.ReadList<Language>("select Id, Name from Language where IsDeleted is null or IsDeleted=0 order by OrderNo, Name")
                .Select(x => new IdName() { Id = x.Id, Name = x.Name }).ToList();
        }


        private DateTime getDomainRegistrationDateWith(string domainName)
        {
            return DateTime.Now;
        }

        private string getDomainRegistrarWith(string domainName)
        {
            return domainName + ", " + DateTime.Now.ToShortDateString();
        }

        public List<DMItemInfo> GetMyItemList(ReqEmpty req)
        {
            var sql = "select * from DMItem where (IsDeleted is null or IsDeleted=0) and SellerMemberId = {0} order by Type, DomainName";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public DMItemInfo GetMyItem(string id)
        {
            var sql = "select * from DMItem where (IsDeleted is null or IsDeleted=0) and Id = {0} and SellerMemberId = {1}";
            return Provider.Database.Read<DMItem>(sql, id, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public DMItemInfo GetItem(string id)
        {
            var sql = "select * from DMItem where (IsDeleted is null or IsDeleted=0) and Id = {0}";
            return Provider.Database.Read<DMItem>(sql, id).ToEntityInfo<DMItemInfo>();
        }

        public List<IdName> GetDomainBlackList(ReqEmpty req)
        {
            var sql = "select * from DMBlackList where (IsDeleted is null or IsDeleted=0)";
            return Provider.Database.ReadList<DMBlackList>(sql, Provider.CurrentMember.Id).ToEntityInfo<IdName>();
        }

        public bool SaveMyItem(DMItemInfo req)
        {
            DMItem item = new DMItem();

            if (this.GetDomainBlackList(new ReqEmpty()).Where(x => x.Name == req.DomainName).Count() > 0)
                throw new Exception("Domain name cannot be " + req.DomainName);

            req.CopyPropertiesWithSameName(item);
            item.SellerMemberId = Provider.CurrentMember.Id;
            item.DomainRegistrar = getDomainRegistrarWith(req.DomainName);
            item.DomainRegistrationDate = getDomainRegistrationDateWith(req.DomainName);
            item.Save();

            return !String.IsNullOrEmpty(item.Id);
        }

        public bool DeleteMyItem(string id)
        {
            var x = Provider.Database.Read<DMItem>("select * from DMItem where (IsDeleted is null or IsDeleted=0) and Id = {0} order by Type, DomainName", id);
            x.Delete();
            return true;
        }

        #endregion

        #region Biddings&Offers

        public bool SaveBid(ReqBid req) {

            DMBid bid = new DMBid();
            req.CopyPropertiesWithSameName(bid);
            bid.BidderMemberId = Provider.CurrentMember.Id;
            
            DMAuction auc = new DMAuction();
            var sql = "select * from ListViewDMSearch where  Id = {0}";
            auc = Provider.Database.Read<DMAuction>(sql, req.DMAuctionId);
            if (bid.BidValue < auc.BiggestBid)
                throw (new Exception("New bids have to be higher"));
            else
                auc.BiggestBid = bid.BidValue;

            if (!String.IsNullOrEmpty(bid.BidderMemberId))
            { 
                auc.Save();
                bid.Save();}
            
            return !String.IsNullOrEmpty(bid.BidderMemberId);
        }

        public ResBidderMemberListWithRows GetBidsWithAuctionId(ReqBidderMemberList req)
        {
            ResBidderMemberListWithRows res = new ResBidderMemberListWithRows(); 
            var sql = "select * from ListViewDMBidderMember where DMAuctionId = {0} order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            res.Bids = Provider.Database.ReadList<ListViewDMBidderMember>(sql, req.id, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMBidderMemberInfo>();
            res.rowCount = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMSearch ");
            return res;
        }


        public ResDMAuctionMember BidsForMyItems(ReqPager req)
        {
            var sql = @"select * from ListViewDMAuctionMember 
                        where
                        MemberId = {2}
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            ResDMAuctionMember res = new ResDMAuctionMember();
            res.Auctions = Provider.Database.ReadList<ListViewDMAuctionMember>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize, Provider.CurrentMember.Id).ToEntityInfo<DMAuctionMemberInfo>();
            res.rowCount = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMAuctionMember");
            return res;
        }

        public bool SaveOffer(ReqOffer req)
        {

            DMOffer offer = new DMOffer();
            req.CopyPropertiesWithSameName(offer);
            offer.OffererMemberId = Provider.CurrentMember.Id;

            if(!String.IsNullOrEmpty(offer.OffererMemberId))
                offer.Save();

            return !String.IsNullOrEmpty(offer.OffererMemberId);
        }

        public ResDMOfferItemMember OffersForMyItems(ReqPager req)
        {
            var sql = @"select * from ListViewOfferItemMember
                        where
                        MemberId = {2}
                        order by OfferValue desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            ResDMOfferItemMember res = new ResDMOfferItemMember();
            res.Items = Provider.Database.ReadList<ListViewOfferItemMember>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize, Provider.CurrentMember.Id).ToEntityInfo<DMOfferItemMemberInfo>();
            res.rowCount = Provider.Database.GetInt("SELECT count(*) FROM ListViewOfferItemMember");
            return res;
        }
        
        
        #endregion


    }
}