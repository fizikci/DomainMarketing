using System.IO;
using System.Web;
using DealerSafe.DTO.Domain;

namespace DealerSafe.ServiceClient
{
    using DTO;
    using DTO.Orders;
    using DTO.Enums;
    using DTO.Hosting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;

    public class HostingAPI : BaseAPI
    {
        public HostingAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public HostingAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        [Description("Get hosting's member id by domain name")]
        public int GetMemberProductsMemberIdByDomain(string domainName)
        {
            return this.Call<int, string>(domainName, "GetMemberProductsMemberIdByDomain");
        }

        public int SaveUpgradeHistoryDomain(MemberProductHistoryDomainsInfo domain)
        {
            return this.Call<int, MemberProductHistoryDomainsInfo>(domain, "SaveUpgradeHistoryDomain");
        }
        public MemberProductHistoryInfo GetUpgradeHistoryByOrderDetailId(int newOrderDetailId)
        {
            return this.Call<MemberProductHistoryInfo, int>(newOrderDetailId, "GetUpgradeHistoryByOrderDetailId");
        }

        public bool UpdateUpgradeHistory(MemberProductHistoryInfo historyInfo)
        {
            return this.Call<bool, MemberProductHistoryInfo>(historyInfo, "UpdateUpgradeHistory");
        }

        public int SaveUpgradeHistory(MemberProductHistoryInfo historyInfo)
        {
            return this.Call<int, MemberProductHistoryInfo>(historyInfo, "SaveUpgradeHistory");
        }

        public bool UpdateBackupStatusToComplete(int newOrderDetailId, int adminId)
        {
            var req = new ReqUpdateBackupStatusToComplete()
            {
                AdminMemberId = adminId,
                OrderDetailId = newOrderDetailId
            };

            return this.Call<bool, ReqUpdateBackupStatusToComplete>(req, "UpdateBackupStatusToComplete");
        }


        public bool SyncPassword(int hostingId)
        {
            return this.Call<bool, int>(hostingId, "SyncPassword");
        }

        public bool SaveMemberProductPassword(int hostingId, string domainName, string username, string password, string passwordType, bool isReseller)
        {
            var req = new ReqMemberProductPassword() { HostingId = hostingId, DomainName = domainName, Password = password, PasswordType = passwordType, Username = username, IsReseller = isReseller };
            return this.Call<bool, ReqMemberProductPassword>(req, "SaveMemberProductPassword");
        }

        //public bool UpdateMemberProductPassword(int hostingId, string domainName, string username, string password, string passwordType)
        //{
        //    var req = new ReqMemberProductPassword() { HostingId = hostingId, DomainName = domainName, Password = password, PasswordType = passwordType, Username = username };
        //    return this.Call<bool, ReqMemberProductPassword>(req, "UpdateMemberProductPassword");
        //}

        public MemberProductPasswordsInfo GetMemberProductPassword(int hostingId, string domainName, string username, string passwordType)
        {
            var req = new ReqMemberProductPassword() { HostingId = hostingId, DomainName = domainName, PasswordType = passwordType, Username = username };
            return this.Call<MemberProductPasswordsInfo, ReqMemberProductPassword>(req, "GetMemberProductPassword");
        }

        public MemberProductPasswordsInfo GetMemberProductPasswordById(int id)
        {
            return this.Call<MemberProductPasswordsInfo, int>(id, "GetMemberProductPasswordById");
        }

        public List<MemberProductPasswordsInfo> GetMemberProductPasswordListByDomainName(string domainName)
        {
            return this.Call<List<MemberProductPasswordsInfo>, string>(domainName, "GetMemberProductPasswordListByDomainName");
        }

        public List<MemberProductPasswordsInfo> GetMemberProductPasswordListByHostingId(int hostingId)
        {
            return this.Call<List<MemberProductPasswordsInfo>, int>(hostingId, "GetMemberProductPasswordListByHostingId");
        }

        public bool DeleteMemberProductPassword(int hostingId, string domainName, string username, string passwordType)
        {
            var req = new ReqMemberProductPassword() { HostingId = hostingId, DomainName = domainName, PasswordType = passwordType, Username = username };
            return this.Call<bool, ReqMemberProductPassword>(req, "DeleteMemberProductPassword");
        }

        public bool DeleteAllMemberProductPasswordByDomainId(ReqDeleteMemberProductPassword request)
        {
            return this.Call<bool, ReqDeleteMemberProductPassword>(request, "DeleteAllMemberProductPasswordByDomainId");
        }

        public bool DeleteAllMemberProductPasswordByHostingId(ReqDeleteMemberProductPassword request)
        {
            return this.Call<bool, ReqDeleteMemberProductPassword>(request, "DeleteAllMemberProductPasswordByHostingId");
        }

        [Description("Update Operating system")]
        public bool UpdateOperationSystem(int hostingId, int systemType)
        {
            var req = new ReqUpdateOperatingSystem() { HostingId = hostingId, SystemType = systemType };
            return this.Call<bool, ReqUpdateOperatingSystem>(req, "UpdateOperationSystem");
        }

        [Description("Get dns by tld with isdefault")]
        public tblDNSbyTLDInfo GetDnsByTld(int isDefault)
        {
            return this.Call<tblDNSbyTLDInfo, int>(isDefault, "GetDnsByTld");
        }

