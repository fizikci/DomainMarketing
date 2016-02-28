namespace Epp.Protocol.Configuration
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Represents license configuration element
    /// </summary>
    public class LicenseConfigurationElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets licence key
        /// </summary>
        [ConfigurationProperty("key", Options = ConfigurationPropertyOptions.IsRequired)]
        public string Key
        {
            get
            {
                return this["key"].ToString();
            }

            set
            {
                this["key"] = value;
            }
        }

        /// <summary>
        /// Gets or sets company name
        /// </summary>
        [ConfigurationProperty("companyName", IsRequired = false)]
        public string CompanyName
        {
            get
            {
                return this["companyName"].ToString() ?? String.Empty;
            }

            set
            {
                this["companyName"] = value;
            }
        }
    }
}
