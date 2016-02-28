using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;

namespace DealerSafe.DTO.BaseKit
{
    public class GetUser : Base
    {
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

        public class Created
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class AccountHolder
        {
            public object @ref { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public object suspended { get; set; }
            public object beta { get; set; }
            public string languageCode { get; set; }
            public object phoneNumber { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public string postcode { get; set; }
            public string country { get; set; }
            public object newsletter { get; set; }
            public object currencyRef { get; set; }
            public string state { get; set; }
            public Capabilities capabilities { get; set; }
            public object accountPaymentMethodRef { get; set; }
            public object cpfNumber { get; set; }
            public object cpfCompany { get; set; }
            public string company { get; set; }
            public bool deleted { get; set; }
            public string storageBytesUsed { get; set; }
            public Created created { get; set; }
            public object lastLogin { get; set; }
            public string accountStatus { get; set; }
            public object seenIntroTour { get; set; }
            public object subscriptionPackageRef { get; set; }
            public object brandRef { get; set; }
            public object nrtStatus { get; set; }
            public object nrtDaysToExpiry { get; set; }
            public object editorAccess { get; set; }
            public object usedFreeDomains { get; set; }
            public object usedImageCredits { get; set; }
        }

        public AccountHolder accountHolder { get; set; }

        public static GetUser Do(int reff)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/users/" + reff.ToString(), Method.GET);
            //request.AddParameter("limit", "1", ParameterType.GetOrPost);
            // request.AddParameter("category", "all",ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<GetUser>(str);
                return ret;
            }

            return null;
        }
    }
}
