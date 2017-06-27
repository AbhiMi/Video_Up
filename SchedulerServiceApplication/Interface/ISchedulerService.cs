using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SchedulerServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISchedulerService
    {
        //[OperationContract]
        //[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetCampaignNames")]
        //ResponseCampaignData GetCampaignNames(RequestCampaignData objData);

        [OperationContract]
        [WebGet(UriTemplate = "GetCampaignNames/{companyID}",ResponseFormat= WebMessageFormat.Json)]
        ResponseCampaignData GetCampaignNames(string companyID);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "SaveCampaignPlayOrder")]
        bool SaveCampaignPlayOrder(RequestCampaignPlayData objData);
    }

}
