using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;

namespace DealerSafe.DTO.BaseKit
{
    public class SetUpdateSite : Base
    {
        public class PrimaryDomain
        {
            public object @ref { get; set; }
            public string domainName { get; set; }
        }

        public class Site
        {
            public object @ref { get; set; }
            public object reverseParentRef { get; set; }
            public object domains { get; set; }
            public object contentMapSite { get; set; }
            public object template { get; set; }
            public PrimaryDomain primaryDomain { get; set; }
            public object lastPublish { get; set; }
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
            public string primaryUrl { get; set; }
        }

        public Site site { get; set; }

        public static SetUpdateSite Do(int siteRef, int primaryUrlRef = 0, bool live = true, bool enabled = true)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/sites/" + siteRef.ToString(), Method.PUT);
            if (primaryUrlRef != 0) request.AddParameter("primaryUrlRef", primaryUrlRef.ToString(), ParameterType.GetOrPost);
            request.AddParameter("live", live.ToString(), ParameterType.GetOrPost);
            request.AddParameter("activationStatus", enabled ? "active" : "inactive", ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<SetUpdateSite>(str);
                return ret;
            }

            return null;
        }
    }
}
