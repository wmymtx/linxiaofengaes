﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TokenTest_for4a.CheckAiuapTokenSoap {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://10.109.209.100:9081/uac/services/CheckAiuapTokenSoap", ConfigurationName="CheckAiuapTokenSoap.CommonTokenService")]
    public interface CommonTokenService {
        
        // CODEGEN: 消息 CheckAiuapTokenSoapRequest 的包装命名空间(http://service.base.app.core.a4.asiainfo.com)以后生成的消息协定与默认值(http://10.109.209.100:9081/uac/services/CheckAiuapTokenSoap)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapResponse CheckAiuapTokenSoap(TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapResponse> CheckAiuapTokenSoapAsync(TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckAiuapTokenSoap", WrapperNamespace="http://service.base.app.core.a4.asiainfo.com", IsWrapped=true)]
    public partial class CheckAiuapTokenSoapRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string RequestInfo;
        
        public CheckAiuapTokenSoapRequest() {
        }
        
        public CheckAiuapTokenSoapRequest(string RequestInfo) {
            this.RequestInfo = RequestInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckAiuapTokenSoapResponse", WrapperNamespace="http://10.109.209.100:9081/uac/services/CheckAiuapTokenSoap", IsWrapped=true)]
    public partial class CheckAiuapTokenSoapResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string CheckAiuapTokenSoapReturn;
        
        public CheckAiuapTokenSoapResponse() {
        }
        
        public CheckAiuapTokenSoapResponse(string CheckAiuapTokenSoapReturn) {
            this.CheckAiuapTokenSoapReturn = CheckAiuapTokenSoapReturn;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CommonTokenServiceChannel : TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommonTokenServiceClient : System.ServiceModel.ClientBase<TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService>, TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService {
        
        public CommonTokenServiceClient() {
        }
        
        public CommonTokenServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommonTokenServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommonTokenServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommonTokenServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapResponse TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService.CheckAiuapTokenSoap(TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest request) {
            return base.Channel.CheckAiuapTokenSoap(request);
        }
        
        public string CheckAiuapTokenSoap(string RequestInfo) {
            TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest inValue = new TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest();
            inValue.RequestInfo = RequestInfo;
            TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapResponse retVal = ((TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService)(this)).CheckAiuapTokenSoap(inValue);
            return retVal.CheckAiuapTokenSoapReturn;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapResponse> TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService.CheckAiuapTokenSoapAsync(TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest request) {
            return base.Channel.CheckAiuapTokenSoapAsync(request);
        }
        
        public System.Threading.Tasks.Task<TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapResponse> CheckAiuapTokenSoapAsync(string RequestInfo) {
            TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest inValue = new TokenTest_for4a.CheckAiuapTokenSoap.CheckAiuapTokenSoapRequest();
            inValue.RequestInfo = RequestInfo;
            return ((TokenTest_for4a.CheckAiuapTokenSoap.CommonTokenService)(this)).CheckAiuapTokenSoapAsync(inValue);
        }
    }
}