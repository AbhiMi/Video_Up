using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using RADBusinessLogicLayer;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "hide", "hideLogin();", true);
            int companyID = 0;
            string userName = Context.User.Identity.Name;
            BusinessLogic objBussLogic = new BusinessLogic();
            string userId = objBussLogic.GetUserId(userName.ToLower());
            if (userId != "0")
            {
                Guid userGuid = Guid.Parse(userId);
                DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
                if (dtCompanies != null && dtCompanies.Rows.Count > 0)
                {
                    companyID = Convert.ToInt32(dtCompanies.Rows[0]["CompanyID"].ToString());
                    //userCompany.Text = dtCompanies.Rows[0]["CompanyName"].ToString();
                }
            }
        }
        else
        {
            Response.Redirect(FormsAuthentication.LoginUrl, true);
        }  
    }
    private bool IsCombinedJSOlder(string path)
    {
        var jsPath = Context.Server.MapPath(path);
        string[] files = Directory.GetFiles(jsPath);

        var combinedFileLastWrite = File.GetLastWriteTime(Server.MapPath("~/js/Combined.js"));

        return Array.Exists(files, file => (File.GetLastWriteTime(file) - combinedFileLastWrite).TotalSeconds > 1);
    }

    protected string GetAlerts()
    {
        if (!Request.IsLocal)
        {
            if (IsCombinedJSOlder("~/js/") || IsCombinedJSOlder("~/Tiles/"))
            {
                return "$('#CombinedScriptAlert').show();";
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            return string.Empty;
        }

    }

    public string GetUsersCompany()
    {
        string companyName = "";
        string userName = Context.User.Identity.Name;
        BusinessLogic objBussLogic = new BusinessLogic();
        string userId = objBussLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            Guid userGuid = Guid.Parse(userId);
            DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyName = Convert.ToString(dr["CompanyName"]);
                }
            }
        }
        return companyName;
    }
}