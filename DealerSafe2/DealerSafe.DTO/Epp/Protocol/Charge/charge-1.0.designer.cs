// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.37595
//    <NameSpace>DealerSafe.DTO.Epp.Protocol.</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>True</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net40</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>True</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------


using System.Linq;

namespace DealerSafe.DTO.Epp.Protocol.Charge {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    using DealerSafe.DTO.Epp.Protocol;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("agreement", Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=false)]
    public partial class setListType : GeneratedEppEntity<setListType> {
        
        private List<setType> setField;
        
        /// <summary>
        /// setListType class constructor
        /// </summary>
        public setListType() {
            this.setField = new List<setType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("set", Order=0)]
        public List<setType> set {
            get {
                return this.setField;
            }
            set {
                this.setField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=true)]
    public partial class setType : GeneratedEppEntity<setType> {
        
        private categoryType categoryField;
        
        private setAttrType typeField;
        
        private List<amountType> amountField;
        
        /// <summary>
        /// setType class constructor
        /// </summary>
        public setType() {
            this.amountField = new List<amountType>();
            this.typeField = new setAttrType();
            this.categoryField = new categoryType();
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public categoryType category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public setAttrType type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute("amount", Order=2)]
        public List<amountType> amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=true)]
    public partial class categoryType : GeneratedEppEntity<categoryType> {
        
        private string nameField;
        
        private string valueField;
        
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
    public string name {get; set;}

    [System.Xml.Serialization.XmlTextAttribute(DataType="token")]
    public string Value {get; set;}

    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=true)]
    public partial class amountType : GeneratedEppEntity<amountType> {
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string name {get; set;}

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value {get; set;}
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public commandTypeValue command {get; set; }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    public enum commandTypeValue {
        
        /// <remarks/>
        check,
        
        /// <remarks/>
        create,
        
        /// <remarks/>
        delete,
        
        /// <remarks/>
        info,
        
        /// <remarks/>
        renew,
        
        /// <remarks/>
        transfer,
        
        /// <remarks/>
        update,
        
        /// <remarks/>
        custom,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=true)]
    public partial class setAttrType : GeneratedEppEntity<setAttrType> {
        
        private string nameField;
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="token")]
        public string name {get; set;}

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    public enum setTypeValue {
        
        /// <remarks/>
        fee,
        
        /// <remarks/>
        price,
        
        /// <remarks/>
        custom,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute("chkData", Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=false)]
    public partial class chkRespType : GeneratedEppEntity<chkRespType> {
        
        private List<checkType> cdField;
        
        /// <summary>
        /// chkRespType class constructor
        /// </summary>
        public chkRespType() {
            this.cdField = new List<checkType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("cd", Order=0)]
        public List<checkType> cd {
            get {
                return this.cdField;
            }
            set {
                this.cdField = value;
            }
        }

        public checkType getByDomainName(string domainName)
        {
            return cdField.FirstOrDefault(i => i.name.ToLowerInvariant() == domainName.ToLowerInvariant());
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.unitedtld.com/epp/charge-1.0", IsNullable=true)]
    public partial class checkType : GeneratedEppEntity<checkType> {
        
        private string nameField;
        
        private List<setType> setField;
        
    [System.Xml.Serialization.XmlElementAttribute(DataType="token",Order=0)]
    public string name {get; set;}

        
        /// <summary>
        /// checkType class constructor
        /// </summary>
        public checkType() {
            this.setField = new List<setType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("set", Order=1)]
        public List<setType> set {
            get {
                return this.setField;
            }
            set {
                this.setField = value;
            }
        }
    }
}
