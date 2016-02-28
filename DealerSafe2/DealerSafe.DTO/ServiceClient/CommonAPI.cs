

using System;
using System.Web;
using DealerSafe.DTO.Dashboard;
using DealerSafe.DTO.Domain;
using DealerSafe.DTO.Enums;
using DealerSafe.DTO.Hosting;
using DealerSafe.DTO.Support;

namespace DealerSafe.ServiceClient
{
    using DTO.Common;
    using System.Configuration;
    using System.ComponentModel;
    using System.Collections.Generic;
    using DealerSafe.DTO;
    using DealerSafe.DTO.Common.FTP;

    public class CommonAPI : BaseAPI
    {
        public CommonAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public CommonAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        [Description("Get blog ress")]
        public List<DealerSafe.DTO.Common.BlogRss> GetBlogRssList(ReqBlogRss request)
        {
            return Call<List<DealerSafe.DTO.Common.BlogRss>, ReqBlogRss>(request, "GetBlogRssList");
        }
        
        [Description("Get domain news for mobile")]
        public List<DomainNewsInfo> GetDomainNewsList(ReqGetDomainNewsList request)
        {
            return Call<List<DomainNewsInfo>, ReqGetDomainNewsList>(request, "GetDomainNewsList");
        }

        [Description("Get domain news insert time less than 72 hour for mobile")]
        public List<DomainNewsInfo> GetDomainNewsListLessThan72Hour()
        {
            return Call<List<DomainNewsInfo>, ReqEmpty>(new ReqEmpty(), "GetDomainNewsListLessThan72Hour");
        }

        [Description("Send SMS of the member")]
        public SendSMSInfo SendSMS(ReqSendSMS request)
        {
            return Call<SendSMSInfo, ReqSendSMS>(request, "SendSMS");
        }
        [Description("Send Hosting Price/Campaign")]
        public HostingTwinPrice GetHostingPrice(int ProductId)
        {
            return Call<HostingTwinPrice, int>(ProductId, "GetHostingPrice");
        }

        [Description("Send Mail of the Member")]
        public bool SendMail(ReqSendMail req)
        {
            return Call<bool, ReqSendMail>(req, "SendMail");
        }

        [Description("Returns the ads for main page bottom")]
        public List<MainBottomBoxInfo> GetMainPageAds()
        {
            return Call<List<MainBottomBoxInfo>, ReqEmpty>(new ReqEmpty(), "GetMainPageAds");
        }

        [Description("Returns all the banners for Basket, MainRight and MainBottom")]
        public List<FrontBannerInfo> GetBanners()
        {

            return Call<List<FrontBannerInfo>, ReqEmpty>(new ReqEmpty(), "GetBanners");
        }

        [Description("Returns version number in date format")]
        public int GetVersion()
        {
            return Call<int, ReqEmpty>(new ReqEmpty(), "GetVersion");
        }

        [Description("Country y IP Address")]
        public IP2CountryInfo IP2Country(ReqIP2Country request)
        {
            return Call<IP2CountryInfo, ReqIP2Country>(request, "IP2Country");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["CommonServiceURL"];
        }

        [Description("Get Campaign By Name")]
        public CampaignTo GetCampaignByName(string name)
        {
            return Call<CampaignTo, string>(name, "GetCampaignByName");
        }

        [Description("Is this member in org mouse pad campaign already")]
        public bool IsMemberAlreadyExistInOrgMousePad(int memberId)
        {
            return Call<bool, int>(memberId, "IsMemberAlreadyExistInOrgMousePad");
        }

        [Description("Get MousePadOrg by MemberId")]
        public OrgMousePadTo GetOrgMousePadByMemberId(int memberId)
        {
            return Call<OrgMousePadTo, int>(memberId, "GetOrgMousePadByMemberId");
        }

        [Description("New org mouse pad")]
        public bool InsertOrgMousePad(OrgMousePadTo mousePad)
        {
            return Call<bool, OrgMousePadTo>(mousePad, "InsertOrgMousePad");
        }

