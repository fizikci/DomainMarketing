using System.Security.Cryptography;
using System.Text;

namespace Epp.Protocol.SecDns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Extension object for providing DNS Security Extensions when creating and querying domain objects
    /// </summary>
    [Serializable]
    public class DnsSecurityExtension : ICommandExtension, IResponseExtension, IEppExtension
    {
        /// <summary>
        /// Initializes a new instance of the DnsSecurityExtension class
        /// </summary>
        public DnsSecurityExtension()
        {
        }

       
        /// <summary>
        /// Initializes a new instance of the DnsSecurityExtension class
        /// </summary>
        /// <param name="domainName">domain name for witch digest is generated</param>
        DnsSecurityExtension(string domainName)
        {
       

        }

        /// <summary>
        /// Initializes a new instance of the DnsSecurityExtension class
        /// </summary>
        /// <param name="delSigData">Set of delegation signer data items</param>
        public DnsSecurityExtension(params DelegationSignerData[] delSigData)
        {
            if (delSigData == null)
            {
                throw new ArgumentNullException("delSigData");
            }

            if (delSigData.Length == 0)
            {
                throw new ArgumentException("parameter must contain at least one DelegationSignerData object", "delSigData");
            }

            this.DelSigData = Array.AsReadOnly(delSigData);
        }

        /// <summary>
        /// Gets the set of delegation signer data items
        /// </summary>
        public IList<DelegationSignerData> DelSigData { get; set; }
        
        #region ICommandExtension Members

        /// <summary>
        /// Fills specified "extension" XML element of the command
        /// </summary>
        /// <param name="extensionElement">"extension" XML element</param>
        public void Fill(XElement extensionElement)
        {
            var createElement = new XElement(SchemaHelper.SecDnsNs.GetName("create"));
            foreach (var delSigDataItem in this.DelSigData)
            {
                var keyTagElement = new XElement(SchemaHelper.SecDnsNs.GetName("keyTag"), delSigDataItem.KeyTag);
                var algElement = new XElement(SchemaHelper.SecDnsNs.GetName("alg"), (byte)delSigDataItem.Algorithm);
                var digestTypeElement = new XElement(SchemaHelper.SecDnsNs.GetName("digestType"), (byte)delSigDataItem.DigestType);
                var digestElement = new XElement(SchemaHelper.SecDnsNs.GetName("digest"), delSigDataItem.Digest.ToHexString());
                var delSigDataElement = new XElement(SchemaHelper.SecDnsNs.GetName("dsData"), keyTagElement, algElement, digestTypeElement, digestElement);

                if (delSigDataItem.MaxSigLife.HasValue)
                {
                    delSigDataElement.Add(new XElement(SchemaHelper.SecDnsNs.GetName("maxSigLife"), delSigDataItem.MaxSigLife));
                }

                if (delSigDataItem.KeyData != null)
                {
                    var flagsElement = new XElement(SchemaHelper.SecDnsNs.GetName("flags"), (ushort)delSigDataItem.KeyData.Flags);
                    var protocolElement = new XElement(SchemaHelper.SecDnsNs.GetName("protocol"), delSigDataItem.KeyData.Protocol);
                    var algElement2 = new XElement(SchemaHelper.SecDnsNs.GetName("alg"), (byte)delSigDataItem.KeyData.Algorithm);
                    var pubKeyElement = new XElement(SchemaHelper.SecDnsNs.GetName("pubKey"), Convert.ToBase64String(delSigDataItem.KeyData.PublicKey));
                    var keyDataElement = new XElement(SchemaHelper.SecDnsNs.GetName("keyData"), flagsElement, protocolElement, algElement2, pubKeyElement);
                    delSigDataElement.Add(keyDataElement);
                }

                createElement.Add(delSigDataElement);
            }

            createElement.AddSecDnsSchemaLocation();
            extensionElement.Add(createElement);
        }

        #endregion

        #region IResponseExtension Members

        /// <summary>
        /// Extracts data from specified "extension" XML element of the response
        /// </summary>
        /// <param name="extensionElement">"extension" XML element</param>
        public void Extract(XElement extensionElement)
        {
            var infDataElement = extensionElement.Element(SchemaHelper.SecDnsNs.GetName("infData"));
            if (infDataElement == null)
            {
                return;
            }

            this.DelSigData = infDataElement
                .Elements(SchemaHelper.SecDnsNs.GetName("dsData"))
                .Select(delSigDataElement =>
                        {
                            var delSigData = new DelegationSignerData(
                                    UInt16.Parse(delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("keyTag")).Value),
                                    (AlgorithmType)Byte.Parse(delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("alg")).Value),
                                    delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("digest")).Value.ToHexBinary());
                            var keyDataElement = delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("keyData"));
                            if (keyDataElement != null)
                            {
                                delSigData.KeyData = new KeyData(
                                        (KeyDataFlags)UInt16.Parse(keyDataElement.Element(SchemaHelper.SecDnsNs.GetName("flags")).Value),
                                        (AlgorithmType)Byte.Parse(keyDataElement.Element(SchemaHelper.SecDnsNs.GetName("alg")).Value),
                                        Convert.FromBase64String(keyDataElement.Element(SchemaHelper.SecDnsNs.GetName("pubKey")).Value));
                            }

                            return delSigData;
                        })
                .ToArray();
        }

        #endregion

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        void IEppExtension.Extract(XElement objectElement)
        {
            if (objectElement == null)
            {
                return;
            }

            this.DelSigData = objectElement
                .Elements(SchemaHelper.SecDnsNs.GetName("dsData"))
                .Select(delSigDataElement =>
                {
                    var delSigData = new DelegationSignerData(
                            UInt16.Parse(delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("keyTag")).Value),
                            (AlgorithmType)Byte.Parse(delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("alg")).Value),
                            delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("digest")).Value.ToHexBinary());
                    var keyDataElement = delSigDataElement.Element(SchemaHelper.SecDnsNs.GetName("keyData"));
                    if (keyDataElement != null)
                    {
                        delSigData.KeyData = new KeyData(
                                (KeyDataFlags)UInt16.Parse(keyDataElement.Element(SchemaHelper.SecDnsNs.GetName("flags")).Value),
                                (AlgorithmType)Byte.Parse(keyDataElement.Element(SchemaHelper.SecDnsNs.GetName("alg")).Value),
                                Convert.FromBase64String(keyDataElement.Element(SchemaHelper.SecDnsNs.GetName("pubKey")).Value));
                    }

                    return delSigData;
                })
                .ToArray();
        }

        #endregion
    }
}