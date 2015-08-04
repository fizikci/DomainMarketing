using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using Cinar.Database;
using DealerSafe2.API.Entity;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Products;
using DealerSafe2.DTO.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DealerSafe2.API.Staff.Handlers
{
    public class CRUDHandler : IHttpHandler, IRequiresSessionState
    {
        protected HttpContext context;

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;

            try
            {
                context.Response.ContentType = "application/json";

                JsonConvert.DefaultSettings = (() =>
                {
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new StringEnumConverter { CamelCaseText = false });
                    return settings;
                });

                string method = context.Request["method"];

                var entityName = context.Request["entityName"];
                foreach (var t in typeof(BaseEntity).Assembly.GetTypes().Where(t => t.FullName.StartsWith("DealerSafe2.API.Entity.") && t.Name == entityName))
                {
                    T = t;
                    break;
                }

                if (T == null)
                    throw new Exception("Entity not found: " + entityName);

                if (string.IsNullOrWhiteSpace(method))
                    throw new Exception("Ajax method needed");

                MethodInfo mi = this.GetType().GetMethod(method);

                if (mi == null)
                    throw new Exception("There is no ajax method with the name " + method);

                object[] paramValues = new object[mi.GetParameters().Length];

                if (mi.GetParameters().Length > 0)
                {
                    for (int i = 0; i < mi.GetParameters().Length; i++)
                    {
                        ParameterInfo pi = mi.GetParameters()[i];
                        try
                        {
                            paramValues[i] = context.Request[pi.Name].ChangeType(pi.ParameterType);
                        }
                        catch
                        {
                            throw new Exception("Error converting " + context.Request[pi.Name] + " TO " + pi.ParameterType);
                        }
                    }
                }

                var res = mi.Invoke(this, paramValues);

                context.Response.Write(Serialize(new AjaxResponse()
                {
                    isError = false,
                    errorMessage = "",
                    data = res
                }));
            }
            catch (Exception ex)
            {
                context.Response.Write(Serialize(new AjaxResponse()
                {
                    isError = true,
                    errorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message,
                    data = null
                }));
            }
        }

        #region utility
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


        private Type T;

        public object GetById(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "View"))
                throw new Exception("Access is denied");

            // read from database
            var type = Type.GetType(T.Namespace + ".View" + T.Name) ?? T;

            return Provider.Database.Read(type, "Id={0}", id);
        }
        public object GetByIdForEdit(string id)
        {
            return Provider.Database.Read(T, "Id={0}", id);
        }

        public bool CheckId(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "View"))
                throw new Exception("Access is denied");

            return Provider.Database.GetBool("select 1 from ["+T.Name+"] where Id={0}", id);
        }

        public ResList GetList(int pageSize, int pageNo)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "View"))
                throw new Exception("Access is denied");

            var fExp = readFilterExpression(pageSize, pageNo);
            modifyFilterByUserRights(fExp);

            // is there an avilable view for T
            var type = Type.GetType(T.Namespace + ".ListView" + T.Name) ?? T;

            // read from database
            IList list = null;
            list = Provider.Database.ReadList(type, fExp);

            var count = Provider.Database.ReadCount(type, fExp);

            return new ResList { 
                list = list,
                count = count
            };
        }

        public IList GetIdNameList(int pageSize, int pageNo)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "View"))
                throw new Exception("Access is denied");

            var fExp = readFilterExpression(pageSize, pageNo);
            modifyFilterByUserRights(fExp);

            return Provider.Database.ReadList(T, fExp)
               .Select(c => new IdName { Id = ((BaseEntity)c).Id, Name = c.ToString() })
               .ToList();
        }

        public bool DeleteById(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "Edit"))
                throw new Exception("Access is denied");

            var entity = (BaseEntity)Provider.Database.Read(T, "Id={0}", id);
            entity.Delete();
            return true;
        }
        public bool UndeleteById(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "Edit"))
                throw new Exception("Access is denied");

            var entity = (BaseEntity)Provider.Database.Read(T, "Id={0}", id);
            entity.IsDeleted = false;
            entity.Save();
            return true;
        }

        public bool Save(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "Edit"))
                throw new Exception("Access is denied");

            try
            {
                var entity = (BaseEntity)Provider.Database.Read(T, "Id={0}", id) ??
                             (BaseEntity)Activator.CreateInstance(T);
                entity.SetFieldsByPostData(context.Request.Form);

                entity.Save();

                if (!string.IsNullOrWhiteSpace(context.Request["redirectToList"]))
                    context.Response.Redirect("/Staff/List" + T.Name + ".aspx", true);
                else
                    context.Response.Redirect(context.Request.UrlReferrer + "&saved=1");

                return true;
            }
            catch
            {
                context.Server.Transfer("/Staff/Edit" + T.Name + ".aspx");
                return false;
            }
        }

        public BaseEntity SaveWithAjax()
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "Edit"))
                throw new Exception("Access is denied");

            var entity = (BaseEntity)Provider.Database.Read(T, "Id={0}", context.Request.Form["Id"]) ??
                         (BaseEntity)Activator.CreateInstance(T);
            entity.SetFieldsByPostData(context.Request.Form);

            entity.Save();

            return entity;
        }
        public BaseEntity InsertWithAjax()
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "Edit"))
                throw new Exception("Access is denied");

            var entity = (BaseEntity)Activator.CreateInstance(T);
            entity.SetFieldsByPostData(context.Request.Form);

            if (entity.Id.IsEmpty())
                entity.Save();
            else
                entity.Insert();

            return entity;
        }
        public BaseEntity UpdateWithAjax()
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "Edit"))
                throw new Exception("Access is denied");

            var entity = (BaseEntity)Provider.Database.Read(T, "Id={0}", context.Request.Form["Id"]);
            if (entity == null)
                throw new Exception("No such record");

            entity.SetFieldsByPostData(context.Request.Form);

            //Provider.Database.Update(T.Name, entity);
            entity.Save();

            return entity;
        }

        public List<IdName> GetEnumList(string enumName)
        {
            return new ApiJson().GetEnumList(enumName);
        }

        public void MoveUp(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "View"))
                throw new Exception("Access is denied");

            var entity = (NamedEntity)Provider.Database.Read(T, "Id={0}", id);
            entity.MoveUp();
        }
        public void MoveDown(string id)
        {
            if (!Provider.CurrentMember.HasRight(T.Name + "View"))
                throw new Exception("Access is denied");

            var entity = (NamedEntity)Provider.Database.Read(T, "Id={0}", id);
            entity.MoveDown();
        }


        #region private implementation
        private static FilterExpression readFilterExpression(int pageSize, int pageNo)
        {
            // where
            FilterExpression fExp = null;
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["Where"]))
                fExp = FilterExpression.Parse(HttpContext.Current.Request.Form["Where"]);
            if (fExp == null)
                fExp = new FilterExpression() { PageNo = pageNo, PageSize = pageSize };
            else
            {
                fExp.PageNo = pageNo;
                fExp.PageSize = pageSize;
            }

            // order by
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request.Form["OrderBy"]))
            {
                var orderBy = HttpContext.Current.Request.Form["OrderBy"].Split(' ');
                fExp.OrderBy(orderBy[0]);
                if (orderBy.Length > 1 && orderBy[1].ToLowerInvariant() == "desc")
                    fExp.Desc();
            }
            return fExp;
        }
        private void modifyFilterByUserRights(FilterExpression fExp)
        {
            if (Provider.CurrentMember.SuperUser)
                return;

            if (T == typeof(Entity.ApiRelated.Api))
                fExp = fExp.And("Id", CriteriaTypes.Eq, Provider.CurrentApi.Id);
            else if (T == typeof(Product))
                fExp = fExp.And("ApiId", CriteriaTypes.Eq, Provider.CurrentApi.Id);
            else if (T == typeof(NewsletterDefinition))
                fExp = fExp.And("ApiId", CriteriaTypes.Eq, Provider.CurrentApi.Id);
            //else if (T == typeof(Right))
            //    fExp = fExp.And("ApiId", CriteriaTypes.Eq, Provider.CurrentApi.Id);
            //else if (T == typeof(Role))
            //    fExp = fExp.And("ApiId", CriteriaTypes.Eq, Provider.CurrentApi.Id);
            else if (T == typeof(ApiClient))
                fExp = fExp.And("ApiId", CriteriaTypes.Eq, Provider.CurrentApi.Id);
            else if (T == typeof(Member))
                fExp = fExp.And("StaffMemberId", CriteriaTypes.Eq, Provider.CurrentMember.Id);
        }
        #endregion

    }

    public class AjaxResponse
    {
        public bool isError { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
    }
    public class ResList
    {
        public int count { get; set; }
        public IList list { get; set; }
    }
}