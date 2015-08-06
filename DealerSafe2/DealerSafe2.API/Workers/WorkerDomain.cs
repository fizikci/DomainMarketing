using System;
using System.Collections.Generic;
using DealerSafe2.API.Entity.Jobs;
using DealerSafe2.API.Entity.Orders;
using DealerSafe2.DTO.EntityInfo;
using DealerSafe2.DTO.Enums;
using System.Linq;
using DealerSafe2.API.Entity.Products.Domain;
using DealerSafe.ServiceClient;
using DealerSafe2.API.Entity.Members;
using DealerSafe.DTO.Epp.Request;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol.Domains;
using Epp.Protocol.Hosts;


namespace DealerSafe2.API.Workers
{
    public class WorkerDomain : BaseWorker
    {
        public override void CreateJobsFor(Order order)
        {
            foreach (var item in order.Items.Where(item => item.Product().ProductType().Name == "DOMAIN"))
            {
                switch (item.ProductPrice().ProductPriceType)
                {
                    case ProductPriceTypes.Create:
                        Provider.Database.Execute(() => {
                            var job = new Job()
                            {
                                Command = JobCommands.DomainRegister,
                                Name = item.DisplayName,
                                RelatedEntityName = "OrderItem",
                                RelatedEntityId = item.Id,
                                State = JobStates.NotStarted,
                                Executer = JobExecuters.Machine
                            };
                            job.Save();
                        });
                        break;

                    case ProductPriceTypes.Renew:
                        new Job()
                        {
                            Command = JobCommands.DomainRenewal,
                            Name = item.DisplayName,
                            RelatedEntityName = "OrderItem",
                            RelatedEntityId = item.Id,
                            State = JobStates.NotStarted,
                            Executer = JobExecuters.Machine
                        }.Save();
                        break;

                    case ProductPriceTypes.Restore:
                        new Job()
                        {
                            Command = JobCommands.DomainRestore,
                            Name = item.DisplayName,
                            RelatedEntityName = "OrderItem",
                            RelatedEntityId = item.Id,
                            State = JobStates.NotStarted,
                            Executer = JobExecuters.Machine
                        }.Save();
                        break;

                    case ProductPriceTypes.Transfer:
                        new Job()
                        {
                            Command = JobCommands.DomainTransfer,
                            Name = item.DisplayName,
                            RelatedEntityName = "OrderItem",
                            RelatedEntityId = item.Id,
                            State = JobStates.NotStarted,
                            Executer = JobExecuters.Machine
                        }.Save();
                        break;

                    default:
                        break;
                }
            }
        }

        public override void Execute(Job job)
        {
            switch (job.Command)
            {
                case JobCommands.DomainRegister:
                    domainRegister(job.RelatedEntityId);
                    break;
                case JobCommands.DomainRenewal:
                    break;
                case JobCommands.DomainTransfer:
                    break;
                case JobCommands.DomainRestore:
                    break;
                default:
                    break;
            }

            job.State = JobStates.Done;
        }