        [Description("Get dns by tld with extension")]
        public tblDNSbyTLDInfo GetDnsByTldByExtension(string extension)
        {
            return this.Call<tblDNSbyTLDInfo, string>(extension, "GetDnsByTldByExtension");
        }

        [Description("Get member dns backup list by domain id")]
        public List<MemberDnsBackupInfo> GetMemberDnsBackupListByDomainId(int domainId)
        {
            return this.Call<List<MemberDnsBackupInfo>, int>(domainId, "GetMemberDnsBackupListByDomainId");
        }

        [Description("Delete member dns backup by entity")]
        public bool DeleteMemberDnsBackup(MemberDnsBackupInfo info)
        {
            return this.Call<bool, MemberDnsBackupInfo>(info, "DeleteMemberDnsBackup");
        }


        [Description("Get member dns backups by id")]
        public MemberDnsBackupInfo GetMemberDnsBackupByDomainId(int domainId)
        {
            return this.Call<MemberDnsBackupInfo, int>(domainId, "GetMemberDnsBackupByDomainId");
        }

        [Description("Get member dns backups by domain id and id ")]
        public MemberDnsBackupInfo GetMemberDnsBackup(int id, int domainId)
        {
            var req = new ReqGetMemberDnsBackup() { DomainId = domainId, Id = id };
            return this.Call<MemberDnsBackupInfo, ReqGetMemberDnsBackup>(req, "GetMemberDnsBackup");
        }

        [Description("Insert member dns backups")]
        public int InsertMemberDnsBackup(MemberDnsBackupInfo mdbi)
        {
            return this.Call<int, MemberDnsBackupInfo>(mdbi, "InsertMemberDnsBackup");
        }

        [Description("Returns domains by hosting id")]
        public List<MemberProductDomainsInfo> GetHostingDomainsAll(int hostingId, bool? tempDomain = false)
        {
            var req = new ReqGetHostingDomainsAllDomain() { HostingId = hostingId, TempDomain = tempDomain };
            return this.Call<List<MemberProductDomainsInfo>, ReqGetHostingDomainsAllDomain>(req, "GetHostingDomainsAll");
        }

        [Description("Get Mail Server by Server Id")]
        public tblMailServersInfo GetMailServer(int mailServerId)
        {
            return this.Call<tblMailServersInfo, int>(mailServerId, "GetMailServer");
        }

        [Description("Get Mail Server by Server Id")]
        public tblMailServersInfo GetMailServerChanging(string DomainName)
        {
            return this.Call<tblMailServersInfo, string>(DomainName, "GetMailServerChanging");
        }


        [Description("Update panel ip")]
        public bool UpdatePanelIp(int hostingId, int panelId)
        {
            var req = new ReqUpdatePanelIp() { HostingId = hostingId, PanelId = panelId };
            return this.Call<bool, ReqUpdatePanelIp>(req, "UpdatePanelIp");
        }

        [Description("Update member product details by property id")]
        public bool UpdateMemberProductDetailsByPropId(int hostingId, int propertyId, string itemValueStr)
        {
            var req = new ReqUpdateMemberProductDetailsByPropId() { HostingId = hostingId, ItemValueStr = itemValueStr, PropertyId = propertyId };
            return this.Call<bool, ReqUpdateMemberProductDetailsByPropId>(req, "UpdateMemberProductDetailsByPropId");
        }

        [Description("Update Order Details")]
        public bool UpdateOrderDetailForHosting(OrdersDetailForHosting od)
        {
            return this.Call<bool, OrdersDetailForHosting>(od, "UpdateOrderDetailForHosting");
        }

        [Description("Returns order detail for hosting")]
        public OrdersDetailForHosting GetOrderDetailForHosting(int hostingId, int orderDetailId)
        {
            var req = new ReqGetOrderDetailForHosting() { OrderDetailId = orderDetailId, TargetId = hostingId };
            return this.Call<OrdersDetailForHosting, ReqGetOrderDetailForHosting>(req, "GetOrderDetailForHosting");
        }

        [Description("UpdateMemberProductEndDate")]
        public bool UpdateMemberProductEndDate(int hostingId, DateTime endDate)
        {
            var req = new ReqUpdateMemberProductEndDate() { HostingId = hostingId, EndDate = endDate };
            return this.Call<bool, ReqUpdateMemberProductEndDate>(req, "UpdateMemberProductEndDate");
        }

        [Description("Delete domain by id")]
        public bool DeleteDomainById(int domainId)
        {
            return this.Call<bool, int>(domainId, "DeleteDomainById");
        }

        [Description("Move hosting for admin controller")]
        public bool MoveHostingForAdmin(ReqMoveHostingForAdmin req)
        {
            return this.Call<bool, ReqMoveHostingForAdmin>(req, "MoveHostingForAdmin");
        }

        [Description("Insert member hosting transaction")]
        public bool InsertHostingTransaction(MemberHostingTransactionsInfo transactions)
        {
            return this.Call<bool, MemberHostingTransactionsInfo>(transactions, "InsertHostingTransaction");
        }

        [Description("Returns member hosting transaction")]
        public MemberHostingTransactionsInfo GetHostingTransaction(int hostingId)
        {
            return this.Call<MemberHostingTransactionsInfo, int>(hostingId, "GetHostingTransaction");
        }

