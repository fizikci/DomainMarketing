using Cinar.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.Products.Domain
{
    /// <summary>
    /// Supplier tablosu ile one-to-one ilişkili, detay bilgileri içeren tablo
    /// </summary>
    public class Registry : NamedEntity
    {
        [ColumnDetail(Length = 12)]
        public string RegistryBackendId { get; set; }

        [ColumnDetail(Length = 12)]
        public string PropertySetId { get; set; }

        [ColumnDetail(Length=100)]
        public string EppServerUri { get; set; }

        [ColumnDetail(Length = 10)]
        public string EppServerPort { get; set; }

        [ColumnDetail(Length = 30)]
        public string EppUsername { get; set; }

        [ColumnDetail(Length = 30)]
        public string EppPassword { get; set; }

        public bool EppSecureConnection { get; set; }

        [ColumnDetail(Length = 100)]
        public string EppCertPath { get; set; }
        
        [ColumnDetail(Length = 30)]
        public string EppCertPassword { get; set; }


        [ColumnDetail(Length = 100)]
        public string OteServerUri { get; set; }

        [ColumnDetail(Length = 10)]
        public string OteServerPort { get; set; }

        [ColumnDetail(Length = 30)]
        public string OteUsername { get; set; }

        [ColumnDetail(Length = 30)]
        public string OtePassword { get; set; }

        public bool OteSecureConnection { get; set; }

        [ColumnDetail(Length = 100)]
        public string OteCertPath { get; set; }

        [ColumnDetail(Length = 30)]
        public string OteCertPassword { get; set; }

        [ColumnDetail(Length = 30)]
        public string UniqueRegistryName { get; set; }

    }
}