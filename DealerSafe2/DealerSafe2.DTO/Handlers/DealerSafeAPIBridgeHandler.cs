using System;
using System.Web;
using System.Web.SessionState;
using DealerSafe2.DTO.ServiceClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Configuration;
namespace DealerSafe2.DTO.Handlers
{
    public class DealerSafeAPIBridgeHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = ConfigurationManager.AppSettings["developmentMode"]=="true" ? "application/json" : "plain/text";
            try
            {
                JsonConvert.DefaultSettings = (() =>
                {
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
                    return settings;
                });

                string method = HttpContext.Current.Request["method"];
                object result = new DealerSafeAPI().CallWebAPIMethod(method);

                HttpContext.Current.Response.Write(Serialize(new AjaxResponse() { Data = result }));
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(Serialize(new AjaxResponse() { Data = null, ErrorMessage = ex.InnerException==null ? ex.Message : ex.InnerException.Message, IsError = true }));
            }
        }

        protected string Serialize(object obj)
        {
           var jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (ConfigurationManager.AppSettings["developmentMode"] == "true")
                return jsonStr;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(jsonStr);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        protected object Deserialize(string data, Type type)
        {
            return JsonConvert.DeserializeObject(data, type);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class AjaxResponse
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}
