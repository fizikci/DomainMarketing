using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Web;
using DealerSafe.DTO;
using DealerSafe.DTO.Domain;
using DealerSafe.DTO.Membership;
using DealerSafe.DTO.MobileBridge;
using ReqLogin = DealerSafe.DTO.MobileBridge.ReqLogin;

namespace DealerSafe.ServiceClient
{
    public class MobileBridgeAPI : BaseAPI
    {
        public MobileBridgeAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["MobileBridgeServiceURL"];
        }

       


        [Description("Search Funtion")]
        public RespSearch Search(ReqSearch req)
        {
            return this.Call<RespSearch, ReqSearch>(req, "Search");
            
        }

        [Description("Get Price List Funtion")]
        public List<RespPrices> GetPriceList(bool req)
        {
            return this.Call<List<RespPrices>, bool>(req, "GetPriceList");

        }

        [Description("Get News List Funtion")]
        public List<RespNews> GetNews(ReqParameter req)
        {
            return this.Call<List<RespNews>, ReqParameter>(req, "GetNews");

        }

        [Description("Get domain news insert time less than 72 hour for mobile")]
        public List<RespNews> GetDomainNewsListLessThan72Hour(ReqParameter req)
        {
            return Call<List<RespNews>, ReqParameter>(req, "GetDomainNewsListLessThan72Hour");
        }

        [Description("Get WhoIs Funtion")]
        public RespWhoIs WhoIs(string req)
        {
            return this.Call<RespWhoIs, string>(req, "WhoIs");

        }

        public List<RespDomains> GetDomains(string req)
        {
            return this.Call<List<RespDomains>, string>(req, "GetDomains");

        }

        public List<RespMemberContact> GetMemberContacts(int req)
        {
            return this.Call<List<RespMemberContact>, int>(req, "GetMemberContacts");
        }

        [Description("Login Funtion")]
        public RespLogin Login(ReqLogin req)
        {
            return this.Call<RespLogin, ReqLogin>(req, "Login");
        }

        [Description("SendTicket Funtion")]
        public RespResult SendTicket(ReqTicket req)
        {
            return this.Call<RespResult, ReqTicket>(req, "SendTicket");
        }


        public RespResult SendContactForm(ReqContactForm req)
        {
            return this.Call<RespResult, ReqContactForm>(req, "SendContactForm");
        }

        public RespDomainHunter GetDomainHunterList(ReqDomainHunter req)
        {
            return this.Call<RespDomainHunter, ReqDomainHunter>(req, "GetDomainHunterList");
        }

        [Description("Insert Member Contact Function")]
        public string InsertContact(RespMemberContact req)
        {
            return Call<string, RespMemberContact>(req, "InsertContact");
        }

        [Description("Edit Member Contact Function")]
        public string EditContact(RespMemberContact req)
        {
            return Call<string, RespMemberContact>(req, "EditContact");
        }

        [Description("Get Member Contact By ContactId Function")]
        public RespMemberContact GetMemberContactsById(int req)
        {
            return Call<RespMemberContact, int>(req, "GetMemberContactsById");
        }

        [Description("Update Member Email")]
        public string UpdateMemberEmail(MemberInfo req)
        {
            return Call<string, MemberInfo>(req, "UpdateMemberEmail");
        }

        [Description("Extention of domain time")]
        public List<RespDomains> GetRenewDomains(string req)
        {
             return Call<List<RespDomains>, string>(req, "GetRenewDomains");
        }

        [Description("Register new member")]
        public RespRegisterMember RegisterMember(ReqRegisterMember req)
        {
            return Call<RespRegisterMember, ReqRegisterMember>(req, "RegisterMember");
        }

        [Description("Register new member send mail")]
        public RespRegisterMemberSendMail RegisterMemberSendMail(ReqRegisterMemberSendMail req)
        {
            return Call<RespRegisterMemberSendMail, ReqRegisterMemberSendMail>(req, "RegisterMemberSendMail");
        }

        [Description("Get member info by memberid")]
        public MemberInfo GetMemberInfo(int req)
        {
            return Call<MemberInfo, int>(req, "GetMemberInfo");
        }

         [Description("Register new member send sms")]
        public RespRegisterMemberSendSms RegisterMemberSendSms(ReqRegisterMemberSendSms req)
        {
            return Call<RespRegisterMemberSendSms, ReqRegisterMemberSendSms>(req, "RegisterMemberSendSms");
        }

        public string Shake()
        {
            return Call<string, ReqEmpty>(new ReqEmpty(), "Shake");
        }

        [Description("Register new member Gsm approve")]
        public bool ConfirmGsm(MemberInfo parameters)
        {
            return Call<bool, MemberInfo>(parameters, "ConfirmGsm");
        }

        [Description("set default member contact")]
        public bool SetDefaultContact(ReqSetDefaultMemberContact req)
        {
            return Call<bool, ReqSetDefaultMemberContact>(req, "SetDefaultContact");
        }

        [Description("Add order on database")]
        public RespAddOrder AddOrder(ReqAddOrder req)
        {
            return Call<RespAddOrder, ReqAddOrder>(req, "AddOrder");
        }

        [Description("Returns suggested domain names for a given domain name.")]
        public RespSearch GetSuggestions(ReqGetSuggestions req)
        {
            return Call<RespSearch, ReqGetSuggestions>(req, "GetSuggestions");
        }


    }
}
