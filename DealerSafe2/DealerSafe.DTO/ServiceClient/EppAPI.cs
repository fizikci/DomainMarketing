

using System;
using System.Linq;
using System.Web;
using DealerSafe.DTO.Epp.Request;
using DealerSafe.DTO.Epp.Response;

namespace DealerSafe.ServiceClient
{
    using DTO.Common;
    using System.Configuration;
    using System.ComponentModel;
    using System.Collections.Generic;
    using DealerSafe.DTO;

    public class EppAPI : BaseAPI
    {
        public EppAPI(int memberId)
        {
            this.memberId = memberId;
        }
        public EppAPI()
        {
            //if (HttpContext.Current != null && HttpContext.Current.Session["MemberID"] != null)
            //    this.memberId = Convert.ToInt32(HttpContext.Current.Session["MemberID"]);
        }


        public string Hello()
        {
            return Call<string, ReqEmpty>(new ReqEmpty(), "Hello");
        }

        public ResDomainCheck DomainCheck(ReqDomainCheck req)
        {
            return Call<ResDomainCheck, ReqDomainCheck>(req, "DomainCheck");
        }
        
        public ResDomainInfo DomainInfo(ReqDomainInfo req)
        {
            return Call<ResDomainInfo, ReqDomainInfo>(req, "DomainInfo");
        }
        public ResDomainCreate DomainCreate(ReqDomainCreate req)
        {
            return Call<ResDomainCreate, ReqDomainCreate>(req, "DomainCreate");
        }
        public List<ResDomainCreate> DomainListCreate(List<ReqDomainCreate> req)
        {
            return Call<List<ResDomainCreate>, List<ReqDomainCreate>>(req, "DomainListCreate");
        }
        public ResDomainUpdate DomainUpdate(ReqDomainUpdate req)
        {
            return Call<ResDomainUpdate, ReqDomainUpdate>(req, "DomainUpdate");
        }
        public ResDomainDelete DomainDelete(ReqDomainDelete req)
        {
            return Call<ResDomainDelete, ReqDomainDelete>(req, "DomainDelete");
        }

        public ResDomainRenew DomainRenew(ReqDomainRenew req)
        {
            return Call<ResDomainRenew, ReqDomainRenew>(req, "DomainRenew");
        }
        public ResDomainTransfer DomainTransferApprove(ReqDomainTransferApprove req)
        {
            return Call<ResDomainTransfer, ReqDomainTransferApprove>(req, "DomainTransferApprove");
        }
        public ResDomainTransfer DomainTransferCancel(ReqDomainTransferCancel req)
        {
            return Call<ResDomainTransfer, ReqDomainTransferCancel>(req, "DomainTransferCancel");
        }
        public ResDomainTransfer DomainTransferQuery(ReqDomainTransferQuery req)
        {
            return Call<ResDomainTransfer, ReqDomainTransferQuery>(req, "DomainTransferQuery");
        }
        public ResDomainTransfer DomainTransferReject(ReqDomainTransferReject req)
        {
            return Call<ResDomainTransfer, ReqDomainTransferReject>(req, "DomainTransferReject");
        }
        public ResDomainTransfer DomainTransferRequest(ReqDomainTransferRequest req)
        {
            return Call<ResDomainTransfer, ReqDomainTransferRequest>(req, "DomainTransferRequest");
        }

