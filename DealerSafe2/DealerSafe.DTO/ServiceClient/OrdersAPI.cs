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

namespace DealerSafe.ServiceClient
{
    public class OrdersAPI : BaseAPI
    {
        public OrdersAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public OrdersAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }

        [Description("Returns the current order (basket) of the member specified by id")]
        public PurchaseOrderInfo GetCurrentOrder(int memberId)
        {
            ReqGetCurrentOrder request = new ReqGetCurrentOrder { MemberId = memberId };
            return Call<PurchaseOrderInfo, ReqGetCurrentOrder>(request, "GetCurrentOrder");
        }

        [Description("Adds item to the current order (basket) of the member specified by id")]
        public int AddOrderDetail(int memberId, OrderDetailInfo orderDetail)
        {
            ReqOrderAddDetail request = new ReqOrderAddDetail { MemberId = memberId, OrderDetail = orderDetail };
            return Call<ResOrderAddDetail, ReqOrderAddDetail>(request, "AddOrderDetail").OrderDetailId;
        }

        [Description("Recalculate product")]
        public CalcProductInfo CalcProduct(ReqCalcProduct request)
        {
            return this.Call<CalcProductInfo, ReqCalcProduct>(request, "CalcProduct");
        }

        [Description("Is coupon valid check")]
        public IsCouponValidNewInfo IsCouponValidNew(ReqIsCouponValidNew request)
        {
            return this.Call<IsCouponValidNewInfo, ReqIsCouponValidNew>(request, "IsCouponValidNew");
        }

        [Description("Get Coupon Detail")]
        public GetCouponInfo GetCoupon(ReqGetCoupon request)
        {
            return this.Call<GetCouponInfo, ReqGetCoupon>(request, "GetCoupon");
        }

        [Description("Execute Coupon Last")]
        public ExecuteCouponLastInfo ExecuteCouponLast(ReqExecuteCouponLast request)
        {
            return this.Call<ExecuteCouponLastInfo, ReqExecuteCouponLast>(request, "ExecuteCouponLast");
        }

        [Description("Update coupon status")]
        public ExecuteCouponStatusInfo ExecuteCouponStatus(ReqExecuteCouponStatus request)
        {
            return this.Call<ExecuteCouponStatusInfo, ReqExecuteCouponStatus>(request, "ExecuteCouponStatus");
        }

        [Description("Modify Order For Coupon Execution")]
        public ModifyOrderForCouponExecutionInfo ModifyOrderForCouponExecution(ReqModifyOrderForCouponExecution request)
        {
            return this.Call<ModifyOrderForCouponExecutionInfo, ReqModifyOrderForCouponExecution>(request, "ModifyOrderForCouponExecution");
        }

        [Description("Product list of the product ids")]
        public GetProductListInfo GetProductList(ReqGetProductListNew request)
        {
            return this.Call<GetProductListInfo, ReqGetProductListNew>(request, "GetProductList");
        }

        [Description("Bank details")]
        public BankDetailInfo BankDetail(ReqBankDetail request)
        {
            return this.Call<BankDetailInfo, ReqBankDetail>(request, "BankDetail");
        }

        [Description("Create order on database")]
        public CreateOrderOnDatabaseInfo CreateOrderOnDatabase(ReqCreateOrderOnDatabase request)
        {
            return this.Call<CreateOrderOnDatabaseInfo, ReqCreateOrderOnDatabase>(request, "CreateOrderOnDatabase");
        }

        [Description("Add to queue")]
        public AddToQueueInfo AddToQueue(ReqAddToQueue request)
        {
            return this.Call<AddToQueueInfo, ReqAddToQueue>(request, "AddToQueue");
        }

        [Description("Complete order actions")]
        public CompleteOrderActionsInfo CompleteOrderActions(ReqCompleteOrderActions request)
        {
            return this.Call<CompleteOrderActionsInfo, ReqCompleteOrderActions>(request, "CompleteOrderActions");
        }

        [Description("Change Order And Pay Type")]
        public ChangeOrderAndPayTypeInfo ChangeOrderAndPayType(ReqChangeOrderAndPayType request)
        {
            return this.Call<ChangeOrderAndPayTypeInfo, ReqChangeOrderAndPayType>(request, "ChangeOrderAndPayType");
        }

