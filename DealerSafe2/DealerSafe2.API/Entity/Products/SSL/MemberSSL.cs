using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinar.Database;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Entity.Products.SSL
{

    public class MemberSSL : MemberProduct
    {
        [ColumnDetail(ColumnType = DbType.VarChar)]
        public SSLStates State { get; set; }

        public string DomainName { get; set; }

        public string NameSurname { get; set; }

        public string ReqProduct { get; set; }
        public int ReqYears { get; set; }
        public int ReqServers { get; set; }
        public string ReqServerSoftware { get; set; }
        public string ReqEmail { get; set; }
        public string ReqDCVEmail { get; set; }
        public string ReqDCVMethod { get; set; }
        public string ReqCSRCode { get; set; }
        public string ReqPrivateKey { get; set; }

        public int ResBitLength { get; set; }
        public string ResOrderNumber { get; set; }
        public string ResTotalCost { get; set; }
        public string ResCertificateId { get; set; }
        public string ResCertificateStatus { get; set; }

        public string CsrCN { get; set; }
        public string CsrOU { get; set; }
        public string CsrO { get; set; }
        public string CsrPOBox { get; set; }
        public string CsrStreet { get; set; }
        public string CsrL { get; set; }
        public string CsrS { get; set; }
        public string CsrPostalCode { get; set; }
        public string CsrC { get; set; }
        public string CsrEmail { get; set; }
        public string CsrPhone { get; set; }
    }


    public class ListViewMemberSSL : BaseEntity
    {
        public string DomainName { get; set; }
        public string MemberId { get; set; }
        public string Email { get; set; }
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string DisplayName { get; set; }
        public string State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}