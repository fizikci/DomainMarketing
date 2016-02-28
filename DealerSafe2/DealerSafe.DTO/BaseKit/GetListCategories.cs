using System.Web.Script.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace DealerSafe.DTO.BaseKit
{
    public class GetListCategories : Base
    {
        public class Category
        {
            public object @ref { get; set; }
            public string category { get; set; }
            public string type { get; set; }
        }

        public List<Category> categories { get; set; }

        public static GetListCategories Do()
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/categories", Method.GET);
            //request.AddParameter("limit", "1", ParameterType.GetOrPost);
            // request.AddParameter("category", "all",ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                var ret = serializer.Deserialize<GetListCategories>(str);
                return ret;
            }

            return null;
        }

    }
}
