using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Mark
{
    public class BrandStaticsForDashBoardInfo
    {
        public bool Process { get; set; }
        public StaticDetail GeneralStatics { get; set; }
    }
    public class StaticDetail
    {
        public int OnInceleme { get; set; }
        public int BelgeBekleyen { get; set; }
        public int BasvuruBekleyen { get; set; }
        public int BasvuruYapilan { get; set; }
        public int IptalEdilen { get; set; }
        public int EkOdemeBekleyen { get; set; }
        public int KargoBekleyen { get; set; }
        public int TescilBelgesiGonderilen { get; set; }
        public int MusaitMarkaSinifDekontlari { get; set; }
        public int MusaitItirazDekontlari { get; set; }
        public int MarkaTescil { get; set; }
        public int MarkaBelgeDuzenleme { get; set; }
        public int MarkaDiger { get; set; }
    }
}
