using System.Globalization;
using System.Reflection;
using System.Web;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.EntityInfo.Jobs;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using Facebook;
using MemberInfo = DealerSafe2.DTO.EntityInfo.MemberInfo;
using DealerSafe2.DTO.EntityInfo.Crm;
using DealerSafe2.DTO.EntityInfo.Products.Domain;
using DealerSafe2.DTO.EntityInfo.Products.SSL;
using DealerSafe2.DTO.EntityInfo.DomainMarketing;

namespace DealerSafe2.DTO.ServiceClient
{
    public class DealerSafeAPI : BaseAPI, System2.IAPIProvider
    {
        #region Common

        public string GetAPIVersion()
        {
            return "1.0";
        }

        public List<IdName> GetEnumList(string enumName)
        {
            return Call<List<IdName>, string>(enumName, MethodBase.GetCurrentMethod().Name);
        }

        public bool ExecuteJob(string jobId)
        {
            return Call<bool, string>(jobId, MethodBase.GetCurrentMethod().Name);
        }

        public ExchangeRates GetExchangeRates(ReqEmpty req)
        {
            return Call<ExchangeRates, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SendMessage(ReqSendMessage req)
        {
            return Call<bool, ReqSendMessage>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Membership

        #region MemberAddress

        public List<MemberAddressInfo> GetMemberAddressList(ReqEmpty req)
        {
            return Call<List<MemberAddressInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public MemberAddressInfo GetMemberAddress(string id)
        {
            return Call<MemberAddressInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public MemberAddressInfo SaveMemberAddress(MemberAddressInfo req)
        {
            return Call<MemberAddressInfo, MemberAddressInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool DeleteMemberAddress(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public List<IdName> GetCountryList(ReqEmpty req)
        {
            return Call<List<IdName>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<IdName> GetStateList(string countryId)
        {
            return Call<List<IdName>, string>(countryId, MethodBase.GetCurrentMethod().Name);
        }

        public List<IdName> GetCityList(ReqGetCityList req)
        {
            return Call<List<IdName>, ReqGetCityList>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<IdName> GetDistrictList(string cityId)
        {
            return Call<List<IdName>, string>(cityId, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Newsletter

        public List<NewsletterDefinitionInfo> GetNewsletterList(ReqEmpty req)
        {
            return Call<List<NewsletterDefinitionInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<string> GetMemberNewsletters(ReqEmpty req)
        {
            return Call<List<string>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool DeleteMemberNewsLetter(string newsletterDefinitionId)
        {
            return Call<bool, string>(newsletterDefinitionId, MethodBase.GetCurrentMethod().Name);
        }

        public bool AddMemberNewsletter(string newsletterDefinitionId)
        {
            return Call<bool, string>(newsletterDefinitionId, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Login

        public ResLogin Login(ReqLogin req)
        {
            var res = Call<ResLogin, ReqLogin>(req, MethodBase.GetCurrentMethod().Name);
            HttpContext.Current.Session["Member"] = res.Member;
            this.SessionId = res.SessionId;
            return res;
        }

        public bool Logout(ReqEmpty req)
        {
            var res = Call<bool, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
            this.SessionId = null;
            HttpContext.Current.Session["Member"] = null;
            HttpContext.Current.Session["Order"] = null;
            return res;
        }

        #endregion

        #region Member

        public MemberInfo GetMemberInfo(ReqEmpty req)
        {
            var res = Call<MemberInfo, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
            HttpContext.Current.Session["Member"] = res;
            return res;
        }

        public bool SaveProfileInfo(ProfileInfo req)
        {
            return Call<bool, ProfileInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        public ProfileInfo GetProfileInfo(ReqEmpty req)
        {
            return Call<ProfileInfo, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool ChangeMemberPassword(ReqChangeMemberPassword req)
        {
            return Call<bool, ReqChangeMemberPassword>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool ChangeMemberEmail(ReqChangeMemberEmail req)
        {
            return Call<bool, ReqChangeMemberEmail>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool ConfirmEmailChange(string keyword)
        {
            var res = Call<bool, string>(keyword, MethodBase.GetCurrentMethod().Name);
            if (res)
                GetMemberInfo(null);
            return res;
        }

        public ResLogin QuickSignUp(ReqQuickSignUp req)
        {
            var res = Call<ResLogin, ReqQuickSignUp>(req, MethodBase.GetCurrentMethod().Name);
            this.SessionId = res.SessionId;
            HttpContext.Current.Session["Member"] = res.Member;
            return res;
        }

        public ResLogin LoginWithFacebook(ReqLoginWithFacebook req)
        {
            var accessToken = HttpContext.Current.Request["accessToken"];
            HttpContext.Current.Session["AccessToken"] = accessToken;

            var client = new FacebookClient(accessToken);
            dynamic result = client.Get("me", new {fields = "id,name,email,gender,first_name,last_name,picture"});

            req = new ReqLoginWithFacebook()
            {
                FacebookId = result.id,
                Name = result.first_name,
                Surname = result.last_name,
                Avatar = result.picture.data.url,
                Email = result.email,
                Nick = result.username,
                Gender = result.gender == "male" ? "M" : "F"
            };

            var res = Call<ResLogin, ReqLoginWithFacebook>(req, MethodBase.GetCurrentMethod().Name);
            this.SessionId = res.SessionId;
            HttpContext.Current.Session["Member"] = res.Member;
            return res;
        }

        public bool MemberExists(string email)
        {
            return Call<bool, string>(email, MethodBase.GetCurrentMethod().Name);
        }

        public ResGetDashboard GetDashboard(ReqEmpty req)
        {
            return Call<ResGetDashboard, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SendPasswordRecoveryMessage(string email)
        {
            return Call<bool, string>(email, MethodBase.GetCurrentMethod().Name);
        }

        public bool SendConfirmationMessage(ReqEmpty req)
        {
            return Call<bool, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool ChangeForgottenPassword(ReqChangeForgottenPassword req)
        {
            return Call<bool, ReqChangeForgottenPassword>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region SMS

        public bool VerifyPhoneNumber(ReqVerifyPhoneNumber feedback)
        {
            return Call<bool, ReqVerifyPhoneNumber>(feedback, MethodBase.GetCurrentMethod().Name);
        }

        public bool VerifyPhoneNumberSendSms(string phoneNumber)
        {
            return Call<bool, string>(phoneNumber, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Mail

        public bool TestEmailAddress(ReqEmpty req)
        {
            return Call<bool, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }
        public bool AddSecondEmailAddress(string secondEmail)
        {
            return Call<bool, string>(secondEmail, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #endregion

        #region Order

        #region Product

        public List<ProductInfo> GetProductListWithPropertyAndPrices(string ids)
        {
            return Call<List<ProductInfo>, string>(ids, MethodBase.GetCurrentMethod().Name);
        }

        public List<ProductInfo> GetProductListWithProductType(string productType)
        {
            //throw new Exception("Iam here");

            return Call<List<ProductInfo>, string>(productType, MethodBase.GetCurrentMethod().Name);
        }

        public ProductInfo GetProductWithDetails(string id)
        {
            return Call<ProductInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Basket

        public List<MemberAddressInfo> GetCheckoutAddressList(string req)
        {
            return Call<List<MemberAddressInfo>, string>(req, MethodBase.GetCurrentMethod().Name);
        }

        public MemberInfo SaveCheckoutAddressInfo(MemberAddressInfo req)
        {
            var res = Call<MemberInfo, MemberAddressInfo>(req, MethodBase.GetCurrentMethod().Name);
            HttpContext.Current.Session["Member"] = res;
            return res;
        }

        public OrderInfo GetMemberBasket(ReqEmpty req)
        {
            return Call<OrderInfo, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public OrderInfo AddToOrder(OrderItemInfo orderItem)
        {
            return Call<OrderInfo, OrderItemInfo>(orderItem, MethodBase.GetCurrentMethod().Name);
        }

        public OrderInfo RemoveFromOrder(string orderItemId)
        {
            return Call<OrderInfo, string>(orderItemId, MethodBase.GetCurrentMethod().Name);
        }

        public OrderInfo RemoveAllFromOrder(ReqEmpty req)
        {
            return Call<OrderInfo, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public OrderInfo ApplyCouponCode(string code)
        {
            return Call<OrderInfo, string>(code, MethodBase.GetCurrentMethod().Name);
        }

        public OrderInfo RemoveCouponCode(ReqEmpty req)
        {
            return Call<OrderInfo, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Order

        public OrderInfo CreateOrderFromBasket(string hash)
        {
            return Call<OrderInfo, string>(hash, MethodBase.GetCurrentMethod().Name);
        }

        public List<OrderInfo> GetOrderList(ReqEmpty req)
        {
            return Call<List<OrderInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public OrderInfo GetMemberOrder(string orderId)
        {
            return Call<OrderInfo, string>(orderId, MethodBase.GetCurrentMethod().Name);
        }

        public bool CancelOrderItem(ReqCancelOrderItem req)
        {
            return Call<bool, ReqCancelOrderItem>(req, MethodBase.GetCurrentMethod().Name);
        }

        public OrderItemInfo GetOrderItem(string orderItemId)
        {
            return Call<OrderItemInfo, string>(orderItemId, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #endregion

        #region SignSec

        public List<ListViewMemberSSLInfo> GetMemberSSLList(ReqEmpty req)
        {
            return Call<List<ListViewMemberSSLInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public ResCheckCRCCode CheckCRCCode(string req)
        {
            return Call<ResCheckCRCCode, string>(req, MethodBase.GetCurrentMethod().Name);
        }

        public ResSSLChecker SSLCheckDomain(string domainName)
        {
            return Call<ResSSLChecker, string>(domainName, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Verilen CSR'ı çözerek okunabilir hale getirir
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ResDecodeCSR DecodeCSR(ReqDecodeCSR req)
        {
            return Call<ResDecodeCSR, ReqDecodeCSR>(req, MethodBase.GetCurrentMethod().Name);
        }

        public ResSSLCertificateInfo DecodeCertificate(string certificate)
        {
            return Call<ResSSLCertificateInfo, string>(certificate, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// SSL sertifikasını ve bilgilerini getirir
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public ResCollectSSL CollectSSL(string orderItemId)
        {
            return Call<ResCollectSSL, string>(orderItemId, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Verilan domain için doğrulama yapılabilinecek e-posta adresi listesini verir
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public List<string> GetDVEmailAddressList(string domainName)
        {
            return Call<List<string>, string>(domainName, MethodBase.GetCurrentMethod().Name);
        }

        public bool SaveMemberSSLInfo(MemberSSLInfo req)
        {
            return Call<bool, MemberSSLInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// SSL sertifikası üretir
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MemberSSLInfo GenerateSSL(MemberSSLInfo req)
        {
            return Call<MemberSSLInfo, MemberSSLInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        public MemberSSLInfo GetMemberSSL(string memberSSLId)
        {
            return Call<MemberSSLInfo, string>(memberSSLId, MethodBase.GetCurrentMethod().Name);
        }

        public string GetLastMemberSSLId(ReqEmpty req)
        {
            return Call<string, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public ResConvertCertificate ConvertCertificate(ReqConvertCertificate req)
        {
            return Call<ResConvertCertificate, ReqConvertCertificate>(req, MethodBase.GetCurrentMethod().Name);
        }

        public ResCertificateKeyMatcher CertificateMatch(ReqCertificateKeyMatcher req)
        {
            return Call<ResCertificateKeyMatcher, ReqCertificateKeyMatcher>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Reseller

        public List<ResellerTypeInfo> GetResellerTypes(ReqEmpty req)
        {
            return Call<List<ResellerTypeInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool ApplyForResellership(ReqApplyForResellership req)
        {
            return Call<bool, ReqApplyForResellership>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool ApplyForMdf(string mdfId)
        {
            return Call<bool, string>(mdfId, MethodBase.GetCurrentMethod().Name);
        }

        public List<MdfResellerInfo> GetMdfList(ReqEmpty req)
        {
            return Call<List<MdfResellerInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public MdfInfo GetMdf(string mdfId)
        {
            return Call<MdfInfo, string>(mdfId, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Crm

        public bool SaveFeedback(FeedbackInfo feedback)
        {
            return Call<bool, FeedbackInfo>(feedback, MethodBase.GetCurrentMethod().Name);
        }

        public bool SaveCrmActivity(CrmActivityInfo req)
        {
            return Call<bool, CrmActivityInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SaveCrmActivityMessage(CrmActivityMessageInfo req)
        {
            return Call<bool, CrmActivityMessageInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<CrmActivityInfo> GetCrmActivities(ReqEmpty req)
        {
            return Call<List<CrmActivityInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<CrmActivityMessageInfo> GetCrmActivityMessages(string crmActivityId)
        {
            return Call<List<CrmActivityMessageInfo>, string>(crmActivityId, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Domain

        public List<ListViewMemberDomainInfo> GetMemberDomainList(ReqEmpty req)
        {
            return Call<List<ListViewMemberDomainInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public string SaveMemberDomain(MemberDomainInfo req)
        {
            return Call<string, MemberDomainInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region DomainMarketing

        #region WatchList & Browse


        public bool RemoveFromWatchList(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        
        public bool AddToWatchList(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        
        public PagerResponse<ListViewDMWatchListItemInfo> GetMyWatchList(ReqPager req)
        {
            return Call<PagerResponse<ListViewDMWatchListItemInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        
        public PagerResponse<ViewDMBrowseItemInfo> GetMyBrowseList(ReqPager req)
        {
            return Call<PagerResponse<ViewDMBrowseItemInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }


        #endregion

        #region Member Comment / Rating

        public bool CreateComment(ReqComment req) {
            return Call<bool, ReqComment>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<EntityCommentInfo> GetMyComments(ReqPager req)
        {
            return Call<PagerResponse<EntityCommentInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<EntityCommentInfo> GetMyComplaints(ReqPager req)
        {
            return Call<PagerResponse<EntityCommentInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Expertise & Brokerage

        public bool AskForExpertise(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        public bool ToggleExpertisePublic(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<DMExpertiseInfo> GetMyExpertiseRequests(ReqPager req)
        {
            return Call<PagerResponse<DMExpertiseInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<DMExpertiseInfo> GetExpertiseReports(string id)
        {
            return Call<List<DMExpertiseInfo>, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public bool AskForBrokerage(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<DMBrokerageInfo> GetMyBrokerageRequests(ReqPager req)
        {
            return Call<PagerResponse<DMBrokerageInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public DMBrokerageInfo GetBrokerageReports(string id)
        {
            return Call<DMBrokerageInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Profile Info

        public DMMemberInfo GetDMProfileInfo(string id)
        {
            return Call<DMMemberInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<EntityCommentInfo> GetProfileComplaints(ReqPager req)
        {
            return Call<PagerResponse<EntityCommentInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<EntityCommentInfo> GetProfileComments(ReqPager req)
        {
            return Call<PagerResponse<EntityCommentInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewSalesInfo> GetProfileSales(ReqPager req)
        {
            return Call<PagerResponse<ListViewSalesInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }


        #endregion

        #region Search & Sharing

        public List<DMItemInfo> GetSearchResults(ReqSearchAuction req)
        {
            return Call<List<DMItemInfo>, ReqSearchAuction>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<string> GetDMItemExtensions(ReqEmpty req)
        {
            return Call<List<string>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<DMFaqInfo> GetDMFaqSearchResults(string keyword)
        {
            return Call<List<DMFaqInfo>, string>(keyword, MethodBase.GetCurrentMethod().Name);
        }

        public bool RecommendItem(ReqShareItem req)
        {
            return Call<bool, ReqShareItem>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Auctions

        public ViewAuctionInfo GetAuction(string req)
        {
            return Call<ViewAuctionInfo, string>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SaveAuction(ReqAuction req)
        {
            return Call<bool, ReqAuction>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool DeleteAuction(string id) 
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewAuctionsInfo> GetOpenAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewAuctionsInfo> GetHotAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewAuctionsInfo> GetHighestBiddedAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewAuctionsInfo> GetNoBiddedAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<ListViewAuctionsInfo> GetExpiredAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<ListViewAuctionsInfo> GetClosedAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<ListViewAuctionsInfo> GetWaitingPaymentAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<ListViewAuctionsInfo> GetWaitingTransferAuctionsList(ReqPager req)
        {
            return Call<PagerResponse<ListViewAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewItemsInfo> GetItems(ReqPager req)
        {
            return Call<PagerResponse<ListViewItemsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewItemsInfo> GetPrivateItems(ReqPager req)
        {
            return Call<PagerResponse<ListViewItemsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<WaitingPaymentInfo> AuctionsWaitingPayment(ReqPager req)
        {
            return Call<PagerResponse<WaitingPaymentInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }


        public List<IdName> GetMyItemsNameIdNotOnAuction(ReqEmpty req)
        {
            return Call<List<IdName>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewWonAuctionsInfo> AuctionsIWon(ReqPager req)
        {
            return Call<PagerResponse<ListViewWonAuctionsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Items

        public List<IdName> GetItemCategoryList(ReqEmpty req)
        {
            return Call<List<IdName>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<IdName> GetLanguageList(ReqEmpty req)
        {
            return Call<List<IdName>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<string> GetItemTypesList(ReqEmpty req)
        {
            return Call<List<string>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }
        
        public PagerResponse<ListViewItemsInfo> GetMyItemsOnAuction(ReqPager req)
        {
            return Call<PagerResponse<ListViewItemsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }   

        public List<IdName> GetDomainBlackList(ReqEmpty req)
        {
            return Call<List<IdName>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public DMItemInfo GetMyItem(string id)
        {
            return Call<DMItemInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public DMItemInfo GetItem(string id)
        {
            return Call<DMItemInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        
        public bool CreatePrivateSales(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        public bool RemoveFromPrivateSales(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        
        public List<IdName> GetMyItemsIdNotOnSale(ReqEmpty req)
        {
            return Call<List<IdName>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SaveMyItem(ReqDMSaveItem req)
        {
            return Call<bool, ReqDMSaveItem>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool DeleteMyItem(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #region Bids & Offers

        public ResponseDMAuctionBidDetails GetBidInfoForAuction(string id)
        {
            return Call<ResponseDMAuctionBidDetails, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public DMBidderMemberInfo GetBid(string id)
        {
            return Call<DMBidderMemberInfo, string>(id, MethodBase.GetCurrentMethod().Name);
        }

        public bool AcceptBid(string req) 
        {
            return Call<bool, string>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SaveBid(ReqBid req)
        {
            return Call<bool, ReqBid>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool GetPaymentForItem(ReqPaymentInfo req)
        {
            return Call<bool, ReqPaymentInfo>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<DMBidderMemberInfo> GetBidsWithAuctionId(ReqGetBidsWithItemId req)
        {
            return Call<PagerResponse<DMBidderMemberInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<DMBidderMemberInfo> BidsForMyItems(ReqPager req)
        {
            return Call<PagerResponse<DMBidderMemberInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ViewMyBidsForItemsInfo> MyBidsForItems(ReqPager req)
        {
            return Call<PagerResponse<ViewMyBidsForItemsInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        

        public bool SaveOffer(ReqOffer req)
        {
            return Call<bool, ReqOffer>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool AcceptOffer(ReqAcceptOffer id)
        {
            return Call<bool, ReqAcceptOffer>(id, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<DMOfferItemMemberInfo> OffersForMyItems(ReqPager req)
        {
            return Call<PagerResponse<DMOfferItemMemberInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<DMOfferItemMemberInfo> MyOffersForItems(ReqPager req)
        {
            return Call<PagerResponse<DMOfferItemMemberInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        //public bool showBidsToggle(string id) 
        //{
        //    return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        //}

        #endregion


        #region Payments & Messages


        public bool CancelPayment(string id)
        {
            return Call<bool, string>(id, MethodBase.GetCurrentMethod().Name);
        }
        public PagerResponse<ListViewSalesInfo> PaymentsISent(ReqPager req)
        {
            return Call<PagerResponse<ListViewSalesInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewSalesInfo> PaymentsIReceive(ReqPager req)
        {
            return Call<PagerResponse<ListViewSalesInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public List<ListDMPredefinedMessageInfo> GetDMPredefinedMessages(ReqEmpty req)
        {
            return Call<List<ListDMPredefinedMessageInfo>, ReqEmpty>(req, MethodBase.GetCurrentMethod().Name);
        }

        public bool SendDMMessage(ReqSendDMMessage req)
        {
            return Call<bool, ReqSendDMMessage>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewDMMessagesInfo> GetSentMessage(ReqPager req)
        {
            return Call<PagerResponse<ListViewDMMessagesInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        public PagerResponse<ListViewDMMessagesInfo> GetInbox(ReqPager req)
        {
            return Call<PagerResponse<ListViewDMMessagesInfo>, ReqPager>(req, MethodBase.GetCurrentMethod().Name);
        }

        #endregion

        #endregion

        public override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["DealerSafe2ServiceURL"];
        }

        public object CallWebAPIMethod(string method)
        {

            if (string.IsNullOrWhiteSpace(method))
                throw new Exception("Service request method needed");

            MethodInfo mi = this.GetType().GetMethod(method);

            if (mi == null)
                throw new Exception("There is no service method with the name " + method);

            Type t = mi.GetParameters()[0].ParameterType;

            object param = Deserialize(HttpContext.Current.Request.Form["data"], t);

            //if (t == typeof (string))
            //    param = HttpContext.Current.Request.Form[mi.GetParameters()[0].Name];
            //else if (t.IsValueType)
            //    param = HttpContext.Current.Request.Form[mi.GetParameters()[0].Name].ChangeType(t);
            //else
            //{
            //    param = Activator.CreateInstance(t);
            //    (param as ISetFieldsByPostData).SetFieldsByPostData();
            //}

            object res = mi.Invoke(this, new object[] {param});

            return res;
        }

        public MemberInfo Member
        {
            get
            {
                if (HttpContext.Current.Session["Member"] != null)
                    return (MemberInfo) HttpContext.Current.Session["Member"];


                return new MemberInfo() {Id = "", UserName = "Anonim"};
            }
            set { HttpContext.Current.Session["Member"] = value; }
        }
    }
}

namespace System2
{
    public interface IAPIProvider
    {
    }

    public static class UtilityDTO
    {
        public static T ChangeType<T>(this object value, CultureInfo culture = null)
        {
            return (T) ChangeType(value, typeof (T), culture);
        }

        public static object ChangeType(this object value, Type conversion, CultureInfo culture = null)
        {
            if (culture == null) culture = CultureInfo.CurrentCulture;

            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof (Nullable<>)))
            {
                if (value == null || value == DBNull.Value)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            if (value == DBNull.Value)
                return t.GetDefault();

            if (t.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(t, value.ToString());
                else if (value.IsNumeric())
                    return Enum.ToObject(t, (int) value);
            }

            return Convert.ChangeType(value, t);
        }

        public static object GetDefault(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        public static bool IsNumeric(this object o)
        {
            if (o is IConvertible)
            {
                TypeCode tc = ((IConvertible) o).GetTypeCode();
                if (TypeCode.Char <= tc && tc <= TypeCode.Decimal)
                    return true;
            }
            return false;
        }

        public static bool IsNumeric(this Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
                    {
                        return IsNumeric(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string[] SplitWithTrim(this string str, char seperator)
        {
            string[] res = str.Split(new char[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < res.Length; i++)
                res[i] = res[i].Trim();
            return res;
        }
        public static string[] SplitWithTrim(this string str, string seperator)
        {
            string[] res = str.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < res.Length; i++)
                res[i] = res[i].Trim();
            return res;
        }
        public static string[] SplitWithTrim(this string str, string seperator, params char[] trimChars)
        {
            string[] res = str.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < res.Length; i++)
                res[i] = res[i].Trim(trimChars);
            return res;
        }
    }
}
