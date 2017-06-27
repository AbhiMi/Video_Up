using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;

namespace RADMediaService
{
    public class ContentTypeMessageFormatter : IDispatchMessageFormatter
    {
        private IDispatchMessageFormatter formatter;
        private String contentType;
        public ContentTypeMessageFormatter(IDispatchMessageFormatter formatter, String contentType)
        {
            this.formatter = formatter;
            this.contentType = contentType;
        }

        public void DeserializeRequest(Message message, object[] parameters)
        {
            formatter.DeserializeRequest(message, parameters);
        }

        public Message SerializeReply(MessageVersion messageVersion, Object[] parameters, Object result)
        {
            if (!String.IsNullOrEmpty(contentType))
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = contentType;
            }
            return formatter.SerializeReply(messageVersion, parameters, result);
        }
    }

    public class ContentTypeAttribute : Attribute, IOperationBehavior
    {
        public ContentTypeAttribute(String contentType)
        {
            this.ContentType = contentType;
        }

        public String ContentType
        {
            get;
            set;
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.Formatter = new ContentTypeMessageFormatter(dispatchOperation.Formatter, ContentType);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}