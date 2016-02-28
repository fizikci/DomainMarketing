using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace DealerSafe.DTO.BaseKit
{
    public class GetSites : Base
    {
        public List<Site> sites { get; set; }

        public class Site
        {
            public object @ref { get; set; }
            public string databaseSchema { get; set; }
            public object domains { get; set; }
            public object mobileSiteRef { get; set; }
        }

        public static GetSites Do(string domain = "", int? limit = 0, int? offset = 0, bool? deleted = null)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/sites", Method.GET);
            request.AddParameter("brandRef", 1, ParameterType.GetOrPost);
            if (!string.IsNullOrWhiteSpace(domain)) request.AddParameter("domain", domain, ParameterType.GetOrPost);
            if (limit != 0) request.AddParameter("limit", limit, ParameterType.GetOrPost);
            if (offset != 0) request.AddParameter("offset", offset, ParameterType.GetOrPost);
            if (deleted != null) request.AddParameter("deleted", deleted == true ? 1 : 0, ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<GetSites>(str);
                return ret;
            }

            return null;
        }
    }
}
