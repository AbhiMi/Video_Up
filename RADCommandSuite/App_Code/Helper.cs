using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using RADBusinessLogicLayer;
using System.Data;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
	public Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int GetUserCompany(string userName)
    {
        int companyId = 0;
        BusinessLogic bl = new BusinessLogic();
        string userId = bl.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            //DataTable dtCompanies = bl.GetUserCompany(userId);
            if (dtCompanies != null)
            {
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyId = Convert.ToInt32(dr[1]);
                }
            }
        }
        return companyId;
    }

    public DataTable GetCampaigns(int companyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCampaigns = objBussLogic.GetCampaigns(companyId);
        return dtCampaigns;
    }

    public DataTable GetChannels(int companyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtChannels = objBussLogic.GetChannels(companyId);
        return dtChannels;
    }
}