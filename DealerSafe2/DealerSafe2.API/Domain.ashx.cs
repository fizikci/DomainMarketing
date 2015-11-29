using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using Newtonsoft.Json.Converters;
using rfl = System.Reflection;
using System.Web;
using Newtonsoft.Json;
using DealerSafe2.DTO;
using Formatting = Newtonsoft.Json.Formatting;
using System.Web.SessionState;
using DealerSafe2.DTO.EntityInfo.Products.SSL;
using DealerSafe2.API.Entity.Products.SSL;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.API.Api.Library;
using DealerSafe2.API.Entity.Products.Domain;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe.ServiceClient;
using Epp.Protocol.Domains;

namespace DealerSafe2.API
{
    /// <summary>
    /// Summary description for ApiJson
    /// </summary>
    public class Domain : ApiJson
    {
        public new bool Login(ReqLogin req)
        {
            Member member = Provider.Database.Read<Member>("Email={0} AND Password={1} AND (IsDeleted=0 OR IsDeleted is null)", req.Email, System.Utility.MD5(req.Password));

            if (member == null)
                throw new APIException(Provider.TR("Invalid email or password"));

            var reseller = member.GetAdminResellerMember();
            if (reseller == null)
                throw new APIException("Reseller undefined! (This Member's ClientId should have an AdminMemberId)");

            doLoginForMember(member);

            return true;
        }

        public new bool Logout(ReqEmpty req)
        {
            return base.Logout(req);
        }

        public Dictionary<string, bool> CheckDomainAvailablity(List<string> domainNames)
        {
            var eppApi = new EppAPI();
            return eppApi
                .DomainCheck(new DealerSafe.DTO.Epp.Request.ReqDomainCheck { DomainNames = domainNames.Distinct().ToList() })
                .DomainInfos.ToDictionary(x=>x.DomainName, x=>x.Available);
        }

        public string PlaceOrderForCreate(ReqPlaceOrderForDomain req)
        {
            var order = placeOrderForDomain(req, ProductPriceTypes.Create);
            return order.Items[0].Id;
        }

        public string PlaceOrderForRenew(ReqPlaceOrderForDomain req)
        {
            var order = placeOrderForDomain(req, ProductPriceTypes.Renew);
            return order.Items[0].Id;
        }

        public string PlaceOrderForRestore(ReqPlaceOrderForDomain req)
        {
            var order = placeOrderForDomain(req, ProductPriceTypes.Restore);
            return order.Items[0].Id;
        }

        public string PlaceOrderForTransfer(ReqPlaceOrderForDomain req)
        {
            if (req.TransferCode.IsEmpty())
                throw new APIException("TransferCode parameter cannot be empty");

            var order = placeOrderForDomain(req, ProductPriceTypes.Transfer);

            var memberDomain = Provider.Database.Read<MemberDomain>("DomainName = {0}", req.DomainName);
            if (memberDomain == null)
                throw new APIException("Critical error: MemberDomain record for domain name (" + req.DomainName + ") for transfer not found!!!");

            memberDomain.AuthInfo = req.TransferCode;
            memberDomain.Save();

            var job = Provider.Database.Read<Job>("RelatedEntityName={0} AND RelatedEntityId={1}", "OrderItem", order.Items[0].Id);
            job.State = JobStates.Done;
            job.Save();

            new Job()
            {
                Command = JobCommands.DomainTransferQuery,
                Name = req.DomainName,
                RelatedEntityName = "OrderItem",
                RelatedEntityId = order.Items[0].Id,
                State = JobStates.NotStarted,
                Executer = JobExecuters.Machine
            }.Save();

            return order.Items[0].Id;
        }

        private OrderInfo placeOrderForDomain(ReqPlaceOrderForDomain req, ProductPriceTypes op)
        {
            if (req.DomainName.IsEmpty())
                throw new APIException("DomainName parameter cannot be empty");

            var extension = DomainUtility.GetZoneFromDomainName(req.DomainName);
            if (extension == null)
                throw new APIException("We dont have such extension: " + DomainUtility.GetDomainExtension(req.DomainName));

            ProductPrice pp = Provider.Database.Read<ProductPrice>("ProductId = {0} AND ProductPriceType = {1} AND Amount = {2}", extension.Id, op.ToString(), req.Years);
            if(pp==null)
                pp = Provider.Database.Read<ProductPrice>("ProductId = {0} AND ProductPriceType = {1}", extension.Id, op.ToString());
            if (pp == null)
                throw new APIException("There is no ProductPrice for Product " + extension.Id + " and ProductPriceType " + op + " with amount of " + req.Years + " years");

            OrderItemInfo oi = new OrderItemInfo() { ProductPriceId = pp.Id, Amount = req.Years };
            oi.DisplayName = req.DomainName;

            var basket = Order.GetMemberBasket();
            basket.RemoveAllItems();
            basket.AddItem(oi);

            if (basket.TotalPrice == 0)
                throw new APIException("Order total price must be bigger than zero");

            var reseller = Provider.CurrentMember.GetAdminResellerMember();
            if (reseller == null)
                throw new APIException("Reseller undefined! (This Member's ClientId should have an AdminMemberId)");

            if (reseller.CreditBalance < basket.TotalPrice)
                throw new APIException("Insufficient credits");

            var order = CreateOrderFromBasket("");
            return order;
        }

