namespace Epp.Protocol.Configuration
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Represents dates configuration element
    /// </summary>
    public class DatesConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets dates provider type name
        /// </summary>
        [ConfigurationProperty("dateProvider", IsRequired = false)]
        public string DateProvider
        {
            get
            {
                return this["dateProvider"].ToString() ?? String.Empty;
            }

            set
            {
                this["dateProvider"] = value;
            }
        }

        /// <summary>
        /// Gets dates provider type
        /// </summary>
        public Type ProviderType
        {
            get
            {
                return Type.GetType(this.DateProvider);
            }
        }
    }
}
