using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Epp.Protocol;
using Epp.Protocol.Commands;
using Epp.Protocol.Domains;
using Epp.Protocol.Shared;

namespace DealerSafe.DTO.Epp.Response
{
    /// <summary>
    /// Represents the info data for the domain
    /// </summary>
    [Serializable]
    public class ResFinanceInfo : CommandResult<ResFinanceInfo>, IEppExtension
    {
        /// <summary>
        /// Gets the list of domain statuses
        /// </summary>
        public List<ThresholdInfo> Thresholds { get; set; }

        /// <summary>
        /// Gets domain registrant
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Extracts result from underlying info response
        /// </summary>
        /// <param name="response">Info response</param>
        public override void ExtractResult(ResponseBase<ResFinanceInfo> response)
        {
            base.ExtractResult(response);
            this.Extract(response.GetResultElement());
        }

        #region IEppExtension Members

        /// <summary>
        /// Extracts data from XML element
        /// </summary>
        /// <param name="objectElement">Object XML element</param>
        public void Extract(XElement objectElement)
        {
            this.Balance = decimal.Parse(objectElement.Element(SchemaHelper.FinanceNs.GetName("balance")).Value);
            this.Thresholds = objectElement
                .Elements(SchemaHelper.FinanceNs.GetName("threshold"))
                .Select(thElem =>
                {
                    var type = EnumParser.ToEnum<ThresholdTypes>((string) thElem.Attribute("type").Value);
                    var val = decimal.Parse(thElem.Value);
                    return new ThresholdInfo(){Type = type, Value = val};
                })
                .ToList();
        }

        #endregion
    }

    /// <summary>
    /// Represents Threshold information
    /// </summary>
    [Serializable]
    public class ThresholdInfo
    {
        public ThresholdTypes Type { get; set; }

        public decimal Value { get; set; }

        public static ThresholdInfo Extract(XElement thresholdInfoElement)
        {
            var val = decimal.Parse(thresholdInfoElement.Value);
            var type = thresholdInfoElement.Attribute("type").Value.ToLowerInvariant().ToEnum<ThresholdTypes>();

            return new ThresholdInfo(){Type = type, Value = val};
        }

        public void Fill(XElement thresholdInfoElement)
        {
            var ch = this.Type.ToString().ToLowerInvariant()[0];
            var type = this.Type.ToString();
            type = ch + type.Remove(0, 1);
            thresholdInfoElement.Add(new XAttribute("type", type));
            thresholdInfoElement.SetValue(this.Value);
        }
    }

    public enum ThresholdTypes
    {
        Final,
        Restricted,
        Notification
    }
}