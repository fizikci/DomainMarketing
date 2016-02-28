namespace Epp.Protocol.SecDns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Extension object for providing DNS Security Extensions when updating domain objects
    /// </summary>
    [Serializable]
    public class DnsSecurityUpdateExtension : ICommandExtension
    {
        /// <summary>
        /// Initializes a new instance of the DnsSecurityUpdateExtension class
        /// </summary>
        /// <param name="operationType">Update operation type</param>
        /// <param name="delSigData">Set of adding or changing delegation signer data items</param>
        public DnsSecurityUpdateExtension(UpdateOperationType operationType, params DelegationSignerData[] delSigData)
        {
            if (delSigData == null)
            {
                throw new ArgumentNullException("delSigData");
            }

            if (delSigData.Length == 0)
            {
                throw new ArgumentException("parameter must contain at least one DelegationSignerData object", "delSigData");
            }

            if (operationType == UpdateOperationType.Remove)
            {
                throw new ArgumentOutOfRangeException("operationType");
            }

            this.DelSigData = Array.AsReadOnly(delSigData);
            this.OperationType = operationType;
        }

        /// <summary>
        /// Initializes a new instance of the DnsSecurityUpdateExtension class
        /// </summary>
        /// <param name="removingKeyTags">Removing key tags</param>
        public DnsSecurityUpdateExtension(params ushort[] removingKeyTags)
        {
            this.RemovingKeyTags = removingKeyTags;
            this.OperationType = UpdateOperationType.Remove;
        }

        /// <summary>
        /// Update operation type
        /// </summary>
        public enum UpdateOperationType
        {
            /// <summary>
            /// Data adding operation
            /// </summary>
            Add,

            /// <summary>
            /// Data modifying operation
            /// </summary>
            Change,

            /// <summary>
            /// Data removing operation
            /// </summary>
            Remove
        }

        /// <summary>
        /// Gets the update operation type
        /// </summary>
        public UpdateOperationType OperationType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the set of adding or changing delegation signer data items
        /// </summary>
        public IList<DelegationSignerData> DelSigData { get; set; }

        /// <summary>
        /// Gets the removing key tags
        /// </summary>
        public ushort[] RemovingKeyTags
        {
            get;
            set;
        }

        #region ICommandExtension Members

        /// <summary>
        /// Fills specified "extension" XML element of the command
        /// </summary>
        /// <param name="extensionElement">"extension" XML element</param>
        public void Fill(XElement extensionElement)
        {
            string operationElementName = String.Empty;
            switch (this.OperationType)
            {
                case UpdateOperationType.Add:
                    operationElementName = "add";
                    break;
                case UpdateOperationType.Change:
                    operationElementName = "chg";
                    break;
                case UpdateOperationType.Remove:
                    operationElementName = "rem";
                    break;
            }

            var operationElement = new XElement(SchemaHelper.SecDnsNs.GetName(operationElementName));
            var updateElement = new XElement(SchemaHelper.SecDnsNs.GetName("update"), operationElement);

            if (this.OperationType == UpdateOperationType.Add || this.OperationType == UpdateOperationType.Change)
            {
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

                    operationElement.Add(delSigDataElement);
                }
            }
            else
            {
                var keyTagsElements = this
                    .RemovingKeyTags
                    .Select(keyTag => new XElement(SchemaHelper.SecDnsNs.GetName("keyTag"), keyTag));
                operationElement.Add(keyTagsElements);
            }

            updateElement.AddSecDnsSchemaLocation();
            extensionElement.Add(updateElement);
        }

        #endregion
    }
}