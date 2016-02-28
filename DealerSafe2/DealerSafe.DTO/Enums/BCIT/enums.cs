using DealerSafe.DTO;
using DealerSafe.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums.BCIT
{
    public enum enmWhyDelete
    {
        DomainSuresiDolmus = 1,
        FiyatHesaplanamadi = 2,
        MusteriSildi = 3,
        DomainKaydedilmis = 4,
        SepetteUrunKalmadi = 5,
        SiparisSuresiDolmus = 6
    }

    public enum enmSMSCompanies
    {
        Codec = 1,
        Clickatell = 2,
        CodecFast = 3,
        MutluCell = 4,
    }

    public enum MsgType
    {
        error = 1,
        success = 2,
        loading = 3,
        warning = 4,
        info = 5,
        info2 = 6,
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
        OdemeTamamlandi = 10,
    }

    public enum SepeteAtilanProductType
    {
        Diger = 0,
        Domain = 1,
        Domain_Uzatma = 2,
        Domain_Uzatma_Uyeliksiz = 3,
        Domain_Gerialma = 4,
        Domain_Gerialma_Redemption = 5,//
        Domain_Gerialma_Uyeliksiz = 6,
        Domain_Gerialma_Uyeliksiz_Redemption = 7,//
        Transfer = 8,
        Hosting = 9,
        Hosting_Uzatma = 10,
        Hosting_Upgrade = 11,
        Hosting_Backup = 12,
        Hosting_Change = 13,
        Hosting_Domain_Renewal = 14,
        Sunucu = 15,
        Sunucu_Uzatma = 16,
        Sunucu_Eklenti = 17,
        Vps = 18,
        Vps_Uzatma = 19,
        Vps_Eklenti = 20,
        Co_location = 21,
        Co_location_Uzatma = 22,
        SSL = 23,
        SSL_Uzatma = 24,
        Web_Klavuzu = 25,
        Web_Klavuzu_Uzatma = 26,
        Marka_Tescil = 27,
        Kargo_Bedeli = 28,
        Hizmet_Bedeli = 29,
        Borc_Odemesi = 30,
        Server_Ekle = 31,
        Hediye_Ceki = 32,
        Endustriyel_Tasarım = 33,
        Customize_VDS_Server = 34,
        PHosting = 36,
        PHosting_Uzatma = 37,
        PHosting_Upgrade = 38,
        PHosting_Backup = 39,
        PHosting_Change = 40,
        PHosting_Domain_Renewal = 41,
        unknown = 42,
        Customize_VDS_Server_Uzat = 43,
        Customize_VDS_Server_Upgrade = 44,
        StatikIp = 45,
        Marka_EkstraSinif = 46,
        Sunucu_Yukseltme = 47,
        Web_Klavuzu_Yukseltme = 48,
        HyperV = 49,
        HyperV_Uzat = 50,
        HyperV_Component = 51,
        HyperV_Extension = 52,
        PhysicalServer_Uzat = 53

        //database te eklenen ProductType tablosunda bulunnan ürün tipleri
        //
        //dom_Registration = 1,
        //dom_Renewal = 2,
        //dom_RenewalExt = 3,
        //dom_RestoreExpired = 4,
        //dom_RestoreRedemption = 5,
        //dom_RestoreExpiredExt = 6,
        //dom_RestoreRedemptionExt = 7,
        //dom_Transfer = 8,
        //hst_Registration = 9,
        //hst_Renewal = 10,
        //hst_Upgrade = 11,
        //hst_Backup = 12,
        //hst_Change = 13,
        //hst_DomainChange = 14,
        //srv_Dedicated = 15,
        //srv_DedicatedRenewal = 16,
        //srv_DedicatedAddon = 17,
        //srv_Vps = 18,
        //srv_VpsRenewal = 19,
        //srv_VpsAddon = 20,
        //srv_CoLocation = 21,
        //srv_CoLocationRenewal = 22,
        //ssl_Registration = 23,
        //ssl_Renewal = 24,
        //wbk_Registration = 25,
        //wbk_Renewal = 26,
        //trm_MarkaTescil = 27,
        //otr_CargoPrice = 28,
        //otr_OperationCost = 29,
        //otr_ExternalCharge = 30,

    }

    public enum SepeteAtilanMarkaProductType
    {
        Marka_Tescil = 6
    }

    public enum WebKlavuzu_Paketleri
    {
        Lite = 1,
        Standart = 2,
        Platinium = 3,
        Lite_Hostlu = 4,
        Standart_HostLu = 5,
        Platinium_Hostlu = 6,
    }

    public enum enmRegisterCompany
    {
        Directi = 1,
        RRP = 2,
        ODTU = 4,
        DotTK = 5,
        Tucows = 7,
        DealerSafe = 10
    }

    public enum enmStatus
    {
        Pasif = 0, Aktif = 1
    }

    public enum enmReferrerWebSite
    {
        IsimTescil = 0,
        IsimtescilAdmin = 1,
    }

    public enum enmInvoiceCompanies
    {
        IsimTescil_AS = 1,
        Fbs_Kibris = 2,
        Fbs_Turkiye = 3,
    }

    public enum enmPaymentProcess
    {
        Beklemede = 0,
        Problemli = 1,
        Gönderildi = 2,
    }


    // Veri Tabanında UlkeAd olarak Aşağıdaki gibi kaydediliyor isimleri değiştirmemeliyiz.
    public enum enmUlkeKodlari
    {
        Türkiye = 215,
        KuzeyKıbrısTürkCumhuriyeti = 240,
        Afghanistan = 2,
        Albania = 5,
        Algeria = 61,
        AmericanSamoa = 11,
        Andorra = 6,
        Angola = 3,
        Anguilla = 4,
        Antarctica = 12,
        AntiguaandBarbuda = 14,
        Argentina = 9,
        Armenia = 10,
        Aruba = 1,
        Australia = 15,
        Austria = 16,
        Azerbaijan = 17,
        Bahamas = 25,
        Bahrain = 24,
        Bangladesh = 22,
        Barbados = 32,
        Belarus = 27,
        Belgium = 19,
        Belize = 28,
        Benin = 20,
        Bermuda = 29,
        Bhutan = 34,
        Bolivia = 30,
        BosniaandHerzegovina = 26,
        Botswana = 36,
        BouvetIsland = 35,
        Brazil = 31,
        BritishIndianOceanTerritory = 101,
        BruneiDarussalam = 33,
        Bulgaria = 23,
        BurkinaFaso = 21,
        Burundi = 18,
        Cambodia = 114,
        Cameroon = 44,
        Canada = 38,
        CapeVerde = 49,
        CaymanIslands = 53,
        CentralAfricanRepublic = 37,
        Chad = 205,
        Chile = 41,
        China = 42,
        ChristmasIsland = 52,
        CocosKeelingIslands = 39,
        Colombia = 47,
        Comoros = 48,
        Congo = 45,
        CongoDemocraticRepublicofthe = -1,
        CookIslands = 46,
        CostaRica = 50,
        CôtedIvoire = 43,
        Croatia = 96,
        Cuba = 51,
        Cyprus = 54,
        CzechRepublic = 55,
        Denmark = 59,
        Djibouti = 57,
        Dominica = 58,
        DominicanRepublic = 60,
        Ecuador = 62,
        Egypt = 63,
        ElSalvador = 192,
        EquatorialGuinea = 85,
        Eritrea = 64,
        Estonia = 67,
        Ethiopia = 68,
        FalklandIslandsMalvinas = 71,
        FaroeIslands = 73,
        Fiji = 70,
        Finland = 69,
        France = 72,
        FrenchGuiana = 90,
        FrenchPolynesia = 177,
        FrenchSouthernTerritories = 13,
        Gabon = 76,
        Gambia = 83,
        Georgia = 78,
        Germany = 56,
        Ghana = 79,
        Gibraltar = 80,
        Greece = 86,
        Greenland = 88,
        Grenada = 87,
        Guadeloupe = 82,
        Guam = 91,
        Guatemala = 89,
        Guernsey = -1,
        Guinea = 81,
        GuineaBissau = 84,
        Guyana = 92,
        Haiti = 97,
        HeardIslandandMcDonaldIslands = 94,
        HolySeeVaticanCityState = 225,
        Honduras = 95,
        HongKong = 93,
        Hungary = 98,
        Iceland = 105,
        India = 100,
        Indonesia = 99,
        IranIslamicRepublicof = 103,
        Iraq = 104,
        Ireland = 102,
        IsleofMan = -1,
        Israel = 106,
        Italy = 107,
        Jamaica = 108,
        Japan = 110,
        Jersey = -1,
        Jordan = 109,
        Kazakhstan = 111,
        Kenya = 112,
        KoreaDemocraticPeoplesRepublicof = 117,
        KoreaRepublicof = 174,
        Kuwait = 118,
        Kyrgyzstan = 113,
        LaoPeoplesDemocraticRepublic = 119,
        Latvia = 129,
        Lebanon = 120,
        Lesotho = 126,
        Liberia = 121,
        LibyanArabJamahiriya = 122,
        Liechtenstein = 124,
        Lithuania = 127,
        Luxembourg = 128,
        Macao = 130,
        MacedoniatheformerYugoslavRepublicof = 138,
        Madagascar = 134,
        Malawi = 149,
        Malaysia = 150,
        Maldives = 135,
        Mali = 139,
        Malta = 140,
        MarshallIslands = 137,
        Martinique = 147,
        Mauritania = 145,
        Mauritius = 148,
        Mayotte = 151,
        Mexico = 136,
        MicronesiaFederatedStatesof = 74,
        MoldovaRepublicof = 133,
        Monaco = 132,
        Mongolia = 142,
        Montenegro = -1,
        Montserrat = 146,
        Morocco = 131,
        Mozambique = 144,
        Myanmar = 141,
        Namibia = 152,
        Nauru = 162,
        Nepal = 161,
        Netherlands = 159,
        NetherlandsAntilles = 7,
        NewCaledonia = 153,
        NewZealand = 163,
        Nicaragua = 157,
        Niger = 154,
        Nigeria = 156,
        Niue = 158,
        NorfolkIsland = 155,
        NorthernMarianaIslands = 143,
        Norway = 160,
        Oman = 164,
        Pakistan = 165,
        Palau = 170,
        PalestinianTerritoryOccupied = -1,
        Panama = 166,
        PapuaNewGuinea = 171,
        Paraguay = 176,
        Peru = 168,
        Philippines = 169,
        Pitcairn = 167,
        Poland = 172,
        Portugal = 175,
        PuertoRico = 173,
        Qatar = 178,
        Réunion = 179,
        Romania = 180,
        RussianFederation = 181,
        Rwanda = 182,
        SaintBarthélemy = -1,
        SaintHelena = 188,
        SaintKittsandNevis = 116,
        SaintLucia = 123,
        SaintMartinFrenchpart = -1,
        SaintPierreandMiquelon = 195,
        SaintVincentandtheGrenadines = 226,
        Samoa = 233,
        SanMarino = 193,
        SaoTomeandPrincipe = 196,
        SaudiArabia = 183,
        Senegal = 185,
        Seychelles = 202,
        SierraLeone = 191,
        Singapore = 186,
        Slovakia = 198,
        Slovenia = 199,
        SolomonIslands = 190,
        Somalia = 194,
        SouthAfrica = 236,
        SouthGeorgiaandtheSouthSandwichIslands = 187,
        Spain = 66,
        SriLanka = 125,
        Sudan = 184,
        Suriname = 197,
        SvalbardandJanMayen = 189,
        Swaziland = 201,
        Sweden = 200,
        Switzerland = 40,
        SyrianArabRepublic = 203,
        TaiwanProvinceofChina = 217,
        Tajikistan = 208,
        TanzaniaUnitedRepublicof = 218,
        Thailand = 207,
        TimorLeste = 211,
        Togo = 206,
        Tokelau = 209,
        Tonga = 212,
        TrinidadandTobago = 213,
        Tunisia = 214,
        Turkmenistan = 210,
        TurksandCaicosIslands = 204,
        Tuvalu = 216,
        Uganda = 219,
        Ukraine = 220,
        UnitedArabEmirates = 8,
        UnitedKingdom = 77,
        UnitedStates = 223,
        UnitedStatesMinorOutlyingIslands = 221,
        Uruguay = 222,
        Uzbekistan = 224,
        Vanuatu = 231,
        Venezuela = 227,
        VietNam = 230,
        VirginIslandsBritish = 228,
        VirginIslandsUS = 229,
        WallisandFutuna = 232,
        WesternSahara = 65,
        Yemen = 234,
        Zambia = 238,
        Zimbabwe = 239,
        TurkishRepublicofNorthernCyprus = 240,
        Serbia = -1
    }
    public enum enmIlKodlari
    {
        İstanbul = 34,
    }

    public enum enmIlceKodlari
    {
        ÜSKÜDAR = 1708,
    }
}
namespace BCIT
{
    [Serializable]
    public class ProductItem
    {
        public int ProductItemId { get; set; }
        public int CustomizeVdsServerId { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int OrderIndex { get; set; } //Yeni
        public double USDSelling { get; set; }
        //fiyatlar
        public double Price { get; set; }
        public string PriceUnit { get; set; }
        public string PriceUnitStr { get { return PriceUnits.GetUnitPrice(PriceUnit); } }
        public string GetUSDString()
        {
            return string.Format("{0:0.00}", Price) + " " + PriceUnitStr;
        }

        public double PriceTr { get { return PriceUnits.ConvertUSDToTL(Price, USDSelling); } }
        public string PriceTrUnit { get { return "1"; } }
        public string PriceTrUnitsTR { get { return PriceUnits.GetUnitPrice(PriceTrUnit); } }
        public string GetTrString()
        {
            return string.Format("{0:0.00}", PriceTr) + " " + PriceTrUnitsTR;
        }
        //////////////////////////////////////////////////////////////////////////////////////
        public string OperatingSystem { get; set; }
        public string IsConfiguratiion { get; set; }

        public EnmPROPS Prop
        {
            get
            {
                return (EnmPROPS)(PropEnmVariable ?? 0);

            }

        }
        public int? PropEnmVariable { get; set; }

        //sepette ek parçaları göstermek için
        public bool ExtraProp { get; set; }
        public EnmUNITS EnmUnit { get; set; }

        //Parça değişikliğinde kullanıcıya toplam tutarı göndermek için
        public string PriceTotalStr { get; set; }
        public string PriceTotal { get; set; }

        public double IndirimTutari { get; set; }
        public int Yuzde { get; set; }
        public double Tutar { get; set; }
        public double tempPrice { get; set; }
    }

