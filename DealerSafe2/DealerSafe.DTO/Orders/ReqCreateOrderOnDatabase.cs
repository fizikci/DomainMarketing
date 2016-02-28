using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqCreateOrderOnDatabase
    {
        public int BankId { get; set; }
        public int RateNumber { get; set; }
        public enmPaymentType PaymentType { get; set; }
        public int pcBankId { get; set; }
        public int OrderID { get; set; }
        public string IPAddress { get; set; }
        public BasketDetail Basket { get; set; }
        public PaymentFlag Payflag { get; set; }
        public HostingUpgradeDetail HostingUpgrade { get; set; }
        public ServerDetails ServerDetail { get; set; }
        [Description("Credit ID of the payment")]
        public double CreditAmount { get; set; }

        [Description("Specified of the Credit ID")]
        public bool CreditAmountSpecified { get; set; }

        public double Quantity { get; set; }
        public bool QuantitySpecified { get; set; }

        public string QuantityType { get; set; }
        public bool QuantityTypeSpecified { get; set; }
    }

    public enum enmPaymentType
    {
        BankaHavalesi = 1,
        MailOrder = 2,
        KrediKartıPeşin = 3,
        KrediKartıTaksit = 4,
        MailOrderTaksit = 5,
        Kredili = 6,
        PostaÇeki = 7,
        BonusPay = 8,
        PayPal = 9,
        Mobile = 12,
        ÖdemeYapılmamış = 0,
        OdemeTamamlandi = 10
    }

    public enum EnmPaymentOrderType
    {
        BankaHavalesi = 1,
        MailOrder = 2,
        KrediKartıPeşin = 3,
        KrediKartıTaksit = 4,
        MailOrderTaksit = 5,
        Kredili = 6,
        PostaÇeki = 7,
        BonusPay = 8,
        PayPal = 9,
        Mobile = 12,
        ÖdemeYapılmamış = 0,
        Kupon  = 10
    }


    public class BasketDetail
    {
        public double totalDollarPrice { get; set; }
        public double totalYTLPrice { get; set; }
        public double komisyonsuzTotalDollarPrice { get; set; }
        public double komisyonsuzTotalYTLPrice { get; set; }
        public int orderID { get; set; }
        public string OrderDetailID { get; set; }
        public int memberID { get; set; }
        public int count { get; set; }
        public int direkOdeme { get; set; }
        public int paymentType { get; set; }
        public string KrediKartNo { get; set; }
        public int invoiceCompanyId { get; set; }
        public int invoiceCargoAddressId { get; set; }
        public int invoiceAddressId { get; set; }
        public bool invoiceSend { get; set; }
        public int cargoId { get; set; }
        public List<ProductDetail> product { get; set; }
        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignEndDate { get; set; }
        public double DiscountPercent { get; set; }

    }
    public class HostingUpgradeDetail
    {
        public int HostUpgradeProductID { get; set; }
        public int HostUpgradeHostPeriod { get; set; }
        public int HostUpgradeBackUpOldHost { get; set; }
        public string HostUpgradeNewDomain { get; set; }
        public string HostUpgradeOldDomain { get; set; }
        public int HostUpgradeOldDomainHostDnsID { get; set; }
        public int HostUpgradeOldHostID { get; set; }
        public string HostUpgradeHostExpiration { get; set; }
    }

    public class ProductDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double MonthPrice { get; set; }
        public double DollarPrice { get; set; }
        public double YearPrice { get; set; }
        public double kdvliDollarPrice { get; set; }
        public double YTLPrice { get; set; }
        public double kdvliYTLPrice { get; set; }
        public double Quantity { get; set; }
        public string QuantityType { get; set; }
        public string Type { get; set; }
        public string RegistryCompany { get; set; }
        public double Tax { get; set; }
        public double UsdSelling { get; set; }
        public int islemiYapildi { get; set; }
        public int InCampaign { get; set; }
        public double CampaignPrice { get; set; }
        public double CampaignPeriod { get; set; }
        public string IsExpiredHosting { get; set; }//hosting uzatma için
        public int HostingID_Lenghten { get; set; }//hosting uzatma için
        public int QueueID { get; set; }//Kuyruğa atılan işlem için kuyruktaki Id si
        public int TargetID { get; set; }//ürünün tipine göre bağlı olduğu ürün gurubunun tablosuna ilişkin ID si ör: Domain için MembersDNS tbl daki ID gibi
        //public int DomainID;//domain uzatma geri alma için....
        public int OrderDetailID { get; set; }
        public int UzantiID { get; set; }//UzantiID;
        public int ProductID { get; set; }
        public int referredPrdID { get; set; }//uzatma yapılan domaine aitse buraya domainin ID si gonderilir.
        public int ServerID { get; set; }//Sunucularda eklenti satın alınmışsa buraya eklenir.
        public bool IsPromotion { get; set; }//Promotion domain ise true set edilir.
        public double DomainPriceForCamp { get; set; }//kampanyalı domain için normal fiyat burada tutulur.
        public string AuthCode { get; set; } // Transfer Şifresi
        public List<object> MarkClassIDs { get; set; }
        public string MarkName { get; set; }
        public int ProductTypeId { get; set; }
        public ContactCompatibility domContComp { get; set; }
        public bool EkstraUzatma { get; set; }
        public string relatedProducts { get; set; }
        public IndustrialDesignColourType ColourType { get; set; }
        public int VisualCount { get; set; }
        public int Promotion { get; set; }
        public double OldPrice { get; set; } // hostinglerin eski fiyatlarını alabilmek için eklendi. 
        public ProductDTODetail customizeVdsServer { get; set; }
        public PRD_HostingDTODetail phosting { get; set; }
        public int UpgradeQuantity { get; set; }
        public string PciDssDomanName { get; set; }
        public List<int> SunucuEklenti { get; set; } // yeni sunucular için 7.4.2014
        public PatentAndBenefitModelDetail PatentAndBenefitModel { get; set; }
        public DealerSafe.DTO.Enums.EnmRegisterStatus enmRegisterStatus { get; set; }
        public int ReferenceId { get; set; }
        public int ParentBrandId { get; set; }

        public enum ContactCompatibility
        {
            None = 0, Generic = 1, DotTr = 2, Europeen = 3, DotTc = 4, DotRo = 5, all = 6, NoDomain = 7
        }
        public enum IndustrialDesignColourType
        {
            None = 0,
            colorful = 1,
            black = 2
        }
        public class PatentAndBenefitModelDetail
        {
            public string NameOfInvention { get; set; }
            public string Sector { get; set; }
            public string UsingArea { get; set; }
            public string ProtectionArea { get; set; }
            public int ProcessType { get; set; }
        }
        public class PRD_HostingDTODetail
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string OperatingSystem { get; set; }
            public GROUPSDetails EnmGroup { get; set; }

            public double OldPrice { get; set; }
            public double TempPrice { get; set; }
            public double Price { get; set; }
            public string PriceUnit { get; set; }
            public double CampaignPrice { get; set; }
            public string CampaingPriceUnit { get; set; }

            public double Quantity { get; set; }
            public string QuantityType { get; set; }

            public List<PRD_HostingItemsDTODetail> HostingItems { get; set; }

            ////
            public double USDSelling { get; set; }
            public string ProductCode { get; set; }
            public int ProductID { get; set; }
            public int UpgradeQuantity { get; set; }

            public Guid Key { get; set; }
            public bool Reseller { get; set; }
        }
        public enum GROUPSDetails
        {
            None = 0,
            SERVER = 1,
            CUSTOMIZE_VDS = 2,
            DEDICATED = 3,
            HOSTING = 4,
            VERiTABANI_YAZILIMI = 5,
            GÜVENLIK = 6,
            MEDIA_SERVISLERI = 7,
            MAIL_YAZILIMI = 8,
            DESTEK = 9,
            IP = 10,
            YEDEKLEME_HIZMETI = 11
        }
        public class PRD_HostingItemsDTODetail
        {
            public int Id { get; set; }
            public string PropName { get; set; }
            public string Name { get; set; }
            public int? Value { get; set; }
            public int? UsedValue { get; set; }
            public string UsedValueStr { get; set; }
            public PROPSDetails EnmProp { get; set; }
            public int DetailId { get; set; }
        }
        public enum PROPSDetails
        {
            TANIMSIZ = 0,
            RAM = 1,
            CPU = 2,
            HDD = 3,
            TRAFIK = 4,
            KONTROL_PANEL = 5,
            ISLETIM_SISTEMI = 6,
            PAKET = 7,
            MARKA = 8,
            PORT = 9,
            IP = 10,
            DESTEK = 11,
            HIZMET_SURESI = 12,
            //CUSTOMIZE = 13,
            DATABASE = 14,
            GUVENLIK = 15,
            MEDIA_SERVISLERI = 16,
            MAIL_YAZILIMI = 17,
            KONFIGURASYON = 18,
            /////////////////////////////Hosting özellikleri
            //PANEL_TYPE = 100,
            //EMAİL_PANEL_TYPE = 101, 
            EMAİL_SERVER = 102,
            SERVER_ID = 103,
            EMAİLSERVER_ID = 104,
            IS_SUSPENDED = 105,
            CLİENT_NAME = 106,
            RESELLER_PACKET = 107,
            CLİENT_TEMPLATE_NAME = 108,
            DOMAİN_TEMPLATE_NAME = 109,
            DİSK_BOYUTU = 110,
            DOMAİN_BARINDIRMA = 111,
            MAİL_HESABI = 112,
            AYLIK_TRAFİK = 113,
            FTP_HESAPLARI = 114,
            MY_SQL = 115,
            MS_SQL = 116,
            MYSQL_ALANI = 117,
            MSSQL_ALANI = 118,
            MAİL_BOX_SİZE = 119,
            SUB_DOMAİNS = 120,
            ////////////////////////////
            YEDEKLEME_HIZMETI = 207,
            SURGATE_ID = 208
        }
        public class ProductDTODetail
        {
            public List<ProductItemDetail> ProductItems { get; set; }

            public double PriceTotal { get; set; }
            public string PriceTotalUnit { get; set; }
            public string GetUSDString { get; set; }
            /////
            public double PriceTotalTr { get; set; }
            public string PriceTotalTrUnit { get; set; }
            public string GetTrString { get; set; }

            public double Quantity { get; set; }
            public string QuantityType { get; set; }

            public double USDSelling { get; set; }

            public string ExtraConfigurationDescription { get; set; }
            public GROUPSDetails Group { get; set; }
            public string ProductSummary { get; set; }

            public double IndirimTutari { get; set; }
            public int Yuzde { get; set; }
            public double Tutar { get; set; }
            public int MemberId { get; set; }
        }
        public class ProductItemDetail
        {
            public int Id { get; set; }
            public int GroupId { get; set; }
            public string Name { get; set; }
            public int OrderIndex { get; set; } //Yeni

            //fiyatlar
            public double Price { get; set; }
            public string PriceUnit { get; set; }
            public string PriceUnitStr { get; set; }
            public string GetUSDString { get; set; }

            public double PriceTr { get; set; }
            public string PriceTrUnit { get; set; }
            public string PriceTrUnitsTR { get; set; }
            public string GetTrString { get; set; }
            //////////////////////////////////////////////////////////////////////////////////////
            public string OperatingSystem { get; set; }
            public string IsConfiguratiion { get; set; }

            public DealerSafe.DTO.Orders.ProductDetail.PROPSDetails Prop { get; set; }
            public int? PropEnmVariable { get; set; }

            //sepette ek parçaları göstermek için
            public bool ExtraProp { get; set; }
            public UNITSDetails EnmUnit { get; set; }

            //Parça değişikliğinde kullanıcıya toplam tutarı göndermek için
            public string PriceTotalStr { get; set; }
            public string PriceTotal { get; set; }

            public double IndirimTutari { get; set; }
            public int Yuzde { get; set; }
            public double Tutar { get; set; }
            public double tempPrice { get; set; }
        }
        public enum UNITSDetails
        {
            None = 0,
            AYLIK_1 = 1,
            AYLIK_2 = 2,
            AYLIK_3 = 3,
            AYLIK_4 = 4,
            AYLIK_5 = 5,
            AYLIK_6 = 6,
            AYLIK_7 = 7,
            AYLIK_8 = 8,
            AYLIK_9 = 9,
            AYLIK_10 = 10,
            AYLIK_11 = 11,
            AYLIK_12 = 12,
            AYLIK_24 = 24,
            AYLIK_36 = 36,
            AYLIK_48 = 48,
            AYLIK_60 = 60,
            AYLIK_120 = 120
        }
    }

    public class ServerDetails
    {
        public int EklentiServerID { get; set; }
        public bool EklentiServerIDSpecified { get; set; }

        public int ProductServerID { get; set; }
        public bool ProductServerIDSpecified { get; set; }
    }
}
