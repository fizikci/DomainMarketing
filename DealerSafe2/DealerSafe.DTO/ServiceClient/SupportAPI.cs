
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Web;
using DealerSafe.DTO;
using DealerSafe.DTO.Dashboard;
using DealerSafe.DTO.Enums.BCIT;
using DealerSafe.DTO.Support;

namespace DealerSafe.ServiceClient
{
    public class SupportAPI : BaseAPI
    {
        public SupportAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public SupportAPI()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
                this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }


        [Description("")]
        public List<SupportStaff> GetUser(string start, string finish)
        {
            ReqGetUser request = new ReqGetUser { Start = start, Finish = finish };

            return this.Call<List<SupportStaff>, ReqGetUser>(request, "GetUser");
        }

        [Description("")]
        public List<SupportStaff> GetStaff()
        {
            ReqEmpty request = new ReqEmpty { };

            return this.Call<List<SupportStaff>, ReqEmpty>(request, "GetStaff");
        }

        [Description("")]
        public string AddAttach(string ticketId, string ticketPostId, string fileName, string content)
        {
            ReqAddAttach request = new ReqAddAttach { TicketId = ticketId, TicketPostId = ticketPostId, FileName = fileName, Content = content };

            return this.Call<string, ReqAddAttach>(request, "AddAttach");
        }

        [Description("")]
        public string AddStaff(string firstName, string lastName, string userName, string password, string staffGroupId, string email, string mobileNumber)
        {
            ReqAddStaff request = new ReqAddStaff { FirstName = firstName, LastName = lastName, UserName = userName, Password = password, StaffGroupId = staffGroupId, Email = email, MobileNumber = mobileNumber };

            return this.Call<string, ReqAddStaff>(request, "AddStaff");
        }

        [Description("")]
        public string DeleteStaff(string id)
        {
            ReqDeleteStaff request = new ReqDeleteStaff { Id = id };

            return this.Call<string, ReqDeleteStaff>(request, "DeleteStaff");
        }

        [Description("")]
        public int GetUserId(string email)
        {
            ReqGetUserId request = new ReqGetUserId { Email = email };

            return this.Call<int, ReqGetUserId>(request, "GetUserId");
        }

        [Description("")]
        public string AddUser(string fullName, string password, string email)
        {
            ReqAddUser request = new ReqAddUser { FullName = fullName, Password = password, Email = email };

            return this.Call<string, ReqAddUser>(request, "AddUser");
        }

        [Description("")]
        public string UpdateUserEmail(string fullName, string email, int userId)
        {
            ReqUpdateUserEmail request = new ReqUpdateUserEmail { FullName = fullName, Email = email, UserId = userId };

            return this.Call<string, ReqUpdateUserEmail>(request, "UpdateUserEmail");
        }

        [Description("")]
        public string AddTicket(string subject, string fullName, string email, string contents, string departmentId, string ticketStatusId, string ticketPriorityId, string ticketTypeId, string userId)
        {
            ReqAddTicket request = new ReqAddTicket { Subject = subject, FullName = fullName, Email = email, Contents = contents, DepartmentId = departmentId, TicketStatusId = ticketStatusId, TicketPriorityId = ticketPriorityId, TicketTypeId = ticketTypeId, UserId = userId };

            return this.Call<string, ReqAddTicket>(request, "AddTicket");
        }

        [Description("")]
        public List<SupportTickets> GetTicketsHosting(string userId, string ownerStaffIds, string ticketStatusId)
        {
            ReqGetTickets request = new ReqGetTickets { UserId = userId, OwnerStaffIds = ownerStaffIds, TicketStatusId = ticketStatusId };

            return this.Call<List<SupportTickets>, ReqGetTickets>(request, "GetTicketsHosting");
        }

        
        [Description("")]
        public List<SupportTickets> GetLast5Tickets(string userId)
        {
            ReqGetTickets request = new ReqGetTickets { UserId = userId };

            return this.Call<List<SupportTickets>, ReqGetTickets>(request, "GetLast5Tickets");
        }

        [Description("")]
        public List<SupportTickets> GetTickets(string userId, string ownerStaffIds, string ticketStatusId)
        {
            ReqGetTickets request = new ReqGetTickets { UserId = userId, OwnerStaffIds = ownerStaffIds, TicketStatusId = ticketStatusId };

            return this.Call<List<SupportTickets>, ReqGetTickets>(request, "GetTickets");
        }

        [Description("")]
        public SupportTickets GetTicket(string ticketId)
        {
            ReqGetTicket request = new ReqGetTicket { TicketId = ticketId };

            return this.Call<SupportTickets, ReqGetTicket>(request, "GetTicket");
        }

        [Description("")]
        public string UpdateTicketStatus(string id, string ticketStatusId)
        {
            ReqUpdateTicketStatus request = new ReqUpdateTicketStatus { Id = id, TicketStatusId = ticketStatusId };

            return this.Call<string, ReqUpdateTicketStatus>(request, "UpdateTicketStatus");
        }

        [Description("")]
        public string TicketPost(string ticketId, string subject, string contents, string userId)
        {
            ReqTicketPost request = new ReqTicketPost { TicketId = ticketId, Subject = subject, Contents = contents, UserId = userId };

            return this.Call<string, ReqTicketPost>(request, "TicketPost");
        }

        [Description("")]
        public string TicketPostStaff(string ticketId, string subject, string contents, string staffId)
        {
            ReqTicketPostStaff request = new ReqTicketPostStaff { TicketId = ticketId, Subject = subject, Contents = contents, StaffId = staffId };

            return this.Call<string, ReqTicketPostStaff>(request, "TicketPostStaff");
        }

        [Description("")]
        public List<SupportPosts> GetTicketsPosts(string ticketId)
        {
            ReqGetTicketsPosts request = new ReqGetTicketsPosts { TicketId = ticketId };

            return this.Call<List<SupportPosts>, ReqGetTicketsPosts>(request, "GetTicketsPosts");
        }

        [Description("")]
        public List<SupportListItem> TicketDepartmentList()
        {
            ReqEmpty request = new ReqEmpty { };

            return this.Call<List<SupportListItem>, ReqEmpty>(request, "TicketDepartmentList");
        }

        [Description("")]
        public List<SupportListItem> TicketStatusList()
        {
            ReqEmpty request = new ReqEmpty { };

            return this.Call<List<SupportListItem>, ReqEmpty>(request, "TicketStatusList");
        }

        [Description("")]
        public List<SupportListItem> TicketPriorityList()
        {
            ReqEmpty request = new ReqEmpty { };

            return this.Call<List<SupportListItem>, ReqEmpty>(request, "TicketPriorityList");
        }

        [Description("")]
        public List<SupportListItem> TicketTypeList()
        {
            ReqEmpty request = new ReqEmpty { };

            return this.Call<List<SupportListItem>, ReqEmpty>(request, "TicketTypeList");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["SupportServiceURL"]; ;
        }
    }
}
