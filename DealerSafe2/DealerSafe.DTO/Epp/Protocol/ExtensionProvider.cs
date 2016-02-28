using DealerSafe.DTO.Epp.Request;
using DealerSafe.DTO.Epp.Response;

namespace Epp.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Contacts;
    using Domains;
    using Hosts;
    using Reflection;
    using SecDns;

    /// <summary>
    /// This assembly extension provider
    /// </summary>
    internal class ExtensionProvider : EppExtensionProvider
    {
        /// <summary>
        /// Returns extensions provided by this assembly
        /// </summary>
        /// <returns>Extensions provided by this assembly</returns>
        public override IEnumerable<KeyValuePair<XName, Type>> GetExtensions()
        {
            yield return new KeyValuePair<XName, Type>(SchemaHelper.ContactNs.GetName("infData"), typeof(ResContactInfo));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.DomainNs.GetName("infData"), typeof(ResDomainInfo));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.HostNs.GetName("infData"), typeof(ResHostInfo));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.SecDns10Ns.GetName("infData"), typeof(DnsSecurityExtension));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.SecDnsNs.GetName("infData"), typeof(DnsSecurityExtension));
            
            yield return new KeyValuePair<XName, Type>(SchemaHelper.DomainNs.GetName("trnData"), typeof(ResDomainTransfer));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.ContactNs.GetName("trnData"), typeof(ResContactTransfer));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.ContactNs.GetName("delete"), typeof(ReqContactDelete));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.DomainNs.GetName("delete"), typeof(ReqDomainDelete));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.HostNs.GetName("delete"), typeof(ReqHostDelete));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.FinanceNs.GetName("infData"), typeof(ResFinanceInfo));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.LaunchNs.GetName("check"), typeof(DealerSafe.DTO.Epp.Protocol.Launch.checkType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.LaunchNs.GetName("info"), typeof(DealerSafe.DTO.Epp.Protocol.Launch.infoType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.LaunchNs.GetName("create"), typeof(DealerSafe.DTO.Epp.Protocol.Launch.createType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.LaunchNs.GetName("update"), typeof(DealerSafe.DTO.Epp.Protocol.Launch.idContainerType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.LaunchNs.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.Launch.chkDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.LaunchNs.GetName("infData"), typeof(DealerSafe.DTO.Epp.Protocol.Launch.infDataType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.BalanceNs.GetName("infData"), typeof(DealerSafe.DTO.Epp.Protocol.Balance.infDataType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.PremiumDomainNs.GetName("check"), typeof(DealerSafe.DTO.Epp.Protocol.PremiumDomain.checkType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.PremiumDomainNs.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.PremiumDomain.chkDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.PremiumDomainNs.GetName("reassign"), typeof(DealerSafe.DTO.Epp.Protocol.PremiumDomain.reassignType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.RgpNs.GetName("infData"), typeof(DealerSafe.DTO.Epp.Protocol.Rgp.respDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.RgpNs.GetName("update"), typeof(DealerSafe.DTO.Epp.Protocol.Rgp.updateType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.NameStoreNs.GetName("namestoreExt"), typeof(DealerSafe.DTO.Epp.Protocol.NameStore.namestoreExtType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.KeySysNs.GetName("resData"), typeof(DealerSafe.DTO.Epp.Protocol.KeySys.resDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.KeySysNs.GetName("infData"), typeof(DealerSafe.DTO.Epp.Protocol.KeySys.infDataType));
            //yield return new KeyValuePair<XName, Type>(SchemaHelper.KeySysNs.GetName("create"), typeof(DealerSafe.DTO.Epp.Protocol.KeySys.createType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.KeySysNs.GetName("update"), typeof(DealerSafe.DTO.Epp.Protocol.KeySys.updateType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee07Ns.GetName("check"), typeof(DealerSafe.DTO.Epp.Protocol.Fee07.checkType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee07Ns.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.Fee07.chkDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee07Ns.GetName("fee"), typeof(DealerSafe.DTO.Epp.Protocol.Fee07.feeType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee06Ns.GetName("check"), typeof(DealerSafe.DTO.Epp.Protocol.Fee06.checkType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee06Ns.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.Fee06.chkDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee06Ns.GetName("fee"), typeof(DealerSafe.DTO.Epp.Protocol.Fee06.feeType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee05Ns.GetName("check"), typeof(DealerSafe.DTO.Epp.Protocol.Fee05.checkType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee05Ns.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.Fee05.chkDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.Fee05Ns.GetName("fee"), typeof(DealerSafe.DTO.Epp.Protocol.Fee05.feeType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.PriceNs.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.Price.chkDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.PriceNs.GetName("creData"), typeof(DealerSafe.DTO.Epp.Protocol.Price.creDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.PriceNs.GetName("trnData"), typeof(DealerSafe.DTO.Epp.Protocol.Price.trnDataType));
            yield return new KeyValuePair<XName, Type>(SchemaHelper.PriceNs.GetName("renData"), typeof(DealerSafe.DTO.Epp.Protocol.Price.renDataType));

            yield return new KeyValuePair<XName, Type>(SchemaHelper.ChargeNs.GetName("chkData"), typeof(DealerSafe.DTO.Epp.Protocol.Charge.chkRespType));
        }
    }
}