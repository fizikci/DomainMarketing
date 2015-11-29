using System;
using System.Collections.Generic;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;

namespace DealerSafe2.API.Workers
{
    public class WorkerMembership : BaseWorker
    {
        public override void CreateJobsFor(Order order)
        {
        }

        public override void Execute(Job job)
        {
        }

        public override int GetMaxTryCount(JobCommands jobCommand)
        {
            return 1;
        }

        public override List<DashboardItem> GetDashboardMessages()
        {
            var res = new List<DashboardItem>();

            if (string.IsNullOrWhiteSpace(Provider.Api.Session.Member().Password))
            {
                res.Add(new DashboardItem()
                {
                    Title = "You must set your password",
                    Description = "Because you signed up with quick signup form, you don't have password yet.",
                    Link="PassPreferences.aspx",
                    LinkText = "Set your password"
                });
            }

            if (Provider.CurrentMember.State == MemberStates.WaitingEmailConfirmation)
            {
                res.Add(new DashboardItem()
                {
                    Title = "Confirm your email address",
                    Description = "Your email address ("+Provider.CurrentMember.Email+") is not confirmed yet.",
                    Type = "JS",
                    Link = "confirmEmail()",
                    LinkText = "Receive confirmation message"
                });
            }

            if (Provider.Api.GetMemberBasket(null).Items.Count>0)
            {
                res.Add(new DashboardItem()
                {
                    Title = "You have items in your basket",
                    Description = "",
                    Link = "Checkout.aspx",
                    LinkText = "View your basket"
                });
            }

            return res;
        }

        public override Departments GetWorkerDepartment()
        {
            return Departments.Marketing;
        }

    }
}