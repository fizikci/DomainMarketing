using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Data;
using DealerSafe.DTO;
using DealerSafe.DTO.Enums.BCIT;
using DealerSafe.DTO.Enums;
using DealerSafe.ServiceClient;

namespace BCIT
{
    public enum enmProductTypes
    {
        Kampanya_Paketi = 1, Hosting = 2, Tasarým_Paketi = 3, Alan_Adý_Uzatma = 4, Alan_Adý_GeriAlma = 5,
        Alan_Adý_Transfer = 6, Domain = 7, Hosting_Eki = 8, Tasarim_Eki = 9, Standart_Ürün = 10, DomainMarket = 11,
        Hosting_Uzatma = 12, SSL = 13, Kredi = 14, Domain_Turkish = 15, KrediDolar = 16, Domain_Eki = 17,
        VPS_Sunucu = 18, VPS_Sunucu_Eki = 19, Dedicated_Sunucu = 20, Dedicated_Sunucu_Eki = 21, Colocated_Sunucu = 22,
        Web_Klavuzu = 23
    }

    /// <summary>
    /// Summary description for Sepet.
    /// </summary>
    [Serializable]

    public class Sepet
    {
        public int BasketId { get; set; }
        public string memberSessionKey { get; set; }
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
        public ArrayList product { get; set; }

        public DateTime CampaignStartDate { get; set; }
        public DateTime CampaignEndDate { get; set; }
        public double DiscountPercent { get; set; }

        public enum ExchangeType
        {
            YTL,
            Dolar,
            Euro
        }

        Product prd;
        readonly static Security _security = new Security();

        public Sepet()
        {

        }

        public void setCampaignPrize(DateTime CampaignStartDate, DateTime CampaignEndDate, double DiscountPercent)
        {
            this.CampaignStartDate = CampaignStartDate;
            this.CampaignEndDate = CampaignEndDate;
            this.DiscountPercent = DiscountPercent;
        }

