using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DealerSafe.DTO.Enums;

namespace DealerSafe.DTO.Common
{
    public class ReqStaffNoticeCampaign
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public short Benefit { get; set; }
        public string RelatedProducts { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public short ImplamentationType { get; set; }
    }

    public class ResStaffNoticeCampaign
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public short Benefit { get; set; }
        public string RelatedProducts { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public short ImplamentationType { get; set; }

    }

    
    public class ReqStaffNoticeGoal
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Decimal TurnoverTarget { get; set; }
        public Decimal TurnoverActual { get; set; }
        public Decimal TurnoverAward { get; set; }
        public int AwardRate { get; set; }
        public short ProductGroup { get; set; }
        public string ProductOperations { get; set; }
    }
    public class ResStaffNoticeGoal
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Decimal TurnoverTarget { get; set; }
        public Decimal TurnoverActual { get; set; }
        public Decimal TurnoverAward { get; set; }
        public int AwardRate { get; set; }
        public short ProductGroup { get; set; }
        public string ProductOperations { get; set; }
    }

    public class ReqStaffNoticeOffer
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public short Subject { get; set; }
        public string Content { get; set; }
        public string Reason { get; set; }
        public int Executive { get; set; }
        public short GroupFlag { get; set; }
        public int MemberId { get; set; }
        public short Situation { get; set; }
    }
    public class ResStaffNoticeOffer
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public short Subject { get; set; }
        public string Content { get; set; }
        public string Reason { get; set; }
        public int Executive { get; set; }
        public short GroupFlag { get; set; }
        public int MemberId { get; set; }
        public string MemberNameSurname { get; set; }
        public short Situation { get; set; }
    }

    public class ReqStaffNoticeOfferSearch
    {
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public short Situation { get; set; }
        public short Subject { get; set; }
        public string Search { get; set; }
    }
    public class ReqStaffNotices
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public int MemberId { get; set; }
        public DateTime InsertDate { get; set; }
    }


    public class ResStaffNotices
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public int MemberId { get; set; }
        public string MemberNameSurname { get; set; }
        public DateTime InsertDate { get; set; }


    }

    public class NoticeModel
    {
        public List<ResStaffNoticeCampaign> Campaigns { get; set; }
        public List<ResStaffNoticeGoal> Goals { get; set; }
        public ResStaffNoticeOffer Offers { get; set; }
        public List<ResStaffNotices> Notices { get; set; }
        public List<ResStaffNoticeGoal> GoalList { get; set; }
        public bool Edit { get; set; }
        public int MemberId { get; set; }
    }

    public class ReqStaffNoticeCampaignSearch
    {
        public string SearchKey { get; set; }

        public EnmStaffNotice.CampaignStatusType CampaignStatus { get; set; }
    }

    public class ResStaffDepartments
    {
        public int sdId { get; set; }
        public int sdStatus { get; set; }
        public DateTime sdCreateDate { get; set; }
        public string sdName { get; set; }
        public string sdNameTr { get; set; }
    }

    public class ReqStaffDepartments
    {
        public int sdId { get; set; }
    }
    public class ResStaff
    {
        public int StaffId { get; set; }
        public int StaffDepartmentId { get; set; }
    }
    public class ReqStaff
    {
        public int stfId { get; set; }
    }
    
}

