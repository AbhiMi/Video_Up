using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVUPService
{
    class Program
    {
        static void Main(string[] args)
        {
            VUPMACAddress_ServiceReference.Service1Client reference = new TestVUPService.VUPMACAddress_ServiceReference.Service1Client();
            bool result = reference.CreateVUPMACAddress(3, "VideoUp1005", "XX-00-00-00-00-44", "AA-00-00-00-00-55");
            var dt=reference.GetVUPMACAddresses(2);
            foreach (DataRow row in dt.VUPMacAddresseses.Rows)
            {
                Console.WriteLine(row["VideoUp_ID"].ToString() +" , "+ row["EthernetMACAddress"].ToString());
            }
            Console.ReadLine();
        }
    }
}
