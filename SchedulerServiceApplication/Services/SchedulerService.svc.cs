using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SchedulerServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SchedulerService : ISchedulerService
    {
        public ResponseCampaignData GetCampaignNames(string companyID)
        {
            List<RequestCampaignPlayData> lstCampaigns = new List<RequestCampaignPlayData>();
            ResponseCampaignData objResponse = new ResponseCampaignData();
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DefaultConnection"]))
            {
                using (SqlCommand objSqlcmd = new SqlCommand("SP_GetCampaigns", con))
                {
                    con.Open();

                    objSqlcmd.CommandType = CommandType.StoredProcedure;
                    objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                    using (SqlDataReader reader = objSqlcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RequestCampaignPlayData campaigndata = new RequestCampaignPlayData();
                            campaigndata.CampaignID = Convert.ToString(reader["CampaignID"]);
                            campaigndata.CampaignName = Convert.ToString(reader["CampaignName"]);
                            campaigndata.CampaignImagePath = Convert.ToString(reader["ImagePath"]);
                            campaigndata.StartTime = "2015-12-07T09:00:00";//Convert.ToString(reader["StartDateTime"]);
                            campaigndata.EndTime = "2015-12-07T09:30:00";//Convert.ToString(reader["EndDateTime"]);
                            campaigndata.IsAllDay = Convert.ToString(reader["IsAllDay"]);
                            lstCampaigns.Add(campaigndata);
                        }
                    }
                    objResponse.Campaigns = lstCampaigns;

                }
            }
            return objResponse;
        }

        public bool SaveCampaignPlayOrder(RequestCampaignPlayData objData)
        {
            bool result = false;
            bool result1 = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DefaultConnection"]);
            SqlTransaction transaction;
            con.Open();
            transaction = con.BeginTransaction();
            SqlCommand objSqlcmd = new SqlCommand("SP_AssociateCampaignToChannel", con, transaction);
            SqlCommand objSqlcmd1 = new SqlCommand("SP_SchedulerUpdateCampaign", con, transaction);
            try
            {
                objSqlcmd.CommandType = CommandType.StoredProcedure;
                objSqlcmd1.CommandType = CommandType.StoredProcedure;

                objSqlcmd.Parameters.Add("@CampaignID", SqlDbType.Int).Value = objData.CampaignID;
                objSqlcmd.Parameters.Add("@ChannelID", SqlDbType.Int).Value = objData.ChannelID;
                objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = objData.CompanyID;

                objSqlcmd1.Parameters.Add("@CampaignID", SqlDbType.Int).Value = objData.CampaignID;
                objSqlcmd1.Parameters.Add("@StartTime", SqlDbType.NVarChar).Value = objData.StartTime;
                objSqlcmd1.Parameters.Add("@EndTime", SqlDbType.NVarChar).Value = objData.EndTime;
                objSqlcmd1.Parameters.Add("@IsAllDay", SqlDbType.Bit).Value = objData.IsAllDay;

                result = objSqlcmd.ExecuteNonQuery() > 0;
                result1 = objSqlcmd1.ExecuteNonQuery() > 0;

                if (result == true && result1 == true)
                {
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                con.Close();
            }

        }

    }
}
