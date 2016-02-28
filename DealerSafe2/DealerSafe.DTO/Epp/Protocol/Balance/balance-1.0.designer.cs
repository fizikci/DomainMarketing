// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.37595
//    <NameSpace>DealerSafe.DTO.Epp.Protocol.Balance</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>True</UseBaseClass><GenBaseClass>True</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace DealerSafe.DTO.Epp.Protocol.Balance
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;


    public partial class thresholdType : GeneratedEppEntity<thresholdType>
    {

        private object itemField;

        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    public partial class infDataType : GeneratedEppEntity<infDataType>
    {

        private decimal creditLimitField;

        private decimal balanceField;

        private decimal availableCreditField;

        private thresholdType creditThresholdField;

        /// <summary>
        /// infDataType class constructor
        /// </summary>
        public infDataType()
        {
            this.creditThresholdField = new thresholdType();
        }

        public decimal creditLimit
        {
            get
            {
                return this.creditLimitField;
            }
            set
            {
                this.creditLimitField = value;
            }
        }

        public decimal balance
        {
            get
            {
                return this.balanceField;
            }
            set
            {
                this.balanceField = value;
            }
        }

        public decimal availableCredit
        {
            get
            {
                return this.availableCreditField;
            }
            set
            {
                this.availableCreditField = value;
            }
        }

        public thresholdType creditThreshold
        {
            get
            {
                return this.creditThresholdField;
            }
            set
            {
                this.creditThresholdField = value;
            }
        }
    }
}