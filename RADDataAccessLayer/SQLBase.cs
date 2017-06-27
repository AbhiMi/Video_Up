using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace RADDataAccessLayer
{
    public class SQLBase
    {
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
