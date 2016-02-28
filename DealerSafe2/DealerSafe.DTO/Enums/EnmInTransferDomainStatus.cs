using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EnmInTransferDomainStatus
    {
        /// <summary>
        /// Başarılı Durumlar
        /// </summary>
        Transfer_Onayi_Bekliyor = 0,
        Transfer_Başlatıldı = 1,
        Transfer_Şifresi_Doğrulandı = 2,
        Transfer_Kayıt_Email_Gönderildi = 4,
        Transfer_Kaydı_Başlatıldı = 5, //Kaydı Başlatıldı.
        Transfer_Şifresi_Yanlış = 6,
        Transfer_Sonlandırıldı = 7, ///Transfer Süreçleri Başarılı işlem sonlandı
        Transfer_Iptal_Edildi = 8, ///Directi Tarafından İptal Edildi.
        Status_Başlatılmadı = 9, ///geçici durum  loga girmicek durum
        Transfer_Kayıt_Email_Alınamadı = 10, //Kaydı Başlatılmadı directiden dönen cvp ara denicek şeklinde dönmekte

        /// <summary>
        /// Hatalı Durumlar Consol
        /// </summary>
        ///     
        Transfer_Şifresi_Servis_Cevap_Vermiyor = 100,
        Server_Transfer_Prohibited = 101,
        Client_Transfer_Prohibited = 102,
        Status_Servis_Cevap_Vermiyor = 103,
        GunlukSurec60 = 104,
        Transfer_Kaydı_Başlatılamadı = 105,
        Status_Pending_Delete = 106,
        AutoRenewPeriod = 107,
        RedemptionPeriod = 108,
        Ok = 3,



        /////
        Manuel_Kontrol_Bekliyor = 200,
        Dosya_Bekliyor = 201,
        Ödeme_Bekliyor = 203,


    }
}
