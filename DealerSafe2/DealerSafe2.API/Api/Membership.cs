using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DealerSafe2.API.Api.Library;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.API.Workers;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        #region MemberAddress

        public List<MemberAddressInfo> GetMemberAddressList(ReqEmpty req)
        {
            return Provider.Database
                           .ReadList<MemberAddress>(
                               "SELECT * FROM MemberAddress WHERE IsDeleted=0 AND MemberId={0} ORDER BY Title",
                               Session.MemberId)
                           .ToEntityInfo<MemberAddressInfo>();
        }

        public MemberAddressInfo GetMemberAddress(string id)
        {
            var a = Provider.Database.Read<MemberAddress>("Id={0}", id);
            if (a == null || a.MemberId != Session.MemberId)
            {
                throw new APIException(Provider.TR("No such address"));
            }
            var address = new MemberAddressInfo();
            a.CopyPropertiesWithSameName(address);
            return address;
        }

        public MemberAddressInfo SaveMemberAddress(MemberAddressInfo req)
        {
            var a = Provider.Database.Read<MemberAddress>("Id = {0}", req.Id) ?? new MemberAddress();

            req.CopyPropertiesWithSameName(a);
            a.MemberId = Session.MemberId;
            a.Save();

            if (a.AddressType == AddressTypes.DefaultAddress)
            {
                Session.Member().MemberAddressId = a.Id;
                Session.Member().Save();
            }
            return a.ToEntityInfo<MemberAddressInfo>();
        }

        public bool DeleteMemberAddress(string id)
        {
            var a = Provider.Database.Read<MemberAddress>("Id={0}", id);
            if (a != null && a.MemberId == Session.MemberId)
            {
                var m = Provider.Database.Read<Member>("Id={0} AND AddressId={1} AND IsDeleted=0",
                                                       Session.MemberId, a.Id);
                if (m == null)
                {
                    a.Delete();
                    return true;
                }

                throw new APIException(Provider.TR("You can not delete default address"));
            }
            return false;
        }

        public List<IdName> GetCountryList(ReqEmpty req)
        {
            return Provider.Database.ReadList<Country>("SELECT Id, Name FROM Country WHERE IsDeleted=0 ORDER BY Name")
                           .Select(c => new IdName { Id = c.Id, Name = c.Name })
                           .ToList();
        }

        public List<IdName> GetStateList(string countryId)
        {
            return
                Provider.Database.ReadList<State>(
                    "SELECT Id, Name FROM State WHERE CountryId={0} AND IsDeleted=0 ORDER BY Name", countryId)
                        .Select(c => new IdName { Id = c.Id, Name = c.Name })
                        .ToList();
        }

        public List<IdName> GetCityList(ReqGetCityList req)
        {
            var cityList = new List<City>();
            if (!string.IsNullOrWhiteSpace(req.StateId))
                cityList =
                    Provider.Database.ReadList<City>(
                        "SELECT Id, Name FROM City WHERE StateId={0} AND IsDeleted=0 ORDER BY Name", req.StateId);
            else if (!string.IsNullOrWhiteSpace(req.CountryId))
                cityList =
                    Provider.Database.ReadList<City>(
                        "SELECT Id, Name FROM City WHERE CountryId={0} AND IsDeleted=0 ORDER BY Name", req.CountryId);

            return cityList.Select(c => new IdName() { Id = c.Id, Name = c.Name }).ToList();
        }

        public List<IdName> GetDistrictList(string cityId)
        {
            return Provider.Database
                           .ReadList<District>(
                               "SELECT Id, Name FROM District WHERE IsDeleted=0 AND CityId={0} ORDER BY Name", cityId)
                           .Select(c => new IdName { Id = c.Id, Name = c.Name })
                           .ToList();
        }

        #endregion

        #region Newsletter

        public List<NewsletterDefinitionInfo> GetNewsletterList(ReqEmpty req)
        {
            return
                Provider.Database
                        .ReadList<NewsletterDefinition>(
                            "SELECT * FROM NewsletterDefinition WHERE ApiId={0} AND IsDeleted=0", ApiClient.ApiId)
                        .ToEntityInfo<NewsletterDefinitionInfo>();
        }

        public List<string> GetMemberNewsletters(ReqEmpty req)
        {
            return
                Provider.Database
                        .GetList<string>(
                            "SELECT NewsletterDefinitionId FROM MemberNewsletter WHERE IsDeleted = 0 AND MemberId={0} AND NewsletterDefinitionId IN (SELECT Id FROM NewsletterDefinition WHERE ApiId={1})",
                            Session.MemberId, ApiClient.ApiId);
        }

        public bool DeleteMemberNewsLetter(string newsletterDefinitionId)
        {
            var res =
                Provider.Database.ExecuteNonQuery(
                    "UPDATE MemberNewsletter SET IsDeleted = 1 WHERE NewsletterDefinitionId={0} AND MemberId={1}",
                    newsletterDefinitionId,
                    Session.MemberId);
            return true;
        }

        public bool AddMemberNewsletter(string newsletterDefinitionId)
        {
            var a = Provider.Database.Read<MemberNewsletter>("NewsletterDefinitionId={0} AND MemberId={1}",
                                                             newsletterDefinitionId,
                                                             Session.MemberId);

            if (a == null)
            {
                a = new MemberNewsletter { MemberId = Session.MemberId, NewsletterDefinitionId = newsletterDefinitionId };
                a.Save();
            }

            return true;
        }

        #endregion

        #region Login

        public ResLogin Login(ReqLogin req)
        {
            Member member = null;

            if (string.IsNullOrWhiteSpace(req.Password))
                member =
                    Provider.Database.Read<Member>("Email={0} AND IsDeleted=0 AND (Password IS NULL OR Password='')",
                                                   req.Email);
            else
                member = Provider.Database.Read<Member>("Email={0} AND Password={1} AND IsDeleted=0", req.Email,
                                                        System.Utility.MD5(req.Password));

            if (member == null)
                throw new APIException(Provider.TR("Invalid email or password"));

            switch (member.State)
            {
                case MemberStates.WaitingEmailConfirmation:
                    throw new APIException(Provider.TR("Waiting e-mail confirmation"));
                case MemberStates.WaitingSMSConfirmation:
                    throw new APIException(Provider.TR("Waiting SMS confirmation"));
                case MemberStates.Suspended:
                    throw new APIException(Provider.TR("Membership suspended"));
            }

            return doLoginForMember(member);
        }

        protected ResLogin doLoginForMember(Member member)
        {
            var res = new ResLogin()
                {
                    Member = null,
                    SessionId = string.Empty
                };

            Provider.CurrentMember = member;

            member.LastLoginDate = member.CurrLoginDate;
            member.CurrLoginDate = Provider.Database.Now;
            member.Save();

            res.Member = new MemberInfo();
            member.CopyPropertiesWithSameName(res.Member);

            // oturum açmadan önce oluşturulan sepeti alalım
            Order anonimOrder = Order.GetMemberBasket();

            this.Session.MemberId = member.Id;
            this.Session.LoginDate = Provider.Database.Now;
            this.Session.LastAccess = Provider.Database.Now;
            this.Session.Save();

            // eğer yeni sepette item varsa eski oturumdan kalan sepeti iptal edelim
            if (anonimOrder.Items.Count > 0)
            {
                var eskiSepet = Order.GetMemberBasket();
                if (eskiSepet.Items.Count > 0)
                {
                    eskiSepet.State = OrderStates.BasketCanceled;
                    eskiSepet.Save();
                }
                // yeni sepeti bu kullanıcıya yazalım
                anonimOrder.MemberId = member.Id;
                anonimOrder.Save();
            }

            res.SessionId = this.Session.Id;
            return res;
        }

        public bool Logout(ReqEmpty req)
        {
            Provider.Database.ExecuteNonQuery("delete from ApiSession where Id = {0}", this.Session.Id);
            this.Session.Id = "";
            return true;
        }

        public ResGetDashboard GetDashboard(ReqEmpty req)
        {
            var res = new ResGetDashboard() { Messages = new List<DashboardItem>() };
            foreach (var workerType in typeof(BaseWorker).Assembly.GetTypes())
            {
                if (workerType.IsSubclassOf(typeof(BaseWorker)))
                {
                    var worker = (BaseWorker)Activator.CreateInstance(workerType);
                    var messages = worker.GetDashboardMessages();
                    if (messages != null && messages.Count > 0)
                        res.Messages.AddRange(messages);
                }
            }

            //TODO: bu kodun daha 
            /*
            var memberSSLIds =
                Provider.Database.GetList<string>(
                    "SELECT DISTINCT Id FROM MemberSSL WHERE Id in (SELECT Id FROM MemberProduct WHERE OrderItemId IN (select Id from OrderItem where OrderId in (select Id from [Order] where MemberId = {0})))",
                    Provider.Api.Session.MemberId);
            res.CompletedOrders =
                Provider.Database.GetInt("SELECT count(*) from MemberSSL WHERE State='Completed' AND Id in ('" +
                                         memberSSLIds.StringJoin("','") + "')");
            res.WaitingOrders =
                Provider.Database.GetInt("SELECT count(*) from MemberSSL WHERE State!='Completed' AND Id in ('" +
                                         memberSSLIds.StringJoin("','") + "')");
            */

            res.TotalOrderCost = Provider.Database.GetInt("select sum(TotalPrice) from [Order] where MemberId = {0} AND State = 'Order'",
                                                          Provider.Api.Session.MemberId);

            res.RemainingCredits = 0; //TODO: read this from payment gateway
            res.SupportMessageCount = 0; //TODO: read this from support api

            return res;
        }

        #endregion

        #region Member

        public MemberInfo GetMemberInfo(ReqEmpty req)
        {
            var res = Provider.Database.Read<Member>("Id = {0}", Session.MemberId).ToEntityInfo<MemberInfo>();
            return res;
        }

        public bool SaveProfileInfo(ProfileInfo req)
        {
            MemberAddress ma = Session.Member().MemberAddress() ?? new MemberAddress();
            req.CopyPropertiesWithSameName(ma);
            if (string.IsNullOrWhiteSpace(ma.InvoiceTitle))
                ma.InvoiceTitle = "Default";
            ma.MemberId = Session.MemberId;
            ma.AddressType = AddressTypes.DefaultAddress;
            ma.Save();

            Member m = Session.Member();
            req.CopyPropertiesWithSameName(m);
            m.Id = Session.MemberId;
            m.MemberAddressId = ma.Id;
            m.Save();

            return true;
        }

        public ProfileInfo GetProfileInfo(ReqEmpty req)
        {
            var res = new ProfileInfo();
            Session.Member().CopyPropertiesWithSameName(res);
            (Session.Member().MemberAddress() ?? new MemberAddress()).CopyPropertiesWithSameName(res);
            return res;
        }

        public bool ChangeMemberPassword(ReqChangeMemberPassword req)
        {
            if ((req.NewPassword ?? "").Length < 6)
                throw new APIException("Password length cannot be less than six", ErrorTypes.ValidationError);
            if (req.NewPassword != req.NewPasswordAgain)
                throw new APIException("Passwords not match", ErrorTypes.ValidationError);

            var member = Session.Member();
            if (member == null)
                throw new APIException("No such member", ErrorTypes.ValidationError);

            try
            {
                member.Password = System.Utility.MD5(req.NewPassword);

                if (member.State == MemberStates.ConfirmedWithFacebook)
                    // bu state sayesinde facebook ile gelen üyenin şifresinin alınmasını sağlıyoruz. Alındığını belirtmek için state'i Confirmed yapıyoruz.
                    member.State = MemberStates.Confirmed;

                member.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangeMemberEmail(ReqChangeMemberEmail req)
        {
            if (!(req.Email ?? "").IsEmail())
                throw new APIException("Please enter a valid email address", ErrorTypes.ValidationError);

            var member = Session.Member();
            if (member == null)
                throw new APIException("No such member", ErrorTypes.ValidationError);

            if (member.Password != System.Utility.MD5(req.Password))
                throw new APIException("Please enter your existing password");

            try
            {
                member.NewEmail = req.Email;
                member.Keyword = Utility.CreatePassword(16);
                member.Save();

                member.SendConfirmationCode();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ConfirmEmailChange(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new APIException("Keyword required", ErrorTypes.ValidationError);

            var member = Provider.Database.Read<Member>("Keyword = {0}", keyword);
            if (member == null)
                throw new APIException("No such member with the keyword provided", ErrorTypes.ValidationError);

            if (!string.IsNullOrWhiteSpace(member.NewEmail))
                member.Email = member.NewEmail;
            member.NewEmail = "";
            member.State = MemberStates.Confirmed;
            member.Keyword = "";
            member.Save();

            return true;
        }

        public ResLogin QuickSignUp(ReqQuickSignUp req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || !req.Email.IsEmail())
                throw new APIException("Email address is invalid", ErrorTypes.ValidationError);
            if ((req.Password ?? "").Length < 6)
                throw new APIException("Password length cannot be less than six");
            if (req.Password != req.PasswordAgain)
                throw new APIException("Passwords do not match", ErrorTypes.ValidationError);

            if (!string.IsNullOrWhiteSpace(Session.MemberId))
                throw new APIException("You are already a member", ErrorTypes.ValidationError,
                                       ErrorCodes.ExistingMemberCannotSignUp);

            Member member = Provider.Database.Read<Member>("Email={0} AND ClientId = {1}", req.Email,
                                                           this.ApiClient.ClientId);
            if (member != null)
                throw new APIException("The email address is registered. Please login before proceeding.",
                                       ErrorTypes.ValidationError, ErrorCodes.ExistingMemberCannotSignUp);

            member = new Member
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Email = req.Email,
                    Password = Utility.MD5(req.Password),
                    MemberType = MemberTypes.Individual,
                    State = MemberStates.WaitingEmailConfirmation,
                    LastLoginDate = Provider.Database.Now,
                    ClientId = this.ApiClient.ClientId,
                    StaffMemberId = Provider.Api.GetNextIdleStaffMemberId(Departments.Marketing)
                };
            member.Save();

            member.SendConfirmationCode();

            var res = new ResLogin { Member = new MemberInfo() };
            member.CopyPropertiesWithSameName(res.Member);

            this.Session.MemberId = member.Id;
            this.Session.LoginDate = Provider.Database.Now;
            this.Session.LastAccess = Provider.Database.Now;
            this.Session.Save();

            res.SessionId = this.Session.Id;

            return res;
        }

        public ResLogin LoginWithFacebook(ReqLoginWithFacebook req)
        {
            if (!req.Email.IsEmail())
                throw new APIException("Email address is invalid", ErrorTypes.ValidationError);

            if (!string.IsNullOrWhiteSpace(Session.MemberId))
                return new ResLogin() { Member = Session.Member().ToEntityInfo<MemberInfo>(), SessionId = Session.Id };

            Member member = Provider.Database.Read<Member>("FacebookId={0}", req.FacebookId);
            if (member != null)
            {
                return doLoginForMember(member);
            }

            member = Provider.Database.Read<Member>("Email={0}", req.Email);
            if (member != null)
            {
                if (string.IsNullOrWhiteSpace(member.Avatar)) member.Avatar = req.Avatar;
                member.FacebookId = req.FacebookId;
                if (string.IsNullOrWhiteSpace(member.FirstName)) member.FirstName = req.Name;
                if (string.IsNullOrWhiteSpace(member.LastName)) member.LastName = req.Surname;
                if (string.IsNullOrWhiteSpace(member.Gender)) member.Gender = req.Gender;
                member.Save();

                return doLoginForMember(member);
            }

            member = new Member
                {
                    Email = req.Email,
                    MemberType = MemberTypes.Individual,
                    State = MemberStates.ConfirmedWithFacebook,
                    // facebook'tan gelen üye default onaylıdır (no need for email confirmation)
                    Avatar = req.Avatar,
                    FacebookId = req.FacebookId,
                    FirstName = req.Name,
                    LastName = req.Surname,
                    UserName = req.Nick,
                    Gender = req.Gender,
                    LastLoginDate = Provider.Database.Now,
                    ClientId = this.ApiClient.ClientId,
                    StaffMemberId = Provider.Api.GetNextIdleStaffMemberId(Departments.Marketing)
                };
            member.Save();

            member.SendEmailWithPassword();

            return doLoginForMember(member);
        }

        public bool MemberExists(string email)
        {
            return
                !string.IsNullOrWhiteSpace(Provider.Database.GetString("SELECT Id FROM Member WHERE Email={0}", email));
        }

        public bool SendPasswordRecoveryMessage(string email)
        {
            if (!email.IsEmail())
                throw new APIException("Not valid email address", ErrorTypes.ValidationError);

            var member = Provider.Database.Read<Member>("Email = {0}", email);
            if (member != null)
                member.SendPasswordRecoveryMessage();
            else throw new APIException("User is not registered!");
            return true;
        }

        public bool SendConfirmationMessage(ReqEmpty req)
        {
            Provider.CurrentMember.Keyword = Utility.CreatePassword(16);
            Provider.CurrentMember.Save();

            Provider.CurrentMember.SendConfirmationCode();
            return true;
        }

        public bool ChangeForgottenPassword(ReqChangeForgottenPassword req)
        {
            if (string.IsNullOrWhiteSpace(req.Keyword))
                throw new APIException("Keyword required", ErrorTypes.ValidationError);
            if ((req.NewPassword ?? "").Length < 6)
                throw new APIException("Password length cannot be less than six", ErrorTypes.ValidationError);
            if (req.NewPassword != req.NewPasswordAgain)
                throw new APIException("Passwords not match", ErrorTypes.ValidationError);


            var member = Provider.Database.Read<Member>("Keyword = {0}", req.Keyword);
            if (member == null)
                throw new APIException("No such member with the keyword provided");


            try
            {
                member.Password = System.Utility.MD5(req.NewPassword);
                member.State = MemberStates.Confirmed;
                member.Keyword = "";
                member.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetRecoveryQuestion(string email)
        {
            if (!email.IsEmail())
                throw new APIException("Email address is invalid", ErrorTypes.ValidationError);



            var q = Provider.Database.GetString("select PasswordRecoveryQuestion from Member where Email = {0} AND IsDeleted = 0", email);
            if (!q.IsEmpty())
                return q;

            throw new APIException("No such email");
        }

        public ResLogin LoginWithRecoveryQuestion(ReqLoginWithRecoveryQuestion req)
        {
            if (!req.Email.IsEmail())
                throw new APIException("Email address is invalid", ErrorTypes.ValidationError);

            if (!string.IsNullOrWhiteSpace(Session.MemberId))
                return new ResLogin() { Member = Session.Member().ToEntityInfo<MemberInfo>(), SessionId = Session.Id };



            Member member = Provider.Database.Read<Member>("Email={0} AND PasswordRecoveryAnswer={1}", req.Email, req.Answer);
            if (member != null)
                return doLoginForMember(member);
            else
                throw new APIException("Wrong answer");
        }

        #endregion

        #region SMS

        public bool VerifyPhoneNumberSendSms(string phoneNumber)
        {
            SendSms smspak = new SendSms(ConfigurationManager.AppSettings["smsApiUserName"],
                                         ConfigurationManager.AppSettings["smsApiPassword"],
                                         ConfigurationManager.AppSettings["smsApiOrg"]);
            String[] number = { phoneNumber };

            string keyword = Utility.CreatePassword(6);
            smspak.addSMS(keyword, number);
            smspak.gonder();

            Provider.CurrentMember.Keyword = keyword;
            Provider.CurrentMember.Save();

            return true;
        }

        public bool VerifyPhoneNumber(ReqVerifyPhoneNumber req)
        {
            if (Provider.CurrentMember.Keyword == req.Keyword)
            {
                Provider.CurrentMember.GSMPhoneNumberVerified = true;
                Provider.CurrentMember.GsmPhoneNumber = req.PhoneNumber;
                Provider.CurrentMember.Save();

                return true;
            }

            else
                return false;
        }

        #endregion

        #region Mail

        public bool TestEmailAddress(ReqEmpty req)
        {
            var res = Provider.Api.ApiClient;
            string email = Provider.CurrentMember.Email;
            string fullName = Provider.CurrentMember.FullName;

            Utility.SendMail(res.MailFrom, res.Client().Name, email, fullName, "Test Mail", @"
                Dear " + fullName + ",<br/> <br/> This is a test mail sent by you.<br/> <br/> ", res.MailHost,
                             res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);

            return true;
        }

        public bool AddSecondEmailAddress(string secondEmail)
        {
            if (!secondEmail.IsEmail())
                throw new APIException("Invalid email address");

            if (Provider.CurrentMember.Email == secondEmail)
            {
                return false;
            }
            else
            {
                Provider.CurrentMember.AlternativeEmail = secondEmail;
                Provider.CurrentMember.Save();
                return true;
            }
        }

        #endregion
    }
}