        [Description("Count down")]
        public bool CountCampaignDown(string campaignName, int count)
        {
            ReqCampaignNameAndCount request = new ReqCampaignNameAndCount()
            {
                CampaignName = campaignName,
                Count = count
            };

            return Call<bool, ReqCampaignNameAndCount>(request, "CountCampaignDown");
        }

        [Description("Upload File to FTP")]
        public ResponseFTPUpload FTPUpload(RequestFTPUpload request)
        {
            return Call<ResponseFTPUpload, RequestFTPUpload>(request, "FTPUpload");
        }


        [Description("Delete file or folder in FTP")]
        public ResponseFTPDelete FTPDelete(RequestFTPDelete request)
        {
            return Call<ResponseFTPDelete, RequestFTPDelete>(request, "FTPDelete");
        }


        [Description("OrgMousePad Status KargoyaHazırlanıyor List")]
        public List<OrgMousePadTo> ListOrgMousePadStatus(ReqListOrgMousePadStatus Rq)
        {
            return Call<List<OrgMousePadTo>, ReqListOrgMousePadStatus>(Rq, "ListOrgMousePadStatus");
        }

        [Description("Get Isimtescil.net frontpage Images List")]
        public List<ResFrontBannerImage> GetFrontBannerList()
        {
            return Call<List<ResFrontBannerImage>, ReqEmpty>(new ReqEmpty(), "GetFrontBannerList");
        }


        [Description("OrgMousePad Status Change")]
        public bool OrgMousePadStatusChange(ReqOrgMousePadStatusChange Rq)
        {
            return Call<bool, ReqOrgMousePadStatusChange>(Rq, "OrgMousePadStatusChange");
        }


        [Description("GetLogCategory")]
        public string GetLogCategory(string ApiName)
        {
            return Call<string, string>(ApiName, "GetLogCategory");
        }


        [Description("GetLogCategory")]
        public ResGetLogMethods GetLogMethods(ReqGetLogMethods rq)
        {
            return Call<ResGetLogMethods, ReqGetLogMethods>(rq, "GetLogMethods");
        }


        [Description("GetLogCategory")]
        public ResGetLogDetails LogDetails(int LogId)
        {
            return Call<ResGetLogDetails, int>(LogId, "LogDetails");
        }

        [Description("GetLog List APINAME")]
        public List<string> GetLogListApiName()
        {
            return Call<List<string>, ReqEmpty>(new ReqEmpty(), "GetLogListApiName");
        }


        [Description("Domain buying member CrossBuyingOffer Hosting")]
        public ResCrossBuyingOffer CrossBuyingOffer(ReqCrossBuyingOffer rq)
        {
            return Call<ResCrossBuyingOffer, ReqCrossBuyingOffer>(rq, "CrossBuyingOffer");
        }

        [Description("Domain buying member CrossBuyingSelection")]
        public ResCrossBuyingSelection CrossBuyingSelection(ReqCrossBuyingSelection rq)
        {
            return Call<ResCrossBuyingSelection, ReqCrossBuyingSelection>(rq, "CrossBuyingSelection");
        }

        [Description("Cross Buying Query Count")]
        public int CrossBuyingQueryCount()
        {
            return Call<int, ReqEmpty>(new ReqEmpty(), "CrossBuyingQueryCount");
        }

        [Description("Get Member Dashboard Items")]
        public DashboardReport GetDashboardReport(ReqGetDashboardReport request)
        {
            return this.Call<DashboardReport, ReqGetDashboardReport>(request, "GetDashboardReport");
        }

        [Description("Get Expiring Product List")]
        public List<ExpiringProduct> GetExpiringProductList(ReqGetExpiringProductList request)
        {
            return this.Call<List<ExpiringProduct>, ReqGetExpiringProductList>(request, "GetExpiringProductList");
        }

        [Description("Member take to services company")]
        public List<string> MemberServices()
        {
            return Call<List<string>, ReqEmpty>(new ReqEmpty(), "MemberServices");
        }

