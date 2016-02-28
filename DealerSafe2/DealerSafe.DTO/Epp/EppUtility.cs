using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DealerSafe.DTO.Enums;
using fee05 = DealerSafe.DTO.Epp.Protocol.Fee05;
using fee06 = DealerSafe.DTO.Epp.Protocol.Fee06;
using fee07 = DealerSafe.DTO.Epp.Protocol.Fee07;
using DealerSafe.DTO.Epp.Protocol.NameStore;
using DealerSafe.DTO.Epp.Request;
using DealerSafe.DTO.Epp.Response;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Contacts;
using Epp.Protocol.Domains;
using Epp.Protocol.Hosts;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp
{
    public class EppUtility
    {
        public static string GetTld(string domainName)
        {
            if (string.IsNullOrEmpty(domainName))
                throw new APIException("Domain name required", ErrorTypes.ValidationError);

            return domainName.Substring(domainName.IndexOf('.'));
        }

        public static void SetVeriSignNameStoreExtension(string domainName, IVerisignNameStore req)
        {
            var tld = GetTld(domainName).ToLowerInvariant();
            if (tld==".com") req.ExtNameStore = new namestoreExtType() { subProduct = "dotCOM" };
            if (tld==".net") req.ExtNameStore = new namestoreExtType() { subProduct = "dotNET" };
            if (tld==".cc") req.ExtNameStore = new namestoreExtType() { subProduct = "dotCC" };
            if (tld==".tv") req.ExtNameStore = new namestoreExtType() { subProduct = "dotTV" };
        }

        public static object CreateSampleRequest(EppQueueCommands command, string domainName = "DOMAIN_NAME.TLD")
        {
            switch (command)
            {
                case EppQueueCommands.Login:
                    {
                        return new ReqEmpty();
                    }
                case EppQueueCommands.Logout:
                    {
                        return new ReqEmpty();
                    }
                case EppQueueCommands.Hello:
                    {
                        return new ReqEmpty();
                    }
                case EppQueueCommands.DomainCheck:
                    {
                        var req = new ReqDomainCheck(new List<string>() { domainName });
                        req.ExtLaunch = new Protocol.Launch.checkType() { phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
                        SetVeriSignNameStoreExtension(domainName, req);
                        req.ExtPremiumDomain = new Protocol.PremiumDomain.chkType() { flag = true };
                        req.ExtFee05 = new fee05.checkType() { domain = new List<fee05.domainCheckType>() { new fee05.domainCheckType() { command = new fee05.commandType() { phase = "sunrise", Value = "create" }, currency = "USD", name = domainName, period = new fee05.periodType() { unit = fee05.pUnitType.y, Value = 1 } } } };
                        req.ExtFee06 = new fee06.checkType() { domain = new List<fee06.domainCheckType>() { new fee06.domainCheckType() { command = new fee06.commandType() { phase = "sunrise", Value = "create" }, currency = "USD", name = domainName, period = new fee06.periodType() { unit = fee06.pUnitType.y, Value = 1 } } } };
                        req.ExtFee07 = new fee07.checkType() { domain = new List<fee07.domainCheckType>() { new fee07.domainCheckType() { command = new fee07.commandType() { phase = "sunrise", Value = "create" }, currency = "USD", name = domainName, period = new fee07.periodType() { unit = fee07.pUnitType.y, Value = 1 } } } };
                        return req;
                    }
                case EppQueueCommands.DomainDelete:
                    {
                        var req = new ReqDomainDelete(domainName);
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.DomainRenew:
                    {
                        var req = new ReqDomainRenew(domainName, DateTime.Now.AddMonths(1), new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1));
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.DomainInfo:
                    {
                        var req = new ReqDomainInfo(domainName, new AuthInfo("PASSWORD"));
                        SetVeriSignNameStoreExtension(domainName, req);
                        req.ExtLaunch = new Protocol.Launch.infoType() { phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.sunrise }, includeMark = false };
                        return req;
                    }
                case EppQueueCommands.DomainUpdate:
                    {
                        ReqDomainUpdate hArgs = new ReqDomainUpdate(domainName);

                        hArgs.Rem = new DomainAddRemType();
                        hArgs.Rem.NameServers = new NameServerList();

                        foreach (string s in new[] { "ns1.isimtescil.net", "ns2.isimtescil.net" })
                            hArgs.Rem.NameServers.Add(new NameServerInfo(s));

                        hArgs.Add = new DomainAddRemType();
                        hArgs.Add.NameServers = new NameServerList();

                        foreach (string s in new[] { "ns1.isimtescil.net", "ns2.isimtescil.net" })
                            hArgs.Add.NameServers.Add(new NameServerInfo(s));

                        List<DomainContactInfo> addContacts = new List<DomainContactInfo>();
                        List<DomainContactInfo> remContacts = new List<DomainContactInfo>();

                        addContacts.Add(new DomainContactInfo("ADMIN_CONTACT_ID", DomainContactInfo.ContactType.Admin));

                        addContacts.Add(new DomainContactInfo("BILL_CONTACT_ID", DomainContactInfo.ContactType.Billing));

                        addContacts.Add(new DomainContactInfo("TECH_CONTACT_ID", DomainContactInfo.ContactType.Tech));

                        hArgs.Add.Contacts = addContacts;
                        if (hArgs.Rem != null)
                            hArgs.Rem.Contacts = remContacts;

                        hArgs.Chg = new DomainChangeType("registrantID");

                        SetVeriSignNameStoreExtension(domainName, hArgs);
                        hArgs.ExtLaunch = new Protocol.Launch.idContainerType() { phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.sunrise } };
                        hArgs.ExtPremiumDomain = new Protocol.PremiumDomain.reassignType() { shortName = "shortname" };
                        hArgs.ExtRgp = new Protocol.Rgp.updateType() { restore = new Protocol.Rgp.restoreType() { op = Protocol.Rgp.rgpOpType.request } };
                        hArgs.ExtKeySys = new Protocol.KeySys.updateType() { domain = new Protocol.KeySys.domainType() { renewalmode = "AUTOEXPIRE" } };

                        return hArgs;
                    }
                case EppQueueCommands.DomainCreate:
                    {
                        //Get ContactId's
                        string adminContactId = "ADMIN_CONTACT_ID";
                        string techContacId = "TECH_CONTACT_ID";
                        string billingContacId = "BILL_CONTACT_ID";

                        ReqDomainCreate dArgs = new ReqDomainCreate(domainName, new AuthInfo("AUTH_PASSWORD"))
                        {
                            NameServers = new NameServerList(new List<NameServerInfo>() { new NameServerInfo("ns1.isimtescil.net"), new NameServerInfo("ns2.isimtescil.net") }),
                            RegistrationPeriod = new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1),
                            Registrant = "OWNER_CONTACT_ID",
                            Contacts = new List<DomainContactInfo>() { 
                                    new DomainContactInfo(adminContactId,DomainContactInfo.ContactType.Admin),
                                    new DomainContactInfo(techContacId,DomainContactInfo.ContactType.Tech),
                                    new DomainContactInfo(billingContacId,DomainContactInfo.ContactType.Billing)
                                 }
                        };

                        SetVeriSignNameStoreExtension(domainName, dArgs);
                        dArgs.ExtLaunch = new Protocol.Launch.createType()
                            {
                                type = Protocol.Launch.objectType.registration, 
                                phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.sunrise }, 
                                notice = new Protocol.Launch.createNoticeType() { acceptedDate = DateTime.Now.AddDays(-30) }
                            };

                        return dArgs;
                    }
                case EppQueueCommands.DomainTransferRequest:
                    {
                        var req = new ReqDomainTransferRequest() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Period = new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1) };
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.DomainTransferQuery:
                    {
                        var req = new ReqDomainTransferQuery() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Period = new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1) };
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.DomainTransferCancel:
                    {
                        var req = new ReqDomainTransferCancel() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Period = new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1) };
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.DomainTransferApprove:
                    {
                        var req = new ReqDomainTransferApprove() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Period = new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1) };
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.DomainTransferReject:
                    {
                        var req = new ReqDomainTransferReject() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Period = new DomainPeriod(DomainPeriod.PeriodUnits.Year, 1) };
                        SetVeriSignNameStoreExtension(domainName, req);
                        return req;
                    }
                case EppQueueCommands.ContactCheck:
                    {
                        return new ReqContactCheck(new List<string>() { "CONTACT_ID" }) { DomainName = domainName };
                    }
                case EppQueueCommands.ContactCreate:
                    {
                        return new ReqContactCreate("CONTACT_ID",
                                new List<PostalInfo>() { 
                                    new PostalInfo(
                                        "NAME", 
                                        PostalInfo.PostalType.Int, 
                                        new AddressInfo("CITY","COUNTRY_CODE") { PostalCode = "POSTAL_CODE", Streets = new List<string>(){"STREET_LINE_1","STREET_LINE_1"}} ) }
                                ,
                                "EMAIL@EMAIL.EMAIL",
                                null)
                        {
                            Fax = "FAX",
                            Voice = new VoiceInfo("PHONE"),
                            AuthInfo = new AuthInfo("PASSWORD"),
                            DomainName = domainName
                        }
                        ;
                    }
                case EppQueueCommands.ContactDelete:
                    {
                        return new ReqContactDelete("CONTACT_ID") { DomainName = domainName };
                    }
                case EppQueueCommands.ContactUpdate:
                    {
                        ReqContactUpdate h = new ReqContactUpdate("CONTACT_ID") { DomainName = domainName };
                        h.Chg = new ContactChangeType();

                        //email degiscek mi
                        h.Chg.Email = "EMAIL@EMAIL.EMAIL";
                        h.Chg.Fax = "FAX";
                        h.Chg.Voice = new VoiceInfo("PHONE");

                        h.Chg.PostalInfos = new List<PostalInfo>() { 
                                    new PostalInfo(
                                        "NAME", 
                                        PostalInfo.PostalType.Int, 
                                        new AddressInfo("CITY","COUNTRY_CODE") { PostalCode = "POSTAL_CODE", Streets = new List<string>(){"STREET_LINE_1","STREET_LINE_1"}} ) };

                        return h;
                    }
                case EppQueueCommands.ContactInfo:
                    {
                        return new ReqContactInfo("CONTACT_ID", new AuthInfo("PASSWORD")) { DomainName = domainName };
                    }
                case EppQueueCommands.ContactTransferRequest:
                    {
                        return new ReqContactTransferRequest() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Id = "CONTACT_ID" };
                    }
                case EppQueueCommands.ContactTransferQuery:
                    {
                        return new ReqContactTransferQuery() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Id = "CONTACT_ID" };
                    }
                case EppQueueCommands.ContactTransferCancel:
                    {
                        return new ReqContactTransferCancel() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Id = "CONTACT_ID" };
                    }
                case EppQueueCommands.ContactTransferApprove:
                    {
                        return new ReqContactTransferApprove() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Id = "CONTACT_ID" };
                    }
                case EppQueueCommands.ContactTransferReject:
                    {
                        return new ReqContactTransferReject() { AuthInfo = new AuthInfo("PASSWORD"), DomainName = domainName, Id = "CONTACT_ID" };
                    }
                case EppQueueCommands.HostCheck:
                    {
                        return new ReqHostCheck(new List<string>() { "HOST_NAME" }) { DomainName = domainName };
                    }
                case EppQueueCommands.HostCreate:
                    {
                        return new ReqHostCreate("HOST_NAME", new[] { "IP1", "IP2" }.Select(x => new IpAddress(x)).ToList()) { DomainName = domainName };
                    }
                case EppQueueCommands.HostDelete:
                    {
                        return new ReqHostDelete("HOST_NAME") { DomainName = domainName };
                    }
                case EppQueueCommands.HostUpdate:
                    {
                        List<string> addAdress = new List<string>() { "add_IP1", "add_IP2" };
                        List<string> remAdress = new List<string>() { "rem_IP1", "rem_IP2" };

                        ReqHostUpdate hArgs = new ReqHostUpdate("HOST_NAME") { DomainName = domainName };

                        if (addAdress.Count != 0 && !string.IsNullOrEmpty(addAdress[0]))
                            hArgs.Add = new HostAddRemType(addAdress.Select(x => new IpAddress(IpAddress.IpAddressType.V4, x)).ToList());

                        if (remAdress.Count != 0 && !string.IsNullOrEmpty(addAdress[0]))
                            hArgs.Rem = new HostAddRemType(remAdress.Select(x => new IpAddress(IpAddress.IpAddressType.V4, x)).ToList());

                        hArgs.Chg = "NEW_HOST_NAME";

                        return hArgs;
                    }
                case EppQueueCommands.HostInfo:
                    {
                        return new ReqHostInfo("HOST_NAME") { DomainName = domainName };
                    }
                case EppQueueCommands.FinanceInfo:
                    {
                        return new ReqFinanceInfo() { DomainName = domainName };
                    }
                case EppQueueCommands.PollRequest:
                    {
                        return new ReqPollRequest { DomainName = domainName, ClientTranId = "IdontKnow" };
                    }
                case EppQueueCommands.PollAcknowledge:
                    {
                        return new ReqPollAcknowledge { DomainName = domainName, MessageId = "MESSAGE_ID" };
                    }
            }

            throw new Exception("No such EPP command");
        }

        public static object ParseEppResponseXml(EppQueueCommands command, string eppResponseXml)
        {
            var document = XDocument.Parse(eppResponseXml);
            ResponseMessageBase resEpp = null;

            switch (command)
            {
                case EppQueueCommands.ContactCheck:
                    resEpp = new ResponseMessage<CheckResponse<ResContactCheck>>(document);
                    break;
                case EppQueueCommands.ContactCreate:
                    resEpp = new ResponseMessage<CreateResponse<ResContactCreate>>(document);
                    break;
                case EppQueueCommands.ContactDelete:
                case EppQueueCommands.DomainDelete:
                case EppQueueCommands.HostDelete:
                case EppQueueCommands.ContactUpdate:
                case EppQueueCommands.DomainUpdate:
                case EppQueueCommands.HostUpdate:
                    resEpp = new ResponseMessageBase(document);
                    break;
                case EppQueueCommands.ContactInfo:
                    resEpp = new ResponseMessage<InfoResponse<ResContactInfo>>(document);
                    break;
                case EppQueueCommands.ContactTransferApprove:
                case EppQueueCommands.ContactTransferCancel:
                case EppQueueCommands.ContactTransferQuery:
                case EppQueueCommands.ContactTransferReject:
                case EppQueueCommands.ContactTransferRequest:
                    return new ResponseMessage<TransferResponse<ResContactTransfer>>(document);
                case EppQueueCommands.DomainCheck:
                    {
                        var resEpp2 = new ResponseMessage<CheckResponse<ResDomainCheck>>(document);
                        if (resEpp2.CommandSucceeded)
                        {
                            var res = new ResDomainCheck();
                            if (resEpp2.Response != null)
                            {
                                res.DomainInfos = new List<ResDomainCheck.CheckInfo>();
                                res.DomainInfos.AddRange(resEpp2.Response.Result.DomainInfos);
                            }
                            res.ExtLaunch = resEpp2.Extension<Protocol.Launch.chkDataType>();
                            res.ExtPrice = resEpp2.Extension<Protocol.Price.chkDataType>();
                            res.ExtPremiumDomain = resEpp2.Extension<Protocol.PremiumDomain.chkDataType>();
                            res.ExtFee05 = resEpp2.Extension<Protocol.Fee05.chkDataType>();
                            res.ExtFee06 = resEpp2.Extension<Protocol.Fee06.chkDataType>();
                            res.ExtFee07 = resEpp2.Extension<Protocol.Fee07.chkDataType>();
                            res.ExtCharge = resEpp2.Extension<Protocol.Charge.chkRespType>();
                            return res;
                        }
                        resEpp = resEpp2;
                        break;
                    }
                case EppQueueCommands.DomainCreate:
                    resEpp = new ResponseMessage<CreateResponse<ResDomainCreate>>(document);
                    break;
                case EppQueueCommands.DomainInfo:
                    {
                        var resEpp2 = new ResponseMessage<InfoResponse<ResDomainInfo>>(document);
                        resEpp2.Response.Result.ExtLaunch = resEpp2.Extension<Protocol.Launch.infDataType>();
                        resEpp2.Response.Result.ExtRgp = resEpp2.Extension<Protocol.Rgp.respDataType>();
                        resEpp2.Response.Result.ExtKeySys = resEpp2.Extension<Protocol.KeySys.resDataType>();
                        resEpp = resEpp2;
                        break;
                    }
                case EppQueueCommands.DomainRenew:
                    resEpp = new ResponseMessage<RenewResponse<ResDomainRenew>>(document);
                    break;
                case EppQueueCommands.DomainTransferApprove:
                case EppQueueCommands.DomainTransferCancel:
                case EppQueueCommands.DomainTransferQuery:
                case EppQueueCommands.DomainTransferReject:
                case EppQueueCommands.DomainTransferRequest:
                    resEpp = new ResponseMessage<TransferResponse<ResDomainTransfer>>(document);
                    break;
                case EppQueueCommands.HostCheck:
                    resEpp = new ResponseMessage<CheckResponse<ResHostCheck>>(document);
                    break;
                case EppQueueCommands.HostCreate:
                    resEpp = new ResponseMessage<CreateResponse<ResHostCreate>>(document);
                    break;
                case EppQueueCommands.HostInfo:
                    resEpp = new ResponseMessage<InfoResponse<ResHostInfo>>(document);
                    break;
                case EppQueueCommands.Login:
                case EppQueueCommands.Logout:
                case EppQueueCommands.Hello:
                case EppQueueCommands.PollRequest:
                case EppQueueCommands.PollAcknowledge:
                case EppQueueCommands.DebugThrowException:
                case EppQueueCommands.DebugKillEppConnection:
                    break;
                case EppQueueCommands.FinanceInfo:
                    resEpp = new ResponseMessage<InfoResponse<ResFinanceInfo>>(document);
                    break;
            }

            return resEpp;
        }

        public static void DoSomethingSpecialForTld(string domainName, ReqDomainCheck req)
        {

            //if (domainName.ToLower().EndsWith(".club") && req.ExtLaunch == null)
            //    req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".bid") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".webcam") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".trade") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            //
            if (domainName.ToLower().EndsWith(".science") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".party") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".cricket") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };

            if (domainName.ToLower().EndsWith(".accountant") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".download") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".loan ") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".racing") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".win") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".date") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".faith") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };
            if (domainName.ToLower().EndsWith(".review") && req.ExtLaunch == null)
                req.ExtLaunch = new Protocol.Launch.checkType() { type = Protocol.Launch.checkFormType.avail, phase = new Protocol.Launch.phaseType() { Value = Protocol.Launch.phaseTypeValue.claims } };

            /*new List<string>{".bid", ".webcam", ".trade", ".science", ".party", ".cricket", ".accountant", ".download", ".loan", ".racing", ".win", ".date", ".faith", ".review"}
                .*/
        }
    }
}
