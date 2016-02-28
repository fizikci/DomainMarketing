using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Orders
{
    public class ReqAddOrder
    {
        public int PaymentType { get; set; }
        public string IName { get; set; }
        public string IAdres { get; set; }
        public string TOffice { get; set; }
        public string TNumber { get; set; }
        public string Ip { get; set; }
        public string BankID { get; set; }
        public string Rate { get; set; }
        public BasketDetail Sepet {get;set;}
        public PaymentFlag Payflag { get; set; }
    }
    public class PaymentFlag
    {
        //kupon işlemleri bölümü
        public bool IsCouponUsable { get; set; }
        public string CouponCode { get; set; }
        public double CouponAmountTL { get; set; }
        public double CouponUnexpendedValue { get; set; }
        //kredi işlemleri bölümü
        public bool IsCreditUsable { get; set; }
        public double CreditAmaountTL { get; set; }

        //kargo işlemleri bölümü
        public double ShippingCostUSD { get; set; }

        //Hizmet bedeli işlemleri bölümü
        public double OperationCostUSD { get; set; }
        public double OperationCostTL { get; set; }

        //ödeme tercihi ile ilgili bölüm
        public int PaymentChoice { get; set; }
        public int PaymentChoiceInstallment { get; set; }
        public int PaymentChoiceBankId { get; set; }
        public int PaymentChoiceSubBankId { get; set; }
        public double PaymentChoiceCommisionRate { get; set; }

        //Hesap özeti bölümü
        public double HesapOzetikdvMatrahiTL { get; set; }
        public double HesapOzetihizmetBedeliTL { get; set; }
        public double HesapOzetishippingCostTL { get; set; }
        public double HesapOzetikdvTutariTL { get; set; }
        public double HesapOzetikrediTutariTL { get; set; }
        public double HesapOzetikuponTutariTL { get; set; }
        public double HesapOzetiBankaKomisyonTutariTL { get; set; }
        public double HesapOzetitoplamTutarTL { get; set; }

        //Ek Bölüm PayPal Ülke Seçimi
        public int PayPalCountry { get; set; }
    }
}
