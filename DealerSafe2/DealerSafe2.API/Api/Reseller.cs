using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http.Description;
using DealerSafe2.API.Api.Library;
using DealerSafe2.API.Entity.ApiRelated;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Members;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.API.Workers;
using DealerSafe2.DTO;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using DealerSafe2.DTO.Request;
using DealerSafe2.DTO.Response;
using DealerSafe2.API.Api;

namespace DealerSafe2.API
{
    public partial class ApiJson
    {
        public List<ResellerTypeInfo> GetResellerTypes(ReqEmpty req)
        {
            return Provider.Database.ReadList<ResellerType>().ToEntityInfo<ResellerTypeInfo>();
        }

        public bool ApplyForResellership(ReqApplyForResellership req)
        {
            if(string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
                return false;

            string resellerTypeId = req.ResellerTypeId;

            if(Provider.CurrentMember.Reseller()!=null)
                throw new APIException("You have already applied for resellership.");

            ResellerType rt = Provider.Database.Read<ResellerType>("Id = {0}", resellerTypeId);

            if(Provider.CurrentMember.CreditBalance < rt.PrePaidCreditAmount)
                throw new APIException("You have not enough credits to apply this resellership. (Min amount: " + (rt.PrePaidCreditAmount/100) + ")");

            Reseller r = new Reseller();
            rt.CopyPropertiesWithSameName(r);
            r.ResellerEndDate = Provider.Database.Now.AddDays(rt.ValidityInDays);
            r.Id = Provider.CurrentMember.Id;
            r.ResellerTypeId = rt.Id;
            Provider.Database.Insert("Reseller", Provider.Database.EntityToHashtable(r), false);

            r.Member().MemberType = MemberTypes.Reseller;
            r.Member().Medal = rt.Id;
            r.Member().Save();

            return true;
        }

        public bool ApplyForMdf(string mdfId)
        {
            if (string.IsNullOrWhiteSpace(Provider.CurrentMember.Id))
                throw new APIException("Access is denied");

            Mdf mdf = Provider.Database.Read<Mdf>("Id={0}", mdfId);
            if (mdf == null)
                throw new APIException("No such MDF");

            Reseller r = Provider.Database.Read<Reseller>("Id={0}", Provider.CurrentMember.Id);
            if (r == null)
                throw new APIException("Only resellers can apply for MDFs.");

            if (mdf.ResellerTypeId != r.ResellerTypeId)
                throw new APIException("Your resellership type is not suitable to apply this MDF");

            if (!r.CanJoinMdf)
                throw new APIException("Your resellership type is not suitable to apply any MDF");

            MdfReseller mr = Provider.Database.Read<MdfReseller>("MdfId={0} AND ResellerId={1}", mdfId, Provider.CurrentMember.Id);
            if (mr == null)
                mr = new MdfReseller() {MdfId = mdfId, ResellerId = Provider.CurrentMember.Id};
            mr.State = MdfStates.Waiting;
            mr.Save();

            Job j = new Job
                {
                    Command = JobCommands.MdfApplication,
                    State = JobStates.NotStarted,
                    Executer = JobExecuters.Staff,
                    ExecuterId = string.IsNullOrWhiteSpace(Provider.CurrentMember.StaffMemberId) ? Provider.Api.GetNextIdleStaffMemberId(Departments.Marketing) : Provider.CurrentMember.StaffMemberId,
                    Name = "Confirm MDF application by " + Provider.CurrentMember.FullName,
                    RelatedEntityName = "MdfReseller",
                    RelatedEntityId = mr.Id,
                    StartDate = Provider.Database.Now
                };
            j.Save();

            return true;
        }

        public List<MdfResellerInfo> GetMdfList(ReqEmpty req)
        {
            return Provider.Database.GetDataTable(@"
                    select
	                    m.Id as MdfId,
	                    m.Name,
	                    m.StartDate,
	                    m.EndDate,
	                    m.RebateRate,
	                    m.RebateAmount,
	                    m.LimitBottom,
	                    mr.Id,
	                    mr.State,
	                    mr.CreditsToRefund
                    from 
	                    Mdf m
	                    LEFT JOIN MdfReseller mr ON mr.MdfId = m.Id AND mr.ResellerId = {0}
                    where
	                    m.ResellerTypeId = {1} AND
	                    m.AnnounceStartDate<=getdate() AND
	                    m.AnnounceEndDate>=getdate();
                    ", Provider.CurrentMember.Id, Provider.CurrentMember.Reseller().ResellerTypeId)
                        .ToEntityList<MdfResellerInfo>();
        }
        public MdfInfo GetMdf(string mdfId)
        {
            return Provider.Database.Read<Mdf>("Id={0}", mdfId).ToEntityInfo<MdfInfo>();
        }
    }
}