using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class UpdateMemberBasketInfo
    {
        public bool Process { get; set; }

        public int BasketId { get; set; }
        public int memberID { get; set; }
        public string memberSessionKey { get; set; }
        public int orderID { get; set; }
        public decimal TotalDolarPrice { get; set; }
        public decimal TotalYTLPrice { get; set; }
        public decimal KomisyonsuzTotalDollarPrice { get; set; }
        public decimal KomisyonsuzTotalYTLPrice { get; set; }
        public string OrderDetailID { get; set; }
        public int count { get; set; }
        public int direkOdeme { get; set; }
        public int paymentType { get; set; }
        public string KrediKartNo { get; set; }
        public int invoiceCompanyId { get; set; }
        public int invoiceCargoAddressId { get; set; }
        public int invoiceAddressId { get; set; }
        public bool invoiceSend { get; set; }
        public int cargoId { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignEndDate { get; set; }
        public decimal DiscountPercent { get; set; }
        public List<MemberBasketDetail> product { get; set; }

        public class MemberBasketDetail
        {
            public int BasketDetailId { get; set; }
            public int BasketId { get; set; }
            public int MemberId { get; set; }
            public string MemberSessionKey { get; set; }
            public int BasketItemId { get; set; }
            public string Name { get; set; }
            public decimal MonthPrice { get; set; }
            public decimal DollarPrice { get; set; }
            public decimal YearPrice { get; set; }
            public decimal kdvliDollarPrice { get; set; }
            public decimal YTLPrice { get; set; }
            public decimal kdvliYTLPrice { get; set; }
            public decimal Quantity { get; set; }
            public string QuantityType { get; set; }
            public string Type { get; set; }
            public string RegistryCompany { get; set; }
            public decimal Tax { get; set; }
            public decimal UsdSelling { get; set; }
            public int islemiYapildi { get; set; }
            public int InCampaign { get; set; }
            public decimal CampaignPrice { get; set; }
            public decimal CampaignPeriod { get; set; }
            public string IsExpiredHosting { get; set; }
            public int HostingID_Lenghten { get; set; }
            public int QueueID { get; set; }
            public int TargetID { get; set; }
            public int OrderDetailID { get; set; }
            public int UzantiID { get; set; }
            public int ProductID { get; set; }
            public int referredPrdID { get; set; }
            public int ServerID { get; set; }
            public bool IsPromotion { get; set; }
            public decimal DomainPriceForCamp { get; set; }
            public string AuthCode { get; set; }
            public string MarkClassIDs { get; set; }
            public string MarkName { get; set; }
            public int ProductTypeId { get; set; }
            public int domContComp { get; set; }
            public bool EkstraUzatma { get; set; }
            public string relatedProducts { get; set; }
            public int ColourType { get; set; }
            public int VisualCount { get; set; }
            public int Promotion { get; set; }
            public decimal OldPrice { get; set; }
            public int UpgradeQuantity { get; set; }
            public string PciDssDomanName { get; set; }
            public CustomizeVdsServer customizeVdsServer { get; set; }
            public PHosting phosting { get; set; }
            public PatentAndBenefitModel patentAndBenefitModel { get; set; }

            public class CustomizeVdsServer
            {
                public int BasketDetailCustomizeVdsServerId { get; set; }
                public int BasketDetailId { get; set; }
                public int MemberId { get; set; }
                public decimal PriceTotal { get; set; }
                public string PriceTotalUnit { get; set; }
                public string GetUSDString { get; set; }
                public decimal PriceTotalTr { get; set; }
                public string PriceTotalTrUnit { get; set; }
                public string GetTrString { get; set; }
                public decimal Quantity { get; set; }
                public string QuantityType { get; set; }
                public decimal USDSelling { get; set; }
                public string ExtraConfigurationDescription { get; set; }
                public int EnmGroup { get; set; }
                public string ProductSummary { get; set; }
                public decimal IndirimTutari { get; set; }
                public int Yuzde { get; set; }
                public decimal Tutar { get; set; }
                public List<ProductItem> ProductItems { get; set; }

                public class ProductItem
                {
                    public int ProductItemId { get; set; }
                    public int CustomizeVdsServerId { get; set; }
                    public int ItemId { get; set; }
                    public int GroupId { get; set; }
                    public string Name { get; set; }
                    public int OrderIndex { get; set; }
                    public decimal Price { get; set; }
                    public string PriceUnit { get; set; }
                    public string PriceUnitStr { get; set; }
                    public string GetUSDString { get; set; }
                    public decimal PriceTr { get; set; }
                    public string PriceTrUnit { get; set; }
                    public string PriceTrUnitsTR { get; set; }
                    public string GetTrString { get; set; }
                    public string OperatingSystem { get; set; }
                    public string IsConfiguratiion { get; set; }
                    public int Prop { get; set; }
                    public int PropEnmVariable { get; set; }
                    public bool ExtraProp { get; set; }
                    public int EnmUnit { get; set; }
                    public string PriceTotalStr { get; set; }
                    public string PriceTotal { get; set; }
                    public decimal IndirimTutari { get; set; }
                    public int Yuzde { get; set; }
                    public decimal Tutar { get; set; }
                    public decimal tempPrice { get; set; }
                }
            }
            public class PHosting
            {
                public int PHostingId { get; set; }
                public int BasketDetailId { get; set; }
                public int ItemId { get; set; }
                public string Name { get; set; }
                public string OperatingSystem { get; set; }
                public int EnmGroup { get; set; }
                public decimal OldPrice { get; set; }
                public decimal TempPrice { get; set; }
                public decimal Price { get; set; }
                public string PriceUnit { get; set; }
                public decimal CampaignPrice { get; set; }
                public string CampaingPriceUnit { get; set; }
                public decimal Quantity { get; set; }
                public string QuantityType { get; set; }
                public decimal USDSelling { get; set; }
                public string ProductCode { get; set; }
                public int ProductID { get; set; }
                public int UpgradeQuantity { get; set; }
                public string GuidKey { get; set; }
                public bool Reseller { get; set; }
                public List<HostingItem> HostingItems { get; set; }

                public class HostingItem
                {
                    public int HostingItemId { get; set; }
                    public int BasketDetailId { get; set; }
                    public int BasketPHostingId { get; set; }
                    public int ItemId { get; set; }
                    public string PropName { get; set; }
                    public string Name { get; set; }
                    public int Value { get; set; }
                    public int UsedValue { get; set; }
                    public string UsedValueStr { get; set; }
                    public int EnmProp { get; set; }
                    public int DetailId { get; set; }
                }
            }
            public class PatentAndBenefitModel
            {
                public int PatentAndBenefitModelId { get; set; }
                public int BasketDetailId { get; set; }
                public string NameOfInvention { get; set; }
                public string Sector { get; set; }
                public string UsingArea { get; set; }
                public string ProtectionArea { get; set; }
                public int ProcessType { get; set; }
            }
        }
    }
}
