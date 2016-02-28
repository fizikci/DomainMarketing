namespace Epp.Protocol
{
    using System.Collections.Generic;
    using DealerSafe.DTO.Properties;
    using Reflection;

    /// <summary>
    /// This assembly schema provider
    /// </summary>
    internal class SchemaProvider : XmlSchemaProvider
    {
        /// <summary>
        /// Returns schemas provided by this assembly
        /// </summary>
        /// <returns>Schemas provided by this assembly</returns>
        public override IEnumerable<string> GetSchemas()
        {
            yield return Resources.eppcom_1_0;
            yield return Resources.epp_1_0;
            yield return Resources.host_1_0;
            yield return Resources.contact_1_0;
            yield return Resources.domain_1_0;
            yield return Resources.secDNS_1_0;
            yield return Resources.finance_1_0;
            yield return Resources.launch_1_0;
            yield return Resources.mark_1_0;
            yield return Resources.signedMark_1_0;
            yield return Resources.xmldsig_core_schema;
            yield return Resources.balance_1_0;
            yield return Resources.namestoreExt_1_1;
            yield return Resources.premiumdomain_1_0;
            yield return Resources.rgp_1_0;
            yield return Resources.fee_0_5;
            yield return Resources.fee_0_6;
            yield return Resources.fee_0_7;
        }
    }
}