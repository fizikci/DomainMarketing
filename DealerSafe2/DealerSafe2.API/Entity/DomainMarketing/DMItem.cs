using Cinar.Database;
using DealerSafe2.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DealerSafe2.API.Entity.DomainMarketing
{
    public class DMItem : BaseEntity
    {
        [ColumnDetail(ColumnType = DbType.VarChar, Length = 10)]
        public DMItemTypes Type { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 70), Description("name of the item, if domain than domain name")]
        public string DomainName { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the seller, fk referencing member table")]
        public string SellerMemberId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("id of the seller, fk referencing category table")]
        public string DMCategoryId { get; set; }

        [Description("direct buy price without participating in the auction, namely reserve price")]
        public int BuyItNowPrice { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("status code of the item. To be defined")]
        public DMItemStates Status { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 12), Description("language of the project")]
        public string LanguageId { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 100), Description("description of the domain/project")]
        public string DescriptionShort { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 500), Description("description of the domain/project")]
        public string DescriptionLong { get; set; }

        [Description("minimum bid price that this item needs to be sold by an auction")]
        public int MinimumBidPrice { get; set; }

        [Description("minimum bidding interval accepted")]
        public int MinimumBidInterval { get; set; }

        [Description("registration date of the domain. Used both for domain and web projects. Could be queried by whois service, no need for user entry.")]
        public DateTime DomainRegistrationDate { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("name of the registrar. Could be queried by whois service, no need for user entry.")]
        public string DomainRegistrar { get; set; }

        [Description("date of expiry for the domain/project")]
        public DateTime ExpiryDate { get; set; }

        [Description("domain parking")]
        public bool EnableDomainParking { get; set; }

        [Description("ads")]
        public bool VisibleInAdNetwork { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("if the ad of this site to be displayed in another site, the link of the ad is to be defined here")]
        public string AdLinkCode { get; set; }

        [Description("0-not verified")]
        public int PageRank { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("owner of the domain")]
        public string Ownership { get; set; }

        [Description("the seller may ask for a verification")]
        public bool VerificationAsked { get; set; }

        [Description("")]
        public bool IsVerified { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("describes the verification channel if verified. The verification could be both automatic and manual. A fee may be requested from the members if a verification is requested for any domain.")]
        public string VerifiedBy { get; set; }

        [Description("")]
        public bool IsPrivateSales { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("holds the analtics value of the web site if available")]
        public string Analytics { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("holds the adsence value of the web site if available")]
        public string AdSense { get; set; }

        [ColumnDetail(ColumnType = DbType.VarChar, Length = 40), Description("holds the alexa value of the web site if available")]
        public string Alexa { get; set; }


    }

}