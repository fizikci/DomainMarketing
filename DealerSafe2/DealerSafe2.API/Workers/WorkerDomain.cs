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
using DealerSafe2.API.Entity.Products;
using DealerSafe.DTO.Epp.Protocol.Rgp;
using DealerSafe2.DTO;


namespace DealerSafe2.API.Workers
{
    public class WorkerDomain : BaseWorker
    {
        public override void CreateJobsFor(Order order)
        {
            foreach (var item in order.Items.Where(item => item.Product().ProductTypeId.ToLowerInvariant() == "domain"))
            {
                switch (item.ProductPrice().ProductPriceType)
                {
                    case ProductPriceTypes.Create:
                        new Job()
                        {
                            Command = JobCommands.DomainRegister,
                            Name = item.DisplayName,
                            RelatedEntityName = "OrderItem",
                            RelatedEntityId = item.Id,
                            State = JobStates.NotStarted,
                            Executer = JobExecuters.Machine
                        }.Save();
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
                            Command = JobCommands.DomainTransferRequest,
                            Name = item.DisplayName,
                            RelatedEntityName = "OrderItem",
                            RelatedEntityId = item.Id,
                            State = JobStates.NotStarted,
                            Executer = JobExecuters.Member, // müşterinin authcode girmesi için bu job'ı müşteriye atıyoruz
                            ExecuterId = order.MemberId
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
                    job.State = domainRegister(job);
                    break;
                case JobCommands.DomainRenewal:
                    job.State = domainRenew(job);
                    break;
                case JobCommands.DomainTransferRequest:
                    job.State = domainTransferRequest(job);
                    break;
                case JobCommands.DomainTransferQuery:
                    job.State = domainTransferQuery(job);
                    break;
                case JobCommands.DomainRestore:
                    job.State = domainRestore(job);
                    break;
                case JobCommands.DomainCancel:
                    job.State = domainCancel(job);
                    break;
                case JobCommands.ReadPollMessages:
                    job.State = readPollMessages(job);
                    break;
                case JobCommands.HandlePollMessage:
                    job.State = handlePollMessage(job);
                    break;
                default:
                    break;
            }
        }

        #region job implementations

        private JobStates domainRegister(Job job)
        {
            var orderItem = Provider.Database.Read<OrderItem>("Id={0}", job.RelatedEntityId);
            if (orderItem == null) throw new Exception("OrderItem not found (in worker method domainRegister)");

            var domainName = orderItem.DisplayName;

            var member = orderItem.Order().Member();

            var memberDomain =
                Provider.Database.Read<MemberDomain>("DomainName={0}", domainName)
                ??
                member.CreateNewMemberDomain(orderItem.DisplayName, orderItem.Id);

            var memberProduct = Provider.Database.Read<MemberProduct>("Id={0}", memberDomain.Id);

            if (memberProduct.CurrentPhase != LifeCyclePhases.None)
                throw new Exception("Domain name (" + domainName + " #" + memberDomain.Id + ") already created (in worker method domainRegister)");

            var product = memberProduct.OrderItem().Product();

            // Aşağıdaki işlemler RFC 5731 dikkate alınarak yazılmıştır. (https://tools.ietf.org/html/rfc5731#page-18)
            var eppApi = new EppAPI();

            var req = new ReqDomainCreate();

            // 1. ContactCheck
            if (product.GetProperty("WhoisServerHolder") == "Registry")
            {
                var reqContactCheck = new ReqContactCheck() { DomainName = domainName };

                // 1.1. contact id'lerin hepsini bir seferde check edelim
                reqContactCheck.ContactIDs = new List<string>();
                if (!memberDomain.OwnerDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.OwnerDomainContactId);
                if (!memberDomain.AdminDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.AdminDomainContactId);
                if (!memberDomain.BillingDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.BillingDomainContactId);
                if (!memberDomain.TechDomainContactId.IsEmpty()) reqContactCheck.ContactIDs.Add(memberDomain.TechDomainContactId);
                reqContactCheck.ContactIDs = reqContactCheck.ContactIDs.Distinct().ToList();

                if (reqContactCheck.ContactIDs.Count > 0)
                {
                    var resContactCheck = eppApi.ContactCheck(reqContactCheck);

                    // 1.2. eğer registry tarafında contact create edilmemişse create edelim
                    if (!memberDomain.OwnerDomainContactId.IsEmpty())
                    {
                        if (resContactCheck.IsAvailable(memberDomain.OwnerDomainContactId))
                        {
                            createContact(memberDomain.OwnerDomainContactId, eppApi, domainName);
                            resContactCheck.ContactInfos.First(ci => ci.ContactId == memberDomain.OwnerDomainContactId).Available = false;
                        }
                        req.Registrant = memberDomain.OwnerDomainContactId;
                    }
                    if (!memberDomain.AdminDomainContactId.IsEmpty())
                    {
                        if (resContactCheck.IsAvailable(memberDomain.AdminDomainContactId))
                        {
                            createContact(memberDomain.AdminDomainContactId, eppApi, domainName);
                            resContactCheck.ContactInfos.First(ci => ci.ContactId == memberDomain.AdminDomainContactId).Available = false;
                        }
                        if (req.Contacts == null) req.Contacts = new List<DomainContactInfo>();
                        req.Contacts.Add(new DomainContactInfo(memberDomain.AdminDomainContactId, DomainContactInfo.ContactType.Admin));
                    }
                    if (!memberDomain.BillingDomainContactId.IsEmpty())
                    {
                        if (resContactCheck.IsAvailable(memberDomain.BillingDomainContactId))
                        {
                            createContact(memberDomain.BillingDomainContactId, eppApi, domainName);
                            resContactCheck.ContactInfos.First(ci => ci.ContactId == memberDomain.BillingDomainContactId).Available = false;
                        }
                        if (req.Contacts == null) req.Contacts = new List<DomainContactInfo>();
                        req.Contacts.Add(new DomainContactInfo(memberDomain.BillingDomainContactId, DomainContactInfo.ContactType.Billing));
                    }
                    if (!memberDomain.TechDomainContactId.IsEmpty())
                    {
                        if (resContactCheck.IsAvailable(memberDomain.TechDomainContactId))
                        {
                            createContact(memberDomain.TechDomainContactId, eppApi, domainName);
                            resContactCheck.ContactInfos.First(ci => ci.ContactId == memberDomain.TechDomainContactId).Available = false;
                        }
                        if (req.Contacts == null) req.Contacts = new List<DomainContactInfo>();
                        req.Contacts.Add(new DomainContactInfo(memberDomain.TechDomainContactId, DomainContactInfo.ContactType.Tech));
                    }
                }
            }

            req.Registrant = memberDomain.OwnerDomainContactId;

            // 2. Nameserver'ları set edelim
            if (!memberDomain.NameServers.IsEmpty())
                foreach (string host in memberDomain.NameServers.SplitWithTrim(";"))
                {
                    if (host.Contains(','))
                    {
                        var parts = host.SplitWithTrim(","); //TODO: IPv6'yı da desteklemek gerekecek gibi
                        req.NameServers.Add(new NameServerInfo { HostName = parts[0], Addresses = new List<IpAddress> { new IpAddress { Address = parts[1], Type = IpAddress.IpAddressType.V4 } } });
                    }
                    else
                        req.NameServers.Add(new NameServerInfo { HostName = host });
                }

            // 3. The domain name itself
            req.DomainName = memberDomain.DomainName;

            // 4. Period
            req.RegistrationPeriod = new DomainPeriod
            {
                Units = orderItem.ProductPrice().Unit == "years" ? DomainPeriod.PeriodUnits.Year : DomainPeriod.PeriodUnits.Month,
                Period = orderItem.Amount
            };

            // 5. AuthInfo
            req.AuthInfo = new Epp.Protocol.Shared.AuthInfo(memberDomain.AuthInfo);

            var res = eppApi.DomainCreate(req);

            memberProduct.StartDate = res.CreateDate;
            memberProduct.EndDate = res.ExpireDate.Value;
            memberProduct.CurrentPhase = LifeCyclePhases.Active;

            memberProduct.Save();

            var resInfo = eppApi.DomainInfo(new ReqDomainInfo { AuthInfo = req.AuthInfo, DomainName = req.DomainName });

            memberDomain.RegistryStates = resInfo.Statuses.Select(s=>s.Status).ToList();
            memberDomain.Save();

            return JobStates.Done;
        }

        private ResContactCreate createContact(string contactId, EppAPI eppApi, string domainName)
        {
            var domainContact = Provider.Database.Read<DomainContact>("Id={0}", contactId);
            if (domainContact == null) throw new Exception("Supplied contact ID is available on registry but there is no record with that ID in the table DomainContact");
            return eppApi.ContactCreate(domainContact.ConvertToReqContactCreate(domainName));
        }

        private JobStates domainRenew(Job job)
        {
            var orderItem = Provider.Database.Read<OrderItem>("Id={0}", job.RelatedEntityId);
            var member = orderItem.Order().Member();

            var memberDomain = Provider.Database.Read<MemberDomain>("DomainName={0}", orderItem.DisplayName);
            if (memberDomain==null)
                throw new Exception("Domain name not found (" + orderItem.DisplayName + ")");

            var memberProduct = Provider.Database.Read<MemberProduct>("Id={0}", memberDomain.Id);

            if (memberProduct==null)
                throw new Exception("MemberProduct for domain name not found (" + orderItem.DisplayName + ")");

            // Aşağıdaki işlemler RFC 5731 dikkate alınarak yazılmıştır. (https://tools.ietf.org/html/rfc5731#page-18)
            var eppApi = new EppAPI();

            var req = new ReqDomainRenew();

            req.DomainName = memberDomain.DomainName;
            req.CurrExpirationDate = memberProduct.EndDate;
            req.Period = new DomainPeriod {
                Units = orderItem.ProductPrice().Unit == "years" ? DomainPeriod.PeriodUnits.Year : DomainPeriod.PeriodUnits.Month,
                Period = orderItem.Amount
            };

            var res = eppApi.DomainRenew(req);

            memberProduct.EndDate = res.ExpirationDate.Value;

            memberProduct.Save();

            return JobStates.Done;
        }

        private JobStates domainTransferRequest(Job job)
        {
            var orderItem = Provider.Database.Read<OrderItem>("Id={0}", job.RelatedEntityId);
            var member = orderItem.Order().Member();


            var memberDomain = Provider.Database.Read<MemberDomain>("DomainName={0}", orderItem.DisplayName);
            if (memberDomain == null || memberDomain.AuthInfo.IsEmpty())
                throw new Exception("Member should enter domain transfer secret");

            // Aşağıdaki işlemler RFC 5730 dikkate alınarak yazılmıştır. (https://tools.ietf.org/html/rfc5730#page-35)
            var eppApi = new EppAPI();

            var req = new ReqDomainTransferRequest();

            req.DomainName = memberDomain.DomainName;
            req.AuthInfo = new Epp.Protocol.Shared.AuthInfo { Password = memberDomain.AuthInfo};
            req.Period = new DomainPeriod
            {
                Units = orderItem.ProductPrice().Unit == "years" ? DomainPeriod.PeriodUnits.Year : DomainPeriod.PeriodUnits.Month,
                Period = orderItem.Amount
            };

            var res = eppApi.DomainTransferRequest(req);

            new Job()
            {
                Command = JobCommands.DomainTransferQuery,
                Name = orderItem.DisplayName,
                RelatedEntityName = "OrderItem",
                RelatedEntityId = orderItem.Id,
                State = JobStates.NotStarted,
                Executer = JobExecuters.Machine,
                StartDate = Provider.Database.Now.AddHours(1)
            }.Save();

            return JobStates.Done;
        }

        private JobStates domainTransferQuery(Job job)
        {
            // according to https://tools.ietf.org/html/rfc5730#page-30

            var orderItem = Provider.Database.Read<OrderItem>("Id={0}", job.RelatedEntityId);
            var member = orderItem.Order().Member();


            var memberDomain = Provider.Database.Read<MemberDomain>("DomainName={0}", orderItem.DisplayName);
            if (memberDomain == null)
                throw new Exception("Domain transfer process not yet started (first request then query)");

            // Aşağıdaki işlemler RFC 5730 dikkate alınarak yazılmıştır. (https://tools.ietf.org/html/rfc5730#page-35)
            var eppApi = new EppAPI();

            var req = new ReqDomainTransferQuery();

            req.DomainName = memberDomain.DomainName;
            req.AuthInfo = new Epp.Protocol.Shared.AuthInfo { Password = memberDomain.AuthInfo };
            req.Period = new DomainPeriod
            {
                Units = orderItem.ProductPrice().Unit == "years" ? DomainPeriod.PeriodUnits.Year : DomainPeriod.PeriodUnits.Month,
                Period = orderItem.Amount
            };

            var res = eppApi.DomainTransferQuery(req);

            if (res.TransferRequestState.ToLowerInvariant() == memberDomain.TransferState.ToString().ToLowerInvariant())
                return JobStates.TryAgain;

            switch (res.TransferRequestState.ToLowerInvariant())
            {
                case "clientApproved":
                    memberDomain.TransferState = TransferStates.ClientApproved;
                    memberDomain.Save();
                    return JobStates.TryAgain;
                case "clientCancelled":
                    memberDomain.TransferState = TransferStates.ClientCancelled;
                    memberDomain.Save();
                    return JobStates.Canceled;
                case "clientRejected":
                    memberDomain.TransferState = TransferStates.ClientRejected;
                    memberDomain.Save();
                    return JobStates.Canceled;
                case "pending":
                    memberDomain.TransferState = TransferStates.Pending;
                    memberDomain.Save();
                    return JobStates.TryAgain;
                case "serverApproved":
                    memberDomain.TransferState = TransferStates.ServerApproved;
                    memberDomain.Save();
                    var memberProduct = Provider.Database.Read<MemberProduct>("Id={0}", memberDomain.Id);
                    memberProduct.EndDate = res.ExpireDate.Value;
                    memberProduct.Save();
                    return JobStates.Done;
                case "serverCancelled":
                    memberDomain.TransferState = TransferStates.ServerCancelled;
                    memberDomain.Save();
                    return JobStates.Canceled;
                default:
                    memberDomain.TransferState = TransferStates.None;
                    memberDomain.Save();
                    throw new Exception("Registry returned an unknown transfer status: " + res.TransferRequestState);
            }


            return JobStates.Failed; // buraya hiç gelmemesi lazım
        }
        
        private JobStates domainRestore(Job job)
        {
            // according to https://tools.ietf.org/html/rfc3915

            var orderItem = Provider.Database.Read<OrderItem>("Id={0}", job.RelatedEntityId);
            var member = orderItem.Order().Member();


            var memberDomain = Provider.Database.Read<MemberDomain>("DomainName={0}", orderItem.DisplayName);
            if (memberDomain == null)
                throw new Exception("MemberDomain record not found. If a domain name is not in our database, cannot be restored.");

            var eppApi = new EppAPI();

            var req = new ReqDomainInfo();
            req.DomainName = memberDomain.DomainName;

            var res = eppApi.DomainInfo(req);

            // eğer domain state OK ise restore işlemi tamamlanmıştır
            if (res.Statuses.FirstOrDefault(s => s.Status == Epp.Protocol.Shared.Status.Ok) != null)
            {
                var memberProduct = Provider.Database.Read<MemberProduct>("Id={0}", memberDomain.Id);
                if (memberProduct == null)
                {
                    //null olmaması gerekir ama bir hatadan dolayı null ise hemen create edelim. bi sakınca yok
                    memberProduct = new MemberProduct
                    {
                        StartDate = res.CreationDate.Value,
                        OrderItemId = job.RelatedEntityId,
                        MemberId = member.Id,

                    };
                }

                memberProduct.EndDate = res.ExpirationDate.Value;
                memberProduct.Save();

                memberDomain.RegistryStatus = res.Statuses.StringJoin(",");
                memberDomain.RGPStatus = res.ExtRgp == null ? statusValueType.NONE : res.ExtRgp.rgpStatus.FirstOrDefault().s;

                memberDomain.Save();

                return JobStates.Done;
            }

            // eğer domain state OK değilse, pendingDelete de değilse, restore'da ne işin var kardeşim?
            if (res.Statuses.FirstOrDefault(s => s.Status == Epp.Protocol.Shared.Status.PendingDelete) == null)
                throw new Exception("A domain with no pendingDelete status cannot be restored.");

            // eğer domain redemptionPeriod'da ise, restore request komutunu göndeririz
            if (res.ExtRgp.rgpStatus.FirstOrDefault(s => s.s == statusValueType.redemptionPeriod) != null)
            {

                var reqRestore = new ReqDomainUpdate
                {
                    DomainName = memberDomain.DomainName,
                    ExtRgp = new DealerSafe.DTO.Epp.Protocol.Rgp.updateType
                    {
                        restore = new DealerSafe.DTO.Epp.Protocol.Rgp.restoreType
                        {
                            op = DealerSafe.DTO.Epp.Protocol.Rgp.rgpOpType.request
                        }
                    }
                };

                var resRestore = eppApi.DomainUpdate(reqRestore);

                job.StartDate = Provider.Database.Now.AddMinutes(10);

                return JobStates.TryAgain;
            }

            // eğer domain pendingRestore'da ise, restore report komutunu göndeririz
            if (res.ExtRgp.rgpStatus.FirstOrDefault(s => s.s == statusValueType.pendingRestore) != null)
            {
                var reqReport = new ReqDomainUpdate
                {
                    DomainName = memberDomain.DomainName,
                    ExtRgp = new DealerSafe.DTO.Epp.Protocol.Rgp.updateType
                    {
                        restore = new DealerSafe.DTO.Epp.Protocol.Rgp.restoreType
                        {
                            op = DealerSafe.DTO.Epp.Protocol.Rgp.rgpOpType.report
                        }
                    }
                };

                var resRestore = eppApi.DomainUpdate(reqReport);

                job.StartDate = Provider.Database.Now.AddMinutes(10);

                return JobStates.TryAgain;
            }

            job.StartDate = Provider.Database.Now.AddMinutes(10);
            return JobStates.TryAgain;
        }

        private JobStates domainCancel(Job job)
        {
            OrderItem oi = Provider.Database.Read<OrderItem>("Id={0}", job.RelatedEntityId);
            if (oi == null)
                throw new APIException("OrderItem not found. refNo: " + job.RelatedEntityId);

            MemberProduct mp = Provider.Database.Read<MemberProduct>("OrderItemId = {0}", oi.Id);
            if (mp == null)
                throw new APIException("Critical error: OrderItem exists but MemberProduct doesn't, for orderItem : " + oi.Id);

            MemberDomain md = Provider.Database.Read<MemberDomain>("Id = {0}", mp.Id);
            if (md == null)
                throw new APIException("Critical error: MemberProduct exists but MemberDomain doesn't, for memberProduct : " + mp.Id);

            if (mp.StartDate < Provider.Database.Now.AddDays(-5))
                throw new APIException("You can cancel your domain and refund in the first 5 days of your domain registration.");

            var eppApi = new EppAPI();
            eppApi.DomainDelete(new DealerSafe.DTO.Epp.Request.ReqDomainDelete
            {
                DomainName = md.DomainName
            });

            md.Delete();
            mp.Delete();

            oi.Cancel();

            return JobStates.Done;
        }

        private JobStates readPollMessages(Job job)
        {
            EppAPI epp = new EppAPI();

            foreach (Registry registry in Provider.Database.ReadList<Registry>().Where(r => r.FollowPollMessages && !r.IsDeleted))
            {
                try
                {
                    var aTldExtension = Provider.Database.GetString("SELECT TOP 1 Name FROM Product WHERE SupplierId = {0} AND IsDeleted <> 1", registry.Id);
                    if (aTldExtension.IsEmpty())
                        continue;

                    var domainName = "example" + (aTldExtension.StartsWith(".") ? "" : ".") + aTldExtension;
                    var res = epp.PollRequest(new ReqPollRequest { DomainName = domainName });

                    while (res!=null && res.Count > 0)
                    {
                        Job j = new Job
                        {
                            Command = JobCommands.HandlePollMessage,
                            Executer = JobExecuters.Machine,
                            Name = registry.Name,
                            RelatedEntityId = registry.Id,
                            RelatedEntityName = "Registry",
                            StartDate = Provider.Database.Now,
                            State = JobStates.NotStarted,
                            CommandParameter = res.Message,
                            ParentJobId = job.Id
                        };
                        j.Save();

                        JobData jd = new JobData { 
                            JobId = j.Id,
                            Request = res.Details,
                            Response = ""
                        };
                        jd.Save();

                        var res2 = epp.PollAcknowledge(new ReqPollAcknowledge { DomainName = domainName, MessageId = res.MessageId });
                        if (res2.Count == 0) break;

                        res = epp.PollRequest(new ReqPollRequest { DomainName = domainName });
                    }
                }
                catch { }
            }

            return JobStates.Done;
        }

        private JobStates handlePollMessage(Job job)
        {
            return JobStates.Done;
        }

        #endregion

        #region worker specific

        public override int GetMaxTryCount(JobCommands jobCommand)
        {
            if (jobCommand == JobCommands.DomainTransferQuery)
                return 24 * 5;
            else if (jobCommand == JobCommands.DomainRestore)
                return 20;

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
        
        #endregion
    }
}