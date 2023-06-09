﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileReference
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://cudanawidelcu.ds360.pl/")]
    public partial class IOException
    {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://cudanawidelcu.ds360.pl/", ConfigurationName="FileReference.FileService")]
    public interface FileService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://cudanawidelcu.ds360.pl/FileService/downloadRecipeProductsPdfRequest", ReplyAction="http://cudanawidelcu.ds360.pl/FileService/downloadRecipeProductsPdfResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FileReference.IOException), Action="http://cudanawidelcu.ds360.pl/FileService/downloadRecipeProductsPdf/Fault/IOExcep" +
            "tion", Name="IOException")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<FileReference.downloadRecipeProductsPdfResponse> downloadRecipeProductsPdfAsync(FileReference.downloadRecipeProductsPdfRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://cudanawidelcu.ds360.pl/FileService/downloadImageRequest", ReplyAction="http://cudanawidelcu.ds360.pl/FileService/downloadImageResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<FileReference.downloadImageResponse> downloadImageAsync(FileReference.downloadImageRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="downloadRecipeProductsPdf", WrapperNamespace="http://cudanawidelcu.ds360.pl/", IsWrapped=true)]
    public partial class downloadRecipeProductsPdfRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cudanawidelcu.ds360.pl/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string recipeName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cudanawidelcu.ds360.pl/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string products;
        
        public downloadRecipeProductsPdfRequest()
        {
        }
        
        public downloadRecipeProductsPdfRequest(string recipeName, string products)
        {
            this.recipeName = recipeName;
            this.products = products;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="downloadRecipeProductsPdfResponse", WrapperNamespace="http://cudanawidelcu.ds360.pl/", IsWrapped=true)]
    public partial class downloadRecipeProductsPdfResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cudanawidelcu.ds360.pl/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary", IsNullable=true)]
        public byte[] @return;
        
        public downloadRecipeProductsPdfResponse()
        {
        }
        
        public downloadRecipeProductsPdfResponse(byte[] @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="downloadImage", WrapperNamespace="http://cudanawidelcu.ds360.pl/", IsWrapped=true)]
    public partial class downloadImageRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cudanawidelcu.ds360.pl/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string recipeName;
        
        public downloadImageRequest()
        {
        }
        
        public downloadImageRequest(string recipeName)
        {
            this.recipeName = recipeName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="downloadImageResponse", WrapperNamespace="http://cudanawidelcu.ds360.pl/", IsWrapped=true)]
    public partial class downloadImageResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://cudanawidelcu.ds360.pl/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] @return;
        
        public downloadImageResponse()
        {
        }
        
        public downloadImageResponse(byte[] @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface FileServiceChannel : FileReference.FileService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class FileServiceClient : System.ServiceModel.ClientBase<FileReference.FileService>, FileReference.FileService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public FileServiceClient() : 
                base(FileServiceClient.GetDefaultBinding(), FileServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.FileServiceImplPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(FileServiceClient.GetBindingForEndpoint(endpointConfiguration), FileServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(FileServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(FileServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FileReference.downloadRecipeProductsPdfResponse> FileReference.FileService.downloadRecipeProductsPdfAsync(FileReference.downloadRecipeProductsPdfRequest request)
        {
            return base.Channel.downloadRecipeProductsPdfAsync(request);
        }
        
        public System.Threading.Tasks.Task<FileReference.downloadRecipeProductsPdfResponse> downloadRecipeProductsPdfAsync(string recipeName, string products)
        {
            FileReference.downloadRecipeProductsPdfRequest inValue = new FileReference.downloadRecipeProductsPdfRequest();
            inValue.recipeName = recipeName;
            inValue.products = products;
            return ((FileReference.FileService)(this)).downloadRecipeProductsPdfAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<FileReference.downloadImageResponse> FileReference.FileService.downloadImageAsync(FileReference.downloadImageRequest request)
        {
            return base.Channel.downloadImageAsync(request);
        }
        
        public System.Threading.Tasks.Task<FileReference.downloadImageResponse> downloadImageAsync(string recipeName)
        {
            FileReference.downloadImageRequest inValue = new FileReference.downloadImageRequest();
            inValue.recipeName = recipeName;
            return ((FileReference.FileService)(this)).downloadImageAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.FileServiceImplPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.FileServiceImplPort))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:8181/cuda-na-widelcu-backend/FileService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return FileServiceClient.GetBindingForEndpoint(EndpointConfiguration.FileServiceImplPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return FileServiceClient.GetEndpointAddress(EndpointConfiguration.FileServiceImplPort);
        }
        
        public enum EndpointConfiguration
        {
            
            FileServiceImplPort,
        }
    }
}
