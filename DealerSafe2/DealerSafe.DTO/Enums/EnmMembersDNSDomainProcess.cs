using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Enums
{
    public enum EnmMembersDNSDomainProcess
    {
        Kuyruktan_Dusurme_islemi = 0,
        Kaydolmayi_Bekleyen_Domainler = 1,
        Uzatilmayi_Bekleyen_Domainler = 2,
        Transfer_Edilmeyi_Bekleyen_Domainler = 3,
        transfer_Onayi_Bekleyen_Domainler = 4,
        Transfer_Dışarı_Bekleyen = 5
    }
}
