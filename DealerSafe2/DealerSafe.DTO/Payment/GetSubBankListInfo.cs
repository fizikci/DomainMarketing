using System.Collections.Generic;
using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class GetSubBankListInfo
    {
        public List<BankDetail> BankList { get; set; }
        public class BankDetail
        {
            public int Id { get; set; }
            public int CompanyId { get; set; }
            public int BankID { get; set; }
            public string CardName { get; set; }
            public string XmlLocation { get; set; }
            public bool Status { get; set; }
            public int Check3D { get; set; }
        }
    }
}