        [Description("Payment Control And Update Domain")]
        public PaymentControlAndUpdateDomainInfo PaymentControlAndUpdateDomain(ReqPaymentControlAndUpdateDomain request)
        {
            return this.Call<PaymentControlAndUpdateDomainInfo, ReqPaymentControlAndUpdateDomain>(request, "PaymentControlAndUpdateDomain");
        }

        [Description("Existing Order First Process")]
        public ExistingOrderFirstProcessInfo ExistingOrderFirstProcess(ReqExistingOrderFirstProcess request)
        {
            return this.Call<ExistingOrderFirstProcessInfo, ReqExistingOrderFirstProcess>(request, "ExistingOrderFirstProcess");
        }

        [Description("Modify Order For Credit Execution")]
        public ModifyOrderForCreditExecutionInfo ModifyOrderForCreditExecution(ReqModifyOrderForCreditExecution request)
        {
            return this.Call<ModifyOrderForCreditExecutionInfo, ReqModifyOrderForCreditExecution>(request, "ModifyOrderForCreditExecution");
        }

        [Description("Get ProductType List")]
        public ProductTypeInfo GetProductType(ReqProductType request)
        {
            return this.Call<ProductTypeInfo, ReqProductType>(request, "GetProductType");
        }

        [Description("Update order details")]
        public UpdateOrderDetailInfo UpdateOrderDetail(ReqUpdateOrderDetail request)
        {
            return this.Call<UpdateOrderDetailInfo, ReqUpdateOrderDetail>(request, "UpdateOrderDetail");
        }

        [Description("Update order")]
        public UpdateOrderInfo UpdateOrder(ReqUpdateOrder request)
        {
            return this.Call<UpdateOrderInfo, ReqUpdateOrder>(request, "UpdateOrder");
        }

        [Description("Get Payment details")]
        public GetPaymentsInfo GetPayments(ReqPayments request)
        {
            return this.Call<GetPaymentsInfo, ReqPayments>(request, "GetPayments");
        }

        [Description("Delete order")]
        public DeleteOrderInfo DeleteOrder(ReqDeleteOrder request)
        {
            return this.Call<DeleteOrderInfo, ReqDeleteOrder>(request, "DeleteOrder");
        }

        [Description("Delete orders")]
        public bool DeleteOrders(ReqDeleteOrders request)
        {
            return Call<bool, ReqDeleteOrders>(request, "DeleteOrders");
        }

        [Description("Delete order details")]
        public DeleteOrderDetailInfo DeleteOrderDetail(ReqDeleteOrderDetail request)
        {
            return this.Call<DeleteOrderDetailInfo, ReqDeleteOrderDetail>(request, "DeleteOrderDetail");
        }

        [Description("Bind DB")]
        public BindDGInfo BindDG(ReqbindDG request)
        {
            return this.Call<BindDGInfo, ReqbindDG>(request, "BindDG");
        }
       
        [Description("Get GetOrderDetail details")]
        public GetOrderDetailInfo GetOrderDetail(ReqGetOrderDetail request)
        {
            return this.Call<GetOrderDetailInfo, ReqGetOrderDetail>(request, "GetOrderDetail");
        }

        [Description("Get orders list")]
        public GetOrdersInfo GetOrders(ReqGetOrders request)
        {
            return this.Call<GetOrdersInfo, ReqGetOrders>(request, "GetOrders");
        }

        [Description("Get Credit Payments")]
        public GetCreditPaymentsInfo GetCreditPayments(ReqGetCreditPayments request)
        {
            return this.Call<GetCreditPaymentsInfo, ReqGetCreditPayments>(request, "GetCreditPayments");
        }

        [Description("Get Credits")]
        public GetCreditsInfo GetCredits(ReqGetCredits request)
        {
            return this.Call<GetCreditsInfo, ReqGetCredits>(request, "GetCredits");
        }

        [Description("Get Payment Types")]
        public GetPaymentTypeInfo GetPaymentType(ReqGetPaymentType request)
        {
            return this.Call<GetPaymentTypeInfo, ReqGetPaymentType>(request, "GetPaymentType");
        }

