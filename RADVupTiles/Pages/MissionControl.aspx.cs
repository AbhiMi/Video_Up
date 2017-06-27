using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using RADBusinessLogicLayer;

public partial class Pages_MissionControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string userName = Context.User.Identity.Name;
        if (!Roles.IsUserInRole(userName, "VUP Admin") || !Roles.IsUserInRole(userName, "Company Admin"))
        {
            //radStepCompany.Visible = false;
            //radStepCompany.Enabled = false;
        }
        string script = "function f(){$find(\"" + RadDeviceDialog.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtLocations = objBussLogic.GetLocations(commFunc.GetUsersCompanyID(Context));
        if(dtLocations!= null && dtLocations.Rows.Count > 0)
        {
            RadDeviceDialog.Visible = false;
        }
        string userId = objBussLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            Guid userGuid = Guid.Parse(userId);
            DataTable dtCompanies = objBussLogic.GetUserCompany(userGuid);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                lblRADLicenseCount.Text = Convert.ToString(dtCompanies.Rows[0]["NumOfLicenses"]);
            }
        }
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtStores = objBussLogic.GetStoresRADDevices(commFunc.GetUsersCompanyID(Context));
        //RadGrid1.DataSource = dtStores;
    }
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = e.Item as GridDataItem;
            GridTableCell linkCell = (GridTableCell)dataItem["NumofRADDevices"];
            LinkButton reportLink = (LinkButton)linkCell.FindControl("raddevicelink");
            string raddeviceText = ((DataRowView)e.Item.DataItem)["NumofRADDevices"].ToString();
            // Set the text to the quote number
            reportLink.Text = raddeviceText;
            //Set the URL
            //reportLink.NavigateUrl = RadTabStrip1.SelectedIndex;
            //Tell it to open in a new window
            //reportLink.Target = "_new";

        }
    }
    protected void rgRegions_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtRegions = objBussLogic.GetRegionAreas(commFunc.GetUsersCompanyID(Context));
        //rgRegions.DataSource = dtRegions;

    }

    protected void rgArea_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtAreas = objBussLogic.GetAreaStores(commFunc.GetUsersCompanyID(Context));
        //rgArea.DataSource = dtAreas;
    }

    protected void RadDeviceGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtRADDevices = objBussLogic.GetRADDevices(commFunc.GetUsersCompanyID(Context));
        //RadDeviceGrid.DataSource = dtRADDevices;
    }
    protected void RadDeviceGrid_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem dataItem = e.Item as GridDataItem;
            Image image = (Image)dataItem["Status"].FindControl("image");
            TableCell PercentOnlineCell = dataItem["PercentOnline"];
            TableCell InactiveCell = dataItem["Inactive"];
            TableCell CriticalCell = dataItem["Critical"];
            TableCell MostRecentCell = dataItem["MostRecentUpdates"];
            DateTime datetime = System.DateTime.Now.AddMinutes(-30);
            if (MostRecentCell.Text != "&nbsp;")
            {
                if (Convert.ToDateTime(MostRecentCell.Text) <= datetime)
                {
                    InactiveCell.Text = "Yes";
                    PercentOnlineCell.Text = "0";
                    image.ImageUrl = "../img/inactive-16.png";
                    image.ToolTip = "Inactive";
                }
                else if (Convert.ToDateTime(MostRecentCell.Text) > datetime)
                {
                    InactiveCell.Text = "No";
                    PercentOnlineCell.Text = "100";
                }
                MostRecentCell.Text = GetUserFriendlyTime(Convert.ToDateTime(MostRecentCell.Text), DateTime.Now);
            }
            else
            {
                MostRecentCell.Text = string.Empty;
            }


        }
    }

    protected void raddevicelink_Click(object sender, EventArgs e)
    {
        //RadTabStrip1.Tabs[1].Selected = true;
        //RadTabStrip1.Tabs[0].PageView.Selected = true;  

        //RadTab tab1 = RadTabStrip1.Tabs.FindTabByText("RADDevice");
        //tab1.Text = "";
        //RadTabStrip1.SelectedIndex = 0;
        //pvRadDevice.Selected = true;
        //RadTabStrip1.Tabs[0].PageView.Selected = true;

    }

    /// <summary>
    /// Method used to Get the Datetime in User Friendly Date Format
    /// </summary>
    public static string GetUserFriendlyTime(DateTime dt, DateTime dtNowDate)
    {
        TimeSpan span = dtNowDate - dt;
        if (span.Days > 365)
        {
            int years = (span.Days / 365);
            if (span.Days % 365 != 0)
                years += 1;
            return String.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
        }
        if (span.Days > 30)
        {
            int months = (span.Days / 30);
            if (span.Days % 31 != 0)
                months += 1;
            return String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
        }
        if (span.Days > 0)
            return String.Format("about {0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");
        if (span.Hours > 0)
            return String.Format("about {0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");
        if (span.Minutes > 0)
            return String.Format("about {0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
        if (span.Seconds > 5)
            return String.Format("about {0} seconds ago", span.Seconds);
        if (span.Seconds <= 5)
            return "just now";
        return string.Empty;
    }
}