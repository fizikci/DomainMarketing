namespace Epp.Protocol.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Represents transport configuration element
    /// </summary>
    public class TransportConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets transport operation timeout (socket connect, socket send, socket receive) in milliseconds. Default value is 30000
        /// </summary>
        [ConfigurationProperty("operationTimeout", IsRequired = false)]
        public int OperationTimeout
        {
            get
            {
                var maxMessageCount = (int?)this["operationTimeout"] ?? 30000;
                return (maxMessageCount == 0) ? 30000 : maxMessageCount;
            }

            set
            {
                this["operationTimeout"] = value;
            }
        }
    }
}