        [Description("Member CustomerOftheYearSave Camping2014 save")]
        public string CustomerOftheYearSave(ReqCustomerOftheYearSave req)
        {
            return Call<string, ReqCustomerOftheYearSave>(req, "CustomerOftheYearSave");
        }

        [Description("Member CustomerOftheYearPhotoUpdate And Point Save")]
        public string CustomerOftheYearPhotoUpdate(ReqCustomerOftheYearSave req)
        {
            return Call<string, ReqCustomerOftheYearSave>(req, "CustomerOftheYearPhotoUpdate");
        }

        [Description("Member CustomerOftheYearTokenUpdate")]
        public string CustomerOftheYearTokenUpdate(ReqCustomerOftheYearSave req)
        {
            return Call<string, ReqCustomerOftheYearSave>(req, "CustomerOftheYearTokenUpdate");
        }

        [Description("Member CustomerOftheYear Member Control ")]
        public ResCustomerOftheYearCampingControl CustomerOftheYearCampingControl(ReqCustomerOftheYearCampingControl req)
        {
            return Call<ResCustomerOftheYearCampingControl, ReqCustomerOftheYearCampingControl>(req, "CustomerOftheYearCampingControl");
        }

        [Description("Member CustomerOftheYear List Staff")]
        public List<ResCampingYearCustomer> CampingYearCustomerList(ReqCampingYearCustomerList req)
        {
            return Call<List<ResCampingYearCustomer>, ReqCampingYearCustomerList>(req, "CampingYearCustomerList");
        }

        [Description("Member CustomerOftheYear Staff")]
        public ResCampingYearCustomer CampingYearCustomer(int id)
        {
            return Call<ResCampingYearCustomer, int>(id, "CampingYearCustomer");
        }

        [Description("Member CustomerOftheYear Count Staff")]
        public int CampingYearCustomerCount(EnmCampaignCustomerYear2014Status req)
        {
            return Call<int, EnmCampaignCustomerYear2014Status>(req, "CampingYearCustomerCount");
        }

        [Description("Member Customer Year Detail Staff")]
        public ResCampingCustomerYearDetail CampingCustomerYearDetail(ReqCampingCustomerYearDetail req)
        {
            return Call<ResCampingCustomerYearDetail, ReqCampingCustomerYearDetail>(req, "CampingCustomerYearDetail");
        }

        [Description("Member Customer Year Active And Share Staff")]
        public ResCampingYearActiveAndShare CampingYearActiveAndShare(ReqCampingYearActiveAndShare req)
        {
            return Call<ResCampingYearActiveAndShare, ReqCampingYearActiveAndShare>(req, "CampingYearActiveAndShare");
        }

        [Description("Member Customer Year ActiveData Staff")]
        public ResCampingYearActiveAndShare CampingYearActiveData(int campaignCustomerYear2014Id)
        {
            return Call<ResCampingYearActiveAndShare, int>(campaignCustomerYear2014Id, "CampingYearActiveData");
        }

        [Description("Member Customer Year CancelData Staff")]
        public ResCampingYearActiveAndShare CampingYearCancel(int campaignCustomerYear2014Id)
        {
            return Call<ResCampingYearActiveAndShare, int>(campaignCustomerYear2014Id, "CampingYearCancel");
        }


        [Description("Member Public Customer Year")]
        public ResCampingPublicCustomerYearList CampingPublicCustomerYearListFb(ReqCampingPublicCustomerYearList req)
        {
            return Call<ResCampingPublicCustomerYearList, ReqCampingPublicCustomerYearList>(req, "CampingPublicCustomerYearListFb");
        }


        [Description("Member Public Customer Point")]
        public List<ResCampingCustomerYearPoint> CampingCustomerYearPoint(int id)
        {
            return Call<List<ResCampingCustomerYearPoint>, int>(id, "CampingCustomerYearPoint");
        }

