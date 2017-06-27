using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Associate_RADDeviceToChannel : System.Web.UI.Page
{
    string RADDevice_Sort_Direction = "DeviceInfo ASC";
    string AvblChannel_Sort_Direction = "ChannelName ASC";
    string AssctedChannel_Sort_Direction = "ChannelName ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion

        if (!IsPostBack)
        {
            ViewState["RADDevice_Sort_Direction"] = RADDevice_Sort_Direction;
            ViewState["AvblChannel_Sort_Direction"] = AvblChannel_Sort_Direction;
            ViewState["AssctedChannel_Sort_Direction"] = AssctedChannel_Sort_Direction;


            BusinessLogic objBussLogic = new BusinessLogic();
            DataView dvRADDevices = GetRADDevices(GetUsersCompanyID());
            grdRADDevice.DataSource = dvRADDevices;
            grdRADDevice.DataBind();
            if (Request.QueryString["RADDeviceName"] != null)
            {
                txtRADDevice.Text = Convert.ToString(Request.QueryString["RADDeviceName"]);
                int radDeviceId = objBussLogic.GetRADDeviceID(Convert.ToString(Request.QueryString["RADDeviceName"]));
                hdnRADDeviceID.Value = Convert.ToString(radDeviceId);
                LoadAssociationGrid(Convert.ToString(Request.QueryString["RADDeviceName"]));
                LoadChannelData();
            }
            if (txtRADDevice.Text == "")
                dragdrop.Visible = false;
        }
        else
        {
            if (txtRADDevice.Text == "")
                dragdrop.Visible = false;
            else
                dragdrop.Visible = true;
        }
        if (gvDest.Rows.Count == 0)
            btnSaveOrder.Visible = false;
        else
            btnSaveOrder.Visible = true;

    }

    private DataView LoadChannelData()
    {
        DataTable dtChannels = GetChannels(GetUsersCompanyID());
        DataView dvChannels = dtChannels.DefaultView;
        dvChannels.Sort = ViewState["AvblChannel_Sort_Direction"].ToString();
        gvSource.DataSource = dvChannels;
        gvSource.DataBind();
        return dvChannels;
    }

    public DataView GetRADDevices(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtRADDevices = objBussLogic.GetRADDevices(GetUsersCompanyID());
        DataView dvRADDevices = dtRADDevices.DefaultView;
        dvRADDevices.Sort = ViewState["RADDevice_Sort_Direction"].ToString();
        return dvRADDevices;
    }
    public int GetUsersCompanyID()
    {
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
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyID = Convert.ToInt32(dr["CompanyID"]);
                }
            }
        }
        return companyID;
    }
    public DataTable GetChannels(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtChannels = objBussLogic.GetUnAssociatedChannels(GetUsersCompanyID());
        return dtChannels;
    }

    private DataView LoadAssociationGrid(string radDeviceName)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID());
        DataTable dtAssociations = objBussLogic.GetChannelRADDeviceAssociation(GetUsersCompanyID(), radDeviceName);
        DataView dvAssociations = dtAssociations.DefaultView;
        dvAssociations.Sort = ViewState["AssctedChannel_Sort_Direction"].ToString();
        gvDest.DataSource = dvAssociations;
        gvDest.DataBind();
        return dvAssociations;
    }

    protected void UpdatePreference(object sender, EventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        int[] associationIds = (from p in Request.Form["AssociationId"].Split(',')
                                select int.Parse(p)).ToArray();
        int associationorder = 1;
        foreach (int associationId in associationIds)
        {
            objBussLogic.UpdateCampaignAssociationOrder(associationId, associationorder);
            associationorder += 1;
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }

    [WebMethod]
    [ScriptMethod]
    public static void SaveCampaign(Channel channel)
    {
        Pages_Associate_RADDeviceToChannel associate = new Pages_Associate_RADDeviceToChannel();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociateRADDeviceToChannel(Convert.ToInt32(channel.RADDeviceID),channel.ID, associate.GetUsersCompanyID());
    }

    [WebMethod]
    public static List<string> GetChannelName(string channelName)
    {
        List<string> channelResult = new List<string>();
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtPLayLists = objBussLogic.GetChannels(GetUsersCompanyID());
        Pages_Associate_RADDeviceToChannel associate = new Pages_Associate_RADDeviceToChannel();
        DataTable dtChannels = objBussLogic.GetChannels(associate.GetUsersCompanyID());
        if (dtChannels != null)
        {
            for (int i = 0; i < dtChannels.Rows.Count; i++)
            {
                channelResult.Add(dtChannels.Rows[i]["ChannelName"].ToString());
            }
        }
        return channelResult;
    }
    protected void btnLoadGrid_Click(object sender, EventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        int channelId = objBussLogic.GetChannelID(txtRADDevice.Text);
        hdnRADDeviceID.Value = channelId.ToString();
        LoadChannelData();
        LoadAssociationGrid(txtRADDevice.Text);
    }
    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        UpdatePreference(sender, e);
    }
    protected void imgShow_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        ImageButton imgShowHide = (sender as ImageButton);
        GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);
        if (imgShowHide.CommandArgument == "Show")
        {
            row.FindControl("pnlChannel").Visible = true;
            imgShowHide.CommandArgument = "Hide";
            imgShowHide.ImageUrl = "../../img/minus.gif";
            string channelName = gvDest.DataKeys[row.RowIndex].Value.ToString();
            GridView gvChannel = row.FindControl("gvChannel") as GridView; gvChannel.ToolTip = channelName;
            DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID(), channelName);
            gvChannel.DataSource = dt;
            gvChannel.DataBind();
        }
        else
        {
            row.FindControl("pnlChannel").Visible = false;
            imgShowHide.CommandArgument = "Show";
            imgShowHide.ImageUrl = "../../img/plus.gif";
        }
    }
    protected void imgUnAssociate_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        ImageButton imgUnAssociate = (sender as ImageButton);
        GridViewRow row = (imgUnAssociate.NamingContainer as GridViewRow);
        int channelID = Convert.ToInt32(gvDest.DataKeys[row.RowIndex].Values["ChannelID"].ToString());
        bool result = objBussLogic.UnAssociateChannels(GetUsersCompanyID(), channelID);
        if (result)
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
    }
    protected void grdChannels_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["RADDevice_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["RADDevice_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["RADDevice_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["RADDevice_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        grdRADDevice.DataSource = GetRADDevices(GetUsersCompanyID());
        grdRADDevice.DataBind();
    }
    protected void gvDest_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AssctedChannel_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AssctedChannel_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AssctedChannel_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AssctedChannel_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvDest.DataSource = LoadAssociationGrid(txtRADDevice.Text);
        gvDest.DataBind();

    }
    protected void gvSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AvblChannel_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AvblChannel_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AvblChannel_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AvblChannel_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvSource.DataSource = LoadChannelData();
        gvSource.DataBind();
    }
}

public class Channel
{
    public int ID { get; set; }
    public string RADDeviceID { get; set; }
}