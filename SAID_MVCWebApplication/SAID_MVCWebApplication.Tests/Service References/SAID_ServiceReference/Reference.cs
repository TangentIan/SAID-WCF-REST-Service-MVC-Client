﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAID_MVCWebApplication.Tests.SAID_ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SAID_ServiceReference.ISAIDGeneratorService")]
    public interface ISAIDGeneratorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAIDGeneratorService/GenerateRandomSAIDNumber", ReplyAction="http://tempuri.org/ISAIDGeneratorService/GenerateRandomSAIDNumberResponse")]
        SAID_MVCWebApplication.SAID_ServiceReference.SAIDGeneratorResponse GenerateRandomSAIDNumber();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISAIDGeneratorService/ValidateSAIDNumber", ReplyAction="http://tempuri.org/ISAIDGeneratorService/ValidateSAIDNumberResponse")]
        SAID_MVCWebApplication.SAID_ServiceReference.SAIDGeneratorResponse ValidateSAIDNumber(string IDNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISAIDGeneratorServiceChannel : SAID_MVCWebApplication.Tests.SAID_ServiceReference.ISAIDGeneratorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SAIDGeneratorServiceClient : System.ServiceModel.ClientBase<SAID_MVCWebApplication.Tests.SAID_ServiceReference.ISAIDGeneratorService>, SAID_MVCWebApplication.Tests.SAID_ServiceReference.ISAIDGeneratorService {
        
        public SAIDGeneratorServiceClient() {
        }
        
        public SAIDGeneratorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SAIDGeneratorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SAIDGeneratorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SAIDGeneratorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SAID_MVCWebApplication.SAID_ServiceReference.SAIDGeneratorResponse GenerateRandomSAIDNumber() {
            return base.Channel.GenerateRandomSAIDNumber();
        }
        
        public SAID_MVCWebApplication.SAID_ServiceReference.SAIDGeneratorResponse ValidateSAIDNumber(string IDNumber) {
            return base.Channel.ValidateSAIDNumber(IDNumber);
        }
    }
}
