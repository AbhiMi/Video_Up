using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Create_ScheduleChannel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commFunc = new CommonFunctions();
        ddlCampaign.DataSource = GetCampaigns(commFunc.GetUsersCompanyID(Context));
        ddlCampaign.DataTextField = "CampaignName";
        ddlCampaign.DataValueField = "CampaignID";
        ddlCampaign.DataBind();
    }

    public DataTable GetCampaigns(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCampaigns = objBussLogic.GetCampaigns(CompanyID);
        return dtCampaigns;
    }

    protected void editButton_Click(object sender, EventArgs e)
    {
        BusinessLogic objBusiness = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        objBusiness.CreateCampaignForScheduler(Convert.ToInt32(hdnField.Value), Convert.ToInt32(ddlCampaign.SelectedValue), commFunc.GetUsersCompanyID(Context), RadDateTimePicker1.SelectedDate.Value, RadDateTimePicker2.SelectedDate.Value, chkBox.Checked);
    }
}