        [Description("Member Public Customer Point")]
        public List<ResCampingCustomerYearPoint> CampingCustomerYearPointFb(ReqCampingCustomerYearPointFb request)
        {
            return Call<List<ResCampingCustomerYearPoint>, ReqCampingCustomerYearPointFb>(request, "CampingCustomerYearPointFb");
        }


        [Description("Member Public Customer Point Send")]
        public bool CampingCustomerYearPointSend(ReqCampingCustomerYearPointSend req)
        {
            return Call<bool, ReqCampingCustomerYearPointSend>(req, "CampingCustomerYearPointSendFb");
        }


        [Description("Member Public Customer Point Send Cancel")]
        public bool CampingCustomerYearPointCancel(ReqCampingCustomerYearPointSend req)
        {
            return Call<bool, ReqCampingCustomerYearPointSend>(req, "CampingCustomerYearPointCancelFb");
        }



        [Description("Member Public Customer Istatistic")]
        public ResDasboardIstatistic DasboardIstatistic()
        {
            return Call<ResDasboardIstatistic, ReqEmpty>(new ReqEmpty(), "DasboardIstatistic");
        }

        [Description("Member Public Customer Customer Back Forward selection")]
        public ResCampingCustomerBackForward CampingCustomerBackForward(ReqCampingCustomerBackForward req)
        {
            return Call<ResCampingCustomerBackForward, ReqCampingCustomerBackForward>(req, "CampingCustomerBackForward");
        }

        [Description("Get all active goals in staff")]
        public List<ResStaffNoticeGoal> GetActiveGoals()
        {
            return Call<List<ResStaffNoticeGoal>, ReqEmpty>(new ReqEmpty(), "GetActiveGoals");
        }

        [Description("Get goals by id in staff")]
        public ResStaffNoticeGoal GetGoalById(int req)
        {
            return Call<ResStaffNoticeGoal, int>(req, "GetGoalById");
        }

        [Description("Get all goals in staff")]
        public List<ResStaffNoticeGoal> GetGoalList()
        {
            return Call<List<ResStaffNoticeGoal>, ReqEmpty>(new ReqEmpty(), "GetGoalList");
        }

        [Description("Save goal in staff")]
        public string SaveGoal(ReqStaffNoticeGoal request)
        {
            return Call<string, ReqStaffNoticeGoal>(request, "SaveGoal");
        }

        [Description("Update goal in staff")]
        public string UpdateGoal(ReqStaffNoticeGoal request)
        {
            return Call<string, ReqStaffNoticeGoal>(request, "UpdateGoal");
        }

        [Description("Delete goal in staff")]
        public string DeleteGoal(int req)
        {
            return Call<string, int>(req, "DeleteGoal");
        }

        [Description("Get offer by id in staff")]
        public ResStaffNoticeOffer GetOfferById(int req)
        {
            return Call<ResStaffNoticeOffer, int>(req, "GetOfferById");
        }

        [Description("Get all offer in staff")]
        public List<ResStaffNoticeOffer> GetOfferList()
        {
            return Call<List<ResStaffNoticeOffer>, ReqEmpty>(new ReqEmpty(), "GetOfferList");
        }

        [Description("Save offer in staff")]
        public bool SaveOffer(ReqStaffNoticeOffer request)
        {
            return Call<bool, ReqStaffNoticeOffer>(request, "SaveOffer");
        }

        [Description("Get campaign by id in staff")]
        public ResStaffNoticeCampaign GetCampaignById(int req)
        {
            return Call<ResStaffNoticeCampaign, int>(req, "GetCampaignById");
        }

        [Description("Get all campaign in staff")]
        public List<ResStaffNoticeCampaign> GetCampaignList()
        {
            return Call<List<ResStaffNoticeCampaign>, ReqEmpty>(new ReqEmpty(), "GetCampaignList");
        }

        [Description("Save campaign in staff")]
        public string SaveCampaign(ReqStaffNoticeCampaign request)
        {
            return Call<string, ReqStaffNoticeCampaign>(request, "SaveCampaign");
        }