        public bool CancelOrderAndRefund(string orderReference)
        {
            OrderItem oi = Provider.Database.Read<OrderItem>("Id={0}", orderReference);
            if (oi == null)
                throw new APIException("OrderItem not found. refNo: " + orderReference);

            MemberProduct mp = Provider.Database.Read<MemberProduct>("OrderItemId = {0}", oi.Id);
            if (mp == null)
                throw new APIException("Critical error: OrderItem exists but MemberProduct doesn't, for orderItem : " + oi.Id);

            if (mp.MemberId != Provider.CurrentMember.Id)
                throw new APIException("Cancellation and refund request can only be send by the domain owner");

            MemberDomain md = Provider.Database.Read<MemberDomain>("Id = {0}", mp.Id);
            if (md == null)
                throw new APIException("Critical error: MemberProduct exists but MemberDomain doesn't, for memberProduct : " + mp.Id);

            if (mp.StartDate < Provider.Database.Now.AddDays(-5))
                throw new APIException("You can cancel your domain and refund in the first 5 days of your domain registration.");

            var job = new Job { 
                Command = JobCommands.DomainCancel,
                Executer = JobExecuters.Machine,
                RelatedEntityId = oi.Id,
                RelatedEntityName = "OrderItem",
                StartDate = Provider.Database.Now,
                State = JobStates.NotStarted
            };
            job.Save();

            return true;
        }

        public string GetOrderStatus(string orderReference)
        {
            OrderItem oi = Provider.Database.Read<OrderItem>("Id={0}", orderReference);
            if (oi == null)
                throw new APIException("OrderItem not found. refNo: " + orderReference);

            MemberProduct mp = Provider.Database.Read<MemberProduct>("OrderItemId = {0}", oi.Id);
            if (mp == null)
                throw new APIException("Critical error: OrderItem exists but MemberProduct doesn't, for orderItem : " + oi.Id);

            MemberDomain md = Provider.Database.Read<MemberDomain>("Id = {0}", mp.Id);
            if (md == null)
                throw new APIException("Critical error: MemberProduct exists but MemberDomain doesn't, for memberProduct : " + mp.Id);

            if (mp.MemberId != Provider.CurrentMember.Id)
                throw new APIException("GetOrderStatus request can only be send by the domain owner");

            return md.RegistryStatus;
        }

        public bool UpdateDomainNameServers(ReqUpdateDomainNameServers req)
        {
            MemberDomain md = Provider.Database.Read<MemberDomain>("DomainName = {0}", req.DomainName);
            if (md == null)
                throw new APIException("Domain name not found: " + req.DomainName);

            MemberProduct mp = Provider.Database.Read<MemberProduct>("Id = {0}", md.Id);
            if (mp == null)
                throw new APIException("Critical error: MemberDomain exists but MemberProduct doesn't, for domain : " + req.DomainName);

            if (mp.MemberId != Provider.CurrentMember.Id)
                throw new APIException("Creditentials not authorized for this domain: " + req.DomainName);

            EppAPI eppApi = new EppAPI();

            var res = eppApi.HostCheck(new DealerSafe.DTO.Epp.Request.ReqHostCheck { DomainName = req.DomainName, HostNames = req.NameServers });
            foreach (var hostInfo in res.HostInfos)
            {
                if (hostInfo.Available) {
                    var res2 = eppApi.HostCreate(new DealerSafe.DTO.Epp.Request.ReqHostCreate {DomainName = req.DomainName, HostName = hostInfo.HostName });

                }
            }

            var res3 = eppApi.DomainUpdate(new DealerSafe.DTO.Epp.Request.ReqDomainUpdate
            {
                Rem = new Epp.Protocol.Domains.DomainAddRemType
                {
                    NameServers = new Epp.Protocol.Domains.NameServerList(md.NameServers.SplitWithTrim(',').Select(ns => new NameServerInfo { HostName = ns }))
                },
                Add = new Epp.Protocol.Domains.DomainAddRemType
                {
                    NameServers = new Epp.Protocol.Domains.NameServerList(req.NameServers.Select(ns => new NameServerInfo {HostName = ns }))
                },
                DomainName = req.DomainName
            });

            return true;
        }

    }

}