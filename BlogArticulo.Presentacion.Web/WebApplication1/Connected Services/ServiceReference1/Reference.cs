﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ArticuloServicioWebSoap")]
    public interface ArticuloServicioWebSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento HelloWorldResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        WebApplication1.ServiceReference1.HelloWorldResponse HelloWorld(WebApplication1.ServiceReference1.HelloWorldRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.HelloWorldResponse> HelloWorldAsync(WebApplication1.ServiceReference1.HelloWorldRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento ObtenerArticulosResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerArticulos", ReplyAction="*")]
        WebApplication1.ServiceReference1.ObtenerArticulosResponse ObtenerArticulos(WebApplication1.ServiceReference1.ObtenerArticulosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerArticulos", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ObtenerArticulosResponse> ObtenerArticulosAsync(WebApplication1.ServiceReference1.ObtenerArticulosRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento idArticulo del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerArticuloPorId", ReplyAction="*")]
        WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponse ObtenerArticuloPorId(WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ObtenerArticuloPorId", ReplyAction="*")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponse> ObtenerArticuloPorIdAsync(WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference1.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(WebApplication1.ServiceReference1.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference1.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(WebApplication1.ServiceReference1.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerArticulosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerArticulos", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference1.ObtenerArticulosRequestBody Body;
        
        public ObtenerArticulosRequest() {
        }
        
        public ObtenerArticulosRequest(WebApplication1.ServiceReference1.ObtenerArticulosRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ObtenerArticulosRequestBody {
        
        public ObtenerArticulosRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerArticulosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerArticulosResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference1.ObtenerArticulosResponseBody Body;
        
        public ObtenerArticulosResponse() {
        }
        
        public ObtenerArticulosResponse(WebApplication1.ServiceReference1.ObtenerArticulosResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerArticulosResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ObtenerArticulosResult;
        
        public ObtenerArticulosResponseBody() {
        }
        
        public ObtenerArticulosResponseBody(string ObtenerArticulosResult) {
            this.ObtenerArticulosResult = ObtenerArticulosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerArticuloPorIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerArticuloPorId", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequestBody Body;
        
        public ObtenerArticuloPorIdRequest() {
        }
        
        public ObtenerArticuloPorIdRequest(WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerArticuloPorIdRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string idArticulo;
        
        public ObtenerArticuloPorIdRequestBody() {
        }
        
        public ObtenerArticuloPorIdRequestBody(string idArticulo) {
            this.idArticulo = idArticulo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ObtenerArticuloPorIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ObtenerArticuloPorIdResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponseBody Body;
        
        public ObtenerArticuloPorIdResponse() {
        }
        
        public ObtenerArticuloPorIdResponse(WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ObtenerArticuloPorIdResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ObtenerArticuloPorIdResult;
        
        public ObtenerArticuloPorIdResponseBody() {
        }
        
        public ObtenerArticuloPorIdResponseBody(string ObtenerArticuloPorIdResult) {
            this.ObtenerArticuloPorIdResult = ObtenerArticuloPorIdResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ArticuloServicioWebSoapChannel : WebApplication1.ServiceReference1.ArticuloServicioWebSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ArticuloServicioWebSoapClient : System.ServiceModel.ClientBase<WebApplication1.ServiceReference1.ArticuloServicioWebSoap>, WebApplication1.ServiceReference1.ArticuloServicioWebSoap {
        
        public ArticuloServicioWebSoapClient() {
        }
        
        public ArticuloServicioWebSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ArticuloServicioWebSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArticuloServicioWebSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ArticuloServicioWebSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplication1.ServiceReference1.HelloWorldResponse WebApplication1.ServiceReference1.ArticuloServicioWebSoap.HelloWorld(WebApplication1.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            WebApplication1.ServiceReference1.HelloWorldRequest inValue = new WebApplication1.ServiceReference1.HelloWorldRequest();
            inValue.Body = new WebApplication1.ServiceReference1.HelloWorldRequestBody();
            WebApplication1.ServiceReference1.HelloWorldResponse retVal = ((WebApplication1.ServiceReference1.ArticuloServicioWebSoap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.HelloWorldResponse> WebApplication1.ServiceReference1.ArticuloServicioWebSoap.HelloWorldAsync(WebApplication1.ServiceReference1.HelloWorldRequest request) {
            return base.Channel.HelloWorldAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.HelloWorldResponse> HelloWorldAsync() {
            WebApplication1.ServiceReference1.HelloWorldRequest inValue = new WebApplication1.ServiceReference1.HelloWorldRequest();
            inValue.Body = new WebApplication1.ServiceReference1.HelloWorldRequestBody();
            return ((WebApplication1.ServiceReference1.ArticuloServicioWebSoap)(this)).HelloWorldAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplication1.ServiceReference1.ObtenerArticulosResponse WebApplication1.ServiceReference1.ArticuloServicioWebSoap.ObtenerArticulos(WebApplication1.ServiceReference1.ObtenerArticulosRequest request) {
            return base.Channel.ObtenerArticulos(request);
        }
        
        public string ObtenerArticulos() {
            WebApplication1.ServiceReference1.ObtenerArticulosRequest inValue = new WebApplication1.ServiceReference1.ObtenerArticulosRequest();
            inValue.Body = new WebApplication1.ServiceReference1.ObtenerArticulosRequestBody();
            WebApplication1.ServiceReference1.ObtenerArticulosResponse retVal = ((WebApplication1.ServiceReference1.ArticuloServicioWebSoap)(this)).ObtenerArticulos(inValue);
            return retVal.Body.ObtenerArticulosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ObtenerArticulosResponse> WebApplication1.ServiceReference1.ArticuloServicioWebSoap.ObtenerArticulosAsync(WebApplication1.ServiceReference1.ObtenerArticulosRequest request) {
            return base.Channel.ObtenerArticulosAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ObtenerArticulosResponse> ObtenerArticulosAsync() {
            WebApplication1.ServiceReference1.ObtenerArticulosRequest inValue = new WebApplication1.ServiceReference1.ObtenerArticulosRequest();
            inValue.Body = new WebApplication1.ServiceReference1.ObtenerArticulosRequestBody();
            return ((WebApplication1.ServiceReference1.ArticuloServicioWebSoap)(this)).ObtenerArticulosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponse WebApplication1.ServiceReference1.ArticuloServicioWebSoap.ObtenerArticuloPorId(WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest request) {
            return base.Channel.ObtenerArticuloPorId(request);
        }
        
        public string ObtenerArticuloPorId(string idArticulo) {
            WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest inValue = new WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest();
            inValue.Body = new WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequestBody();
            inValue.Body.idArticulo = idArticulo;
            WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponse retVal = ((WebApplication1.ServiceReference1.ArticuloServicioWebSoap)(this)).ObtenerArticuloPorId(inValue);
            return retVal.Body.ObtenerArticuloPorIdResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponse> WebApplication1.ServiceReference1.ArticuloServicioWebSoap.ObtenerArticuloPorIdAsync(WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest request) {
            return base.Channel.ObtenerArticuloPorIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.ObtenerArticuloPorIdResponse> ObtenerArticuloPorIdAsync(string idArticulo) {
            WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest inValue = new WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequest();
            inValue.Body = new WebApplication1.ServiceReference1.ObtenerArticuloPorIdRequestBody();
            inValue.Body.idArticulo = idArticulo;
            return ((WebApplication1.ServiceReference1.ArticuloServicioWebSoap)(this)).ObtenerArticuloPorIdAsync(inValue);
        }
    }
}