        [Description("Campaign search in staff")]
        public List<ResStaffNoticeCampaign> CampaignSearch(ReqStaffNoticeCampaignSearch reqlist)
        {
            return Call<List<ResStaffNoticeCampaign>, ReqStaffNoticeCampaignSearch>(reqlist, "CampaignSearch");
        }

        [Description("Update campaign in staff")]
        public string UpdateCampaign(ReqStaffNoticeCampaign request)
        {
            return Call<string, ReqStaffNoticeCampaign>(request, "UpdateCampaign");
        }

        [Description("Delete campaign in staff")]
        public string DeleteCampaign(int req)
        {
            return Call<string, int>(req, "DeleteCampaign");
        }

        [Description("Get notice by id in staff")]
        public ResStaffNotices GetNoticesById(int req)
        {
            return Call<ResStaffNotices, int>(req, "GetNoticesById");
        }

        [Description("Get notice list in staff")]
        public List<ResStaffNotices> GetNoticesList()
        {
            return Call<List<ResStaffNotices>, ReqEmpty>(new ReqEmpty(), "GetNoticesList");
        }

        [Description("Save notice in staff")]
        public string SaveNotices(ReqStaffNotices request)
        {
            return Call<string, ReqStaffNotices>(request, "SaveNotices");
        }

        [Description("Update notice in staff")]
        public string UpdateNotices(ReqStaffNotices request)
        {
            return Call<string, ReqStaffNotices>(request, "UpdateNotices");
        }

        [Description("Delete notice in staff")]
        public string DeleteNotices(int request)
        {
            return Call<string, int>(request, "DeleteNotices");
        }

        [Description("Get department in staff")]
        public ResStaff GetSatffDepartment(int request)
        {
            return Call<ResStaff, int>(request, "GetSatffDepartment");
        }

        [Description("Update offer in staff")]
        public string UpdateOffer(ReqStaffNoticeOffer request)
        {
            return Call<string, ReqStaffNoticeOffer>(request, "UpdateOffer");
        }

        [Description("Delete offer in staff")]
        public string DeleteOffer(int request)
        {
            return Call<string, int>(request, "DeleteOffer");
        }

        [Description("Offer search in staff")]
        public List<ResStaffNoticeOffer> OfferSearch(ReqStaffNoticeOfferSearch reqlist)
        {
            return Call<List<ResStaffNoticeOffer>, ReqStaffNoticeOfferSearch>(reqlist, "OfferSearch");
        }

        [Description("ArkadasimaDevretHosting")]
        public bool ArkadasimaDevretHosting(ReqArkadasimaDevretHosting req)
        {
            return Call<bool, ReqArkadasimaDevretHosting>(req, "ArkadasimaDevretHosting");
        }

        [Description("ArkadasimaDevretHasHostingIndirim")]
        public bool ArkadasimaDevretHasHostingIndirim(ReqArkadasimaDevretHasHostingIndirim req)
        {
            return Call<bool, ReqArkadasimaDevretHasHostingIndirim>(req, "ArkadasimaDevretHasHostingIndirim");
        }

        [Description("AdSoyad Domain control")]
        public List<ResDomainTypesAndPrices> DomainControlList()
        {
            return Call<List<ResDomainTypesAndPrices>, ReqEmpty>(new ReqEmpty(), "DomainControlList");
        }

        [Description("Insert Domain News Staff")]
        public string InsertDomainNews(ReqGetDomainNewsList request)
        {
            return Call<string, ReqGetDomainNewsList>(request, "InsertDomainNews");
        }

        [Description("Update Domain News Staff")]
        public string UpdateDomainNews(ReqGetDomainNewsList request)
        {
            return Call<string, ReqGetDomainNewsList>(request, "UpdateDomainNews");
        }

        [Description("Delete Domain News Staff")]
        public string DeleteNews(int request)
        {
            return Call<string, int>(request, "DeleteNews");
        }

        [Description("Get news by id in staff")]
        public DomainNewsInfo GetNewsById(int req)
        {
            return Call<DomainNewsInfo, int>(req, "GetNewsById");
        }
    }
}
