using System;
using System.Collections.Generic;
using System.Linq;
using Epp.Protocol.Commands;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Response data for host check command
    /// </summary>
    [Serializable]
    public class ResHostCheck : ICommandResult<ResHostCheck>
    {
        /// <summary>
        /// Gets information about checked hosts
        /// </summary>
        public List<CheckInfo> HostInfos { get; set; }

        #region ICommandResult<HostCheckResult> Members

        /// <summary>
        /// Extracts result from underlying check response
        /// </summary>
        /// <param name="response">Check response</param>
        public void ExtractResult(ResponseBase<ResHostCheck> response)
        {
            this.HostInfos = response
                .GetCDItems()
                .Select(cd => new CheckInfo(cd.ObjectElement.Value, cd.Available, cd.Reason))
                .ToList();
        }

        #endregion

        #region Nested type: CheckInfo

        /// <summary>
        /// Information about one checked host
        /// </summary>
        [Serializable]
        public class CheckInfo
        {
            /// <summary>
            /// Initializes a new instance of the CheckInfo class
            /// </summary>
            /// <param name="hostName">Checked host name</param>
            /// <param name="available">Wehether host is available for provisioning</param>
            /// <param name="reason">Reason of unavailablity or null</param>
            public CheckInfo(string hostName, bool available, string reason)
            {
                this.HostName = hostName;
                this.Available = available;
                this.Reason = reason;
            }
            public CheckInfo()
            {
            }
            /// <summary>
            /// Gets the checked domain identifier
            /// </summary>
            public string HostName { get; set; }

            /// <summary>
            /// Gets a value indicating whether domain is available for provisioning
            /// </summary>
            public bool Available { get; set; }

            /// <summary>
            /// Gets the reason of unavailablity if any
            /// </summary>
            public string Reason { get; set; }
        }

        #endregion


        public bool IsAvailable(string hostName)
        {
            var hostInfo = HostInfos.First(ci => ci.HostName == hostName);
            return hostInfo == null ? false : hostInfo.Available;
        }
    }
}