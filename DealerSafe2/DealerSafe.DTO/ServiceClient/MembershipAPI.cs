using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DealerSafe.DTO;
using DealerSafe.DTO.Dashboard;
using DealerSafe.DTO.Membership;
using Fbs.Core.Entities;
using Newtonsoft.Json;

namespace DealerSafe.ServiceClient
{
    public class MembershipAPI : BaseAPI
    {
        public MembershipAPI(int memberId)
        {
            this.memberId = memberId;
        }

        public MembershipAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        [Description("Get discounted product list")]
        public List<DiscountBulletinInfo> GetDiscountBulletinList(ReqGetDiscountBulletinList request)
        {
            return this.Call<List<DiscountBulletinInfo>, ReqGetDiscountBulletinList>(request, "GetDiscountBulletinList");
        }

        [Description("Returns the essential information of a member specified by username")]
        public MemberInfo GetMemberInfoByUserName(string username)
        {
            return this.Call<MemberInfo, string>(username, "GetMemberInfoByUserName");
        }

        [Description("Returns Member Login Information")]
        public List<MemberLogsInfo> GetMemberLogs(string username, DateTime entryDate, string ip)
        {
            var req = new ReqMemberLogsInfo() { Username = username, EntryDate = entryDate, Ip = ip };
            return this.Call<List<MemberLogsInfo>, ReqMemberLogsInfo>(req, "GetMemberLogs");
        }

        [Description("Insert Member Login Information")]
        public int InsertMemberLogs(MemberLogsInfo memberLog)
        {
            return this.Call<int, MemberLogsInfo>(memberLog, "InsertMemberLogs");
        }

        [Description("Returns the essential information of a member specified by login data")]
        public MemberInfo Login(string email, string password)
        {
            ReqLogin request = new ReqLogin { Email = email, Password = password };

            return this.Call<MemberInfo, ReqLogin>(request, "Login");
        }

        [Description("Returns the essential information of a member specified by login data")]
        public MemberInfo LoginSec(string email, string password)
        {
            ReqLogin request = new ReqLogin { Email = email, Password = password };

            return this.Call<MemberInfo, ReqLogin>(request, "LoginSec");
        }

        [Description("Returns the essential information of a member specified by id")]
        public MemberInfo GetMemberInfo(int id)
        {
            ReqGetMemberInfo request = new ReqGetMemberInfo { Id = id };
            return this.Call<MemberInfo, ReqGetMemberInfo>(request, "GetMemberInfo");
        }
        
        [Description("Request a new password reset email")]
        public ForgotPasswordInfo ForgotPassword(ReqForgotPassword request)
        {
            return this.Call<ForgotPasswordInfo, ReqForgotPassword>(request, "ForgotPassword");
        }

        [Description("Request for register user")]
        public RegisterUserInfo RegisterUser(ReqRegisterUser request)
        {
            return this.Call<RegisterUserInfo, ReqRegisterUser>(request, "RegisterUser");
        }

        [Description("Request Validate for register user")]
        public ValidateUserInfo RegisterUserValidate(ReqRegisterUser request)
        {
            return this.Call<ValidateUserInfo, ReqRegisterUser>(request, "RegisterUserValidate");
        }

        [Description("Request send sms for register user")]
        public SendSmsForReqisterUserInfo RegisterUserSendSMS(ReqSendSmsForReqisterUser request)
        {
            return this.Call<SendSmsForReqisterUserInfo, ReqSendSmsForReqisterUser>(request, "RegisterUserSendSMS");
        }

        [Description("Request send sms for register turkcell user")]
        public SendSmsForReqisterUserInfo RegisterTurkcellUserSendSMS(ReqSendSmsForReqisterUser request)
        {
            return this.Call<SendSmsForReqisterUserInfo, ReqSendSmsForReqisterUser>(request, "RegisterTurkcellUserSendSMS");
        }

        [Description("Request send mail for register user")]
        public SendMailForReqisterUserInfo RegisterUserSendMail(ReqSendMailForReqisterUser request)
        {
            return this.Call<SendMailForReqisterUserInfo, ReqSendMailForReqisterUser>(request, "RegisterUserSendMail");
        }

        [Description("Request send mail for register user")]
        public SendMailForReqisterUserInfo RegisterTurkcellUserFirstSendMail(ReqSendMailForReqisterUser request)
        {
            return this.Call<SendMailForReqisterUserInfo, ReqSendMailForReqisterUser>(request, "RegisterTurkcellUserFirstSendMail");
        }

