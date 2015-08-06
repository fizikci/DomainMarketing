using System.Collections;
using Cinar.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using DealerSafe2.API.Entity;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Members;
using System.Net;
using DealerSafe2.API.Entity.Common;

namespace DealerSafe2.API
{
    public static class Provider
    {
        private static Database _db;

        public static Database Database
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items["db"] == null)
                    {
                        Database db = GetNewDatabaseInstance();
                        db.DefaultCommandTimeout = 1000;
                        db.CreateTablesAutomatically = true;
                        HttpContext.Current.Items["db"] = db;
                    }
                    return (Database)HttpContext.Current.Items["db"];
                }

                if (_db == null)
                    _db = GetNewDatabaseInstance();
                return _db;
            }
        }

        public static Database GetNewDatabaseInstance()
        {
            return new Database(ConfigurationManager.AppSettings["dbConnStr"], DatabaseProvider.SQLServer, null, false, false);
        }

        public static ApiJson Api
        {
            get
            {
                //DİKKAT: sakın ha if(null) ise new ApiJson() yapayım deme.
                return HttpContext.Current.Items["api"] as ApiJson;
            }
        }

        public static string RequestExternalWebAPI(string url, string requestData, bool post)
        {
            HttpContext.Current.Items["requestUrl"] = url;
            HttpContext.Current.Items["request"] = requestData;

            using (WebClient wc = new WebClient())
            {
                string res = post ? wc.UploadString(url, requestData) : wc.DownloadString(url);

                res = res.Trim();

                HttpContext.Current.Items["response"] = res;

                return res;
            }
        }

        public static List<T> ReadListWithCache<T>(this IDatabase db) where T : IDatabaseEntity
        {
            if (HttpContext.Current.Cache[typeof(T).FullName] == null)
                HttpContext.Current.Cache.Insert(typeof(T).FullName, db.ReadList<T>(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0));

            return (List<T>)HttpContext.Current.Cache[typeof(T).FullName];
        }

        public static ApiClient CurrentApiClient
        {
            get
            {
                if (HttpContext.Current.Session["CurrentApiClient"] != null)
                    return (ApiClient)HttpContext.Current.Session["CurrentApiClient"];


                return new ApiClient() { Id = "" };
            }
            set { HttpContext.Current.Session["CurrentApiClient"] = value; }
        }
        public static Member CurrentMember
        {
            get
            {
                if (HttpContext.Current.Session["Member"] != null)
                    return (Member)HttpContext.Current.Session["Member"];


                return new Member() { Id = "", UserName = "Anonim" };
            }
            set { HttpContext.Current.Session["Member"] = value; }
        }
        public static Entity.ApiRelated.Api CurrentApi
        {
            get
            {
                if (HttpContext.Current.Session["CurrentApi"] != null)
                    return (Entity.ApiRelated.Api)HttpContext.Current.Session["CurrentApi"];


                return new Entity.ApiRelated.Api();
            }
            set
            {
                HttpContext.Current.Session["CurrentApi"] = value;
            }
        }




        public static List<TEntityInfo> ToEntityInfo<TEntityInfo>(this IList list) where TEntityInfo : new()
        {
            var res = new List<TEntityInfo>();
            foreach (var entity in list)
            {
                var info = new TEntityInfo();
                entity.CopyPropertiesWithSameName(info);
                res.Add(info);
            }
            return res;
        }
        public static TEntityInfo ToEntityInfo<TEntityInfo>(this BaseEntity entity) where TEntityInfo : new()
        {
            if (entity == null) 
                return default(TEntityInfo);

            var res = new TEntityInfo();
            entity.CopyPropertiesWithSameName(res);
            return res;
        }

        // Provider.TR("{0} records of total {1}", recCount, total);
        public static string TR(string text, params object[] parameters)
        {
            return string.Format(text, parameters);
        }


        public static T ReadEntityWithRequestCache<T>(string id, string idFieldName = "Id") where T : BaseEntity, new()
        {
            var key = typeof (T).Name + "_" + id;
            if (!HttpContext.Current.Items.Contains(key))
            {
                var e = Provider.Database.Read<T>(idFieldName+"={0}", id);
                if(e==null)
                    return new T();
                HttpContext.Current.Items.Add(key, e);
            }

            return (T)HttpContext.Current.Items[key];
        }

        public static void Translate(BaseEntity entity)
        {
            var langCode = Provider.Api.CurrentLanguage;

            if (langCode == "tr") return; //***

            foreach (var val in Provider.Database.ReadList<LanguageValue>("select * from LanguageValue where EntityName={0} AND EntityId = {1} AND LanguageId={2}", entity.GetType().Name, entity.Id, langCode))
                entity.SetMemberValue(val.FieldName, val.FieldValue);

        }

    }
}