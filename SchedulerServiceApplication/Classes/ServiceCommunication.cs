using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerServiceApplication
{
    [DataContract(Namespace = "http://www.video-up.com/RequestData")]
    public class RequestCampaignData
    {
        [DataMember]
        public string CompanyID { get; set; }
    }

    [DataContract(Namespace = "http://www.video-up.com/RequestData")]
    public class ResponseCampaignData
    {
        [DataMember]
        public List<RequestCampaignPlayData> Campaigns { get; set; }
    }

    [DataContract(Namespace = "http://www.video-up.com/RequestData")]
    public class RequestCampaignPlayData
    {
        [DataMember]
        public string CampaignName { get; set; }
        [DataMember]
        public string CampaignImagePath { get; set; }
        [DataMember]
        public string CompanyID { get; set; }
        [DataMember]
        public string ChannelID { get; set; }
        [DataMember]
        public string CampaignID { get; set; }
        [DataMember]
        public string StartTime { get; set; }
        [DataMember]
        public string EndTime { get; set; }
        [DataMember]
        public string IsAllDay { get; set; }
    }
}