using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RADDataAccessLayer
{
    public class MediaLibrary
    {
        private string _strUploadedBy = string.Empty;
        private string _strMimeType = string.Empty;
        private string _strUrlLocationPath = string.Empty;
        private string _strDescription = string.Empty;
        private int _intPlayListID;
        private int _intMediaID;
        private int _intCampaignID;
        private int _intCompanyID;
        private byte[] _videoBuffer;
        private string _strPhysicalLocationPath = string.Empty;
        public string UploadedBy
        {
            get
            {
                return _strUploadedBy;
            }
            set
            {
                _strUploadedBy = value;
            }
        }

        public string MIMEType
        {
            get
            {
                return _strMimeType;
            }
            set
            {
                _strMimeType = value;
            }
        }
        public string UrlLocation
        {
            get
            {
                return _strUrlLocationPath; 
            }
            set
            {
                _strUrlLocationPath = value;
            }
        }
        public string PhysicalLocation
        {
            get
            {
                return _strPhysicalLocationPath;
            }
            set
            {
                _strPhysicalLocationPath = value;
            }
        }
        public string Description
        {
            get
            {
                return _strDescription;
            }
            set
            {
                _strDescription = value;
            }
        }
        public int PlayListID
        {
            get
            {
                return _intPlayListID;
            }
            set
            {
                _intPlayListID = value;
            }
        }
        public int MediaID
        {
            get
            {
                return _intMediaID;
            }
            set
            {
                _intMediaID = value;
            }
        }
        public int CampaignID
        {
            get
            {
                return _intCampaignID;
            }
            set
            {
                _intCampaignID = value;
            }
        }
        public int CompanyID
        {
            get
            {
                return _intCompanyID;
            }
            set
            {
                _intCompanyID = value;
            }
        }
        public byte[] VideoBuffer
        {
            get
            {
                return _videoBuffer;
            }
            set
            {
                _videoBuffer = value;
            }
        }
    }
}
