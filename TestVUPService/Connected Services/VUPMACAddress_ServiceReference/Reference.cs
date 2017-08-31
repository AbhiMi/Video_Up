﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestVUPService.VUPMACAddress_ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VUPMacAddressesDetails", Namespace="http://schemas.datacontract.org/2004/07/VUPMACService")]
    [System.SerializableAttribute()]
    public partial class VUPMacAddressesDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Data.DataTable VUPMacAddressesesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Data.DataTable VUPMacAddresseses {
            get {
                return this.VUPMacAddressesesField;
            }
            set {
                if ((object.ReferenceEquals(this.VUPMacAddressesesField, value) != true)) {
                    this.VUPMacAddressesesField = value;
                    this.RaisePropertyChanged("VUPMacAddresseses");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VUPMACAddress_ServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateVUPMACAddress", ReplyAction="http://tempuri.org/IService1/CreateVUPMACAddressResponse")]
        bool CreateVUPMACAddress(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateVUPMACAddress", ReplyAction="http://tempuri.org/IService1/CreateVUPMACAddressResponse")]
        System.Threading.Tasks.Task<bool> CreateVUPMACAddressAsync(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetVUPMACAddresses", ReplyAction="http://tempuri.org/IService1/GetVUPMACAddressesResponse")]
        TestVUPService.VUPMACAddress_ServiceReference.VUPMacAddressesDetails GetVUPMACAddresses(string strVideoUpID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetVUPMACAddresses", ReplyAction="http://tempuri.org/IService1/GetVUPMACAddressesResponse")]
        System.Threading.Tasks.Task<TestVUPService.VUPMACAddress_ServiceReference.VUPMacAddressesDetails> GetVUPMACAddressesAsync(string strVideoUpID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteVUPMACAddresses", ReplyAction="http://tempuri.org/IService1/DeleteVUPMACAddressesResponse")]
        bool DeleteVUPMACAddresses(int CompanyID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteVUPMACAddresses", ReplyAction="http://tempuri.org/IService1/DeleteVUPMACAddressesResponse")]
        System.Threading.Tasks.Task<bool> DeleteVUPMACAddressesAsync(int CompanyID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TestVUPService.VUPMACAddress_ServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TestVUPService.VUPMACAddress_ServiceReference.IService1>, TestVUPService.VUPMACAddress_ServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateVUPMACAddress(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress) {
            return base.Channel.CreateVUPMACAddress(companyID, vupID, strEthernetMACAddress, strWirelessMACAddress);
        }
        
        public System.Threading.Tasks.Task<bool> CreateVUPMACAddressAsync(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress) {
            return base.Channel.CreateVUPMACAddressAsync(companyID, vupID, strEthernetMACAddress, strWirelessMACAddress);
        }
        
        public TestVUPService.VUPMACAddress_ServiceReference.VUPMacAddressesDetails GetVUPMACAddresses(string strVideoUpID) {
            return base.Channel.GetVUPMACAddresses(strVideoUpID);
        }
        
        public System.Threading.Tasks.Task<TestVUPService.VUPMACAddress_ServiceReference.VUPMacAddressesDetails> GetVUPMACAddressesAsync(string strVideoUpID) {
            return base.Channel.GetVUPMACAddressesAsync(strVideoUpID);
        }
        
        public bool DeleteVUPMACAddresses(int CompanyID) {
            return base.Channel.DeleteVUPMACAddresses(CompanyID);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteVUPMACAddressesAsync(int CompanyID) {
            return base.Channel.DeleteVUPMACAddressesAsync(CompanyID);
        }
    }
}
