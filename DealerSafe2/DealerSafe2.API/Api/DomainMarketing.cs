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
            var res = new PagerResponse<ViewDMWatchListItemInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ViewDMWatchListItem>(sql, Provider.CurrentMember.Id, (req.PageNumber - 1) * req.PageSize, req.PageSize)
                .ToList().ToEntityInfo<ViewDMWatchListItemInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt(@"SELECT count(*) FROM ViewDMWatchListItem where MemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);
            return res;
        }

        public bool AddNewBrowse(string id)
        {
            var browse = Provider.Database.Read<DMBrowse>(@"select * from DMBrowse where Id = {0} and (IsDeleted is null or IsDeleted=0) ", id) ?? new DMBrowse();
            browse.InsertDate = DateTime.Now;
            browse.DMItemId = id;
            browse.MemberId = Provider.CurrentMember.Id;
            browse.Save();
            return true;
        }

        public PagerResponse<ViewDMBrowseItemInfo> GetMyBrowseList(ReqPager req)
        {
            var sql = @"select * from ViewDMBrowseItem where MemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate, Status desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var res = new PagerResponse<ViewDMBrowseItemInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ViewDMBrowseItem>(sql, Provider.CurrentMember.Id, (req.PageNumber - 1) * req.PageSize, req.PageSize)
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
            var expertise = Provider.Database.Read<DMExpertise>(@"select Id, IsPublic from DMExpertise where Id = {0}", id);
            return expertise.IsPublic = !expertise.IsPublic;
        }

        public PagerResponse<ListViewDMExpertiseInfo> GetMyExpertiseRequests(ReqPager req)
        {
            var sql = @"select * from ListViewDMExpertise where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0) order by InsertDate, Status desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            var res = new PagerResponse<ListViewDMExpertiseInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMExpertise>(sql, Provider.CurrentMember.Id, (req.PageNumber - 1) * req.PageSize, req.PageSize)
                .ToList().ToEntityInfo<ListViewDMExpertiseInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt(@"SELECT count(*) FROM ListViewDMExpertise where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);
            return res;
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
            var res = new PagerResponse<ListViewDMBrokerageInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMBrokerage>(sql, Provider.CurrentMember.Id, (req.PageNumber - 1) * req.PageSize, req.PageSize)
                .ToList().ToEntityInfo<ListViewDMBrokerageInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt(@"SELECT count(*) FROM ListViewDMBrokerage where RequesterMemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);
            return res;
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
            var sql = @"select * from DMItem where Id = {0}";
            var item = Provider.Database.Read<DMItem>(sql, id);
            return item.ToEntityInfo<DMItemInfo>();
        }

        #endregion

        #region Auctions
        public DMAuctionSearchInfo GetAuction(string req)
        {
            var sql = @"select * from ListViewDMSearch where  Id = {0} And (IsDeleted is null or IsDeleted=0)";
            return Provider.Database.Read<ListViewDMSearch>(sql,req).ToEntityInfo<DMAuctionSearchInfo>();
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
                auc.BiggestBid = auc.SmallestBid = item.MinimumBidPrice;
                auc.BuyItNowPrice = item.BuyItNowPrice;
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

        public Boolean DeleteAuction(string id) {
            var sql = @"select * from DMAuction where Id = {0} And (IsDeleted is null or IsDeleted=0)";
            var auc = Provider.Database.Read<DMAuction>(sql,id);

            if (Provider.Database.GetInt(@"select count(*) from DMBid where DMAuctionId = {0}", id) > 0)
            {
                throw (new Exception("There are bids on this auction, thus can't be deleted!"));
                return false;
            }
            else {
                auc.Status = "4";
                auc.Delete();
                return true;
            }
        }



        public PagerResponse<DMAuctionSearchInfo> GetOpenAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewDMSearch 
                        where 
                        (IsDeleted is null or IsDeleted=0)
                        AND (Status='0')
                        order by StartDate desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionSearchInfo> res = new PagerResponse<DMAuctionSearchInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMAuctionSearchInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMSearch where (IsDeleted is null or IsDeleted=0) And (Status='0')");
            return res;
        }


        public PagerResponse<DMAuctionSearchInfo> GetHotAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewDMSearch 
                        where
                        (IsDeleted is null or IsDeleted=0)
                        And (Status='0')
                        And StartDate >= DATEADD(day, -1, GETDATE())
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionSearchInfo> res = new PagerResponse<DMAuctionSearchInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMAuctionSearchInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMSearch where (IsDeleted is null or IsDeleted=0) And (Status='0') And StartDate >= DATEADD(day, -1, GETDATE()) ");
            return res;
        }


        public PagerResponse<DMAuctionSearchInfo> GetHighestBiddedAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewDMSearch 
                        where
                        (IsDeleted is null or IsDeleted=0)
                        And (Status='0')
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionSearchInfo> res = new PagerResponse<DMAuctionSearchInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMAuctionSearchInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMSearch where (IsDeleted is null or IsDeleted=0) And (Status='0') And SmallestBid != BiggestBid");
            return res;
        }

        public PagerResponse<DMAuctionSearchInfo> GetNoBiddedAuctionsList(ReqPager req)
        {
            var sql = @"select * from ListViewDMSearch 
                        where
                        (IsDeleted is null or IsDeleted=0)
                        And SmallestBid = BiggestBid
                        And (Status='0')
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionSearchInfo> res = new PagerResponse<DMAuctionSearchInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMAuctionSearchInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMSearch where (IsDeleted is null or IsDeleted=0) And (Status='0') And SmallestBid = BiggestBid");
            return res;
        }


        public PagerResponse<DMAuctionSearchInfo> GetMyItemsOnAuction(ReqPager req)
        {
            var sql = @"select * from ListViewDMSearch 
                        where
                        SellerMemberId = {2}
                        And (IsDeleted is null or IsDeleted=0)
                        order by StartDate desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionSearchInfo> res = new PagerResponse<DMAuctionSearchInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize, Provider.CurrentMember.Id).ToEntityInfo<DMAuctionSearchInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt( @"SELECT count(*) FROM ListViewDMSearch where SellerMemberId = {0}", Provider.CurrentMember.Id);
            return res;
        }

        public PagerResponse<DMAuctionSearchInfo> AuctionsWaitingPayment(ReqPager req)
        {
            var sql = @"select (M.FirstName + ' ' + M.LastName) AS WinnerMemberId
		                , A.*
                        from ListViewDMSearch as A
                        Inner Join Member as M On M.Id = A.WinnerMemberId 
                        where A.DMItemId in 
	                        (select DMItemId from DMAuction) 
                        and A.SellerMemberId = {2}                        
                        and A.Status = '1'
                        order by A.StartDate desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionSearchInfo> res = new PagerResponse<DMAuctionSearchInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMSearch>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize, Provider.CurrentMember.Id).ToEntityInfo<DMAuctionSearchInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt(@"SELECT count(*) FROM ListViewDMSearch where SellerMemberId = {0}", Provider.CurrentMember.Id);
            return res;
        }

        public List<DMItemInfo> GetMyItemsNotOnAuction(ReqEmpty req)
        {
            var sql = @"select * from DMItem where Id not in (select DMItemId from DMAuction) and SellerMemberId = {0}";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public List<IdName> GetMyItemsNameIdNotOnAuction(ReqEmpty req)
        {
            var sql = @"select Id, DomainName from DMItem where Id not in (select DMItemId from DMAuction) and SellerMemberId = {0}";
            return Provider.Database.ReadList<DMItem>(sql, Provider.CurrentMember.Id).Select(item => new IdName() { Id = item.Id, Name = item.DomainName }).ToList();
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
            return Provider.Database.Read<DMItem>(sql, id).ToEntityInfo<DMItemInfo>();
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
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMAuctionId = {0} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMAuctionId);

                DMAutoBidder autoBidder = new DMAutoBidder();
                req.CopyPropertiesWithSameName(autoBidder);
                autoBidder.BidderMemberId = Provider.CurrentMember.Id;
                autoBidder.Save();


                if (highestAutoBid != null) {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from ListViewDMSearch where Id = {0}", req.DMAuctionId);

                    if(auction.BiggestBid < highestAutoBid.MaxBidValue){

                        if (highestAutoBid.MaxBidValue > req.MaxBidValue) {
                            req.CopyPropertiesWithSameName(newBid);
                            newBid.BidderMemberId = Provider.CurrentMember.Id;
                            newBid.BidValue = req.MaxBidValue;
                            newBid.Save();
                            newBid = new DMBid();
                            highestAutoBid.CopyPropertiesWithSameName(newBid);
                            if (highestAutoBid.MaxBidValue >= (req.MaxBidValue + minBidInt))
                                newBid.BidValue = req.MaxBidValue + minBidInt;
                            else
                                newBid.BidValue = highestAutoBid.MaxBidValue;
                            newBid.Save();
                        }
                        else if (highestAutoBid.MaxBidValue < req.MaxBidValue)
                        {
                            highestAutoBid.CopyPropertiesWithSameName(newBid);
                            newBid.BidValue = highestAutoBid.MaxBidValue;
                            newBid.Save();
                            newBid = new DMBid();
                            req.CopyPropertiesWithSameName(newBid);
                            newBid.BidderMemberId = Provider.CurrentMember.Id;
                            if (req.MaxBidValue >= (highestAutoBid.MaxBidValue + minBidInt))
                                newBid.BidValue = highestAutoBid.MaxBidValue + minBidInt;
                            else
                                newBid.BidValue = req.MaxBidValue;
                            newBid.Save();
                        }
                    }
                }
            }
            else if (req.MaxBidValue == 0) {//if autobidding value was not set then we are going to check if there is an autobid which has a bigger maxautobidvalue than our current bid value
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMAuctionId = {0} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMAuctionId);
                if(highestAutoBid!=null){
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from ListViewDMSearch where Id = {0}", req.DMAuctionId);
                    if (highestAutoBid.MaxBidValue > req.BidValue) {
                        highestAutoBid.CopyPropertiesWithSameName(newBid);
                        newBid.BidValue = req.BidValue + minBidInt;
                        newBid.Save();
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
                    if(req.MaxBidValue != 0)
                        if (req.MaxBidValue < req.BidValue){
                            throw (new Exception("Auto Bidding Value has to be bigger than bid value!"));
                        }
                    if (req.MaxBidValue > auc.BuyItNowPrice) {
                        throw (new Exception("Auto Bidding Value has to be smaller than Buy It Now Price!"));
                    }

                    if (bid.BidValue >= auc.BuyItNowPrice)
                    {
                        bid.BidValue = auc.BuyItNowPrice;
                        bid.Save();
                        AcceptBid(bid.Id);
                        auc.BiggestBid = bid.BidValue;
                        auc.Save();
                        return true;

                    }
                    auc.BiggestBid = bid.BidValue;
                }
            }
            else
                throw (new Exception("There is no such auction to bid on"));

            auc.Save();
            bid.Save();
            AutoBidder(req,auc);

            return !String.IsNullOrEmpty(bid.BidderMemberId);
        }

        public bool AcceptBid(string id)
        {
            var bid = Provider.Database.Read<DMBid>(@"select * from DMBid where Id = {0}", id);
            
            var sql = @"select * from DMAuction where Id={0} And (IsDeleted is null or IsDeleted=0)";
            var auc = Provider.Database.Read<DMAuction>(sql, bid.DMAuctionId);

            var newSale = new DMSale();
            newSale.SellerMemberId = Provider.Database.GetString(@"select SellerMemberId from ListViewDMSearch where Id = {0}", auc.Id);
            newSale.BuyerMemberId = bid.BidderMemberId;
            newSale.PaymentType = "NotDefinedYet";
            newSale.SaleValue = bid.BidValue;
            newSale.Status = DMSaleStates.WaitingForPayment;
            newSale.InsertDate = DateTime.Now;
            newSale.DMItemId = auc.DMItemId;

            auc.WinnerMemberId = bid.BidderMemberId;
            auc.Status = "1";
            

            if (!String.IsNullOrEmpty(bid.BidderMemberId))
            {
                auc.Save();
                newSale.Save();
            }

            return !String.IsNullOrEmpty(bid.BidderMemberId);
        
        }

        public PagerResponse<DMBidderMemberInfo> GetBidsWithAuctionId(ReqPager req)
        {
            PagerResponse<DMBidderMemberInfo> res = new PagerResponse<DMBidderMemberInfo>();
            ListViewDMSearch checker = Provider.Database.Read<ListViewDMSearch>(@"select ShowBidlist, SellerMemberId from ListViewDMSearch where Id = {0}", req.RelativeId);


            if (Provider.CurrentMember.Id == checker.SellerMemberId)//check if it is seller who is tying to see bids
            {
                return BidlistForSeller(req, res);
            }
            else//
            {

                if (checker.ShowBidlist)//Is it allowed for bidders to see bids
                {
                    return BidlistForBidders(req, res);
                }
                else
                    return res;
            }
        }

        private static PagerResponse<DMBidderMemberInfo> BidlistForSeller(ReqPager req, PagerResponse<DMBidderMemberInfo> res)
        {
            var sql = @"select FirstName, LastName, BidValue, BidId from ListViewDMBidderMember where DMAuctionId = {0}  order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMBidderMember where DMAuctionId = {0}", req.RelativeId);
            if (res.NumberOfItemsInTotal > 0)
                res.ItemsInPage = Provider.Database.ReadList<ListViewDMBidderMember>(sql, req.RelativeId, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMBidderMemberInfo>();
            return res;
        }

        private static PagerResponse<DMBidderMemberInfo> BidlistForBidders(ReqPager req, PagerResponse<DMBidderMemberInfo> res)
        {
            var sql = @"select FirstName, LastName, BidValue, MemberId from ListViewDMBidderMember where DMAuctionId = {0}  order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMBidderMember where DMAuctionId = {0}", req.RelativeId);
            if (res.NumberOfItemsInTotal > 0)
                res.ItemsInPage = Provider.Database.ReadList<ListViewDMBidderMember>(sql, req.RelativeId, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMBidderMemberInfo>();
            return res;
        }


        public PagerResponse<DMAuctionMemberInfo> BidsForMyItems(ReqPager req)
        {
            var sql = @"select * from ListViewDMAuctionMember 
                        where
                        MemberId = {2}
                        order by BiggestBid desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMAuctionMemberInfo> res = new PagerResponse<DMAuctionMemberInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewDMAuctionMember>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize, Provider.CurrentMember.Id).ToEntityInfo<DMAuctionMemberInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewDMAuctionMember");
            return res;
        }


        public PagerResponse<DMBidderMemberInfo> MyBidsForItems(ReqPager req)
        {
            PagerResponse<DMBidderMemberInfo> res = new PagerResponse<DMBidderMemberInfo>();
            var sql = @"select DomainName, BidValue, BidId, Type, BiggestBid,DMAuctionId from ListViewDMBidderMember where MemberId = {0}  order by InsertDate desc OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) from ListViewDMBidderMember where MemberId = {0}", Provider.CurrentMember.Id);
            if (res.NumberOfItemsInTotal > 0)
                res.ItemsInPage = Provider.Database.ReadList<ListViewDMBidderMember>(sql, Provider.CurrentMember.Id, (req.PageNumber - 1) * req.PageSize, req.PageSize).ToEntityInfo<DMBidderMemberInfo>();
            return res;
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
            auc.Status = "1";


            if (!String.IsNullOrEmpty(req.OffererMemberId))
            {
                auc.Save();
                newSale.Save();
            }

            return !String.IsNullOrEmpty(req.OffererMemberId);

        }


        public PagerResponse<DMOfferItemMemberInfo> OffersForMyItems(ReqPager req)
        {
            var sql = @"select * from ListViewOfferItemMember
                        where
                        MemberId = {2}
                        And Status = '0'
                        order by OfferValue desc OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

            PagerResponse<DMOfferItemMemberInfo> res = new PagerResponse<DMOfferItemMemberInfo>();
            res.ItemsInPage = Provider.Database.ReadList<ListViewOfferItemMember>(sql, (req.PageNumber - 1) * req.PageSize, req.PageSize, Provider.CurrentMember.Id).ToEntityInfo<DMOfferItemMemberInfo>();
            res.NumberOfItemsInTotal = Provider.Database.GetInt("SELECT count(*) FROM ListViewOfferItemMember");
            return res;
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