using System.Collections;
using Cinar.Database;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Common;
using System;
using System.Collections.Generic;
using DealerSafe2.DTO;
using DealerSafe2.DTO.Enums;
using DealerSafe2.API.Entity.Products.Domain;
using DealerSafe2.API.Api.Library;

namespace DealerSafe2.API.Entity.Members
{
    public class Member : BaseEntity, ICriticalEntity
    {
        public Member()
        {
            this.Keyword = Utility.CreatePassword(16);
        }

        [ColumnDetail(Length = 12)]
        public string ClientId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 50)]
        public MemberStates State { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 16)]
        public MemberTypes MemberType { get; set; }

        [ColumnDetail(Length = 12)]
        public string MemberAddressId { get; set; }
        [ColumnDetail(Length = 12)]
        public string LanguageId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ReferenceMemberId { get; set; }
        public string Keyword { get; set; }
        public string IdentityNo { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NewEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string GsmPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Avatar { get; set; }
        public string MemberRiskLevel { get; set; }
        public string GeoLocation { get; set; }
        public string CompanyInfo { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public string WebSite { get; set; }
        public string Locale { get; set; }
        public int TimeZone { get; set; }

        public string PasswordRecoveryQuestion { get; set; }
        public string PasswordRecoveryAnswer { get; set; }

        public DateTime LastLoginDate { get; set; }
        public DateTime CurrLoginDate { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 16)]
        public string Medal { get; set; }
        public bool GSMPhoneNumberVerified { get; set; }

        public bool IsStaffMember { get; set; }
        public Departments StaffDepartment { get; set; }
        public string AlternativeEmail { get; set; }

        public bool SuperUser { get; set; }
        [ColumnDetail(Length = 12)]
        public string StaffMemberId { get; set; }

        public int CreditBalance { get; set; }

        public int Rating { get; set; }


        public MemberAddress MemberAddress() { return Provider.ReadEntityWithRequestCache<MemberAddress>(MemberAddressId); }
        public Language Language() { return Provider.ReadEntityWithRequestCache<Language>(LanguageId); }
        public Member ReferenceMember() { return Provider.ReadEntityWithRequestCache<Member>(ReferenceMemberId); }
        public Client Client() { return Provider.ReadEntityWithRequestCache<Client>(ClientId); }
        public Member StaffMember() { return Provider.ReadEntityWithRequestCache<Member>(StaffMemberId); }
        public Reseller Reseller()
        {
            if (MemberType == MemberTypes.Reseller) 
                return Provider.ReadEntityWithRequestCache<Reseller>(Id);
            else 
                return null;
        }



        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public bool HasRight(Rights right)
        {
            return Provider.Database.GetBool("select count(*) from MemberRole where MemberId={0} AND RoleId in (select RoleId from RoleRight where [Right]={1})",
                Provider.CurrentMember.Id,
                right.ToString());
        }
        public bool HasRight(string rightName)
        {
            try
            {
                var right = (Rights) Enum.Parse(typeof (Rights), rightName);
                return HasRight(right);
            }
            catch
            {
                throw new APIException("Please add "+rightName+" to the Rights enumeration.");
            }
        }

        private List<MemberAddress> memberAddressList;
        public List<MemberAddress> GetMemberAddresses()
        {
            if (memberAddressList == null)
                memberAddressList = Provider.Database.ReadList<MemberAddress>("select * from MemberAddress where MemberId={0}", this.Id);

            return memberAddressList;
        }


        internal void SendEmailWithPasswordAndConfirmationCode()
        {
            var password = Utility.CreatePassword(6);
            this.Password = password.MD5();
            this.Keyword = Utility.CreatePassword(16);
            this.Save();

            var res = Provider.Api.ApiClient;
            string siteAddress = res.Url;

            Utility.SendMail(res.MailFrom, res.Client().Name, this.Email, this.FullName, "Welcome to SignSec ", @"
                Dear #{FullName},<br/>
                <br/>
                Your password: #{password}<br/>
                <br/>
                #{siteAddress}/
                ".EvaluateAsTemplate(new { FullName, password, siteAddress, Keyword }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
        }

        internal void SendEmailWithPassword()
        {
            var password = Utility.CreatePassword(6);
            this.Password = password.MD5();
            this.Save();

            var res = Provider.Api.ApiClient;
            string siteAddress = res.Url;

            Utility.SendMail(res.MailFrom, res.Client().Name, this.Email, this.FullName, "Welcome to SignSec ", @"
                Dear #{FullName},<br/>
                <br/>
                Your password: #{password}<br/>
                <br/>
                #{siteAddress}/
                ".EvaluateAsTemplate(new { FullName, password, siteAddress }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
        }

        internal void SendPasswordRecoveryMessage()
        {
            this.Keyword = Utility.CreatePassword(16);
            this.Save();

            var res = Provider.Api.ApiClient;
            string siteAddress = res.Url;

            Utility.SendMail(res.MailFrom, res.Client().Name, this.Email, this.FullName, "Your password", @"
                Dear #{FullName},<br/>
                <br/>
                Please follow this link to change your password:<br/>
                #{siteAddress}/ChangePassword.aspx?Keyword=#{Keyword}
                ".EvaluateAsTemplate(new { FullName, siteAddress, Keyword }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
        }

        internal void SendConfirmationCode()
        {
            var res = Provider.Api.ApiClient;
            string siteAddress = res.Url;

            Utility.SendMail(res.MailFrom, res.Client().Name, string.IsNullOrWhiteSpace(this.NewEmail) ? this.Email : this.NewEmail, this.FullName, "Your confirmation code", @"
                Dear #{FullName},<br/>
                <br/>
                Please follow this link to confirm your email address:<br/>
                #{siteAddress}/ConfirmEmail.aspx?Keyword=#{Keyword}
                ".EvaluateAsTemplate(new { FullName, siteAddress, Keyword }), res.MailHost, res.MailPort, res.MailUserName, res.MailPassword, res.MailFrom);
        }

        public Dictionary<string, int> GetAllRights()
        {
            var res = Provider.Database.GetDictionary<string,int>(@"
                                                        SELECT DISTINCT 
                                                            rr.[Right], 1
                                                        FROM 
                                                            RoleRight rr, Role r, MemberRole mr 
                                                        WHERE 
                                                            mr.MemberId={0} AND 
                                                            mr.RoleId=r.Id AND
                                                            rr.RoleId = r.Id
                                                        ORDER BY rr.[Right]", Id);
            return res;
        }

        private DomainDefaults domainDefaults = null;
        public DomainDefaults DomainDefaults(string domainName) {
            if (domainDefaults == null)
            {
                domainDefaults = Provider.ReadEntityWithRequestCache<DomainDefaultsForMember>(Id, "MemberId");
                if (domainDefaults == null)
                    domainDefaults = Provider.ReadEntityWithRequestCache<DomainDefaultsForClient>(ClientId, "ClientId");
                if (domainDefaults == null)
                {
                    var zone = DomainUtility.GetZoneFormDomainName(domainName);
                    domainDefaults = Provider.ReadEntityWithRequestCache<DomainDefaultsForZone>(zone.Id, "ZoneId");
                    if (domainDefaults == null)
                        domainDefaults = Provider.ReadEntityWithRequestCache<DomainDefaultsForClient>(zone.RegistryId, "RegistryId");
                }

                if (domainDefaults == null)
                    domainDefaults = new DomainDefaults();
            }
            return domainDefaults;
        }


        public MemberDomain CreateNewMemberDomain(string domainName, string orderItemId)
        {
            var memberDomain = new MemberDomain();
            memberDomain.DomainName = domainName;
            memberDomain.OrderItemId = orderItemId;
            memberDomain.AdminDomainContactId = DomainDefaults(domainName).AdminDomainContactId;
            memberDomain.BillingDomainContactId = DomainDefaults(domainName).BillingDomainContactId;
            memberDomain.OwnerDomainContactId = DomainDefaults(domainName).OwnerDomainContactId;
            memberDomain.TechDomainContactId = DomainDefaults(domainName).TechDomainContactId;
            memberDomain.RenewalMode = DomainDefaults(domainName).RenewalMode;
            memberDomain.TransferMode = DomainDefaults(domainName).TransferMode;
            memberDomain.PrivacyProtection = DomainDefaults(domainName).PrivacyProtection;
            memberDomain.NameServers = DomainDefaults(domainName).NameServers;
            memberDomain.AuthInfo = Utility.CreatePassword(8);
            memberDomain.Save();

            return memberDomain;
        }
    }


    public class ListViewMember : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Medal { get; set; }
        public string Email { get; set; }
        public string MemberType { get; set; }
        public string State { get; set; }

        public string StaffMemberId { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    public class ViewMember : Member
    {
        
    }
}
