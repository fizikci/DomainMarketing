using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using DealerSafe.DTO;
using Newtonsoft.Json;

namespace DealerSafe.ServiceClient
{
    public abstract class BaseAPI
    {
        protected string apiKey;
        protected int memberId;
        protected int staffId;
        protected string clientIP;
        protected string browser;
        protected string userAgent;

        public int ResponseTimeOut;

        protected T Call<T, K>(K request, string methodName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ServiceRequest<K> serviceRequest = new ServiceRequest<K>();
            serviceRequest.APIKey = ConfigurationManager.AppSettings["APIKey"];
            serviceRequest.Data = request;
            serviceRequest.ResellerId = int.Parse(ConfigurationManager.AppSettings["ResellerId"]);
            serviceRequest.MemberId = this.memberId;
            serviceRequest.StaffId = this.staffId;


            if (HttpContext.Current != null) serviceRequest.ClientIP = getIPAddress();
            if (HttpContext.Current != null) serviceRequest.Browser = HttpContext.Current.Request.Browser.Browser;
            if (HttpContext.Current != null) serviceRequest.UserAgent = HttpContext.Current.Request.UserAgent;
            serviceRequest.Client = HttpContext.Current == null ? System.AppDomain.CurrentDomain.FriendlyName : HttpContext.Current.Request.RawUrl;

            string serviceUrl = GetServiceURL();
            serviceUrl += "?apiType=json&method=" + methodName;

            string data = "data=" + HttpUtility.UrlEncode(Serialize(serviceRequest));

            using (MyWebClient wc = new MyWebClient(ResponseTimeOut))
            {
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string res = wc.UploadString(serviceUrl, data);

                ServiceResponse<T> serviceResponse = (ServiceResponse<T>)Deserialize(res, typeof(ServiceResponse<T>));

                sw.Stop();

                if (!serviceResponse.IsSuccessful)
                    throw new APIException(
                        serviceResponse.ErrorMessage,
                        (ErrorTypes)serviceResponse.ErrorType,
                        (ErrorCodes)serviceResponse.ErrorCode,
                        serviceResponse.ExtraMessages
                    );


                return serviceResponse.Data;
            }
        }

        protected abstract string GetServiceURL();

        protected string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        protected object Deserialize(string data, Type type)
        {
            return JsonConvert.DeserializeObject(data, type);
        }

        private class MyWebClient : WebClient
        {
            private int ResTimeOut { get; set; }

            public MyWebClient(int RTimeOut)
            {
                ResTimeOut = RTimeOut == 0 ? (4 * 60 * 1000) : RTimeOut;
            }

            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = ResTimeOut;
                return w;
            }
        }


        private string getIPAddress()
        {
            try
            {
                HttpContext context = HttpContext.Current;
                string ip = context.Request.ServerVariables["HTTP_C_IP"] ?? context.Request.ServerVariables["REMOTE_ADDR"];

                return ip;
            }
            catch (Exception)
            {
                return "";
            }
        }

    }

}
