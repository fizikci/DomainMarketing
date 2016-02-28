namespace Epp.Protocol.Configuration
{
    using System.Configuration;

    /// <summary>
    /// EPP configuration section. All EPP configurations placed inside
    /// </summary>
    public class EppConfigurationSection : ConfigurationSection
    {
        /// <summary>
        /// Gets or sets licence configuration section
        /// </summary>
        [ConfigurationProperty("license", IsRequired = false)]
        public LicenseConfigurationElement License
        {
            get
            {
                return (LicenseConfigurationElement)this["license"];
            }

            set
            {
                this["license"] = value;
            }
        }

        /// <summary>
        /// Gets or sets transport configuration section
        /// </summary>
        [ConfigurationProperty("transport", IsRequired = false)]
        public TransportConfigurationElement Transport
        {
            get
            {
                return (TransportConfigurationElement)this["transport"];
            }

            set
            {
                this["transport"] = value;
            }
        }

        /// <summary>
        /// Gets or sets dates configuration section
        /// </summary>
        [ConfigurationProperty("dates", IsRequired = false)]
        public DatesConfigurationElement Dates
        {
            get
            {
                return (DatesConfigurationElement)this["dates"];
            }

            set
            {
                this["dates"] = value;
            }
        }
    }
}