        [Description("Mailbox limit update")]
        public bool MailBoxLimitUpdate(int hostingId, int productId, bool unlimited)
        {
            var req = new ReqMailboxLimitUpdate() { HostingId = hostingId, ProductId = productId, Unlimited = unlimited };
            return this.Call<bool, ReqMailboxLimitUpdate>(req, "MailBoxLimitUpdate");
        }

        [Description("Delete tblDirection row and tblUnderConstruction row")]
        public bool DeleteDirectionAndUnderConstruction(int domainId)
        {
            return this.Call<bool, int>(domainId, "DeleteDirectionAndUnderConstruction");
        }

        [Description("Returns true/false, when it was domain in the blacklist")]
        public bool DomainBlackListControl(string domaiName)
        {
            return this.Call<bool, string>(domaiName, "DomainBlackListControl");
        }

        [Description("Decrease Domain Used Value On Member Product Details Row")]
        public bool DecreaseDomainUsedValue(int hostingId)
        {
            return this.Call<bool, int>(hostingId, "DecreaseDomainUsedValue");
        }

        [Description("Increase Domain Used Value On Member Product Details Row")]
        public bool IncreaseDomainUsedValue(int hostingId)
        {
            return this.Call<bool, int>(hostingId, "IncreaseDomainUsedValue");
        }

        [Description("Return mailbox list")]
        public List<MemberEmailsInfo> GetMailboxList(string domain)
        {
            return this.Call<List<MemberEmailsInfo>, string>(domain, "GetMailboxList");
        }

        [Description("Delete member mailbox")]
        public bool DeleteMailbox(string domainName, string mailbox)
        {
            var req = new ReqGetMailBoxes() { DomainName = domainName, MailBox = mailbox };
            return this.Call<bool, ReqGetMailBoxes>(req, "DeleteMailbox");
        }

        [Description("Delete postoffice")]
        public bool DeletePostOffice(string domainName, int hostingId)
        {
            var req = new ReqDeletePostOffice() { DomainName = domainName, MemberId = memberId, HostingId = hostingId };
            return this.Call<bool, ReqDeletePostOffice>(req, "DeletePostOffice");
        }

        [Description("Returns member mailbox")]
        public MemberEmailsInfo GetMailboxes(string domainName, string mailbox)
        {
            var req = new ReqGetMailBoxes() { DomainName = domainName, MailBox = mailbox };
            return this.Call<MemberEmailsInfo, ReqGetMailBoxes>(req, "GetMailboxes");
        }

        [Description("get mailbox current size")]
        public long GetMailBoxSize(string mailbox, string postOffice)
        {
            var req = new ReqGetMailBoxSize() { MailBox = mailbox, PostOffice = postOffice };
            return this.Call<long, ReqGetMailBoxSize>(req, "GetMailBoxSize");
        }

        [Description("Insert new mailbox")]
        public int InsertMailbox(MemberEmailsInfo email)
        {
            return this.Call<int, MemberEmailsInfo>(email, "InsertMailbox");
        }

        [Description("Get Member Product Log")]
        public List<MemberProductLogsInfo> GetMemberProductLogs(int hostingId)
        {
            return this.Call<List<MemberProductLogsInfo>, int>(hostingId, "GetMemberProductLogs");
        }

        [Description("Insert Member Product Log")]
        public bool SaveMemberProductLogs(MemberProductLogsInfo log)
        {
            return this.Call<bool, MemberProductLogsInfo>(log, "SaveMemberProductLogs");
        }

        [Description("Insert Member Process Log")]
        public bool SaveMemberProcessLogs(MemberProcessLogInfo log)
        {
            return this.Call<bool, MemberProcessLogInfo>(log, "SaveMemberProcessLogs");
        }

        [Description("Returns Plesk Panel Password from Database")]
        public string GetPleskPanelPassword(int hostingId)
        {
            return this.Call<string, int>(hostingId, "GetPleskPanelPassword");
        }

        [Description("Returns surgate users count by user id")]
        public int GetSurgateUsersCount(int userId)
        {
            return this.Call<int, int>(userId, "GetSurgateUsersCount");
        }

        [Description("Update Member Product Details")]
        public bool UpdateMemberProductDetails(MemberProductDetailsInfo mpd)
        {
            return this.Call<bool, MemberProductDetailsInfo>(mpd, "UpdateMemberProductDetails");
        }

        [Description("Update Domain Password")]
        public bool UpdateDomainUserPass(MemberProductDomainsInfo domain)
        {
            return this.Call<bool, MemberProductDomainsInfo>(domain, "UpdateDomainUserPass");
        }

        [Description("Returns hosting details of product")]
        public HostingDetail GetHosting(int memberProductId)
        {
            return this.Call<HostingDetail, int>(memberProductId, "GetHosting");
        }

        [Description("Get Server Id With MemberProducts")]
        public int GetServerId(MemberProductsInfo memberProduct)
        {
            return this.Call<int, MemberProductsInfo>(memberProduct, "GetServerId");
        }

        [Description("Get Server With Server Id")]
        public tblServersInfo GetServer(int serverId)
        {
            return this.Call<tblServersInfo, int>(serverId, "GetServer");
        }

