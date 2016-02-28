namespace Epp.Protocol.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Helps retrieve EPP configuration section
    /// </summary>
    public static class EppConfigurationManager
    {
        /// <summary>
        /// Gets "epp" configuration section
        /// </summary>
        public static EppConfigurationSection Root
        {
            get
            {
                return (EppConfigurationSection)ConfigurationManager.GetSection("epp");
            }
        }
    }
}