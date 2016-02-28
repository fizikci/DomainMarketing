using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DealerSafe.DTO.Orders;
using DealerSafe.DTO;
using DealerSafe.DTO.Domain;
using DealerSafe.DTO.HyperV;

namespace DealerSafe.ServiceClient
{
    public class OrdersHyperVAPI : BaseAPI
    {
        public OrdersHyperVAPI(int memberId)
        {
            this.memberId = memberId;
        }

        private void setMemberId()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        public OrdersHyperVAPI(bool useMemberId = true)
        {
            if (useMemberId) setMemberId();    
        }        

        public ResGetProducts GetProducts()
        {
            return Call<ResGetProducts, ReqEmpty>(new ReqEmpty(), "GetProducts");
        }

        public List<PriceInfo> GetPrices(List<int> products)
        {
            return Call<List<PriceInfo>, List<int>>(products, "GetPrices");
        }

        public List<PriceInfo> GetExtensionPrices(ReqGetPrices req)
        {
            return Call<List<PriceInfo>, ReqGetPrices>(req, "GetExtensionPrices");
        }

        public decimal GetMonthlyExtensionPrice(int productId)
        {
            return Call<decimal, int>(productId, "GetMonthlyExtensionPrice");
        }

        public PriceInfo GetComponentPrice(ReqGetPrices req)
        {
            return Call<PriceInfo, ReqGetPrices>(req, "GetComponentPrice");
        }

        public decimal GetServerPrice(ReqOrder req)
        {
            return Call<decimal, ReqOrder>(req, "GetServerPrice");
        }

        public decimal GetMonthlyServerPrice(int serverId)
        {
            return Call<decimal, int>(serverId, "GetMonthlyServerPrice");
        }

        public string GetOrderDescription(ReqOrder req)
        {
            return Call<string, ReqOrder>(req, "GetOrderDescription");
        }
        
        public int AddServer(ReqOrderAddServer req)
        {
            return Call<int, ReqOrderAddServer>(req, "AddServer");
        }

        public int BuildServer(int serverId)
        {
            return Call<int, int>(serverId, "BuildServer");
        }

        public DateTime ExtendPeriod(ReqExtendPeriod req)
        {
            return Call<DateTime, ReqExtendPeriod>(req, "ExtendPeriod");
        }

        public List<ServerInfo> GetServersByCustomer(string customerId)
        {
            return Call<List<ServerInfo>, string>(customerId, "GetServersByCustomer");
        }

        public List<ServerInfoAdmin> GetAllServers()
        {
            return Call<List<ServerInfoAdmin>, ReqEmpty>(new ReqEmpty(), "GetAllServers");
        }     

        public int GetVirtualMachineId(int serverId)
        {
            return Call<int, int>(serverId, "GetVirtualMachineId");
        }

        public ServerExtendedInfo GetServer(int serverId)
        {
            return Call<ServerExtendedInfo, int>(serverId, "GetServer");
        }

        public ServerExtendedInfo GetServerNoMemberCheck(int serverId)
        {
            return Call<ServerExtendedInfo, int>(serverId, "GetServerNoMemberCheck");
        }

        public List<PriceInfo> GetServerPrices(int serverId)
        {
            return Call<List<PriceInfo>, int>(serverId, "GetServerPrices");
        }

        public string GetComponentOrderDescription(ReqComponentOrder req)
        {
            return Call<string, ReqComponentOrder>(req, "GetComponentOrderDescription");
        }

        public int AddComponent(ReqComponentOrder2 req)
        {
            return Call<int, ReqComponentOrder2>(req, "AddComponent");
        }

        public int AddExtension(ReqComponentOrder2 req)
        {
            return Call<int, ReqComponentOrder2>(req, "AddExtension");
        }

        public string GetUzatmaOrderDescription(int serverId)
        {
            return Call<string, int>(serverId, "GetUzatmaOrderDescription");
        }

        public string SendServerReadyEmail(int virtualMachineId)
        {
            return Call<string, int>(virtualMachineId, "SendServerReadyEmail");
        }

        public string SendDiskAddedEmail(int virtualMachineId)
        {
            return Call<string, int>(virtualMachineId, "SendDiskAddedEmail");
        }

        public string SendErrorEmail(ReqError req)
        {
            return Call<string, ReqError>(req, "SendErrorEmail");
        }

        public string SendNewIpAddressEmail(ReqNewIpAddress req)
        {
            return Call<string, ReqNewIpAddress>(req, "SendNewIpAddressEmail");
        }

        public string GeneratePassword()
        {
            return Call<string, ReqEmpty>(new ReqEmpty(), "GeneratePassword");
        }

        public string ValidateOrder(ReqOrder order)
        {
            return Call<string, ReqOrder>(order, "ValidateOrder");
        }

        public int DeleteServerNoMemberCheck(int serverId)
        {
            return Call<int, int>(serverId, "DeleteServerNoMemberCheck");
        }

        public int RemoveServerFromDatabaseNoMemberCheck(int serverId)
        {
            return Call<int, int>(serverId, "RemoveServerFromDatabaseNoMemberCheck");
        }

        public List<int> GetServerExtensions(int serverId)
        {
            return Call<List<int>, int>(serverId, "GetServerExtensions");
        }

        public string ValidateComponent(int component)
        {
            return Call<string, int>(component, "ValidateComponent");
        }

        public int ResetVm(ReqResetVm req)
        {
            return Call<int, ReqResetVm>(req, "ResetVm");
        }

        public List<HyperVResetJobInfo> ListResetJobInfo()
        {
            return Call<List<HyperVResetJobInfo>, ReqEmpty>(new ReqEmpty(), "ListResetJobInfo");
        }

        public List<ProductInfo> GetValidPanels(ReqOrder order)
        {
            return Call<List<ProductInfo>, ReqOrder>(order, "GetValidPanels");
        }

        public List<PhysicalServerInfo> GetPhysicalServers()
        {
            return Call<List<PhysicalServerInfo>, ReqEmpty>(new ReqEmpty(), "GetPhysicalServers");
        }

        public List<PhysicalServerPriceInfo> GetPhysicalServerPrices(int serverId)
        {
            return Call<List<PhysicalServerPriceInfo>, int>(serverId, "GetPhysicalServerPrices");
        }

        public string GetPhysicalServerUzatmaOrderDescription(int serverId)
        {
            return Call<string, int>(serverId, "GetPhysicalServerUzatmaOrderDescription");
        }

        public DateTime PhysicalServerExtendPeriod(ReqExtendPeriod req)
        {
            return Call<DateTime, ReqExtendPeriod>(req, "PhysicalServerExtendPeriod");
        }

        public int SetLiteSpeed(int serverId)
        {
            return Call<int, int>(serverId, "SetLiteSpeed");
        }

        public string GetLiteSpeedOrderDescription(int serverId)
        {
            return Call<string, int>(serverId, "GetLiteSpeedOrderDescription");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["OrdersHyperVServiceURL"];
        }
    }
}
