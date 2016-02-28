using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DealerSafe.Utility;

namespace DealerSafe.DTO.Hosting
{
    [Serializable]
    public class SupportInfo
    {
        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "{0} alaný gereklidir")]
        [Display(Name = "Mesaj")]
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ReplyDate { get; set; }
        //public SelectList Status { get; set; }
        public int TicketId { get; set; }
        public string SecurityId
        {
            get
            {
                return Encryption.Encrypt(TicketId.ToString());
            }
            set
            {

            }
        }
        public string PostId { get; set; }
        public DateTime DateLine { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public string StaffId { get; set; }

        //public string StaffName
        //{
        //    get { return GetStaffName(); }
        //    set { }
        //}

        //public string GetStaffName()
        //{
        //    var kyk = new BCIT.Kayako_5();
        //    var staff = kyk.GetStaff();
        //    for (int i = 0; i < staff.Count; i++)
        //    {
        //        if (!string.IsNullOrEmpty(StaffId))
        //            if (staff[i].id == Int32.Parse(StaffId))
        //            {
        //                return staff[i].fullname;
        //            }
        //    }
        //    return "Hosting Departmaný";
        //}

    }
}