        [Description("Request for register user")]
        public UpdateUserInfo UpdateUser(ReqUpdateUser request)
        {
            var res = this.Call<UpdateUserInfo, ReqUpdateUser>(request, "UpdateUser");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Change password for registered users")]
        public ChangePasswordInfo ChangePassword(ReqChangePassword request)
        {
            return this.Call<ChangePasswordInfo, ReqChangePassword>(request, "ChangePassword");
        }

        [Description("Request validate for change password")]
        public ChangePasswordValidateInfo ChangePasswordValidate(ReqChangePassword request)
        {
            return this.Call<ChangePasswordValidateInfo, ReqChangePassword>(request, "ChangePasswordValidate");
        }

        [Description("Change email for registered users")]
        public ChangeEmailInfo ChangeEmail(ReqChangeEmail request)
        {
            var res = this.Call<ChangeEmailInfo, ReqChangeEmail>(request, "ChangeEmail");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Change email for registered users")]
        public ChangeUserNameInfo ChangeUserName(ReqChangeUserName request)
        {
            var res = this.Call<ChangeUserNameInfo, ReqChangeUserName>(request, "ChangeUserName");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Change support email for registered users")]
        public ChangeEmailInfo ChangeSupportEmail(ReqChangeEmail request)
        {
            var res = this.Call<ChangeEmailInfo, ReqChangeEmail>(request, "ChangeSupportEmail");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Request validate for change email")]
        public ChangeEmailValidateInfo ChangeEmailValidate(ReqChangeEmailValidate request)
        {
            return this.Call<ChangeEmailValidateInfo, ReqChangeEmailValidate>(request, "ChangeEmailValidate");
        }


        [Description("Request validate for change UserName")]
        public ChangeUserNameValidateInfo ChangeUserNameValidate(ReqChangeUserNameValidate request)
        {
            return this.Call<ChangeUserNameValidateInfo, ReqChangeUserNameValidate>(request, "ChangeUserNameValidate");
        }


        [Description("Confirm mobile number for registered users")]
        public ConfirmMobileInfo ConfirmMobileNumber(ReqConfirmMobile request)
        {
            var res = this.Call<ConfirmMobileInfo, ReqConfirmMobile>(request, "ConfirmMobileNumber");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Request New Address for registered users")]
        public AddMembersAddressInfo AddMembersAddress(ReqAddMembersAddress request)
        {
            return this.Call<AddMembersAddressInfo, ReqAddMembersAddress>(request, "AddMembersAddress");
        }

        [Description("Request Update Address for registered users")]
        public UpdateMembersAddressInfo UpdateMembersAddress(ReqUpdateMembersAddress request)
        {
            return this.Call<UpdateMembersAddressInfo, ReqUpdateMembersAddress>(request, "UpdateMembersAddress");
        }

        [Description("Request Delete Address for registered users")]
        public DeleteMembersAddressInfo DeleteMembersAddress(ReqDeleteMembersAddress request)
        {
            return this.Call<DeleteMembersAddressInfo, ReqDeleteMembersAddress>(request, "DeleteMembersAddress");
        }

        [Description("Request Delete Address for registered users - with type")]
        public DeleteMembersAddressInfo DeleteMembersAddressWithType(ReqDeleteMembersAddress request)
        {
            return this.Call<DeleteMembersAddressInfo, ReqDeleteMembersAddress>(request, "DeleteMembersAddressWithType");
        }

        [Description("Request Address Detail for registered users")]
        public GetMemberAddressInfo GetMembersAddress(ReqGetMembersAddress request)
        {
            return this.Call<GetMemberAddressInfo, ReqGetMembersAddress>(request, "GetMembersAddress");
        }

        [Description("Request Address list for registered users")]
        public GetMemberAddressListInfo GetMembersAddressList(ReqGetMembersAddressList request)
        {
            return this.Call<GetMemberAddressListInfo, ReqGetMembersAddressList>(request, "GetMembersAddressList");
        }

        [Description("Request Address list for registered users - with type")]
        public GetMemberAddressListInfoWithType GetMembersAddressListWithType(ReqGetMembersAddressList request)
        {
            return this.Call<GetMemberAddressListInfoWithType, ReqGetMembersAddressList>(request, "GetMembersAddressListWithType");
        }

        [Description("Request default address fır registered users")]
        public UpdateMemberDefaultAddressInfo UpdateMemberDefaultAddress(ReqUpdateMemberDefaultAddress request)
        {
            var res = this.Call<UpdateMemberDefaultAddressInfo, ReqUpdateMemberDefaultAddress>(request, "UpdateMemberDefaultAddress");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Message list of the member")]
        public MemberMessagesInfo GetMemberMessages(ReqGetMemberMessages request)
        {
            return this.Call<MemberMessagesInfo, ReqGetMemberMessages>(request, "GetMemberMessages");
        }

        [Description("Message count of the member")]
        public MemberMessageCountInfo GetMemberMessageCount(ReqGetMemberMessageCount request)
        {
            return this.Call<MemberMessageCountInfo, ReqGetMemberMessageCount>(request, "GetMemberMessageCount");
        }

        [Description("Message detail of the member")]
        public MemberMessageDetailInfo GetMemberMessageDetail(ReqGetMemberMessageDetail request)
        {
            return this.Call<MemberMessageDetailInfo, ReqGetMemberMessageDetail>(request, "GetMemberMessageDetail");
        }

        [Description("Read of the member message")]
        public UpdateMemberMessageReadInfo UpdateMemberMessageRead(ReqUpdateMemberMessageRead request)
        {
            return this.Call<UpdateMemberMessageReadInfo, ReqUpdateMemberMessageRead>(request, "UpdateMemberMessageRead");
        }

        [Description("Status update of the member message")]
        public UpdateMemberMessageStatusInfo UpdateMemberMessagStatus(ReqUpdateMemberMessageStatus request)
        {
            return this.Call<UpdateMemberMessageStatusInfo, ReqUpdateMemberMessageStatus>(request, "UpdateMemberMessagStatus");
        }

        [Description("Request block user for member")]
        public BlockUserInfo BlockUser(ReqBlockUser request)
        {
            var res = this.Call<BlockUserInfo, ReqBlockUser>(request, "BlockUser");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Request update activation code for member")]
        public UpdateActivationCodeInfo UpdateActivationCode(ReqUpdateActivationCode request)
        {
            var res = this.Call<UpdateActivationCodeInfo, ReqUpdateActivationCode>(request, "UpdateActivationCode");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Request change phone for member")]
        public ChangeGSMInfo ChangeGSM(ReqChangeGSM request)
        {
            var res = this.Call<ChangeGSMInfo, ReqChangeGSM>(request, "ChangeGSM");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Request change kayako user id for member")]
        public bool ChangeKayakoUserId(ReqChangeKayakoUserId request)
        {
            var res = this.Call<bool, ReqChangeKayakoUserId>(request, "ChangeKayakoUserId");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Get suggestion list of the system")]
        public GetSuggestionsInfo GetSuggestions()
        {
            ReqSuggestionsInfo request = new ReqSuggestionsInfo();
            return this.Call<GetSuggestionsInfo, ReqSuggestionsInfo>(request, "GetSuggestions");
        }

        [Description("Invoice List of the member")]
        public GetMemberInvoiceListInfo GetMemberInvoicelist(ReqGetMemberInvoiceList request)
        {
            return this.Call<GetMemberInvoiceListInfo, ReqGetMemberInvoiceList>(request, "GetMemberInvoicelist");
        }

        [Description("Update invoice company of the member")]
        public UpdateInvoiceCompanyInfo UpdateInvoiceCompany(ReqUpdateInvoiceCompany request)
        {
            var res = this.Call<UpdateInvoiceCompanyInfo, ReqUpdateInvoiceCompany>(request, "UpdateInvoiceCompany");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Returns visitor count from SQL Server Session database")]
        public int GetOnlineVisitorCount()
        {
            return this.Call<int, ReqEmpty>(new ReqEmpty(), "GetOnlineVisitorCount");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["membershipServiceURL"]; ;
        }

        public bool IpIsAdmin(string clientIpAddress)
        {
            //new Member().IpIsAdmin(clientIpAddress)
            return Call<bool, string>(clientIpAddress, "IpIsAdmin");
        }

        [Description("Adds kayako user id")]
        public bool AddKayakoUserID(int memberId, int kayakoUserId)
        {
            return Call<bool, ReqAddKayakoUserId>(new ReqAddKayakoUserId { MemberID = memberId, Userid = kayakoUserId }, "AddKayakoUserID");
        }


        [Description("Get Country list")]
        public CountryListInfo CountryList(ReqCountryList request)
        {
            return this.Call<CountryListInfo, ReqCountryList>(request, "CountryList");
        }

        [Description("Auto Complete Member Search")]
        public AutoCompleteMemberSearchInfo AutoCompleteMemberSearch(ReqAutoCompleteMemberSearch request)
        {
            return this.Call<AutoCompleteMemberSearchInfo, ReqAutoCompleteMemberSearch>(request, "AutoCompleteMemberSearch");
        }

        public bool UpdateMemberInvoiceInfo(int memId, bool invoiceSend, int invoiceCompanyId)
        {
            return Call<bool, ReqUpdateMemberInvoiceInfo>(new ReqUpdateMemberInvoiceInfo { MemberId = memberId, InvoiceSend = invoiceSend, InvoiceCompanyId = invoiceCompanyId }, "UpdateMemberInvoiceInfo");
        }

        [Description("Get user messages count")]
        public List<tblAdminNoticeInfo> GetUserMessages(ReqGetUserMessages request)
        {
            return this.Call<List<tblAdminNoticeInfo>, ReqGetUserMessages>(request, "GetUserMessages");
        }

        [Description("delete user message")]
        public bool DeleteUserMessage(ReqDeleteUserMessage request)
        {
            return this.Call<bool, ReqDeleteUserMessage>(request, "DeleteUserMessage");
        }

        [Description("read user message")]
        public bool ReadUserMessage(ReqReadUserMessage request)
        {
            return this.Call<bool, ReqReadUserMessage>(request, "ReadUserMessage");
        }

        public string GetTcNoToEmail(string TcNo)
        {
            return Call<string, string>(TcNo, "GetTcNoToEmail");

        }

        [Description("domain taşıma listesini getirir")]
        public List<ResGetDomainMove> GetDomainMoveList(ReqDomainMove request)
        {
            return this.Call<List<ResGetDomainMove>, ReqDomainMove>(request, "GetDomainMoveList");
        }

        [Description("domain taşıma işlemini iptal eder")]
        public bool CancelDomainMove(ReqDomainMove request)
        {
            return this.Call<bool, ReqDomainMove>(request, "CancelDomainMove");
        }

        [Description("domain taşıma işlemini iptal eder")]
        public bool ApproveDomainMove(ReqDomainMove request)
        {
            return this.Call<bool, ReqDomainMove>(request, "ApproveDomainMove");
        }

        [Description("Turkcell kampanyası için mobile kayıt formu aktiflenmiş mi?")]
        public bool MobileMembersIsActive(ReqMembersMobile request)
        {
            return this.Call<bool, ReqMembersMobile>(request, "MobileMembersIsActive");
        }

        [Description("Turkcell kampanyası için mobile kayıt formu")]
        public string MobileMembersSave(ReqMembersMobile request)
        {
            return this.Call<string, ReqMembersMobile>(request, "MobileMembersSave");
        }

        [Description("Turkcell kampanyası için mobile kayıt ek formu")]
        public bool MobileMembersCheck(ReqMembersMobile request)
        {
            return this.Call<bool, ReqMembersMobile>(request, "MobileMembersCheck");
        }

        [Description("Request for register mobile user")]
        public UpdateUserInfo MobileUpdateUser(ReqRegisterUser request)
        {
            var res = this.Call<UpdateUserInfo, ReqRegisterUser>(request, "MobileUpdateUser");
            HttpContext.Current.Session["MemberInfo"] = null;
            return res;
        }

        [Description("Get campaign by id in staff")]
        public DiscountBulletinInfo GetCampaignsById(int req)
        {
            return Call<DiscountBulletinInfo, int>(req, "GetCampaignsById");
        }

        [Description("Insert Campaign Staff")]
        public string InsertCampaign(ReqGetDiscountBulletinList request)
        {
            return Call<string, ReqGetDiscountBulletinList>(request, "InsertCampaign");
        }

        [Description("Update Campaign Staff")]
        public string UpdateCampaign(ReqGetDiscountBulletinList request)
        {
            return Call<string, ReqGetDiscountBulletinList>(request, "UpdateCampaign");
        }

        [Description("Delete Campaign Staff")]
        public string DeleteCampaign(int request)
        {
            return Call<string, int>(request, "DeleteCampaign");
        }

        [Description("Returns the marketing authorization information of a member specified by member id")]
        public ResMemberMarketingAuth GetMemberMarketingAuth(int id)
        {
            var request = new ReqMemberMarketingAuth { MemberId = id };
            return Call<ResMemberMarketingAuth, ReqMemberMarketingAuth>(request, "GetMemberMarketingAuth");
        }

        [Description("Returns the marketing authorization information")]
        public List<ResMemberMarketingAuth> GetMemberMarketingAuthList(ReqGetMemberMarketingAuthList request)
        {
            return Call<List<ResMemberMarketingAuth>, ReqGetMemberMarketingAuthList>(request, "GetMemberMarketingAuthList");
        }

        [Description("Save the marketing authorization information")]
        public bool SaveMemberMarketingAuth(ReqMemberMarketingAuth request)
        {
            return Call<bool, ReqMemberMarketingAuth>(request, "SaveMemberMarketingAuth");
        }

        [Description("Update the marketing authorization information of a member specified by member id")]
        public bool UpdateMemberMarketingAuth(ReqMemberMarketingAuth request)
        {
            return Call<bool, ReqMemberMarketingAuth>(request, "UpdateMemberMarketingAuth");
        }

        [Description("Change member default contact ")]
        public string UpdateMemberDefaultContact(ReqUpdateMembersDefaultContact request)
        {
            return Call<string, ReqUpdateMembersDefaultContact>(request, "UpdateMemberDefaultContact");
        }
    }
}