        [Description("Calculate Order Amount With Company")]
        public GetCalculateOrderAmountWithCompanyInfo GetCalculateOrderAmountWithCompany(ReqGetCalculateOrderAmountWithCompany request)
        {
            return this.Call<GetCalculateOrderAmountWithCompanyInfo, ReqGetCalculateOrderAmountWithCompany>(request, "GetCalculateOrderAmountWithCompany");
        }

        [Description("Execute Coupon After Order")]
        public ExecuteCouponAfterOrderInfo ExecuteCouponAfterOrder(ReqExecuteCouponAfterOrder request)
        {
            return this.Call<ExecuteCouponAfterOrderInfo, ReqExecuteCouponAfterOrder>(request, "ExecuteCouponAfterOrder");
        }

        [Description("Update coupon status")]
        public ExecuteCouponInfo ExecuteCoupon(ReqExecuteCoupon request)
        {
            return this.Call<ExecuteCouponInfo, ReqExecuteCoupon>(request, "ExecuteCoupon");
        }

        [Description("Update CouponID For Orders")]
        public UpdateCouponIDForOrdersInfo UpdateCouponIDForOrders(ReqUpdateCouponIDForOrders request)
        {
            return this.Call<UpdateCouponIDForOrdersInfo, ReqUpdateCouponIDForOrders>(request, "UpdateCouponIDForOrders");
        }

        [Description("Get Credit Reports")]
        public GetCreditReportsInfo GetCreditReports(ReqGetCreditReports request)
        {
            return this.Call<GetCreditReportsInfo, ReqGetCreditReports>(request, "GetCreditReports");
        }

        [Description("Add Credit For Rejection")]
        public AddCreditForRejectionInfo AddCreditForRejection(ReqAddCreditForRejection request)
        {
            return this.Call<AddCreditForRejectionInfo, ReqAddCreditForRejection>(request, "AddCreditForRejection");
        }

        [Description("Update CreditReportsID For Orders")]
        public UpdateCreditReportsIDForOrdersInfo UpdateCreditReportsIDForOrders(ReqUpdateCreditReportsIDForOrders request)
        {
            return this.Call<UpdateCreditReportsIDForOrdersInfo, ReqUpdateCreditReportsIDForOrders>(request, "UpdateCreditReportsIDForOrders");
        }

        [Description("Delete Payment")]
        public DeletePaymentInfo DeletePayment(ReqDeletePayment request)
        {
            return this.Call<DeletePaymentInfo, ReqDeletePayment>(request, "DeletePayment");
        }

        [Description("Get Orders Details")]
        public GetOrdersDetailsInfo GetOrdersDetails(ReqGetOrdersDetails request)
        {
            return this.Call<GetOrdersDetailsInfo, ReqGetOrdersDetails>(request, "GetOrdersDetails");
        }

        [Description("View Members DNS And Domain Price")]
        public ViewMembersDNSAndDomainPriceInfo GetViewMembersDNSAndDomainPrice(ReqViewMembersDNSAndDomainPrice request)
        {
            return this.Call<ViewMembersDNSAndDomainPriceInfo, ReqViewMembersDNSAndDomainPrice>(request, "GetViewMembersDNSAndDomainPrice");
        }

        [Description("Delete Orders Detail")]
        public DeleteOrdersDetailInfo DeleteOrdersDetail(ReqDeleteOrdersDetail request)
        {
            return this.Call<DeleteOrdersDetailInfo, ReqDeleteOrdersDetail>(request, "DeleteOrdersDetail");
        }

        [Description("Get Domain Types")]
        public DomainTypesInfo GetDomainTypes(ReqDomainTypes request)
        {
            return this.Call<DomainTypesInfo, ReqDomainTypes>(request, "GetDomainTypes");
        }

        [Description("Get ssl type list")]
        public SSLTypesInfo GetSSLTypes(ReqSSLTypes request)
        {
            return this.Call<SSLTypesInfo, ReqSSLTypes>(request, "GetSSLTypes");
        }

