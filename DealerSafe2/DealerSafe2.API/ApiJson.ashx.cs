using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using DealerSafe2.API.Entity.ApiRelated;
using Newtonsoft.Json.Converters;
using rfl = System.Reflection;
using System.Web;
using Newtonsoft.Json;
using DealerSafe2.DTO;
using Formatting = Newtonsoft.Json.Formatting;
using System.Web.SessionState;

namespace DealerSafe2.API
{
    /// <summary>
    /// Summary description for ApiJson
    /// </summary>
    public partial class ApiJson : BaseApi
    {
    }

    public class BaseApi : IHttpHandler, IRequiresSessionState
    {
        protected HttpContext context;
        private string apiType = "json";

        public ApiClient ApiClient { get; set; }
        public string ClientIp { get; set; }
        public ApiSession Session { get; set; }
        public string CurrentLanguage { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            HttpContext.Current.Items["api"] = this;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            JsonConvert.DefaultSettings = (() =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
                return settings;
            });

            this.context = context;
            if (context.Request["apiType"] == "xml") apiType = "xml";

            string clientIPAddress = getIPAddress();

            string data = "", method = "", clientName = "";
            object req = null;
            rfl.MethodInfo mi = null;
            try
            {
                if (!clientIPAddress.StartsWith("93.89.226") && !ConfigurationManager.AppSettings["allowedIPs"].Contains(clientIPAddress))
                    throw new Exception("Access denied for " + context.Request.UserHostAddress);

                if (apiType == "xml")
                    context.Response.ContentType = "application/xml";
                else
                    context.Response.ContentType = "application/json";

                method = context.Request["method"];

                if (string.IsNullOrWhiteSpace(method))
                    throw new Exception("Service request method needed");

                mi = this.GetType().GetMethod(method);

                if (mi == null)
                    throw new Exception("There is no service method with the name " + method);

                if (mi.GetParameters().Length != 1)
                    throw new Exception("A service request method should have only one parameter");

                data = context.Request["data"];
                if (string.IsNullOrWhiteSpace(data))
                    throw new Exception("Service request data needed");
                data = HttpUtility.UrlDecode(data);
                Type t = getServiceRequestType(mi.GetParameters()[0].ParameterType);

                req = deserialize(data, t);

                this.ApiClient = Provider.Database.Read<ApiClient>("ClientApiKey={0}", req.GetMemberValue("ApiKey"));
                if (this.ApiClient == null)
                    throw new Exception("No such client");

                var client = req.GetMemberValue("Client");
                clientName = client == null ? "" : client.ToString();

                this.CurrentLanguage = (req.GetMemberValue("Lang") ?? "en").ToString();
                var objSessionId = req.GetMemberValue("SessionId");
                string sessionId = objSessionId == null ? "" : objSessionId.ToString();

                if (!sessionId.IsEmpty()) // eğer client sessionId göndermişse
                {
                    this.Session = Provider.Database.Read<ApiSession>("Id={0}", sessionId); // veritabanından session'ı okuyalım
                    
                    if (this.Session == null) // eğer session veritabanına kaydedilmemişse hemen kaydedelim (çünkü bu client API ile session açarak çalışmak istiyor)
                    {
                        this.Session = new ApiSession();
                        this.Session.Id = sessionId;
                        this.Session.LastAccess = Provider.Database.Now;
                        this.Session.SerializedParams = this.Session.Params.Serialize();
                        Provider.Database.Insert("ApiSession", this.Session);
                    }
                }
                else // eğer client sessionId gönderMEmişse, yeni bir sessionId oluşturalım (ama veritabanına kaydetmeyelim yoksa ApiSession tablosunu google botları patlatabilir)
                {
                    this.Session = new ApiSession();
                    this.Session.Id = Utility.CreatePassword(12);
                }

                if (!string.IsNullOrWhiteSpace(this.Session.MemberId))
                    Provider.CurrentMember = this.Session.Member();

                object res = mi.Invoke(this, new[] { req.GetMemberValue("Data") });

                t = getServiceResponseType(mi.ReturnType);
                object serviceResponse = Activator.CreateInstance(t);
                serviceResponse.SetMemberValue("Data", res);
                serviceResponse.SetMemberValue("IsSuccessful", true);
                serviceResponse.SetMemberValue("ClientIPAddress", clientIPAddress);
                serviceResponse.SetMemberValue("SessionId", this.Session.Id);

                sw.Stop();

                serviceResponse.SetMemberValue("ServerProcessTime", sw.ElapsedMilliseconds);

                context.Response.Write(serialize(serviceResponse, apiType));
            }
            catch (Exception ex)
            {
                sw.Stop();

                if (ex.InnerException is APIException)
                {
                    var exInner = ex.InnerException as APIException;
                    context.Response.Write(serialize(new ServiceResponse<object>
                        {
                            Data = mi!=null ? (mi.ReturnType == typeof(bool) ? (object)false : null) : null,
                            IsSuccessful = false,
                            ErrorMessage = exInner.Message,
                            ErrorType = (int)exInner.ErrorType,
                            ErrorCode = (int)exInner.ErrorCode,
                            ClientIPAddress = clientIPAddress,
                            ServerProcessTime = sw.ElapsedMilliseconds
                        }, apiType));
                }
                else
                {
                    context.Response.Write(serialize(new ServiceResponse<object>
                        {
                            Data = mi != null ? (mi.ReturnType == typeof(bool) ? (object)false : null) : null,
                            IsSuccessful = false,
                            ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                            ErrorCode = 500,
                            ClientIPAddress = clientIPAddress,
                            ServerProcessTime = sw.ElapsedMilliseconds
                        }, apiType));
                }
            }
        }

