using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using RADBusinessLogicLayer;

namespace RADMediaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IMediaService
    {
        public List<SP_GetMediaDetailsForRADDevice_Result> GetMediaList(int iRADDeviceID, int iCompanyID)
        {
            List<SP_GetMediaDetailsForRADDevice_Result> MediaData = null;
            RADDeviceMediaEntities objEntities = new RADDeviceMediaEntities();
            MediaData = objEntities.SP_GetMediaDetailsForRADDevice(iRADDeviceID, iCompanyID).ToList();
            return MediaData;
            //VUPEntities db = new VUPEntities();
            //return db.Media1.Where(x => x.CompanyID == iCompanyID).Select(data => data.Location).ToList();
        }

        public Stream GetMedia(string name)
        {
            var dir = HttpContext.Current.Server.MapPath("~");
            var file = String.Format("{0}.wmv", name);
            var filePath = Path.Combine(dir, file);
            return File.OpenRead(filePath); 
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