        public ResContactCheck ContactCheck(ReqContactCheck req)
        {
            return Call<ResContactCheck, ReqContactCheck>(req, "ContactCheck");
        }
        public ResContactInfo ContactInfo(ReqContactInfo req)
        {
            return Call<ResContactInfo, ReqContactInfo>(req, "ContactInfo");
        }
        public ResContactCreate ContactCreate(ReqContactCreate req)
        {
            return Call<ResContactCreate, ReqContactCreate>(req, "ContactCreate");
        }
        public ResContactDelete ContactDelete(ReqContactDelete req)
        {
            return Call<ResContactDelete, ReqContactDelete>(req, "ContactDelete");
        }
        public ResContactUpdate ContactUpdate(ReqContactUpdate req)
        {
            return Call<ResContactUpdate, ReqContactUpdate>(req, "ContactUpdate");
        }
        public ResContactTransfer ContactTransferApprove(ReqContactTransferApprove req)
        {
            return Call<ResContactTransfer, ReqContactTransferApprove>(req, "ContactTransferApprove");
        }
        public ResContactTransfer ContactTransferCancel(ReqContactTransferCancel req)
        {
            return Call<ResContactTransfer, ReqContactTransferCancel>(req, "ContactTransferCancel");
        }
        public ResContactTransfer ContactTransferQuery(ReqContactTransferQuery req)
        {
            return Call<ResContactTransfer, ReqContactTransferQuery>(req, "ContactTransferQuery");
        }
        public ResContactTransfer ContactTransferReject(ReqContactTransferReject req)
        {
            return Call<ResContactTransfer, ReqContactTransferReject>(req, "ContactTransferReject");
        }
        public ResContactTransfer ContactTransferRequest(ReqContactTransferRequest req)
        {
            return Call<ResContactTransfer, ReqContactTransferRequest>(req, "ContactTransferRequest");
        }

        public ResHostCheck HostCheck(ReqHostCheck req)
        {
            return Call<ResHostCheck, ReqHostCheck>(req, "HostCheck");
        }
        public List<ResHostCheck> HostChecks(List<string> hostNames)
        {
            return Call<List<ResHostCheck>, List<string>>(hostNames, "HostChecks");
        }
        public ResHostCreate HostCreate(ReqHostCreate req)
        {
            return Call<ResHostCreate, ReqHostCreate>(req, "HostCreate");
        }
        public ResHostInfo HostInfo(ReqHostInfo req)
        {
            return Call<ResHostInfo, ReqHostInfo>(req, "HostInfo");
        }
        public ResHostDelete HostDelete(ReqHostDelete req)
        {
            return Call<ResHostDelete, ReqHostDelete>(req, "HostDelete");
        }
        public ResHostUpdate HostUpdate(ReqHostUpdate req)
        {
            return Call<ResHostUpdate, ReqHostUpdate>(req, "HostUpdate");
        }

        public ResPollRequest PollRequest(ReqPollRequest req)
        {
            return Call<ResPollRequest, ReqPollRequest>(req, "PollRequest");
        }
        public ResPollAcknowledge PollAcknowledge(ReqPollAcknowledge req)
        {
            return Call<ResPollAcknowledge, ReqPollAcknowledge>(req, "PollAcknowledge");
        }

        public ResTldInformation TldInformation(ReqTldInformation req)
        {
            return Call<ResTldInformation, ReqTldInformation>(req, "TldInformation");
        }
        public List<ResTldInformation> TldInformationList()
        {
            return Call<List<ResTldInformation>, ReqEmpty>(new ReqEmpty(), "TldInformationList");
        }
        public bool TldInformationUpdate(ReqTldInformationUpdate req)
        {
            return Call<bool, ReqTldInformationUpdate>(req, "TldInformationUpdate");
        }
        public bool TldInformationSave(ReqTldInformationSave req)
        {
            return Call<bool, ReqTldInformationSave>(req, "TldInformationSave");
        }
        public List<ResTldNameGroupByCompanyId> TldNameGroupByCompanyId()
        {
            return Call<List<ResTldNameGroupByCompanyId>, ReqEmpty>(new ReqEmpty(), "TldNameGroupByCompanyId");
        }
        public List<ResTldCompany> TldCompanyList()
        {
            return Call<List<ResTldCompany>, ReqEmpty>(new ReqEmpty(), "TldCompanyList");
        }

        public bool TldDelete(string domainName)
        {
            return Call<bool, string>(domainName, "TldDelete");
        }

        public int TldInformationSetExtensionLaunch(string name)
        {
            return Call<int, string>(name, "TldInformationSetExtensionLaunch");
        }

        public int TldInformationClearExtensionLaunch(string name)
        {
            return Call<int, string>(name, "TldInformationClearExtensionLaunch");
        }

        protected override string GetServiceURL()
        {
            return ConfigurationManager.AppSettings["EppServiceURL"];
        }
    }
}
