using DealerSafe2.API.Entity.Common;
using DealerSafe2.API.Entity.DomainMarketing;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Social;
using DealerSafe2.DTO;
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
                throw new Exception(Provider.TR("Cannot add to watchlist twice!"));

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

        public PagerResponse<ListViewDMWatchListItemInfo> GetMyWatchList(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT W.Id,
                               W.DmItemId,
                               W.InsertDate,
                               I.DomainName,
                               I.Status,
                               I.Type,
                               I.IsPrivateSales,
                               I.Ownership
                        FROM DMWatchList AS W
                        LEFT JOIN DMItem AS I ON W.DMItemId = I.Id
                        WHERE W.MemberId = {0}
                        ORDER BY W.InsertDate, I.Status desc
                    ";

            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMWatchList where MemberId = {0}", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewDMWatchListItemInfo>();

            return new PagerResponse<ListViewDMWatchListItemInfo> {ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ViewDMBrowseItemInfo> GetMyBrowseList(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
                            B.DMItemId,
                            B.InsertDate,
                            I.DomainName,
                            I.Status,
                            I.Type,
                            I.IsPrivateSales,
                            I.Ownership
                        FROM DMBrowse AS B
                        INNER JOIN DMItem AS I ON B.DMItemId = I.Id 
                        ORDER BY B.InsertDate, I.Status DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBrowse where MemberId = {0}", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ViewDMBrowseItemInfo>();

            return new PagerResponse<ViewDMBrowseItemInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        #endregion

        #region Member Comment / Rating

        public bool CreateComment(ReqComment req) {
            var comment = new EntityComment();
            comment.EntityName = "Member";

            // validation
            if (req.ToMemberId == Provider.CurrentMember.Id)
                throw new Exception(Provider.TR("You cannot comment to yourself!"));
            if (req.Rating > 5 || req.Rating == 0 || req.Rating < -5)
                throw new Exception(Provider.TR("Invalid Rating."));



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
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        EC.Id,
                            (M.FirstName + M.LastName) AS ToFullName,
                            M.Avatar AS ToAvatar,
                            (F.FirstName + F.LastName) AS SenderFullName,
                            F.Avatar AS SenderAvatar,
	                        EC.MemberId AS SenderMemberId,
	                        EC.EntityId AS ToMemberId,
                            EC.Rating,
                            EC.Comment,
                            EC.InsertDate,
                            EC.IsDeleted
                        FROM EntityComment AS EC 
                        INNER JOIN Member F ON EC.MemberId = F.Id
                        INNER JOIN Member M ON EC.EntityId = M.Id
                        WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.MemberId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0) 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.MemberId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0) ", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        
        public PagerResponse<EntityCommentInfo> GetMyComplaints(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        EC.Id,
                            (M.FirstName + M.LastName) AS ToFullName,
                            M.Avatar AS ToAvatar,
                            (F.FirstName + F.LastName) AS SenderFullName,
                            F.Avatar AS SenderAvatar,
	                        EC.MemberId AS SenderMemberId,
	                        EC.EntityId AS ToMemberId,
                            EC.Rating,
                            EC.Comment,
                            EC.InsertDate,
                            EC.IsDeleted
                        FROM EntityComment AS EC 
                        INNER JOIN Member F ON EC.MemberId = F.Id
                        INNER JOIN Member M ON EC.EntityId = M.Id
                        WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.MemberId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0) 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.MemberId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
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

        public PagerResponse<DMExpertiseInfo> GetMyExpertiseRequests(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
	                        E.Id,
	                        E.RequesterMemberId,
	                        (M.FirstName + ' ' + M.LastName) as ExpertFullName,
	                        E.ExpertMemberId,
	                        E.DMItemId,
	                        I.DomainName,
	                        I.Type,
	                        E.Status,
	                        E.ReportContent,
	                        E.IsPublic,
	                        E.InsertDate
                        FROM DMExpertise AS E
                        INNER JOIN DMItem I on E.DMItemId = I.Id
                        INNER JOIN Member M on M.Id = E.ExpertMemberId
                        WHERE E.RequesterMemberId = {0} and (E.IsDeleted is null or E.IsDeleted=0) 
                        ORDER BY E.InsertDate, E.Status DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMExpertise AS E WHERE E.RequesterMemberId = {0} and (E.IsDeleted is null or E.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMExpertiseInfo>();

            return new PagerResponse<DMExpertiseInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        // There might be more than 1 report for an item
        public List<DMExpertiseInfo> GetExpertiseReports(string id)
        {
            var sql = @"SELECT 
	                        E.Id,
	                        E.RequesterMemberId,
	                        (M.FirstName + ' ' + M.LastName) as ExpertFullName,
	                        E.ExpertMemberId,
	                        E.DMItemId,
	                        I.DomainName,
	                        I.Type,
	                        E.Status,
	                        E.ReportContent,
	                        E.IsPublic,
	                        E.InsertDate
                        FROM DMExpertise AS E
                        INNER JOIN DMItem I on E.DMItemId = I.Id
                        INNER JOIN Member M on M.Id = E.ExpertMemberId
                        WHERE E.RequesterMemberId = {0} and E.DMItemId = {1} AND E.Status = {2} AND (E.IsDeleted is null or E.IsDeleted=0) 
                        ORDER BY E.InsertDate, E.Status DESC";
            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id, id, DMExpertiseStates.Processed.ToString())
                .ToEntityList<DMExpertiseInfo>();
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

        public PagerResponse<DMBrokerageInfo> GetMyBrokerageRequests(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
	                        B.Id,
	                        B.RequesterMemberId,	
	                        (M.FirstName + ' ' + M.LastName) as BrokerFullName,
	                        B.BrokerMemberId,
	                        B.DMItemId,
	                        I.DomainName,	
	                        I.Type,
	                        B.Status,
	                        B.ReportContent,
	                        B.IsDeleted,
	                        B.InsertDate
                        FROM DMBrokerage AS B
                        INNER JOIN DMItem I ON B.DMItemId = I.Id
                        INNER JOIN Member M ON M.Id = B.BrokerMemberId 
                        WHERE B.RequesterMemberId = {0} AND (B.IsDeleted is null or B.IsDeleted=0) 
                        ORDER BY B.InsertDate, B.Status DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBrokerage B WHERE B.RequesterMemberId = {0} AND (B.IsDeleted is null or B.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMBrokerageInfo>();

            return new PagerResponse<DMBrokerageInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public DMBrokerageInfo GetBrokerageReports(string id)
        {
            var sql = @"SELECT 
	                        B.Id,
	                        B.RequesterMemberId,	
	                        (M.FirstName + ' ' + M.LastName) as BrokerFullName,
	                        B.BrokerMemberId,
	                        B.DMItemId,
	                        I.DomainName,	
	                        I.Type,
	                        B.Status,
	                        B.ReportContent,
	                        B.IsDeleted,
	                        B.InsertDate
                        FROM DMBrokerage AS B
                        INNER JOIN DMItem I ON B.DMItemId = I.Id
                        INNER JOIN Member M ON M.Id = B.BrokerMemberId 
                        WHERE B.RequesterMemberId = {0} AND (B.IsDeleted is null or B.IsDeleted=0) AND B.DMItemId = {1} AND B.Status = {2}
                        ORDER BY B.InsertDate, B.Status DESC";
            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id, id, DMBrokerageStates.Processed.ToString())
                .ToEntityList<DMBrokerageInfo>().FirstOrDefault();
            return res;
        }

        #endregion

        #region ProfileInfo

        public PagerResponse<EntityCommentInfo> GetProfileComplaints(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        EC.Id,
                            (M.FirstName + M.LastName) AS ToFullName,
                            M.Avatar AS ToAvatar,
                            (F.FirstName + F.LastName) AS SenderFullName,
                            F.Avatar AS SenderAvatar,
	                        EC.MemberId AS SenderMemberId,
	                        EC.EntityId AS ToMemberId,
                            EC.Rating,
                            EC.Comment,
                            EC.InsertDate,
                            EC.IsDeleted
                        FROM EntityComment AS EC 
                        INNER JOIN Member F ON EC.MemberId = F.Id
                        INNER JOIN Member M ON EC.EntityId = M.Id
                        WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.EntityId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0) 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.EntityId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0) ", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        
        public PagerResponse<EntityCommentInfo> GetProfileComments(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        EC.Id,
                            (M.FirstName + M.LastName) AS ToFullName,
                            M.Avatar AS ToAvatar,
                            (F.FirstName + F.LastName) AS SenderFullName,
                            F.Avatar AS SenderAvatar,
	                        EC.MemberId AS SenderMemberId,
	                        EC.EntityId AS ToMemberId,
                            EC.Rating,
                            EC.Comment,
                            EC.InsertDate,
                            EC.IsDeleted
                        FROM EntityComment AS EC 
                        INNER JOIN Member F ON EC.MemberId = F.Id
                        INNER JOIN Member M ON EC.EntityId = M.Id
                        WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.EntityId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0) 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.EntityId = {0} AND (EC.IsDeleted is null or EC.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewSalesInfo> GetProfileSales(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        I.Id,
	                        I.SellerMemberId,
	                        (SM.FirstName + ' ' + SM.LastName) AS SellerFullName,
	                        I.BuyerMemberId,
	                        (BM.FirstName + ' ' + BM.LastName) AS BuyerFullName,
	                        I.DomainName,
	                        I.Type,
	                        I.Ownership,
	                        I.IsVerified,
	                        I.DescriptionShort,
	                        I.IsPrivateSales,
	                        I.IsDeleted,
	                        I.PaymentAmount,
	                        I.PaymentType,
	                        I.PaymentStatus,
	                        I.PaymentDescription,
	                        I.InsertDate
                        FROM DMItem I
                        LEFT JOIN Member SM ON SM.Id = I.SellerMemberId
                        LEFT JOIN Member BM ON BM.Id = I.BuyerMemberId 
                        WHERE I.SellerMemberId = {0} 
                            AND I.PaymentStatus = 'SuccessfullyClosed' 
                            AND COALESCE(I.IsPrivateSales, 0) = 0 
                            AND COALESCE(I.IsDeleted, 0) = 0 
                            ORDER BY I.InsertDate, I.PaymentStatus DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) 
                        FROM DMItem
                        WHERE SellerMemberId = {0} 
                            AND PaymentStatus = 'SuccessfullyClosed' 
                            AND COALESCE(IsPrivateSales, 0) = 0 
                            AND COALESCE(IsDeleted, 0) = 0 ", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewSalesInfo>();

            return new PagerResponse<ListViewSalesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
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
            if (address != null && !string.IsNullOrEmpty(address.CountryId))
                memberInfo.Country = address.Country().Name;
            memberInfo.RegistrationDate = member.InsertDate;

            return memberInfo;
        }

        #endregion

        #region Search

        public List<DMItemInfo> GetSearchResults(ReqSearchAuction req)
        {
            if (req == null)
                return new List<DMItemInfo>();

            var sql = @"SELECT 
                            I.Id,
                        -- DMItem Fields
	                        I.[SellerMemberId],
	                        I.[Type],
	                        I.[DomainName],
	                        C.[Name] AS CategoryName,
	                        I.[BuyItNowPrice],
	                        L.[Name] as [Language],
	                        I.[DescriptionShort],
	                        I.[PageRank],
	                        I.[StartDate],
	                        I.[PlannedCloseDate],
	                        I.[IsDeleted]
                        FROM DMItem I
                        INNER JOIN DMCategory AS C ON C.Id = I.DMCategoryId
                        INNER JOIN [Language] L on L.Id = I.LanguageId

                        WHERE COALESCE(I.IsDeleted, 0) = 0 AND COALESCE(I.IsPrivateSales, 0) = 0
                        AND I.BiggestBid >= {0} AND I.BuyItNowPrice >= {0}
                            AND ({1} = 0 OR I.BiggestBid < {1} OR I.BuyItNowPrice < {1})
                            AND (I.Type = {2})
                            AND ((SUBSTRING ( I.DomainName ,0 , CHARINDEX ( '.' , I.DomainName )) LIKE {3})
                                AND (SUBSTRING ( I.DomainName ,0 , CHARINDEX ( '.' , I.DomainName )) LIKE {4})
                                AND (SUBSTRING ( I.DomainName ,0 , CHARINDEX ( '.' , I.DomainName )) LIKE {5}))
                            AND (SUBSTRING ( I.DomainName ,CHARINDEX ( '.' , I.DomainName ), LEN(I.DomainName)) = {6})";
            var res = Provider.Database.GetDataTable(sql,
                    req.MinPrice, 
                    req.MaxPrice, 
                    req.Type.ToString(), 
                    req.StartsWith + "%",
                    "%" + req.EndsWith, 
                    "%" + req.Including + "%", 
                    req.Extension
                ).ToEntityList<DMItemInfo>();
            return res;
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
            var sql = @"select * from DMItem where  Id = {0} ";
            return Provider.Database.Read<DMItem>(sql, req).ToEntityInfo<ViewAuctionInfo>();
            }

        public DMItemInfo SaveAuction(ReqAuction req)
        {
            var item = Provider.Database.Read<DMItem>(@"select * from DMItem where Id={0}", req.DMItemId);
            if (item == null)
                throw new APIException("There is no such an item with the ID: " + req.DMItemId);

            req.CopyPropertiesWithSameName(item);

            item.Status = DMAuctionStates.Open;
            item.PlannedCloseDate = req.PlannedCloseDate;
            item.Comments = req.Comments;
            item.PaymentDate = DateTime.MinValue;
            item.StartDate = DateTime.Now;
            item.BiggestBid = 0;
            item.SmallestBid = 0;
            item.BuyItNowPrice = item.BuyItNowPrice;
            item.Save();

            return item.ToEntityInfo<DMItemInfo>();
        }

        public bool DeleteAuction(string id) {
            var sql = @"select * from DMItem where Id = {0} AND (IsDeleted is null or IsDeleted=0)";
            var auc = Provider.Database.Read<DMItem>(sql,id);

            if (Provider.Database.GetInt(@"select count(*) from DMBid where DMItemId = {0}", id) > 0)
            {
                throw (new Exception(Provider.TR("There are bids on this auction, thus it cannot be deleted!")));
            }
            else {
                auc.Status = DMAuctionStates.Cancelled;
                auc.Save();
                auc.Delete();
                return true;
            }
        }


        public PagerResponse<ListViewAuctionsInfo> GetOpenAuctionsList(ReqPager req)
        {
            var sql = @"SELECT 
                          [Id],
                          [BiggestBid],
                          [Type],
                          [DomainName],
                          [MinimumBidInterval],
                          [StartDate],
                          [PlannedCloseDate],
                          [BuyItNowPrice],
                          [IsDeleted],
                          [InsertDate]
                        FROM DMItem
                        WHERE (IsDeleted IS NULL OR IsDeleted=0)
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where (IsDeleted is null or IsDeleted=0)");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        public PagerResponse<ListViewAuctionsInfo> GetHotAuctionsList(ReqPager req)
        {
            var sql = @"SELECT 
                          [Id],
                          [BiggestBid],
                          [Type],
                          [DomainName],
                          [MinimumBidInterval],
                          [StartDate],
                          [PlannedCloseDate],
                          [BuyItNowPrice],
                          [IsDeleted],
                          [InsertDate]
                        FROM DMItem I
                        WHERE StartDate >= DATEADD(day, -1, GETDATE())
                        AND (IsDeleted IS NULL OR IsDeleted=0)
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                                WHERE StartDate >= DATEADD(day, -1, GETDATE())
                                AND (IsDeleted IS NULL OR IsDeleted=0)");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        public PagerResponse<ListViewAuctionsInfo> GetHighestBiddedAuctionsList(ReqPager req)
        {
            var sql = @"SELECT 
                          [Id],
                          [BiggestBid],
                          [Type],
                          [DomainName],
                          [MinimumBidInterval],
                          [StartDate],
                          [PlannedCloseDate],
                          [BuyItNowPrice],
                          [IsDeleted],
                          [InsertDate]
                        FROM DMItem
                        WHERE (IsDeleted IS NULL OR IsDeleted =0)
                        ORDER BY BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where (IsDeleted is null or IsDeleted=0)");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        public PagerResponse<ListViewAuctionsInfo> GetNoBiddedAuctionsList(ReqPager req)
        {
            var sql = @"SELECT 
                          I.[Id],
                          I.[BiggestBid],
                          I.[Type],
                          I.[DomainName],
                          I.[MinimumBidInterval],
                          I.[StartDate],
                          I.[PlannedCloseDate],
                          I.[BuyItNowPrice],
                          I.[IsDeleted],
                          I.[InsertDate]
                        FROM DMItem I
                        WHERE I.Status = 'Open' AND (I.BiggestBid = 0 OR I.BiggestBid IS NULL)
                        AND (I.IsDeleted IS NULL OR I.IsDeleted=0)
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"
                SELECT count(*) FROM DMItem
                WHERE (BiggestBid = 0 or BiggestBid IS NULL) 
                AND (IsDeleted IS NULL OR IsDeleted=0)");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetExpiredAuctionsList(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
                          I.[Id],
                          I.[BiggestBid],
                          I.[Type],
                          I.[DomainName],
                          I.[MinimumBidInterval],
                          I.[StartDate],
                          I.[PlannedCloseDate],
                          I.[BuyItNowPrice],
                          I.[IsDeleted],
                          I.[InsertDate]
                        FROM DMItem I
                        WHERE I.Status = 'DueDateReached' AND I.SellerMemberId={0}
                        AND (I.IsDeleted IS NULL OR I.IsDeleted=0)
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = 20;

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetClosedAuctionsList(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
                          I.[Id],
                          I.[BiggestBid],
                          I.[Type],
                          I.[DomainName],
                          I.[MinimumBidInterval],
                          I.[StartDate],
                          I.[PlannedCloseDate],
                          I.[BuyItNowPrice],
                          I.[IsDeleted],
                          I.[InsertDate]
                        FROM DMItem I
                        WHERE I.Status = 'Closed' AND I.SellerMemberId={0}
                        AND (I.IsDeleted IS NULL OR I.IsDeleted=0)
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"
                        SELECT count(*) FROM DMItem I
                        WHERE I.Status = 'Closed' AND I.SellerMemberId={0}
                        AND (I.IsDeleted IS NULL OR I.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetWaitingPaymentAuctionsList(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
                          [Id],
                          [BiggestBid],
                          [Type],
                          [DomainName],
                          [MinimumBidInterval],
                          [StartDate],
                          [PlannedCloseDate],
                          [BuyItNowPrice],
                          [IsDeleted],
                          [InsertDate],
                          [PaymentStatus]
                        FROM DMItem
                        WHERE PaymentStatus = 'WaitingForPayment' AND SellerMemberId={0}
                        AND (IsDeleted IS NULL OR IsDeleted=0)
                        ORDER BY InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                        WHERE PaymentStatus = 'WaitingForPayment' AND SellerMemberId={0}
                        AND (IsDeleted IS NULL OR IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetWaitingTransferAuctionsList(ReqPager req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
                          [Id],
                          [BiggestBid],
                          [Type],
                          [DomainName],
                          [MinimumBidInterval],
                          [StartDate],
                          [PlannedCloseDate],
                          [BuyItNowPrice],
                          [IsDeleted],
                          [InsertDate]
                        FROM DMItem
                        WHERE PaymentStatus = 'WaitingForTransfer' AND SellerMemberId={0}
                        AND (IsDeleted IS NULL OR IsDeleted=0)
                        ORDER BY InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                        WHERE S.Status = 'WaitingForTransfer' AND SellerMemberId={0}
                        AND (IsDeleted IS NULL OR IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        
        public PagerResponse<ListViewItemsInfo> GetItems(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
	                        Id,
	                        MinimumBidPrice,
	                        MinimumBidInterval,
	                        VerificationAsked,
	                        BiggestBid,
	                        Type,
	                        DomainName,
	                        StartDate,
	                        PlannedCloseDate,
	                        BuyItNowPrice,
	                        Status,
	                        SellerMemberId,
	                        IsDeleted,
	                        InsertDate
                        FROM DMItem
                        WHERE SellerMemberId = {0} AND (IsDeleted is null or IsDeleted=0)
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where SellerMemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewItemsInfo>();

            return new PagerResponse<ListViewItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        
        public PagerResponse<ListViewItemsInfo> GetMyItemsOnAuction(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
	                        Id,
	                        MinimumBidPrice,
	                        MinimumBidInterval,
	                        VerificationAsked,
	                        BiggestBid,
	                        Type,
	                        DomainName,
	                        StartDate,
	                        PlannedCloseDate,
	                        BuyItNowPrice,
	                        Status,
	                        SellerMemberId,
	                        IsDeleted,
	                        InsertDate
                        FROM DMItem
                        WHERE SellerMemberId = {0}
                            AND Status = 'Open'
                            AND (IsDeleted is null or IsDeleted=0)
                            AND (Id IS NOT NULL OR Id <> '')
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                        WHERE SellerMemberId = {0} AND (IsDeleted IS NULL OR IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewItemsInfo>();

            return new PagerResponse<ListViewItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<WaitingPaymentInfo> AuctionsWaitingPayment(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
                            I.DomainName,
                            I.Type,
                            I.StartDate,
                            I.BuyItNowPrice,
                            I.InsertDate AS CloseDate,
                            I.SaleValue,
                            I.BuyerMemberId,
                            I.SellerMemberId,
                            I.Status,
                            M.FirstName,
                            M.LastName
                        FROM DMItem AS I
                        INNER JOIN Member as M ON M.Id = I.BuyerMemberId
                        WHERE I.SellerMemberId = {0} 
                            AND I.PaymentStatus = 'WaitingForPayment' 
                            AND (IsDeleted IS NULL OR IsDeleted=0)";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT COUNT(*) FROM DMItem WHERE SellerMemberId = {0} AND PaymentStatus = 'WaitingForPayment' AND (IsDeleted IS NULL OR IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<WaitingPaymentInfo>();

            return new PagerResponse<WaitingPaymentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        
        public List<IdName> GetMyItemsNameIdNotOnAuction(ReqEmpty req)
        {
            var sql = @"select Id, DomainName from DMItem where Status = {0} and SellerMemberId = {1} and ((VerificationAsked = 1 and IsVerified = 1) or VerificationAsked = 0)";
            return Provider.Database.ReadList<DMItem>(sql, DMAuctionStates.NotOnAuction.ToString(), Provider.CurrentMember.Id).Select(item => new IdName() { Id = item.Id, Name = item.DomainName }).ToList();
        }

        public PagerResponse<ListViewWonAuctionsInfo> AuctionsIWon(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        I.Id AS DMItemId,
	                        I.DomainName,
	                        I.Type,
	                        I.StartDate,
	                        I.InsertDate,
	                        I.BuyItNowPrice,
	                        I.IsDeleted,
	                        I.PaymentAmount,
	                        I.InsertDate AS CloseDate,
	                        I.BuyerMemberId,
	                        I.PaymentStatus,
	                        I.Id
                        FROM DMItem AS I
                        LEFT JOIN Member as M ON M.Id = I.BuyerMemberId
                        WHERE I.BuyerMemberId = {0} AND (I.IsDeleted IS NULL OR I.IsDeleted=0) ORDER BY I.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT COUNT(*) FROM DMItem WHERE BuyerMemberId = {0} AND (IsDeleted IS NULL OR IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewWonAuctionsInfo>();

            return new PagerResponse<ListViewWonAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
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
            return Provider.Database.ReadList<DMItem>(sql, DMAuctionStates.NotOnAuction.ToString(), Provider.CurrentMember.Id)
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

        public bool SaveMyItem(ReqDMSaveItem req)
        {
            if (string.IsNullOrEmpty(Provider.CurrentMember.Id))
                throw new Exception(Provider.TR("Access denied."));

            if (this.GetDomainBlackList(new ReqEmpty()).Where(x => x.Name == req.DomainName).Count() > 0)
                throw new Exception(Provider.TR("Domain name is in blacklist. It cannot be ") + req.DomainName);

            DMItem item = new DMItem();

            //if new record
            if (string.IsNullOrWhiteSpace(req.DMItemId))
                item.Status = DMAuctionStates.NotOnAuction;

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

        #region Biddings & Offers

        public DMBidderMemberInfo GetBid(string id)
        {

            var sql = @"SELECT
	                        B.[Id] AS BidId,
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[BidComments],
	                        B.[InsertDate],
	                        B.[IsDeleted],
	                        M.[Id],
	                        M.[FirstName],
	                        M.[LastName],
	                        M.[UserName],
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[SellerMemberId]
                        FROM DMBid AS B
                        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE BidId = {0} AND (B.IsDeleted IS NULL OR B.IsDeleted=0)";
            var res = Provider.Database.GetDataTable(sql, id).ToEntityList<DMBidderMemberInfo>().FirstOrDefault();
            return res;
        }

        public void AutoBidder(ReqBid req, DMItem auction) {

            DMBid newBid = new DMBid();

            if (req.MaxBidValue > 0)
            {
                //if autobidding value is set first, 
                //we are going to check if there is a higher autobidding value then, knock one out
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMItemId = {0} AND BidderMemberId != {1} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMItemId, Provider.CurrentMember.Id);

                DMAutoBidder autoBidder = new DMAutoBidder();
                req.CopyPropertiesWithSameName(autoBidder);
                autoBidder.BidderMemberId = Provider.CurrentMember.Id;
                autoBidder.Save();


                if (highestAutoBid.MaxBidValue > 0 && highestAutoBid != null) {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from DMItem where Id = {0}", req.DMItemId);

                    if(auction.BiggestBid < highestAutoBid.MaxBidValue){

                        if (highestAutoBid.MaxBidValue > req.MaxBidValue) {
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMItemId = req.DMItemId;
                            newBid.BidderMemberId = Provider.CurrentMember.Id;
                            newBid.BidValue = req.MaxBidValue;
                            newBid.Save();
                            newBid = new DMBid();
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMItemId = highestAutoBid.DMItemId;
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
                            newBid.DMItemId = highestAutoBid.DMItemId;
                            newBid.BidderMemberId = highestAutoBid.BidderMemberId;
                            newBid.BidValue = highestAutoBid.MaxBidValue;
                            newBid.Save();
                            newBid = new DMBid();
                            newBid.BidComments = "Automaticly bidded";
                            newBid.DMItemId = req.DMItemId;
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
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMItemId = {0} AND BidderMemberId != {1} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMItemId,Provider.CurrentMember.Id);
                if (highestAutoBid.MaxBidValue > 0 && highestAutoBid != null)
                {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from DMItem where Id = {0}", req.DMItemId);
                    if (highestAutoBid.MaxBidValue > req.BidValue) {
                        newBid.BidComments = "Automaticly bidded";
                        newBid.DMItemId = highestAutoBid.DMItemId;
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
            var auc = Provider.Database.Read<DMItem>(@"select * from DMItem where  Id = {0} And (IsDeleted is null or IsDeleted=0)", req.DMItemId);
            var isAutoBidderSet = req.MaxBidValue != 0;
            if (auc != null)
            {
                if (bid.BidValue < auc.BiggestBid)
                    throw (new Exception(Provider.TR("New bids have to be bigger")));
                else
                {
                    if (isAutoBidderSet)
                    {
                        if (req.MaxBidValue < req.BidValue)
                            throw (new Exception(Provider.TR("Auto Bidding Value has to be bigger than bid value!")));
                        if (req.MaxBidValue > auc.BuyItNowPrice)
                            throw (new Exception(Provider.TR("Auto Bidding Value has to be smaller than Buy It Now Price!")));
                    }
                    if (auc.BiggestBid == 0 && bid.BidValue >= (auc.SmallestBid))
                        throw (new Exception(Provider.TR("First bid has to be bigger then or equal to Mininmum Bid Value that is ") + auc.SmallestBid.ToString() ));

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
            else throw (new Exception(Provider.TR("There is no such auction to bid on")));

            auc.Save();
            bid.Save();
            if (isAutoBidderSet)
                AutoBidder(req, auc);

            return !String.IsNullOrEmpty(bid.BidderMemberId);
        }

        public bool AcceptBid(string id)
        {
            var bid = Provider.Database.Read<DMBid>(@"select * from DMBid where Id = {0}", id);
            
            var sql = @"select * from DMItem where Id={0} And (IsDeleted is null or IsDeleted=0)";
            var item = Provider.Database.Read<DMItem>(sql, bid.DMItemId);

            item.BuyerMemberId = bid.BidderMemberId;
            item.PaymentType = "ByBid";
            item.PaymentAmount = bid.BidValue;
            item.PaymentStatus = DMSaleStates.WaitingForPayment;
            item.Status = DMAuctionStates.Completed;
            item.Save();

            return !String.IsNullOrEmpty(bid.BidderMemberId);
        }

        public PagerResponse<DMBidderMemberInfo> GetBidsWithAuctionId(ReqGetBidsWithItemId req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        B.[Id] AS BidId,
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[BidComments],
	                        B.[InsertDate],
	                        B.[IsDeleted],
	                        M.[Id],
	                        M.[FirstName],
	                        M.[LastName],
	                        M.[UserName],
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[SellerMemberId]
                        FROM DMBid AS B
                        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
                        INNER JOIN DMAuction AS A ON A.Id = B.DMAuctionId
                        INNER JOIN DMItem AS I ON I.Id = A.DMItemId
                        WHERE B.DMAuctionId = {0} AND (A.ShowBidlist = 1 OR I.SellerMemberId = {0}) 
                        ORDER BY B.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBid AS B
                        INNER JOIN DMAuction AS A ON A.Id = B.DMAuctionId
                        INNER JOIN DMItem AS I ON I.Id = A.DMItemId
                        WHERE B.DMAuctionId = {0} AND (A.ShowBidlist = 1 OR I.SellerMemberId = {0})", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMBidderMemberInfo>();

            return new PagerResponse<DMBidderMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<DMBidderMemberInfo> BidsForMyItems(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        B.[Id] AS BidId,
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[BidComments],
	                        B.[InsertDate],
	                        B.[IsDeleted],
	                        M.[Id],
	                        M.[FirstName],
	                        M.[LastName],
	                        M.[UserName],
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[SellerMemberId]
                        FROM DMBid AS B
                        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.SellerMemberId = {0} 
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBid AS B
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.SellerMemberId = {0} AND (B.IsDeleted is null or B.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMBidderMemberInfo>();

            return new PagerResponse<DMBidderMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        public PagerResponse<ViewMyBidsForItemsInfo> MyBidsForItems(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        B.[Id],
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[InsertDate],
	                        B.[IsDeleted],
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[PlannedCloseDate],
	                        I.[BuyItNowPrice]
                        FROM DMBid AS B
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.Status = 'Open' AND B.BidderMemberId = {0}
                        ORDER BY B.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT COUNT(*) FROM DMBid AS B
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.Status = 'Open' AND B.BidderMemberId = {0}", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ViewMyBidsForItemsInfo>();

            return new PagerResponse<ViewMyBidsForItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
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


        public bool AcceptOffer(ReqAcceptOffer req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"select * from DMItem where Id={0}";
            var auc = Provider.Database.Read<DMItem>(sql, req.DMItemId);

            if (req.OfferValue < auc.BiggestBid)
                throw new APIException("You cannot offer less than the current bid ($" + auc.BiggestBid + ")");

            auc.BuyerMemberId = Provider.CurrentMember.Id;
            auc.PaymentType = "ByOffer";
            auc.PaymentAmount = req.OfferValue;
            auc.PaymentStatus = DMSaleStates.WaitingForPayment;
            auc.Status = DMAuctionStates.Completed;
            auc.Save();

            return true;
        }


        public PagerResponse<DMOfferItemMemberInfo> OffersForMyItems(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
                            -- Member Fields
                            M.[Id] AS MemberId,
                            M.[FirstName],
                            M.[LastName],
                            M.[UserName],
                            -- DMItem Fields
                            I.[Id] AS DMItemId,
                            I.[Type],
                            I.[DomainName],
                            I.[BuyItNowPrice],
                            I.[BiggestBid],
                            I.[Status],
                            O.[Id] AS DMOfferId,
                            O.[OfferValue],
                            O.[OffererMemberId],
                            O.[IsDeleted],
                            OM.[FirstName] AS OffererMemberFirstName,
                            OM.[LastName] AS OffererMemberLastName
                        FROM DMOffer AS O
                        INNER JOIN DMItem AS I ON I.Id = O.DMItemId
                        INNER JOIN Member as M ON M.Id = I.SellerMemberId
                        INNER JOIN Member as OM ON OM.Id = O.OffererMemberId
                        WHERE M.Id = {0} AND I.Status = 'Open' 
                        ORDER BY OfferValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMOffer AS O
                                    INNER JOIN DMItem AS I ON I.Id = O.DMItemId
                                    INNER JOIN Member as M ON M.Id = I.SellerMemberId
                                    WHERE M.Id = {0} AND I.Status = 'Open' AND (O.IsDeleted IS NULL OR O.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMOfferItemMemberInfo>();

            return new PagerResponse<DMOfferItemMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<DMOfferItemMemberInfo> MyOffersForItems(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
                            -- Member Fields
                            M.[Id] AS MemberId,
                            M.[FirstName],
                            M.[LastName],
                            M.[UserName],
                            -- DMItem Fields
                            I.[Id] AS DMItemId,
                            I.[Type],
                            I.[DomainName],
                            I.[BuyItNowPrice],
                            I.[BiggestBid],
                            I.[Status],
                            O.[Id] AS DMOfferId,
                            O.[OfferValue],
                            O.[OffererMemberId],
                            O.[IsDeleted],
                            OM.[FirstName] AS OffererMemberFirstName,
                            OM.[LastName] AS OffererMemberLastName
                        FROM DMOffer AS O
                        INNER JOIN DMItem AS I ON I.Id = O.DMItemId
                        INNER JOIN Member as M ON M.Id = I.SellerMemberId
                        INNER JOIN Member as OM ON OM.Id = O.OffererMemberId
                        WHERE O.OffererMemberId = {0} AND I.Status = 'Open' 
                        ORDER BY OfferValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMOffer AS O
                                    INNER JOIN DMItem AS I ON I.Id = O.DMItemId
                                    WHERE O.OffererMemberId = {0} AND I.Status = 'Open' AND (O.IsDeleted IS NULL OR O.IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMOfferItemMemberInfo>();

            return new PagerResponse<DMOfferItemMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public bool showBidsToggle(ReqBidsToggle req) {

            if (Provider.CurrentMember.Id != req.MemberId)
            {
                return false;
            }
            else 
            {
                var auc = Provider.Database.Read<DMItem>(@"select * from DMItem where Id={0}", req.DMItemId);
                if (auc.ShowBidlist)
                    auc.ShowBidlist = false;
                else
                    auc.ShowBidlist = true;
                auc.Save();
                return true;
            }
        }
        
        
        #endregion

        #region Payments & Messages

        public bool CancelPayment(string id)
        {
            throw new APIException("You cannot cancel a payment");

            //var sql = @"SELECT * FROM DMItem WHERE Id = {0}";
            //var item = Provider.Database.Read<DMItem>(sql, id);

            //if (item.InsertDate.AddDays(14) > DateTime.Now)
            //{
            //    item.Status = DMSaleStates.TimeoutForPayment;
            //    item.Save();
            //    //rethink the next line...
            //    return item.IsDeleted;
            //}
            //if (item.SellerMemberId == Provider.CurrentMember.Id)
            //    item.Status = DMSaleStates.CancelledBySeller;
            //else item.Status = DMSaleStates.CancelledByBuyer;
            //item.Delete();
            //return item == null || item.IsDeleted;
        }

        public PagerResponse<ListViewSalesInfo> PaymentsISent(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        I.Id,
	                        I.SellerMemberId,
	                        (SM.FirstName + ' ' + SM.LastName) AS SellerFullName,
	                        I.BuyerMemberId,
	                        (BM.FirstName + ' ' + BM.LastName) AS BuyerFullName,
	                        I.DomainName,
	                        I.Type,
	                        I.Ownership,
	                        I.IsVerified,
	                        I.DescriptionShort,
	                        I.IsPrivateSales,
	                        I.IsDeleted,
	                        I.PaymentAmount,
	                        I.PaymentType,
	                        I.PaymentStatus,
	                        I.PaymentDescription,
	                        I.InsertDate
                        FROM DMItem I
                        LEFT JOIN Member SM ON SM.Id = I.SellerMemberId
                        LEFT JOIN Member BM ON BM.Id = I.BuyerMemberId 
                        WHERE I.BuyerMemberId = {0} AND I.PaymentStatus = 'SuccessfullyClosed' AND (I.IsDeleted is null or I.IsDeleted=0)
                        ORDER BY I.InsertDate";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where BuyerMemberId = {0} AND PaymentStatus = 'SuccessfullyClosed' AND (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewSalesInfo>();

            return new PagerResponse<ListViewSalesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewSalesInfo> PaymentsIReceive(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        I.Id,
	                        I.SellerMemberId,
	                        (SM.FirstName + ' ' + SM.LastName) AS SellerFullName,
	                        I.BuyerMemberId,
	                        (BM.FirstName + ' ' + BM.LastName) AS BuyerFullName,
	                        I.DomainName,
	                        I.Type,
	                        I.Ownership,
	                        I.IsVerified,
	                        I.DescriptionShort,
	                        I.IsPrivateSales,
	                        I.IsDeleted,
	                        I.PaymentAmount,
	                        I.PaymentType,
	                        I.PaymentStatus,
	                        I.PaymentDescription,
	                        I.InsertDate
                        FROM DMItem I
                        LEFT JOIN Member SM ON SM.Id = I.SellerMemberId
                        LEFT JOIN Member BM ON BM.Id = I.BuyerMemberId 
                        WHERE I.SellerMemberId = {0} AND I.PaymentStatus = 'SuccessfullyClosed' AND (I.IsDeleted is null or I.IsDeleted=0)
                        ORDER BY I.InsertDate";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where SellerMemberId = {0} AND PaymentStatus = 'SuccessfullyClosed' AND (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewSalesInfo>();

            return new PagerResponse<ListViewSalesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        //Messages...
        public PagerResponse<ListViewDMMessagesInfo> GetInbox(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
			                        THEN M.Subject ELSE PDM.Subject END AS Subject,
                                CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
       		                        THEN M.Body ELSE PDM.Body END AS Body,
                                M.SenderMemberId,
                                (FM.FirstName + ' ' + FM.Lastname) AS SenderMemberFullName,
                                FM.Avatar AS SenderMemberIdAvatar,
                                M.ToMemberId,
                                (TM.FirstName + ' ' + TM.Lastname) AS ToMemberFullname,
                                TM.Avatar AS ToMemberAvatar,
                                M.Id,
                                M.IsDeleted,
                                M.InsertDate
                        FROM DMMessage AS M
                        INNER JOIN Member AS FM ON M.SenderMemberId = FM.Id
                        INNER JOIN Member AS TM ON M.TomemberId = TM.Id
                        LEFT JOIN DMPredefinedMessage AS PDM ON M.DMPredefinedMessageId = PDM.Id
                        WHERE M.ToMemberId = {0} 
                        ORDER BY M.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMMessage where ToMemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewDMMessagesInfo>();

            return new PagerResponse<ListViewDMMessagesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewDMMessagesInfo> GetSentMessage(ReqPager req)
        {
            ///////////////////////////////////////////////////////////////////////
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
			                        THEN M.Subject ELSE PDM.Subject END AS Subject,
                                CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
       		                        THEN M.Body ELSE PDM.Body END AS Body,
                                M.SenderMemberId,
                                (FM.FirstName + ' ' + FM.Lastname) AS SenderMemberFullname,
                                FM.Avatar AS SenderMemberAvatar,
                                M.ToMemberId,
                                (TM.FirstName + ' ' + TM.Lastname) AS ToMemberFullname,
                                TM.Avatar AS ToMemberAvatar,
                                M.Id,
                                M.IsDeleted,
                                M.InsertDate
                        FROM DMMessage AS M
                        INNER JOIN Member AS FM ON M.SenderMemberId = FM.Id
                        INNER JOIN Member AS TM ON M.TomemberId = TM.Id
                        LEFT JOIN DMPredefinedMessage AS PDM ON M.DMPredefinedMessageId = PDM.Id
                        WHERE SenderMemberId = {0} 
                        ORDER BY M.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber-1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMMessage where SenderMemberId = {0} and (IsDeleted is null or IsDeleted=0)", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewDMMessagesInfo>();

            return new PagerResponse<ListViewDMMessagesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public List<ListDMPredefinedMessageInfo> GetDMPredefinedMessages(ReqEmpty req)
        {
            return Provider.Database.ReadList<DMPredefinedMessage>("select * from DMPredefinedMessage").ToEntityInfo<ListDMPredefinedMessageInfo>();
        }

        public bool SendMessage(ReqSendDMMessage req)
        {
            var dmmessage = new DMMessage();
            dmmessage.CopyPropertiesWithSameName(req);

            // ensure that users are using pdm to send messages to each other.
            if (!string.IsNullOrEmpty(dmmessage.DMPredefinedMessageId))
                dmmessage.Body = dmmessage.Subject = "";
            
            dmmessage.Save();
            return dmmessage.Id.Length > 0;
        }







        #endregion

    }
}