using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using DealerSafe.DTO;
using DealerSafe.DTO.Dns;
using DealerSafe.DTO.Domain;
using DealerSafe.DTO.Domain.Register;
using DealerSafe.DTO.Domain.Renew;
using DealerSafe.DTO.Domain.Transfer;
using DealerSafe.DTO.Domain.TransferIn;
using DealerSafe.DTO.Domain.TransferOut;
using DealerSafe.DTO.Enums;
using DealerSafe.DTO.Epp.Response;
using ReqHostUpdate = DealerSafe.DTO.Domain.ReqHostUpdate;
using ResDomainTransfer = DealerSafe.DTO.Domain.Transfer.ResDomainTransfer;

namespace DealerSafe.ServiceClient
{
    public class DomainAPI : BaseAPI
    {
        public DomainAPI(int memberId)
        {
            this.memberId = memberId;
        }

        public DomainAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["domainServiceURL"];
        }

        #region DomainRegister

        public bool UpdateContactStatus(ReqUpdateContactStatus request)
        {
            return Call<bool, ReqUpdateContactStatus>(request, "UpdateContactStatus");
        }

        public bool UpdateDomainRegisterLogStatus(ReqUpdateDomainRegisterLogStatus request)
        {
            return Call<bool, ReqUpdateDomainRegisterLogStatus>(request, "UpdateDomainRegisterLogStatus");
        }

        public ResSaveDomainRegisterLog SaveDomainRegisterLog(DomainRegisterRegisterLogInfo log)
        {
            return Call<ResSaveDomainRegisterLog, DomainRegisterRegisterLogInfo>(log, "SaveDomainRegisterLog");
        }

        public List<DomainRegisterRegisterLogInfo> GetDomainRegisterLogs(ReqGetDomainRegisterLogs request)
        {
            return Call<List<DomainRegisterRegisterLogInfo>, ReqGetDomainRegisterLogs>(request, "GetDomainRegisterLogs");
        }

        public DomainRegisterRegisterLogInfo GetDomainRegisterLogById(ReqGetDomainRegisterLogById request)
        {
            return Call<DomainRegisterRegisterLogInfo, ReqGetDomainRegisterLogById>(request, "GetDomainRegisterLogById");
        }

        public List<ResGetIncorrectDomainsForMailing> GetIncorrectDomainsForMailing(ReqGetIncorrectDomainsForMailing request)
        {
            return Call<List<ResGetIncorrectDomainsForMailing>, ReqGetIncorrectDomainsForMailing>(request, "GetIncorrectDomainsForMailing");
        }

        public List<ResGetSuccessfullDomainsForMailing> GetSuccessfullDomainsForMailing(ReqGetSuccessfullDomainsForMailing request)
        {
            return Call<List<ResGetSuccessfullDomainsForMailing>, ReqGetSuccessfullDomainsForMailing>(request, "GetSuccessfullDomainsForMailing");
        }

        public List<ResGetDomainIds> GetDomainIds(ReqResGetDomainIds request)
        {
            return Call<List<ResGetDomainIds>, ReqResGetDomainIds>(request, "GetDomainIds");
        }

        public bool UpdateExtLaunch(ReqUpdateExtLaunch request)
        {
            return Call<bool, ReqUpdateExtLaunch>(request, "UpdateExtLaunch");
        }

        public ResGetDomainRegisterRequest GetDomainRegisterRequestWithReferenceId(ReqGetDomainRegisterRequestWithReferenceId request)
        {
            return Call<ResGetDomainRegisterRequest, ReqGetDomainRegisterRequestWithReferenceId>(request, "GetDomainRegisterRequestWithReferenceId");
        }

        public bool UpdateDomainRegisterRequestGeneralAvailableDate(ReqUpdateDomainRegisterRequestGeneralAvailableDate request)
        {
            return Call<bool, ReqUpdateDomainRegisterRequestGeneralAvailableDate>(request, "UpdateDomainRegisterRequestGeneralAvailableDate");
        }

        public bool IsActiveDomainDb(ReqIsActiveDomainDb request)
        {
            return Call<bool, ReqIsActiveDomainDb>(request, "IsActiveDomainDb");
        }

        public ResGetQueueIdByDomainId GetQueueIdByDomainId(ReqGetQueueIdByDomainId request)
        {
            return Call<ResGetQueueIdByDomainId, ReqGetQueueIdByDomainId>(request, "GetQueueIdByDomainId");
        }

        public ResUpdateQueueReportType UpdateQueueReportType(ReqUpdateQueueReportType request)
        {
            return Call<ResUpdateQueueReportType, ReqUpdateQueueReportType>(request, "UpdateQueueReportType");
        }

        public ResUpdateQueueReportTypeAndProcessType UpdateQueueReportTypeAndProcessType(ReqUpdateQueueReportTypeAndProcessType request)
        {
            return Call<ResUpdateQueueReportTypeAndProcessType, ReqUpdateQueueReportTypeAndProcessType>(request, "UpdateQueueReportTypeAndProcessType");
        }

        public ResRemoveFromQueue RemoveFromQueue(ReqRemoveFromQueue request)
        {
            return Call<ResRemoveFromQueue, ReqRemoveFromQueue>(request, "RemoveFromQueue");
        }

        public ResUpdateDomainNameServerRequest UpdateDomainNameServerRequest(ReqUpdateDomainNameServerRequest request)
        {
            return Call<ResUpdateDomainNameServerRequest, ReqUpdateDomainNameServerRequest>(request, "UpdateDomainNameServerRequest");
        }

        public ResUpdateDomainRegisterRequest UpdateDomainRegisterRequest(ReqUpdateDomainRegisterRequest request)
        {
            return Call<ResUpdateDomainRegisterRequest, ReqUpdateDomainRegisterRequest>(request, "UpdateDomainRegisterRequest");
        }

        public DomainRegisterContactInfo GetRegisterContactByDomainId(ReqGetRegisterContactByDomainId request)
        {
            return Call<DomainRegisterContactInfo, ReqGetRegisterContactByDomainId>(request, "GetRegisterContactByDomainId");
        }

        public bool UpdateDomainRegisterProcessType(ReqUpdateDomainRegisterProcessType request)
        {
            return Call<bool, ReqUpdateDomainRegisterProcessType>(request, "UpdateDomainRegisterProcessType");
        }

        public ResUpdateDomainNameservers UpdateDomainNameservers(ReqUpdateDomainNameservers request)
        {
            return Call<ResUpdateDomainNameservers, ReqUpdateDomainNameservers>(request, "UpdateDomainNameservers");
        }

        public ResGetDomainRegisterRequest GetDomainRegisterRequest(ReqGetDomainRegisterRequest request)
        {
            return Call<ResGetDomainRegisterRequest, ReqGetDomainRegisterRequest>(request, "GetDomainRegisterRequest");
        }

        public List<ResGetDomainRegisterRequest> GetDomainRegisterRequestList(ReqGetDomainRegisterRequestList request)
        {
            return Call<List<ResGetDomainRegisterRequest>, ReqGetDomainRegisterRequestList>(request, "GetDomainRegisterRequestList");
        }

        public bool ContactProcessOk(int referenceId)
        {
            return Call<bool, int>(referenceId, "ContactProcessOk");
        }

        public ResUpdateContact UpdateContactId(ReqUpdateContact request)
        {
            return Call<ResUpdateContact, ReqUpdateContact>(request, "UpdateContactId");
        }

        public DomainRegisterReferenceInfoDto GetReferenceInfoById(int refId)
        {
            return Call<DomainRegisterReferenceInfoDto, int>(refId, "GetReferenceInfoById");
        }

        public ResUpdateContact UpdateContact(DomainRegisterContactInfo request)
        {
            return Call<ResUpdateContact, DomainRegisterContactInfo>(request, "UpdateContact");
        }

        public ResDomainRegisterRequest SaveDomainRegisterRequest(ReqDomainRegisterRequest request)
        {
            return Call<ResDomainRegisterRequest, ReqDomainRegisterRequest>(request, "SaveDomainRegisterRequest");
        }

        public int SaveReferenceInfo(DomainRegisterReferenceInfoDto request)
        {
            return Call<int, DomainRegisterReferenceInfoDto>(request, "SaveReferenceInfo");
        }

        public ResSaveContact SaveContactInfo(DomainRegisterContactInfo request)
        {
            return Call<ResSaveContact, DomainRegisterContactInfo>(request, "SaveContactInfo");
        }

        public DomainRegisterContactInfo GetRegisterContactById(ReqGetRegisterContact request)
        {
            return Call<DomainRegisterContactInfo, ReqGetRegisterContact>(request, "GetRegisterContactById");
        }

        public DomainRegisterContactInfo GetRegisterContactByReferenceId(ReqGetRegisterContact request)
        {
            return Call<DomainRegisterContactInfo, ReqGetRegisterContact>(request, "GetRegisterContactByReferenceId");
        }

        public List<DomainRegisterContactInfo> GetRegisterContactList(ReqGetRegisterContactList request)
        {
            return Call<List<DomainRegisterContactInfo>, ReqGetRegisterContactList>(request, "GetRegisterContactList");
        }

        public List<string> GetDnsList(ReqGetDnsList request)
        {
            return Call<List<string>, ReqGetDnsList>(request, "GetDnsList");
        }

        public DomainRegisterReferenceInfoDto GetReferenceInfo(ReqGetReferenceInfo request)
        {
            return Call<DomainRegisterReferenceInfoDto, ReqGetReferenceInfo>(request, "GetReferenceInfo");
        }

        #endregion

        #region DomainRenew


        [Description("Domain Uzatma isteğini request tablosuna kaydet")]
        public string Renew(ReqRenewRequest request)
        {
            var response = Call<string, ReqRenewRequest>(request, "Renew");
            return response;
        }

        [Description("Domain Uzatma isteğini request tablosuna kaydet (Hata durumu)")]
        public string RenewCatch(ReqRenewRequest request)
        {
            var response = Call<string, ReqRenewRequest>(request, "RenewCatch");
            return response;
        }

        [Description("Uzatma işlemindeki hata mesajını getirir")]
        public DomainRenewLogDataResponse GetRenewErrorMessage(int domainId)
        {
            var response = Call<DomainRenewLogDataResponse, int>(domainId, "GetRenewErrorMessage");
            return response;
        }

        [Description("domain uzatma işlemi doğrulandığı zaman işlem bittiğinde pasife çekilir")]
        public bool UpdateDomainRenewTemp(ReqUpdateDomainRenewTemp request)
        {
            var response = Call<bool, ReqUpdateDomainRenewTemp>(request, "UpdateDomainRenewTemp");
            return response;
        }

        [Description("Rrpden durumu değiştirilmiş domainleri kontol ve update için kullanılır")]
        public List<ResGetDomainRenewCheckList> GetDomainRenewCheckList(ReqGetDomainRenewCheckList request)
        {
            var response = Call<List<ResGetDomainRenewCheckList>, ReqGetDomainRenewCheckList>(request, "GetDomainRenewCheckList");
            return response;
        }

        [Description("Domain uzatılabileceği tarih bilgisini döndürür")]
        public DateTime GetRenewalDate(string domainName)
        {
            var response = Call<DateTime, string>(domainName, "GetRenewalDate");
            return response;
        }

        [Description("Uzatılan domain statusunu değiştir. işlem bittiğinde pasife çekilir")]
        public bool UpdateDomainRenewStatus(ReqUpdateDomainRenewStatus request)
        {
            var response = Call<bool, ReqUpdateDomainRenewStatus>(request, "UpdateDomainRenewStatus");
            return response;
        }

        [Description("Uzatılan domain için sonuç değeri güncellenir")]
        public bool UpdateDomainRenewSuccess(ReqUpdateDomainRenewSuccess request)
        {
            var response = Call<bool, ReqUpdateDomainRenewSuccess>(request, "UpdateDomainRenewSuccess");
            return response;
        }

        [Description("Uzatılacak Domain satırını Getirir")]
        public DomainRenewRequestInfo GetDomainRenewRequestById(int request)
        {
            var response = Call<DomainRenewRequestInfo, int>(request, "GetDomainRenewRequestById");
            return response;
        }

        [Description("Uzatılacak Domain satırını sipariş ve domain id ile getirir")]
        public DomainRenewRequestInfo GetDomainRenewRequestByOrderId(ReqGetDomainRenewRequestByOrderId request)
        {
            var response = Call<DomainRenewRequestInfo, ReqGetDomainRenewRequestByOrderId>(request, "GetDomainRenewRequestByOrderId");
            return response;
        }

