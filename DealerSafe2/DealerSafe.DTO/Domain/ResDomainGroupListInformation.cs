using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DealerSafe.DTO.Domain
{
    public class ResDomainGroupListInformation
    {
        public int TldId { get; set; }
        public string TldName { get; set; }
        public int TldPopularite { get; set; }
        public List<GroupsName> LGroupName { get; set; }
        public TldStatus TldStatu { get; set; }
    }


    public class GroupsName
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }


    public class TldStatus
    {
        public TldStatus_Enum Statu_Enum { get; set; }
        public string Statu_EndDate { get; set; }
        public string Statu_StartDate { get; set; }
        public bool FavoriteSendStatu { get; set; }
    }


    public enum TldStatus_Enum
    {
        GeneralAvalible = 1,
        SunRise = 2,
        LandRush = 3,
        OnTalep = 4,
        Favorite = 5
    }
}
