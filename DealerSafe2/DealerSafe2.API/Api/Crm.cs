using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml;
using DealerSafe2.API.Entity.Common;
using DealerSafe2.API.Entity.Crm;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Workers;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.EntityInfo.Crm;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using DealerSafe2.API.Api.Library;
using System.Configuration;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        #region Crm

        public bool SaveFeedback(FeedbackInfo feedback)
        {
            if (string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
            {
                var f = new Feedback();
                feedback.CopyPropertiesWithSameName(f);
                f.Save();

                Job j = new Job()
                    {
                        Command = JobCommands.NewFeedback,
                        Executer = JobExecuters.Staff,
                        ExecuterId = Provider.Api.GetNextIdleStaffMemberId(f.Department),
                        Name = "New feedback from visitor",
                        RelatedEntityName = "Feedback",
                        RelatedEntityId = f.Id,
                        State = JobStates.NotStarted
                    };

                j.Save();
            }
            else
            {
                return SaveCrmActivity(new CrmActivityInfo()
                    {
                        ActivityType = ActivityTypes.Form,
                        Department = feedback.Department,
                        MemberId = Provider.CurrentMember.Id,
                        Message = feedback.Message,
                        Subject = feedback.Subject
                    });
            }

            return true;
        }


        public bool SaveCrmActivity(CrmActivityInfo req)
        {
            if(string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
                throw new APIException("Access is denied");

            var cr = new CrmActivity();
            req.CopyPropertiesWithSameName(cr);
            cr.MemberId = Provider.CurrentMember.Id;
            cr.Save();

            Job j = new Job()
                {
                    Command = JobCommands.NewTicket,
                    Executer = JobExecuters.Staff,
                    ExecuterId = Provider.CurrentMember.StaffMemberId.IsEmpty() ? Provider.Api.GetNextIdleStaffMemberId(Departments.Marketing) : Provider.CurrentMember.StaffMemberId,
                    Name = "New ticket from " + cr.Member().FullName,
                    RelatedEntityName = "CrmActivity",
                    RelatedEntityId = cr.Id,
                    State = JobStates.NotStarted
                };

            j.Save();

            return true;
        }

        public bool SaveCrmActivityMessage(CrmActivityMessageInfo req)
        {
            if (string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
                throw new APIException("Access is denied");

            var cr = new CrmActivityMessage();
            req.CopyPropertiesWithSameName(cr);
            cr.MemberId = Provider.CurrentMember.Id;
            cr.Save();

            return true;
        }

        public List<CrmActivityInfo> GetCrmActivities(ReqEmpty req)
        {
            if (string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
                throw new APIException("Access is denied");

            var entities =
                Provider.Database.ReadList<CrmActivity>(
                    @"
                        SELECT 
                            ca.*,
                            j.State
                        FROM 
                            CrmActivity ca, Job j
                        WHERE 
                            j.RelatedEntityId = ca.Id AND
                            j.RelatedEntityName = 'CrmActivity' AND
                            ca.MemberId = {0} AND 
                            ca.IsDeleted = 0
                        ORDER BY
                            ca.InsertDate desc", Provider.CurrentMember.Id);

            var dtos = new List<CrmActivityInfo>();

            foreach (var e in entities)
            {
                var dto = new CrmActivityInfo();
                e.CopyPropertiesWithSameName(dto);
                dto.State = (JobStates)Enum.Parse(typeof(JobStates), (string)e["State"]);
                dto.ReplyCount = Provider.Database.GetInt("select count(*) from CrmActivityMessage where CrmActivityId = {0}", e.Id);

                dtos.Add(dto);
            }

            return dtos;
        }

        public List<CrmActivityMessageInfo> GetCrmActivityMessages(string crmActivityId)
        {
            if (string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
                throw new APIException("Access is denied");

            var entities =
                Provider.Database.ReadList<CrmActivityMessage>(
                    @"
                        SELECT 
                            m.*,
                            u.FirstName + ' ' + u.LastName as MemberName
                        FROM 
                            CrmActivityMessage as m, Member u
                        WHERE 
                            u.Id = m.MemberId AND
                            m.CrmActivityId = {0} AND
                            m.IsDeleted = 0
                        ORDER BY
                            m.InsertDate desc", crmActivityId);

            var dtos = new List<CrmActivityMessageInfo>();

            foreach (var e in entities)
            {
                var dto = new CrmActivityMessageInfo();
                e.CopyPropertiesWithSameName(dto);
                dto.MemberName = (string)e["MemberName"];

                dtos.Add(dto);
            }

            return dtos;
        }

        #endregion
    }


}