        [Description("Uzatılacak Domain Listesini Getirir")]
        public List<DomainRenewRequestInfo> GetDomainRenewRequests(ReqGetDomainRenewRequests request)
        {
            var response = Call<List<DomainRenewRequestInfo>, ReqGetDomainRenewRequests>(request, "GetDomainRenewRequests");
            return response;
        }

        [Description("Domain yenileme isteği işlem havuzuna kayıt edilir")]
        public bool UpdateDomainRenewRequest(DomainRenewRequestInfo request)
        {
            var response = Call<bool, DomainRenewRequestInfo>(request, "UpdateDomainRenewRequest");
            return response;
        }

        [Description("Domain yenileme isteği işlem havuzuna kayıt edilir")]
        public int SaveDomainRenewRequest(ReqSaveDomainRenewRequest request)
        {
            var response = Call<int, ReqSaveDomainRenewRequest>(request, "SaveDomainRenewRequest");
            return response;
        }

        [Description("Yapılan Uzatma işlemleri loglanır")]
        public bool SaveDomainRenewLogs(ReqDomainRenewLogs request)
        {
            var response = Call<bool, ReqDomainRenewLogs>(request, "SaveDomainRenewLogs");
            return response;
        }

        [Description("Domain tarihleri isimtescil firmasından alınır")]
        public ResGetDomainRegistirationDate GetDomainRegistirationDateFromOur(ReqGetDomainRegistirationDate request)
        {
            var response = Call<ResGetDomainRegistirationDate, ReqGetDomainRegistirationDate>(request,
                "GetDomainRegistirationDateFromOur");
            return response;
        }

        [Description("Domain tarihleri kayıt firmasından alınır")]
        public ResGetDomainRegistirationDate GetDomainRegistirationDateFromRc(ReqGetDomainRegistirationDate request)
        {
            var response = Call<ResGetDomainRegistirationDate, ReqGetDomainRegistirationDate>(request,
                "GetDomainRegistirationDateFromRc");
            return response;
        }

        [Description("Domain Info kayıt firmasından alınır")]
        public List<string> GetDomainStatus(ReqGetDomainStatus request)
        {
            var response = Call<List<string>, ReqGetDomainStatus>(request, "GetDomainStatus");
            return response;
        }

        [Description("İşlem yapılacak domain için ödeme aktifliği kontrol edilir")]
        public bool CheckPaymentActivity(ReqCheckPaymentActivity request)
        {
            var response = Call<bool, ReqCheckPaymentActivity>(request, "CheckPaymentActivity");
            return response;
        }

        [Description("İşlem başarısız ise kuyruğa gönderilir.")]
        public bool UpdateDomainRenewalQueue(ReqUpdateDomainQueue request)
        {
            var response = Call<bool, ReqUpdateDomainQueue>(request, "UpdateDomainRenewalQueue");
            return response;
        }

        [Description("İşlem başarısız ise kuyruğa gönderilir.")]
        public bool RemoveDomainRenewalQueue(ReqRemoveDomainQueue request)
        {
            var response = Call<bool, ReqRemoveDomainQueue>(request, "RemoveDomainRenewalQueue");
            return response;
        }

        [Description("Domain Uzatma işleminde domain satırını güncellemek için kullanılır")]
        public bool UpdateDomainForRenewal(ReqUpdateDomainForRenewal request)
        {
            var response = Call<bool, ReqUpdateDomainForRenewal>(request, "UpdateDomainForRenewal");
            return response;
        }

        [Description("Domain Uzat")]
        public ResDomainAutoRenew DomainAutoRenew(ReqDomainAutoRenew request)
        {
            var response = Call<ResDomainAutoRenew, ReqDomainAutoRenew>(request, "DomainAutoRenew");
            return response;
        }

        [Description("Kuyruğa Atılan işlem için kuyruk id'si döndürür")]
        public int GetQueueId(ReqGetQueue request)
        {
            var response = Call<int, ReqGetQueue>(request, "GetQueueId");
            return response;
        }

        #endregion

