using System;
using System.Collections.Generic;
using System.Linq;
using launch = DealerSafe.DTO.Epp.Protocol.Launch;
using premium = DealerSafe.DTO.Epp.Protocol.PremiumDomain;
using price = DealerSafe.DTO.Epp.Protocol.Price;
using fee05 = DealerSafe.DTO.Epp.Protocol.Fee05;
using fee06 = DealerSafe.DTO.Epp.Protocol.Fee06;
using fee07 = DealerSafe.DTO.Epp.Protocol.Fee07;
using charge = DealerSafe.DTO.Epp.Protocol.Charge;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Response data for domain check command
    /// </summary>
    [Serializable]
    public class ResDomainCheck : ICommandResult<ResDomainCheck>
    {
        /// <summary>
        /// Gets information about checked domains
        /// </summary>
        public List<CheckInfo> DomainInfos { get; set; }

        #region ICommandResult<DomainCheckResult> Members

        /// <summary>
        /// Extracts result from underlying check response
        /// </summary>
        /// <param name="response">Check response</param>
        public void ExtractResult(ResponseBase<ResDomainCheck> response)
        {
            this.DomainInfos = response
                .GetCDItems()
                .Select(cd => new CheckInfo(cd.ObjectElement.Value, cd.Available, cd.Reason))
                .ToList();
        }

        #endregion

        public launch.chkDataType ExtLaunch { get; set; }
        public premium.chkDataType ExtPremiumDomain { get; set; }
        public price.chkDataType ExtPrice { get; set; }
        public fee05.chkDataType ExtFee05 { get; set; }
        public fee06.chkDataType ExtFee06 { get; set; }
        public fee07.chkDataType ExtFee07 { get; set; }
        public charge.chkRespType ExtCharge { get; set; }

        #region Nested type: CheckInfo

        /// <summary>
        /// Information about one checked domain
        /// </summary>
        [Serializable]
        public class CheckInfo
        {
            /// <summary>
            /// Initializes a new instance of the CheckInfo class
            /// </summary>
            /// <param name="domainName">Checked domain name</param>
            /// <param name="available">Wehether domain is available for provisioning</param>
            /// <param name="reason">Reason of unavailablity or null</param>
            public CheckInfo(string domainName, bool available, string reason)
            {
                this.DomainName = domainName;
                this.Available = available;
                this.Reason = reason;
            }

            public CheckInfo()
            {
            }

            /// <summary>
            /// Gets the checked domain identifier
            /// </summary>
            public string DomainName { get; set; }

            /// <summary>
            /// Gets a value indicating whether domain is available for provisioning
            /// </summary>
            public bool Available { get; set; }

            /// <summary>
            /// Gets the reason of unavailablity if any
            /// </summary>
            public string Reason { get; set; }

            public int JobId { get; set; }
        }

        #endregion

    }
}