using RestSharp;
using RestSharp.Authenticators;

namespace DealerSafe.DTO.BaseKit
{
    public class Base
    {
        public enum PaketTipi
        {
            Business = 60,
            Basic = 17,
            ThreePages = 63, //Demo = 16 // göndermeye gerek yok, default bu geliyor!
            //Demo = 16 // göndermeye gerek yok, default bu geliyor!
            ECommerce = 62
        }

        public static string url = "http://rest.webklavuzu.net";
        public static string consumer_key = "isimtescil";
        public static string consumer_secret = "c71da68f2253bc6996fb1e3d96085ec5faf57ea2";
        public static string token = "c286d981e06e6baa13dd89528aa49c737563b338";
        public static string token_secret = "702ce5ddc880d74ffa5a985a202c3cc08b345b98";
        public static string brandRef = "1";
        public static string str { get; set; }

        // ok
        public static bool CreateAutoLogin(int accountHolderRef, int siteRef, out string tmp)
        {
            tmp = "";
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            string param = "/users/" + accountHolderRef.ToString() + "/auto-login";
            var request = new RestRequest(param, Method.POST);
            request.AddParameter("siteRef", siteRef.ToString(), ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                tmp = response.Content;
            }
            else return false;

            return true;
        }

        // ok
        public static bool DeleteSite(int id)
        {
            string ret = "";
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest(string.Format("/sites/{0}", id), Method.DELETE);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                ret = response.Content;
            }
            else return false;

            return true;
        }

        // ok
        public static bool DeleteUser(int reff)
        {
            string ret = "";
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest(string.Format("/users/{0}", reff), Method.DELETE);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                ret = response.Content;
            }
            else return false;

            return true;
        }
        
        // ?
        public static bool SetPayment(int id, PaketTipi tip, int yil=1)
        {
            //"accountHolderRef": 1,
            //"brandRef": 1,
            //"domain": "example.com",

            string ret = "";
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/users/" + id.ToString() + "/account-packages", Method.POST);
            request.AddParameter("billingFrequency", 12*yil, ParameterType.GetOrPost);
            request.AddParameter("packageRef", tip.GetHashCode(), ParameterType.GetOrPost);

            // 17 vardı, unutma!...

            //"userRef":6,
            //"packageRef":60,
            //"billingFrequency":12

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                ret = response.Content;
            }
            else return false;

            return true;
        }

        public static bool MapSite(int @ref, string domain)
        {
            // /sites/:siteRef/domains
            string ret = "";
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/sites/" + @ref.ToString() + "/domains", Method.POST);
            //request.AddParameter("siteRef", @ref.ToString(), ParameterType.GetOrPost);
            request.AddParameter("domain", domain, ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                ret = response.Content;
            }
            else return false;

            return true;
        }

        // calismiyor
        public static string getTemplatev2()
        {
            string ret = "";
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/v2/templates", Method.GET);
            //request.AddParameter("users", "1", ParameterType.GetOrPost);
            // request.AddParameter("category", "all",ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                ret = response.Content;
            }

            return ret;
        }
    }
}
