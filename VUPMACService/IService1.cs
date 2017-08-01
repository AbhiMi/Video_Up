using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VUPMACService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "CreateVUPMACAddress")]
        bool CreateVUPMACAddress(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress);

        [OperationContract]
        VUPMacAddressesDetails GetVUPMACAddresses(int CompanyID);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class VUPMacAddressesDetails
    {
        [DataMember]
        public DataTable VUPMacAddresseses
        {
            get;
            set;
        }
    }

}
