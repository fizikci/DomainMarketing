using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;

namespace DealerSafe.DTO.BaseKit
{
    public class GetSite : Base
    {
        public class PrimaryDomain
        {
            public object @ref { get; set; }
            public string domainName { get; set; }
        }

        public class LastPublish
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class Site
        {
            public object @ref { get; set; }
            public object reverseParentRef { get; set; }
            public object domains { get; set; }
            public object contentMapSite { get; set; }
            public object template { get; set; }
            public PrimaryDomain primaryDomain { get; set; }
            public LastPublish lastPublish { get; set; }
            public object brandRef { get; set; }
            public object version { get; set; }
            public object enabled { get; set; }
            public object privateWidgets { get; set; }
            public object mobileSiteRef { get; set; }
            public object mobile { get; set; }
            public object profileRef { get; set; }
            public object redirectToPrimary { get; set; }
            public string siteType { get; set; }
            public string activationStatus { get; set; }
            public object revertType { get; set; }
            public object isReversible { get; set; }
            public object responsiveSiteRef { get; set; }
            public object ready { get; set; }
            public object live { get; set; }
            public object previouslyPublished { get; set; }
            public string primaryUrl { get; set; }
            public object accountHolderRef { get; set; }
        }

        public Site site { get; set; }

        public static GetSite Do(int @ref)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest(string.Format("/sites/{0}", @ref), Method.GET);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<GetSite>(str);
                return ret;
            }

            return null;
        }
    }
}
