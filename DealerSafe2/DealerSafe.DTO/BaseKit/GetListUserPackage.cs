using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace DealerSafe.DTO.BaseKit
{
    public class GetListUserPackage : Base
    {
        public class StartDateTime
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class Updated
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class Capabilities
        {
            public string liveSites { get; set; }
            public string allowUsers { get; set; }
            public string cdnEnabled { get; set; }
            public string cssEditing { get; set; }
            public string themeLevel { get; set; }
            public string freeDomains { get; set; }
            public string htmlEditing { get; set; }
            public string pagesLimited { get; set; }
            public string storageLimit { get; set; }
            public string templateTier { get; set; }
            public string domainMapping { get; set; }
            public string googleAnalytics { get; set; }
            public string ecommerceAllowed { get; set; }
            public string enableEcommerceStore { get; set; }
            public string googleAdWordVoucher { get; set; }
            public string allowExternalRedirects { get; set; }
            public string allowTemplateSave { get; set; }
            public string mailboxes { get; set; }
            public string mobile { get; set; }
            public string siteLock { get; set; }
            public string mobileSites { get; set; }
            public string mobilePublishing { get; set; }
            public string restrictPagesOnPublish { get; set; }
            public string templatesAllowed { get; set; }
            public string imageEditing { get; set; }
            public string imageCredits { get; set; }
            public string seoAndRedirects { get; set; }
            public string facebookPublish { get; set; }
        }

        public class TemplateGroup
        {
            public string name { get; set; }
            public object @ref { get; set; }
        }

        public class Package
        {
            public object @ref { get; set; }
            public string name { get; set; }
            public object active { get; set; }
            public object global { get; set; }
            public object urlID { get; set; }
            public string notifyMarketing { get; set; }
            public string productType { get; set; }
            public string type { get; set; }
            public string contentType { get; set; }
            public object offerRebillMonths { get; set; }
            public string offerRebillActive { get; set; }
            public object trialDays { get; set; }
            public string imageURL { get; set; }
            public object requirePurchasedDomain { get; set; }
            public object allowMultiplePurchase { get; set; }
            public object showInStore { get; set; }
            public string bannerHTML { get; set; }
            public string affiliateLink { get; set; }
            public object brandRef { get; set; }
            public string brandName { get; set; }
            public object defaultCurrencyRef { get; set; }
            public string currencyCode { get; set; }
            public string currencyName { get; set; }
            public string currencyTitle { get; set; }
            public Capabilities capabilities { get; set; }
            public object templateGroupRef { get; set; }
            public TemplateGroup templateGroup { get; set; }
            public object displayOrder { get; set; }
        }

        public class AccountPackage
        {
            public object @ref { get; set; }
            public StartDateTime startDateTime { get; set; }
            public object endDateTime { get; set; }
            public Updated updated { get; set; }
            public object deleteOnExpiry { get; set; }
            public object isFree { get; set; }
            public object billingPeriodMonths { get; set; }
            public object activationCode { get; set; }
            public Package package { get; set; }
        }

        public List<AccountPackage> accountPackages { get; set; }

        public static GetListUserPackage Do(int userRef)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/users/" + userRef.ToString() + "/account-packages", Method.GET);
            //request.AddParameter("users", "1", ParameterType.GetOrPost);
            // request.AddParameter("category", "all",ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<GetListUserPackage>(str);
                return ret;
            }

            return null;
        }
    }
}
