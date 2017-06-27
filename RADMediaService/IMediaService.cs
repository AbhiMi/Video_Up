using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RADMediaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMediaService
    {
        [OperationContract]
        List<Media> GetMediaList(int iRADDeviceID, string sUserName);

        // TODO: Add your service operations here
    }


    [DataContract]
    public class Media
    {
        [DataMember]
        public int MediaID { get; set; }

        [DataMember]
        public string UploadedBy { get; set; }

        [DataMember]
        public DateTime UploadedOn { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public int CompanyID { get; set; }

        [DataMember]
        public string DeviceInfo { get; set; }

        [DataMember]
        public Stream StreamedVideo { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }    
}