        private void domainRegister(string orderItemId)
        {
            //var orderItem = Provider.Database.Read<OrderItem>("Id={0}", orderItemId);
            //var member = orderItem.Order().Member();

            //var memberDomain = 
            //    Provider.Database.Read<MemberDomain>("DomainName={0}", orderItem.DisplayName) 
            //    ??
            //    member.CreateNewMemberDomain(orderItem.DisplayName, orderItem.Id);

            //if (memberDomain.Created)
            //    throw new Exception("Domain name already created (" + orderItem.DisplayName + ")");

            //// Aşağıdaki işlemler RFC 5731 dikkate alınarak yazılmıştır. (https://tools.ietf.org/html/rfc5731#page-18)
            //var eppApi = new EppAPI();

            //var req = new ReqDomainCreate();

            //// 1. ContactCheck
            //var reqContactCheck = new ReqContactCheck();

            //// 1.1. contact id'lerin hepsini bir seferde check edelim
            //if(!memberDomain.OwnerDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.OwnerDomainContactId);
            //if(!memberDomain.AdminDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.AdminDomainContactId);
            //if(!memberDomain.BillingDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.BillingDomainContactId);
            //if(!memberDomain.TechDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.TechDomainContactId);

            //var resContactCheck = eppApi.ContactCheck(reqContactCheck);

            //// 1.2. eğer registry tarafında contact create edilmemişse create edelim
            //if (!memberDomain.OwnerDomainContactId.IsEmpty())
            //{
            //    if(resContactCheck.IsAvailable(memberDomain.OwnerDomainContactId))
            //        createContact(memberDomain.OwnerDomainContactId, eppApi);
            //    req.Registrant = memberDomain.OwnerDomainContactId;
            //}
            //if (!memberDomain.AdminDomainContactId.IsEmpty())
            //{
            //    if(resContactCheck.IsAvailable(memberDomain.AdminDomainContactId))
            //        createContact(memberDomain.AdminDomainContactId, eppApi);
            //    req.Contacts.Add(new DomainContactInfo(memberDomain.AdminDomainContactId, DomainContactInfo.ContactType.Admin));
            //}
            //if (!memberDomain.BillingDomainContactId.IsEmpty())
            //{
            //    if(resContactCheck.IsAvailable(memberDomain.BillingDomainContactId))
            //        createContact(memberDomain.BillingDomainContactId, eppApi);
            //    req.Contacts.Add(new DomainContactInfo(memberDomain.BillingDomainContactId, DomainContactInfo.ContactType.Billing));
            //}
            //if (!memberDomain.TechDomainContactId.IsEmpty())
            //{
            //    if(resContactCheck.IsAvailable(memberDomain.TechDomainContactId))
            //        createContact(memberDomain.TechDomainContactId, eppApi);
            //    req.Contacts.Add(new DomainContactInfo(memberDomain.TechDomainContactId, DomainContactInfo.ContactType.Tech));
            //}

            //// 2. Nameserver'ları set edelim
            //if (!memberDomain.NameServers.IsEmpty())
            //    foreach (string host in memberDomain.NameServers.SplitWithTrim(";"))
            //    {
            //        if (host.Contains(','))
            //        {
            //            var parts = host.SplitWithTrim(","); //TODO: IPv6'yı da desteklemek gerekecek gibi
            //            req.NameServers.Add(new NameServerInfo { HostName = parts[0], Addresses = new List<IpAddress> { new IpAddress {Address = parts[1], Type = IpAddress.IpAddressType.V4} } });
            //        }
            //        else
            //            req.NameServers.Add(new NameServerInfo { HostName = host });
            //    }

            //// 3. The domain name itself
            //req.DomainName = memberDomain.DomainName;

            //// 4. Period
            //req.RegistrationPeriod = new DomainPeriod { 
            //    Units = orderItem.ProductPrice().Unit == "years" ? DomainPeriod.PeriodUnits.Year : DomainPeriod.PeriodUnits.Month,
            //    Period = orderItem.Amount
            //};

            //// 5. AuthInfo
            //req.AuthInfo = new Epp.Protocol.Shared.AuthInfo(memberDomain.AuthInfo);

            //var res = eppApi.DomainCreate(req);

            //memberDomain.StartDate = res.CreateDate;
            //memberDomain.EndDate = res.ExpireDate.Value;

        }

        private ResContactCreate createContact(string contactId, EppAPI eppApi)
        {
            var domainContact = Provider.Database.Read<DomainContact>("Id={0}", contactId);
            if (domainContact == null) throw new Exception("Supplied contact ID is available on registry but there is no record with that ID in the table DomainContact");
            return eppApi.ContactCreate(domainContact.ConvertToReqContactCreate());
        }

        public override int GetMaxTryCount(JobCommands jobCommand)
        {
            return 1;
        }

        public override List<DashboardItem> GetDashboardMessages()
        {
            var res = new List<DashboardItem>();
            return res;
        }


        public override Departments GetWorkerDepartment()
        {
            return Departments.Domain;
        }
    }
}