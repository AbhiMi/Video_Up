using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RADDataAccessLayer
{
    public class DataAccesLayer
    {
        public bool InsertMediaLibrary(MediaLibrary objMediaLibrary)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UploadMediaLibraries", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@UploadedBy", SqlDbType.VarChar).Value = objMediaLibrary.UploadedBy;
                        objSqlcmd.Parameters.Add("@MIMEType", SqlDbType.VarChar).Value = objMediaLibrary.MIMEType;
                        objSqlcmd.Parameters.Add("@UrlLocation", SqlDbType.VarChar).Value = objMediaLibrary.UrlLocation;
                        objSqlcmd.Parameters.Add("@PhysicalLocation", SqlDbType.VarChar).Value = objMediaLibrary.PhysicalLocation;
                        objSqlcmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = objMediaLibrary.Description;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = objMediaLibrary.CompanyID;
                        objSqlcmd.Parameters.Add("@VideoBuffer", SqlDbType.VarBinary).Value = objMediaLibrary.VideoBuffer;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool AddNewScheduleDemoRequest(string strName, string strCompany, string strCompanySiteUrl, string strSubject, int intContactNo, int intOfficeContact, string strEmail )
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AddNewScheduleDemoRequest", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = strName;
                        objSqlcmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = strCompany;
                        objSqlcmd.Parameters.Add("@CompanySiteUrl", SqlDbType.NVarChar).Value = strCompanySiteUrl;
                        objSqlcmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = strSubject;
                        objSqlcmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = intContactNo;
                        objSqlcmd.Parameters.Add("@OfficeContact", SqlDbType.Int).Value = intOfficeContact;
                        objSqlcmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = strEmail;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public DataTable GetUploadedMediaFiles(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUploadedMediaFiles", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                        string[] strSeperater = { "\\" };
                        if (dtResults != null && dtResults.Rows.Count > 0)
                        {
                            foreach (DataRow drRow in dtResults.Rows)
                            {
                                string strValue = Convert.ToString(drRow["UrlLocation"]);
                                if (!string.IsNullOrEmpty(strValue))
                                {
                                    string[] strValues = strValue.Split(strSeperater, StringSplitOptions.RemoveEmptyEntries);
                                    if (strValues != null)
                                    {
                                        string strFileName = strValues[strValues.Length - 1];
                                        drRow["UrlLocation"] = strFileName;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetPlayLists(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetPlayLists", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetRADDevices(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRADDevices", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataTable GetUserStatus(int companyId)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUserwithStatus", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public bool UpdateUserStatus(string UserId, bool islocked,string RoleId)
        { 
            bool result = false; 
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateUserStatus", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@IsLocked", SqlDbType.Bit).Value = islocked;
                        objSqlcmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = UserId;
                        objSqlcmd.Parameters.Add("@RoleId", SqlDbType.NVarChar).Value = RoleId;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public DataTable GetUserCompany(Guid userId)
        {
            DataTable dtResults = null;
            try
            {
                if (userId != null)
                {
                    using (SqlConnection objSqlConn = SQLBase.GetConnection())
                    {
                        using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUserCompany", objSqlConn))
                        {
                            objSqlcmd.CommandType = CommandType.StoredProcedure;
                            objSqlcmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userId;
                            dtResults = new DataTable();
                            dtResults.Load(objSqlcmd.ExecuteReader());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetCompanies()
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCompanies", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetCampaigns(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaigns", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataSet GetCampaignsForScheduler(int CompanyID)
        {
            DataSet dsCampaign = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaignsForScheduler", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dsCampaign = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = objSqlcmd;
                        da.Fill(dsCampaign, "Campaigns");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dsCampaign;
        }
        public DataSet GetCampaignsForScheduler(int CompanyID, int ChannelID)
        {
            DataSet dsCampaign = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaignsForChannelScheduler", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = ChannelID;
                        dsCampaign = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = objSqlcmd;
                        da.Fill(dsCampaign, "Campaigns");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dsCampaign;
        }
        public DataSet GetChannelsForScheduler(int CompanyID, int CampaignID)
        {
            DataSet dsCampaign = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetChannelsForScheduler", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = CampaignID;
                        dsCampaign = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();

                        da.SelectCommand = objSqlcmd;
                        da.Fill(dsCampaign, "Channel");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dsCampaign;
        }

        public DataTable GetMedia(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetMedia", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetUnAssociatedCampaigns(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUnAssociatedCampaigns", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetUnAssociatedChannels(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUnAssociatedChannels", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public bool AssociateMediaToPlayList(int MediaID, int PlayListID, int CompanyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AssociatedMediaToPlayList", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@MediaID", SqlDbType.Int).Value = MediaID;
                        objSqlcmd.Parameters.Add("@PlayListID", SqlDbType.Int).Value = PlayListID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool AssociateRADDeviceToCompany(int CompanyID, string RADDeviceName)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AssociatedRADDeviceToCompany", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@RADDeviceName", SqlDbType.NVarChar).Value = RADDeviceName;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool AssociatePlayListToCampaign(int PlayListID, int CampaignID, int CompanyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AssociatePlayListToCampaign", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = CampaignID;
                        objSqlcmd.Parameters.Add("@PlayListID", SqlDbType.Int).Value = PlayListID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool CreateCompany(string strCompanyName,int intCompanyCode)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateCompany", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = strCompanyName;
                        objSqlcmd.Parameters.Add("@CompanyCode", SqlDbType.VarChar).Value = intCompanyCode;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool InsertRADDeviceInfo(string strRADDeviceName, string strRADDeviceDesc, int companyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_InsertRADDeviceInfo", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@DeviceInfo", SqlDbType.VarChar).Value = strRADDeviceName;
                        objSqlcmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = strRADDeviceDesc;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public DataTable GetUserWithRole(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetAllUserWithRoles", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public string GetUserId(string userName)
        {
            string userId = "0";
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUserIdFromName", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                        userId = objSqlcmd.ExecuteScalar().ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return userId;
        }

        public bool AssociateUserWithRoles(string strUserId, string strRoleId)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AssociateUserWithRoles", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = strUserId;
                        objSqlcmd.Parameters.Add("@RoleId", SqlDbType.VarChar).Value = strRoleId;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool CreatePlayList(string strPlayListName, int CompanyID, string strImagePath, string strFileName)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreatePlayList", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@PlayListName", SqlDbType.VarChar).Value = strPlayListName;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = strImagePath;
                        objSqlcmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = strFileName;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }

        public bool CreateStore(string strStoreName, string strLocation, int companyId)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateStores", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@StoreName", SqlDbType.VarChar).Value = strStoreName;
                        objSqlcmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = strLocation;
                        objSqlcmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool CreateArea(string strAreaName, int regionId, int companyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateArea", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@AreaName", SqlDbType.VarChar).Value = strAreaName;
                        objSqlcmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionId;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }

        public bool CreateCampaign(string strCampaignName, int CompanyID, string strImagePath, string strFileName, string strColor)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateCampaign", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CampaignName", SqlDbType.VarChar).Value = strCampaignName;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = strImagePath;
                        objSqlcmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = strFileName;
                        objSqlcmd.Parameters.Add("@Color", SqlDbType.NChar).Value = strColor;
                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }

        public bool CreateCampaignForScheduler(int campaignID, int channelID, int CompanyID, DateTime Start, DateTime End, bool isAllDay)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateCampaignForScheduler", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = campaignID;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = channelID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@Start", SqlDbType.DateTime).Value = Start;
                        objSqlcmd.Parameters.Add("@End", SqlDbType.DateTime).Value = End;
                        objSqlcmd.Parameters.Add("@IsAllDay", SqlDbType.Bit).Value = isAllDay;
                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }

        public bool UserCompanyAssociation(string strUserId, int strCompanyId)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateUserCompanyAssociation", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = strUserId;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = strCompanyId;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool UpdateCompany(string strCompanyName, int intCompanyId, int companyCode)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateCompany", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = strCompanyName;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyId;
                        objSqlcmd.Parameters.Add("@CompanyCode", SqlDbType.Int).Value = companyCode;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool UpdateMedia(int mediaID, string strDescription)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateMedia", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaID;
                        objSqlcmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = strDescription;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;

        }
        public bool DeleteCompany(int intCompanyId)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteCompany", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyId;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool UpdateRADDevice(int intRADDeviceID, string strRADDevice, string strRADDesc)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateRADDevice", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@RADDeviceID", SqlDbType.Int).Value = intRADDeviceID;
                        objSqlcmd.Parameters.Add("@DeviceInfo", SqlDbType.NVarChar).Value = strRADDevice;
                        objSqlcmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = strRADDesc;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool DeleteRADDevice(int intRADDeviceID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteRADDevice", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@RADDeviceID", SqlDbType.Int).Value = intRADDeviceID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool UpdatePlayList(string strPlayListName, int intPlayListID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdatePlayList", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@PlayListName", SqlDbType.VarChar).Value = strPlayListName;
                        objSqlcmd.Parameters.Add("@PlayListID", SqlDbType.Int).Value = intPlayListID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool DeletePlayList(int intPlayListID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeletePlayList", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@PlayListID", SqlDbType.Int).Value = intPlayListID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public DataTable GetStores(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetStores", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetRegions(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRegions", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetUserOfCompany(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUsersOfCompany", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@companyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }
        public bool UpdateStore(int intStoreID, string strStoreName, string strLocation)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateStores", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = intStoreID;
                        objSqlcmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = strStoreName;
                        objSqlcmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = strLocation;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool DeleteStore(int intStoreID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteStore", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@StoreID", SqlDbType.Int).Value = intStoreID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool UpdateCampaign(int intCampaignID, string strCampaignName, string strSelectedColor, string imagePath, string fileName, bool isImageChanged)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateCampaign", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = intCampaignID;
                        objSqlcmd.Parameters.Add("@CampaignName", SqlDbType.NVarChar).Value = strCampaignName;
                        objSqlcmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = strSelectedColor;
                        objSqlcmd.Parameters.Add("@imagepath", SqlDbType.NVarChar).Value = imagePath;
                        objSqlcmd.Parameters.Add("@isimagechanged", SqlDbType.Bit).Value = isImageChanged;
                        objSqlcmd.Parameters.Add("@imageFileName", SqlDbType.NVarChar).Value = fileName;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool DeleteCampaign(int intCampaignID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteCampaign", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = intCampaignID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool DeleteMedia(int intMediaID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteMedia", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@MediaID", SqlDbType.Int).Value = intMediaID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool CreateChannel(string strChannelName, int CompanyID, string strFilePath, string strFileName, string strColor)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateChannel", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@ChannelName", SqlDbType.VarChar).Value = strChannelName;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = strFilePath;
                        objSqlcmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = strFileName;
                        objSqlcmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = strColor;
                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool UpdateChannel(int intChannelID, string strChannelName, string strColor, string imagePath, string fileName, bool isImageChanged)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateChannel", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = intChannelID;
                        objSqlcmd.Parameters.Add("@ChannelName", SqlDbType.NVarChar).Value = strChannelName;
                        objSqlcmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = strColor;
                        objSqlcmd.Parameters.Add("@imagepath", SqlDbType.NVarChar).Value = imagePath;
                        objSqlcmd.Parameters.Add("@isimagechanged", SqlDbType.Bit).Value = isImageChanged;
                        objSqlcmd.Parameters.Add("@imageFileName", SqlDbType.NVarChar).Value = fileName;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool DeleteChannel(int intChannelID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteChannel", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = intChannelID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public DataTable GetChannels(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetChannels", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetMediaPlayListAssociation(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetMediaPlayListAssociation", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataTable GetMediaPlayListAssociation(int companyID, string playListName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetMediaPlayListAssociation", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@PlayListName", SqlDbType.NVarChar).Value = playListName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetPlayListCompanyAssociation(int CompanyID, string CampaignName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetAssociatedPlayListsToCampaigns", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@CampaignName", SqlDbType.NVarChar).Value = CampaignName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public bool AssociateCampaignToChannel(int CampaignID, int ChannelID, int CompanyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AssociateCampaignToChannel", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = CampaignID;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = ChannelID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool AssociateRADDeviceToChannel(int RADDeviceID, int ChannelID, int CompanyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AssociateRADDeviceToChannel", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@RADDeviceID", SqlDbType.Int).Value = RADDeviceID;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = ChannelID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public DataTable GetCampaignChannelAssociation(int CompanyID, string channelName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaignChannelAssociations", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@ChannelName", SqlDbType.VarChar).Value = channelName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetRADDeviceChannelAssociation(int CompanyID, string radDeviceName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRADDeviceChannelAssociations", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        objSqlcmd.Parameters.Add("@RADDeviceName", SqlDbType.VarChar).Value = radDeviceName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public int GetRADDeviceID(string radDeviceName)
        {
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRADDeviceID", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar).Value = radDeviceName;
                        int radDeviceID = Convert.ToInt32(objSqlcmd.ExecuteScalar());
                        return radDeviceID;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetChannelID(string channelName)
        {
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetChannelID", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar).Value = channelName;
                        int channelID = Convert.ToInt32(objSqlcmd.ExecuteScalar());
                        return channelID;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetCampaignID(string campaignName)
        {
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaignID", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar).Value = campaignName;
                        int campaignID = Convert.ToInt32(objSqlcmd.ExecuteScalar());
                        return campaignID;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetPlatlistID(string playlistName)
        {
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetPlaylistID", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar).Value = playlistName;
                        int playlistID = Convert.ToInt32(objSqlcmd.ExecuteScalar());
                        return playlistID;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateCampaignAssociationOrder(int Id, int order)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateCampaignChannelAssociationOrder", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                        objSqlcmd.Parameters.Add("@AssociationOrder", SqlDbType.Int).Value = order;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool UpdatePlaylistAssociationOrder(int Id, int order)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdatePlaylistCampaignAssociationOrder", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                        objSqlcmd.Parameters.Add("@AssociationOrder", SqlDbType.Int).Value = order;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool UpdateMediaAssociationOrder(int Id, int order)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateMediaPlaylistAssociationOrder", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = Id;
                        objSqlcmd.Parameters.Add("@AssociationOrder", SqlDbType.Int).Value = order;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool UnAssociateChannels(int companyID, int channelID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UnAssociateChannels", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = channelID;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool UnAssociateCampaigns(int companyID, int campaignID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UnAssociateCampaigns", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = campaignID;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool UnAssociatePlayLists(int companyID, int playlistID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UnAssociatePlayLists", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@PlayListID", SqlDbType.Int).Value = playlistID;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public DataTable GetUnAssociatedPlayLists(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUnAssociatedPlayLists", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataTable GetUnAssociatedMedia(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetUnAssociatedMedia", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public bool UnAssociateMedia(int companyID, int mediaID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UnAssociateMedia", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaID;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public DataTable GetMediaFromID(int mediaID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetMediaFromID", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@mediaID", SqlDbType.Int).Value = mediaID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataTable GetMediaForCampaign(int companyID, string campaignName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetMediaForCampaign", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@CampaignName", SqlDbType.VarChar).Value = campaignName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataTable GetStoresRADDevices(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetStores_RADDevices", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetAreaStores(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetArea_Stores", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public DataTable GetAreas(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetAreas", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public DataTable GetRegionAreas(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRegion_Areas", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
        public bool CreateRegions(string strRegionName, string strDescription, string strCreatedBy, int intCompanyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateRegions", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@RegionName", SqlDbType.VarChar).Value = strRegionName;
                        objSqlcmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = strDescription;
                        objSqlcmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = strCreatedBy;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = intCompanyID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public DataTable GetRoleWithDescription(string RoleName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRoleWithDescription", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = RoleName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public bool UpdateSchedulerCampaign(int intCampaignID, DateTime startdate, DateTime enddate, bool Isallday)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_SchedulerUpdateCampaign", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ID", SqlDbType.Int).Value = intCampaignID;
                        objSqlcmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = startdate;
                        objSqlcmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = enddate;
                        objSqlcmd.Parameters.Add("@IsAllday", SqlDbType.Bit).Value = Isallday;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public DataTable GetEncryptedID(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetEncryptedID", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetCampaignViewReport(int companyID, DateTime start, DateTime End)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaignViews", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@dtStart", SqlDbType.DateTime).Value = start;
                        objSqlcmd.Parameters.Add("@dtEnd", SqlDbType.DateTime).Value = End;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetCampaignReport(int companyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaignViewReport", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetLineCampaignViewReport(int companyID, DateTime start, DateTime End)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_LineGetCampaignViews", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@dtStart", SqlDbType.DateTime).Value = start;
                        objSqlcmd.Parameters.Add("@dtEnd", SqlDbType.DateTime).Value = End;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetScatterCampaignViewReport(int companyID, DateTime start, DateTime End)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_LineGetCampaignViews", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@dtStart", SqlDbType.DateTime).Value = start;
                        objSqlcmd.Parameters.Add("@dtEnd", SqlDbType.DateTime).Value = End;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetPlayListViewReport(int companyID, int campaignID, DateTime start, DateTime End)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetPlayListViews", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = campaignID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@dtStart", SqlDbType.DateTime).Value = start;
                        objSqlcmd.Parameters.Add("@dtEnd", SqlDbType.DateTime).Value = End;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetVideoViewReport(int companyID, int playlistID, DateTime start, DateTime End)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetVideoViews", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@PlaylistID", SqlDbType.Int).Value = playlistID;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@dtStart", SqlDbType.DateTime).Value = start;
                        objSqlcmd.Parameters.Add("@dtEnd", SqlDbType.DateTime).Value = End;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public bool AddNewStore(string strStoreName, string strLocation, int companyID, int regionID, int areaID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AddNewStore", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@StoreName", SqlDbType.NVarChar).Value = strStoreName;
                        objSqlcmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = strLocation;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionID;
                        objSqlcmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = areaID;
                        result = Convert.ToBoolean(objSqlcmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public DataTable GetRegionReport(int companyID, DateTime start, DateTime End)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRegionViews", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@dtStart", SqlDbType.DateTime).Value = start;
                        objSqlcmd.Parameters.Add("@dtEnd", SqlDbType.DateTime).Value = End;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetRoles(string applicationName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("aspnet_Roles_GetAllRolesData", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ApplicationName", SqlDbType.NVarChar).Value = applicationName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetRoleAction(string roleName)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetActionforRole", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@roleName", SqlDbType.NVarChar).Value = roleName;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public DataTable GetAllAction()
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetAllAction", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            { throw; }
            return dtResults;
        }

        public int GetActionId(string actionName)
        {
            int id;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetActionId", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@actionName", SqlDbType.NVarChar).Value = actionName;
                        objSqlcmd.Parameters.Add("@id", SqlDbType.Int);
                        objSqlcmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        objSqlcmd.ExecuteNonQuery();

                        id = (int)objSqlcmd.Parameters["@id"].Value;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return id;
        }

        public bool UpdateRole(string applicationName, string roleName, string oldRoleName)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_Roles_UpdateRole", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@ApplicationName", SqlDbType.NVarChar).Value = applicationName;
                        objSqlcmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = roleName;
                        objSqlcmd.Parameters.Add("@oldRoleName", SqlDbType.NVarChar).Value = oldRoleName;
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool ManageRoleAction(DataTable _dt, Guid roleId)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_ManageRolesAction", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.AddWithValue("@roleId", SqlDbType.UniqueIdentifier).Value = roleId;
                        SqlParameter tvpParam = objSqlcmd.Parameters.AddWithValue("@RoleActionTVP", _dt); //Needed TVP
                        tvpParam.SqlDbType = SqlDbType.Structured; //tells ADO.NET we are passing TVP                        
                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool CheckExistCampaignForScheduler(int campaignID, int channelID, DateTime Start, DateTime End)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CheckCampaignForScheduler", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = campaignID;
                        objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = channelID;
                        objSqlcmd.Parameters.Add("@Start", SqlDbType.DateTime).Value = Start;
                        objSqlcmd.Parameters.Add("@End", SqlDbType.DateTime).Value = End;
                        result = Convert.ToBoolean(objSqlcmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public bool CreateNetworkProfile(string strProfileName, string strWirelessName, int companyID, string strConnectionType, string strPassword)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_CreateNetworkProfile", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@ProfileName", SqlDbType.NVarChar).Value = strProfileName;
                        objSqlcmd.Parameters.Add("@WireLessName", SqlDbType.NVarChar).Value = strWirelessName;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@ConnectionType", SqlDbType.NVarChar).Value = strConnectionType;
                        objSqlcmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = strPassword;

                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public DataTable GetNetworkProfiles(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetNetworkProfiles", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }

        public bool DeleteArea(int AreaID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteArea", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = AreaID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool DeleteRegion(int RegionID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteRegion", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = RegionID;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool UpdateArea(int intAreaID, string strAreaName)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateArea", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = intAreaID;
                        objSqlcmd.Parameters.Add("@AreaName", SqlDbType.NVarChar).Value = strAreaName;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }

        public bool UpdateRegion(int intRegionID, string strRegionName)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_UpdateRegion", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = intRegionID;
                        objSqlcmd.Parameters.Add("@RegionName", SqlDbType.NVarChar).Value = strRegionName;

                        result = objSqlcmd.ExecuteNonQuery() < 0;
                    }
                }
            }
            catch (Exception)
            { throw; }
            return result;
        }
        public bool AddNewLocation(string strLocationName, string strAddress, string strCountry, string strState, int zipCode, int regionID, int areaID, string strCustomTags, string strCreatedBy, int companyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_AddNewLocation", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@LocationName", SqlDbType.NVarChar).Value = strLocationName;
                        objSqlcmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = strAddress;
                        objSqlcmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = strCountry;
                        objSqlcmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = strState;
                        objSqlcmd.Parameters.Add("@ZipCode", SqlDbType.Int).Value = zipCode;
                        objSqlcmd.Parameters.Add("@RegionID", SqlDbType.Int).Value = regionID;
                        objSqlcmd.Parameters.Add("@AreaID", SqlDbType.Int).Value = areaID;
                        objSqlcmd.Parameters.Add("@CustomTags", SqlDbType.NVarChar).Value = strCustomTags;
                        objSqlcmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = strCreatedBy;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        result = objSqlcmd.ExecuteNonQuery() < 0;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return result;
        }
        public DataTable GetLocations(int CompanyID)
        {
            DataTable dtResults = null;
            try
            {
                using (SqlConnection objSqlConn = SQLBase.GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetLocationData", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dtResults;
        }
    }
}
