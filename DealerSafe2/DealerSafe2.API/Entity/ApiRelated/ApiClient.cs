using System;
using Cinar.Database;

namespace DealerSafe2.API.Entity.ApiRelated
{
    public class ApiClient : BaseEntity, ICriticalEntity
    {
        [ColumnDetail(Length = 12)]
        public string ApiId { get; set; }
        [ColumnDetail(Length = 12)]
        public string ClientId { get; set; }
        public string ClientApiKey { get; set; }
        public string Url { get; set; }

        public Api Api() { return Provider.ReadEntityWithRequestCache<Api>(ApiId); }
        public Client Client() { return Provider.ReadEntityWithRequestCache<Client>(ClientId); }

        public string MailFrom { get; set; }
        public string MailHost { get; set; }
        public int MailPort { get; set; }
        public string MailUserName { get; set; }
        public string MailPassword { get; set; }
    }


    public class ListViewApiClient : ApiClient
    {
        public string ApiName { get; set; }
        public string ClientName { get; set; }
    }
}