        //Hosting uzatma için
        public void yeniUrunEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice,
            string IsExpiredHosting, int HostingID_Lenghten, int ProductID)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.IsExpiredHosting = IsExpiredHosting;
            prd.HostingID_Lenghten = HostingID_Lenghten;
            prd.TargetID = HostingID_Lenghten;
            prd.ProductID = ProductID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void yeniUrunEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice,
            string IsExpiredHosting, int HostingID_Lenghten, int ProductID, int referredPrdID)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.IsExpiredHosting = IsExpiredHosting;
            prd.HostingID_Lenghten = HostingID_Lenghten;
            prd.ProductID = ProductID;
            prd.referredPrdID = referredPrdID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }


        //alan adý uzatma, hosting, ssl alma için
        public void yeniUrunEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int UzantiID, int ProductID, string PsiDssDomainName = "")
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.UzantiID = UzantiID;
            prd.ProductID = ProductID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.PciDssDomanName = PsiDssDomainName;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //ssl alma için
        public void yeniSslEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int UzantiID, int ProductID, int TargetID)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.UzantiID = UzantiID;
            prd.ProductID = ProductID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.TargetID = TargetID;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }


        public void yeniStatikIpEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type, double Tax, double usdSelling, double YearPrice, int ProductID, int TargetID)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.YearPrice = YearPrice;
            prd.ProductID = ProductID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.TargetID = TargetID;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }


        //Kargo Bedeli 
        public void KargoEkle(int ID, string Name, string Type, string QuantityType, double Tax, double DollarPrice, double Quantity)
        {
            prd = new Product();
            prd.ID = ID;
            prd.DollarPrice = DollarPrice;
            prd.Name = Name;
            prd.Type = Type;
            prd.QuantityType = QuantityType;
            prd.Quantity = Quantity;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.Tax = Tax;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }


        //Domain Kayýt
        public void yeniDomainEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int UzantiID, int ProductID, enmContactCompatibility domContComp, EnmRegisterStatus enmRegisterStatus, bool IsLast = false)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.UzantiID = UzantiID;
            prd.ProductID = ProductID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.domContComp = domContComp;
            prd.enmRegisterStatus = enmRegisterStatus;
            product.Add(prd);
            setPrices(count);
            count++;

            if (IsLast == false)
                setTotalPrice();
        }

        // alan adý alma, alan adý uzatma, Extra için
        public void yeniUrunEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int UzantiID, int ProductID, bool EkstraUzatma, int TargetID)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.UzantiID = UzantiID;
            prd.ProductID = ProductID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.EkstraUzatma = EkstraUzatma;
            prd.TargetID = TargetID;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //sunucu eklenti satýnlamak için
        public void yeniUrunEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int UzantiID, int ProductID, int ServerID, string PsiDssDomainName = "", List<int> SunucuEklenti = null)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.UzantiID = UzantiID;
            prd.ProductID = ProductID;
            prd.ServerID = ServerID;
            prd.TargetID = ServerID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.PciDssDomanName = PsiDssDomainName;
            prd.SunucuEklenti = SunucuEklenti; // 7.4.2014 sunucu için eklendi
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        // alan adý uzatma için        
        public void yeniUrunEkle_(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
            double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int TargetID, int DomainID, int HostingID, int ProductID)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.TargetID = TargetID;
            prd.ProductID = ProductID;
            prd.HostingID_Lenghten = HostingID;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //Transfer ürünü eklemek için
        public void TransferUrunEkle(int ID, string Name, double DollarPrice, double YTLPrice, double Quantity, string QuantityType, string Type,
                    double Tax, string RegistryCompany, double usdSelling, int InCampaign, double CampaignPrice, double CampaignPeriod, double YearPrice, int UzantiID, int ProductID, string AuthCode, enmContactCompatibility domContComp)
        {
            prd = new Product();
            prd.UsdSelling = usdSelling;
            prd.ID = ID;
            prd.Name = Name;
            prd.DollarPrice = DollarPrice;
            prd.Tax = Tax;
            Tax = (Tax + 100.0) / 100.0;
            prd.YTLPrice = YTLPrice;
            prd.Quantity = Quantity;
            prd.QuantityType = QuantityType;
            prd.Type = Type;
            prd.RegistryCompany = RegistryCompany;
            prd.InCampaign = InCampaign;
            prd.CampaignPrice = CampaignPrice;
            prd.CampaignPeriod = CampaignPeriod;
            prd.YearPrice = YearPrice;
            prd.UzantiID = UzantiID;
            prd.ProductID = ProductID;
            prd.AuthCode = AuthCode;
            prd.domContComp = domContComp;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void MarkaUrunEkle(int ID, string Name, string MarkName, double DollarPrice, double YTLPrice, string Type, double Tax, double usdSelling, double YearPrice, ArrayList MarkClassIDs, int UzantiID, ArrayList MarkClassProductIDs = null, int ParentBrandId = 0)
        {
            prd = new Product();
            prd.ID = ID;
            prd.Name = Name;
            prd.MarkName = MarkName;
            prd.DollarPrice = DollarPrice;
            prd.YTLPrice = YTLPrice;
            prd.Type = Type;
            prd.UsdSelling = usdSelling;
            prd.Tax = Tax;
            prd.YearPrice = YearPrice;
            prd.MarkClassIDs = MarkClassIDs;
            prd.UzantiID = UzantiID;
            prd.Quantity = 1;
            prd.QuantityType = "Yýl";
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.MarkClassProductIDs = MarkClassProductIDs;
            prd.ParentBrandId = ParentBrandId;

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }
        public void MarkaUrunEkle(int ID, string Name, string MarkName, double DollarPrice, double YTLPrice, string Type, double Tax, double usdSelling, double YearPrice, ArrayList MarkClassIDs, int UzantiID, int MarkID)
        {
            prd = new Product();
            prd.ID = ID;
            prd.Name = Name;
            prd.MarkName = MarkName;
            prd.DollarPrice = DollarPrice;
            prd.YTLPrice = YTLPrice;
            prd.Type = Type;
            prd.UsdSelling = usdSelling;
            prd.Tax = Tax;
            prd.YearPrice = YearPrice;
            prd.MarkClassIDs = MarkClassIDs;
            prd.UzantiID = UzantiID;
            prd.Quantity = 1;
            prd.QuantityType = "Yýl";
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.TargetID = MarkID;

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }
        public void MarkaUrunEkle(int ID, string Name, string MarkName, double DollarPrice, double YTLPrice, string Type, double Tax, double usdSelling, double YearPrice, ArrayList MarkClassIDs, int UzantiID, PatentAndBenefitModel patentAndBenefitModel)
        {
            prd = new Product();
            prd.ID = ID;
            prd.Name = Name;
            prd.MarkName = MarkName;
            prd.DollarPrice = DollarPrice;
            prd.YTLPrice = YTLPrice;
            prd.Type = Type;
            prd.UsdSelling = usdSelling;
            prd.Tax = Tax;
            prd.YearPrice = YearPrice;
            prd.MarkClassIDs = MarkClassIDs;
            prd.UzantiID = UzantiID;
            prd.Quantity = 1;
            prd.QuantityType = "Yýl";
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.PatentAndBenefitModel = patentAndBenefitModel;

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }
        public void MarkaUrunEkleForStaff(int ID, string Name, string MarkName, double DollarPrice, double YTLPrice, string Type, double Tax, double usdSelling, double YearPrice, ArrayList MarkClassIDs, int UzantiID, PatentAndBenefitModel patentAndBenefitModel)
        {
            prd = new Product();
            prd.ID = ID;
            prd.Name = Name;
            prd.MarkName = MarkName;
            prd.DollarPrice = DollarPrice;
            prd.YTLPrice = YTLPrice;
            prd.Type = Type;
            prd.UsdSelling = usdSelling;
            prd.Tax = Tax;
            prd.YearPrice = YearPrice;
            prd.MarkClassIDs = MarkClassIDs;
            prd.UzantiID = UzantiID;
            prd.Quantity = 1;
            prd.QuantityType = "Yýl";
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);
            prd.PatentAndBenefitModel = patentAndBenefitModel;

            if (product == null) product = new ArrayList();
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPriceForStaff();
        }

        public void EndTasarimUrunEkle(int ID, string Name, int VisualCount, enmIndustrialDesignColourType colourType, string Type, double TotalYTL, double usdSelling)
        {
            prd = new Product();
            prd.ID = ID;
            prd.Name = Name;
            prd.Type = Type;
            prd.DollarPrice = Math.Round(TotalYTL / usdSelling, 2);
            prd.YTLPrice = TotalYTL;
            prd.UsdSelling = usdSelling;
            prd.Tax = 18;
            prd.Quantity = 1;
            prd.QuantityType = "Yýl";
            prd.ColourType = colourType;
            prd.VisualCount = VisualCount;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(Type);

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //Hediye çeki ürünü ekle
        public void HediyeCekiEkle(double priceUSD, double priceTL, double quantity, int tax, double usdSelling, string relatedProducts)
        {
            prd = new Product();
            prd.ID = (int)SepeteAtilanProductType.Hediye_Ceki;
            prd.Name = "Hediye Çeki";
            prd.DollarPrice = priceUSD;
            prd.YTLPrice = priceTL;
            prd.Quantity = quantity;
            prd.QuantityType = "Adet";
            prd.Type = GeneralFunctions.productType(SepeteAtilanProductType.Hediye_Ceki);
            prd.Tax = tax;
            prd.UsdSelling = usdSelling;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(prd.Type);
            prd.relatedProducts = relatedProducts;

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //Customize VDS Server Ekle
        public void CustomizeServerEkle(ProductDTO productDTO)
        {
            double tutar = productDTO.IndirimTutari != 0
                ? (productDTO.PriceTotal - productDTO.IndirimTutari)
                : productDTO.PriceTotal;

            double tutarTr = getYTLPrice(productDTO.USDSelling, tutar);
            if (tutar != 0)
                tutarTr = getYTLPrice(productDTO.USDSelling, tutar);


            prd = new Product();
            prd.ID = (int)SepeteAtilanProductType.Customize_VDS_Server;
            prd.Name = "Customize VDS Server";
            prd.DollarPrice = tutar;
            prd.YTLPrice = tutarTr;
            prd.Quantity = productDTO.Quantity;
            prd.QuantityType = productDTO.QuantityType;
            prd.Type = GeneralFunctions.productType(SepeteAtilanProductType.Customize_VDS_Server);
            prd.Tax = 18;
            prd.UsdSelling = productDTO.USDSelling;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(prd.Type);
            prd.customizeVdsServer = productDTO;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //Customize VDS Server Yükseltme
        public void CustomizeServerUpgrade(ProductDTO productDTO, int targetID, double total)
        {
            double tutar = productDTO.IndirimTutari != 0
               ? (total - productDTO.IndirimTutari)
               : total;

            double tutarTr = getYTLPrice(productDTO.USDSelling, tutar);
            if (tutar != 0)
                tutarTr = getYTLPrice(productDTO.USDSelling, tutar);


            prd = new Product();
            prd.ID = (int)SepeteAtilanProductType.Customize_VDS_Server_Upgrade; //Burasý bilinçli olarak Customize_VDS_Server olarak belirlenmiþtir. ProductTypeId den farklýdýr.
            prd.Name = "Customize VDS Server Upgrade";
            prd.TargetID = targetID;   // Upgrade için ekstradan sunucunun ID sini gönderiyorum. Üst taraftaki metot için gerekli deðil..
            prd.DollarPrice = tutar;// productDTO.PriceTotal;
            prd.YTLPrice = getYTLPrice(productDTO.USDSelling, total); // productDTO.PriceTotalTr;
            prd.Quantity = productDTO.Quantity;
            prd.QuantityType = productDTO.QuantityType;
            prd.Type = GeneralFunctions.productType(SepeteAtilanProductType.Customize_VDS_Server_Upgrade);
            prd.Tax = 18;
            prd.UsdSelling = productDTO.USDSelling;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(prd.Type);
            prd.customizeVdsServer = productDTO;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        //Customize VDS Server Süre Uzat
        public void CustomizeServerSureUzat(ProductDTO productDTO, int targetID)
        {
            double tutar = productDTO.IndirimTutari != 0
              ? (productDTO.PriceTotal - productDTO.IndirimTutari)
              : productDTO.PriceTotal;

            double tutarTr = getYTLPrice(productDTO.USDSelling, tutar);
            if (tutar != 0)
                tutarTr = getYTLPrice(productDTO.USDSelling, tutar);

            prd = new Product();
            prd.ID = (int)SepeteAtilanProductType.Customize_VDS_Server_Uzat; //Burasý bilinçli olarak Customize_VDS_Server olarak belirlenmiþtir. ProductTypeId den farklýdýr.
            prd.Name = "Customize VDS Server Uzat";
            prd.TargetID = targetID;   // Upgrade için ekstradan sunucunun ID sini gönderiyorum. Üst taraftaki metot için gerekli deðil..
            prd.DollarPrice = tutar;
            prd.YTLPrice = tutarTr;
            prd.Quantity = productDTO.Quantity;
            prd.QuantityType = productDTO.QuantityType;
            prd.Type = GeneralFunctions.productType(SepeteAtilanProductType.Customize_VDS_Server_Uzat);
            prd.Tax = 18;
            prd.UsdSelling = productDTO.USDSelling;
            prd.ProductTypeId = GeneralFunctions.ProductTypeEnum(prd.Type);
            prd.customizeVdsServer = productDTO;
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void PHostingEkle(PRD_HostingDTO hostingDTO)
        {
            prd = new Product
                      {
                          ID = hostingDTO.ProductID,
                          Name = string.Format("{0} {1}", hostingDTO.Name,
                                            hostingDTO.OperatingSystem == "1" ? "(Windows)" : "(Linux)"),
                          DollarPrice = hostingDTO.Price,
                          YearPrice = hostingDTO.Price,
                          YTLPrice = hostingDTO.Price * hostingDTO.USDSelling,
                          Quantity =
                              hostingDTO.QuantityType.ToLower() == "ay" ? (hostingDTO.Quantity / 12) : hostingDTO.Quantity,
                          QuantityType = "Yýl",
                          Type = GeneralFunctions.productType(SepeteAtilanProductType.PHosting),
                          Tax = 18,
                          UsdSelling = hostingDTO.USDSelling,
                          ProductTypeId = (int)SepeteAtilanProductType.PHosting,
                          phosting = hostingDTO,
                          OldPrice = hostingDTO.OldPrice,
                          IsPromotion = hostingDTO.IsPromotion

                      };
            if (CampaignStartDate <= DateTime.Now && CampaignEndDate >= DateTime.Now)
            {
                prd.DollarPrice = (hostingDTO.Price * DiscountPercent);
                prd.YTLPrice = (hostingDTO.Price * DiscountPercent) * hostingDTO.USDSelling;
            }
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void PHostingEkleIndirim(PRD_HostingDTO hostingDTO, int indirim)
        {
            var multiplier = (100.0 - indirim) / 100.0;
            var price = new DealerSafe.ServiceClient.CommonAPI().GetHostingPrice(hostingDTO.ProductID).PriceList * multiplier;

            prd = new Product
            {
                ID = hostingDTO.ProductID,
                Name = string.Format("{0} {1}", hostingDTO.Name,
                                  hostingDTO.OperatingSystem == "1" ? "(Windows)" : "(Linux)"),
                DollarPrice = price,
                YearPrice = price,
                YTLPrice = price * hostingDTO.USDSelling,
                Quantity =
                    hostingDTO.QuantityType.ToLower() == "ay" ? (hostingDTO.Quantity / 12) : hostingDTO.Quantity,
                QuantityType = "Yýl",
                Type = GeneralFunctions.productType(SepeteAtilanProductType.PHosting),
                Tax = 18,
                UsdSelling = hostingDTO.USDSelling,
                ProductTypeId = (int)SepeteAtilanProductType.PHosting,
                phosting = hostingDTO,
                OldPrice = hostingDTO.OldPrice,
                IsPromotion = hostingDTO.IsPromotion

            };
            /*if (CampaignStartDate <= DateTime.Now && CampaignEndDate >= DateTime.Now)
            {
                prd.DollarPrice = (hostingDTO.Price * DiscountPercent);
                prd.YTLPrice = (hostingDTO.Price * DiscountPercent) * hostingDTO.USDSelling;
            }*/
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void HostingUzatmaEkle(PRD_HostingDTO hostingDTO)
        {
            prd = new Product
            {
                ID = hostingDTO.ProductID,
                Name = hostingDTO.Name,
                DollarPrice = hostingDTO.Price,
                YTLPrice = hostingDTO.Price * hostingDTO.USDSelling,
                YearPrice = hostingDTO.Price,
                Quantity =
                    hostingDTO.QuantityType.ToLower() == "ay" ? (hostingDTO.Quantity / 12) : hostingDTO.Quantity,
                QuantityType = "Yýl",
                Type = GeneralFunctions.productType(SepeteAtilanProductType.Hosting_Uzatma),
                Tax = 18,
                UsdSelling = hostingDTO.USDSelling,
                ProductTypeId = (int)SepeteAtilanProductType.Hosting_Uzatma,
                HostingID_Lenghten = hostingDTO.Id,
                TargetID = hostingDTO.Id,
                phosting = hostingDTO,
                OldPrice = hostingDTO.OldPrice
            };
            if (CampaignStartDate <= DateTime.Now && CampaignEndDate >= DateTime.Now)
            {
                prd.DollarPrice = (hostingDTO.Price * DiscountPercent);
                prd.YTLPrice = (hostingDTO.Price * DiscountPercent) * hostingDTO.USDSelling;
            }

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void PHostingUzatmaEkle(PRD_HostingDTO hostingDTO)
        {
            prd = new Product
                      {
                          ID = hostingDTO.ProductID,
                          Name = hostingDTO.Name,
                          DollarPrice = hostingDTO.Price,
                          YTLPrice = hostingDTO.Price * hostingDTO.USDSelling,
                          YearPrice = hostingDTO.Price,
                          Quantity =
                              hostingDTO.QuantityType.ToLower() == "ay" ? (hostingDTO.Quantity / 12) : hostingDTO.Quantity,
                          QuantityType = "Yýl",
                          Type = GeneralFunctions.productType(SepeteAtilanProductType.PHosting_Uzatma),
                          Tax = 18,
                          UsdSelling = hostingDTO.USDSelling,
                          ProductTypeId = (int)SepeteAtilanProductType.PHosting_Uzatma,
                          HostingID_Lenghten = hostingDTO.Id,
                          TargetID = hostingDTO.Id,
                          phosting = hostingDTO,
                          OldPrice = hostingDTO.OldPrice
                      };
            

            var h = new HostingAPI();
            var hosting = h.GetMemberProduct(prd.phosting.Id);

            if (CampaignStartDate <= DateTime.Now && CampaignEndDate >= DateTime.Now)
            {
                prd.DollarPrice = new CommonAPI().GetHostingPrice(prd.ID).PriceReal * prd.Quantity;
                prd.YTLPrice = (prd.DollarPrice) * (prd.phosting.USDSelling);
                prd.YearPrice = prd.DollarPrice;
            }

            if ((DateTime.Now.Subtract(hosting.ProductEndDate)).TotalDays >= 0)
            {
                var price = ((DateTime.Now.Subtract(hosting.ProductEndDate)).TotalDays * prd.YearPrice) / 365;
                prd.DollarPrice = price + prd.DollarPrice;
                prd.YTLPrice = (prd.DollarPrice) * prd.phosting.USDSelling;
            }                           

            
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void PHostingUpgradeEkle(PRD_HostingDTO hostingDTO)
        {
            prd = new Product
            {
                ID = hostingDTO.Id,
                Name = hostingDTO.Name,
                DollarPrice = hostingDTO.Price,
                YTLPrice = hostingDTO.Price * hostingDTO.USDSelling,
                YearPrice = hostingDTO.Price,
                Quantity = hostingDTO.QuantityType.ToLower() == "ay" ? (hostingDTO.Quantity / 12) : hostingDTO.Quantity,
                QuantityType = "Yýl",
                Type = GeneralFunctions.productType(SepeteAtilanProductType.PHosting_Upgrade),
                Tax = 18,
                UsdSelling = hostingDTO.USDSelling,
                ProductTypeId = (int)SepeteAtilanProductType.PHosting_Upgrade,
                HostingID_Lenghten = hostingDTO.ProductID,
                TargetID = hostingDTO.Id,
                phosting = hostingDTO,
                OldPrice = hostingDTO.OldPrice,
                UpgradeQuantity = hostingDTO.UpgradeQuantity
            };

            //if (CampaignStartDate <= DateTime.Now && CampaignEndDate >= DateTime.Now)
            //{
            //    prd.DollarPrice = (hostingDTO.Price * DiscountPercent);
            //    prd.YTLPrice = (hostingDTO.Price * DiscountPercent) * hostingDTO.USDSelling;
            //}

            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void PHostingBackupEkle(PRD_HostingDTO hostingDTO)
        {
            prd = new Product
            {
                ID = hostingDTO.ProductID,
                Name = hostingDTO.Name,
                DollarPrice = hostingDTO.Price,
                YTLPrice = hostingDTO.Price * hostingDTO.USDSelling,
                Quantity = 1,
                QuantityType = "Adet",
                Type = GeneralFunctions.productType(SepeteAtilanProductType.PHosting_Backup),
                Tax = 18,
                UsdSelling = hostingDTO.USDSelling,
                ProductTypeId = (int)SepeteAtilanProductType.PHosting_Backup,
                HostingID_Lenghten = hostingDTO.Id,
                TargetID = 0,
                phosting = hostingDTO,
                OldPrice = hostingDTO.OldPrice
            };
            product.Add(prd);
            setPrices(count);
            count++;
            setTotalPrice();
        }

        public void uruncikar(int index)
        {
            try
            {
                Product p = (Product)product[index];
                product.RemoveAt(index);
                DeleteBasket(p, this);
                count--;
                setTotalPrice();
            }
            catch
            {
                setTotalPrice();
            }
        }

        public void urunDomainCikar(string domainName)
        {
            try
            {
                var Pp = product.Cast<Product>().Where(x => x.Name == domainName).ToList()[0];

                var say = product.IndexOf(Pp);
                product.RemoveAt(say);
                DeleteBasket(Pp, this);
                count--;
                setTotalPrice();
            }
            catch
            {
                setTotalPrice();
            }


        }



        public void setPrices(int index)
        {
            prd = (Product)product[index];
            prd.kdvliDollarPrice = prd.DollarPrice * (prd.Tax + 100.0) / 100.0;
            prd.kdvliYTLPrice = prd.kdvliDollarPrice * prd.UsdSelling;
            prd.kdvliDollarPrice = Math.Round((prd.kdvliDollarPrice) * 100) / 100;
            prd.kdvliYTLPrice = Math.Round((prd.kdvliYTLPrice) * 100) / 100;
        }
        public void setTotalPrice()
        {
            Product prd;
            totalDollarPrice = 0.0;
            totalYTLPrice = 0.0;
            komisyonsuzTotalDollarPrice = 0.0;
            komisyonsuzTotalYTLPrice = 0.0;
            for (int i = 0; i < count; i++)
            {
                prd = (Product)product[i];
                totalDollarPrice += prd.kdvliDollarPrice;
                totalYTLPrice += prd.kdvliYTLPrice;
            }
            for (int i = 0; i < count; i++)
            {
                prd = (Product)product[i];
                komisyonsuzTotalDollarPrice += prd.DollarPrice;
                komisyonsuzTotalYTLPrice += prd.YTLPrice;
            }
            SaveBasket(this);
        }
        public void setTotalPriceForStaff()
        {
            Product prd;
            totalDollarPrice = 0.0;
            totalYTLPrice = 0.0;
            komisyonsuzTotalDollarPrice = 0.0;
            komisyonsuzTotalYTLPrice = 0.0;
            for (int i = 0; i < count; i++)
            {
                prd = (Product)product[i];
                totalDollarPrice += prd.kdvliDollarPrice;
                totalYTLPrice += prd.kdvliYTLPrice;
            }
            for (int i = 0; i < count; i++)
            {
                prd = (Product)product[i];
                komisyonsuzTotalDollarPrice += prd.DollarPrice;
                komisyonsuzTotalYTLPrice += prd.YTLPrice;
            }
        }
        public double getYTLPrice(double usdSelling, double dollarPrice)
        {
            double ytlPrice;
            ytlPrice = dollarPrice * usdSelling;
            ytlPrice = Math.Round(ytlPrice * 100) / 100;
            return ytlPrice;
        }

        public double GetKdvMatrahi(ExchangeType eType)
        {
            double _retval = 0;
            Product prd;

            for (int i = 0; i < count; i++)
            {
                prd = (Product)product[i];
                if (prd.Name != GeneralFunctions.productType(SepeteAtilanProductType.Kargo_Bedeli) && prd.Name != GeneralFunctions.productType(SepeteAtilanProductType.Hizmet_Bedeli))
                    _retval += eType == ExchangeType.Dolar ? prd.DollarPrice : prd.YTLPrice;
            }

            return _retval;
        }

        public double GetKdvToplam(ExchangeType eType, int taxRate)
        {
            double _retval = 0;
            Product prd;

            for (int i = 0; i < count; i++)
            {
                prd = (Product)product[i];
                _retval += (eType == ExchangeType.Dolar ? prd.DollarPrice : prd.YTLPrice) * (taxRate) / 100.0;
            }

            return _retval;
        }

        public bool HostingKampanyaUygula()
        {
            bool _retval = false;

            for (int i = 0; i < count; i++)
            {
                if (((Product)product[i]).ID == 174 || ((Product)product[i]).ID == 175 || ((Product)product[i]).ID == 176)
                {
                    _retval = true;
                    break;
                }
            }

            return _retval;
        }

        public static DealerSafe.DTO.Orders.BasketDetail ToDTO(Sepet FromBasket)
        {
            DealerSafe.DTO.Orders.BasketDetail basket = new DealerSafe.DTO.Orders.BasketDetail();

            basket.totalDollarPrice = FromBasket.totalDollarPrice;
            basket.totalYTLPrice = FromBasket.totalYTLPrice;
            basket.komisyonsuzTotalDollarPrice = FromBasket.komisyonsuzTotalDollarPrice;
            basket.komisyonsuzTotalYTLPrice = FromBasket.komisyonsuzTotalYTLPrice;
            basket.orderID = FromBasket.orderID;
            basket.OrderDetailID = FromBasket.OrderDetailID;
            basket.memberID = FromBasket.memberID;
            basket.count = FromBasket.count;
            basket.direkOdeme = FromBasket.direkOdeme;
            basket.paymentType = FromBasket.paymentType;
            basket.KrediKartNo = FromBasket.KrediKartNo;
            basket.invoiceCompanyId = FromBasket.invoiceCompanyId;
            basket.invoiceCargoAddressId = FromBasket.invoiceCargoAddressId;
            basket.invoiceAddressId = FromBasket.invoiceAddressId;
            basket.invoiceSend = FromBasket.invoiceSend;
            basket.cargoId = FromBasket.cargoId;
            basket.CampaignStartDate = FromBasket.CampaignStartDate;
            basket.CampaignEndDate = FromBasket.CampaignEndDate;
            basket.DiscountPercent = FromBasket.DiscountPercent;

            basket.product = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ProductDetail>();

            foreach (var item in FromBasket.product)
            {
                Product prd = (Product)item;
                DealerSafe.DTO.Orders.ProductDetail UrunDetay = new DealerSafe.DTO.Orders.ProductDetail();

                UrunDetay.ID = prd.ID;
                UrunDetay.Name = prd.Name;
                UrunDetay.MonthPrice = prd.MonthPrice;
                UrunDetay.DollarPrice = prd.DollarPrice;
                UrunDetay.YearPrice = prd.YearPrice;
                UrunDetay.kdvliDollarPrice = prd.kdvliDollarPrice;
                UrunDetay.YTLPrice = prd.YTLPrice;
                UrunDetay.kdvliYTLPrice = prd.kdvliYTLPrice;
                UrunDetay.Quantity = prd.Quantity;
                UrunDetay.QuantityType = prd.QuantityType;
                UrunDetay.Type = prd.Type;
                UrunDetay.RegistryCompany = prd.RegistryCompany;
                UrunDetay.Tax = prd.Tax;
                UrunDetay.UsdSelling = prd.UsdSelling;
                UrunDetay.islemiYapildi = prd.islemiYapildi;
                UrunDetay.InCampaign = prd.InCampaign;
                UrunDetay.CampaignPrice = prd.CampaignPrice;
                UrunDetay.CampaignPeriod = prd.CampaignPeriod;
                UrunDetay.IsExpiredHosting = prd.IsExpiredHosting;
                UrunDetay.HostingID_Lenghten = prd.HostingID_Lenghten;
                UrunDetay.QueueID = prd.QueueID;
                UrunDetay.TargetID = prd.TargetID;
                UrunDetay.OrderDetailID = prd.OrderDetailID;
                UrunDetay.UzantiID = prd.UzantiID;
                UrunDetay.ProductID = prd.ProductID;
                UrunDetay.referredPrdID = prd.referredPrdID;
                UrunDetay.ServerID = prd.ServerID;
                UrunDetay.IsPromotion = prd.IsPromotion;
                UrunDetay.DomainPriceForCamp = prd.DomainPriceForCamp;
                UrunDetay.AuthCode = prd.AuthCode;
                UrunDetay.MarkClassIDs = new System.Collections.Generic.List<object>();
                UrunDetay.enmRegisterStatus = prd.enmRegisterStatus;
                UrunDetay.ReferenceId = prd.ReferenceId;
                foreach (var itemmcID in prd.MarkClassIDs)
                {
                    UrunDetay.MarkClassIDs.Add(itemmcID);
                }
                UrunDetay.MarkName = prd.MarkName;
                UrunDetay.ProductTypeId = prd.ProductTypeId;
                UrunDetay.ParentBrandId = prd.ParentBrandId;
                UrunDetay.domContComp = (DealerSafe.DTO.Orders.ProductDetail.ContactCompatibility)((int)prd.domContComp);
                UrunDetay.EkstraUzatma = prd.EkstraUzatma;
                UrunDetay.relatedProducts = prd.relatedProducts;
                UrunDetay.ColourType = (DealerSafe.DTO.Orders.ProductDetail.IndustrialDesignColourType)((int)prd.ColourType);
                UrunDetay.VisualCount = prd.VisualCount;
                UrunDetay.Promotion = prd.Promotion;
                UrunDetay.OldPrice = prd.OldPrice;
                UrunDetay.UpgradeQuantity = prd.UpgradeQuantity;
                UrunDetay.PciDssDomanName = prd.PciDssDomanName;
                UrunDetay.SunucuEklenti = prd.SunucuEklenti; // sunucu için eklendi 7.4.2014
                UrunDetay.PatentAndBenefitModel = new DealerSafe.DTO.Orders.ProductDetail.PatentAndBenefitModelDetail();
                if (prd.PatentAndBenefitModel != null)
                {
                    UrunDetay.PatentAndBenefitModel.NameOfInvention = prd.PatentAndBenefitModel.NameOfInvention;
                    UrunDetay.PatentAndBenefitModel.Sector = prd.PatentAndBenefitModel.Sector;
                    UrunDetay.PatentAndBenefitModel.UsingArea = prd.PatentAndBenefitModel.UsingArea;
                    UrunDetay.PatentAndBenefitModel.ProtectionArea = prd.PatentAndBenefitModel.ProtectionArea;
                    UrunDetay.PatentAndBenefitModel.ProcessType = prd.PatentAndBenefitModel.ProcessType;
                }

                UrunDetay.customizeVdsServer = new DealerSafe.DTO.Orders.ProductDetail.ProductDTODetail();
                if (prd.customizeVdsServer != null)
                {
                    UrunDetay.customizeVdsServer.PriceTotal = prd.customizeVdsServer.PriceTotal;
                    UrunDetay.customizeVdsServer.PriceTotalUnit = prd.customizeVdsServer.PriceTotalUnit;
                    UrunDetay.customizeVdsServer.GetUSDString = prd.customizeVdsServer.GetUSDString();
                    UrunDetay.customizeVdsServer.PriceTotalTr = prd.customizeVdsServer.PriceTotalTr;
                    UrunDetay.customizeVdsServer.PriceTotalTrUnit = prd.customizeVdsServer.PriceTotalTrUnit;
                    UrunDetay.customizeVdsServer.GetTrString = prd.customizeVdsServer.GetTrString();
                    UrunDetay.customizeVdsServer.Quantity = prd.customizeVdsServer.Quantity;
                    UrunDetay.customizeVdsServer.QuantityType = prd.customizeVdsServer.QuantityType;
                    UrunDetay.customizeVdsServer.USDSelling = prd.customizeVdsServer.USDSelling;
                    UrunDetay.customizeVdsServer.ExtraConfigurationDescription = prd.customizeVdsServer.ExtraConfigurationDescription;
                    UrunDetay.customizeVdsServer.Group = (DealerSafe.DTO.Orders.ProductDetail.GROUPSDetails)((int)prd.customizeVdsServer.Group);
                    UrunDetay.customizeVdsServer.ProductSummary = prd.customizeVdsServer.ProductSummary;
                    UrunDetay.customizeVdsServer.IndirimTutari = prd.customizeVdsServer.IndirimTutari;
                    UrunDetay.customizeVdsServer.Yuzde = prd.customizeVdsServer.Yuzde;
                    UrunDetay.customizeVdsServer.Tutar = prd.customizeVdsServer.Tutar;
                    UrunDetay.customizeVdsServer.MemberId = prd.customizeVdsServer.MemberId;

                    UrunDetay.customizeVdsServer.ProductItems = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ProductDetail.ProductItemDetail>();
                    if (prd.customizeVdsServer.ProductItems != null && prd.customizeVdsServer.ProductItems.Count > 0)
                    {
                        foreach (var ProductItemDetail in prd.customizeVdsServer.ProductItems)
                        {
                            DealerSafe.DTO.Orders.ProductDetail.ProductItemDetail myProductItemDetay = new DealerSafe.DTO.Orders.ProductDetail.ProductItemDetail();

                            myProductItemDetay.Id = ProductItemDetail.Id;
                            myProductItemDetay.GroupId = ProductItemDetail.GroupId;
                            myProductItemDetay.Name = ProductItemDetail.Name;
                            myProductItemDetay.OrderIndex = ProductItemDetail.OrderIndex;
                            myProductItemDetay.Price = ProductItemDetail.Price;
                            myProductItemDetay.PriceUnit = ProductItemDetail.PriceUnit;
                            myProductItemDetay.PriceUnitStr = ProductItemDetail.PriceUnitStr;
                            myProductItemDetay.GetUSDString = ProductItemDetail.GetUSDString();
                            myProductItemDetay.PriceTr = ProductItemDetail.PriceTr;
                            myProductItemDetay.PriceTrUnit = ProductItemDetail.PriceTrUnit;
                            myProductItemDetay.PriceTrUnitsTR = ProductItemDetail.PriceTrUnitsTR;
                            myProductItemDetay.GetTrString = ProductItemDetail.GetTrString();
                            myProductItemDetay.OperatingSystem = ProductItemDetail.OperatingSystem;
                            myProductItemDetay.IsConfiguratiion = ProductItemDetail.IsConfiguratiion;
                            myProductItemDetay.Prop = (DealerSafe.DTO.Orders.ProductDetail.PROPSDetails)((int)ProductItemDetail.Prop);
                            myProductItemDetay.PropEnmVariable = ProductItemDetail.PropEnmVariable;
                            myProductItemDetay.ExtraProp = ProductItemDetail.ExtraProp;
                            myProductItemDetay.EnmUnit = (DealerSafe.DTO.Orders.ProductDetail.UNITSDetails)((int)ProductItemDetail.EnmUnit);
                            myProductItemDetay.PriceTotalStr = ProductItemDetail.PriceTotalStr;
                            myProductItemDetay.PriceTotal = ProductItemDetail.PriceTotal;
                            myProductItemDetay.IndirimTutari = ProductItemDetail.IndirimTutari;
                            myProductItemDetay.Yuzde = ProductItemDetail.Yuzde;
                            myProductItemDetay.Tutar = ProductItemDetail.Tutar;
                            myProductItemDetay.tempPrice = ProductItemDetail.tempPrice;

                            UrunDetay.customizeVdsServer.ProductItems.Add(myProductItemDetay);
                        }
                    }
                }

                UrunDetay.phosting = new DealerSafe.DTO.Orders.ProductDetail.PRD_HostingDTODetail();
                if (prd.phosting != null)
                {
                    UrunDetay.phosting.Name = prd.phosting.Name;
                    UrunDetay.phosting.Id = prd.phosting.Id;
                    UrunDetay.phosting.OperatingSystem = prd.phosting.OperatingSystem;
                    UrunDetay.phosting.EnmGroup = (DealerSafe.DTO.Orders.ProductDetail.GROUPSDetails)((int)prd.phosting.EnmGroup);
                    UrunDetay.phosting.OldPrice = prd.phosting.OldPrice;
                    UrunDetay.phosting.TempPrice = prd.phosting.TempPrice;
                    UrunDetay.phosting.Price = prd.phosting.Price;
                    UrunDetay.phosting.PriceUnit = prd.phosting.PriceUnit;
                    UrunDetay.phosting.CampaignPrice = prd.phosting.CampaignPrice;
                    UrunDetay.phosting.CampaingPriceUnit = prd.phosting.CampaingPriceUnit;
                    UrunDetay.phosting.Quantity = prd.phosting.Quantity;
                    UrunDetay.phosting.QuantityType = prd.phosting.QuantityType;
                    UrunDetay.phosting.USDSelling = prd.phosting.USDSelling;
                    UrunDetay.phosting.ProductCode = prd.phosting.ProductCode;
                    UrunDetay.phosting.ProductID = prd.phosting.ProductID;
                    UrunDetay.phosting.UpgradeQuantity = prd.phosting.UpgradeQuantity;
                    UrunDetay.phosting.Key = prd.phosting.Key;
                    UrunDetay.phosting.Reseller = prd.phosting.Reseller;

                    UrunDetay.phosting.HostingItems = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ProductDetail.PRD_HostingItemsDTODetail>();
                    if (prd.phosting.HostingItems != null && prd.phosting.HostingItems.Count > 0)
                    {
                        foreach (var HostingItem in prd.phosting.HostingItems)
                        {
                            DealerSafe.DTO.Orders.ProductDetail.PRD_HostingItemsDTODetail myHosingItem = new DealerSafe.DTO.Orders.ProductDetail.PRD_HostingItemsDTODetail();

                            myHosingItem.Id = HostingItem.Id;
                            myHosingItem.PropName = HostingItem.PropName;
                            myHosingItem.Name = HostingItem.Name;
                            myHosingItem.Value = HostingItem.Value;
                            myHosingItem.UsedValue = HostingItem.UsedValue;
                            myHosingItem.UsedValueStr = HostingItem.UsedValueStr;
                            myHosingItem.EnmProp = (DealerSafe.DTO.Orders.ProductDetail.PROPSDetails)((int)HostingItem.EnmProp);
                            myHosingItem.DetailId = HostingItem.DetailId;

                            UrunDetay.phosting.HostingItems.Add(myHosingItem);
                        }
                    }
                }

                basket.product.Add(UrunDetay);
            }

            return basket;
        }

        public static Sepet FromDTO(DealerSafe.DTO.Orders.BasketDetail FromBasket)
        {
            Sepet basket = new Sepet();

            basket.totalDollarPrice = FromBasket.totalDollarPrice;
            basket.totalYTLPrice = FromBasket.totalYTLPrice;
            basket.komisyonsuzTotalDollarPrice = FromBasket.komisyonsuzTotalDollarPrice;
            basket.komisyonsuzTotalYTLPrice = FromBasket.komisyonsuzTotalYTLPrice;
            basket.orderID = FromBasket.orderID;
            basket.OrderDetailID = FromBasket.OrderDetailID;
            basket.memberID = FromBasket.memberID;
            basket.count = FromBasket.count;
            basket.direkOdeme = FromBasket.direkOdeme;
            basket.paymentType = FromBasket.paymentType;
            basket.KrediKartNo = FromBasket.KrediKartNo;
            basket.invoiceCompanyId = FromBasket.invoiceCompanyId;
            basket.invoiceCargoAddressId = FromBasket.invoiceCargoAddressId;
            basket.invoiceAddressId = FromBasket.invoiceAddressId;
            basket.invoiceSend = FromBasket.invoiceSend;
            basket.cargoId = FromBasket.cargoId;
            basket.CampaignStartDate = FromBasket.CampaignStartDate;
            basket.CampaignEndDate = FromBasket.CampaignEndDate;
            basket.DiscountPercent = FromBasket.DiscountPercent;
            basket.memberSessionKey = HttpContext.Current.Session.SessionID;

            basket.product = new ArrayList();

            foreach (var item in FromBasket.product)
            {
                DealerSafe.DTO.Orders.ProductDetail prd = (DealerSafe.DTO.Orders.ProductDetail)item;
                Product UrunDetay = new Product();

                UrunDetay.ID = prd.ID;
                UrunDetay.Name = prd.Name;
                UrunDetay.MonthPrice = prd.MonthPrice;
                UrunDetay.DollarPrice = prd.DollarPrice;
                UrunDetay.YearPrice = prd.YearPrice;
                UrunDetay.kdvliDollarPrice = prd.kdvliDollarPrice;
                UrunDetay.YTLPrice = prd.YTLPrice;
                UrunDetay.kdvliYTLPrice = prd.kdvliYTLPrice;
                UrunDetay.Quantity = prd.Quantity;
                UrunDetay.QuantityType = prd.QuantityType;
                UrunDetay.Type = prd.Type;
                UrunDetay.RegistryCompany = prd.RegistryCompany;
                UrunDetay.Tax = prd.Tax;
                UrunDetay.UsdSelling = prd.UsdSelling;
                UrunDetay.islemiYapildi = prd.islemiYapildi;
                UrunDetay.InCampaign = prd.InCampaign;
                UrunDetay.CampaignPrice = prd.CampaignPrice;
                UrunDetay.CampaignPeriod = prd.CampaignPeriod;
                UrunDetay.IsExpiredHosting = prd.IsExpiredHosting;
                UrunDetay.HostingID_Lenghten = prd.HostingID_Lenghten;
                UrunDetay.QueueID = prd.QueueID;
                UrunDetay.TargetID = prd.TargetID;
                UrunDetay.OrderDetailID = prd.OrderDetailID;
                UrunDetay.UzantiID = prd.UzantiID;
                UrunDetay.ProductID = prd.ProductID;
                UrunDetay.referredPrdID = prd.referredPrdID;
                UrunDetay.ServerID = prd.ServerID;
                UrunDetay.IsPromotion = prd.IsPromotion;
                UrunDetay.DomainPriceForCamp = prd.DomainPriceForCamp;
                UrunDetay.AuthCode = prd.AuthCode;
                UrunDetay.MarkClassIDs = new ArrayList();
                foreach (var itemmcID in prd.MarkClassIDs)
                {
                    UrunDetay.MarkClassIDs.Add(itemmcID);
                }
                UrunDetay.MarkName = prd.MarkName;
                UrunDetay.ParentBrandId = prd.ParentBrandId;
                UrunDetay.ProductTypeId = prd.ProductTypeId;
                UrunDetay.domContComp = (enmContactCompatibility)((int)prd.domContComp);
                UrunDetay.EkstraUzatma = prd.EkstraUzatma;
                UrunDetay.relatedProducts = prd.relatedProducts;
                UrunDetay.ColourType = (enmIndustrialDesignColourType)((int)prd.ColourType);
                UrunDetay.VisualCount = prd.VisualCount;
                UrunDetay.Promotion = prd.Promotion;
                UrunDetay.OldPrice = prd.OldPrice;
                UrunDetay.UpgradeQuantity = prd.UpgradeQuantity;
                UrunDetay.PciDssDomanName = prd.PciDssDomanName;
                UrunDetay.SunucuEklenti = prd.SunucuEklenti; // 7.4.2014 sunucu için eklendi
                UrunDetay.PatentAndBenefitModel = new PatentAndBenefitModel();
                UrunDetay.enmRegisterStatus = prd.enmRegisterStatus;
                UrunDetay.ReferenceId = prd.ReferenceId;

                if (prd.PatentAndBenefitModel != null)
                {
                    UrunDetay.PatentAndBenefitModel.NameOfInvention = prd.PatentAndBenefitModel.NameOfInvention;
                    UrunDetay.PatentAndBenefitModel.Sector = prd.PatentAndBenefitModel.Sector;
                    UrunDetay.PatentAndBenefitModel.UsingArea = prd.PatentAndBenefitModel.UsingArea;
                    UrunDetay.PatentAndBenefitModel.ProtectionArea = prd.PatentAndBenefitModel.ProtectionArea;
                    UrunDetay.PatentAndBenefitModel.ProcessType = prd.PatentAndBenefitModel.ProcessType;
                }

                UrunDetay.customizeVdsServer = new ProductDTO();
                if (prd.customizeVdsServer != null)
                {
                    UrunDetay.customizeVdsServer.Quantity = prd.customizeVdsServer.Quantity;
                    UrunDetay.customizeVdsServer.QuantityType = prd.customizeVdsServer.QuantityType;
                    UrunDetay.customizeVdsServer.ExtraConfigurationDescription = prd.customizeVdsServer.ExtraConfigurationDescription;
                    UrunDetay.customizeVdsServer.Group = (EnmGROUPS)((int)prd.customizeVdsServer.Group);
                    UrunDetay.customizeVdsServer.ProductSummary = prd.customizeVdsServer.ProductSummary;
                    UrunDetay.customizeVdsServer.IndirimTutari = prd.customizeVdsServer.IndirimTutari;
                    UrunDetay.customizeVdsServer.Yuzde = prd.customizeVdsServer.Yuzde;
                    UrunDetay.customizeVdsServer.Tutar = prd.customizeVdsServer.Tutar;
                    UrunDetay.customizeVdsServer.MemberId = prd.customizeVdsServer.MemberId;
                    UrunDetay.customizeVdsServer.USDSelling = prd.customizeVdsServer.USDSelling;
                    UrunDetay.customizeVdsServer.ProductItems = new System.Collections.Generic.List<ProductItem>();
                    if (prd.customizeVdsServer.ProductItems != null && prd.customizeVdsServer.ProductItems.Count > 0)
                    {
                        foreach (var ProductItemDetail in prd.customizeVdsServer.ProductItems)
                        {
                            ProductItem myProductItemDetay = new ProductItem();

                            myProductItemDetay.Id = ProductItemDetail.Id;
                            myProductItemDetay.GroupId = ProductItemDetail.GroupId;
                            myProductItemDetay.Name = ProductItemDetail.Name;
                            myProductItemDetay.OrderIndex = ProductItemDetail.OrderIndex;
                            myProductItemDetay.Price = ProductItemDetail.Price;
                            myProductItemDetay.PriceUnit = ProductItemDetail.PriceUnit;
                            myProductItemDetay.OperatingSystem = ProductItemDetail.OperatingSystem;
                            myProductItemDetay.IsConfiguratiion = ProductItemDetail.IsConfiguratiion;
                            myProductItemDetay.PropEnmVariable = ProductItemDetail.PropEnmVariable;
                            myProductItemDetay.ExtraProp = ProductItemDetail.ExtraProp;
                            myProductItemDetay.EnmUnit = (EnmUNITS)((int)ProductItemDetail.EnmUnit);
                            myProductItemDetay.PriceTotalStr = ProductItemDetail.PriceTotalStr;
                            myProductItemDetay.PriceTotal = ProductItemDetail.PriceTotal;
                            myProductItemDetay.IndirimTutari = ProductItemDetail.IndirimTutari;
                            myProductItemDetay.Yuzde = ProductItemDetail.Yuzde;
                            myProductItemDetay.Tutar = ProductItemDetail.Tutar;
                            myProductItemDetay.tempPrice = ProductItemDetail.tempPrice;
                            myProductItemDetay.USDSelling = prd.UsdSelling;
                            UrunDetay.customizeVdsServer.ProductItems.Add(myProductItemDetay);
                        }
                    }
                }

                UrunDetay.phosting = new PRD_HostingDTO();
                if (prd.phosting != null)
                {
                    UrunDetay.phosting.Name = prd.phosting.Name;
                    UrunDetay.phosting.Id = prd.phosting.Id;
                    UrunDetay.phosting.OperatingSystem = prd.phosting.OperatingSystem;
                    UrunDetay.phosting.EnmGroup = (EnmGROUPS)((int)prd.phosting.EnmGroup);
                    UrunDetay.phosting.OldPrice = prd.phosting.OldPrice;
                    UrunDetay.phosting.TempPrice = prd.phosting.TempPrice;
                    UrunDetay.phosting.Price = prd.phosting.Price;
                    UrunDetay.phosting.PriceUnit = prd.phosting.PriceUnit;
                    UrunDetay.phosting.CampaignPrice = prd.phosting.CampaignPrice;
                    UrunDetay.phosting.CampaingPriceUnit = prd.phosting.CampaingPriceUnit;
                    UrunDetay.phosting.Quantity = prd.phosting.Quantity;
                    UrunDetay.phosting.ProductCode = prd.phosting.ProductCode;
                    UrunDetay.phosting.ProductID = prd.phosting.ProductID;
                    UrunDetay.phosting.UpgradeQuantity = prd.phosting.UpgradeQuantity;
                    UrunDetay.phosting.Key = prd.phosting.Key;
                    UrunDetay.phosting.Reseller = prd.phosting.Reseller;
                    UrunDetay.phosting.USDSelling = prd.phosting.USDSelling;
                    UrunDetay.phosting.HostingItems = new System.Collections.Generic.List<PRD_HostingItemsDTO>();
                    if (prd.phosting.HostingItems != null && prd.phosting.HostingItems.Count > 0)
                    {
                        foreach (var HostingItem in prd.phosting.HostingItems)
                        {
                            PRD_HostingItemsDTO myHosingItem = new PRD_HostingItemsDTO();

                            myHosingItem.Id = HostingItem.Id;
                            myHosingItem.PropName = HostingItem.PropName;
                            myHosingItem.Name = HostingItem.Name;
                            myHosingItem.Value = HostingItem.Value;
                            myHosingItem.UsedValue = HostingItem.UsedValue;
                            myHosingItem.UsedValueStr = HostingItem.UsedValueStr;
                            myHosingItem.EnmProp = (EnmPROPS)((int)HostingItem.EnmProp);
                            myHosingItem.DetailId = HostingItem.DetailId;

                            UrunDetay.phosting.HostingItems.Add(myHosingItem);
                        }
                    }
                }

                basket.product.Add(UrunDetay);
            }

            return basket;
        }
        public static string StringJoin(ArrayList liste, string JoinChar)
        {
            string sonuc = "";
            foreach (var item in liste)
            {
                if (sonuc == "")
                    sonuc = item.ToString();
                else
                    sonuc += "," + item.ToString();
            }
            return sonuc;
        }
        public static void SaveBasket(Sepet basket)
        {
            DealerSafe.DTO.Orders.ReqUpdateMemberBasket RequestBasket = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket();
            RequestBasket.BasketId = basket.BasketId;
            RequestBasket.memberID = basket.memberID;
            RequestBasket.memberSessionKey = basket.memberSessionKey;
            RequestBasket.orderID = basket.orderID;
            RequestBasket.TotalDolarPrice = (decimal)basket.totalDollarPrice;
            RequestBasket.TotalYTLPrice = (decimal)basket.totalYTLPrice;
            RequestBasket.KomisyonsuzTotalDollarPrice = (decimal)basket.komisyonsuzTotalDollarPrice;
            RequestBasket.KomisyonsuzTotalYTLPrice = (decimal)basket.komisyonsuzTotalYTLPrice;
            RequestBasket.OrderDetailID = basket.OrderDetailID;
            RequestBasket.count = basket.count;
            RequestBasket.direkOdeme = basket.direkOdeme;
            RequestBasket.paymentType = basket.paymentType;
            RequestBasket.KrediKartNo = basket.KrediKartNo;
            RequestBasket.invoiceCompanyId = basket.invoiceCompanyId;
            RequestBasket.invoiceCargoAddressId = basket.invoiceCargoAddressId;
            RequestBasket.invoiceAddressId = basket.invoiceAddressId;
            RequestBasket.invoiceSend = basket.invoiceSend;
            RequestBasket.cargoId = basket.cargoId;
            RequestBasket.CampaignStartDate = basket.CampaignStartDate;
            RequestBasket.CampaignEndDate = basket.CampaignEndDate;
            RequestBasket.DiscountPercent = (decimal)basket.DiscountPercent;

            RequestBasket.product = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail>();





            foreach (Product item in basket.product)
            {
                DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail myMemberBasketDetail = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail()
                {
                    BasketDetailId = item.BasketDetailId,
                    BasketId = item.BasketId,
                    MemberId = basket.memberID,
                    MemberSessionKey = basket.memberSessionKey,
                    BasketItemId = item.ID,
                    Name = item.Name,
                    MonthPrice = (decimal)item.MonthPrice,
                    DollarPrice = (decimal)item.DollarPrice,
                    YearPrice = (decimal)item.YearPrice,
                    kdvliDollarPrice = (decimal)item.kdvliDollarPrice,
                    YTLPrice = (decimal)item.YTLPrice,
                    kdvliYTLPrice = (decimal)item.kdvliYTLPrice,
                    Quantity = (decimal)item.Quantity,
                    QuantityType = item.QuantityType,
                    Type = item.Type,
                    RegistryCompany = item.RegistryCompany,
                    Tax = (decimal)item.Tax,
                    UsdSelling = (decimal)item.UsdSelling,
                    islemiYapildi = item.islemiYapildi,
                    InCampaign = item.InCampaign,
                    CampaignPrice = (decimal)item.CampaignPrice,
                    CampaignPeriod = (decimal)item.CampaignPeriod,
                    IsExpiredHosting = item.IsExpiredHosting,
                    HostingID_Lenghten = item.HostingID_Lenghten,
                    QueueID = item.QueueID,
                    TargetID = item.TargetID,
                    OrderDetailID = item.OrderDetailID,
                    UzantiID = item.UzantiID,
                    ProductID = item.ProductID,
                    referredPrdID = item.referredPrdID,
                    ServerID = item.ServerID,
                    IsPromotion = item.IsPromotion,
                    DomainPriceForCamp = (decimal)item.DomainPriceForCamp,
                    AuthCode = item.AuthCode,
                    MarkClassIDs = StringJoin(item.MarkClassIDs, ";"),
                    MarkName = item.MarkName,
                    ProductTypeId = item.ProductTypeId,
                    domContComp = (int)item.domContComp,
                    EkstraUzatma = item.EkstraUzatma,
                    relatedProducts = item.relatedProducts,
                    ColourType = (int)item.ColourType,
                    VisualCount = item.VisualCount,
                    Promotion = item.Promotion,
                    OldPrice = (decimal)item.OldPrice,
                    UpgradeQuantity = item.UpgradeQuantity,
                    PciDssDomanName = item.PciDssDomanName,
                    SunucuEklenti = item.SunucuEklenti, // 7.4.2014 sunucu için eklendi
                    RegisterStatus = (int)item.enmRegisterStatus,
                    ReferenceId = item.ReferenceId
                };

                if (item.customizeVdsServer != null)
                {
                    myMemberBasketDetail.customizeVdsServer = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.CustomizeVdsServer();
                    myMemberBasketDetail.customizeVdsServer.BasketDetailCustomizeVdsServerId = item.customizeVdsServer.BasketDetailCustomizeVdsServerId;
                    myMemberBasketDetail.customizeVdsServer.BasketDetailId = item.customizeVdsServer.BasketDetailId;
                    myMemberBasketDetail.customizeVdsServer.MemberId = basket.memberID;
                    myMemberBasketDetail.customizeVdsServer.PriceTotal = (decimal)item.customizeVdsServer.PriceTotal;
                    myMemberBasketDetail.customizeVdsServer.PriceTotalUnit = item.customizeVdsServer.PriceTotalUnit;
                    myMemberBasketDetail.customizeVdsServer.GetUSDString = item.customizeVdsServer.GetUSDString();
                    myMemberBasketDetail.customizeVdsServer.PriceTotalTr = (decimal)item.customizeVdsServer.PriceTotalTr;
                    myMemberBasketDetail.customizeVdsServer.PriceTotalTrUnit = item.customizeVdsServer.PriceTotalTrUnit;
                    myMemberBasketDetail.customizeVdsServer.GetTrString = item.customizeVdsServer.GetTrString();
                    myMemberBasketDetail.customizeVdsServer.Quantity = (decimal)item.customizeVdsServer.Quantity;
                    myMemberBasketDetail.customizeVdsServer.QuantityType = item.customizeVdsServer.QuantityType;
                    myMemberBasketDetail.customizeVdsServer.USDSelling = (decimal)item.customizeVdsServer.USDSelling;
                    myMemberBasketDetail.customizeVdsServer.ExtraConfigurationDescription = item.customizeVdsServer.ExtraConfigurationDescription;
                    myMemberBasketDetail.customizeVdsServer.EnmGroup = (int)item.customizeVdsServer.Group;
                    myMemberBasketDetail.customizeVdsServer.ProductSummary = item.customizeVdsServer.ProductSummary;
                    myMemberBasketDetail.customizeVdsServer.IndirimTutari = (decimal)item.customizeVdsServer.IndirimTutari;
                    myMemberBasketDetail.customizeVdsServer.Yuzde = item.customizeVdsServer.Yuzde;
                    myMemberBasketDetail.customizeVdsServer.Tutar = (decimal)item.customizeVdsServer.Tutar;
                    if (item.customizeVdsServer.ProductItems.Count > 0) myMemberBasketDetail.customizeVdsServer.ProductItems = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.CustomizeVdsServer.ProductItem>();
                    foreach (var y in item.customizeVdsServer.ProductItems)
                    {
                        DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.CustomizeVdsServer.ProductItem myProductItem = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.CustomizeVdsServer.ProductItem();
                        myProductItem.ProductItemId = y.ProductItemId;
                        myProductItem.CustomizeVdsServerId = y.CustomizeVdsServerId;
                        myProductItem.ItemId = y.Id;
                        myProductItem.GroupId = y.GroupId;
                        myProductItem.Name = y.Name;
                        myProductItem.OrderIndex = y.OrderIndex;
                        myProductItem.Price = (decimal)y.Price;
                        myProductItem.PriceUnit = y.PriceUnit;
                        myProductItem.PriceUnitStr = y.PriceUnitStr;
                        myProductItem.GetUSDString = y.GetUSDString();
                        myProductItem.PriceTr = (decimal)y.PriceTr;
                        myProductItem.PriceTrUnit = y.PriceTrUnit;
                        myProductItem.PriceTrUnitsTR = y.PriceTrUnitsTR;
                        myProductItem.GetTrString = y.GetTrString();
                        myProductItem.OperatingSystem = y.OperatingSystem;
                        myProductItem.IsConfiguratiion = y.IsConfiguratiion;
                        myProductItem.Prop = (int)y.Prop;
                        myProductItem.PropEnmVariable = (int)y.PropEnmVariable;
                        myProductItem.ExtraProp = y.ExtraProp;
                        myProductItem.EnmUnit = (int)y.EnmUnit;
                        myProductItem.PriceTotal = y.PriceTotal;
                        myProductItem.PriceTotalStr = y.PriceTotalStr;
                        myProductItem.IndirimTutari = (decimal)y.IndirimTutari;
                        myProductItem.Yuzde = y.Yuzde;
                        myProductItem.Tutar = (decimal)y.Tutar;
                        myProductItem.tempPrice = (decimal)y.tempPrice;

                        myMemberBasketDetail.customizeVdsServer.ProductItems.Add(myProductItem);
                    }
                }
                //
                if (item.phosting != null)
                {
                    myMemberBasketDetail.phosting = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.PHosting();
                    myMemberBasketDetail.phosting.PHostingId = item.phosting.PHostingId;
                    myMemberBasketDetail.phosting.BasketDetailId = item.phosting.BasketDetailId;
                    myMemberBasketDetail.phosting.ItemId = item.phosting.Id;
                    myMemberBasketDetail.phosting.Name = item.phosting.Name;
                    myMemberBasketDetail.phosting.OperatingSystem = item.phosting.OperatingSystem;
                    myMemberBasketDetail.phosting.EnmGroup = (int)item.phosting.EnmGroup;
                    myMemberBasketDetail.phosting.OldPrice = (decimal)item.phosting.OldPrice;
                    myMemberBasketDetail.phosting.TempPrice = (decimal)item.phosting.TempPrice;
                    myMemberBasketDetail.phosting.Price = (decimal)item.phosting.Price;
                    myMemberBasketDetail.phosting.PriceUnit = item.phosting.PriceUnit;
                    myMemberBasketDetail.phosting.CampaignPrice = (decimal)item.phosting.CampaignPrice;
                    myMemberBasketDetail.phosting.CampaingPriceUnit = item.phosting.CampaingPriceUnit;
                    myMemberBasketDetail.phosting.Quantity = (decimal)item.phosting.Quantity;
                    myMemberBasketDetail.phosting.QuantityType = item.phosting.QuantityType;
                    myMemberBasketDetail.phosting.USDSelling = (decimal)item.phosting.USDSelling;
                    myMemberBasketDetail.phosting.ProductCode = item.phosting.ProductCode;
                    myMemberBasketDetail.phosting.ProductID = item.phosting.ProductID;
                    myMemberBasketDetail.phosting.UpgradeQuantity = item.phosting.UpgradeQuantity;
                    myMemberBasketDetail.phosting.GuidKey = item.phosting.Key.ToString();
                    myMemberBasketDetail.phosting.Reseller = item.phosting.Reseller;

                    if (item.phosting.HostingItems == null) item.phosting.HostingItems = new System.Collections.Generic.List<PRD_HostingItemsDTO>();

                    if (item.phosting.HostingItems != null) myMemberBasketDetail.phosting.HostingItems = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.PHosting.HostingItem>();
                    foreach (var y in item.phosting.HostingItems)
                    {
                        DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.PHosting.HostingItem myHostingItem = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.PHosting.HostingItem();
                        myHostingItem.HostingItemId = y.HostingItemId;
                        myHostingItem.BasketDetailId = y.BasketDetailId;
                        myHostingItem.BasketPHostingId = y.BasketPHostingId;
                        myHostingItem.ItemId = y.Id;
                        myHostingItem.PropName = y.PropName;
                        myHostingItem.Name = y.Name;
                        myHostingItem.Value = y.Value.ToInt32();
                        myHostingItem.UsedValue = y.UsedValue.ToInt32();
                        myHostingItem.UsedValueStr = y.UsedValueStr;
                        myHostingItem.EnmProp = (int)y.EnmProp;
                        myHostingItem.DetailId = y.DetailId;
                        myMemberBasketDetail.phosting.HostingItems.Add(myHostingItem);
                    }


                }
                //
                if (item.PatentAndBenefitModel != null)
                {
                    myMemberBasketDetail.patentAndBenefitModel = new DealerSafe.DTO.Orders.ReqUpdateMemberBasket.MemberBasketDetail.PatentAndBenefitModel();
                    myMemberBasketDetail.patentAndBenefitModel.PatentAndBenefitModelId = item.PatentAndBenefitModel.PatentAndBenefitModelId;
                    myMemberBasketDetail.patentAndBenefitModel.BasketDetailId = item.PatentAndBenefitModel.BasketDetailId;
                    myMemberBasketDetail.patentAndBenefitModel.NameOfInvention = item.PatentAndBenefitModel.NameOfInvention;
                    myMemberBasketDetail.patentAndBenefitModel.Sector = item.PatentAndBenefitModel.Sector;
                    myMemberBasketDetail.patentAndBenefitModel.UsingArea = item.PatentAndBenefitModel.UsingArea;
                    myMemberBasketDetail.patentAndBenefitModel.ProtectionArea = item.PatentAndBenefitModel.ProtectionArea;
                    myMemberBasketDetail.patentAndBenefitModel.ProcessType = item.PatentAndBenefitModel.ProcessType;
                }
                RequestBasket.product.Add(myMemberBasketDetail);
            }
            // Service Baðlanýlacak!
            if (RequestBasket.memberSessionKey == null)
                RequestBasket.memberSessionKey = HttpContext.Current.Session.SessionID;
            DealerSafe.ServiceClient.OrdersAPI myOrderAPI = new DealerSafe.ServiceClient.OrdersAPI(basket.memberID);
            DealerSafe.DTO.Orders.UpdateMemberBasketInfo myUpdateMemberBasket = myOrderAPI.UpdateMemberBasket(RequestBasket);

            //Servisten gelen ID leri sepete assaign edelim ve sessiondaki sepeti güncelliyelim.
            basket.BasketId = myUpdateMemberBasket.BasketId;
            for (int i = 0; i < basket.product.Count; i++)
            {
                Product p = (Product)basket.product[i];
                DealerSafe.DTO.Orders.UpdateMemberBasketInfo.MemberBasketDetail b = myUpdateMemberBasket.product.Where(a => a.BasketItemId == p.ID).FirstOrDefault();
                ((Product)basket.product[i]).BasketDetailId = b.BasketDetailId;

                if (b.customizeVdsServer != null && b.customizeVdsServer.BasketDetailCustomizeVdsServerId > 0 && p.customizeVdsServer != null)
                {
                    ((Product)basket.product[i]).customizeVdsServer.BasketDetailCustomizeVdsServerId = b.customizeVdsServer.BasketDetailCustomizeVdsServerId;
                    ((Product)basket.product[i]).customizeVdsServer.BasketDetailId = b.customizeVdsServer.BasketDetailId;

                    for (int x = 0; x < ((Product)basket.product[i]).customizeVdsServer.ProductItems.Count; x++)
                    {
                        ProductItem pi = ((Product)basket.product[i]).customizeVdsServer.ProductItems[x];
                        DealerSafe.DTO.Orders.UpdateMemberBasketInfo.MemberBasketDetail.CustomizeVdsServer.ProductItem mpi = myUpdateMemberBasket.product[i].customizeVdsServer.ProductItems.Where(a => a.ItemId == pi.Id).FirstOrDefault();
                        if (mpi != null)
                        {
                            ((Product)basket.product[i]).customizeVdsServer.ProductItems[x].ProductItemId = mpi.ProductItemId;
                            ((Product)basket.product[i]).customizeVdsServer.ProductItems[x].CustomizeVdsServerId = mpi.CustomizeVdsServerId;
                        }
                    }
                }

                if (b.phosting != null && b.phosting.PHostingId > 0 && p.phosting != null)
                {
                    ((Product)basket.product[i]).phosting.PHostingId = b.phosting.PHostingId;
                    ((Product)basket.product[i]).phosting.BasketDetailId = b.phosting.BasketDetailId;

                    for (int x = 0; x < ((Product)basket.product[i]).phosting.HostingItems.Count; x++)
                    {
                        PRD_HostingItemsDTO pi = ((Product)basket.product[i]).phosting.HostingItems[x];
                        DealerSafe.DTO.Orders.UpdateMemberBasketInfo.MemberBasketDetail.PHosting.HostingItem mpi = myUpdateMemberBasket.product[i].phosting.HostingItems.Where(a => a.ItemId == pi.Id).FirstOrDefault();
                        if (mpi != null)
                        {
                            ((Product)basket.product[i]).phosting.HostingItems[x].HostingItemId = mpi.HostingItemId;
                            ((Product)basket.product[i]).phosting.HostingItems[x].BasketDetailId = mpi.BasketDetailId;
                            ((Product)basket.product[i]).phosting.HostingItems[x].BasketPHostingId = mpi.BasketPHostingId;
                        }
                    }
                }

                if (b.patentAndBenefitModel != null && b.patentAndBenefitModel.PatentAndBenefitModelId > 0 && p.PatentAndBenefitModel != null)
                {
                    ((Product)basket.product[i]).PatentAndBenefitModel.PatentAndBenefitModelId = b.patentAndBenefitModel.PatentAndBenefitModelId;
                    ((Product)basket.product[i]).PatentAndBenefitModel.BasketDetailId = b.patentAndBenefitModel.BasketDetailId;
                }
            }

            //Düzenlenen sepeti Sessiona gönderelim geri.
            HttpContext.Current.Session["SEPET"] = basket;
        }

        public static void DeleteBasket(Product p, Sepet basket)
        {
            DealerSafe.DTO.Orders.ReqDeleteMemberBasket request = new DealerSafe.DTO.Orders.ReqDeleteMemberBasket();
            request.ProductList = new System.Collections.Generic.List<DealerSafe.DTO.Orders.ReqDeleteMemberBasket.DeletProductDetail>();
            request.ProductList.Add(new DealerSafe.DTO.Orders.ReqDeleteMemberBasket.DeletProductDetail() { BasketID = basket.BasketId, MemberID = basket.memberID, ProductID = p.BasketDetailId, MemberSessionKey = basket.memberSessionKey });

            // Service Baðlanýlacak!
            DealerSafe.ServiceClient.OrdersAPI myOrderAPI = new DealerSafe.ServiceClient.OrdersAPI(p.MemberId);
            myOrderAPI.DeleteMemberBasket(request);
        }
    }

    [Serializable]
    public class NetRebate
    {
        public string Name { get; set; }
        public int Extension { get; set; }
    }

    [Serializable]
    public class Product
    {
        public int ID;
        public int BasketDetailId;//Yeni Eklendi
        public int BasketId;//Yeni Eklendi
        public int MemberId;//Yeni Eklendi
        public string MemberSessionKey;//Yeni Eklendi
        public string Name;
        public double MonthPrice;
        public double DollarPrice;
        public double YearPrice;
        public double kdvliDollarPrice;
        public double YTLPrice;
        public double kdvliYTLPrice;
        public double Quantity;
        public string QuantityType;
        public string Type;
        public string RegistryCompany;
        public double Tax;
        public double UsdSelling;
        public int islemiYapildi;
        public int InCampaign;
        public double CampaignPrice;
        public double CampaignPeriod;
        public string IsExpiredHosting;//hosting uzatma için
        public int HostingID_Lenghten;//hosting uzatma için
        public int QueueID;//Kuyruða atýlan iþlem için kuyruktaki Id si
        public int TargetID;//ürünün tipine göre baðlý olduðu ürün gurubunun tablosuna iliþkin ID si ör: Domain için MembersDNS tbl daki ID gibi
        //public int DomainID;//domain uzatma geri alma için....
        public int OrderDetailID;
        public int UzantiID;//UzantiID;
        public int ProductID;
        public int referredPrdID;//uzatma yapýlan domaine aitse buraya domainin ID si gonderilir.
        public int ServerID;//Sunucularda eklenti satýn alýnmýþsa buraya eklenir.
        public bool IsPromotion;//Promotion domain ise true set edilir.
        public double DomainPriceForCamp;//kampanyalý domain için normal fiyat burada tutulur.
        public string AuthCode; // Transfer Þifresi
        public ArrayList MarkClassIDs;
        public ArrayList MarkClassProductIDs; // Marka Sýnýflarýnýn Product Id leri için
        public string MarkName;
        public int ProductTypeId;
        public enmContactCompatibility domContComp;
        public bool EkstraUzatma;
        public string relatedProducts;
        public enmIndustrialDesignColourType ColourType;
        public int VisualCount;
        public int Promotion = 0;
        public double OldPrice; // hostinglerin eski fiyatlarýný alabilmek için eklendi. 
        public ProductDTO customizeVdsServer;
        public PRD_HostingDTO phosting;
        public int UpgradeQuantity;
        public string PciDssDomanName;
        public List<int> SunucuEklenti; // 7.4.2014 sunucu için eklendi
        public PatentAndBenefitModel PatentAndBenefitModel;
        public int ContactType = 0;
        public EnmRegisterStatus enmRegisterStatus { get; set; }
        public int ReferenceId = 0;
        public int ParentBrandId = 0; // Yeni Eklendi

        public Product()
        {
            ID = 0;
            Name = "";
            MonthPrice = 0.0;
            DollarPrice = 0.0;
            YearPrice = 0.0;
            kdvliDollarPrice = 0.0;
            YTLPrice = 0.0;
            kdvliYTLPrice = 0.0;
            Quantity = 0.0;
            QuantityType = "";
            Type = "";
            RegistryCompany = "";
            Tax = 0.0;
            UsdSelling = 0.0;
            islemiYapildi = 0;
            InCampaign = 0;
            CampaignPrice = 0.0;
            CampaignPeriod = 0.0;
            HostingID_Lenghten = 0;
            QueueID = 0;
            TargetID = -5;
            //DomainID = 0;
            OrderDetailID = 0;
            UzantiID = 0;
            referredPrdID = -1;
            ServerID = 0;
            IsPromotion = false;
            DomainPriceForCamp = 0.0;
            AuthCode = "";
            MarkClassIDs = new ArrayList();
            MarkName = "";
            ProductTypeId = 0;
            domContComp = enmContactCompatibility.NoDomain;
            ColourType = enmIndustrialDesignColourType.black;
            VisualCount = 0;
            relatedProducts = "";
            UpgradeQuantity = 0;
            PatentAndBenefitModel = null;
            ContactType = 0;
            //customizeVdsServer= new ProductDTO();
            SunucuEklenti = new List<int>(); // sunucu eklentileri 7.4.2014
            ReferenceId = 0;
            ParentBrandId = 0;
        }
    }
}
