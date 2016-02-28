using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace DealerSafe.DTO.BaseKit
{
    public class GetListBrandLanguages : Base
    {
        public class Language
        {
            public object @ref { get; set; }
            public string code { get; set; }
            public string name { get; set; }
        }

        public List<Language> languages { get; set; }

        public static GetListBrandLanguages Do(int brandRef = 1)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/brands/" + brandRef.ToString() + "/languages", Method.GET);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<GetListBrandLanguages>(str);
                return ret;
            }

            return null;
        }
    }
}
