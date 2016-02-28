using DealerSafe.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqCompleteOrderActions
    {
        public HostingUpgradeDetail HostingUpgrade { get; set; }
        public BasketDetail Sepet { get; set; }
        public PaymentFlag Payflag { get; set; }
        public string Notice { get; set; }
        public QueueReportType QueueReport { get; set; }
        public string IPAddress { get; set; }
        public string Session { get; set; }
    }
    public enum QueueReportType
    {
        none = 0,
        isimtescil_Kredi_Karti_ile_alışveriş = 1,
        isimtescil_Kredili_alışveriş = 2,
        isimtescil_Banka_Havalesi_ile_alışveriş = 3,
        isimtescil_Mail_Order_ile_alışveriş = 4,
        isimtescil_Posta_Çeki_ile_alışveriş = 5,
        isimtescil_Member_Not_Approved_Processes_Will_Done_Manually = 6,
        isimtescil_Bilinmeyen_Hata = 7,
        isimtescil_TargetID_Cannot_Be_Assigned = 8,
        isimtescil_DB_Error_1_Update_Command_Error = 9, //Update işlemi hata ya düştü
        isimtescil_DB_Error_2_Insert_Command_Error = 10, //İnsert işlemi hata ya düştü
        isimtescil_DB_Error_3_Domain_Kuyruktan_düşürülürken_hata_oluştu = 11,
        Directi_Hata_Gelen_Veride_Ayırdedilemeyen_Hata = 12,//----------------------------------------------------------
        isimtescil_Directi_Hata_2_IDictionaryEnumerator_ilerleme_hatası = 13,
        isimtescil_Directi_Hata_3_Process_timed_Out_Thread_Aborted = 14,
        isimtescil_Directi_domain_Kayıt_işlemleri_başarılı = 15,
        Directi_or_DB_Domain_Uzatma_Suresi_Verisi_problemli = 16,//----------------------------------------------------------
        Directi_Domain_Uzatma_DB_Domain_Sure_uyumsuzluğu = 17,//----------------------------------------------------------
        Directi_Domain_Uzatma_başarılı = 18,//----------------------------------------------------------
        isimtescil_Directi_Transfer_Onayı_Bekleyen_Domainler = 19,
        isimtescil_Directi_Transfer_Ayıklanmamış_Hata = 20,
        isimtescil_RRP_Hata_1_Process_timed_Out_Thread_Aborted = 21,
        isimtescil_RRP_domain_Kayıt_işlemleri_başarılı = 22,
        RRP_Servisten_Gelen_Cevapta_Hata_Var = 23,//----------------------------------------------------------
        RRP_Domain_Uzatma_DB_Domain_Sure_uyumsuzluğu = 24,//----------------------------------------------------------
        RRP_OR_DB_Domain_Uzatma_Suresi_Verisi_problemli = 25,//----------------------------------------------------------
        isimtescil_RRP_Domain_Uzatma_başarılı = 26,
        isimtescil_RRP_Transfer_Onayı_Bekleyen_Domainler = 27,
        isimtescil_RRP_Transfer_Ayıklanmamış_Hata = 28,
        isimtescil_ODTU_Domain_Transfer_edilmeyi_Bekliyor = 29,
        isimtescil_SSL_Odemesi_Alınmış_Aktiflenmemeiş_SSLler = 30,
        isimtescil_DNS_Guncelleme_İşlemi_Başarılı = 31,
        isimtescil_DNS_Güncelleme_İşlemi_beklemede = 32,
        isimtescil_şifre_Gönderilmesi_Gereken_Hostingler = 33,
        isimtescil_Ödemesi_Çekilen_ve_DBden_Uzatılan_Hostingler = 34,
        isimtescil_Domain_Atama_Bekleyen_Hostingler_DomainID_Atandı = 35,
        isimtescil_Domain_Atama_Bekleyen_Hostingler_DomainID_Atanamadı = 36,
        isimtescil_Ödemesi_Çeiklen_Uzatilamayan_Hostingler = 37,
        isimtescil_Ödemesi_Alinip_Aktiflenemeyen_Hositngler = 38,
        isimtescilAdmin_Directi_Domain_Uzatma_başarılı = 39,
        RRP_Domain_Uzatma_başarılı = 40,//----------------------------------------------------------
        isimtescilAdmin_Directi_Domain_Uzatılırken_hata_oluştu = 41,
        isimtescilAdmin_RRP_Domain_Uzatılırken_hata_oluştu = 42,
        isimtescilAdmin_Transfer_Onayı_Verildi = 43,
        isimtescilAdmin_Uzatma_yapıldı = 44,
        isimtescilAdmin_şifre_Gönderilmesi_Gereken_Hostingler = 45,
        isimtescilAdmin_Domain_Atama_Bekleyen_Hostingler = 46,
        isimtescilAdmin_İşlemi_Tamamlanan_Hostingler = 47,
        İsimtescilAdmin_Ödemesi_Çekilen_ve_DBden_Uzatilan_Hostingler = 48,
        İsimtescilAdmin_Domain_Kayit_Directi_Response_Verisi_Hatalı = 49,
        İsimtescilAdmin_Domain_Kayit_CustomerID_Bozuk_Veri = 50,
        isimtescilAdmin_Domain_Kayıt_Siparis_Aktiflendi = 51,
        isimtescilAdmin_Domain_Uzatma_Siparis_Aktiflendi = 52,
        isimtescilAdmin_Alan_Adı_Geri_Alma_Siparis_Aktiflendi = 53,
        isimtescilAdmin_Transfer_Edilmeyi_Bekleyen_Domainler_Siparis_Aktiflendi = 54,
        isimtescilAdmin_Kaydolmayı_Bekleyen_Domainler_Ödeme_Aktiflendi = 55,
        isimtescilAdmin_Transfer_Edilmeyi_Bekleyen_Domainler_Ödeme_Aktiflendi = 56,
        isimtescilAdmin_Domain_Uzatma_Ödeme_Aktiflendi = 57,
        isimtescilAdmin_Alan_Adı_Geri_Alma_Ödemesi_Aktiflendi = 58,
        isimtescilAdmin_Domain_Kayıt_DomainEkle2sayfasından = 59,
        isimtescilAdmin_Domainler_aspx_sadece_DBye_Kayıt_Basarılı = 60,
        isimtescilAdmin_Domainler_aspx_sadece_DBye_Kayıt_Hata_Olustu = 61,
        isimtescilAdmin_Directi_Transfer_Edilmayi_Bekleyen_Domainler = 62,
        isimtescilAdmin_RRP_Transfer_Edilmayi_Bekleyen_Domainler = 63,
        isimtescilAdmin_Directi_Transfer_Onayı_Bekleyen_Domainler = 64,
        isimtescilAdmin_RRP_Transfer_Onayı_Bekleyen_Domainler = 65,
        isimtescilAdmin_Domain_DNS_Değişikliği_Bekliyor_Domainler_aspx = 66,
        isimtescil_Manuel_Domain_Kayıt = 67,
        isimtescilAdmin_TRDomain_Kayıt_Siparis_Aktiflendi = 68,
        isimtescilAdmin_Kaydolmayı_Bekleyen_TRDomainler_Ödeme_Aktiflendi = 69,
        isimtescilAdmin_Kaydedilecek_SSL_Sparisi_Aktiflendi = 70,
        isimtescilAdmin_Kaydedilecek_SSL_Ödeme_Onaylandı = 71,
        isimtescilAdmin_SSL_Kaydedildi = 72,
        isimtescilAdmin_Directi_Transfer_Başlatma_Hatalı = 73,
        isimtescilAdmin_RRP_Transfer_Başlatma_Hatalı = 74,
        isimtescilAdmin_Directi_Transfer_işleminde_OrderID_Alınamadı = 75,
        isimtescilAdmin_Domain_Kuyruktan_Düşürüldü = 76,
        Çakma_Metod_işlem_yaptı_Dikkat_Edin = 77,
        isimtescil_RRP_alanadı_geri_alma_işlemi_bir_süre_manuel_yapılacak = 78,
        isimtescil_Directi_Directide_Uzadı_Panelde_Uzamadi = 79,
        isimtescil_ODTU_Alan_adı_kayıt_Başvurusu = 80,
        ODTU_Domain_Uzatma_başarılı = 81,//----------------------------------------------------------
        isimtescilAdmin_ODTU_Hata_1_Gelen_Veride_Ayırdedilemeyen_Hata = 82,
        ODTU_veya_DB_Domain_Uzatma_Suresi_Verisi_problemli = 83,//----------------------------------------------------------
        ODTU_Domain_Uzatma_DB_Domain_Sure_uyumsuzluğu = 84,//----------------------------------------------------------
        isimtescil_ODTU_Domain_Uzatma_başarılı = 85,
        isimtescil_ODTU_Hata_1_Gelen_Veride_Ayırdedilemeyen_Hata = 86,
        isimtescil_ODTUorDB_Domain_Uzatma_Suresi_Verisi_problemli = 87,
        isimtescil_ODTU_Domain_Uzatma_DB_Domain_Sure_uyumsuzluğu = 88,
        isimtescilAdmin_DB_Error_1_Update_Command_Error = 89,
        isimtescilAdmin_RRP_Domain_Uzatma_DB_Domain_Sure_uyumsuzluğu = 90,
        isimtescilAdmin_RRPorDB_Domain_Uzatma_Suresi_Verisi_problemli = 91,
        isimtescilAdmin_RRP_Gelen_Veride_Hata_Var = 92,
        isimtescil_NicTr_Test_Kayıtlari_Manuel = 93,
        isimtescil_MemberNotApproved_TotatlPriceOverFlow_PriceOverFlow = 94,
        isimtescil_MemberNotApproved_TotatlPriceOverFlow_PriceNotOverFlow = 95,
        isimtescil_MemberNotApproved_TotatlPriceNotOverFlow_PriceOverFlow = 96,
        isimtescil_MemberNotApproved_TotatlPriceNotOverFlow_PriceNotOverFlow = 97,
        isimtescil_MemberApproved_TotatlPriceOverFlow_PriceOverFlow = 98,
        isimtescil_MemberApproved_TotatlPriceOverFlow_PriceNotOverFlow = 99,
        isimtescil_MemberApproved_TotatlPriceNotOverFlow_PriceOverFlow = 100,
        isimtescilAdmin_ODTU_Domain_Kuyruğunda_bekliyor = 101,
        ODTU_Domain_Uzatma_Kuyruğunda_Bekliyor = 102,//----------------------------------------------------------
        isimtescilAdmin_ODTU_Domain_Kuyruğunda_bekliyor_TransferEdilmeyiBekliyor = 103,
        isimtescilAdmin_ODTU_Domain_Kuyruğunda_bekliyor_TransferOnayıBekliyor = 104,
        isimtescil_ODTU_Domain_DNS_Kuyruğunda_bekliyor = 105,
        isimtescilAdmin_ODTU_Domain_Uzatma_Başarılı = 106,
        isimtescilAdmin_ODTU_Domain_Uzatılırken_Hata_Oluştu = 107,
        isimtescilAdmin_ODTU_Domain_Kayıt_Siparis_Aktiflendi = 108,
        isimtescilAdmin_ODTU_Alan_Adı_Geri_Alma_Siparis_Aktiflendi = 109,
        isimtescilAdmin_ODTU_Uzatma_Siparis_Aktiflendi = 110,
        isimtescilAdmin_ODTU_Transfer_Edilmeyi_Bekleyen_Domainler_Siparis_Aktiflendi = 111,
        isimtescilAdmin_Kaydolmayı_Bekleyen_ODTU_Domainler_Ödeme_Aktiflendi = 112,
        isimtescilAdmin_ODTU_Transfer_Edilmeyi_Bekleyen_Domainler_Ödeme_Aktiflendi = 113,
        isimtescilAdmin_ODTU_Alan_Adı_Geri_Alma_Ödemesi_Aktiflendi = 114,
        isimtescilAdmin_ODTU_Domain_Uzatma_Ödeme_Aktiflendi = 115,
        isimtescilAdmin_ODTU_Domain_Kayıt_işlemi_Başarılı = 116,
        isimtescil_DotTK_Gelen_Veride_Hata_Var = 117,
        isimtescil_DotTK_Hata_1_Process_timed_Out_Thread_Aborted = 118,
        isimtescil_DotTK_domain_Kayıt_işlemleri_başarılı = 119,
        isimtescil_DotTK_alanadı_geri_alma_işlemi_bir_süre_manuel_yapılacak = 120,
        DotTK_Domain_Uzatma_başarılı = 121,//------------------------------------------------------------------------
        isimtescil_DotTK_DotTKda_Uzadı_Panelde_Uzamadi = 122,
        DotTK_Domain_Uzatma_DB_Domain_Sure_uyumsuzluğu = 123,//------------------------------------------------------------------------
        DotTK_or_DB_Domain_Uzatma_Suresi_Verisi_problemli = 124,//------------------------------------------------------------------------
        DotTK_Hata_Gelen_Veride_Ayırdedilemeyen_Hata = 125,//------------------------------------------------------------------------
        isimtescil_Sunucu_Kiralama_Ödemesi_Alınmış_Aktiflenecek_Sunucu = 126,
        isimtescil_Vps_Kiralama_Ödemesi_Alınmış_Aktiflenecek_Vps = 127,
        DotTK_Gelen_Veride_Hata_Var = 128,//------------------------------------------------------------------------
        isimtescilAdmin_DotTK_Kayıt_İşlemi_Başarılı_Whois_Bilgisi_Güncellenemedi = 129,
        isimtescilAdmin_DotTK_Kayıt_İşlemi_Başarılı = 130,
        isimtescilAdmin_RRP_DomainKayıt_İşlemi_Başarılı = 131,
        isimtescilAdmin_RRP_Domain_Kaydedilirken_Hata_Oluştu = 132,
        isimtescilAdmin_Directi_Domain_Kayıt_başarılı = 133,
        isimtescilAdmin_Directi_Domain_Kaydedilirken_hata_oluştu = 134,
        isimtescilAdmin_Kaydedilecek_Vps_Hizmetleri_Sparisi_Aktiflendi = 135,
        isimtescilAdmin_Kaydedilecek_Sunucu_Hizmetleri_Sparisi_Aktiflendi = 136,
        isimtescilAdmin_Kaydedilecek_Web_Klavuzu_Sparisi_Aktiflendi = 137,
        isimtescilAdmin_Sunucu_Kaydedildi = 138,
        isimtescilAdmin_Vps_Kaydedildi = 139,
        isimtescilAdmin_WebKlavuzu_Kaydedildi = 140,
        isimtescil_Odemesi_Alınmış_Aktiflenmemeiş_WebKalvuzu = 141,
        isimtescilAdmin_DotTK_Domain_Uzatma_başarılı = 142,
        isimtescil_Web_Klavuzu_Kiralama_Ödemesi_Alınmış_Aktiflenecek_Web_Klavuzu = 143,
        isimtescil_Borc_Odemesi = 144,
        isimtescil_Admin_Borc_Odemesi_Kaydedildi = 145,
        isimtescil_CepBank_ile_Alisveris = 146,
        isimtescil_Admin_CepBank_Kaydedildi = 147,

        isimtescil_Admin_Kaydedilmeyi_Bekleyen_Domainler_Tanımsız_işlemlerden = 148,
        isimtescil_Admin_Uzatılmayı_Bekleyen_Domainler_Tanımsız_işlemlerden = 149,
        isimtescil_Admin_Kaydedilmeyi_Bekleyen_Hostingler_Tanımsız_işlemlerden = 150,
        isimtescil_Admin_Uzatılmayı_Bekleyen_Hostingler_Tanımsız_işlemlerden = 151,
        isimtescil_Admin_Transfer_edilecek_Domainler_Tanımsız_işlemlerden = 152,
        isimtescil_Admin_Kaydedilmeyi_Bekleyen_SSL_Tanımsız_işlemlerden = 153,
        isimtescil_Admin_DNS_Güncelleme_işlemi_Tanımsız_işlemlerden = 154,
        isimtescil_Admin_Domain_Atama_Bekleyen_Hostingler_Tanımsız_işlemlerden = 155,
        isimtescil_Admin_Kaydedilecek_Sunucu_Tanımsız_işlemlerden = 156,
        isimtescil_Admin_Kaydedilecek_Vps_Tanımsız_işlemlerden = 157,
        isimtescil_Admin_Kaydedilecek_Web_Klavuzu_Tanımsız_işlemlerden = 158,
        isimtescil_Admin_Borc_Odemesi_Tanımsız_işlemlerden = 159,
        isimtescil_Admin_Tanımsız_İşlemler_Kuyruğundan_Düşürme = 160,
        isimtescil_Admin_Kaydedilmeyi_Bekleyen_ODTU_Domainler_Tanımsız_işlemlerden = 161,
        isimtescil_Admin_Uzatılmayı_Bekleyen_ODTU_Domainler_Tanımsız_işlemlerden = 162,
        isimtescil_Admin_Transfer_edilecek_ODTU_Domainler_Tanımsız_işlemlerden = 163,
        isimtescil_Admin_ODTU_DNS_Güncelleme_işlemi_Tanımsız_işlemlerden = 164,
        isimtescil_Admin_Siparis_Silme_İşlemi = 165,
        isimtescil_Admin_Domain_Uzatma_Operatör_Tarafından_Kontrol_Edildi_Kuyruktan_Düşürüldü = 166,
        Directi_Domain_Uzatma_Gerekli_değil_İşlem_Kuyruktan_Düşürüldü = 167,//----------------------------------------------------------
        RRP_Domain_Uzatma_Gerekli_değil_İşlem_Kuyruktan_Düşürüldü = 168,//----------------------------------------------------------
        ODTU_Domain_Uzatma_Gerekli_değil_İşlem_Kuyruktan_Düşürüldü = 169,//----------------------------------------------------------
        DotTk_Domain_Uzatma_Gerekli_değil_İşlem_Kuyruktan_Düşürüldü = 170,//------------------------------------------------------------------------

        isimtescil_VeriSign_Domain_Register_Command_Completed_With_Error = 171,//kuyrukta
        isimtescil_VeriSign_Domain_Register_Command_Process_time_Out_Thread_Aborted = 172,//kuyrukta
        isimtescil_VeriSign_Domain_Register_Command_Completed_Successfully = 173,//kuyruktan düşürüldü
        isimtescil_VeriSign_Domain_Transfer_Onayı_Bekleyen_Domainler = 174,//kuyrukta
        isimtescil_VeriSign_Domain_Transfer_İsteği_Hata = 175,//kuyrukta

        VeriSign_Domain_Uzatma_Başarılı = 176,//------------------------------------------------------------------------
        VeriSign_Domain_Uzatma_Başarısız = 177,//------------------------------------------------------------------------
        VeriSign_Domain_Uzatma_yapılmadan_Kuyruğa_Gönderildi = 178, //------------------------------------------------------------------------
        VeriSign_Domain_Uzatma_DomainInfo_Başarısız = 179, //------------------------------------------------------------------------
        VeriSign_Domain_Restore_Başarısız = 180, //------------------------------------------------------------------------
        VeriSign_Domain_Restore_Başarılı = 181, //------------------------------------------------------------------------
        VeriSign_Domain_Restore_Başarılı_Rapor_Gönderme_Başarısız = 182,//------------------------------------------------------------------------

        Admin_VeriSign_Domain_Renew_Successful = 183,//kuyruktan düşürüldü
        Admin_VeriSign_Domain_Register_Command_Completed_Successfully = 184,//kuyruktan düşürüldü
        Admin_VeriSign_Domain_Register_Command_Completed_With_Error = 185,//kuyrukta
        Admin_Borc_Odemesi_Urunun_Islemi_Tamamlandı = 186,//kuyruktan düşürüldü
        Admin_VeriSign_Transfer_Edilmayi_Bekleyen_Domainler = 187,//kuyrukta
        Admin_VeriSign_Transfer_Onayı_Bekleyen_Domainler = 188,//kuyrukta

        isimtescil_Vps_Kiralama_Ödemesi_Alınmış_Uzatılacak_Vps = 189,//kuyrukta
        isimtescil_Sunucu_Kiralama_Ödemesi_Alınmış_Uzatılacak_Sunucu = 189,//kuyrukta
        isimtescil_Vps_Kiralama_Ödemesi_Alınmış_Upgrade_Vps = 190,//kuyrukta
        isimtescil_Sunucu_Kiralama_Ödemesi_Alınmış_Upgrade_Sunucu = 191,//kuyrukta
        isimtescil_Vps_Kiralama_Uzatılan_Vps = 192,//kuyruktan düşürüldü
        isimtescil_Sunucu_Kiralama_Uzatılan_Sunucu = 193,//kuyruktan düşürüldü
        isimtescil_Vps_Kiralama_Upgrade_Tamamlanan_Vps = 194,//kuyruktan düşürüldü
        isimtescil_Sunucu_Kiralama_Upgrade_Tamamlanan_Sunucu = 195,//kuyruktan düşürüldü
        isimtescil_Web_Klavuzu_Kiralama_Ödemesi_Alınmış_Uzatılacak_Web_Klavuzu = 196,//kuyrukta
        isimtescil_Web_Klavuzu_Kiralama_Uzatılan_Web_Klavuzu = 197,//kuyruktan düşürüldü
        isimtescil_SSL_Odemesi_Alınmış_Uzatılacak_SSLler = 198,//kuyrukta
        isimtescil_SSL_Odemesi_Alınmış_Uzatılan_SSLler = 199,//kuyruktan düşürüldü
        isimtescil_Co_Location_Kiralama_Ödemesi_Alınmış_Kaydedilecek = 200,//kuyrukta
        isimtescil_Co_Location_Kiralama_Ödemesi_Alınmış_Kaydedildi = 201,//kuyruktan düşürüldü
        isimtescil_Co_Location_Kiralama_Ödemesi_Alınmış_Uzatılacak = 202,//kuyrukta
        isimtescil_Co_Location_Kiralama_Ödemesi_Alınmış_Uzatılan = 203,//kuyruktan düşürüldü

        isimtescilAdmin_Domain_DBde_Başka_Kullanıcıda_Aktif = 204,//kuyrukta

        isimtescil_MarkaTescil_Kayıt = 205,//Kuyrukta
        isimtescil_MarkaTescil_Tamamlandı = 206,//kuyruktan düşürüldü

        admin_Tucows_Domain_Kayıt_Başarılı = 207,//kuyruktan düşürüldü
        admin_Tucows_Domain_Siparis_Beklemede = 208,//Kuyrukta
        admin_Tucows_Domain_Kayıt_Başarılı_NS_Güncellenemedi = 209,//Kuyrukta
        isimtescil_Tucows_Domain_Kayıt_Başarılı = 210,//kuyruktan düşürüldü
        isimtescil_Tucows_Domain_Siparis_Beklemede = 211,//Kuyrukta
        isimtescil_Tucows_Domain_Kayıt_Başarılı_NS_Güncellenemedi = 212,//Kuyrukta
        isimtescil_Tucows_Domain_Uzatma_Başarılı = 213,//kuyruktan düşürüldü
        isimtescil_Tucows_Domain_Uzatma_Başarısız = 214,//Kuyrukta
        isimtescil_Tucows_Domain_Uzatma_Başarılı_DBde_Uzatma_Başarısız = 215,//Kuyrukta
        isimtescil_admin_kuyruktan_düşürme_manuel = 216,
        isimtescil_PayPal_ile_Alisveris = 217,
        isimtescil_3dSecure_ile_Alisveris = 218,
        Domain_Extra_Uzatma = 219,
        Domain_Uzatma_Bekleniyor = 220,
        isimtescil_hediye_ceki_alisveris = 221,
        isimtescil_hediye_ceki_aktiflendi = 222,
        isimtescil_hediye_ceki_aktiflenemedi = 223,
        isimtescil_EndustriyelTasarim_Kayıt = 224,//Kuyrukta
        isimtescil_EndustriyelTasarim_Tamamlandı = 225,//kuyruktan düşürüldü
        isimtescil_XXX_Onkayit = 226,//kullanılmayacak
        isimtescil_Silinecek_Hosting = 227,//kuyrukta
        isimtescil_Silinecek_Hosting_Silindi = 228,//kuyruktan düşürüldü
        isimtescil_Silinecek_Hosting_Iptal = 229,//kuyruktan düşürüldü

        DomainRegisterConsole_Directi_Domain_Kayit_Basarili = 230,
        DomainRegisterConsole_Directi_Domain_Kayit_Basarisiz = 231,
        DomainRegisterConsole_Rrp_Domain_Kayit_Basarili = 232,
        DomainRegisterConsole_Rrp_Domain_Kayit_Basarisiz = 233,
        DomainRegisterConsole_DotTk_Domain_Kayit_Basarili = 234,
        DomainRegisterConsole_DotTk_Domain_Kayit_Basarisiz = 235,
        DomainRegisterConsole_Verisign_Domain_Kayit_Basarili = 236,
        DomainRegisterConsole_Verisign_Domain_Kayit_Basarisiz = 237,
        DomainRegisterConsole_Tucows_Domain_Kayit_Basarili = 236,
        DomainRegisterConsole_Tucows_Domain_Kayit_Basarisiz = 237,

        Statik_IP_Kayit_Basarili = 238,
        Statik_IP_Kayit_Basarisiz = 239,

        DS_Servisten_Gelen_Cevapta_Hata_Var = 240,//----------------------------------------------------------
        isimtescilAdmin_DS_Domain_Kaydedilirken_Hata_Oluştu = 241,
        isimtescilAdmin_DS_DomainKayıt_İşlemi_Başarılı = 242,

        isimtescil_Mobile_ile_Alisveris = 243
    }
}
