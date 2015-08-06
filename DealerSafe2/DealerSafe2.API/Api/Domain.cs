using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.DTO;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using rfl = System.Reflection;
using System.Web;
using DealerSafe2.DTO.EntityInfo.Products.Domain;
using DealerSafe2.API.Entity.Products.Domain;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        public List<ListViewMemberDomainInfo> GetMemberDomainList(ReqEmpty req)
        {
            return Provider.Database.GetDataTable(@"
                        SELECT 
                            dom.Id,
                            dom.InsertDate,
                            dom.OrderItemId,
                            oi.OrderId,
                            dom.MemberId,
                            m.FirstName + ' ' + m.LastName as MemberName,
                            oi.DisplayName AS ProductName,
                            dom.RenewalMode,
                            dom.StartDate,
                            dom.EndDate,
                            dom.DomainName
                        FROM 
                            MemberDomain dom
                            INNER JOIN Member m ON dom.MemberId = m.Id
                            INNER JOIN OrderItem oi ON dom.OrderItemId = oi.Id
                            INNER JOIN [Order] o ON o.Id = oi.OrderId AND o.MemberId = {0} AND o.State = 'Order';", Session.MemberId)
                   .ToEntityList<ListViewMemberDomainInfo>();
        }
        public string SaveMemberDomain(MemberDomainInfo req)
        {
            MemberDomain md = new MemberDomain();
            req.CopyPropertiesWithSameName(md);

            md.Id = req.DomainName.Trim();

            Provider.Database.Insert("MemberDomain", md);

            return md.Id;
        }
    }
}