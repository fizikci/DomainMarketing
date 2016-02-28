using System.Web;
using DealerSafe.DTO.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;

namespace DealerSafe.ServiceClient
{
    public class PaymentAPI : BaseAPI
    {
        public PaymentAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public PaymentAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }


        [Description("Is payment 3d secure")]
        public IsPayment3dSecureInfo IsPayment3dSecure(ReqIsPayment3dSecure request)
        {
            return this.Call<IsPayment3dSecureInfo, ReqIsPayment3dSecure>(request, "IsPayment3dSecure");
        }

        [Description("Get parameters for 3D Secure")]
        public ThreeDSecureParamsInfo GetThreeDSecureParams(ReqThreeDSecureParams request)
        {
            return this.Call<ThreeDSecureParamsInfo, ReqThreeDSecureParams>(request, "GetThreeDSecureParams");
        }

        [Description("3D Secure control and update")]
        public ThreeDSecureControlInfo ThreeDSecureControlAndUpdate(ReqThreeDSecureControl request)
        {
            return this.Call<ThreeDSecureControlInfo, ReqThreeDSecureControl>(request, "ThreeDSecureControlAndUpdate");
        }

        [Description("Classic VPos of the payment")]
        public ClassicVPosPaymentInfo ClassicVPosPayment(ReqClassicVPosPayment request)
        {
            return this.Call<ClassicVPosPaymentInfo, ReqClassicVPosPayment>(request, "ClassicVPosPayment");
        }

        [Description("Validate of the payment form")]
        public PaymentFormValidateInfo PaymentFormValidate(ReqPaymentForm request)
        {
            return this.Call<PaymentFormValidateInfo, ReqPaymentForm>(request, "PaymentFormValidate");
        }

        [Description("Request of the payment form")]
        public PaymentFormInfo PaymentForm(ReqPaymentForm request)
        {
            return this.Call<PaymentFormInfo, ReqPaymentForm>(request, "PaymentForm");
        }

        [Description("Mail Request of the payment form")]
        public PaymentFormEmailInfo PaymentFormEmail(ReqPaymentFormEmail request)
        {
            return this.Call<PaymentFormEmailInfo, ReqPaymentFormEmail>(request, "PaymentFormEmail");
        }

        [Description("Request of the companies list")]
        public GetCompaniesInfo GetCompanies(ReqGetCompanies request)
        {
            return this.Call<GetCompaniesInfo, ReqGetCompanies>(request, "GetCompanies");
        }

        [Description("Request of the bank list")]
        public GetBankListInfo GetBankList(ReqGetBankList request)
        {
            return this.Call<GetBankListInfo, ReqGetBankList>(request, "GetBankList");
        }

        [Description("Request of the subbank list")]
        public GetSubBankListInfo GetSubBankList(ReqGetSubBankList request)
        {
            return this.Call<GetSubBankListInfo, ReqGetSubBankList>(request, "GetSubBankList");
        }

        [Description("Request of the subbank list")]
        public GetSubBankListInfo GetSubBankList2(ReqGetSubBankList request)
        {
            return this.Call<GetSubBankListInfo, ReqGetSubBankList>(request, "GetSubBankList2");
        }

        [Description("Request of the bank rate list")]
        public GetBankRateInfo GetBankRate(ReqGetBankRate request)
        {
            return this.Call<GetBankRateInfo, ReqGetBankRate>(request, "GetBankRate");
        }

        [Description("Request of the add credit")]
        public AddCreditInfo AddCredit(ReqAddCredit request)
        {
            return this.Call<AddCreditInfo, ReqAddCredit>(request, "AddCredit");
        }

        [Description("Transaction check for garanti cep bank")]
        public CepBankTransactionCheckInfo CepBankTransactionCheck(ReqCepBankTransactionCheck request)
        {
            return this.Call<CepBankTransactionCheckInfo, ReqCepBankTransactionCheck>(request, "CepBankTransactionCheck");
        }

        [Description("Mark Express Checkout")]
        public MarkExpressCheckoutInfo MarkExpressCheckout(ReqMarkExpressCheckout request)
        {
            return this.Call<MarkExpressCheckoutInfo, ReqMarkExpressCheckout>(request, "MarkExpressCheckout");
        }

        [Description("Transaction Check DLL API")]
        public TransactionCheckDLLAPIInfo TransactionCheckDLLAPI(ReqTransactionCheckDLLAPI request)
        {
            return this.Call<TransactionCheckDLLAPIInfo, ReqTransactionCheckDLLAPI>(request, "TransactionCheckDLLAPI");
        }

        [Description("Transaction Start DLL API")]
        public TransactionStartDLLAPIInfo TransactionStartDLLAPI(ReqTransactionStartDLLAPI request)
        {
            return this.Call<TransactionStartDLLAPIInfo, ReqTransactionStartDLLAPI>(request, "TransactionStartDLLAPI");
        }

        [Description("Get Bank")]
        public GetBankInfo GetBank(ReqGetBank request)
        {
            return this.Call<GetBankInfo, ReqGetBank>(request, "GetBank");
        }









        [Description("Payment Information")]
        public ResPaymentListInformation PaymentListInformation(ReqPaymentListInformation req)
        {
            return this.Call<ResPaymentListInformation, ReqPaymentListInformation>(req, "PaymentListInformation");
        }

        [Description("Payment Mobile Sender")]
        public ResPaymentMobileSend PaymentSendMobile(ReqPaymentMobileSend req)
        {
            return this.Call<ResPaymentMobileSend, ReqPaymentMobileSend>(req, "PaymentSendMobile");
        }

        [Description("Payment Mobile Control")]
        public ResPaymentMobileControl PaymentMobileControl(ReqPaymentMobileControl req)
        {
            return this.Call<ResPaymentMobileControl, ReqPaymentMobileControl>(req, "PaymentMobileControl");
        }



        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["paymentServiceURL"]; ;
        }
    }
}
