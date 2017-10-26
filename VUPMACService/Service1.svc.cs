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
using System.IO;
using System.Drawing;
using QRCoder;

namespace VUPMACService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public VUPMacAddressesDetails GetVUPMACAddresses(string strVideoUpID)
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
                        objSqlcmd.Parameters.Add("@VideoUpID", SqlDbType.NVarChar).Value = strVideoUpID;
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

        public bool CreateVUPMACAddress(int RADDeviceID,string VideoUpID, Guid HardwareID1, Guid HardwareID2, int companyID, string strEthernetMACAddress, string strWirelessMACAddress,int IsActive, int FlipDisplay)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_InsertVUPMACAddresses", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

                        objSqlcmd.Parameters.Add("@RADDeviceID", SqlDbType.Int).Value = RADDeviceID;
                        objSqlcmd.Parameters.Add("@VideoUpID", SqlDbType.NVarChar).Value = VideoUpID;
                        objSqlcmd.Parameters.Add("@HardwareID1", SqlDbType.UniqueIdentifier).Value = HardwareID1;
                        objSqlcmd.Parameters.Add("@HardwareID2", SqlDbType.UniqueIdentifier).Value = HardwareID2;
                        objSqlcmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyID;
                        objSqlcmd.Parameters.Add("@EthernetMACAddress", SqlDbType.NVarChar).Value = strEthernetMACAddress;
                        objSqlcmd.Parameters.Add("@WirelessMACAddress", SqlDbType.NVarChar).Value = strWirelessMACAddress;
                        objSqlcmd.Parameters.Add("@IsActive", SqlDbType.Int).Value = IsActive;
                        MemoryStream ms = GenerateQRCode(VideoUpID);
                        objSqlcmd.Parameters.Add("@QRcodeImage", SqlDbType.Image, ms.GetBuffer().Length).Value = ms.GetBuffer();
                        objSqlcmd.Parameters.Add("@FlipDisplay", SqlDbType.Int).Value = FlipDisplay;
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
        public bool DeleteVUPMACAddresses(int companyID)
        {
            bool result = false;
            try
            {
                using (SqlConnection objSqlConn = GetConnection())
                {
                    using (SqlCommand objSqlcmd = new SqlCommand("SP_DeleteVUPMACAddress", objSqlConn))
                    {
                        objSqlcmd.CommandType = CommandType.StoredProcedure;

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
        public MemoryStream GenerateQRCode(string strVideoUpID)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(strVideoUpID, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms;
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    //string result = Convert.ToBase64String(byteImage, 0, byteImage.Length);
                }
            }
        }
    }
}
