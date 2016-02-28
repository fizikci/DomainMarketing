using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO
{
    public class ReqAddCreditForRejection
    {
        public int MemberID { get; set; }
        public double CreditAmount { get; set; }
        public enmCreditReportType CreditReportType { get; set; }
        public int ID { get; set; }
    }
    public enum enmCreditReportType
    {
        Admin_Siparis_Silme = 1, Siparis_Detay_Silme = 2, Admin_Manuel_Kredi_Ekleme = 3, Admin_Manuel_Kredi_Cikarma = 4, Admin_Kredili_Onaylanmis_Siparis = 5,
        Admin_Silinmis_Kredi = 6, Isimtescil_Kredili_Siparis = 7, Admin_Kredi_Alma_Onay = 8, Admin_Kuyruk_Kredi_Alma_Onay = 9, Admin_Ödeme_Fazlası_Aktarıldı = 10,
        Admin_Havale_Kredi_Alma_Aktiflendi = 11, Admin_Borçlu_Bakiye_Ödeme_Onayı = 12, Isimtescil_Kredi_Kartı_Kredi_Alma = 13, Admin_Siparis_Detay_Silme = 14,
        IsimTescil_Parca_Kredi_Geri_Aktarıldı = 15, IsimTescil_Parca_Kredi_Cekildi = 16
    }
}
