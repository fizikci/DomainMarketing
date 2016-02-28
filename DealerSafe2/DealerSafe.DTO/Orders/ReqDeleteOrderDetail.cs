using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqDeleteOrderDetail
    {
        public SepeteAtilanUrunTipi ProductType { get; set; }
        public int TargetID { get; set; }
        public int OrderID { get; set; }
        public int OrderDetailID { get; set; }
        public WhyDelete Why { get; set; }
    }
    public enum WhyDelete
    {
        None = 0,
        DomainSuresiDolmus = 1,
        FiyatHesaplanamadi = 2,
        MusteriSildi = 3,
        DomainKaydedilmis = 4,
        SepetteUrunKalmadi = 5,
        SiparisSuresiDolmus = 6
    }
    public enum SepeteAtilanUrunTipi
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
}