        [Description("Get Server Id With ServerIP")]
        public int GetServerIdWithServerIp(string serverIp)
        {
            return this.Call<int, string>(serverIp, "GetServerIdWithServerIp");
        }

        [Description("Brings most available server of the server list")]
        public tblServersInfo GetAvaibleServer(int memberProductId, List<tblServersInfo> serverList, int serverId)
        {
            var req = new ReqGetAvailableServer() { MemberProductId = memberProductId, ServerList = serverList, ServerId = serverId };
            return this.Call<tblServersInfo, ReqGetAvailableServer>(req, "GetAvaibleServer");
        }

        [Description("Get Member Hosting with MemberProductId")]
        public MemberProductsInfo GetMemberProduct(int memberProductId)
        {
            return this.Call<MemberProductsInfo, int>(memberProductId, "GetMemberProduct");
        }

        [Description("Get Product Package Name. Ex: 'Eko Paket' for product id = 171)")]
        public string GetProductName(int productId)
        {
            return this.Call<string, int>(productId, "GetProductName");
        }

        [Description("Add Log")]
        public bool AddLog(HostingLogInfo hostingLogDto, int memberProductId, ProcessTypes processTypes)
        {
            var req = new ReqAddLog() { HostingLogDto = hostingLogDto, MemberProductId = memberProductId, ProcessType = processTypes };
            return this.Call<bool, ReqAddLog>(req, "AddLog");
        }

        [Description("Get hosting properties ")]
        public List<MemberProductDetailInfo> GetMemberHostingDetail(int memberProductId)
        {
            return this.Call<List<MemberProductDetailInfo>, int>(memberProductId, "GetMemberHostingDetail");
        }

        [Description("Get member hostings for hosting dropdown")]
        public List<DropDown> GetMemberHostings(int? selectedHostingId)
        {
            var req = new ReqGetMemberHostings() { MemberId = memberId, SelectHostingId = selectedHostingId };
            return this.Call<List<DropDown>, ReqGetMemberHostings>(req, "GetMemberHostings");
        }

        [Description("Get member hostings for hosting dropdown")]
        public List<DropDown> GetMemberHostingsForAdmin(int? selectedHostingId)
        {
            var req = new ReqGetMemberHostings() { MemberId = memberId, SelectHostingId = selectedHostingId };
            return this.Call<List<DropDown>, ReqGetMemberHostings>(req, "GetMemberHostingsForAdmin");
        }

        [Description("get hosting domains with hosting and domain id")]
        public List<DropDown> GetHostingDomains(int hostingId, int? domainId)
        {
            var req = new ReqGetHostingDomains() { HostingId = hostingId, DomainId = domainId };
            return this.Call<List<DropDown>, ReqGetHostingDomains>(req, "GetHostingDomains");
        }

        [Description("get hosting domains by hosting id")]
        public List<ResGetDomainsByHostingId> GetDomainsByHostingId(int hostingId)
        {
            var req = new ReqGetDomainsByHostingId() { HostingId = hostingId, MemberId = memberId };
            return this.Call<List<ResGetDomainsByHostingId>, ReqGetDomainsByHostingId>(req, "GetDomainsByHostingId");
        }

        [Description("get domains with member id ")]
        public List<DropDown> GetMemberDomains()
        {
            return this.Call<List<DropDown>, int>(memberId, "GetMemberDomains");
        }

        [Description("Get Domains with Hosting Id")]
        public List<MemberProductDomainsInfo> GetMemberProductDomains(int hostingId)
        {
            return this.Call<List<MemberProductDomainsInfo>, int>(hostingId, "GetMemberProductDomains");
        }

        [Description("Get Domain with domain id")]
        public MemberProductDomainsInfo GetDomain(int domainId)
        {
            return this.Call<MemberProductDomainsInfo, int>(domainId, "GetDomain");
        }

        [Description("Get Domain with domain id")]
        public MemberProductDomainsInfo GetDomainByName(string domainName)
        {
            return this.Call<MemberProductDomainsInfo, string>(domainName, "GetDomainByName");
        }

        [Description("Get Temp Domain with hosting id")]
        public MemberProductDomainsInfo GetTempDomain(int hostingId)
        {
            return this.Call<MemberProductDomainsInfo, int>(hostingId, "GetTempDomain");
        }

        [Description("Get Domain By Domain UserName")]
        public MemberProductDomainsInfo GetDomainByDomainUserName(string domainUser)
        {
            return this.Call<MemberProductDomainsInfo, string>(domainUser, "GetDomainByDomainUserName");
        }

        [Description("Product details to HostingProperty")]
        public List<HostingProperty> BindHostingProperties(int hostingId)
        {
            return this.Call<List<HostingProperty>, int>(hostingId, "BindHostingProperties");
        }

        [Description("Get domains with hosting id and convert domain dto")]
        public List<DomainInfo> GetHostingDomainsAllDomainDto(int hostingId, bool? tempDomain)
        {
            var req = new ReqGetHostingDomainsAllDomain() { HostingId = hostingId, TempDomain = tempDomain };
            return this.Call<List<DomainInfo>, ReqGetHostingDomainsAllDomain>(req, "GetHostingDomainsAllDomainDto");
        }

        [Description("Add domain.")]
        public ReturnMethod AddHostingDomain(DomainInfo model)
        {
            return this.Call<ReturnMethod, DomainInfo>(model, "AddHostingDomain");
        }

