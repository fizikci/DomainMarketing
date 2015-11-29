using System;
using DealerSafe2.API.Entity.Members;
using Cinar.Database;

namespace DealerSafe2.API.Entity.ApiRelated
{
    public class ApiSession : BaseEntity
    {
        [ColumnDetail(Length = 12)]
        public string MemberId { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LastAccess { get; set; }

        public string SerializedParams { get; set; }


        public Member Member() { return Provider.ReadEntityWithRequestCache<Member>(MemberId); }

        private SessionParams _params;
        public SessionParams Params {
            get
            {
                if (string.IsNullOrWhiteSpace(SerializedParams))
                {
                    _params = new SessionParams();
                    return _params;
                }

                if (_params == null)
                    _params = SerializedParams.Deserialize<SessionParams>();

                return _params;
            }
        }

    }

    public class SessionParams
    {
        public string ASessionData { get; set; }
    }

    public class ListViewApiSession : ApiSession
    {
        public string MemberId { get; set; }
        public string MemberName { get; set; }
    }
}