using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RADMediaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MediaService : IMediaService
    {
        public List<Media> GetMediaList(int iRADDeviceID, string sUserName)
        {
            List<Media> Medias = new List<Media>();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnStr))
            {
                using (SqlCommand objSqlcmd = new SqlCommand("SP_GetMediaDetailsForRADDevice", con))                
                {
                    con.Open();

                    objSqlcmd.CommandType = CommandType.StoredProcedure;
                    objSqlcmd.Parameters.Add("@RADDeviceID", SqlDbType.Int).Value = iRADDeviceID;
                    objSqlcmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = sUserName;

                    SqlDataReader dr = objSqlcmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Media media = new Media();
                        media.MediaID = dr.GetInt32(0);
                        media.UploadedBy = dr.GetString(1);
                        media.UploadedOn = dr.GetDateTime(2);
                        media.Location = dr.GetString(3);
                        media.CompanyID = dr.GetInt32(4);
                        media.DeviceInfo = dr.GetString(5);
                        media.StreamedVideo = dr.GetStream(6);
                        media.UserName = dr.GetString(7);

                        Medias.Add(media);
                    }
                }
            }
            return Medias;
        }
    }
}