        [Description("Delete domain with DomainDto")]
        public ReturnMethod DeleteHostingDomain(DomainInfo model)
        {
            return this.Call<ReturnMethod, DomainInfo>(model, "DeleteHostingDomain");
        }

        [Description("Domain is exist?")]
        public bool ExistDomain(string domain)
        {
            return this.Call<System.Boolean, string>(domain, "ExistDomain");
        }

        [Description("Domain is exist in the MembersHostDns table?")]
        public bool ExistDomainMemberDns(string domain)
        {
            var req = new ReqExistDomainMemberDns() { Domain = domain, MemberId = memberId };
            return this.Call<System.Boolean, ReqExistDomainMemberDns>(req, "ExistDomainMemberDns");
        }

        [Description("Get all servers for operating system's dropdowns")]
        public List<DropDown> GetServersForOpertaingSystem(int serverId, int opSystem)
        {
            var req = new ReqGetServersForOpertaingSystem() { OperatingSystem = opSystem, ServerId = serverId };
            return this.Call<List<DropDown>, ReqGetServersForOpertaingSystem>(req, "GetServersForOpertaingSystem");
        }

        [Description("Get Operation System Name (Linux/Windows)")]
        public string GetOperatingSystem(string val)
        {
            return this.Call<string, string>(val, "GetOperatingSystem");
        }

        [Description("Get All Hosting With Activity Status")]
        public List<MemberProductsInfo> GetAllHosting(EnmActivities e)
        {
            return this.Call<List<MemberProductsInfo>, EnmActivities>(e, "GetAllHosting");
        }

        [Description("Change hosting activity")]
        public string HostingActivityChange(int memberProductId, int state)
        {
            var req = new ReqHostingActivityChange() { MemberProductId = memberProductId, State = state };
            return this.Call<string, ReqHostingActivityChange>(req, "HostingActivityChange");
        }

        [Description("Hosting top row fix for hosting controller")]
        public string HostingTopRowFix()
        {
            return this.Call<string, ReqEmpty>(new ReqEmpty(), "HostingTopRowFix");
        }

        [Description("Get products to fix")]
        public List<MemberProductsInfo> GetProductsToFix()
        {
            return this.Call<List<MemberProductsInfo>, ReqEmpty>(new ReqEmpty(), "GetProductsToFix");
        }

        [Description("Product to fix")]
        public ReturnMethod ProductToFix(MemberProductsInfo product)
        {
            return this.Call<ReturnMethod, MemberProductsInfo>(product, "ProductToFix");
        }

        [Description("Get hosting list to hosting create")]
        public List<int> GetHostingListToCreate()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToCreate");
        }

