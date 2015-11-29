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

namespace DealerSafe2.API
{
    /// <summary>
    /// Summary description for ApiJson
    /// </summary>
    public class SignSec : ApiJson
    {
        public new bool Login(ReqLogin req)
        {
            Member member = Provider.Database.Read<Member>("Email={0} AND Password={1} AND IsDeleted=0", req.Email, System.Utility.MD5(req.Password));

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

        public string PlaceOrder(string productPriceId)
        {
            if(string.IsNullOrWhiteSpace(productPriceId))
                throw new APIException("OrderItemId parameter cannot be empty");

            OrderItemInfo oi = new OrderItemInfo() {ProductPriceId = productPriceId};

            var basket = Order.GetMemberBasket();
            basket.RemoveAllItems();
            basket.AddItem(oi);

            if(basket.TotalPrice == 0)
                throw new APIException("Order total price must be bigger than zero");

            var reseller = Provider.CurrentMember.GetAdminResellerMember();
            if (reseller == null)
                throw new APIException("Reseller undefined! (This Member's ClientId should have an AdminMemberId)");

            if (reseller.CreditBalance < basket.TotalPrice)
                throw new APIException("Insufficient credits");

            var order = CreateOrderFromBasket("");

            return order.Items[0].Id;
        }

        public new List<string> GetDVEmailAddressList(string domainName)
        {
            return base.GetDVEmailAddressList(domainName);
        }

        public bool SendSSLInfo(MemberSSLInfoForReseller req)
        {
            if (string.IsNullOrWhiteSpace(req.OrderItemId))
                throw new APIException("OrderItemId parameter cannot be empty");
            if (string.IsNullOrWhiteSpace(req.DCVEmail))
                throw new APIException("DCVEmail parameter cannot be empty");
            if (string.IsNullOrWhiteSpace(req.CSRCode))
                throw new APIException("CSRCode parameter cannot be empty");

            var decodedCSR = this.DecodeCSR(new ReqDecodeCSR() { csr = req.CSRCode });

            var memberProd = Provider.Database.Read<MemberProduct>("OrderItemId={0}", req.OrderItemId);
            var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", memberProd.Id);
            if(memberSSL==null)
                throw  new APIException("OrderItemId is invalid, please use the return value of PlaceOrder as OrderItemId");

            memberSSL.CsrC = decodedCSR.C;
            memberSSL.CsrCN = decodedCSR.CN;
            memberSSL.CsrEmail = decodedCSR.Email;
            memberSSL.CsrL = decodedCSR.L;
            memberSSL.CsrO = decodedCSR.O;
            memberSSL.CsrOU = decodedCSR.OU;
            memberSSL.CsrPOBox = decodedCSR.POBox;
            memberSSL.CsrPhone = decodedCSR.Phone;
            memberSSL.CsrPostalCode = decodedCSR.PostalCode;
            memberSSL.CsrS = decodedCSR.S;
            memberSSL.CsrStreet = decodedCSR.STREET;
            memberSSL.ReqCSRCode = req.CSRCode;
            memberSSL.ReqDCVEmail = req.DCVEmail;
            
            memberSSL.Save();

            var memberSSLInfo = memberSSL.ToEntityInfo<MemberSSLInfo>();
            memberProd.CopyPropertiesWithSameName(memberSSLInfo);

            return base.SaveMemberSSLInfo(memberSSLInfo);
        }

        public string GetSSLResult(string orderItemId)
        {
            var memberProd = Provider.Database.Read<MemberProduct>("OrderItemId={0}", orderItemId);
            var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", memberProd.Id);
            if (memberSSL == null)
                throw new APIException("OrderItemId is invalid, please use the return value of PlaceOrder as OrderItemId");

            return memberSSL.State.ToString();
        }

        public string GetSSLDownloadLink(string orderItemId)
        {
            var memberProd = Provider.Database.Read<MemberProduct>("OrderItemId={0}", orderItemId);
            var memberSSL = Provider.Database.Read<MemberSSL>("Id={0}", memberProd.Id);
            if (memberSSL == null)
                throw new APIException("OrderItemId is invalid, please use the return value of PlaceOrder as OrderItemId");

            if(memberSSL.State != SSLStates.Completed)
                throw new APIException("You can download SSL certificate files when the SSL result is 'Completed'. Please use GetSSLResult method to check the SSL result.");

            return "/PaymentGateway/DownloadCertificate.ashx?orderItemId=" + orderItemId;
        }
    }

}