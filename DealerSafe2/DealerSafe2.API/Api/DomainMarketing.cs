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
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied.");

            var watch = new DMWatchList();
            if (Provider.Database.Read<DMWatchList>(@"select * from DMWatchList where DmItemId = {0} and MemberId = {1} and IsDeleted = 0 ", id, Provider.CurrentMember.Id) != null)
                throw new APIException("Cannot add to watchlist twice!");

            watch.DMItemId = id;
            watch.MemberId = Provider.CurrentMember.Id;
            watch.Save();
            return true;
        }

        public bool RemoveFromWatchList(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied.");

            var sql = @"select * from DMWatchList where MemberId = {0} and DMItemId = {1}";
            var watch = Provider.Database.Read<DMWatchList>(sql, Provider.CurrentMember.Id, id);
            if (watch == null) throw new APIException("Already removed from favorites.");

            return Provider.Database.ExecuteNonQuery("delete from DMWatchList where Id = {0}", watch.Id) > 0;
        }

        public bool IsOnMyWatchList(string id)
        {
            return Provider.Database.GetBool("select 1 from DMWatchList where DMItemId = {0} and MemberId = {1} and IsDeleted = 0", id, Provider.CurrentMember.Id);
        }

        public PagerResponse<ListViewDMWatchListItemInfo> GetMyWatchList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT W.Id,
                               W.DmItemId,
                               W.InsertDate,
                               I.DomainName,
                               I.Status,
                               I.StatusReason,
                               I.Type,
                               I.IsPrivateSale,
                               I.Ownership
                        FROM DMWatchList AS W
                        LEFT JOIN DMItem AS I ON W.DMItemId = I.Id
                        WHERE W.MemberId = {0}
                        ORDER BY W.InsertDate, I.Status desc";

            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMWatchList where MemberId = {0}", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewDMWatchListItemInfo>();

            return new PagerResponse<ListViewDMWatchListItemInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ViewDMBrowseItemInfo> GetMyBrowseList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT 
                            B.DMItemId,
                            B.InsertDate,
                            I.DomainName,
                            I.Status,
                            I.StatusReason,
                            I.Type,
                            I.IsPrivateSale,
                            I.Ownership
                        FROM DMBrowse AS B
                        INNER JOIN DMItem AS I ON B.DMItemId = I.Id 
                        ORDER BY B.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBrowse where MemberId = {0}", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ViewDMBrowseItemInfo>();

            return new PagerResponse<ViewDMBrowseItemInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        #endregion

        #region Member Comment / Rating

        public bool CreateComment(ReqComment req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");

            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied.");

            var comment = new EntityComment();
            comment.EntityName = "Member";

            // validation
            if (req.ToMemberId == Provider.CurrentMember.Id)
                throw new APIException("You cannot comment to yourself!");
            if (req.Rating > 5 || req.Rating == 0 || req.Rating < -5)
                throw new APIException("Invalid Rating.");



            comment.EntityId = req.ToMemberId;
            // Multiply with 100 to set precision to 0.01
            comment.Rating = req.Rating * 100;
            comment.Comment = req.Comment;
            comment.MemberId = Provider.CurrentMember.Id;
            comment.IsDeleted = false;
            comment.Save();

            //update user rating
            var newRating = Provider.Database.GetInt(@"select AVG(Rating) from EntityComment where EntityName = {0} AND EntityId = {1}", "Member", req.ToMemberId);
            var member = Provider.Database.Read<Member>(@"select * from Member where id= {0}", req.ToMemberId);
            member.Rating = newRating;
            member.Save();

            return !String.IsNullOrEmpty(comment.Id);
        }

        public PagerResponse<EntityCommentInfo> GetMyComments(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.MemberId = {0} AND EC.IsDeleted = 0 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.MemberId = {0} AND EC.IsDeleted = 0 ", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<EntityCommentInfo> GetMyComplaints(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.MemberId = {0} AND EC.IsDeleted = 0 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.MemberId = {0} AND EC.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        #endregion

        #region Expertise & Brokerage

        public bool AskForExpertise(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied.");

            var expertise = new DMExpertise();
            expertise.RequesterMemberId = Provider.CurrentMember.Id;
            expertise.Status = DMExpertiseStates.Open;
            expertise.DMItemId = id;
            expertise.Insert();

            return !String.IsNullOrEmpty(expertise.Id);
        }

        public bool ToggleExpertisePublic(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            var expertise = Provider.Database.Read<DMExpertise>("select * from DMExpertise where Id = {0}", id);
            expertise.IsPublic = !expertise.IsPublic;
            expertise.Save();
            return expertise.IsPublic;
        }

        public PagerResponse<DMExpertiseInfo> GetMyExpertiseRequests(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        LEFT JOIN Member M on M.Id = E.ExpertMemberId
                        WHERE E.RequesterMemberId = {0} and E.IsDeleted = 0 
                        ORDER BY E.InsertDate, E.Status DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMExpertise AS E WHERE E.RequesterMemberId = {0} and E.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMExpertiseInfo>();

            return new PagerResponse<DMExpertiseInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        // There might be more than 1 report for an item
        public List<DMExpertiseInfo> GetExpertiseReports(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE E.RequesterMemberId = {0} and E.DMItemId = {1} AND E.Status = {2} AND E.IsDeleted = 0 
                        ORDER BY E.InsertDate, E.Status DESC";
            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id, id, DMExpertiseStates.Processed.ToString())
                .ToEntityList<DMExpertiseInfo>();
            return res;
        }


        public bool AskForBrokerage(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            var brokerage = new DMBrokerage();
            brokerage.RequesterMemberId = Provider.CurrentMember.Id;
            brokerage.Status = DMBrokerageStates.Open;
            brokerage.DMItemId = id;
            brokerage.Insert();

            return !String.IsNullOrEmpty(brokerage.Id);
        }

        public PagerResponse<DMBrokerageInfo> GetMyBrokerageRequests(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE B.RequesterMemberId = {0} AND B.IsDeleted = 0 
                        ORDER BY B.InsertDate, B.Status DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBrokerage B WHERE B.RequesterMemberId = {0} AND B.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMBrokerageInfo>();

            return new PagerResponse<DMBrokerageInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public DMBrokerageInfo GetBrokerageReports(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE B.RequesterMemberId = {0} AND B.IsDeleted = 0 AND B.DMItemId = {1} AND B.Status = {2}
                        ORDER BY B.InsertDate, B.Status DESC";
            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id, id, DMBrokerageStates.Processed.ToString())
                .ToEntityList<DMBrokerageInfo>().FirstOrDefault();
            return res;
        }

        #endregion

        #region ProfileInfo

        public PagerResponse<EntityCommentInfo> GetProfileComplaints(ReqGetProfileComplaints req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.EntityId = {0} AND EC.IsDeleted = 0 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating < 0 AND EC.EntityId = {0} AND EC.IsDeleted = 0 ", req.MemberId);

            var res = Provider.Database.GetDataTable(sql, req.MemberId).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<EntityCommentInfo> GetProfileComments(ReqGetProfileComplaints req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                            EC.InsertDate
                        FROM EntityComment AS EC 
                        INNER JOIN Member F ON EC.MemberId = F.Id
                        INNER JOIN Member M ON EC.EntityId = M.Id
                        WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.EntityId = {0} AND EC.IsDeleted = 0 
                        ORDER BY EC.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM EntityComment AS EC WHERE EC.EntityName = 'Member' AND EC.Rating > 0 AND EC.EntityId = {0} AND EC.IsDeleted = 0", req.MemberId);

            var res = Provider.Database.GetDataTable(sql, req.MemberId).ToEntityList<EntityCommentInfo>();

            return new PagerResponse<EntityCommentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewSalesInfo> GetProfileSales(ReqGetProfileComplaints req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
	                        I.PaymentAmount,
	                        I.PaymentType,
	                        I.PaymentStatus,
	                        I.StatusReason,
	                        I.PaymentDescription,
	                        I.InsertDate
                        FROM DMItem I
                        LEFT JOIN Member SM ON SM.Id = I.SellerMemberId
                        LEFT JOIN Member BM ON BM.Id = I.BuyerMemberId 
                        WHERE I.SellerMemberId = {0} 
                            AND I.PaymentStatus = 'SuccessfullyClosed' 
                            AND I.IsPrivateSale = 0 
                            AND I.IsDeleted = 0 
                            ORDER BY I.InsertDate, I.PaymentStatus DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) 
                        FROM DMItem
                        WHERE SellerMemberId = {0} 
                            AND PaymentStatus = 'SuccessfullyClosed' 
                            AND IsPrivateSale = 0 
                            AND IsDeleted = 0 ", req.MemberId);

            var res = Provider.Database.GetDataTable(sql, req.MemberId).ToEntityList<ListViewSalesInfo>();

            return new PagerResponse<ListViewSalesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public DMMemberInfo GetDMProfileInfo(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
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

        #region Search & Sharing

        public PagerResponse<ResGetSearchResults> GetSearchResults(ReqSearchAuction req)
        {
            if (req == null)
                return new PagerResponse<ResGetSearchResults>();
            //set defaults
            if (req.Type == null) req.Type = "Any";

            var sql = @"SELECT 
                            I.Id,
                        -- DMItem Fields
	                        I.[SellerMemberId],
	                        I.[Type],
	                        I.[DomainName],
	                        C.[Name] AS CategoryName,
	                        I.[BuyItNowPrice],
	                        I.[BiggestBid],
	                        L.[Name] as [Language],
	                        I.[DescriptionShort],
	                        I.[PageRank],
	                        I.[StartDate],
	                        I.[PlannedCloseDate],
	                        I.[Status]
                        FROM DMItem I
                        INNER JOIN DMCategory AS C ON C.Id = I.DMCategoryId
                        INNER JOIN [Language] L on L.Id = I.LanguageId ";
            var where = @" WHERE I.IsDeleted = 0 AND COALESCE(I.IsPrivateSale, 0) = 0 AND I.Status IN ('Open', 'NotOnAuction')
                            AND I.BiggestBid >= {0} AND I.BuyItNowPrice >= {0}
                            AND ({1} = 0 OR I.BiggestBid < {1} OR I.BuyItNowPrice < {1})
                            AND I.Type LIKE {2}
                            AND SUBSTRING ( I.DomainName ,0 , CHARINDEX ( '.' , I.DomainName )) LIKE {3}
                            AND SUBSTRING ( I.DomainName ,0 , CHARINDEX ( '.' , I.DomainName )) LIKE {4} 
                            AND I.DomainName LIKE {6}
                            AND I.DomainName LIKE {5}";
            var orderBy = " ORDER BY I.[BuyItNowPrice], I.[DomainName]";
            sql += where + orderBy;
            var countSql = "select count(*) from DMItem I " + where;
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            //extention check, sql:
            //AND (SUBSTRING ( I.DomainName ,CHARINDEX ( '.' , I.DomainName ), LEN(I.DomainName)) = {6})
            var paramss = new Object[]{req.MinPrice,
                    req.MaxPrice,
                    req.Type == "Any" ? "%" : req.Type,
                    req.StartsWith + "%",
                    "%" + req.EndsWith,
                    "%" + req.Including + "%",
                    "%" + req.Extension};
            var itemsInPage = Provider.Database.GetDataTable(sql, paramss).ToEntityList<ResGetSearchResults>();
            var count = Provider.Database.GetInt(countSql, paramss);
            var res = new PagerResponse<ResGetSearchResults>() { ItemsInPage = itemsInPage, NumberOfItemsInTotal = count };
            return res;
        }

        public List<string> GetDMItemExtensions(ReqEmpty req)
        {
            return Provider.Database.GetStringList("select distinct SUBSTRING ( DomainName ,CHARINDEX ( '.' , DomainName ), LEN(DomainName)) from DMItem");
        }

        public List<DMFaqInfo> GetDMFaqSearchResults(string keyword)
        {
            var searchIncludingKeyword = "%" + (keyword ?? "") + "%";
            return Provider.Database.ReadList<DMFaq>("select * from DMFaq where Question LIKE {0} OR Answer LIKE {1}", searchIncludingKeyword, searchIncludingKeyword).ToEntityInfo<DMFaqInfo>();
        }

        public bool RecommendItem(ReqShareItem req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (string.IsNullOrEmpty(req.DMItemId) || !Provider.Database.GetBool("select 1 from DMItem where id = {0}", req.DMItemId))
                throw new APIException("No such item.");

            var reqMail = new ReqSendMessage()
            {
                Email = req.ToEmail,
                AddSubject = "New Message From " + Provider.CurrentMember.FullName,
                AddMessage = req.Message,
                SendDate = DateTime.Now,
                TemplateId = "" // TODO: set the proper id
            };

            return Provider.Api.SendMessage(reqMail); ;
        }

        #endregion

        #region Auctions
        public ViewAuctionInfo GetAuction(string req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            var sql = @"select  I.Id,
                                I.IsDeleted,
                                I.InsertDate,
                                I.Type,
                                I.SellerMemberId,
                                (M.FirstName + ' ' + M.LastName) AS SellerFullName,
                                I.DomainName,
                                I.BuyItNowPrice,
                                I.DMCategoryId,
                                C.Name AS CategoryName,
                                I.LanguageId,
                                L.Name AS Language,
                                I.DescriptionShort,
                                I.DescriptionLong,
                                I.ExpiryDate,
                                I.EnableDomainParking,
                                I.VisibleInAdNetwork,
                                I.PageRank,
                                I.Ownership,
                                I.VerificationAsked,
                                I.IsVerified,
                                I.Analytics,
                                I.AdSense,
                                I.Alexa,
                                I.Status,
                                I.StatusReason,
                                I.StartDate,
                                I.PlannedCloseDate,
                                I.Comments
                        FROM DMItem I
                        INNER JOIN Member AS M ON M.Id = I.SellerMemberId
                        INNER JOIN DMCategory AS C ON C.Id = I.DMCategoryId
                        INNER JOIN [Language] L on L.Id = I.LanguageId
                        where I.Id = {0} AND I.IsPrivateSale = 0 OR I.SellerMemberId = {1}";
            return Provider.Database.GetDataTable(sql, req, Provider.CurrentMember.Id).ToEntityList<ViewAuctionInfo>().FirstOrDefault();
        }

        public bool SaveAuction(ReqAuction req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var item = Provider.Database.Read<DMItem>(@"select * from DMItem where Id={0}", req.Id);
            if (item == null)
                throw new APIException("No such auction.");
            if (item.IsPrivateSale)
                throw new APIException("This item is private, remove from private items to create an auction.");

            if (item.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You cannot create or edit auctions from somebody else's item.");
            if (req.MinimumBidInterval < 10)
                throw new APIException("Minimum bid interval has to be bigger than 9.");
            if (req.MinimumBidPrice <= 0)
                throw new APIException("Minimum bid interval has to be bigger than 0.");
            if (req.BuyItNowPrice <= req.MinimumBidPrice + req.MinimumBidInterval)
                throw new APIException("Buy it now price has to be higher than the minimum placeable bid.");
            if (req.PlannedCloseDate <= DateTime.Now.AddDays(1))
                throw new APIException("Planned close date of auction should be at least 1 day later.");

            if (item.Status == DMAuctionStates.Open && item.BiggestBid > 0)
                throw new APIException("There are bids on this auction! Auction cannot be editted.");
            if (item.Status != DMAuctionStates.NotOnAuction)
                throw new APIException("Cannot create auction! Because it was already on auction.");

            req.CopyPropertiesWithSameName(item);

            item.Status = DMAuctionStates.Open;
            item.StartDate = DateTime.Now;
            item.BiggestBid = 0;
            item.Save();

            return !string.IsNullOrEmpty(item.Id);
        }

        public bool DeleteAuction(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"select * from DMItem where Id = {0} AND IsDeleted = 0";
            var item = Provider.Database.Read<DMItem>(sql, id);

            if (item == null)
                throw new APIException("No such auction.");
            if (item.BiggestBid > 0)
                throw new APIException("There are bids on this auction, thus it cannot be deleted!");
            if (item.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You cannot delete other's auctions.");
            if (item.PaymentStatus == DMSaleStates.TimeoutForPayment || item.PaymentStatus == DMSaleStates.CancelledByBuyer 
                || (item.Status == DMAuctionStates.Cancelled && item.StatusReason == DMAuctionStateReasons.DueDate))
                Provider.Database.ExecuteNonQuery("delete from DMBid where DMItemId = {0}", item.Id);
            else throw new APIException("Cannot remove auction.");

            item.Status = DMAuctionStates.NotOnAuction;
            item.Save();
            return true;
        }


        public PagerResponse<ListViewAuctionsInfo> GetOpenAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE IsDeleted = 0 AND Status = 'Open'
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where IsDeleted = 0 AND Status = 'Open'");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        public PagerResponse<ListViewAuctionsInfo> GetHotAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        AND IsDeleted = 0 AND Status = 'Open'
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                                WHERE StartDate >= DATEADD(day, -1, GETDATE())
                                AND IsDeleted = 0 AND Status = 'Open'");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        public PagerResponse<ListViewAuctionsInfo> GetHighestBiddedAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        WHERE IsDeleted = 0 AND Status = 'Open'
                        ORDER BY BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where IsDeleted = 0 AND Status = 'Open'");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }
        public PagerResponse<ListViewAuctionsInfo> GetNoBiddedAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        AND I.IsDeleted = 0
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"
                SELECT count(*) FROM DMItem
                WHERE (BiggestBid = 0 or BiggestBid IS NULL) 
                AND IsDeleted = 0 AND Status = 'Open'");

            var res = Provider.Database.GetDataTable(sql).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetExpiredAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        AND I.IsDeleted = 0
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = 20;

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetClosedAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        AND I.IsDeleted = 0
                        ORDER BY I.BiggestBid DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"
                        SELECT count(*) FROM DMItem I
                        WHERE I.Status = 'Closed' AND I.SellerMemberId={0}
                        AND I.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetWaitingPaymentAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        AND IsDeleted = 0
                        ORDER BY InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                        WHERE PaymentStatus = 'WaitingForPayment' AND SellerMemberId={0}
                        AND IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewAuctionsInfo> GetWaitingTransferAuctionsList(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        AND IsDeleted = 0
                        ORDER BY InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                        WHERE PaymentStatus = 'WaitingForTransfer' AND SellerMemberId={0}
                        AND IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewAuctionsInfo>();

            return new PagerResponse<ListViewAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        public PagerResponse<ListViewItemsInfo> GetItems(ReqPager req)
        {
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
	                        StatusReason,
	                        SellerMemberId,
                            IsPrivateSale,
	                        IsDeleted,
	                        InsertDate
                        FROM DMItem
                        WHERE SellerMemberId = {0} AND IsDeleted = 0
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where SellerMemberId = {0} and IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewItemsInfo>();

            return new PagerResponse<ListViewItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewItemsInfo> GetPrivateItems(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                            StatusReason,
	                        SellerMemberId,
	                        IsDeleted,
	                        InsertDate
                        FROM DMItem
                        WHERE SellerMemberId = {0} AND IsDeleted = 0 AND IsPrivateSale = 1
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where SellerMemberId = {0} and IsDeleted = 0 AND IsPrivateSale = 1", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewItemsInfo>();

            return new PagerResponse<ListViewItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewItemsInfo> GetMyItemsOnAuction(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                            StatusReason,
	                        SellerMemberId,
	                        IsDeleted,
	                        InsertDate
                        FROM DMItem
                        WHERE SellerMemberId = {0}
                            AND Status = 'Open'
                            AND IsDeleted = 0
                        ORDER BY StartDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem
                        WHERE SellerMemberId = {0} AND IsDeleted = 0 AND Status = 'Open'", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewItemsInfo>();

            return new PagerResponse<ListViewItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<WaitingPaymentInfo> AuctionsWaitingPayment(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                            I.StatusReason,
                            M.FirstName,
                            M.LastName
                        FROM DMItem AS I
                        INNER JOIN Member as M ON M.Id = I.BuyerMemberId
                        WHERE I.SellerMemberId = {0} 
                            AND I.PaymentStatus = 'WaitingForPayment' 
                            AND IsDeleted = 0";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT COUNT(*) FROM DMItem WHERE SellerMemberId = {0} AND PaymentStatus = 'WaitingForPayment' AND IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<WaitingPaymentInfo>();

            return new PagerResponse<WaitingPaymentInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public List<IdName> GetMyItemsNameIdNotOnAuction(ReqEmpty req)
        {
            var sql = @"select Id, DomainName from DMItem where Status = {0} and SellerMemberId = {1}";
            return Provider.Database.ReadList<DMItem>(sql, DMAuctionStates.NotOnAuction.ToString(), Provider.CurrentMember.Id).Select(item => new IdName() { Id = item.Id, Name = item.DomainName }).ToList();
        }

        public PagerResponse<ListViewWonAuctionsInfo> AuctionsIWon(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        I.Id,
	                        I.DomainName,
	                        I.Type,
	                        I.StartDate,
	                        I.ActualCloseDate AS CloseDate,
	                        I.BuyItNowPrice,
	                        I.PaymentAmount,
	                        I.BuyerMemberId,
	                        I.PaymentStatus
                        FROM DMItem AS I
                        INNER JOIN Member as M ON M.Id = I.BuyerMemberId
                        WHERE I.BuyerMemberId = {0} AND I.IsDeleted = 0 ORDER BY I.InsertDate DESC, I.PaymentStatus DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT COUNT(*) FROM DMItem WHERE BuyerMemberId = {0} AND IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewWonAuctionsInfo>();

            return new PagerResponse<ListViewWonAuctionsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        #endregion

        #region Items

        public List<IdName> GetItemCategoryList(ReqEmpty req)
        {
            return Provider.Database.ReadList<DMCategory>(@"select Id, Name from DMCategory where IsDeleted = 0 order by OrderNo, Name")
                .Select(x => new IdName { Id = x.Id, Name = x.Name }).ToList();
        }

        public List<string> GetItemTypesList(ReqEmpty req)
        {
            return Enum.GetNames(typeof(DMItemTypes)).ToList();
        }

        public bool CreatePrivateSales(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (string.IsNullOrEmpty(Provider.CurrentMember.Id))
                throw new APIException("Access denied.");

            var item = Provider.Database.Read<DMItem>("select * from DMItem where Id = {0}", id);
            item.IsPrivateSale = true;
            item.Save();
            return true;
        }
        public bool RemoveFromPrivateSales(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (string.IsNullOrEmpty(Provider.CurrentMember.Id))
                throw new APIException("Access denied.");

            var item = Provider.Database.Read<DMItem>("select * from DMItem where Id = {0}", id);
            item.IsPrivateSale = false;
            item.Save();
            return true;
        }
        public List<IdName> GetMyItemsIdNotOnSale(ReqEmpty req)
        {
            var sql = "select Id, DomainName from DMItem where Status = {0} and SellerMemberId = {1} and IsDeleted = 0 and IsPrivateSale = 0 ";
            return Provider.Database.ReadList<DMItem>(sql, DMAuctionStates.NotOnAuction.ToString(), Provider.CurrentMember.Id)
                .Select(x => new IdName() { Id = x.Id, Name = x.DomainName }).ToList();
        }

        public List<IdName> GetLanguageList(ReqEmpty req)
        {
            return Provider.Database.ReadList<Language>(@"select Id, Name from Language where IsDeleted = 0 order by OrderNo, Name")
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
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (string.IsNullOrEmpty(Provider.CurrentMember.Id))
                throw new APIException("Access denied.");

            var sql = @"select * from DMItem where IsDeleted = 0 and Id = {0} and SellerMemberId = {1}";
            return Provider.Database.Read<DMItem>(sql, id, Provider.CurrentMember.Id).ToEntityInfo<DMItemInfo>();
        }

        public DMItemInfo GetItem(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");

            var sql = @"SELECT 
	                        (M.FirstName + ' ' + M.LastName) AS SellerFullName,
                            C.Name as CategoryName,
                            L.Name as Language,
	                        I.*
                        FROM DMItem AS I 
                        INNER JOIN Member AS M ON M.Id = I.SellerMemberId
                        LEFT JOIN DMCategory AS C ON C.Id = I.DMCategoryId
                        LEFT JOIN Language AS L ON L.Id = I.LanguageId
                        WHERE I.IsDeleted = 0 AND I.Id = {0}";
            var item = Provider.Database.GetDataTable(sql, id).ToEntityList<DMItemInfo>().FirstOrDefault();
            if (item != null && !Provider.CurrentMember.Id.IsEmpty())
                Provider.Database.ExecuteNonQuery("insert into DMBrowse( MemberId, DMItemId, InsertDate ) values ({0}, {1}, {2})", Provider.CurrentMember.Id, id, DateTime.Now);
            return item;
        }

        public List<IdName> GetDomainBlackList(ReqEmpty req)
        {
            var sql = @"select * from DMBlackList where IsDeleted = 0";
            return Provider.Database.ReadList<DMBlackList>(sql, Provider.CurrentMember.Id).ToEntityInfo<IdName>();
        }

        public bool SaveMyItem(ReqDMSaveItem req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (string.IsNullOrEmpty(Provider.CurrentMember.Id))
                throw new APIException("Access denied.");

            //TODO: check if user is saving his own item?
            DMItem item = Provider.Database.Read<DMItem>("select * from DMItem where Id = {0}", req.Id);
            if (item != null && item.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You cannot edit somebody else's item!");
            else item = new DMItem();

            if (this.GetDomainBlackList(new ReqEmpty()).Where(x => x.Name == req.DomainName).Count() > 0)
                throw new APIException(string.Format("Domain name is in blacklist. It cannot be {0}", req.DomainName));


            req.CopyPropertiesWithSameName(item);
            item.SellerMemberId = Provider.CurrentMember.Id;
            item.DomainRegistrar = getDomainRegistrarWith(req.DomainName);
            item.DomainRegistrationDate = getDomainRegistrationDateWith(req.DomainName);

            //if new record
            if (item.BiggestBid == 0)
            {
                item.Status = DMAuctionStates.NotOnAuction;
                item.PaymentStatus = DMSaleStates.None;
            }

            item.Save();

            return !String.IsNullOrEmpty(item.Id);
        }

        public bool DeleteMyItem(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var x = Provider.Database.Read<DMItem>(@"select * from DMItem where IsDeleted = 0 and Id = {0} order by Type, DomainName", id);
            if (x.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You cannot delete auctions that are not yours!");
            if (x.Status == DMAuctionStates.Open && x.BiggestBid > 0)
                throw new APIException("This item has an auction with bids. It cannot be deleted!");
            if (x.PaymentStatus == DMSaleStates.WaitingForPayment || x.PaymentStatus == DMSaleStates.WaitingForTransfer)
                throw new APIException("This item has an unstable payment status, wait until it is resolved!");

            x.Delete();
            return true;
        }

        #endregion

        #region Biddings & Offers

        public ResponseDMAuctionBidDetails GetBidInfoForAuction(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = "select Id, BiggestBid, MinimumBidPrice, MinimumBidInterval, DomainName, BuyItNowPrice from DMItem where Id = {0}";
            var item = Provider.Database.GetDataTable(sql, id).ToEntityList<ResponseDMAuctionBidDetails>().FirstOrDefault();

            return item;
        }

        public DMBidderMemberInfo GetBid(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        B.[Id],
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[BidComments],
	                        B.[InsertDate],
	                        M.[FirstName] AS BidderFirstName,
                            M.[LastName] AS BidderLastName,
                            M.[UserName] AS BidderUserName,
                            I.[Id] AS DMItemId,
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[SellerMemberId]
                        FROM DMBid AS B
                        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE B.Id = {0} AND B.IsDeleted = 0";
            var res = Provider.Database.GetDataTable(sql, id).ToEntityList<DMBidderMemberInfo>().FirstOrDefault();
            if (res == null)
                throw new APIException("No such bid.");
            if (res.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You are not the seller of this auction! Access denied.");

            return res;
        }

        private void AutoBidder(ReqBid req, DMItem auction)
        {

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


                if (highestAutoBid.MaxBidValue > 0 && highestAutoBid != null)
                {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from DMItem where Id = {0}", req.DMItemId);

                    if (auction.BiggestBid < highestAutoBid.MaxBidValue)
                    {

                        if (highestAutoBid.MaxBidValue > req.MaxBidValue)
                        {
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
            else if (req.MaxBidValue == 0)
            {//if autobidding value was not set then we are going to check if there is an autobid which has a bigger maxautobidvalue than our current bid value
                var highestAutoBid = Provider.Database.Read<DMAutoBidder>(@"select * from DMAutoBidder where DMItemId = {0} AND BidderMemberId != {1} order by MaxBidValue desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", req.DMItemId, Provider.CurrentMember.Id);
                if (highestAutoBid.MaxBidValue > 0 && highestAutoBid != null)
                {
                    var minBidInt = Provider.Database.GetInt(@"select MinimumBidInterval from DMItem where Id = {0}", req.DMItemId);
                    if (highestAutoBid.MaxBidValue > req.BidValue)
                    {
                        newBid.BidComments = "Automaticly bidded";
                        newBid.DMItemId = highestAutoBid.DMItemId;
                        newBid.BidderMemberId = highestAutoBid.BidderMemberId;
                        newBid.BidValue = req.BidValue + minBidInt;
                        newBid.Save();
                        auction.BiggestBid = newBid.BidValue;
                        auction.Save();
                    }
                    else if (highestAutoBid.MaxBidValue <= req.BidValue)
                    {//
                        //Do nothing
                    }
                }
            }

        }

        public bool SaveBid(ReqBid req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            DMBid bid = new DMBid();
            bid.BidderMemberId = Provider.CurrentMember.Id;
            req.CopyPropertiesWithSameName(bid);

            var item = Provider.Database.Read<DMItem>(@"select * from DMItem where  Id = {0} and Status = {1} and IsDeleted = 0", req.DMItemId, DMAuctionStates.Open.ToString());
            if (item == null) throw new APIException("Auction is closed or there is no such auction."); 
            
            var minimumPossible = (item.BiggestBid == 0 ? item.MinimumBidPrice : item.BiggestBid) + item.MinimumBidInterval;
            var isAutoBidderSet = req.MaxBidValue != 0;

            if (bid.BidValue < minimumPossible)
                return false;
            if (isAutoBidderSet && req.MaxBidValue < req.BidValue)
                throw new APIException("Auto Bidding Value has to be bigger than bid value!");
            if (isAutoBidderSet && req.MaxBidValue > item.BuyItNowPrice)
                throw new APIException("Auto Bidding Value has to be smaller than Buy It Now Price!");
            if (item.SellerMemberId == Provider.CurrentMember.Id)
                throw new APIException("You cannot bid on your own item.");

            var latestBidByCurrentMember = Provider.Database.Read<DMBid>("select TOP 1 * from DMBid where BidderMemberId = {0} and DMItemId = {1} order by BidValue desc", Provider.CurrentMember.Id, bid.DMItemId);
            if (latestBidByCurrentMember != null && latestBidByCurrentMember.BidValue == item.BiggestBid)
                throw new APIException("You have already made a bid.");

            //In compliance with page 24...
            if (bid.BidValue >= item.BuyItNowPrice)
            {
                bid.BidValue = item.BuyItNowPrice;
                bid.Save();

                // accept bid
                acceptBidAndSetItemWithoutValidation(bid, item);
            }
            item.BiggestBid = bid.BidValue;

            item.Save();
            bid.Save();
            if (isAutoBidderSet)
                AutoBidder(req, item);

            return !String.IsNullOrEmpty(bid.Id);
        }

        public bool AcceptBid(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var bid = Provider.Database.Read<DMBid>("select * from DMBid where Id = {0}", id);

            if (bid.BidderMemberId == Provider.CurrentMember.Id)
                throw new APIException("You cannot declare yourself as the winner.");

            var sql = "select * from DMItem where Id = {0} And IsDeleted = 0";
            var item = Provider.Database.Read<DMItem>(sql, bid.DMItemId);

            if (item.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You cannot accept bid if you are not the owner!");
            if (item.Status != DMAuctionStates.Open)
                throw new APIException("This auction is not open! Cannot accept the bid.");


            acceptBidAndSetItemWithoutValidation(bid, item);

            item.Save();
            return !String.IsNullOrEmpty(bid.Id);
        }

        private static void acceptBidAndSetItemWithoutValidation(DMBid bid, DMItem item)
        {
            item.BuyerMemberId = bid.BidderMemberId;
            item.PaymentAmount = bid.BidValue;
            item.PaymentStatus = DMSaleStates.WaitingForPayment;
            item.Status = DMAuctionStates.Completed;
            item.StatusReason = DMAuctionStateReasons.Bid;
            item.ActualCloseDate = DateTime.Now;
        }

        public PagerResponse<DMBidderMemberInfo> GetBidsWithAuctionId(ReqGetBidsWithItemId req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        B.[Id],
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[BidComments],
	                        B.[InsertDate],
	                        M.[FirstName] AS BidderFirstName,
                            M.[LastName] AS BidderLastName,
                            M.[UserName] AS BidderUserName,
                            I.[Id] AS DMItemId,
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[SellerMemberId]
                        FROM DMBid AS B
                        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE B.DMItemId = {0} AND I.IsDeleted <> 1
                        ORDER BY B.InsertDate DESC, B.BidValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBid AS B
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE B.DMItemId = {0} AND I.IsDeleted <> 1", req.DMItemId, Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, req.DMItemId, Provider.CurrentMember.Id).ToEntityList<DMBidderMemberInfo>();

            return new PagerResponse<DMBidderMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<DMBidderMemberInfo> BidsForMyItems(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT
	                        B.[Id],
	                        B.[BidderMemberId],
	                        B.[BidValue],
	                        B.[BidComments],
	                        B.[InsertDate],
	                        M.[FirstName] AS BidderFirstName,
                            M.[LastName] AS BidderLastName,
                            M.[UserName] AS BidderUserName,
                            I.[Id] AS DMItemId,
	                        I.[DomainName],
	                        I.[Type],
	                        I.[BiggestBid],
	                        I.[SellerMemberId]
                        FROM DMBid AS B
                        INNER JOIN Member AS M ON M.Id = B.BidderMemberId
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.SellerMemberId = {0} 
                        ORDER BY I.BiggestBid DESC, B.BidValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMBid AS B
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.SellerMemberId = {0} AND B.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMBidderMemberInfo>();

            return new PagerResponse<DMBidderMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ViewMyBidsForItemsInfo> MyBidsForItems(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        ORDER BY B.InsertDate DESC, B.BidValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT COUNT(*) FROM DMBid AS B
                        INNER JOIN DMItem AS I ON I.Id = B.DMItemId
                        WHERE I.Status = 'Open' AND B.BidderMemberId = {0}", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ViewMyBidsForItemsInfo>();

            return new PagerResponse<ViewMyBidsForItemsInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        public bool SaveOffer(ReqOffer req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            DMOffer offer = new DMOffer();
            req.CopyPropertiesWithSameName(offer);
            offer.OffererMemberId = Provider.CurrentMember.Id;

            var item = Provider.Database.Read<DMItem>(@"select * from DMItem where  Id = {0} and Status = {1} and IsDeleted = 0", req.DMItemId, DMAuctionStates.Open.ToString());

            if (item == null)
                throw new APIException("Auction is closed or there is no such auction.");
            var minimumPossible = (item.BiggestBid == 0 ? item.MinimumBidPrice : item.BiggestBid) + item.MinimumBidInterval;
            if (offer.OfferValue < minimumPossible)
                throw new APIException(string.Format("New offers have to be bigger than {0}", minimumPossible));
            if (item.SellerMemberId == Provider.CurrentMember.Id)
                throw new APIException("You cannot offer on your own item.");

            var latestOfferByCurrentMember = Provider.Database.Read<DMOffer>("select TOP 1 * from DMOffer where OffererMemberId = {0} and DMItemId = {1} and Status = {2} order by OfferValue desc", Provider.CurrentMember.Id, offer.DMItemId, DMOfferStatus.None);
            if (latestOfferByCurrentMember != null) throw new APIException("You have already made an offer.");

            offer.Save();

            return !String.IsNullOrEmpty(offer.Id);
        }

        public bool AcceptOffer(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = "select * from DMItem where Id={0}";
            var offer = Provider.Database.Read<DMOffer>("select * from DMOffer where Id = {0}", id);
            var item = Provider.Database.Read<DMItem>(sql, offer.DMItemId);

            if (item.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("You cannot accept other's offers.");
            if (offer.OfferValue < item.BiggestBid)
                throw new APIException(string.Format("You cannot offer less than the current bid {0}", item.BiggestBid));

            item.BuyerMemberId = offer.OffererMemberId;
            item.PaymentAmount = offer.OfferValue;
            item.PaymentStatus = DMSaleStates.WaitingForPayment;
            item.Status = DMAuctionStates.Completed;
            item.StatusReason = DMAuctionStateReasons.Offer;
            item.ActualCloseDate = DateTime.Now;
            item.Save();

            offer.Status = DMOfferStatus.Accepted;
            offer.ReviewedAt = DateTime.Now;
            offer.Save();

            return true;
        }

        public bool GetPaymentForItem(ReqPaymentInfo req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            // check if item is still available for #buyitnow
            var item = Provider.Database.Read<DMItem>(
                "select * from DMItem where Id = {0} and PaymentStatus = {1}",
                req.Id, DMSaleStates.None.ToString());
            if (item == null)
                throw new APIException("No such item is on sale.");

            //if (item.PaymentStatus != DMSaleStates.None)
            //    throw new APIException("Cannot buy item. It was either cancelled or bought by somebody else.");
            if (item.SellerMemberId == Provider.CurrentMember.Id)
                throw new APIException("You cannot buy your own item.");

            if (item.Status == DMAuctionStates.Cancelled || item.Status == DMAuctionStates.Suspended)
                throw new APIException("Canceled or Suspended items cannot be sold");
            if (item.Status == DMAuctionStates.Completed)
                throw new APIException("Payment for this item has already been completed. Please contact your customer representative.");

            // if withdrawal was made continue...
            // TODO: send the item as parameter as well
            var paymentRes = makeWithdrawal(req);
            if (!paymentRes.IsEmpty())
                throw new APIException(paymentRes);

            // set items status
            item.Status = DMAuctionStates.Completed;

            item.PaymentStatus = DMSaleStates.WaitingForTransfer;
            item.StatusReason = DMAuctionStateReasons.BuyItNow;
            item.BuyerMemberId = Provider.CurrentMember.Id;
            item.PaymentAmount = item.BuyItNowPrice;
            item.ActualCloseDate = Provider.Database.Now;
            item.PaymentType = "Credit Card";
            item.PaymentDate = DateTime.Now;
            item.PaymentDescription = req.PaymentDescription;
            item.Save();

            return true;
        }

        private string makeWithdrawal(ReqPaymentInfo req)
        {
            return "";
        }



        public PagerResponse<DMOfferItemMemberInfo> OffersForMyItems(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                            O.[Id],
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
                        ORDER BY O.OfferValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMOffer AS O
                                    INNER JOIN DMItem AS I ON I.Id = O.DMItemId
                                    INNER JOIN Member as M ON M.Id = I.SellerMemberId
                                    WHERE M.Id = {0} AND I.Status = 'Open' AND O.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMOfferItemMemberInfo>();

            return new PagerResponse<DMOfferItemMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<DMOfferItemMemberInfo> MyOffersForItems(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
                        ORDER BY O.OfferValue DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMOffer AS O
                                    INNER JOIN DMItem AS I ON I.Id = O.DMItemId
                                    WHERE O.OffererMemberId = {0} AND I.Status = 'Open' AND O.IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<DMOfferItemMemberInfo>();

            return new PagerResponse<DMOfferItemMemberInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        #endregion

        #region Payments & Messages

        public bool CancelPayment(string id)
        {
            if (id == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT * FROM DMItem WHERE Id = {0}";
            var item = Provider.Database.Read<DMItem>(sql, id);

            if (item.BuyerMemberId != Provider.CurrentMember.Id && item.SellerMemberId != Provider.CurrentMember.Id)
                throw new APIException("Cannot cancel payment that does not belong to you.");

            item.Status = DMAuctionStates.Cancelled;
            if (item.SellerMemberId == Provider.CurrentMember.Id)
                item.PaymentStatus = DMSaleStates.CancelledBySeller;
            else item.PaymentStatus = DMSaleStates.CancelledByBuyer;
            item.Save();
            return true;
        }

        public PagerResponse<ListViewSalesInfo> PaymentsISent(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
	                        I.IsPrivateSale,
	                        I.IsDeleted,
	                        I.PaymentAmount,
	                        I.PaymentType,
	                        I.PaymentStatus,
	                        I.StatusReason,
	                        I.PaymentDate,
	                        I.PaymentDescription,
	                        I.InsertDate
                        FROM DMItem I
                        LEFT JOIN Member SM ON SM.Id = I.SellerMemberId
                        LEFT JOIN Member BM ON BM.Id = I.BuyerMemberId 
                        WHERE I.BuyerMemberId = {0} AND I.IsDeleted = 0
                        AND (I.PaymentStatus = 'SuccessfullyClosed' OR I.PaymentStatus = 'WaitingForTransfer')
                        ORDER BY I.InsertDate";

            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where BuyerMemberId = {0} AND (PaymentStatus = 'SuccessfullyClosed' OR PaymentStatus = 'WaitingForTransfer') AND IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewSalesInfo>();

            return new PagerResponse<ListViewSalesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewSalesInfo> PaymentsIReceive(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
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
	                        I.IsPrivateSale,
	                        I.IsDeleted,
	                        I.PaymentAmount,
	                        I.PaymentType,
	                        I.StatusReason,
	                        I.PaymentStatus,
	                        I.PaymentDate,
	                        I.PaymentDescription,
	                        I.InsertDate
                        FROM DMItem I
                        LEFT JOIN Member SM ON SM.Id = I.SellerMemberId
                        LEFT JOIN Member BM ON BM.Id = I.BuyerMemberId 
                        WHERE I.SellerMemberId = {0} AND I.IsDeleted = 0
                        AND (I.PaymentStatus = 'SuccessfullyClosed' OR I.PaymentStatus = 'WaitingForTransfer')
                        ORDER BY I.InsertDate";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMItem where SellerMemberId = {0} AND (PaymentStatus = 'SuccessfullyClosed' OR PaymentStatus = 'WaitingForTransfer') AND IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewSalesInfo>();

            return new PagerResponse<ListViewSalesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }


        //Messages...
        public PagerResponse<ListViewDMMessagesInfo> GetInbox(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
			                        THEN M.Subject ELSE PDM.Subject END AS Subject,
                                CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
       		                        THEN M.Body ELSE PDM.Body END AS Body,
                                M.SenderMemberId,
                                (FM.FirstName + ' ' + FM.Lastname) AS SenderMemberFullName,
                                FM.Avatar AS SenderMemberAvatar,
                                M.ToMemberId,
                                (TM.FirstName + ' ' + TM.Lastname) AS ToMemberFullName,
                                TM.Avatar AS ToMemberAvatar,
                                M.Id,
                                M.InsertDate
                        FROM DMMessage AS M
                        INNER JOIN Member AS FM ON M.SenderMemberId = FM.Id
                        INNER JOIN Member AS TM ON M.ToMemberId = TM.Id
                        LEFT JOIN DMPredefinedMessage AS PDM ON M.DMPredefinedMessageId = PDM.Id
                        WHERE M.ToMemberId = {0} 
                        ORDER BY M.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMMessage where ToMemberId = {0} and IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewDMMessagesInfo>();

            return new PagerResponse<ListViewDMMessagesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public PagerResponse<ListViewDMMessagesInfo> GetSentMessage(ReqPager req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            var sql = @"SELECT CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
			                        THEN M.Subject ELSE PDM.Subject END AS Subject,
                                CASE WHEN M.DMPredefinedMessageId IS NULL OR M.DMPredefinedMessageId = '' 
       		                        THEN M.Body ELSE PDM.Body END AS Body,
                                M.SenderMemberId,
                                (FM.FirstName + ' ' + FM.Lastname) AS SenderMemberFullName,
                                FM.Avatar AS SenderMemberAvatar,
                                M.ToMemberId,
                                (TM.FirstName + ' ' + TM.Lastname) AS ToMemberFullName,
                                TM.Avatar AS ToMemberAvatar,
                                M.Id,
                                M.InsertDate
                        FROM DMMessage AS M
                        INNER JOIN Member AS FM ON M.SenderMemberId = FM.Id
                        INNER JOIN Member AS TM ON M.TomemberId = TM.Id
                        LEFT JOIN DMPredefinedMessage AS PDM ON M.DMPredefinedMessageId = PDM.Id
                        WHERE M.SenderMemberId = {0} 
                        ORDER BY M.InsertDate DESC";
            sql = Provider.Database.AddPagingToSQL(sql, req.PageSize, req.PageNumber - 1);
            var totalCount = Provider.Database.GetInt(@"SELECT count(*) FROM DMMessage where SenderMemberId = {0} and IsDeleted = 0", Provider.CurrentMember.Id);

            var res = Provider.Database.GetDataTable(sql, Provider.CurrentMember.Id).ToEntityList<ListViewDMMessagesInfo>();

            return new PagerResponse<ListViewDMMessagesInfo> { ItemsInPage = res, NumberOfItemsInTotal = totalCount };
        }

        public List<ListDMPredefinedMessageInfo> GetDMPredefinedMessages(ReqEmpty req)
        {
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");

            return Provider.Database.ReadList<DMPredefinedMessage>("select * from DMPredefinedMessage").ToEntityInfo<ListDMPredefinedMessageInfo>();
        }

        public bool SendDMMessage(ReqSendDMMessage req)
        {
            if (req == null)
                throw new APIException("Parameter null. Access denied");
            if (Provider.CurrentMember.Id.IsEmpty())
                throw new APIException("Access denied");
            if (Provider.CurrentMember.Id == req.ToMemberId)
                throw new APIException("You cannot send message to yourself!");

            var dmmessage = new DMMessage();
            req.CopyPropertiesWithSameName(dmmessage);
            dmmessage.SenderMemberId = Provider.CurrentMember.Id;

            // ensure that users are using pdm to send messages to each other.
            if (!string.IsNullOrEmpty(dmmessage.DMPredefinedMessageId))
                dmmessage.Body = dmmessage.Subject = "";

            dmmessage.Save();
            return dmmessage.Id.Length > 0;
        }







        #endregion
    }
}