        [Description("Get hosting list to domain create")]
        public List<int> GetHostingListToDomainCreate()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToDomainCreate");
        }

        [Description("Get hosting list to move hosting")]
        public List<int> GetHostingListToMove()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToMove");
        }

        [Description("Get hosting list to default hosting job")]
        public List<int> GetHostingListToDefault()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToDefault");
        }

        [Description("Get hosting list to renew hosting")]
        public List<int> GetHostingListToRenew()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToRenew");
        }

        [Description("Get hosting list to suspend account")]
        public List<int> GetHostingListToSuspend()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToSuspend");
        }

        [Description("Get hosting list to change platform")]
        public List<int> GetHostingListToChangeHosting()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToChangeHosting");
        }

        [Description("Get hosting list to procuct upgrade")]
        public List<int> GetHostingListToUpgrade()
        {
            return this.Call<List<int>, ReqEmpty>(new ReqEmpty(), "GetHostingListToUpgrade");
        }

        [Description("Get Hosting list to migration jobs")]
        public List<WaitingMigrationInfo> GetHostingListToMigration()
        {
            return this.Call<List<WaitingMigrationInfo>, ReqEmpty>(new ReqEmpty(), "GetHostingListToMigration");
        }

        [Description("Create Hosting for Service Jobs")]
        public ReturnMethod CreateHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "CreateHosting");
        }

        [Description("Change Domain for Service Jobs")]
        public ReturnMethod CreateDomain(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "CreateDomain");
        }

        [Description("Move Hosting for Service Jobs")]
        public ReturnMethod MoveHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "MoveHosting");
        }

        [Description("Default Hosting for Service Jobs")]
        public ReturnMethod DefaultHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "DefaultHosting");
        }

        [Description("Renew Hosting for Service Jobs")]
        public ReturnMethod RenewHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "RenewHosting");
        }

        [Description("Suspend Hosting for Service Jobs")]
        public ReturnMethod SuspendHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "SuspendHosting");
        }

        [Description("Change Hosting for Service Jobs")]
        public ReturnMethod ChangeHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "ChangeHosting");
        }

        [Description("Upgrade Hosting for Service Jobs")]
        public ReturnMethod UpgradeHosting(HostingJobRequest request)
        {
            return this.Call<ReturnMethod, HostingJobRequest>(request, "UpgradeHosting");
        }

        [Description("Hosting Migration for Service Jobs")]
        public ReturnMethod Migration(WaitingMigrationInfo mg)
        {
            return this.Call<ReturnMethod, WaitingMigrationInfo>(mg, "Migration");
        }

        [Description("Insert/Update Mailbox In Our Database - Service Jobs")]
        public bool MailBoxInsert(string mailBox, string postOffice, long mailBoxSize)
        {
            var req = new ReqMailBoxInsert()
                {
                    MailBox = mailBox,
                    PostOffice = postOffice,
                    MailBoxSize = mailBoxSize
                };

            return this.Call<bool, ReqMailBoxInsert>(req, "MailBoxInsert");
        }

        [Description("Delete member product")]
        public bool DeleteHosting(int memberProductId)
        {
            return this.Call<bool, int>(memberProductId, "DeleteHosting");
        }

        [Description("Hosting reseller control")]
        public bool IsReseller(int memberProductId)
        {
            return this.Call<bool, int>(memberProductId, "IsReseller");
        }

        [Description("Get Member Hosting Details Row With EnmProps property")]
        public MemberProductDetailsInfo GetHostingDetailsRow(int memberProductId, int productProperty)
        {
            var req = new ReqGetHostingDetailsRow() { MemberProductId = memberProductId, ProductProperty = productProperty };
            return this.Call<MemberProductDetailsInfo, ReqGetHostingDetailsRow>(req, "GetHostingDetailsRow");
        }

        [Description("Get Hosting With Name and Price")]
        public MemberProductsInfo GetHostingWithNameAndPrice(int memberProductId)
        {
            var req = new ReqGetHostingWithNameAndPrice() { MemberProductId = memberProductId, MemberId = memberId };
            return this.Call<MemberProductsInfo, ReqGetHostingWithNameAndPrice>(req, "GetHostingWithNameAndPrice");
        }

        [Description("")]
        public string GetHostingStatus(string domain)
        {
            return this.Call<string, string>(domain, "GetHostingStatus");
        }

        [Description("")]
        public MemberProductsInfo GetHostingByDomain(string domain)
        {
            return this.Call<MemberProductsInfo, string>(domain, "GetHostingByDomain");
        }

        [Description("")]
        public int GetCountForStats(int day)
        {
            var req = new ReqGetCountForStats() { Day = day, MemberId = memberId };
            return this.Call<int, ReqGetCountForStats>(req, "GetCountForStats");
        }

        [Description("")]
        public int GetActiveHostingCountForStats()
        {
            return this.Call<int, int>(memberId, "GetActiveHostingCountForStats");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["hostingServiceURL"];
        }

        [Description("")]
        public ResGetStatsCountQuery GetStatsCountQuery()
        {
            return this.Call<ResGetStatsCountQuery, int>(memberId, "GetStatsCountQuery");
        }

        [Description("")]
        public List<MemberProductsInfo> GetListQuery(EnmListTypes enm, int from, int to, string search)
        {
            var request = new ReqGetHostingList() { EnumListType = enm, From = from, To = to, MemberId = memberId, Search = search };
            return this.Call<List<MemberProductsInfo>, ReqGetHostingList>(request, "GetListQuery");
        }

        [Description("")]
        public ResGetStatsCountQuery GetSearchCount(string search)
        {
            var req = new ReqGetSearchCount() { Search = search, MemberId = memberId };
            return this.Call<ResGetStatsCountQuery, ReqGetSearchCount>(req, "GetSearchCount");
        }

        [Description("")]
        public List<MemberProductsInfo> GetSearchList(EnmListTypes enm, int from, int to, string search)
        {
            var request = new ReqGetHostingList() { EnumListType = enm, From = from, To = to, MemberId = memberId, Search = search };
            return this.Call<List<MemberProductsInfo>, ReqGetHostingList>(request, "GetSearchList");
        }

        [Description(" Domain Is Active Other User Chek")]
        public MembersDnsTo GetDomainIsActiveOtherUserChek(string domainName)
        {
            return this.Call<MembersDnsTo, string>(domainName, "GetDomainIsActiveOtherUserChek");
        }

        #region antispam

        [Description("Returns true/false, antispam")]
        public bool AddAntiSpam(string DomainName)
        {
            return this.Call<bool, string>(DomainName, "AddAntiSpam");
        }

        [Description("Returns true/false, AddOldMailCopiers")]
        public bool AddOldMailCopiers(string Email)
        {
            return this.Call<bool, string>(Email, "AddOldMailCopiers");
        }


        [Description("Returns true/false, antispam")]
        public bool DeleteAntiSpam(string DomainName)
        {
            return this.Call<bool, string>(DomainName, "DeleteAntiSpam");
        }

        [Description("Returns true/false, antispam")]
        public bool GetAntiSpamOn(string DomainName)
        {
            return this.Call<bool, string>(DomainName, "GetAntiSpamOn");
        }

        [Description("Returns Value")]
        public simpleReturn GetAntiSpam(string DomainName)
        {
            return this.Call<simpleReturn, string>(DomainName, "GetAntiSpam");
        }

        #endregion

        #region HybridPanel

        [Description("")]
        public ReturnMethod AddFtpAccount(ReqFtpInfo extraFtpInfo)
        {
            var req = new ReqFtpInfo() { ServiceSettings = extraFtpInfo.ServiceSettings, MemberId = memberId, ExtraFtpInfo = extraFtpInfo.ExtraFtpInfo };
            return this.Call<ReturnMethod, ReqFtpInfo>(req, "AddFtpAccount");
        }

        [Description("")]
        public List<DropDown> GetDocList(ReqFtpInfo extraFtpInfo)
        {
            try
            {
                var req = new ReqFtpInfo() { ServiceSettings = extraFtpInfo.ServiceSettings, MemberId = memberId, ExtraFtpInfo = extraFtpInfo.ExtraFtpInfo };
                return this.Call<List<DropDown>, ReqFtpInfo>(req, "GetDocList");
            }
            catch
            {
                return null;
            }
        }

        [Description("")]
        public ReturnMethod ChangeFtpPassword(ReqFtpInfo extraFtpInfo)
        {
            var req = new ReqFtpInfo() { ServiceSettings = extraFtpInfo.ServiceSettings, MemberId = memberId, ExtraFtpInfo = extraFtpInfo.ExtraFtpInfo };
            return this.Call<ReturnMethod, ReqFtpInfo>(req, "ChangeFtpPassword");
        }

        [Description("")]
        public ReturnMethod ChangeExtraFtpPassword(ReqFtpInfo extraFtpInfo)
        {
            var req = new ReqFtpInfo() { ServiceSettings = extraFtpInfo.ServiceSettings, MemberId = memberId, ExtraFtpInfo = extraFtpInfo.ExtraFtpInfo };
            return this.Call<ReturnMethod, ReqFtpInfo>(req, "ChangeExtraFtpPassword");
        }


        [Description("")]
        public List<ExtraFtpInfo> GetFtpAccounts(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<List<ExtraFtpInfo>, ReqHostingInfo>(req, "GetFtpAccounts");
        }

        [Description("")]
        public ReturnMethod DeleteFtpAccount(ReqFtpInfo extraFtpInfo)
        {
            var req = new ReqFtpInfo() { ServiceSettings = extraFtpInfo.ServiceSettings, MemberId = memberId, ExtraFtpInfo = extraFtpInfo.ExtraFtpInfo };
            return this.Call<ReturnMethod, ReqFtpInfo>(req, "DeleteFtpAccount");
        }

        [Description("")]
        public ExtraFtpInfo GetFtpInfo(HostingServiceSettings settings)
        {
            try
            {
                var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
                return this.Call<ExtraFtpInfo, ReqHostingInfo>(req, "GetFtpInfo");
            }
            catch
            {
                return null;
            }
        }

        [Description("")]
        public ReturnMethod SetFtpInfo(ReqFtpInfo extraFtpInfo)
        {
            var req = new ReqFtpInfo() { ServiceSettings = extraFtpInfo.ServiceSettings, MemberId = memberId, ExtraFtpInfo = extraFtpInfo.ExtraFtpInfo };
            return this.Call<ReturnMethod, ReqFtpInfo>(req, "SetFtpInfo");
        }

        [Description("")]
        public ReturnMethod AddSubdomain(ReqSubdomainInfo subdomainInfo)
        {
            var req = new ReqSubdomainInfo() { ServiceSettings = subdomainInfo.ServiceSettings, MemberId = memberId, SubdomainInfo = subdomainInfo.SubdomainInfo };
            return this.Call<ReturnMethod, ReqSubdomainInfo>(req, "AddSubdomain");
        }

        [Description("")]
        public List<SubdomainInfo> GetSubdomains(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<List<SubdomainInfo>, ReqHostingInfo>(req, "GetSubdomains");
        }

        [Description("")]
        public ReturnMethod DeleteSubdomain(ReqSubdomainInfo subdomainInfo)
        {
            var req = new ReqSubdomainInfo() { ServiceSettings = subdomainInfo.ServiceSettings, MemberId = memberId, SubdomainInfo = subdomainInfo.SubdomainInfo };
            return this.Call<ReturnMethod, ReqSubdomainInfo>(req, "DeleteSubdomain");
        }

        [Description("")]
        public ReturnMethod AddDatabase(ReqDatabaseInfo databaseInfo)
        {
            var req = new ReqDatabaseInfo() { ServiceSettings = databaseInfo.ServiceSettings, MemberId = memberId, DatabaseInfo = databaseInfo.DatabaseInfo };
            return this.Call<ReturnMethod, ReqDatabaseInfo>(req, "AddDatabase");
        }

        [Description("")]
        public ReturnMethod AddDatabaseUser(ReqDatabaseInfo databaseInfo)
        {
            var req = new ReqDatabaseInfo() { ServiceSettings = databaseInfo.ServiceSettings, MemberId = memberId, DatabaseInfo = databaseInfo.DatabaseInfo };
            return this.Call<ReturnMethod, ReqDatabaseInfo>(req, "AddDatabaseUser");
        }

        [Description("")]
        public List<DatabaseInfo> GetDatabases(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<List<DatabaseInfo>, ReqHostingInfo>(req, "GetDatabases");
        }

        [Description("")]
        public ReturnMethod DeleteDatabase(ReqDatabaseInfo databaseInfo)
        {
            var req = new ReqDatabaseInfo() { ServiceSettings = databaseInfo.ServiceSettings, MemberId = memberId, DatabaseInfo = databaseInfo.DatabaseInfo };
            return this.Call<ReturnMethod, ReqDatabaseInfo>(req, "DeleteDatabase");
        }

        [Description("")]
        public ReturnMethod ManageDatabaseUser(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<ReturnMethod, ReqHostingInfo>(req, "ManageDatabaseUser");
        }

        [Description("")]
        public ReturnMethod AddProtectedDir(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<ReturnMethod, ReqHostingInfo>(req, "AddProtectedDir");
        }

        [Description("")]
        public List<int> GetProtectedDirs(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<List<int>, HostingServiceSettings>(settings, "GetProtectedDirs");
        }

        [Description("")]
        public ReturnMethod DeleteProtectedDir(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<ReturnMethod, ReqHostingInfo>(req, "DeleteProtectedDir");
        }

        [Description("")]
        public ReturnMethod ChangePanelPassword(ReqPanelInfo panelInfo)
        {
            var req = new ReqPanelInfo() { ServiceSettings = panelInfo.ServiceSettings, MemberId = memberId, PanelInfo = panelInfo.PanelInfo };
            return this.Call<ReturnMethod, ReqPanelInfo>(req, "ChangePanelPassword");
        }

        [Description("")]
        public PanelInfo GetPanelAccount(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<PanelInfo, ReqHostingInfo>(req, "GetPanelAccount");
        }

        [Description("")]
        public List<StatisticsInfo> GetStatistics(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<List<StatisticsInfo>, ReqHostingInfo>(req, "GetStatistics");
        }

        [Description("")]
        public ReturnMethod AddDomain(ReqDomainInfo domainInfo)
        {
            var req = new ReqDomainInfo() { ServiceSettings = domainInfo.ServiceSettings, MemberId = memberId, DomainInfo = domainInfo.DomainInfo };
            return this.Call<ReturnMethod, ReqDomainInfo>(req, "AddDomain");
        }

        [Description("")]
        public List<DomainInfo> GetDomains(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<List<DomainInfo>, ReqHostingInfo>(req, "GetDomains");
        }

        [Description("")]
        public ReturnMethod DeleteDomain(ReqDomainInfo domainInfo)
        {
            var req = new ReqDomainInfo() { ServiceSettings = domainInfo.ServiceSettings, MemberId = memberId, DomainInfo = domainInfo.DomainInfo };
            return this.Call<ReturnMethod, ReqDomainInfo>(req, "DeleteDomain");
        }

        [Description("")]
        public ReturnMethod DeleteAccount(ReqClientInfo clientInfo)
        {
            var req = new ReqClientInfo() { ServiceSettings = clientInfo.ServiceSettings, MemberId = memberId, ClientInfo = clientInfo.ClientInfo };
            return this.Call<ReturnMethod, ReqClientInfo>(req, "DeleteAccount");
        }

        [Description("")]
        public ReturnMethod IsSuspendAccount(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<ReturnMethod, ReqHostingInfo>(req, "IsSuspendAccount");
        }

        [Description("")]
        public ReturnMethod SuspendAccount(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<ReturnMethod, ReqHostingInfo>(req, "SuspendAccount");
        }

        [Description("")]
        public ReturnMethod UnsuspendAccount(HostingServiceSettings settings)
        {
            var req = new ReqHostingInfo() { ServiceSettings = settings, MemberId = memberId };
            return this.Call<ReturnMethod, ReqHostingInfo>(req, "UnsuspendAccount");
        }

        #endregion

        #region MailEnableRepository

        [Description("Add new mail account byte")]
        public ReturnMethod AddEmailByte(EmailInfo req)
        {
            return this.Call<ReturnMethod, EmailInfo>(req, "AddEmailByte");
        }

        [Description("Add new mail account")]
        public ReturnMethod AddEmail(EmailInfo req)
        {
            return this.Call<ReturnMethod, EmailInfo>(req, "AddEmail");
        }

        [Description("List of mailboxes")]
        public List<EmailInfo> GetEmailList(EmailInfo req)
        {
            return this.Call<List<EmailInfo>, EmailInfo>(req, "GetEmailList");
        }

        [Description("Get mailbox password")]
        public string GetPassword(EmailInfo req)
        {
            return this.Call<string, EmailInfo>(req, "GetPassword");
        }

        [Description("Get mailbox properties")]
        public EmailInfo GetEmailProp(EmailInfo req)
        {
            return this.Call<EmailInfo, EmailInfo>(req, "GetEmailProp");
        }

        [Description("Delete mail account")]
        public ReturnMethod DeleteEmailAccount(EmailInfo req)
        {
            return this.Call<ReturnMethod, EmailInfo>(req, "DeleteEmailAccount");
        }

        [Description("Update mail account")]
        public ReturnMethod UpdateEmailAccount(EmailInfo req)
        {
            return this.Call<ReturnMethod, EmailInfo>(req, "UpdateEmailAccount");
        }

        [Description("Delete post office")]
        public ReturnMethod DeleteEmailOffice(EmailInfo req)
        {
            return this.Call<ReturnMethod, EmailInfo>(req, "DeleteEmailOffice");
        }

        #endregion

        #region simple dns repository

        public bool WriteDns(string domainName, int mailServerId, int serverId, int memberProductId)
        {
            var req = new ReqWriteDns() { DomainName = domainName, MemberProductId = memberProductId, ServerId = serverId, MailServerId = mailServerId };
            return this.Call<bool, ReqWriteDns>(req, "WriteDns");
        }


        #endregion

    }
}
