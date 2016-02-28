using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EnmOutTransferDomainProcess
    {
        Dışarıya_Transfer_Başladı = 1,
        Dışarı_Transfer_Oldu_Consol = 2,
        Dışarı_Transfer_Süreci_Iptal_Oldu_Consol_10_günlük_süreç_doldu = 3,
        Dışarı_Transfer_Süreci_Iptal_Oldu_Müşteri_İptal_Etti = 4,
        Dışarı_Transfer_Süreci_Iptal_Oldu_Staff_İptal_Etti = 5
    }
}
