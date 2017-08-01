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

namespace VUPMACService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public VUPMacAddressesDetails GetVUPMACAddresses(int CompanyID)
        {
            DataTable dtResults = null;
            VUPMacAddressesDetails vadetails = new VUPMacAddressesDetails();
            try
            {
                using (SqlConnection objSqlConn = GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_GetVUPMACAddresses", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = CompanyID;
                        dtResults = new DataTable();
                        dtResults.TableName = "VUPMACAddresses";
                        dtResults.Load(objSqlcmd.ExecuteReader());
                    }
                }
                vadetails.VUPMacAddresseses = dtResults;
            }
            catch (Exception)
            {
                throw;
            }
            return vadetails;
        }

        public bool CreateVUPMACAddress(int companyID, string vupID, string strEthernetMACAddress, string strWirelessMACAddress)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_InsertVUPMACAddresses", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@VideoUp_ID", SqlDbType.NVarChar).Value = vupID;
                        objSqlcmd.Parameters.Add("@EthernetMACAddress", SqlDbType.NVarChar).Value = strEthernetMACAddress;
                        objSqlcmd.Parameters.Add("@WirelessMACAddress", SqlDbType.NVarChar).Value = strWirelessMACAddress;

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

        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;
            string strConnectionString = string.Empty;
            try
            {
                if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
                {
                    strConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["DefaultConnection"]);
                }
                //string str = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Video-Up;User Id=Test;Password=test";
                //string str = "Data Source=WIN-3R2103861JK\\SQLEXPRESS;Initial Catalog=Video-Up;User Id=VideoUp;Password=vup123";

                con = new SqlConnection(strConnectionString);
                con.Open();
            }
            catch
            {
                throw;
            }
            return con;
        }
    }
}
