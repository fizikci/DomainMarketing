using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace DealerSafe.DTO.BaseKit
{
    public class SetCreateSite : Base
    {
        public class Domain
        {
            public object @ref { get; set; }
            public string domainName { get; set; }
        }

        public class PrimaryDomain
        {
            public object @ref { get; set; }
            public string domainName { get; set; }
        }

        public class Site
        {
            public object @ref { get; set; }
            public object reverseParentRef { get; set; }
            public List<Domain> domains { get; set; }
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
        }

        public Site site { get; set; }

        public static SetCreateSite Do(int accountHolderRef, string domain, int templateRef = 0, bool activationStatus=true)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/sites", Method.POST);
            request.AddParameter("accountHolderRef", accountHolderRef.ToString(), ParameterType.GetOrPost);
            request.AddParameter("brandRef", "1", ParameterType.GetOrPost);
            if (templateRef != 0) request.AddParameter("templateRef", templateRef.ToString(), ParameterType.GetOrPost);
            if (activationStatus) request.AddParameter("activationStatus", "active", ParameterType.GetOrPost); else request.AddParameter("activationStatus", "inactive", ParameterType.GetOrPost);
            request.AddParameter("domain", domain, ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<SetCreateSite>(str);
                return ret;
            }
            
            return null;
        }

    }
}
