using System.ComponentModel;

namespace DealerSafe.DTO.Payment
{
    public class ReqGetCompanies
    {
        [Description("Identity number of the company")]
        public int CompanyID { get; set; }

        [Description("Status of the company")]
        public bool IsActive { get; set; }
    }
}
