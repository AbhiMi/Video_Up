<%@ WebHandler Language="C#" Class="Search_RADDevice" %>
 
using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Search_CS
/// </summary>
public class Search_RADDevice : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string prefixText = context.Request.QueryString["q"];        
        using (SqlConnection objSqlConn = RADDataAccessLayer.SQLBase.GetConnection())
        {
            using (SqlCommand objSqlcmd = new SqlCommand("SP_GetRADDeviceName", objSqlConn))
            {
                objSqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                objSqlcmd.Parameters.AddWithValue("@CompanyID", GetUsersCompanyID(context));
                objSqlcmd.Parameters.AddWithValue("@SearchText", prefixText);                
                StringBuilder sb = new StringBuilder();
                using (SqlDataReader sdr = objSqlcmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        sb.Append(sdr["DeviceInfo"])
                            .Append(Environment.NewLine);
                    }
                }                
                context.Response.Write(sb.ToString());
            }
        }
    }

    public int GetUsersCompanyID(HttpContext Context)
    {
        int companyID = 0;
        string userName = Context.User.Identity.Name;
        RADBusinessLogicLayer.BusinessLogic objBussLogic = new RADBusinessLogicLayer.BusinessLogic();
        string userId = objBussLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            Guid userGuid = Guid.Parse(userId);
            System.Data.DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dr in dtCompanies.Rows)
                {
                    companyID = Convert.ToInt32(dr["CompanyID"]);
                }
            }
        }
        return companyID;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}