        [Description("Static IP Types")]
        public StaticIPTypesInfo GetStaticIPTypes(ReqStaticIPTypes request)
        {
            return this.Call<StaticIPTypesInfo, ReqStaticIPTypes>(request, "GetStaticIPTypes");
        }

        [Description("Get Server Type List")]
        public ServerTypeInfo GetServerType(ReqServerType request)
        {
            return this.Call<ServerTypeInfo, ReqServerType>(request, "GetServerType");
        }

        [Description("Get Members SERVER Plugins")]
        public MembersSERVERPluginsInfo GetMembersSERVERPlugins(ReqMembersSERVERPlugins request)
        {
            return this.Call<MembersSERVERPluginsInfo, ReqMembersSERVERPlugins>(request, "GetMembersSERVERPlugins");
        }

        [Description("Get Web Klavuzu")]
        public WebKlavuzuInfo GetWebKlavuzu(ReqWebKlavuzu request)
        {
            return this.Call<WebKlavuzuInfo, ReqWebKlavuzu>(request, "GetWebKlavuzu");
        }

        [Description("Get Gift Voucher")]
        public GiftVoucherInfo GetGiftVoucher(ReqGiftVoucher request)
        {
            return this.Call<GiftVoucherInfo, ReqGiftVoucher>(request, "GetGiftVoucher");
        }

        [Description("Get Premium Tv Domains")]
        public PremiumTvDomainsInfo GetPremiumTvDomains(ReqPremiumTvDomains request)
        {
            return this.Call<PremiumTvDomainsInfo, ReqPremiumTvDomains>(request, "GetPremiumTvDomains");
        }

        [Description("Delete order detail for order list")]
        public DeleteOrderDetailForOrderListInfo DeleteOrderDetailForOrderList(ReqDeleteOrderDetailForOrderList request)
        {
            return this.Call<DeleteOrderDetailForOrderListInfo, ReqDeleteOrderDetailForOrderList>(request, "DeleteOrderDetailForOrderList");
        }

        [Description("Get order detail for order list")]
        public GetOrderDetailForOrderListInfo GetOrderDetailForOrderList(ReqGetOrderDetailForOrderList request)
        {
            return this.Call<GetOrderDetailForOrderListInfo, ReqGetOrderDetailForOrderList>(request, "GetOrderDetailForOrderList");
        }

        [Description("Get order list")]
        public GetOrderListInfo GetOrderList(ReqGetOrderList request)
        {
            return this.Call<GetOrderListInfo, ReqGetOrderList>(request, "GetOrderList");
        }

        [Description("Get deleting orders")]
        public DeletingOrdersInfo GetDeletingOrders(ReqDeletingOrders request)
        {
            return this.Call<DeletingOrdersInfo, ReqDeletingOrders>(request, "GetDeletingOrders");
        }

        [Description("Get problematic payment list")]
        public ProblematicPaymentListInfo GetProblematicPaymentList(ReqProblematicPaymentList request)
        {
            return this.Call<ProblematicPaymentListInfo, ReqProblematicPaymentList>(request, "GetProblematicPaymentList");
        }

        [Description("Write 3D Bank Response XML")]
        public Write3DBankResponseXMLInfo Write3DBankResponseXML(ReqWrite3DBankResponseXML request)
        {
            return this.Call<Write3DBankResponseXMLInfo, ReqWrite3DBankResponseXML>(request, "Write3DBankResponseXML");
        }

        [Description("Success 3D payment after process")]
        public Success3DPaymentAfterProcessInfo Success3DPaymentAfterProcess(ReqSuccess3DPaymentAfterProcess request)
        {
            return this.Call<Success3DPaymentAfterProcessInfo, ReqSuccess3DPaymentAfterProcess>(request, "Success3DPaymentAfterProcess");
        }

        [Description("Get bank errors")]
        public BankErrorsInfo GetBankErrors(ReqBankErrors request)
        {
            return this.Call<BankErrorsInfo, ReqBankErrors>(request, "GetBankErrors");
        }

        [Description("Payment fail")]
        public PaymentFailInfo PaymentFail(ReqPaymentFail request)
        {
            return this.Call<PaymentFailInfo, ReqPaymentFail>(request, "PaymentFail");
        }

