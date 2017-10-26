using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using System.ServiceModel.Security;

namespace TestVUPService
{
    class Program
    {
        static void Main(string[] args)
        {
            VUPMACAddress_ServiceReference.Service1Client reference = new TestVUPService.VUPMACAddress_ServiceReference.Service1Client();
            reference.ClientCredentials.UserName.UserName = "vup@video-up.com";
            reference.ClientCredentials.UserName.Password = "vup@123";
            reference.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                       X509CertificateValidationMode.None;
            bool result = reference.CreateVUPMACAddress(1003, "VideoUp1004", Guid.NewGuid(), Guid.NewGuid(),42, "XX-00-WW-DD-EE", "XX-00-WW-DD-EE",1,180);
            bool isDeleted = reference.DeleteVUPMACAddresses(2);
            var dt=reference.GetVUPMACAddresses("VideoUp1007");
            foreach (DataRow row in dt.VUPMacAddresseses.Rows)
            {
                Console.WriteLine(row["VideoUp_ID"].ToString() +" , "+ row["EthernetMACAddress"].ToString());
            }
            Console.ReadLine();
        }
    }
}
