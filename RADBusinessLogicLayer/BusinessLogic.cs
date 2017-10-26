using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RADDataAccessLayer;
using System.Data;

namespace RADBusinessLogicLayer
{
    public class BusinessLogic
    {
        public bool InsertMediaLibrary(MediaLibrary objMediaLibrary)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.InsertMediaLibrary(objMediaLibrary);
        }
        public bool AddNewScheduleDemoRequest(string strName, string strCompany, string strCompanySiteUrl, string strSubject, int intContactNo, int intOfficeContact, string strEmail)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AddNewScheduleDemoRequest(strName, strCompany, strCompanySiteUrl, strSubject, intContactNo, intOfficeContact, strEmail);
        }
        public DataTable GetMedia(int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetMedia(companyID);
        }
        public DataTable GetUploadedMediaFiles(int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetUploadedMediaFiles(companyID);
        }
        public DataTable GetPlayLists(int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetPlayLists(companyID);
        }
        public DataTable GetRADDevices(int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetRADDevices(companyID);
        }
        public DataTable GetCompanies()
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetCompanies();
        }

        public DataTable GetUserStatus(int companyId)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetUserStatus(companyId);
        }

        public bool UpdateUserStatus(string userId, bool isLocked, string roleId)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.UpdateUserStatus(userId, isLocked, roleId);
        }

        public DataTable GetUserCompany(Guid userId)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetUserCompany(userId);
        }
        public string GetUserId(string userName)
        {
            string userId;
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            userId = objDataAccesLayer.GetUserId(userName);
            return userId;
        }
        public bool AssociateMediaToPlayList(int MediaID, int PlayListID, int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AssociateMediaToPlayList(MediaID, PlayListID, companyID);
        }
        public bool AssociateRADDeviceToCompany(int CompanyID, string RADDeviceName)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AssociateRADDeviceToCompany(CompanyID, RADDeviceName);
        }
        public bool CreateCampaign(string strCampaignName, int CompanyID, string strImagePath, string strFileName, string strColor)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateCampaign(strCampaignName, CompanyID, strImagePath, strFileName, strColor);
        }
        public bool CreateCampaignForScheduler(int campaignID, int channelID, int CompanyID, DateTime Start, DateTime End, bool isAllDay)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateCampaignForScheduler(campaignID, channelID, CompanyID, Start, End, isAllDay);
        }
        public DataTable GetCampaigns(int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetCampaigns(CompanyID);
        }

        public DataSet GetCampaignsForScheduler(int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetCampaignsForScheduler(CompanyID);
        }
        public DataSet GetCampaignsForScheduler(int CompanyID, int channelID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetCampaignsForScheduler(CompanyID, channelID);
        }
        public DataSet GetChannelsForScheduler(int CompanyID, int CampaignID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetChannelsForScheduler(CompanyID, CampaignID);
        }
        public DataTable GetUnAssociatedCampaigns(int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetUnAssociatedCampaigns(CompanyID);
        }
        public DataTable GetUnAssociatedChannels(int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetUnAssociatedChannels(CompanyID);
        }
        public bool AssociatePlayListToCampaign(int PlayListID, int CampaignID, int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AssociatePlayListToCampaign(PlayListID, CampaignID, CompanyID);
        }
        public bool CreateCompany(string strCompanyName, int intCompanyCode)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateCompany(strCompanyName, intCompanyCode);
        }
        public bool InsertRADDeviceInfo(string strRADDeviceName, string strRADDeviceDesc, int companyID,string strScreenFlip,string strScreenOrientation)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.InsertRADDeviceInfo(strRADDeviceName, strRADDeviceDesc, companyID,strScreenFlip,strScreenOrientation);
        }
        public DataTable GetUserWithRole(int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetUserWithRole(companyID);
        }
        public bool AssociateUserWithRoles(string strUserId, string strRoleId)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AssociateUserWithRoles(strUserId, strRoleId);
        }
        public bool CreatePlayList(string strPlayListName, int CompanyID, string strImagePath, string strFileName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.CreatePlayList(strPlayListName, CompanyID, strImagePath, strFileName);
        }
        public bool CreateStore(string strStoreName, string strLocation, int companyId)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateStore(strStoreName, strLocation, companyId);
        }
        public bool CreateArea(string strAreaName, int regionId, int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateArea(strAreaName, regionId, companyID);
        }
        public bool UserCompanyAssociation(string userId, int companyId)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UserCompanyAssociation(userId, companyId);
        }
        public bool UpdateCompany(string strCompanyName, int intCompanyId, int CompanyCode)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateCompany(strCompanyName, intCompanyId, CompanyCode);
        }
        public bool UpdateMedia(int mediaID, string strDescription)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateMedia(mediaID, strDescription);
        }
        public bool DeleteCompany(int intCompanyId)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteCompany(intCompanyId);
        }
        public bool UpdateRADDevice(int intRADDeviceID, string strRADDevice, string strRADDesc)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateRADDevice(intRADDeviceID, strRADDevice, strRADDesc);
        }
        public bool DeleteRADDevice(int intRADDeviceID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteRADDevice(intRADDeviceID);
        }
        public bool UpdatePlayList(string strPlayListName, int intPlayListID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdatePlayList(strPlayListName, intPlayListID);
        }
        public bool DeletePlayList(int intPlayListID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeletePlayList(intPlayListID);
        }
        public DataTable GetStores(int CompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetStores(CompanyID);
        }
        public DataTable GetRegions(int CompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRegions(CompanyID);
        }
        public DataTable GetUserOfCompany(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetUserOfCompany(companyID);
        }
        public bool UpdateStore(int intStoreID, string strStoreName, string strLocation)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateStore(intStoreID, strStoreName, strLocation);
        }
        public bool DeleteStore(int intStoreID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteStore(intStoreID);
        }
        public bool UpdateCampaign(int intCampaignID, string strCampaignName, string strSelectedColor, string imagePath, string fileName, bool isImageChanged)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateCampaign(intCampaignID, strCampaignName, strSelectedColor, imagePath, fileName, isImageChanged);
        }

        public bool DeleteMedia(int intMediaID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteMedia(intMediaID);
        }
        public bool DeleteCampaign(int intCampaignID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteCampaign(intCampaignID);
        }
        public bool CreateChannel(string strChannelName, int CompanyID, string strFilePath, string strFileName, string strColor)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.CreateChannel(strChannelName, CompanyID, strFilePath, strFileName, strColor);
        }
        public bool UpdateChannel(int intChannelID, string strChannelName, string strColor, string imagePath, string fileName, bool isImageChanged)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateChannel(intChannelID, strChannelName, strColor, imagePath, fileName, isImageChanged);
        }
        public bool DeleteChannel(int intChannelID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteChannel(intChannelID);
        }
        public DataTable GetChannels(int CompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetChannels(CompanyID);
        }
        public DataTable GetMediaPlayListAssociation(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetMediaPlayListAssociation(companyID);
        }

        public DataTable GetMediaPlayListAssociation(int companyID, string playListName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetMediaPlayListAssociation(companyID, playListName);
        }
        public DataTable GetPlayListCompanyAssociation(int CompanyID, string CampaignName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetPlayListCompanyAssociation(CompanyID, CampaignName);
        }
        public bool AssociateCampaignToChannel(int CampaignID, int ChannelID, int CompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.AssociateCampaignToChannel(CampaignID, ChannelID, CompanyID);
        }
        public bool AssociateRADDeviceToChannel(int RADDeviceID, int ChannelID, int CompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.AssociateRADDeviceToChannel(RADDeviceID, ChannelID, CompanyID);
        }
        public DataTable GetCampaignChannelAssociation(int CompanyID, string channelName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetCampaignChannelAssociation(CompanyID, channelName);
        }
        public DataTable GetChannelRADDeviceAssociation(int CompanyID, string radDeviceName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRADDeviceChannelAssociation(CompanyID, radDeviceName);
        }

        public int GetRADDeviceID(string radDeviceName)
        {
            DataAccesLayer objDAtaAccessLayer = new DataAccesLayer();
            return objDAtaAccessLayer.GetRADDeviceID(radDeviceName);
        }

        public int GetChannelID(string channelName)
        {
            DataAccesLayer objDAtaAccessLayer = new DataAccesLayer();
            return objDAtaAccessLayer.GetChannelID(channelName);
        }

        public int GetCampaignID(string campaignName)
        {
            DataAccesLayer objDAtaAccessLayer = new DataAccesLayer();
            return objDAtaAccessLayer.GetCampaignID(campaignName);
        }

        public int GetPlaylistID(string playlistName)
        {
            DataAccesLayer objDAtaAccessLayer = new DataAccesLayer();
            return objDAtaAccessLayer.GetPlatlistID(playlistName);
        }

        public bool UpdateCampaignAssociationOrder(int Id, int order)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateCampaignAssociationOrder(Id, order);
        }

        public bool UpdatePlaylistAssociationOrder(int Id, int order)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdatePlaylistAssociationOrder(Id, order);
        }
        public bool UpdateMediaAssociationOrder(int Id, int order)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateMediaAssociationOrder(Id, order);
        }

        public bool UnAssociateChannels(int companyID, int channelID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UnAssociateChannels(companyID, channelID);
        }

        public bool UnAssociateCampaigns(int companyID, int campaignID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UnAssociateCampaigns(companyID, campaignID);
        }
        public bool UnAssociatePlayLists(int companyID, int playlistID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UnAssociatePlayLists(companyID, playlistID);
        }

        public DataTable GetUnAssociatePlaylists(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetUnAssociatedPlayLists(companyID);
        }

        public DataTable GetUnAssociateMedia(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetUnAssociatedMedia(companyID);
        }

        public bool UnAssociateMedia(int companyID, int mediaID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UnAssociateMedia(companyID, mediaID);
        }

        public DataTable GetMediaFromID(int mediaID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetMediaFromID(mediaID);
        }

        public DataTable GetMediaForCampaign(int companyID, string campaignName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetMediaForCampaign(companyID, campaignName);
        }
        public DataTable GetStoresRADDevices(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetStoresRADDevices(companyID);
        }
        public DataTable GetAreaStores(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetAreaStores(companyID);
        }
        public DataTable GetAreas(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetAreas(companyID);
        }
        public DataTable GetRegionAreas(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRegionAreas(companyID);
        }
        public bool CreateRegions(string strRegionName, string strDescription, string strCreatedBy, int intCompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.CreateRegions(strRegionName, strDescription, strCreatedBy, intCompanyID);
        }
        public DataTable GetRoleWithDescription(string RoleName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRoleWithDescription(RoleName);
        }
        public bool UpdateSchedulerCampaign(int intCampaignID, DateTime startdate, DateTime enddate, bool Isallday)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateSchedulerCampaign(intCampaignID, startdate, enddate, Isallday);
        }

        public DataTable GetEncryptedID(int intCompanyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetEncryptedID(intCompanyID);
        }

        public DataTable GetCampaignViewReport(int companyID, DateTime start, DateTime End)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetCampaignViewReport(companyID, start, End);
        }

        public DataTable GetCampaignReport(int companyID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetCampaignReport(companyID);
        }

        public DataTable GetLineCampaignViewReport(int companyID, DateTime start, DateTime End)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetLineCampaignViewReport(companyID, start, End);
        }

        public DataTable GetScatterCampaignViewReport(int companyID, DateTime start, DateTime End)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetScatterCampaignViewReport(companyID, start, End);
        }

        public DataTable GetPlaylistViewReport(int companyID, int campaignID, DateTime start, DateTime End)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetPlayListViewReport(companyID, campaignID, start, End);
        }

        public DataTable GetVideoViewReport(int companyID, int playlistID, DateTime start, DateTime End)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetVideoViewReport(companyID, playlistID, start, End);
        }

        public DataTable GetRegionReport(int companyID, DateTime start, DateTime End)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRegionReport(companyID, start, End);
        }

        public DataTable GetRoles(string applicationName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRoles(applicationName);
        }

        public DataTable GetRoleAction(string roleName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetRoleAction(roleName);
        }

        public int GetActionId(string actionName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetActionId(actionName);
        }

        public DataTable GetAllAction()
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.GetAllAction();
        }

        public bool UpdateRole(string applicationName, string roleName, string oldRoleName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateRole(applicationName, roleName, oldRoleName);
        }

        public bool ManageRoleActions(DataTable dt, Guid roleId)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.ManageRoleAction(dt, roleId);
        }
        public bool CheckExistCampaignForScheduler(int campaignID, int channelID, DateTime Start, DateTime End)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CheckExistCampaignForScheduler(campaignID, channelID, Start, End);
        }
        public bool AddNewStore(string strStoreName, string strLocation, int companyID, int regionID, int areaID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AddNewStore(strStoreName, strLocation, companyID, regionID, areaID);
        }
        public bool CreateNetworkProfile(string strProfileName, string strWirelessName, int companyID, string strConnectionType, string strPassword)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateNetworkProfile(strProfileName, strWirelessName, companyID, strConnectionType, strPassword);
        }
        public DataTable GetNetworkProfiles(int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetNetworkProfiles(CompanyID);
        }
        public bool DeleteArea(int AreaID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteArea(AreaID);
        }

        public bool DeleteRegion(int RegionID)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.DeleteRegion(RegionID);
        }

        public bool UpdateArea(int intAreaID, string strAreaName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateArea(intAreaID, strAreaName);
        }

        public bool UpdateRegion(int intRegionID, string strRegionName)
        {
            DataAccesLayer objDataAccessLayer = new DataAccesLayer();
            return objDataAccessLayer.UpdateRegion(intRegionID, strRegionName);
        }
        public bool AddNewLocation(string strLocationName, string strAddress, string strCountry, string strState, int zipCode, int regionID, int areaID, string strCustomTags, string strCreatedBy, int companyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.AddNewLocation(strLocationName, strAddress, strCountry, strState, zipCode, regionID, areaID, strCustomTags, strCreatedBy, companyID);
        }
        public DataTable GetLocations(int CompanyID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetLocations(CompanyID);
        }
        public bool CreateVUPMACAddress(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.CreateVUPMACAddress(companyID, vupID, strEthernetMACAddress, strWirelessMACAddress);
        }
        public DataTable GetVUPMACAddresses(string strVideoUPID)
        {
            DataAccesLayer objDataAccesLayer = new DataAccesLayer();
            return objDataAccesLayer.GetVUPMACAddresses(strVideoUPID);
        }
    }
}