        #region utility

        private string serialize(object obj, string apiType)
        {
            if (apiType == "json")
                return JsonConvert.SerializeObject(obj, Formatting.Indented);

            return obj.Serialize();
        }
        private object deserialize(string data, Type type)
        {
            if (apiType == "json")
                return JsonConvert.DeserializeObject(data, type);
            return data.Deserialize(type);
        }

        private Type getServiceRequestType(Type item)
        {
            var t = typeof(ServiceRequest<>);
            Type[] typeArgs = { item };
            return t.MakeGenericType(typeArgs);
        }
        private Type getServiceResponseType(Type item)
        {
            var t = typeof(ServiceResponse<>);
            Type[] typeArgs = { item };
            return t.MakeGenericType(typeArgs);
        }

        public List<rfl.MethodInfo> GetServiceMethods()
        {
            return this.GetType()
                .GetMethods(rfl.BindingFlags.DeclaredOnly | rfl.BindingFlags.Public | rfl.BindingFlags.Instance)
                .ToList();
        }
        public string GetServiceMethodDescription(rfl.MethodInfo mi)
        {
            DescriptionAttribute desc = mi.GetAttribute<DescriptionAttribute>();

            string description = "<table><tr><td colspan=\"2\"><i>" + (desc == null ? "No description." : desc.Description) + "</i></td></tr>";
            description += "<tr><td colspan=\"2\">&nbsp;</td></tr>";

            foreach (rfl.PropertyInfo pi in mi.GetParameters()[0].ParameterType.GetProperties())
            {
                DescriptionAttribute desc2 = pi.GetAttribute<DescriptionAttribute>();
                description += string.Format("<tr><td><b>{0}</b></td><td>{1}</td></tr>", pi.Name, (desc2 == null ? "" : desc2.Description));
            }

            description += "</table>";

            return description;
        }
        public string GetServiceMethodRequestSample(rfl.MethodInfo mi, string apiType)
        {
            if (mi == null)
                return "No such service method";

            if (mi.GetParameters().Length != 1)
                return "A service request method should have only one parameter";

            Type t = getServiceRequestType(mi.GetParameters()[0].ParameterType);
            object req = Activator.CreateInstance(t);
            req.SetMemberValue("ApiKey", "GFD65RO3");
            object data;
            if (mi.GetParameters()[0].ParameterType == typeof(string))
                data = "";
            else
                data = Activator.CreateInstance(mi.GetParameters()[0].ParameterType);
            req.SetMemberValue("Data", data);

            foreach (rfl.PropertyInfo pi in data.GetType().GetProperties(rfl.BindingFlags.DeclaredOnly | rfl.BindingFlags.Public | rfl.BindingFlags.Instance))
                if (!(pi.PropertyType.IsPrimitive || pi.PropertyType == typeof(string)) && pi.GetSetMethod() != null)
                    pi.SetValue(data, pi.PropertyType.IsArray ? Array.CreateInstance(pi.PropertyType.GetElementType(), 0) : Activator.CreateInstance(pi.PropertyType), null);

            return serialize(req, apiType);
        }

        private string getIPAddress()
        {
            HttpContext context = HttpContext.Current;

            if (!string.IsNullOrWhiteSpace(context.Request.ServerVariables["HTTP_CLIENT_IP"]))
                return context.Request.ServerVariables["HTTP_CLIENT_IP"];

            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.UserHostAddress;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        protected object Deserialize(string data, Type type)
        {
            return JsonConvert.DeserializeObject(data, type);
        }

        #endregion
    }

}