        [Description("Update member dns list")]
        public bool UpdateMemberDnsList(int dnsId, string dns1, string dns2, string dns3, string dns4)
        {
            ReqUpdateMemberDnsList request = new ReqUpdateMemberDnsList()
            {
                Dns1 = dns1,
                Dns2 = dns2,
                Dns3 = dns3,
                Dns4 = dns4,
                DnsId = dnsId
            };

            var response = Call<bool, ReqUpdateMemberDnsList>(request, "UpdateMemberDnsList");
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dns1"></param>
        /// <param name="dns2"></param>
        /// <param name="dns3"></param>
        /// <param name="dns4"></param>
        /// <param name="addingStatus">0: Not first dns, 1:firstDns</param>
        /// <returns></returns>
        [Description("Insert new record MemberDNSList tablosuna insert")]
        public int AddToMemberDnsList(string dns1, string dns2, string dns3, string dns4, int addingStatus)
        {
            ReqAddToMemberDnsList request = new ReqAddToMemberDnsList()
            {
                AddingStatus = addingStatus,
                Dns1 = dns1,
                Dns2 = dns2,
                Dns3 = dns3,
                Dns4 = dns4
            };

            var response = Call<int, ReqAddToMemberDnsList>(request, "AddToMemberDnsList");
            return response;
        }

        [Description("Get a members MemberDnsList")]
        public List<MemberDnsListTo> GetMembersDnsList()
        {
            var response = Call<List<MemberDnsListTo>, ReqEmpty>(new ReqEmpty(), "GetMembersDnsList");
            return response;
        }

        [Description("Returns company nameservers by domain extension")]
        public List<string> GetCompanyNameServers(string domainExtension)
        {
            var response = Call<List<string>, string>(domainExtension, "GetCompanyNameServers");
            return response;
        }

        [Description("Returns a domains name")]
        public string GetDomainName(int domainId)
        {
            var response = Call<string, int>(domainId, "GetDomainName");
            return response;
        }

        [Description("Get a domains remote hosts and update on database")]
        public List<ChildNameServerTo> GetDomainHosts(int domainId)
        {
            ReqGetDomainHosts request = new ReqGetDomainHosts()
            {
                DomainId = domainId
            };

            var response = Call<List<ChildNameServerTo>, ReqGetDomainHosts>(request, "GetDomainHosts");
            return response;
        }

        [Description("Create a contact and return contact id")]
        public string HostCreate(int domainId, string cns, string ip)
        {
            ReqHostCreate request = new ReqHostCreate()
            {
                Cns = cns,
                DomainId = domainId,
                Ip = ip
            };

            var response = Call<string, ReqHostCreate>(request, "HostCreate");

            return response;
        }

        [Description("Delete an existing host name.")]
        public string HostDelete(int nameServerId, int domainId)
        {
            ReqHostDelete request = new ReqHostDelete
            {
                DomainId = domainId,
                NameServerId = nameServerId
            };

            var response = Call<string, ReqHostDelete>(request, "HostDelete");
            return response;
        }

        [Description("Update name of a child name server")]
        public string HostUpdateName(string newCns, int nameServerId, int domainId)
        {
            ReqHostUpdate request = new ReqHostUpdate
            {
                DomainId = domainId,
                NameServerId = nameServerId,
                NewCns = newCns
            };

            var response = Call<string, ReqHostUpdate>(request, "HostUpdateName");
            return response;
        }

        [Description("Update ip of a child name server")]
        public string HostUpdateIp(string newIp, int nameServerId, int domainId)
        {
            ReqHostUpdate request = new ReqHostUpdate
            {
                DomainId = domainId,
                NameServerId = nameServerId,
                NewIp = newIp
            };

            var response = Call<string, ReqHostUpdate>(request, "HostUpdateIp");
            return response;
        }

        [Description("Update a domains dns adress")]
        public string UpdateDomainDns(int domainId, string dns1, string dns2, string dns3, string dns4)
        {
            ReqUpdateDomainDns request = new ReqUpdateDomainDns()
            {
                DomainDns1 = dns1,
                DomainDns2 = dns2,
                DomainDns3 = dns3,
                DomainDns4 = dns4,
                DomainId = domainId
            };

            var response = Call<string, ReqUpdateDomainDns>(request, "UpdateDomainDns");
            return response;
        }

        [Description("Get a domains current nameservers")]
        public List<string> GetDomainsDns(int domainId)
        {
            ReqGetDomainDns request = new ReqGetDomainDns()
            {
                DomainId = domainId
            };

            var response = Call<List<string>, ReqGetDomainDns>(request, "GetDomainsDns");

            return response;
        }

        [Description("Returns suggested domain names for a given domain name.")]
        public List<DomainQueryResult> DomainQuery(string domainNames, string tlds, bool isNameSurname = false, bool isIdn = false, bool isSummaryDomain = true)
        {
            ReqDomainQuery request = new ReqDomainQuery { DomainNames = domainNames, TLDs = tlds, NameSurname = isNameSurname, IsIDN = isIdn, IsSummaryDomain = isSummaryDomain };
            return Call<ResDomainQuery, ReqDomainQuery>(request, "DomainQuery").DomainQueryResults;
        }

        [Description("Returns suggested domain names for a given domain name.")]
        public string GetSuggestions(string domainName)
        {
            ReqGetSuggestions request = new ReqGetSuggestions { DomainName = domainName };
            return Call<ResGetSuggestions, ReqGetSuggestions>(request, "GetSuggestions").Suggestions;
        }

        [Description("Returns protected contact info")]
        public ResProtectedContact GetProtectedContactInfo(string domainName, int resellerId)
        {
            ReqProtectedContact request = new ReqProtectedContact { DomainName = domainName, ResellerId = resellerId };
            return Call<ResProtectedContact, ReqProtectedContact>(request, "GetProtectedContact");
        }

        [Description("Returns members transfers")]
        public List<MembersDomainTransferInfo> GetTransfersByMember()
        {
            return Call<ResDomainTransfer, ReqEmpty>(new ReqEmpty(), "GetTransfersByMember").ListTransferData;
        }

        [Description("Returns All Members Transfer Domain Secret Control ")]
        public List<Transfer_Control> GetTransferAllPasswordControl()
        {
            return Call<ResTransferAllPasswordControl, ReqEmpty>(new ReqEmpty(), "GetTransferAllPasswordControl").Mlll;
        }

        [Description("Update a domains selected Id's")]
        public bool UpdateDomainDnsId(int domainId, int dnsId, int selectedDnsId)
        {
            ReqUpdateDomainDnsId request = new ReqUpdateDomainDnsId()
            {
                DomainId = domainId,
                DnsId = dnsId,
                SelectedDnsId = selectedDnsId
            };

            return Call<bool, ReqUpdateDomainDnsId>(request, "UpdateDomainDnsId");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dnsId"></param>
        /// <param name="dnsType">1: default, 2: specific, enum in BCIT.cDns.enmDnsType </param>
        /// <returns></returns>
        [Description("Get Members MemberDNSList info and returns Dns's")]
        public List<string> SetMemberDnsListInfo(int dnsId, int dnsType)
        {
            ReqSetMemberDnsListInfo request = new ReqSetMemberDnsListInfo()
            {
                DnsId = dnsId,
                DnsType = dnsType
            };

            var response = Call<List<string>, ReqSetMemberDnsListInfo>(request, "SetMemberDnsListInfo");
            return response;
        }

        [Description("Get Privacy Protection status from Directi")]
        public string GetPrivacyProtectionStatusFromDirecti(int directiOrderId)
        {
            var response = Call<string, int>(directiOrderId, "GetPrivacyProtectionStatusFromDirecti");
            return response;
        }

        [Description("Set Privacy Protection status to Directi")]
        public string SetPrivacyProtectionToDirecti(int directiOrderId, string lockerId, string reason, bool toLock)
        {
            ReqSetPrivacyProtectionToDirecti request = new ReqSetPrivacyProtectionToDirecti()
            {
                DirectiOrderId = directiOrderId,
                LockerId = lockerId,
                Reason = reason,
                ToLock = toLock
            };

            var response = Call<string, ReqSetPrivacyProtectionToDirecti>(request, "SetPrivacyProtectionToDirecti");

            return response;
        }

        [Description("Update Privacy Protection Status of a domain, statuses : Disabled = 0, Enabled = 1, NoInfo = 2, EnabledByWhoisHider = 3")]
        public bool UpdateDomainPrivacyStatus(int domainId, int protectionStatus)
        {
            ReqUpdateDomainPrivacyStatus request = new ReqUpdateDomainPrivacyStatus()
            {
                DomainId = domainId,
                ProtectionStatus = protectionStatus
            };

            var response = Call<bool, ReqUpdateDomainPrivacyStatus>(request, "UpdateDomainPrivacyStatus");
            return response;
        }

        [Description("Disable Privacy Protection"), Category("Domain")]
        public string DirectiDisablePrivacyProtection(ReqDirectiDisablePrivacyProtection request)
        {
            return Call<string, ReqDirectiDisablePrivacyProtection>(request, "DirectiDisablePrivacyProtection");
        }

        [Description("Return Members Dns Other Company by domain and memberId")]
        public MembersDNSOtherCompanyTo GetMembersDnsOtherCompanyByDomainAndMember(int domainId)
        {
            var response = Call<MembersDNSOtherCompanyTo, int>(domainId, "GetMembersDnsOtherCompanyByDomainAndMember");
            return response;
        }

        [Description("Return Members Dns Other Company by domain")]
        public MembersDNSOtherCompanyTo GetMembersDnsOtherCompanyByDomainAndMemberByName(string DomainName)
        {
            var response = Call<MembersDNSOtherCompanyTo, string>(DomainName, "GetMembersDnsOtherCompanyByDomainAndMemberByName");
            return response;
        }

        [Description("Is Simple Dns Active?")]
        public bool IsSimpleDns()
        {
            var response = Call<bool, ReqEmpty>(new ReqEmpty(), "IsSimpleDns");
            return response;

        }

        [Description("PowerDNSNS Name servers")]
        public List<string> PowerDNSNS()
        {
            var response = Call<DnsName, ReqEmpty>(new ReqEmpty(), "PowerDNSNS");
            return response.NamesList;
        }

        [Description("Return is isimtescil dns")]
        public bool GetIsIsimtescilDns(string ns)
        {
            var response = Call<bool, string>(ns, "GetIsIsimtescilDns");
            return response;

        }

        [Description("set dns type")]
        public bool SetDnsServerTypeDomainById(int userId, int DomainId, EnmDnsServerType type)
        {
            ReqSetDnsServerTypeDomainById request = new ReqSetDnsServerTypeDomainById()
            {
                userId = userId,
                DomainId = DomainId,
                type = type
            };

            var response = Call<bool, ReqSetDnsServerTypeDomainById>(request, "SetDnsServerTypeDomainById");
            return response;
        }

        [Description("Get zone by domain name using Simple Dns")]
        public string SimpleDnsGetZoneByDomainName(string domainName, int? serverId = null, bool? isPower = null)
        {
            ReqDomainNameAndServerId request = new ReqDomainNameAndServerId()
            {
                DomainName = domainName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqDomainNameAndServerId>(request, "SimpleDnsGetZoneByDomainName");
            return response;
        }

        [Description("Update A record by simpleDns")]
        public string SimpleDnsUpdateARecord(string domainName, string oldRecordName, string oldRecordInfo, string newRecordName, string newIPAddress, int? serverId = null, bool? isPower = null)
        {
            ReqUpdateARecord request = new ReqUpdateARecord()
            {
                DomainName = domainName,
                NewIPAddress = newIPAddress,
                NewRecordName = newRecordName,
                OldIPAddress = oldRecordInfo,
                OldRecordName = oldRecordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqUpdateARecord>(request, "SimpleDnsUpdateARecord");
            return response;
        }

        [Description("Update MX record by simpledns")]
        public string SimpleDnsUpdateMXRecord(string domainName, string oldRecordName, string oldPriority, string oldMailServer, string newPrority, string newMailServer, int? serverId = null, bool? isPower = null)
        {
            ReqUpdateMXRecord request = new ReqUpdateMXRecord()
            {
                DomainName = domainName,
                NewMailServer = newMailServer,
                NewPriority = newPrority,
                OldMailServer = oldMailServer,
                OldPriority = oldPriority,
                OldRecordName = oldRecordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqUpdateMXRecord>(request, "SimpleDnsUpdateMXRecord");
            return response;
        }

        [Description("Update NS record by simple dns")]
        public string SimpleDnsUpdateNSRecord(string domainName, string recordName, string oldNs, string newNs, int? serverId = null, bool? isPower = null)
        {
            ReqUpdateNSRecord request = new ReqUpdateNSRecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                OldNs = oldNs,
                NewNs = newNs,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqUpdateNSRecord>(request, "SimpleDnsUpdateNSRecord");
            return response;
        }

        [Description("Update CName record by simple dns")]
        public string SimpleDnsUpdateCNameRecord(string domainName, string recordName, string oldRecordData, string newRecordData, int? serverId = null, bool? isPower = null)
        {
            ReqUpdateCNameRecord request = new ReqUpdateCNameRecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                OldRecordData = oldRecordData,
                NewRecordData = newRecordData,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqUpdateCNameRecord>(request, "SimpleDnsUpdateCNameRecord");
            return response;
        }

        [Description("Update TXT Record by simple dns")]
        public string SimpleDnsUpdateTXTRecord(string domainName, string oldRecordName, string[] oldTxtRecord, string[] newTxtRecord, int? serverId = null, bool? isPower = null)
        {
            ReqUpdateTXTRecord request = new ReqUpdateTXTRecord()
            {
                DomainName = domainName,
                NewTxtRecord = newTxtRecord,
                OldRecordName = oldRecordName,
                OldTxtRecord = oldTxtRecord,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqUpdateTXTRecord>(request, "SimpleDnsUpdateTXTRecord");
            return response;
        }

        [Description("Update Spf Record by simple dns")]
        public string SimpleDnsUpdateSPFRecord(string domainName, string oldRecordName, string[] oldTxtRecord, string[] newTxtRecord, int? serverId = null, bool? isPower = null)
        {
            ReqUpdateSPFRecord request = new ReqUpdateSPFRecord()
            {
                DomainName = domainName,
                NewTxtRecord = newTxtRecord,
                OldRecordName = oldRecordName,
                OldTxtRecord = oldTxtRecord,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqUpdateSPFRecord>(request, "SimpleDnsUpdateSPFRecord");
            return response;
        }

        [Description("Remove an A Record by simple dns")]
        public string SimpleDnsRemoveARecord(string domainName, string recordName, string ipAdress, int? serverId = null, bool? isPower = null)
        {
            ReqARecord request = new ReqARecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                IpAdress = ipAdress,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqARecord>(request, "SimpleDnsRemoveARecord");
            return response;
        }

        [Description("Remove an MX Record by simple dns")]
        public string SimpleDnsRemoveMXRecord(string domainName, string recordName, string priority, string mailServer, int? serverId = null, bool? isPower = null)
        {
            ReqMXRecord request = new ReqMXRecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                Priority = priority,
                MailServer = mailServer,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqMXRecord>(request, "SimpleDnsRemoveMXRecord");
            return response;
        }

        [Description("Remove a Ns Record by simple dns")]
        public string SimpleDnsRemoveNSRecord(string domainName, string recordName, string nsServerName, int? serverId = null, bool? isPower = null)
        {
            ReqNSRecord request = new ReqNSRecord()
            {
                DomainName = domainName,
                NsServerName = nsServerName,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqNSRecord>(request, "SimpleDnsRemoveNSRecord");
            return response;
        }

        [Description("Remove a Cname record by simple dns")]
        public string SimpleDnsRemoveCNameRecord(string domainName, string recordName, string recordData, int? serverId = null, bool? isPower = null)
        {
            ReqCNameRecord request = new ReqCNameRecord()
            {
                DomainName = domainName,
                RecordData = recordData,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqCNameRecord>(request, "SimpleDnsRemoveCNameRecord");
            return response;
        }

        [Description("Remove a TXT record")]
        public string SimpleDnsRemoveTXTRecord(string domainName, string recordName, string[] oldTxtRecord, int? serverId = null, bool? isPower = null)
        {
            ReqTxtRecord request = new ReqTxtRecord()
            {
                DomainName = domainName,
                RecordData = oldTxtRecord,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqTxtRecord>(request, "SimpleDnsRemoveTXTRecord");
            return response;
        }

        [Description("Remove a SPF record")]
        public string SimpleDnsRemoveSPFRecord(string domainName, string recordName, string[] oldTxtRecord, int? serverId = null, bool? isPower = null)
        {
            ReqSpfRecord request = new ReqSpfRecord()
            {
                DomainName = domainName,
                RecordData = oldTxtRecord,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqSpfRecord>(request, "SimpleDnsRemoveSPFRecord");
            return response;
        }

        [Description("Remove a SRV record")]
        public string SimpleDnsRemoveSRVRecord(string domainName, string recordName, string currentPriority, string currentWeight, string currentMxPort, string currentHost, int? serverId = null, bool? isPower = null)
        {
            ReqRemoveSrvRecord request = new ReqRemoveSrvRecord()
            {
                DomainName = domainName,
                CurrentHost = currentHost,
                CurrentMxPort = currentMxPort,
                CurrentPriority = currentPriority,
                CurrentWeight = currentWeight,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqRemoveSrvRecord>(request, "SimpleDnsRemoveSRVRecord");
            return response;
        }

        [Description("Delete zone with domain name")]
        public string SimpleDnsRemoveZone(string domainName, int? serverId = null, bool? isPower = null)
        {
            ReqDomainNameAndServerId request = new ReqDomainNameAndServerId()
            {
                DomainName = domainName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqDomainNameAndServerId>(request, "SimpleDnsRemoveZone");
            return response;
        }

        [Description("Add new A record")]
        public string SimpleDnsAddARecord(string domainName, string recordName, string ipAdress, int? serverId = null, bool? isPower = null)
        {
            ReqARecord request = new ReqARecord()
            {
                DomainName = domainName,
                IpAdress = ipAdress,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqARecord>(request, "SimpleDnsAddARecord");
            return response;
        }

        [Description("Add new MX Record")]
        public string SimpleDnsAddMXRecord(string domainName, string recordName, string priority, string mailServer, int? serverId = null, bool? isPower = null)
        {
            ReqMXRecord request = new ReqMXRecord()
            {
                DomainName = domainName,
                MailServer = mailServer,
                Priority = priority,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqMXRecord>(request, "SimpleDnsAddMXRecord");
            return response;
        }

        [Description("Add new NS Record")]
        public string SimpleDnsAddNSRecord(string domainName, string recordName, string nsServerName, int? serverId = null, bool? isPower = null)
        {
            ReqNSRecord request = new ReqNSRecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                NsServerName = nsServerName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqNSRecord>(request, "SimpleDnsAddNSRecord");
            return response;
        }

        [Description("Add new CName record by simple dns")]
        public string SimpleDnsAddCNameRecord(string domainName, string recordName, string recordData, int? serverId = null, bool? isPower = null)
        {
            ReqCNameRecord request = new ReqCNameRecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                RecordData = recordData,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqCNameRecord>(request, "SimpleDnsAddCNameRecord");
            return response;
        }

        [Description("Add new TXT record by simple dns")]
        public string SimpleDnsAddTXTRecord(string domainName, string recordName, string[] recordData, int? serverId = null, bool? isPower = null)
        {
            ReqTxtRecord request = new ReqTxtRecord()
            {
                DomainName = domainName,
                RecordData = recordData,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqTxtRecord>(request, "SimpleDnsAddTXTRecord");
            return response;
        }

        public string SimpleDnsAddSPFRecord(string domainName, string recordName, string[] recordData, int? serverId = null, bool? isPower = null)
        {
            ReqSpfRecord request = new ReqSpfRecord()
            {
                DomainName = domainName,
                RecordData = recordData,
                RecordName = recordName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqSpfRecord>(request, "SimpleDnsAddSPFRecord");
            return response;
        }

        [Description("MembersHostDns tablosundan domain adina gore host id'sini verir")]
        public int GetHostIdByDomain(string domainName)
        {
            var response = Call<int, string>(domainName, "GetHostIdByDomain");
            return response;
        }

        [Description("Returns tbl dns records by domain type")]
        public List<TblDnsTo> GetDnsByDomainType(string domainTipi)
        {
            var response = Call<List<TblDnsTo>, string>(domainTipi, "GetDnsByDomainType");
            return response;
        }

        [Description("Returns DnsList")]
        public List<DnsList> GetNewDnsByDomainType(int domainType, int dnsType)
        {
            var response = Call<List<DnsList>, ReqGetNewDnsByDomainType>(new ReqGetNewDnsByDomainType() { DomainType = domainType, DnsType = dnsType }, "GetNewDnsByDomainType");
            return response;
        }

        [Description("Returns DnsList")]
        public List<DnsList> GetNewDnsByDomainTypeExtName(string domainExt, int domainType)
        {
            var response = Call<List<DnsList>, ReqGetNewDnsByDomainTypeExtName>(new ReqGetNewDnsByDomainTypeExtName() { DomainExtension = domainExt, DnsType = domainType }, "GetNewDnsByDomainTypeExtName");
            return response;
        }

        [Description("Returns DnsList")]
        public List<DnsList> GetNewDnsByDomainTypeDomainId(int DomainId)
        {
            var response = Call<List<DnsList>, int>(DomainId, "GetNewDnsByDomainTypeDomainId");
            return response;
        }

        [Description("Returns DnsList")]
        public List<DnsList> GetNewDnsByDomainTypeOtherDomain(string DomainName)
        {
            var response = Call<List<DnsList>, string>(DomainName, "GetNewDnsByDomainTypeOtherDomain");
            return response;
        }

        [Description("Returns DnsList")]
        public List<DnsList> GetNewDnsByDomainTypeOtherDomainId(int DomainId)
        {
            var response = Call<List<DnsList>, int>(DomainId, "GetNewDnsByDomainTypeOtherDomainId");
            return response;
        }

        [Description("Returns DnsList")]
        public List<DnsList> GetNewDnsByMemberAndDomain(int MemberId, string Domain)
        {
            var response = Call<List<DnsList>, ReqGetNewDnsByMemberAndDomain>(new ReqGetNewDnsByMemberAndDomain() { MemberId = MemberId, Domain = Domain }, "GetNewDnsByMemberAndDomain");
            return response;
        }

        [Description("Domain-Hosting-IP-Tabanli-DNS-Yonetimi sayfasinda bulunan Domain Dns Update metodu, hata olmaz ise '' donecektir")]
        public string UpdateDomainDnsForHostingPage(int domainId, string dns1, string dns2, string dns3, string dns4)
        {
            ReqUpdateDomainDns request = new ReqUpdateDomainDns()
            {
                DomainDns1 = dns1,
                DomainDns2 = dns2,
                DomainDns3 = dns3,
                DomainDns4 = dns4,
                DomainId = domainId
            };

            var response = Call<string, ReqUpdateDomainDns>(request, "UpdateDomainDnsForHostingPage");
            return response;
        }

        [Description("MembersDns tablosunda dns adreslerini günceller")]
        public bool UpdateDomainDnsInDb(int domainId, string dns1, string dns2, string dns3, string dns4)
        {
            ReqUpdateDomainDns request = new ReqUpdateDomainDns()
            {
                DomainDns1 = dns1,
                DomainDns2 = dns2,
                DomainDns3 = dns3,
                DomainDns4 = dns4,
                DomainId = domainId
            };

            var response = Call<bool, ReqUpdateDomainDns>(request, "UpdateDomainDnsInDb");
            return response;
        }

        [Description("Returns general plesk dns id")]
        public string GetPleskDnsIdGeneral(string hostIp)
        {
            var response = Call<string, string>(hostIp, "GetPleskDnsIdGeneral");
            return response;
        }

        [Description("Returns tblDns table record by key")]
        public TblDnsTo GetDnsById(int dnsId)
        {
            var response = Call<TblDnsTo, int>(dnsId, "GetDnsById");
            return response;
        }

        [Description("Add new zone by simple dns")]
        public string SimpleDnsAddZone(string domainName, string primaryNS, string hostMasterMail, int defaultTtl, int MinTtl, int zoneGroupId, int? serverId = null, bool? isPower = null)
        {
            ReqAddZone request = new ReqAddZone()
            {
                DefaultTtl = defaultTtl,
                DomainName = domainName,
                HostMasterMail = hostMasterMail,
                MinimumTtl = MinTtl,
                PrimaryNameServer = primaryNS,
                ZoneGroupId = zoneGroupId,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqAddZone>(request, "SimpleDnsAddZone");
            return response;
        }

        [Description("Add new zone by simple dns")]
        public bool SimpleDnsAddZoneWithServerId(string domainName, int? serverId = null, bool? isPower = null)
        {
            ReqDomainNameAndServerId request = new ReqDomainNameAndServerId()
            {
                DomainName = domainName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<bool, ReqDomainNameAndServerId>(request, "SimpleDnsAddZoneWithServerId");
            return response;
        }

        [Description("Add new zone by simple dns")]
        public bool SimpleDnsAddZoneWithRecordId(string domainName, string dnsRecordId, int? serverId = null, bool? isPower = null)
        {
            ReqDomainNameAndDnsRecordId request = new ReqDomainNameAndDnsRecordId()
            {
                DnsRecordId = dnsRecordId,
                DomainName = domainName,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<bool, ReqDomainNameAndDnsRecordId>(request, "SimpleDnsAddZoneWithRecordId");
            return response;
        }

        [Description("Remove simple dns zone")]
        public string SimpleDnsRemoveRecord(string domainName, string recordName, string recordType, string[] recordData, int? serverId = null, bool? isPower = null)
        {
            ReqRemoveSimpleDnsRecord request = new ReqRemoveSimpleDnsRecord()
            {
                DomainName = domainName,
                RecordName = recordName,
                RecordType = recordType,
                RecordData = recordData,
                ServerId = serverId,
                isPower = isPower
            };

            var response = Call<string, ReqRemoveSimpleDnsRecord>(request, "SimpleDnsRemoveRecord");
            return response;
        }

        [Description("Returns hosting type name by product id")]
        public string GetHostingTypeName(int productId)
        {
            var response = Call<string, int>(productId, "GetHostingTypeName");
            return response;
        }

        [Description("Returns mail server by id")]
        public tblMailServersTo GetMailServerById(int id)
        {
            var response = Call<tblMailServersTo, int>(id, "GetMailServerById");
            return response;
        }

        [Description("Returns plesk netscaler ip by hosting ip")]
        public string GetPleskNetScalerId(string hostIp)
        {
            var response = Call<string, string>(hostIp, "GetPleskNetScalerId");
            return response;
        }

        [Description("Returns plesk dns id general by product id")]
        public string GetPleskDnsIDGeneralByProductId(int productId)
        {
            var response = Call<string, int>(productId, "GetPleskDnsIDGeneralByProductId");
            return response;
        }

        [Description("Returns plesk dns id for de and ru by product id")]
        public string GetPleskDNSIDForDeAndRuByProductId(int productId)
        {
            var response = Call<string, int>(productId, "GetPleskDNSIDForDeAndRuByProductId");
            return response;
        }

        [Description("Returns plesk dns id for de and ru by hosting ip")]
        public string GetPleskDDNSIDForDeAndRuByHostingIp(string hostIp)
        {
            var response = Call<string, string>(hostIp, "GetPleskDDNSIDForDeAndRuByHostingIp");
            return response;
        }

        [Description("Returns Domain name by hostdns and hosting ip")]
        public string GetDomainNameByHostDnsAndHost(int hostDnsId, int hostingId)
        {
            ReqHostDnsAndHosting request = new ReqHostDnsAndHosting()
            {
                hostDnsId = hostDnsId,
                hostingId = hostingId
            };

            var response = Call<string, ReqHostDnsAndHosting>(request, "GetDomainNameByHostDnsAndHost");
            return response;
        }

        [Description("Get Hosting id by host dns id")]
        public int GetHostingIdByHostDnsId(int hostDnsId)
        {
            var response = Call<int, int>(hostDnsId, "GetHostingIdByHostDnsId");
            return response;
        }

        [Description("Get Domain name from MembersDNSOtherCompany table")]
        public string GetDomainNameFromMembersDNSOtherCompany(int domainId)
        {
            var response = Call<string, int>(domainId, "GetDomainNameFromMembersDNSOtherCompany");
            return response;
        }

        [Description("Get Domain ID by name and activity")]
        public int GetDomainIdByNameAndActivity(string domainName, int activity)
        {
            ReqDomainNameAndActivity request = new ReqDomainNameAndActivity()
            {
                Activity = activity,
                DomainName = domainName
            };

            var response = Call<int, ReqDomainNameAndActivity>(request, "GetDomainIdByNameAndActivity");
            return response;
        }

        [Description("Track contact info")]
        public string TrackContactInfo(string contactId, int domainId)
        {
            ReqTrackContactInfo request = new ReqTrackContactInfo()
            {
                ContactId = contactId,
                DomainId = domainId
            };

            var response = Call<string, ReqTrackContactInfo>(request, "TrackContactInfo");
            return response;
        }

        [Description("Return contact details by registry id")]
        public DomainContactsTo GetDomainContactByIdRegistry(int contactIdRegistry)
        {
            var response = Call<DomainContactsTo, int>(contactIdRegistry, "GetDomainContactByIdRegistry");
            return response;
        }

        [Description("Insert new Domain Contact")]
        public int InsertDomainContact(DomainContactsTo dContact)
        {
            var response = Call<int, DomainContactsTo>(dContact, "InsertDomainContact");
            return response;
        }

        [Description("Returns Memberdns by domain Id")]
        public MembersDnsTo GetMemberDnsById(int domainId)
        {
            var response = Call<MembersDnsTo, int>(domainId, "GetMemberDnsById");
            return response;
        }

        [Description("Update a Member Dns(domain) status")]
        public bool UpdateMemberDnsStatus(int domainId, string status)
        {
            ReqDomainIdAndStatus request = new ReqDomainIdAndStatus()
            {
                DomainId = domainId,
                Status = status
            };

            var response = Call<bool, ReqDomainIdAndStatus>(request, "UpdateMemberDnsStatus");
            return response;
        }



        [Description("Update a domains secret")]
        public bool UpdateMemberDnsSecret(int domainId, string secret)
        {
            ReqDomainIdAndSecret request = new ReqDomainIdAndSecret()
            {
                DomainId = domainId,
                Secret = secret
            };

            var response = Call<bool, ReqDomainIdAndSecret>(request, "UpdateMemberDnsSecret");
            return response;
        }

        [Description("Create new Transfer Log record")]
        public bool CreateTransferLog(int memberId, int domainId, string infoStatus, string error)
        {
            DomainTransferLogTo request = new DomainTransferLogTo()
            {
                DomainId = domainId,
                MemberId = memberId,
                Error = error,
                InfoStatus = infoStatus
            };

            var response = Call<bool, DomainTransferLogTo>(request, "CreateTransferLog");
            return response;
        }

        [Description("Get first xxx code by domain Id")]
        public string GetFirstXXXCodeByDomain(int domainId)
        {
            var response = Call<string, int>(domainId, "GetFirstXXXCodeByDomain");
            return response;
        }

        [Description("Associate xxx domain with code from directi")]
        public bool DirectiAssociateXXX(string directiOrderId, string code, string domainName)
        {
            ReqDirectiOrderIdAndCode request = new ReqDirectiOrderIdAndCode()
            {
                Code = code,
                DirectiOrderId = directiOrderId,
                DomainName = domainName
            };

            var response = Call<bool, ReqDirectiOrderIdAndCode>(request, "DirectiAssociateXXX");
            return response;
        }

        [Description("Create new XXX Code in db")]
        public bool InsertXXXCode(string code, int domainId)
        {
            XXXCodeTo xxx = new XXXCodeTo()
            {
                Code = code,
                DomainId = domainId
            };

            var response = Call<bool, XXXCodeTo>(xxx, "InsertXXXCode");
            return response;
        }

        [Description("Get Nic tr Query Ticket Status")]
        public NicTrTicketStatusTo NicTrQueryTicketStatus(string ticketNumber)
        {
            var response = Call<NicTrTicketStatusTo, string>(ticketNumber, "NicTrQueryTicketStatus");
            return response;
        }

        [Description("Return MemberDnsList by its id")]
        public MemberDnsListTo GetMemberDnsListById(int dnsId)
        {
            var response = Call<MemberDnsListTo, int>(dnsId, "GetMemberDnsListById");
            return response;
        }

        [Description("Delete a child name server record by id")]
        public bool DeleteChildNameServer(int cnsId)
        {
            var response = Call<bool, int>(cnsId, "DeleteChildNameServer");
            return response;
        }

        [Description("Add new child name server to database")]
        public bool AddChildNameServer(int domainId, string cNsName, string iPAdres)
        {
            ChildNameServerTo cNameServer = new ChildNameServerTo()
            {
                CNSName = cNsName,
                DomainID = domainId,
                IPAdres = iPAdres
            };

            var response = Call<bool, ChildNameServerTo>(cNameServer, "AddChildNameServer");
            return response;
        }

        [Description("Get first memberdns recort by name")]
        public MembersDnsTo GetDomainByName(string domainName)
        {
            var response = Call<MembersDnsTo, string>(domainName, "GetDomainByName");
            return response;
        }

        [Description("Return membersdns domain name to extension")]
        public string GetDomainByExtension(string domainName)
        {
            var response = Call<string, string>(domainName, "GetDomainByExtension");
            return response;
        }

        [Description("Return membersdns domain name to extension")]
        public string GetDomainByExtensionById(int DomainId)
        {
            var response = Call<string, int>(DomainId, "GetDomainByExtensionById");
            return response;
        }

        [Description("Return membersdns domain name to which dns server, 1 to simple dns, 2 to powerdns")]
        public EnmDnsServerType GetDomainByWhichDnsServerByName(string domainName)
        {
            var response = Call<EnmDnsServerType, string>(domainName, "GetDomainByWhichDnsServerByName");
            return response;
        }

        [Description("Return membersdns domain id to which dns server, 1 to simple dns, 2 to powerdns")]
        public EnmDnsServerType GetDomainByWhichDnsServerById(int Id)
        {
            var response = Call<EnmDnsServerType, int>(Id, "GetDomainByWhichDnsServerById");
            return response;
        }

        [Description("Delete all child name server in db belongs to a domain id")]
        public bool DeleteChildNameServerByDomainId(int domainId)
        {
            var response = Call<bool, int>(domainId, "DeleteChildNameServerByDomainId");
            return response;
        }

        [Description("Domain-Hosting-IP-Tabanli-DNS-Yonetimi sayfasinda bulunan Domain Dns Update metodu, hata olmaz ise '' donecektir")]
        public string UpdateDomainDnsForNotOtherCompany(int domainId, string dns1, string dns2, string dns3, string dns4)
        {
            ReqUpdateDomainDns request = new ReqUpdateDomainDns()
            {
                DomainDns1 = dns1,
                DomainDns2 = dns2,
                DomainDns3 = dns3,
                DomainDns4 = dns4,
                DomainId = domainId
            };

            var response = Call<string, ReqUpdateDomainDns>(request, "UpdateDomainDnsForNotOtherCompany");
            return response;
        }

        [Description("Domain-Hosting-IP-Tabanli-DNS-Yonetimi sayfasinda bulunan Domain Dns Update metodu, hata olmaz ise '' donecektir")]
        public string UpdateDomainDnsForHostingId(int domainId, string dns1, string dns2, string dns3, string dns4)
        {
            ReqUpdateDomainDns request = new ReqUpdateDomainDns()
            {
                DomainDns1 = dns1,
                DomainDns2 = dns2,
                DomainDns3 = dns3,
                DomainDns4 = dns4,
                DomainId = domainId
            };

            var response = Call<string, ReqUpdateDomainDns>(request, "UpdateDomainDnsForHostingId");
            return response;
        }


        [Description("Lock domain in directi")]
        public ResTextAndResult LockDomain(int domainId)
        {
            var response = Call<ResTextAndResult, int>(domainId, "LockDomain");
            return response;
        }

        [Description("Unlock domain")]
        public ResTextAndResult UnLockDomain(int domainId)
        {
            var response = Call<ResTextAndResult, int>(domainId, "UnLockDomain");
            return response;
        }

        [Description("Is this domain belongs to this user")]
        public bool CheckDomainMemberRelation(int domainId)
        {
            var response = Call<bool, int>(domainId, "CheckDomainMemberRelation");
            return response;
        }

        [Description("Get My Domain by domainId")]
        public MyDomainTo GetMyDomainById(int domainId)
        {
            var response = Call<MyDomainTo, int>(domainId, "GetMyDomainById");
            return response;
        }

        [Description("Get Count by member Id and domain name from tables MembersHostDns, MembersHost")]
        public int GetMemberHostCount(string domainName)
        {
            var response = Call<int, string>(domainName, "GetMemberHostCount");
            return response;
        }

        [Description("Get Plesk Server Ip from db or by ping")]
        public string GetPleskServerIp(string domainName)
        {
            var response = Call<string, string>(domainName, "GetPleskServerIp");
            return response;
        }

        [Description("Return dataset of plesk servers by ip adresses")]
        public System.Data.DataSet GetPleskServersByIpAdress(string Ip)
        {
            var response = Call<System.Data.DataSet, string>(Ip, "GetPleskServersByIpAdress");
            return response;
        }



        [Description("Get DataView of MembersHost table by domainName and MemberId")]
        public System.Data.DataView MembersHOSTByDomainName(string DomainName)
        {
            var response = Call<System.Data.DataView, string>(DomainName, "MembersHOSTByDomainName");
            return response;
        }

        [Description("Get Plesk Server Ip from database or by pinging")]
        public string GetPleskServerIpByDomainNameAndActivity(string DomainName, int Activity)
        {
            ReqDomainNameAndActivity request = new ReqDomainNameAndActivity()
            {
                Activity = Activity,
                DomainName = DomainName
            };

            var response = Call<string, ReqDomainNameAndActivity>(request, "GetPleskServerIpByDomainNameAndActivity");
            return response;
        }

        [Description("Update a MemberDns'es contact ids")]
        public bool UpdateMembersDNSContId(int domainID, int RegistryContId, int AdminContId, int TechContId, int BillContId)
        {
            ReqDomainNameAndContacts request = new ReqDomainNameAndContacts()
            {
                AdminContId = AdminContId,
                BillContId = BillContId,
                DomainId = domainID,
                RegistrContId = RegistryContId,
                TechContId = TechContId
            };

            var response = Call<bool, ReqDomainNameAndContacts>(request, "UpdateMembersDNSContId");
            return response;
        }

        [Description("Call GetHostingCount function in database by domainname ")]
        public System.Data.DataTable GetHostingCountByDomainName(string domainName)
        {
            var response = Call<System.Data.DataTable, string>(domainName, "GetHostingCountByDomainName");
            return response;
        }

        [Description("Return member id from table MembersDNSOtherCompany by id")]
        public string GetMemberIdFromDNSOtherCompanyByKey(int id)
        {
            var response = Call<string, int>(id, "GetMemberIdFromDNSOtherCompanyByKey");
            return response;
        }

        [Description("Return a datatable contains ids of ODTU Domains in a list")]
        public System.Data.DataTable GetODTUDomainIdsByMemberInList(string IDs)
        {
            var response = Call<System.Data.DataTable, string>(IDs, "GetODTUDomainIdsByMemberInList");
            return response;
        }

        [Description("Delete record in membersdns by id")]
        public bool DeleteMemberDns(int id)
        {
            var response = Call<bool, int>(id, "DeleteMemberDns");
            return response;
        }

        [Description("Delete record in deletedmembersdns by id")]
        public bool DeleteDeletedMemberDns(int id)
        {
            var response = Call<bool, int>(id, "DeleteDeletedMemberDns");
            return response;
        }

        [Description("Delete Domain Passwords by domain id")]
        public bool DeleteDomainPasswordsByDomainId(int domainId)
        {
            var response = Call<bool, int>(domainId, "DeleteDomainPasswordsByDomainId");
            return response;
        }

        [Description("Delete under construction records by domain id")]
        public bool DeleteUnderConstructionsByDomainId(int domainId)
        {
            var response = Call<bool, int>(domainId, "DeleteUnderConstructionsByDomainId");
            return response;
        }

        [Description("Delete direction records by domain id")]
        public bool DeleteDirectionsByDomainId(int domainId)
        {
            var response = Call<bool, int>(domainId, "DeleteDirectionsByDomainId");
            return response;
        }

        [Description("Get Counts of MemberDns'es by activity")]
        public int GetMemberDnsCountByInActivity(List<int> activities)
        {
            var response = Call<int, List<int>>(activities, "GetMemberDnsCountByInActivity");
            return response;
        }

        [Description("Get Counts of MemberDns'es by nor activity")]
        public int GetMemberDnsCountByNotInActivity(List<int> activities)
        {
            var response = Call<int, List<int>>(activities, "GetMemberDnsCountByNotInActivity");
            return response;
        }

        [Description("Get Counts of MemberDns'es by activity with day filter")]
        public int GetMemberDnsCountByInActivityLastDay(int day, List<int> activities)
        {
            ReqDayAndActivities request = new ReqDayAndActivities()
            {
                Activities = activities,
                DayCount = day
            };

            var response = Call<int, ReqDayAndActivities>(request, "GetMemberDnsCountByInActivityLastDay");
            return response;
        }

        [Description("Get Counts of MemberDns'es by deleted")]
        public int GetMembersDnsCountByDeleted()
        {
            return Call<int, ReqEmpty>(new ReqEmpty(), "GetMembersDnsCountByDeleted");
        }

        [Description("Check is this domain group saved before for this member")]
        public bool IsExistDomainGroupByName(string groupName)
        {
            var response = Call<bool, string>(groupName, "IsExistDomainGroupByName");
            return response;
        }

        [Description("Add new Domain Group for this member")]
        public bool AddDomainGroup(string groupName)
        {
            var response = Call<bool, string>(groupName, "AddDomainGroup");
            return response;
        }

        [Description("Update a domain groups name")]
        public bool UpdateDomainGroupName(int id, string newGroupName)
        {
            ReqIdAndName request = new ReqIdAndName()
            {
                Id = id,
                Name = newGroupName
            };

            var response = Call<bool, ReqIdAndName>(request, "UpdateDomainGroupName");
            return response;
        }

        [Description("Delete a domain group by its primary key, check if member has this domain group")]
        public bool DeleteDomainGroup(int groupId)
        {
            var response = Call<bool, int>(groupId, "DeleteDomainGroup");
            return response;
        }

        [Description("Update many domains group at the same time")]
        public bool UpdateMemberDnsGroup(int groupID, string ids)
        {
            ReqIdAndName request = new ReqIdAndName()
            {
                Id = groupID,
                Name = ids
            };

            var response = Call<bool, ReqIdAndName>(request, "UpdateMemberDnsGroup");
            return response;
        }

        [Description("Is there any record with this domain name in MembersDNSOtherCompany")]
        public bool IsExistMembersDNSOtherCompanyName(string domainName)
        {
            var response = Call<bool, string>(domainName, "IsExistMembersDNSOtherCompanyName");
            return response;
        }

        [Description("Is there any record with this domain name and activity in MemberDns table")]
        public bool IsExistMembersDNSNameAndActivity(string domainName, int activity)
        {
            ReqDomainNameAndActivity request = new ReqDomainNameAndActivity()
            {
                Activity = activity,
                DomainName = domainName
            };

            var response = Call<bool, ReqDomainNameAndActivity>(request, "IsExistMembersDNSNameAndActivity");
            return response;
        }

        [Description("Get nic tr online document by id as datatable")]
        public System.Data.DataTable GetNictrOnlineDocumentById(string id)
        {
            var response = Call<System.Data.DataTable, string>(id, "GetNictrOnlineDocumentById");
            return response;
        }

        [Description("Delete nic tr online document by id")]
        public bool DeleteNictrOnlineDocument(string id)
        {
            var response = Call<bool, string>(id, "DeleteNictrOnlineDocument");
            return response;
        }

        [Description("Set objects price property and return back")]
        public MyDomainTo SetMyDomainPrice(MyDomainTo myDom)
        {
            var response = Call<MyDomainTo, MyDomainTo>(myDom, "SetMyDomainPrice");
            return response;
        }

        [Description("Get HireDurationControl, HireDurationFinish, HireDurationSpecific, HireDurationCustom,ExpirePeriod fields from DomainTypes table")]
        public System.Data.DataTable GetHireAndExpireFromDomainTypes(string productId)
        {
            var response = Call<System.Data.DataTable, string>(productId, "GetHireAndExpireFromDomainTypes");
            return response;
        }

        [Description("Get premium tv domains by domain name")]
        public System.Data.DataTable GetPremiumTvDomains(string domainName)
        {
            var response = Call<System.Data.DataTable, string>(domainName, "GetPremiumTvDomains");
            return response;
        }

        [Description("Get Nictr online documnet by domain id")]
        public System.Data.DataTable GetNictrOnlineDocumentByDomainId(int domainId)
        {
            var response = Call<System.Data.DataTable, int>(domainId, "GetNictrOnlineDocumentByDomainId");
            return response;
        }

        [Description("Returns list of premium domains")]
        public List<PremiumTvDomainTo> GetPremiumTvDomainsList(string domainName)
        {
            var response = Call<List<PremiumTvDomainTo>, string>(domainName, "GetPremiumTvDomainsList");
            return response;
        }

        [Description("Check domain can be trasnfer in its register company")]
        public string CheckDomainTransferForCompany(string transferCompanyID, string domainName)
        {
            ReqDomainNameAndCompanyId request = new ReqDomainNameAndCompanyId()
            {
                CompanyId = int.Parse(transferCompanyID),
                DomainName = domainName
            };

            var response = Call<string, ReqDomainNameAndCompanyId>(request, "CheckDomainTransferForCompany");
            return response;
        }

        [Description("Return a members domain groups as DataTable")]
        public System.Data.DataTable GetDomainGroupOfMember()
        {
            var response = Call<System.Data.DataTable, ReqEmpty>(new ReqEmpty(), "GetDomainGroupOfMember");
            return response;
        }

        [Description("Nictr cancel update name server")]
        public string NictrCancelUpdateNameServer(string nicTrTicketStatus)
        {
            var response = Call<string, string>(nicTrTicketStatus, "NictrCancelUpdateNameServer");
            return response;
        }

        [Description("Nictr update name server and returns ticket number, if error return '' ")]
        public string NictrUpdateNameServer(string domain, string[] DNSs, string[] IPs)
        {
            ReqNictrUpdateNameServer request = new ReqNictrUpdateNameServer()
            {
                DNSs = DNSs,
                domain = domain,
                IPs = IPs
            };

            var response = Call<string, ReqNictrUpdateNameServer>(request, "NictrUpdateNameServer");
            return response;
        }


        [Description("Update MemberDns Table record process")]
        public bool UpdateMemberDnsProcess(int domainId, int process)
        {
            ReqDomainIdAndProcess request = new ReqDomainIdAndProcess()
            {
                DomainId = domainId,
                Process = process
            };

            var response = Call<bool, ReqDomainIdAndProcess>(request, "UpdateMemberDnsProcess");
            return response;
        }

        [Description("Delete a record from Under Construction table with Other Company Id and Domain Id")]
        public bool DeleteUnderConstructionsByDomainAndOtherCompanyId(int domainId, int otherCompanyId)
        {
            ReqDomainIdAndCompanyId request = new ReqDomainIdAndCompanyId()
            {
                CompanyId = otherCompanyId,
                DomainId = domainId
            };

            var response = Call<bool, ReqDomainIdAndCompanyId>(request, "DeleteUnderConstructionsByDomainAndOtherCompanyId");
            return response;
        }

        [Description("Delete direction by domain id and othercompany")]
        public bool DeleteDirectionByDomainIdAndOtherCompany(int domainId, int otherCompanyId)
        {
            ReqDomainIdAndCompanyId request = new ReqDomainIdAndCompanyId()
            {
                CompanyId = otherCompanyId,
                DomainId = domainId
            };

            var response = Call<bool, ReqDomainIdAndCompanyId>(request, "DeleteDirectionByDomainIdAndOtherCompany");
            return response;
        }

        [Description("Get Users Refference Member By Key")]
        public int GetRefferenceMemberByKey(int userId)
        {
            var response = Call<int, int>(userId, "GetRefferenceMemberByKey");
            return response;
        }

        [Description("Get Domain User By Key")]
        public DomainUsersTo GetDomainUserByKey(int userId)
        {
            var response = Call<DomainUsersTo, int>(userId, "GetDomainUserByKey");
            return response;
        }

        [Description("Update Password of domain user")]
        public bool UpdateDomainUserPassword(int userId, string password)
        {
            ReqUserIdAndPassword request = new ReqUserIdAndPassword()
            {
                Password = password,
                UserId = userId
            };

            var response = Call<bool, ReqUserIdAndPassword>(request, "UpdateDomainUserPassword");
            return response;
        }

        [Description("Delete Domain User")]
        public bool DeleteDomainUserByUserId(int userId)
        {
            var response = Call<bool, int>(userId, "DeleteDomainUserByUserId");
            return response;
        }

        [Description("CQueue Check Domain Exist")]
        public bool CQueueCheckDomainExist(int queueProcessTypeId, int queueReportTypeId, int domainId, int orderId)
        {
            ReqCQueueCheckDomain request = new ReqCQueueCheckDomain()
            {
                DomainId = domainId,
                OrderId = orderId,
                QueueProcessTypeId = queueProcessTypeId,
                QueueReportTypeId = queueReportTypeId
            };

            var response = Call<bool, ReqCQueueCheckDomain>(request, "CQueueCheckDomainExist");
            return response;
        }

        [Description("CQueue Add Domain Exist")]
        public bool CQueueAddToQueue(int queueProcessTypeId, int queueReportTypeId, int domainId, int orderId, int productDetailId)
        {
            ReqCQueueAddDomain request = new ReqCQueueAddDomain()
            {
                DomainId = domainId,
                OrderId = orderId,
                QueueProcessTypeId = queueProcessTypeId,
                QueueReportTypeId = queueReportTypeId,
                ProductDetailId = productDetailId
            };

            var response = Call<bool, ReqCQueueAddDomain>(request, "CQueueAddToQueue");
            return response;
        }

        [Description("Delete domain contact by Id")]
        public bool DeleteDomainContact(int domContactId)
        {
            var response = Call<bool, int>(domContactId, "DeleteDomainContact");
            return response;
        }

        [Description("Get Dataview of tblDNS table by pkDNSID")]
        public System.Data.DataView GetTblDnsViewBypkDNSID(string pkDNSID)
        {
            var response = Call<System.Data.DataView, string>(pkDNSID, "GetTblDnsViewBypkDNSID");
            return response;
        }

        [Description("Get Dataview of tblDNS table by domain type")]
        public TblDnsTo GetTblDnsViewByDomainType(string domainType)
        {
            var response = Call<TblDnsTo, string>(domainType, "GetTblDnsViewByDomainType");
            return response;
        }

        [Description("Update Member Dns Nic tr ticket")]
        public bool UpdateMemberDnsNicTrTicket(int domainId, string ticketNumber)
        {
            ReqDomainIdAndTicketNumber request = new ReqDomainIdAndTicketNumber()
            {
                DomainId = domainId,
                TicketNumber = ticketNumber
            };

            var response = Call<bool, ReqDomainIdAndTicketNumber>(request, "UpdateMemberDnsNicTrTicket");
            return response;
        }

        [Description("Return Simple Dns Host Group value")]
        public int GetSimpleDnsHostGroup()
        {
            var response = Call<int, ReqEmpty>(new ReqEmpty(), "GetSimpleDnsHostGroup");
            return response;
        }

        [Description("Return Simple Dns Domain Group value")]
        public int GetSimpleDnsDomainGroup()
        {
            var response = Call<int, ReqEmpty>(new ReqEmpty(), "GetSimpleDnsDomainGroup");
            return response;
        }

        [Description("cIDN cozumleme islemi")]
        public string CIDNCozumle(string domainName)
        {
            var response = Call<string, string>(domainName, "CIDNCozumle");
            return response;
        }

        [Description("cIDN sifreleme islemi")]
        public string CIDNSifrele(string domainName)
        {
            var response = Call<string, string>(domainName, "CIDNSifrele");
            return response;
        }

        [Description("Getting Domain Id from MembersDns table with paremeters domainName, product Id and activities")]
        public int GetDomainIdByNameAndActivityListAndProductId(string domainName, int productId, int[] activities)
        {
            ReqDomainNameAndActivityAndProductId request = new ReqDomainNameAndActivityAndProductId()
            {
                DomainName = domainName,
                Activities = activities,
                ProductId = productId
            };

            var response = Call<int, ReqDomainNameAndActivityAndProductId>(request, "GetDomainIdByNameAndActivityListAndProductId");
            return response;
        }

        [Description("Update Member Dns'es activity by domain id")]
        public bool UpdateMemberDnsActivity(int domainId, int activity)
        {
            ReqDomainIdAndActivity request = new ReqDomainIdAndActivity()
            {
                Activity = activity,
                DomainId = domainId
            };

            var response = Call<bool, ReqDomainIdAndActivity>(request, "UpdateMemberDnsActivity");
            return response;
        }

        [Description("Return DomainType by its id")]
        public DomainTypeTo GetDomainTypeByKey(int id)
        {
            var response = Call<DomainTypeTo, int>(id, "GetDomainTypeByKey");
            return response;
        }

        [Description("Return DomainType by its name")]
        public DomainTypeTo GetDomainTypeByName(string domainRoot)
        {
            var response = Call<DomainTypeTo, string>(domainRoot, "GetDomainTypeByName");
            return response;
        }

        [Description("Return GetContactCompatibility by its name")]
        public int GetContactCompatibility(string tld)
        {
            var response = Call<int, string>(tld, "GetContactCompatibility");
            return response;
        }

        [Description("Tbl Direction By DomainId")]
        public List<tblDirectionTo> GetTblDirectionByDomainId(int domainId)
        {
            var response = Call<List<tblDirectionTo>, int>(domainId, "GetTblDirectionByDomainId");
            return response;
        }

        [Description("Tbl Direction By DomainId and Is Other Company Parameter")]
        public List<tblDirectionTo> GetTblDirectionByDomainIdAndIsOtherCompany(int domainId, int isOtherCompany)
        {
            ReqDomainIdAndOtherCompany request = new ReqDomainIdAndOtherCompany()
            {
                DomainId = domainId,
                IsOtherCompany = isOtherCompany
            };

            var response = Call<List<tblDirectionTo>, ReqDomainIdAndOtherCompany>(request, "GetTblDirectionByDomainIdAndIsOtherCompany");
            return response;
        }

        [Description("Return Simle Dns Redirect group value")]
        public int GetSimpleDnsRedirectGroup()
        {
            var response = Call<int, ReqEmpty>(new ReqEmpty(), "GetSimpleDnsRedirectGroup");
            return response;
        }

        [Description("Insert new tbl direction")]
        public bool InsertTblDirection(tblDirectionTo tbl)
        {
            var response = Call<bool, tblDirectionTo>(tbl, "InsertTblDirection");
            return response;
        }

        [Description("Update new tbl direction")]
        public bool UpdateTblDirection(tblDirectionTo tbl)
        {
            var response = Call<bool, tblDirectionTo>(tbl, "UpdateTblDirection");
            return response;
        }

        [Description("Delete Domain User Relation")]
        public bool DeleteDomainUserRelation(int userId, int domainId)
        {
            ReqDomainIdAndUserId request = new ReqDomainIdAndUserId()
            {
                DomainId = domainId,
                UserId = userId
            };

            var response = Call<bool, ReqDomainIdAndUserId>(request, "DeleteDomainUserRelation");
            return response;
        }

        [Description("Delete Domain user Relation by domain id")]
        public bool DeleteDomainUserRelationByDomainId(int domainId)
        {
            var response = Call<bool, int>(domainId, "DeleteDomainUserRelationByDomainId");
            return response;
        }

        [Description("Insert new Domain User Relation")]
        public int InsertDomainUserRelations(int userId, int domainId)
        {
            ReqDomainIdAndUserId request = new ReqDomainIdAndUserId()
            {
                DomainId = domainId,
                UserId = userId
            };

            var response = Call<int, ReqDomainIdAndUserId>(request, "InsertDomainUserRelations");
            return response;
        }

        [Description("Insert new Domain Users and Return Id")]
        public int InsertDomainUsers(string username, string password)
        {
            ReqUserNameAndPassword request = new ReqUserNameAndPassword()
            {
                UserName = username,
                Password = password
            };

            var response = Call<int, ReqUserNameAndPassword>(request, "InsertDomainUsers");
            return response;
        }

        [Description("Get Domain UserId By User Name")]
        public int GetDomainUserIdByUserName(string username)
        {
            var response = Call<int, string>(username, "GetDomainUserIdByUserName");
            return response;
        }

        [Description("Get Id of Member By Domain Name From MemberDNSOtherCompany table")]
        public int GetMemberIdFromDNSOtherCompanyByDomainName(int domainId)
        {
            var response = Call<int, int>(domainId, "GetMemberIdFromDNSOtherCompanyByDomainName");
            return response;
        }

        [Description("Get Id of Member By Which Dns Server From MemberDNSOtherCompany table")]
        public int GetMemberIdFromDNSOtherCompanyByWhichDnsServer(int domainId)
        {
            var response = Call<int, int>(domainId, "GetMemberIdFromDNSOtherCompanyByWhichDnsServer");
            return response;
        }

        [Description("GetDNSOtherCompanyByExtension")]
        public string GetDNSOtherCompanyByExtension(string extension)
        {
            var response = Call<string, string>(extension, "GetDNSOtherCompanyByExtension");
            return response;
        }

        [Description("Get registered domain counts to show off")]
        public RegisteredDomainCounts GetRegisteredDomainCounts()
        {
            return Call<RegisteredDomainCounts, ReqEmpty>(new ReqEmpty(), "GetRegisteredDomainCounts");
        }

        [Description("Returns domain types (tlds) for the main page domain query check boxes")]
        public List<DomainTypeInfo> GetDomainTypes()
        {
            return Call<List<DomainTypeInfo>, ReqEmpty>(new ReqEmpty(), "GetDomainTypes");
        }

        [Description("Returns My Domain with name like example.com")]
        public MyDomainTo GetMyDomainByName(string domainName)
        {
            return Call<MyDomainTo, string>(domainName, "GetMyDomainByName");
        }

        [Description("Returns My Domain with member mail")]
        public string GetMyDomainByMemberEMail(int memberId)
        {
            return Call<string, int>(memberId, "GetMyDomainByMemberEMail");
        }

        [Description("Get Contact Email by Contact Id from table MemberContacts")]
        public string GetContactEmailById(int contactId)
        {
            return Call<string, int>(contactId, "GetContactEmailById");
        }

        [Description("Returns email of contact from register company")]
        public string GetContactEmailFromId(int domainId, string contactId)
        {
            ReqDomainIdAndContactId request = new ReqDomainIdAndContactId()
            {
                ContactId = contactId,
                DomainId = domainId
            };

            var response = Call<string, ReqDomainIdAndContactId>(request, "GetContactEmailFromId");
            return response;
        }

        [Description("Add new Whois hider log")]
        public bool AddWhoisHiderLog(WhoisHiderLogTo log)
        {
            var response = Call<bool, WhoisHiderLogTo>(log, "AddWhoisHiderLog");
            return response;
        }

        [Description("Add new Whois Contact Us log")]
        public bool AddWhoisContactUsLog(WhoisContactUsLogTo log)
        {
            var response = Call<bool, WhoisContactUsLogTo>(log, "AddWhoisContactUsLog");
            return response;
        }

        [Description("Update Email adress of Domain Contact")]
        public bool UpdateDomainContactEmail(int id, string email)
        {
            var request = new ReqIdAndEmail()
            {
                Email = email,
                Id = id
            };

            var response = Call<bool, ReqIdAndEmail>(request, "UpdateDomainContactEmail");
            return response;
        }

        [Description("Get Domain Contact by id")]
        public tblDomainContactTo GetDomainContactById(int tblDomainContactId)
        {
            var response = Call<tblDomainContactTo, int>(tblDomainContactId, "GetDomainContactById");
            return response;
        }

        [Description("Return directi order id by name")]
        public int GetDirectiOrderIdByName(string domainName)
        {
            var response = Call<int, string>(domainName, "GetDirectiOrderIdByName");
            return response;
        }

        [Description("Register new contact on directi and return contact id")]
        public string DirectiRegisterContact(RegisterContactTo request)
        {
            var response = Call<string, RegisterContactTo>(request, "DirectiRegisterContact");
            return response;
        }

        [Description("Modify Register contact on directi and return message")]
        public string DirectiModifyRegisterContact(ModifyRegisterContactTo modContactTo)
        {
            var response = Call<string, ModifyRegisterContactTo>(modContactTo, "DirectiModifyRegisterContact");
            return response;
        }

        [Description("Add new contact Rrp")]
        public string AddRrpContact(RegisterContactTo registerContactTo)
        {
            var response = Call<string, RegisterContactTo>(registerContactTo, "AddRrpContact");
            return response;
        }

        [Description("Update domain's contact id's")]
        public string ModifyRrpDomainContact(ReqDomainAndContacts request)
        {
            var response = Call<string, ReqDomainAndContacts>(request, "ModifyRrpDomainContact");
            return response;
        }

        [Description("Update MemberDns table dns records")]
        public bool UpdateMemberDnsDnses(int domainId, string domainDns1, string domainDns2, string domainDns3, string domainDns4)
        {
            ReqUpdateDomainDns request = new ReqUpdateDomainDns()
            {
                DomainDns1 = domainDns1,
                DomainDns2 = domainDns2,
                DomainDns3 = domainDns3,
                DomainDns4 = domainDns4,
                DomainId = domainId
            };

            var response = Call<bool, ReqUpdateDomainDns>(request, "UpdateMemberDnsDnses");
            return response;
        }

        [Description("Get Whois for Domain")]
        public WhoisInformationInfo GetWhoisInformation(ReqWhoisInformation request)
        {
            return this.Call<WhoisInformationInfo, ReqWhoisInformation>(request, "GetWhoisInformation");
        }

        [Description("Tld Extension Information")]
        public ResNewTldInformation NewTldInformation(ReqNewTldInformation Rq)
        {
            return this.Call<ResNewTldInformation, ReqNewTldInformation>(Rq, "NewTldInformation");
        }

        [Description("Tld Request Information Save")]
        public bool TLD_TalepBilgileri_Save(ReqTldRequestInformation Rq)
        {
            return this.Call<bool, ReqTldRequestInformation>(Rq, "TLD_TalepBilgileri_Save");
        }

        [Description("Tld Request Information Kontrol(MemberId,Domain Parameters)")]
        public bool TLD_TalepBilgileri_Kontrol(ReqTldRequestInformation Rq)
        {
            return this.Call<bool, ReqTldRequestInformation>(Rq, "TLD_TalepBilgileri_Kontrol");
        }

        [Description("Staff Tld List")]
        public List<ResNewTldList> NewTLDList()
        {
            return this.Call<List<ResNewTldList>, ReqEmpty>(new ReqEmpty(), "NewTLDList");
        }

        [Description("Staff Tld List Search")]
        public List<ResNewTldList> NewTLDListSearch(string TldName)
        {
            return this.Call<List<ResNewTldList>, string>(TldName, "NewTLDListSearch");
        }

        [Description("Staff Tld Update ")]
        public bool NewTLDInformationUpdate(ReqNewTldUpdate Rq)
        {
            return this.Call<bool, ReqNewTldUpdate>(Rq, "NewTLDInformationUpdate");
        }

        [Description("Staff Tld Save")]
        public bool NewTLDInformationSave(ReqNewTldSave Rq)
        {
            return this.Call<bool, ReqNewTldSave>(Rq, "NewTLDInformationSave");
        }

        [Description("Tld Selling Price essantial information")]
        public ResTldSellingInformation TLDSellingInformation(ReqTldSellingInformation req)
        {
            return this.Call<ResTldSellingInformation, ReqTldSellingInformation>(req, "TLDSellingInformation");

        }

        [Description("DomainTypesGroupsByAll")]
        public List<DomainTypesGroups> DomainTypesGroupsByAll(int IsActive)
        {
            return this.Call<List<DomainTypesGroups>, int>(IsActive, "DomainTypesGroupsByAll");
        }

        [Description("DomainTypesGroupsByDetails")]
        public List<DomainTypeTo> GetgTldGroups(int GroupId)
        {
            return this.Call<List<DomainTypeTo>, int>(GroupId, "GetgTldGroups");
        }

        [Description("DomainTypesGroupsByIdDelete")]
        public bool DomainTypesGroupsByIdDelete(int Id)
        {
            return this.Call<bool, int>(Id, "DomainTypesGroupsByIdDelete");
        }

        [Description("DomainTypesGroupsByUpdate")]
        public bool DomainTypesGroupsByUpdate(DomainTypesGroupsByUpdate prm)
        {
            return this.Call<bool, DomainTypesGroupsByUpdate>(prm, "DomainTypesGroupsByUpdate");
        }

        [Description("DomainTypesGroupsByAdd")]
        public bool DomainTypesGroupsByAdd(string str)
        {
            return this.Call<bool, string>(str, "DomainTypesGroupsByAdd");
        }

        [Description("DomainTypesGroupsDetailAdd")]
        public bool DomainTypesGroupsDetailAdd(DomainTypesGroupsDetailAdd prm)
        {
            return this.Call<bool, DomainTypesGroupsDetailAdd>(prm, "DomainTypesGroupsDetailAdd");
        }

        [Description("DomainTypesGroupsDetailDelete")]
        public bool DomainTypesGroupsDetailDelete(DomainTypesGroupsDetailDelete prm)
        {
            return this.Call<bool, DomainTypesGroupsDetailDelete>(prm, "DomainTypesGroupsDetailDelete");
        }

        [Description("Domain Typelarini Dondurur")]
        public List<DealerSafe.DTO.Domain.qryDomainManagemenet> GetDomainTypeList(bool IsgTld)
        {
            return this.Call<List<DealerSafe.DTO.Domain.qryDomainManagemenet>, bool>(IsgTld, "GetDomainTypeList");
        }

        [Description("RegistryCompany")]
        public List<DealerSafe.DTO.Domain.RegistryCompany> GetRegistryCompanyList(bool bos = false)
        {
            return this.Call<List<DealerSafe.DTO.Domain.RegistryCompany>, bool>(bos, "GetRegistryCompanyList");
        }

        [Description("New Tld Avalible Control Process and return Avalible Information")]
        public ResNewTldAvailable NewTldAvalibleInformation(string DomainNm)
        {
            return this.Call<ResNewTldAvailable, string>(DomainNm, "NewTldAvalibleInformation");
        }

        [Description("Get DomainTypes NewGTld Count ")]
        public int GetNewGTldCount()
        {
            return this.Call<int, ReqEmpty>(new ReqEmpty(), "GetNewGTldCount");
        }

        [Description("List New Tld Query Information")]
        public List<ResNewTldAllQuery> NewTldAllQuery()
        {
            return this.Call<List<ResNewTldAllQuery>, ReqEmpty>(new ReqEmpty(), "NewTldAllQuery");
        }

        public List<DealerSafe.DTO.Epp.Response.ResTldNameGroupByCompanyId> TldNameGroupByCompanyId()
        {
            return Call<List<DealerSafe.DTO.Epp.Response.ResTldNameGroupByCompanyId>, ReqEmpty>(new ReqEmpty(), "TldNameGroupByCompanyId");
        }


        [Description("Domain Groups List Information")]
        public List<ResDomainGroupListInformation> DomainGroupListInformation()
        {
            return this.Call<List<ResDomainGroupListInformation>, ReqEmpty>(new ReqEmpty(), "DomainGroupListInformation");

        }


        [Description("New Tld Favorite Add Email process")]
        public bool TldFavoriteAdd(ReqTldFavoriteAdd Rq)
        {
            return this.Call<bool, ReqTldFavoriteAdd>(Rq, "TldFavoriteAdd");

        }


        [Description("New Tld Favorite Count")]
        public int TldFavoriteCount(int MemberId)
        {
            return this.Call<int, int>(MemberId, "TldFavoriteCount");

        }


        [Description("New Tld Delete Staff"), Category("NewGtld")]
        public Dictionary<bool, string> NewGtldDelete(ReqNewGtldDelete rq)
        {
            return this.Call<Dictionary<bool, string>, ReqNewGtldDelete>(rq, "NewGtldDelete");
        }

        #region MobileBridge

        [Description("Get member domain list by member id"), Category("General")]
        public List<MembersDnsTo> GetMemberDomainListByMemberId(int memberId)
        {
            return this.Call<List<MembersDnsTo>, int>(memberId, "GetMemberDomainListByMemberId");
        }

        #endregion

        #region İsimTescil

        #region OutTransfer

        [Description("Reseller DomainOut Transfer Cancel")]
        public string DomainTransferOutCancel(ReqDomainTransferOutCancel rq)
        {
            var response = Call<string, ReqDomainTransferOutCancel>(rq, "DomainTransferOutCancel");
            return response;
        }

        [Description("Reseller-Domain OutTransfer Start")]
        public ResDomainTransferOutStart DomainTransferOutStart(ReqDomainTransferOutStart rq)
        {

            return this.Call<ResDomainTransferOutStart, ReqDomainTransferOutStart>(rq, "DomainTransferOutStart");
        }


        [Description("Reseller-Domain OutTransfer List")]
        public List<ResOutTransferMemberDnsList> DomainTransferOutListIsimTescil()
        {
            return Call<List<ResOutTransferMemberDnsList>, ReqEmpty>(new ReqEmpty(), "DomainTransferOutListIsimTescil");
        }

        [Description("Staff-Domain OutTransfer List")]
        public List<ResDomainTransferOutListStaff> DomainTransferOutListStaff(ReqDomainTransferOutListStaff req)
        {
            return this.Call<List<ResDomainTransferOutListStaff>, ReqDomainTransferOutListStaff>(req, "DomainTransferOutListStaff");
        }


        [Description("Staff-Domain OutTransfer Password Again Send")]
        public bool DomainTransferOutPasswordMailSend(int domainId)
        {
            return this.Call<bool, int>(domainId, "DomainTransferOutPasswordMailSend");
        }


        [Description("Staff-Domain OutTransfer LogsGet")]
        public List<ResDomainTransferOutLogGet> DomainTransferOutLogGet(int domainId)
        {
            return this.Call<List<ResDomainTransferOutLogGet>, int>(domainId, "DomainTransferOutLogGet");
        }


        [Description("Staff-Domain OutTransfer Process Count")]
        public int DomainTransferOutProcesstoCount(List<EnmOutTransferDomainProcess> Lenm)
        {
            return this.Call<int, List<EnmOutTransferDomainProcess>>(Lenm, "DomainTransferOutProcesstoCount");
        }


        [Description("Consol-Domain OutTransfer Control and statu change")]
        public List<string> DomainTransferOutControl()
        {
            return this.Call<List<string>, ReqEmpty>(new ReqEmpty(), "DomainTransferOutControl");
        }

        [Description("Consol-Domain OutTransfer  DomainTimeEmpty Status and TransferOut Process Delete")]
        public List<string> DomainTransferOutProcessCheckControl()
        {
            return this.Call<List<string>, ReqEmpty>(new ReqEmpty(), "DomainTransferOutProcessCheckControl");
        }


        [Description("Consol-Domain OutTransfer 20 day control and domain activated")]
        public List<string> DomainTransferOut20DaysControl()
        {
            return this.Call<List<string>, ReqEmpty>(new ReqEmpty(), "DomainTransferOut20DaysControl");
        }

        [Description("Staff OutTransfer UserGet")]
        public ResDomainTransferOutListStaff DomainTransferOutGet(int domainId)
        {
            return this.Call<ResDomainTransferOutListStaff, int>(domainId, "DomainTransferOutGet");
        }


        #endregion

        #region  InTransfer

        [Description("Reseller-Domain InTransfer List"), Category("İçeri Transfer")]
        public List<MemberDnsList> DomainTransferInList()
        {
            return Call<ResGetTransferMemberDnsList, ReqEmpty>(new ReqEmpty(), "DomainTransferInList").List;
        }

        [Description("Staff-Domain InTransfer List"), Category("İçeri Transfer")]
        public List<ResDomainTransferInListStaff> DomainTransferInListStaff(ReqDomainTransferInListStaff req)
        {
            return this.Call<List<ResDomainTransferInListStaff>, ReqDomainTransferInListStaff>(req, "DomainTransferInListStaff");
        }

        [Description("Staff-Domain InTransfer Process Count"), Category("İçeri Transfer")]
        public int DomainTransferInProcesstoCount(string State)
        {
            return this.Call<int, string>(State, "DomainTransferInProcesstoCount");
        }

        [Description("Staff-Domain InTransfer LogsGet"), Category("İçeri Transfer")]
        public List<ResDomainTransferInLogGet> DomainTransferInLogGet(ReqDomainTransferInLogGet rq)
        {
            return this.Call<List<ResDomainTransferInLogGet>, ReqDomainTransferInLogGet>(rq, "DomainTransferInLogGet");
        }

        [Description("Resseller-Domain TransferIn Log"), Category("İçeri Transfer")]
        public List<ResTransferLogExplantion> DomainTansferInLogExplation(int DmainId)
        {
            ReqTransferLogExplation Rq = new ReqTransferLogExplation() { DomainId = DmainId };

            return Call<List<ResTransferLogExplantion>, ReqTransferLogExplation>(Rq, "DomainTansferInLogExplation");

        }


        [Description("Resseller-Domain InTransfer Start"), Category("İçeri Transfer")]
        public ResDomainTransferInStart DomainTransferInStart(ReqDomainTransferInStart rq)
        {
            return Call<ResDomainTransferInStart, ReqDomainTransferInStart>(rq, "DomainTransferInStart");
        }


        [Description("Consol-Domain InTransfer Pending Change Control"), Category("İçeri Transfer")]
        public List<string> DomainTransferInSendMailApproval()
        {
            return Call<List<string>, ReqEmpty>(new ReqEmpty(), "DomainTransferInSendMailApproval");
        }

        [Description("Consol-Domain InTransfer is Isimtestcil Active Operation"), Category("İçeri Transfer")]
        public List<string> DomainTransferInIsIsimtescilOperation()
        {
            return Call<List<string>, ReqEmpty>(new ReqEmpty(), "DomainTransferInIsIsimtescilOperation");
        }

        [Description("Consol-Domain InTransfer Start (Transfer Edilmeyi bekleyenler)"), Category("İçeri Transfer")]
        public List<ResDomainTransferInStart> DomainTransferInIsIsimtescilStartConsol()
        {
            return Call<List<ResDomainTransferInStart>, ReqEmpty>(new ReqEmpty(), "DomainTransferInIsIsimtescilStartConsol");
        }


        [Description("Consol-Domain InTransfer Control and statu change"), Category("İçeri Transfer")]
        public List<string> DomainTransferInControl()
        {
            return this.Call<List<string>, ReqEmpty>(new ReqEmpty(), "DomainTransferInControl");
        }

        [Description("Reseller DomainTransferToMembers Cancel")]
        public string DomainTransferToMembersCancel(ReqDomainTransferToMembersCancel rq)
        {
            return Call<string, ReqDomainTransferToMembersCancel>(rq, "DomainTransferToMembersCancel");
        }

        #endregion

        #region Whois

        [Description("Domain Whois Detail Call"), Category("General")]
        public ResDomainWhoisLookUpGet DomainWhoisLookUpGet(ReqDomainWhois whoisReq)
        {
            return Call<ResDomainWhoisLookUpGet, ReqDomainWhois>(whoisReq, "DomainWhoisLookUpGet");
        }

        [Description("Domain Whois Alternative Domain proposition"), Category("General")]
        public List<ResDomainWhoisAlternativeCheck> DomainWhoisAlternativeCheck(string domainName)
        {
            return Call<List<ResDomainWhoisAlternativeCheck>, string>(domainName, "DomainWhoisAlternativeCheck");
        }

        #endregion

        #endregion


        #region Staff



        #region  InTransfer

        [Description("Staff-Domain InTransfer Status Change"), Category("İçeri Transfer")]
        public bool DomainTransferInStatusChanged(ReqDomainTransferInStatusChanged rq)
        {
            return this.Call<bool, ReqDomainTransferInStatusChanged>(rq, "DomainTransferInStatusChanged");
        }


        [Description("Staff-Domain InTransfer Mail Exposition"), Category("İçeri Transfer")]
        public bool DomainTransferInMailExposition(ReqDomainTransferInMailExposition rq)
        {
            return this.Call<bool, ReqDomainTransferInMailExposition>(rq, "DomainTransferInMailExposition");
        }

        #endregion

        #region DomainDirection

        [Description("Tld General Save")]
        public int TldGeneralSave(ReqTldGeneralSave Req)
        {
            return this.Call<int, ReqTldGeneralSave>(Req, "TldGeneralSave");
        }


        [Description("Tld General Updaters")]
        public bool TldGeneralUpdate(ReqTldGeneralUpdate Req)
        {
            return this.Call<bool, ReqTldGeneralUpdate>(Req, "TldGeneralUpdate");
        }


        [Description("Tld Price Updaters")]
        public bool TldPriceSave(ReqTldPriceSave Req)
        {
            return this.Call<bool, ReqTldPriceSave>(Req, "TldPriceSave");
        }


        [Description("Tld Price Updaters")]
        public bool TldPriceUpdate(ReqTldPriceUpdate Req)
        {
            return this.Call<bool, ReqTldPriceUpdate>(Req, "TldPriceUpdate");
        }



        [Description("Tld Price GetInformation Staff")]
        public ResTldPriceInformation GetTldPriceInformation(int tldId)
        {
            return this.Call<ResTldPriceInformation, int>(tldId, "GetTldPriceInformation");
        }


        [Description("New Tld CompanyList Staff")]
        public List<ResTldCompany> NewGTldCompanyList()
        {
            return Call<List<ResTldCompany>, ReqEmpty>(new ReqEmpty(), "NewGTldCompanyList");
        }


        [Description("Tld Name Count Staff")]
        public int TldCount(string TldName)
        {
            return this.Call<int, string>(TldName, "TldCount");
        }


        [Description("Protected Contact Table TldName Get Stafff")]
        public ResTldProtectedContactGet TldProtectedContactGet(string tldName)
        {
            return this.Call<ResTldProtectedContactGet, string>(tldName, "TldProtectedContactGet");
        }



        [Description("Protected Contact Table TldName Get Staff")]
        public bool TldProtectedContactSave(ReqTldProtectedContactSave req)
        {
            return this.Call<bool, ReqTldProtectedContactSave>(req, "TldProtectedContactSave");
        }



        [Description("Protected Contact Table TldName Get Staff")]
        public bool TldProtectedContactUpdate(ReqTldProtectedContactUpdate req)
        {
            return this.Call<bool, ReqTldProtectedContactUpdate>(req, "TldProtectedContactUpdate");
        }


        [Description("Domain Status Change")]
        public bool DomainStatusActivityProcessChange(ReqDomainStatusActivityProcessChange rq)
        {
            return this.Call<bool, ReqDomainStatusActivityProcessChange>(rq, "DomainStatusActivityProcessChange");
        }

        #endregion

        #region General

        [Description("Staff MembersDns Record Process (item1: TransferEdilmeyi Bekleyenler And item2: Transfer Onayı Bekleyenler)")]
        public Tuple<int, int> MembersDNSDomainTransferCountsList()
        {
            return this.Call<Tuple<int, int>, ReqEmpty>(new ReqEmpty(), "MembersDNSDomainTransferCountsList");
        }


        [Description("Staff UpdateMembersDns Late Record List"), Category("General")]
        public List<ResDomain_Process_History> Domain_Process_History(int domainId)
        {
            return this.Call<List<ResDomain_Process_History>, int>(domainId, "Domain_Process_History");
        }

        #endregion

        #endregion

        [Description("Domain buy count"), Category("General")]
        public int WaitingRegisterCount(string domainName)
        {
            return this.Call<int, string>(domainName, "WaitingRegisterCount");
        }

        [Description("Domain Whois Query Count Get"), Category("General")]
        public int WhoisQueryCountGet()
        {
            return this.Call<int, ReqEmpty>(new ReqEmpty(), "WhoisQueryCountGet");
        }


        [Description("GetMemberContactsApprove")]
        public ResStaffMemberContactsApprove StaffGetMemberContactsApprove(ReqStaffMemberContactsApprove rq)
        {
            return this.Call<ResStaffMemberContactsApprove, ReqStaffMemberContactsApprove>(rq, "StaffGetMemberContactsApprove");
        }


        [Description("SaveMemberContactsApprove")]
        public bool StaffSaveMemberContactsApprove(ReqStaffSaveMemberContactsApprove rq)
        {
            return this.Call<bool, ReqStaffSaveMemberContactsApprove>(rq, "StaffSaveMemberContactsApprove");

        }

        [Description("UpdateMemberContactsApprove")]
        public bool StaffUpdateMemberContactsApprove(ReqStaffSaveMemberContactsApprove rq)
        {
            return this.Call<bool, ReqStaffSaveMemberContactsApprove>(rq, "StaffUpdateMemberContactsApprove");

        }

        [Description("CheckContactApprove")]
        public string StaffCheckContactApprove(ReqStaffCheckContactApprove rq)
        {
            return this.Call<string, ReqStaffCheckContactApprove>(rq, "StaffCheckContactApprove");

        }

        public bool TldListUpdateaa()
        {
            var response = Call<bool, ReqEmpty>(new ReqEmpty(), "TldListUpdateaa");
            return response;

        }


        [Description("PriceList"), Category("General")]
        public string PriceList()
        {
            return this.Call<string, ReqEmpty>(new ReqEmpty(), "PriceList");
        }

        [Description("AddEppExtension")]
        public bool AddEppExtension(ReqEppExtension req)
        {
            return this.Call<bool, ReqEppExtension>(req, "AddEppExtension");
        }

        [Description("RemoveEppExtension")]
        public bool RemoveEppExtension(ReqEppExtension req)
        {
            return this.Call<bool, ReqEppExtension>(req, "RemoveEppExtension");
        }

        [Description("HasEppExtension")]
        public bool HasEppExtension(ReqEppExtension req)
        {
            return this.Call<bool, ReqEppExtension>(req, "HasEppExtension");
        }
    }
}
