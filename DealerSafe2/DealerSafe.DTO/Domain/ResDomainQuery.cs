using System.Collections.Generic;

namespace DealerSafe.DTO.Domain
{
    public class ResDomainQuery
    {
        public List<DomainQueryResult> DomainQueryResults { get; set; }
    }

    public class DomainQueryResult
    {
        public string DomainName { get; set; }
        public string TLD { get; set; }
        public string Note { get; set; }
        public string Period { get; set; }
        public DomainQueryStatus Status { get; set; }
        public float Price { get; set; }
        public float PromotedPrice { get; set; }

        public RegisterCompanies QueryCompanyId;
        public RegisterCompanies AlternativeCompanyId;
        public int ProcessCode;
        public int MinLength;
        public int MaxLength;
        public string CampaignDescription;
        public string CampaignName;
        public int TLDId;
    }

    public enum DomainQueryStatus
    {
        NotAvailable,
        Available,
        Error
    }

    public enum RegisterCompanies
    {
        Directi = 1,
        RRP = 2,
        ODTU = 4,
        DotTK = 5,
        Tucows = 7,
        DealerSafe = 10
    }

    /// <summary>
    /// Domain kayıt konsolu bu alan ile domain tipine göre işlem yapacaktır.
    /// NotSaving , Oto kayıt kapalı
    /// DefaultSave , Oto kayıt açık default contact ve name serverlar kullanılacak.
    /// CustomSave , Oto kayıt açık müşteri bilgilerinden contact oluşturulacak.
    /// </summary>
    public enum AutoRegister
    {
        NotSaving = 0,
        DefaultSave = 1,
        CustomSave = 2,
    }
}
