using DealerSafe2.API.Entity.Common;
using DealerSafe2.API.Entity.DomainMarketing;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Social;
using DealerSafe2.DTO.EntityInfo;
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
        #region WatchList & Browse

        public bool AddToWatchList(string id)
        {
            var watch = new DMWatchList();
            if (Provider.Database.Read<DMWatchList>(@"select * from DMWatchList where DmItemId = {0} and (IsDeleted is null or IsDeleted=0) ", id) != null)
                throw new Exception("Cannot add to watchlist twice!");

            watch.DMItemId = id;
            watch.MemberId = Provider.CurrentMember.Id;
            watch.Save();
            return true;
        }
        public bool RemoveFromWatchList(string id)
        {
            var sql = @"select * from DMWatchList where MemberId = {0} and DMItemId = {1} and (IsDeleted is null or IsDeleted=0)";
            var watch = Provider.Database.Read<DMWatchList>(sql, Provider.CurrentMember.Id, id);
            watch.Delete();
            return true;
        }

        public PagerResponse<ViewDMWatchListItemInfo> GetMyWatchList(ReqPager req)
        {
            var sql = @"select * from ViewDMWatchListItem where MemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate, Status desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ViewDMWatchListItem where MemberId = {0} and (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ViewDMWatchListItem, ViewDMWatchListItemInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<ViewDMBrowseItemInfo> GetMyBrowseList(ReqPager req)
        {
            var sql = @"select * from ViewDMBrowseItem where MemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate, Status desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";

            // GetPagerResult<T, ViewDMBrowseItemInfo>(req, sql, totalCountSQL);
            // method was not used because T, the entity for DMBrowse, is not defined. 
            // We did not define it to cut down on total data bandwith and decrease response time and limit the table to 3 columns only.

            var res = new PagerResponse<ViewDMBrowseItemInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMBrowseItem>(sql, Provider.CurrentMember.Id, (req.PageNumber - 1) * req.PageSize, req.PageSize)
                .ToList().ToEntityInfo<ViewDMBrowseItemInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt(@"SELECT count(*) FROM ViewDMBrowseItem where MemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);
            return res;
        }


        #endregion

        #region Member Comment / Rating

        public bool CreateComment(ReqComment req) {
            var comment = new EntityComment();
            comment.EntityName = "Member";

            // validation
            if (req.ToMemberId == Provider.CurrentMember.Id)
                throw new Exception("You cannot comment to yourself!");
            if (req.Rating > 5 || req.Rating == 0 || req.Rating < -5)
                throw new Exception("Invalid Rating.");



            comment.EntityId = req.ToMemberId;
            // Multiply with 100 to set precision to 0.01
            comment.Rating = req.Rating * 100;
            comment.Comment = req.Comment;
            comment.MemberId = Provider.CurrentMember.Id;
            comment.Insert();

            //update user rating
            var newRating = Provider.Database.GetInt(@"select AVG(Rating) from EntityComment where EntityName = {0} AND EntityId = {1}", "Member", req.ToMemberId);
            var member = Provider.Database.Read<Member>(@"select * from Member where id= {0}", req.ToMemberId);
            member.Rating = newRating;
            member.Save();

            return !String.IsNullOrEmpty(comment.Id);
        }

        public PagerResponse<EntityCommentInfo> GetMyComments(ReqPager req)
        {
            var sql = @"select * from ListViewCommentsToMember where Rating > 0 and FromMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewCommentsToMember where Rating > 0 and FromMemberId = {0} and (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewCommentsToMember, EntityCommentInfo>(req, sql, totalCountSQL);
        }
        public PagerResponse<EntityCommentInfo> GetMyComplaints(ReqPager req)
        {
            var sql = @"select * from ListViewCommentsToMember where Rating < 0 and FromMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewCommentsToMember where Rating < 0 and FromMemberId = {0} and (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewCommentsToMember, EntityCommentInfo>(req, sql, totalCountSQL);
        }

        private static PagerResponse<T2> GetPagerResult<T, T2>(ReqPager req, string sql, string totalCountSQL) 
            where T : DealerSafe2.API.Entity.BaseEntity
            where T2 : BaseEntityInfo, new()
        {
            var res = new PagerResponse<T2>();
            res.ItemsInPage = Provider.Database.ReadList<T>(sql,
                    req.RelativeId ?? Provider.CurrentMember.Id,
                    (req.PageNumber - 1) * req.PageSize,
                    req.PageSize)
                .ToList().ToEntityInfo<T2>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt(totalCountSQL, req.RelativeId ?? Provider.CurrentMember.Id);
            return res;
        }

        #endregion

        #region Expertise & Brokerage

        public bool AskForExpertise(string id)
        {
            var expertise = new DMExpertise();
            expertise.RequesterMemberId = Provider.CurrentMember.Id;
            expertise.Status = DMExpertiseStates.Open;
            expertise.DMItemId = id;
            expertise.Insert();

            return !String.IsNullOrEmpty(expertise.Id);
        }

        public bool ToggleExpertisePublic(string id)
        {
            var expertise = Provider.Database.Read<DMExpertise>("select * from DMExpertise where Id = {0}", id);
            expertise.IsPublic = !expertise.IsPublic;
            expertise.Save();
            return expertise.IsPublic;
        }

        public PagerResponse<ListViewDMExpertiseInfo> GetMyExpertiseRequests(ReqPager req)
        {
            var sql = "select * from ListViewDMExpertise where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate, Status desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewDMExpertise where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0)";
            return GetPagerResult<ListViewDMExpertise, ListViewDMExpertiseInfo>(req, sql, totalCountSQL);
        }

        // There might be more than 1 report for an item
        public List<ListViewDMExpertiseInfo> GetExpertiseReports(string id)
        {
            var sql = @"select * from ListViewDMExpertise where RequesterMemberId = {0} and DMItemId = {1} and (IsDeleted is null or IsDeleted=0) and Status = {2}";
            var res = Provider.Database.ReadList<ListViewDMExpertise>(sql, Provider.CurrentMember.Id, id, DMExpertiseStates.Processed.ToString())
                .ToList().ToEntityInfo<ListViewDMExpertiseInfo>();
            return res;
        }


        public bool AskForBrokerage(string id)
        {
            var brokerage = new DMBrokerage();
            brokerage.RequesterMemberId = Provider.CurrentMember.Id;
            brokerage.Status = DMBrokerageStates.Open;
            brokerage.DMItemId = id;
            brokerage.Insert();

            return !String.IsNullOrEmpty(brokerage.Id);
        }

        public PagerResponse<ListViewDMBrokerageInfo> GetMyBrokerageRequests(ReqPager req)
        {
            var sql = @"select * from ListViewDMBrokerage where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate, Status desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewDMBrokerage where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0)";
            return GetPagerResult<ListViewDMBrokerage, ListViewDMBrokerageInfo>(req, sql, totalCountSQL);
        }

        public ListViewDMBrokerageInfo GetBrokerageReports(string id)
        {
            var sql = @"select * from ListViewDMBrokerage where RequesterMemberId = {0} and DMItemId = {1} and (IsDeleted is null or IsDeleted=0) and Status = {2}";
            var res = Provider.Database.Read<ListViewDMBrokerage>(sql, Provider.CurrentMember.Id, id, DMBrokerageStates.Processed.ToString())
                .ToEntityInfo<ListViewDMBrokerageInfo>();
            return res;
        }

        #endregion

        #region ProfileInfo

        public PagerResponse<EntityCommentInfo> GetProfileComplaints(ReqPager req)
        {
            var sql = @"select * from ListViewCommentsToMember where Rating < 0 and ToMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewCommentsToMember where Rating < 0 and ToMemberId = {0} and (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewCommentsToMember, EntityCommentInfo>(req, sql, totalCountSQL);
        }
        public PagerResponse<EntityCommentInfo> GetProfileComments(ReqPager req)
        {
            var sql = @"select * from ListViewCommentsToMember where Rating > 0 and ToMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewCommentsToMember where Rating > 0 and ToMemberId = {0} and (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewCommentsToMember, EntityCommentInfo>(req, sql, totalCountSQL);
        }
        public PagerResponse<ListViewSalesInfo> GetProfileSales(ReqPager req)
        {
            var sql = @"select * 
                        from ListViewSales 
                        where SellerMemberId = {0} 
                            and Status = '" + DMSaleStates.SuccessfullyClosed.ToString()+@"' 
                            and COALESCE(IsPrivateSale, 0) = 0 
                            and COALESCE(IsDeleted, 0) = 0 
                            order by InsertDate, Status desc 
                            OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = @"select count(*) 
                                  from ListViewSales 
                                  where SellerMemberId = {0} 
                                      and Status = '" + DMSaleStates.SuccessfullyClosed.ToString()+@"' 
                                      and COALESCE(IsPrivateSale, 0) = 0 
                                      and COALESCE(IsDeleted, 0) = 0";

            return GetPagerResult<ListViewSales, ListViewSalesInfo>(req, sql, totalCountSQL);
        }

        public DMMemberInfo GetDMProfileInfo(string id)
        {
            var member = Provider.Database.Read<Member>(@"select * from Member where Id={0}", id);
            var memberInfo = new DMMemberInfo();
            member.CopyPropertiesWithSameName(memberInfo);
            memberInfo.FullName = member.FullName;
            var address = member.GetMemberAddresses()
                .Where(x => x.AddressType == AddressTypes.DefaultAddress)
                .FirstOrDefault();
            if (address != null)
                memberInfo.Country = address.Country().Name;
            memberInfo.RegistrationDate = member.InsertDate;

            return memberInfo;
        }

        #endregion

        #region Search

        public List<DMAuctionSearchInfo> GetSearchResults(ReqSearchAuction req)
        {
            if (req == null)
                return new List<DMAuctionSearchInfo>();

            var sql = @"SELECT * FROM ListViewDMSearch WHERE 
                            BiggestBid >= {0} AND BuyItNowPrice >= {0}
                            AND ({1} = 0 OR BiggestBid < {1} OR BuyItNowPrice < {1})
                            AND (Type = {2})
                            AND ((SUBSTRING ( DomainName ,0 , CHARINDEX ( '.' , DomainName )) LIKE {3})
                                AND (SUBSTRING ( DomainName ,0 , CHARINDEX ( '.' , DomainName )) LIKE {4})
                                AND (SUBSTRING ( DomainName ,0 , CHARINDEX ( '.' , DomainName )) LIKE {5}))
                            AND (SUBSTRING ( DomainName ,CHARINDEX ( '.' , DomainName ), LEN(DomainName)) = {6})";
            var res = Provider.Database.ReadList<ListViewDMSearch>(sql,
                    req.MinPrice, 
                    req.MaxPrice, 
                    req.Type.ToString(), 
                    req.StartsWith + "%",
                    "%" + req.EndsWith, 
                    "%" + req.Including + "%", 
                    req.Extension
                ).ToList();
            return res.ToEntityInfo<DMAuctionSearchInfo>();
        }

        public List<string> GetDMItemExtensions(ReqEmpty req) {
            return Provider.Database.GetStringList("select distinct SUBSTRING ( DomainName ,CHARINDEX ( '.' , DomainName ), LEN(DomainName)) from DMItem");
        }

        public DMItemInfo GetPrivateSale(string id)
        {
            var sql = @"select * from DMItem where Id = {0}";
            var item = Provider.Database.Read<DMItem>(sql, id);
            return item.ToEntityInfo<DMItemInfo>();
        }

        #endregion

        #region Auctions
        public ViewAuctionInfo GetAuction(string req)
        {
            var sql = @"select * from ViewAuction where  Id = {0} ";
            return Provider.Database.Read<ViewAuction>(sql, req).ToEntityInfo<ViewAuctionInfo>();
        }

        public DMAuctionSearchInfo SaveAuction(ReqAuction req)
        {
            var oldAuc = Provider.Database.Read<DMAuction>(@"select * from DMAuction where DMItemId = {0}", req.DMItemId);
            if (oldAuc == null)
            {
                var item = Provider.Database.Read<DMItem>(@"select * from DMItem where Id={0}", req.DMItemId);
                item.Status = DMItemStates.OnAuction;
                DMAuction auc = new DMAuction();
                auc.PlannedCloseDate = auc.ActualCloseDate = req.PlannedCloseDate;
                auc.DMItemId = req.DMItemId;
                auc.Comments = req.Comments;
                auc.PaymentDate = DateTime.MinValue;
                auc.StartDate = DateTime.Now;
                auc.Status = "0";
                auc.BiggestBid = 0;
                auc.SmallestBid = item.MinimumBidPrice;
                auc.BuyItNowPrice = item.BuyItNowPrice;
                auc.ShowBidlist = true;
                auc.Save();
                item.Save();

                auc.Item.Status = DMItemStates.OnAuction;

                return auc.ToEntityInfo<DMAuctionSearchInfo>();
            }
            else
            {
                oldAuc.PlannedCloseDate = req.PlannedCloseDate;
                oldAuc.Comments = req.Comments;
                oldAuc.Status = "0";
                oldAuc.Save();
                return oldAuc.ToEntityInfo<DMAuctionSearchInfo>();
            }
        }

        public ResAucUpdate GetAuctionUpdateInfo(string id)
        {
            var auc = Provider.Database.Read<ListViewDMSearch>(@"select Comments, PlannedCloseDate, DMItemId,DomainName from ListViewDmSearch where Id={0} ", id);
            ResAucUpdate res = new ResAucUpdate();
            auc.CopyPropertiesWithSameName(res);
            
            return res;

        }

        public bool DeleteAuction(string id) {
            var sql = @"select * from DMAuction where Id = {0} And (IsDeleted is null or IsDeleted=0)";
            var auc = Provider.Database.Read<DMAuction>(sql,id);

            if (Provider.Database.GetInt(@"select count(*) from DMBid where DMAuctionId = {0}", id) > 0)
            {
                throw (new Exception("There are bids on this auction, thus it can't be deleted!"));
            }
            else {
                auc.Status = "4";
                auc.Delete();
                return true;
            }
        }



        public PagerResponse<ListViewAuctionsInfo> GetOpenAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions
                        where (IsDeleted IS NULL OR IsDeleted=0)
                        order by StartDate desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewAuctions where (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }


        public PagerResponse<ListViewAuctionsInfo> GetHotAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        WHERE StartDate >= DATEADD(day, -1, GETDATE())
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewAuctions
                                WHERE StartDate >= DATEADD(day, -1, GETDATE())
                                and (IsDeleted IS NULL OR IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }


        public PagerResponse<ListViewAuctionsInfo> GetHighestBiddedAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewAuctions where (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<ListViewAuctionsInfo> GetNoBiddedAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        where BiggestBid = 0 or BiggestBid IS NULL
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewAuctions where BiggestBid = 0 where (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<ListViewAuctionsInfo> GetExpiredAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        where PlannedCloseDate < GetDate() and Status = 'DueDateReached'
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewAuctions where BiggestBid = 0 where (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<ListViewAuctionsInfo> GetClosedAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        where PlannedCloseDate < GetDate() and (Status = 'Completed or Status = 'DirectBuy') and SaleStatus = 'SuccessfullyClosed'
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewAuctions
                                where PlannedCloseDate < GetDate() and (Status = 'Completed or Status = 'DirectBuy') and SaleStatus = 'SuccessfullyClosed'
                                and (IsDeleted IS NULL OR IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<ListViewAuctionsInfo> GetWaitingPaymentAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        where PlannedCloseDate < GetDate() and (Status = 'Completed or Status = 'DirectBuy') and SaleStatus = 'WaitingForPayment'
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewAuctions 
                                where PlannedCloseDate < GetDate() and (Status = 'Completed or Status = 'DirectBuy') and SaleStatus = 'WaitingForPayment'
                                and (IsDeleted IS NULL OR IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<ListViewAuctionsInfo> GetWaitingTransferAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewAuctions 
                        where PlannedCloseDate < GetDate() and (Status = 'Completed or Status = 'DirectBuy') and SaleStatus = 'WaitingForTransfer'
                        and (IsDeleted IS NULL OR IsDeleted=0)
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewAuctions  
                                where PlannedCloseDate < GetDate() and (Status = 'Completed or Status = 'DirectBuy') and SaleStatus = 'WaitingForTransfer'
                                and (IsDeleted IS NULL OR IsDeleted=0)";

            return GetPagerResult<ListViewAuctions, ListViewAuctionsInfo>(req, sql, totalCountSQL);
        }


        public PagerResponse<ListViewMyItemsOnAuctionInfo> GetMyItemsOnAuction(ReqPager req)
        {
            var sql = @"select * from ListViewMyItemsOnAuction 
                        where SellerMemberId = {2}
                            and (IsDeleted is null or IsDeleted=0)
                        order by StartDate desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = @"SELECT count(*) FROM ListViewMyItemsOnAuction where SellerMemberId = {0}";

            return GetPagerResult<ListViewMyItemsOnAuction, ListViewMyItemsOnAuctionInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<WaitingPaymentInfo> AuctionsWaitingPayment(ReqPager req)
        {
            var sql = @"SELECT * FROM ListViewWaitingPayment WHERE SellerMemberId = {0} AND Status = 'WaitingForPayment'";
            var totalCountSQL = @"SELECT COUNT(*) FROM ListViewWaitingPayment WHERE SellerMemberId = {0} AND Status = 'WaitingForPayment'";

            return GetPagerResult<ListViewWaitingPayment, WaitingPaymentInfo>(req, sql, totalCountSQL);
        }

        public List<DMItemInfo> GetMyItemsNotOnAuction(ReqEmpty req)
        {
            var sql = @"select * from DMItem where Status = {0} and SellerMemberId = {1}";
            return Provider.Database.ReadList<DMItem>(sql, DMItemStates.NotOnAuction.ToString(), Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public List<IdName> GetMyItemsNameIdNotOnAuction(ReqEmpty req)
        {
            var sql = @"select Id, DomainName from DMItem where Status = {0} and SellerMemberId = {1} and ((VerificationAsked = 1 and IsVerified = 1) or VerificationAsked = 0)";
            return Provider.Database.ReadList<DMItem>(sql, DMItemStates.NotOnAuction.ToString(), Provider.CurrentMember.Id).Select(item => new IdName() { Id = item.Id, Name = item.DomainName }).ToList();
        }

        public PagerResponse<ListViewWonAuctionsInfo> AuctionsIWon(ReqPager req)
        {
            var sql = @"SELECT * FROM ListViewWonAuctions WHERE BuyerMemberId = {0}";
            var totalCountSQL = @"SELECT COUNT(*) FROM ListViewWonAuctions WHERE BuyerMEmberId = {0}";

            return GetPagerResult<ListViewWonAuctions, ListViewWonAuctionsInfo>(req, sql, totalCountSQL);
        }

        #endregion

        #region Items

        public List<IdName> GetItemCategoryList(ReqEmpty req)
        {
            return Provider.Database.ReadList<DMCategory>(@"select Id, Name from DMCategory where IsDeleted is null or IsDeleted=0 order by OrderNo, Name")
                .Select(x => new IdName { Id = x.Id, Name = x.Name }).ToList();
        }

        public List<string> GetItemTypesList(ReqEmpty req)
        {
            return Enum.GetNames(typeof(DMItemTypes)).ToList();
        }

        public bool CreatePrivateSales(string id)
        {
            var item = Provider.Database.Read<DMItem>("select * from DMItem where Id = {0}", id);
            item.IsPrivateSales = true;
            item.Save();
            return true;
        }
        public List<IdName> GetMyItemsIdNotOnSale(ReqEmpty req)
        {
            var sql = "select Id, DomainName from DMItem where Status = {0} and SellerMemberId = {1} and COALESCE(IsDeleted, 0) = 0 and COALESCE(IsPrivateSales, 0) = 0 ";
            return Provider.Database.ReadList<DMItem>(sql, DMItemStates.NotOnAuction.ToString(), Provider.CurrentMember.Id)
                .Select(x => new IdName() { Id = x.Id, Name = x.DomainName }).ToList();
        }

        public List<IdName> GetLanguageList(ReqEmpty req)
        {
            return Provider.Database.ReadList<Language>(@"select Id, Name from Language where IsDeleted is null or IsDeleted=0 order by OrderNo, Name")
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
            var sql = @"select * from DMItem where (IsDeleted is null or IsDeleted=0) and SellerMemberId = {0} order by Type, DomainName";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public DMItemInfo GetMyItem(string id)
        {
            var sql = @"select * from DMItem where (IsDeleted is null or IsDeleted=0) and Id = {0} and SellerMemberId = {1}";
            return Provider.Database.Read<DMItem>(sql, id, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public DMItemInfo GetItem(string id)
        {
            var sql = @"select * from DMItem where (IsDeleted is null or IsDeleted=0) and Id = {0}";
            var item = Provider.Database.Read<DMItem>(sql, id);
            if (item != null)
                Provider.Database.ExecuteNonQuery("insert into DMBrowse( MemberId, DMItemId, InsertDate ) values ({0}, {1}, {2})", Provider.CurrentMember.Id, id, DateTime.Now);
            return item.ToEntityInfo<DMItemInfo>();
        }

        public List<IdName> GetDomainBlackList(ReqEmpty req)
        {
            var sql = @"select * from DMBlackList where (IsDeleted is null or IsDeleted=0)";
            return Provider.Database.ReadList<DMBlackList>(sql, Provider.CurrentMember.Id).ToEntityInfo<IdName>();
        }

        public bool SaveMyItem(DMItemInfo req)
        {
            if (this.GetDomainBlackList(new ReqEmpty()).Where(x => x.Name == req.DomainName).Count() > 0)
                throw new Exception("Domain name cannot be " + req.DomainName);

            DMItem item = new DMItem();

            //if new record
            if (string.IsNullOrWhiteSpace(req.Id))
                item.Status = DMItemStates.NotOnAuction;

            req.CopyPropertiesWithSameName(item);
            item.SellerMemberId = Provider.CurrentMember.Id;
            item.DomainRegistrar = getDomainRegistrarWith(req.DomainName);
            item.DomainRegistrationDate = getDomainRegistrationDateWith(req.DomainName);
            item.Save();

            return !String.IsNullOrEmpty(item.Id);
        }

        public bool DeleteMyItem(string id)
        {
            var x = Provider.Database.Read<DMItem>(@"select * from DMItem where (IsDeleted is null or IsDeleted=0) and Id = {0} order by Type, DomainName", id);
            x.Delete();
            return true;
        }

        #endregion

        #region Biddings&Offers

        public DMBidderMemberInfo GetBid(string id)
        {

            var sql = @"SELECT * FROM ListViewDMBidderMember WHERE BidId= {0} And (IsDeleted is null or IsDeleted=0)";
            var res = Provider.Database.Read<ListViewDMBidderMember>(sql, id).ToEntityInfo<DMBidderMemberInfo>();
            return res;
        }

        public void AutoBidder(ReqBid req,DMAuction auction) {

            DMBid newBid = new DMBid();

            if (req.MaxBidValue > 0)
            {
                //if autobidding value is set first, 
                //we are going to check if there is a higher autobidding value then, knock one out
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMAuctionId = {0} AND BidderMemberId != {1} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMAuctionId, Provider.CurrentMember.Id);

                DMAutoBidder autoBidder = new DMAutoBidder();
                req.CopyPropertiesWithSameName(autoBidder);
                autoBidder.BidderMemberId = Provider.CurrentMember.Id;
                autoBidder.Save();


                if (highestAutoBid.MaxBidValue > 0 && highestAutoBid != null) {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from ListViewDMSearch where Id = {0}", req.DMAuctionId);

                    if(auction.BiggestBid < highestAutoBid.MaxBidValue){

                        if (highestAutoBid.MaxBidValue > req.MaxBidValue) {
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMAuctionId = req.DMAuctionId;
                            newBid.BidderMemberId = Provider.CurrentMember.Id;
                            newBid.BidValue = req.MaxBidValue;
                            newBid.Save();
                            newBid = new DMBid();
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMAuctionId = highestAutoBid.DMAuctionId;
                            newBid.BidderMemberId = highestAutoBid.BidderMemberId;
                            if (highestAutoBid.MaxBidValue >= (req.MaxBidValue + minBidInt))
                                newBid.BidValue = req.MaxBidValue + minBidInt;
                            else
                                newBid.BidValue = highestAutoBid.MaxBidValue;
                            newBid.Save();
                            auction.BiggestBid = newBid.BidValue;
                        }
                        else if (highestAutoBid.MaxBidValue < req.MaxBidValue)
                        {
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMAuctionId = highestAutoBid.DMAuctionId;
                            newBid.BidderMemberId = highestAutoBid.BidderMemberId;
                            newBid.BidValue = highestAutoBid.MaxBidValue;
                            newBid.Save();
                            newBid = new DMBid();
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMAuctionId = req.DMAuctionId;
                            newBid.BidderMemberId = Provider.CurrentMember.Id;
                            if (req.MaxBidValue >= (highestAutoBid.MaxBidValue + minBidInt))
                                newBid.BidValue = highestAutoBid.MaxBidValue + minBidInt;
                            else
                                newBid.BidValue = req.MaxBidValue;
                            newBid.Save();
                            auction.BiggestBid = newBid.BidValue;
                        }
                        auction.Save();
                    }
                }
            }
            else if (req.MaxBidValue == 0) {//if autobidding value was not set then we are going to check if there is an autobid which has a bigger maxautobidvalue than our current bid value
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMAuctionId = {0} AND BidderMemberId != {1} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMAuctionId,Provider.CurrentMember.Id);
                if (highestAutoBid.MaxBidValue > 0 && highestAutoBid != null)
                {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from ListViewDMSearch where Id = {0}", req.DMAuctionId);
                    if (highestAutoBid.MaxBidValue > req.BidValue) {
                        newBid.BidComments = "Automaticly bidded";
                        newBid.DMAuctionId = highestAutoBid.DMAuctionId;
                        newBid.BidderMemberId = highestAutoBid.BidderMemberId;
                        newBid.BidValue = req.BidValue + minBidInt;
                        newBid.Save();
                        auction.BiggestBid = newBid.BidValue;
                        auction.Save();
                    }
                    else if (highestAutoBid.MaxBidValue <= req.BidValue) {//
                        //Do nothing
                    }
                }
            }
            
        }

        public bool SaveBid(ReqBid req) {
            DMBid bid = new DMBid();
            bid.BidderMemberId = Provider.CurrentMember.Id;
            req.CopyPropertiesWithSameName(bid);
            var auc = Provider.Database.Read<DMAuction>(@"select * from DMAuction where  Id = {0} And (IsDeleted is null or IsDeleted=0)", req.DMAuctionId);
            if (auc != null)
            {
                if (bid.BidValue < auc.BiggestBid)
                    throw (new Exception("New bids have to be bigger"));
                else
                {
                    if (req.MaxBidValue != 0)
                        if (req.MaxBidValue < req.BidValue)
                        {
                            throw (new Exception("Auto Bidding Value has to be bigger than bid value!"));
                        }
                    if (req.MaxBidValue > auc.BuyItNowPrice)
                    {
                        throw (new Exception("Auto Bidding Value has to be smaller than Buy It Now Price!"));
                    }

                    if (auc.BiggestBid == 0 && bid.BidValue >= (auc.SmallestBid)) {
                        throw (new Exception("First bid has to be bigger then or equal to Mininmum Bid Value that is " + auc.SmallestBid.ToString() ));
                    }

                    if (bid.BidValue >= auc.BuyItNowPrice)
                    {
                        bid.BidValue = auc.BuyItNowPrice;
                        bid.Save();
                        AcceptBid(bid.Id);

                        return true;

                    }
                    auc.BiggestBid = bid.BidValue;
                }
            }
            else
                throw (new Exception("There is no such auction to bid on"));

            auc.Save();
            bid.Save();
            AutoBidder(req, auc);

            return !String.IsNullOrEmpty(bid.BidderMemberId);
        }

        public bool AcceptBid(string id)
        {
            var bid = Provider.Database.Read<DMBid>(@"select * from DMBid where Id = {0}", id);
            
            var sql = @"select * from DMAuction where Id={0} And (IsDeleted is null or IsDeleted=0)";
            var auc = Provider.Database.Read<DMAuction>(sql, bid.DMAuctionId);

            var newSale = new DMSale();
            newSale.SellerMemberId = Provider.Database.GetString(@"select SellerMemberId from DMItem where Id = {0}", auc.DMItemId);
            newSale.BuyerMemberId = bid.BidderMemberId;
            newSale.PaymentType = "NotDefinedYet";
            newSale.SaleValue = bid.BidValue;
            newSale.Status = DMSaleStates.WaitingForPayment;
            newSale.InsertDate = DateTime.Now;
            newSale.DMItemId = auc.DMItemId;

            auc.WinnerMemberId = bid.BidderMemberId;
            auc.Status = DMAuctionStates.Completed;
            

            if (!String.IsNullOrEmpty(bid.BidderMemberId))
            {
                auc.Save();
                newSale.Save();
            }

            return !String.IsNullOrEmpty(bid.BidderMemberId);
        
        }

        public PagerResponse<DMBidderMemberInfo> GetBidsWithAuctionId(ReqPager req)
        {
            var res = new PagerResponse<DMBidderMemberInfo>();
            var totalCountSQL = "SELECT count(*) FROM ListViewDMBidderMember where DMAuctionId = {0}";
            var sql = "";

            //check if it is seller who is tying to see bids
            if (Provider.CurrentMember.Id == Provider.Database.GetString("SELECT SellerMemberId FROM DMItem where Id = (select DMItemId from DMAuction where Id={0}) ", req.RelativeId))
                sql = @"select * from ListViewDMBidderMember where DMAuctionId = {0}  order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            //Is it allowed for bidders to see bids
            else if (Provider.Database.GetBool("select ShowBidlist from DMAuction where Id = {0}", req.RelativeId))
                sql = @"select * from ListViewDMBidderMember where DMAuctionId = {0}  order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            else return res;

            return GetPagerResult<ListViewDMBidderMember, DMBidderMemberInfo>(req, sql, totalCountSQL);
        }

        public PagerResponse<DMAuctionMemberInfo> BidsForMyItems(ReqPager req)
        {
            var sql = @"select * from ListViewDMAuctionMember where MemberId = {2}
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewDMAuctionMember where (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewDMAuctionMember, DMAuctionMemberInfo>(req, sql, totalCountSQL);
        }


        public PagerResponse<ViewMyBidsForItemsInfo> MyBidsForItems(ReqPager req)
        {
            var sql = @"select * from ViewMyBidsForItems where BidderMemberId = {0}  order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) from ViewMyBidsForItems where BidderMemberId = {0}";

            return GetPagerResult<ViewMyBidsForItems, ViewMyBidsForItemsInfo>(req, sql, totalCountSQL);
        }


        public bool SaveOffer(ReqOffer req)
        {

            //var auc = Provider.Database.Read<DMAuction>(@"select DMAuction")

            DMOffer offer = new DMOffer();
            req.CopyPropertiesWithSameName(offer);
            offer.OffererMemberId = Provider.CurrentMember.Id;

            if(!String.IsNullOrEmpty(offer.OffererMemberId))
                offer.Save();

            return !String.IsNullOrEmpty(offer.OffererMemberId);
        }


        public bool AcceptOffer(ReqAcceptOffer req)
        {

            var sql = @"select * from DMAuction where Id={0}";
            var auc = Provider.Database.Read<DMAuction>(sql, req.DMAuctionId);

            var newSale = new DMSale();
            newSale.SellerMemberId = req.MemberId;
            newSale.BuyerMemberId = req.OffererMemberId;
            newSale.PaymentType = "NotDefinedYet";
            newSale.SaleValue = req.OfferValue;
            newSale.Status = DMSaleStates.WaitingForPayment;
            newSale.InsertDate = DateTime.Now;
            newSale.DMItemId = req.DMItemId;

            auc.WinnerMemberId = req.OffererMemberId;
            auc.Status = DMAuctionStates.DirectBuy;


            if (!String.IsNullOrEmpty(req.OffererMemberId))
            {
                auc.Save();
                newSale.Save();
            }

            return !String.IsNullOrEmpty(req.OffererMemberId);

        }


        public PagerResponse<DMOfferItemMemberInfo> OffersForMyItems(ReqPager req)
        {
            var sql = @"select * from ListViewOfferItemMember where MemberId = {2} And Status = '0'
                        order by OfferValue desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
            var totalCountSQL = "SELECT count(*) FROM ListViewOfferItemMember where (IsDeleted is null or IsDeleted=0)";

            return GetPagerResult<ListViewOfferItemMember, DMOfferItemMemberInfo>(req, sql, totalCountSQL);
        }

        public bool showBidsToggle(ReqBidsToggle req) {

            if (Provider.CurrentMember.Id != req.MemberId)
            {
                return false;
            }
            else 
            {
                var auc = Provider.Database.Read<DMAuction>(@"select * from DMAuction where Id={0}", req.AuctionId);
                if (auc.ShowBidlist)
                    auc.ShowBidlist = false;
                else
                    auc.ShowBidlist = true;
                auc.Save();
                return true;
            }
        }
        
        
        #endregion

    }
}