        [Description("Add Orders Ip Address")]
        public OrdersIpAddressInfo AddOrdersIpAddress(ReqOrdersIpAddress request)
        {
            return this.Call<OrdersIpAddressInfo, ReqOrdersIpAddress>(request, "AddOrdersIpAddress");
        }

        [Description("Get Order Count For Coupon")]
        public int GetOrderCountForCoupon(ReqEmpty request)
        {
            return this.Call<int, ReqEmpty>(request, "GetOrderCountForCoupon");
        }

        [Description("Order List With Coupon")]
        public OrderListWithCouponInfo OrderListWithCoupon(ReqOrderListWithCoupon request)
        {
            return this.Call<OrderListWithCouponInfo, ReqOrderListWithCoupon>(request, "OrderListWithCoupon");
        }

        [Description("Get My Coupons")]
        public GetMyCouponsInfo GetMyCoupons(ReqGetMyCoupons request)
        {
            return this.Call<GetMyCouponsInfo, ReqGetMyCoupons>(request, "GetMyCoupons");
        }

        [Description("Get orders for credit management page")]
        public OrdersForCreditManagementPageInfo GetOrdersForCreditManagementPage(ReqOrdersForCreditManagementPage request)
        {
            return this.Call<OrdersForCreditManagementPageInfo, ReqOrdersForCreditManagementPage>(request, "GetOrdersForCreditManagementPage");
        }

        [Description("Get Credits Report")]
        public GetCreditsReportInfo GetCreditsReportForCreditPage(ReqGetCreditsReportInfo request)
        {
            return this.Call<GetCreditsReportInfo, ReqGetCreditsReportInfo>(request, "GetCreditsReportForCreditPage");
        }

        [Description("Delete Credit")]
        public DeleteCreditInfo DeleteCredit(ReqDeleteCredit request)
        {
            return this.Call<DeleteCreditInfo, ReqDeleteCredit>(request, "DeleteCredit");
        }

        [Description("Get Page Krediler")]
        public GetPageKredilerInfo GetPageKrediler(ReqGetPageKrediler request)
        {
            return this.Call<GetPageKredilerInfo, ReqGetPageKrediler>(request, "GetPageKrediler");
        }

        [Description("Blocked Credit Orders")]
        public BlockedCreditOrdersInfo GetBlockedCreditOrders(ReqBlockedCreditOrders request)
        {
            return this.Call<BlockedCreditOrdersInfo, ReqBlockedCreditOrders>(request, "GetBlockedCreditOrders");
        }

        [Description("Member basket list")]
        public MemberBasketListInfo GetMemberBasketList(ReqMemberBasketList request)
        {
            return this.Call<MemberBasketListInfo, ReqMemberBasketList>(request, "GetMemberBasketList");
        }

        [Description("Update member basket")]
        public UpdateMemberBasketInfo UpdateMemberBasket(ReqUpdateMemberBasket request)
        {
            return this.Call<UpdateMemberBasketInfo, ReqUpdateMemberBasket>(request, "UpdateMemberBasket");
        }

        [Description("Delete member basket")]
        public DeleteMemberBasketInfo DeleteMemberBasket(ReqDeleteMemberBasket request)
        {
            return this.Call<DeleteMemberBasketInfo, ReqDeleteMemberBasket>(request, "DeleteMemberBasket");
        }
        [Description("Delete All Member Basket")]
        public DeleteAllMemberBasketInfo DeleteAllMemberBasket(ReqDeleteAllMemberBasket request)
        {
            return this.Call<DeleteAllMemberBasketInfo, ReqDeleteAllMemberBasket>(request, "DeleteAllMemberBasket");
        }

        [Description("Order Id Set Member Basket")]
        public OrderIdSetMemberBasketInfo OrderIdSetMemberBasket(ReqOrderIdSetMemberBasket request)
        {
            return this.Call<OrderIdSetMemberBasketInfo, ReqOrderIdSetMemberBasket>(request, "OrderIdSetMemberBasket");
        }
        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["ordersServiceURL"];
        }
    }
}
