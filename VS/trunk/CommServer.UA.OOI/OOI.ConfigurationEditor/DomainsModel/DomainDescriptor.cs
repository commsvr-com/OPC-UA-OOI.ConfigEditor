﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://commsvr.com/CAS/CommServer/UA/OOI/ConfigurationEditor/DomainsModel/DomainD" +
        "escriptor.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://commsvr.com/CAS/CommServer/UA/OOI/ConfigurationEditor/DomainsModel/DomainD" +
        "escriptor.xsd", IsNullable=true)]
    public partial class DomainDescriptor {
        
        private string descriptionField;
        
        private string urlPatternField;
        
        private RecordType nextStepRecordTypeField;
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string UrlPattern {
            get {
                return this.urlPatternField;
            }
            set {
                this.urlPatternField = value;
            }
        }
        
        /// <remarks/>
        public RecordType NextStepRecordType {
            get {
                return this.nextStepRecordTypeField;
            }
            set {
                this.nextStepRecordTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://commsvr.com/CAS/CommServer/UA/OOI/ConfigurationEditor/DomainsModel/DomainD" +
        "escriptor.xsd")]
    public enum RecordType {
        
        /// <remarks/>
        DomainModel,
        
        /// <remarks/>
        DomainDescriptor,
    }
}