    [Serializable]
    public class ProductDTO
    {
        public List<ProductItem> ProductItems { get; set; }

        public double PriceTotal
        {
            get
            {
                return ProductItems.Sum(x => x.Price) * Quantity;
            }
        }
        public string PriceTotalUnit { get { return "2"; } }
        public string GetUSDString()
        {
            return PriceTotal + " " + PriceUnits.GetUnitPrice(PriceTotalUnit);
        }
        /////
        public double PriceTotalTr { get { return ProductItems.Sum(x => x.PriceTr) * Quantity; } }
        public string PriceTotalTrUnit { get { return "1"; } }
        public string GetTrString()
        {
            return PriceTotalTr + " " + PriceUnits.GetUnitPrice(PriceTotalTrUnit);
        }

        public double Quantity { get; set; }
        public string QuantityType { get; set; }

        public double USDSelling { get; set; }

        public string ExtraConfigurationDescription { get; set; }
        public EnmGROUPS Group { get; set; }
        public string ProductSummary { get; set; }

        public double IndirimTutari { get; set; }
        public int Yuzde { get; set; }
        public double Tutar { get; set; }
        public int MemberId { get; set; }
        public int BasketDetailCustomizeVdsServerId { get; set; }
        public int BasketDetailId { get; set; }
    }
    [Serializable]
    public class PRD_HostingDTO
    {
        public int PHostingId { get; set; }
        public int BasketDetailId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string OperatingSystem { get; set; }
        public EnmGROUPS EnmGroup { get; set; }

        public double OldPrice { get; set; }
        public double TempPrice { get; set; }
        public double Price { get; set; }
        public string PriceUnit { get; set; }
        public double CampaignPrice { get; set; }
        public string CampaingPriceUnit { get; set; }
        public bool IsPromotion { get; set; }

        public double Quantity { get; set; }
        public string QuantityType { get { return "Ay"; } }

        public List<PRD_HostingItemsDTO> HostingItems { get; set; }

        ////
        public double USDSelling { get; set; }
        public string ProductCode { get; set; }
        public int ProductID { get; set; }
        public int UpgradeQuantity { get; set; }

        public Guid Key { get; set; }
        public bool Reseller { get; set; }
    }

    [Serializable]
    public class PRD_HostingItemsDTO
    {
        public int HostingItemId { get; set; }
        public int BasketDetailId { get; set; }
        public int BasketPHostingId { get; set; }
        public int Id { get; set; }
        public string PropName { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }
        public int? UsedValue { get; set; }
        public string UsedValueStr { get; set; }
        public EnmPROPS EnmProp { get; set; }
        public int DetailId { get; set; }
    }
    [Serializable]
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
    public enum enmIndustrialDesignColourType
    {
        colorful = 1,
        black = 2
    }
}
