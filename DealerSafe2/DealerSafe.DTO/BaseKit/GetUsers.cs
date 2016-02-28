using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Linq;

namespace DealerSafe.DTO.BaseKit
{
    public class GetUsers : Base
    {
        public class Created
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class LastLogin
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class StartDateTime
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class Package
        {
            public object @ref { get; set; }
            public string name { get; set; }
        }

        public class ExpiryDate
        {
            public string date { get; set; }
            public object timezone_type { get; set; }
            public string timezone { get; set; }
        }

        public class BillingCycle
        {
            public object billingPeriodMonths { get; set; }
            public ExpiryDate expiryDate { get; set; }
        }

        public class AccountPackage
        {
            public object @ref { get; set; }
            public object deleteOnExpiry { get; set; }
            public StartDateTime startDateTime { get; set; }
            public Package package { get; set; }
            public BillingCycle billingCycle { get; set; }
        }

        public class AccountHolder
        {
            public object @ref { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public Created created { get; set; }
            public LastLogin lastLogin { get; set; }
            public object deleted { get; set; }
            public string accountStatus { get; set; }
            public object newsletter { get; set; }
            public object suspended { get; set; }
            public string languageCode { get; set; }
            public string phoneNumber { get; set; }
            public object cpfNumber { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string company { get; set; }
            public string country { get; set; }
            public string postcode { get; set; }
            public List<AccountPackage> accountPackages { get; set; }
        }

        public string count { get; set; }
        public List<AccountHolder> accountHolders { get; set; }


        // ok
        public static bool UserCheck(string str)
        {
            bool ret = false;
            int step = 100;
            int max = Dos(0).count.ToInt32() / step + 1;

            for (int i = 0; i < max; i++)
            {
                var tmp = Dos(i*100).accountHolders.Count(x => x.email == str);
                if (tmp > 0)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        // kullanıcı arama için
        private static GetUsers Dos(int offset)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/users", Method.GET);
            request.AddParameter("limit", "100", ParameterType.GetOrPost);
            request.AddParameter("offset", offset, ParameterType.GetOrPost);
            request.AddParameter("showDeleted", "1", ParameterType.GetOrPost);
            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                var ret = serializer.Deserialize<GetUsers>(str);
                return ret;
            }

            return null;

        }

        // ok
        public static GetUsers Do(int limit=20)
        {
            var client = new RestClient(url);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(consumer_key, consumer_secret, token, token_secret);
            var request = new RestRequest("/users", Method.GET);
            if (limit != 20) request.AddParameter("limit", limit.ToString(), ParameterType.GetOrPost);
            request.AddParameter("showDeleted", "1", ParameterType.GetOrPost);

            var response = client.Execute(request);
            if (response != null && !string.IsNullOrWhiteSpace(response.Content))
            {
                string str = response.Content;
                Base.str = str;
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                var ret = serializer.Deserialize<GetUsers>(str);
                return ret;
            }

            return null;
        }

    }
}
