using RADBusinessLogicLayer;
using RADCommonServices;
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

public partial class Pages_Associate_CampaignToChannel : System.Web.UI.Page
{
    string Channel_Sort_Direction = "ChannelName ASC";
    string AvblCampaign_Sort_Direction = "CampaignName ASC";
    string AssctedCampaign_Sort_Direction = "CampaignName ASC";    
    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion

        if (!IsPostBack)
        {
            ViewState["Channel_Sort_Direction"] = Channel_Sort_Direction;
            ViewState["AvblCampaign_Sort_Direction"] = AvblCampaign_Sort_Direction;
            ViewState["AssctedCampaign_Sort_Direction"] = AssctedCampaign_Sort_Direction;


            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions objCommon = new CommonFunctions();
            DataView dvChannels = GetChannels(objCommon.GetUsersCompanyID(Context));
            grdChannels.DataSource = dvChannels;
            grdChannels.DataBind();
            if (Request.QueryString["ChannelName"] != null)
            {
                txtChannel.Text = Convert.ToString(Request.QueryString["ChannelName"]);
                int channelId = objBussLogic.GetChannelID(Convert.ToString(Request.QueryString["ChannelName"]));
                hdnChannelID.Value = Convert.ToString(channelId);
                LoadAssociationGrid(Convert.ToString(Request.QueryString["ChannelName"]));
                LoadCampaignData();
            }
            if (txtChannel.Text == "")
                dragdrop.Visible = false;
        }
        else
        {
            if (txtChannel.Text == "")
                dragdrop.Visible = false;
            else
                dragdrop.Visible = true;
        }
        if (gvDest.Rows.Count == 0)
            btnSaveOrder.Visible = false;
        else
            btnSaveOrder.Visible = true;

    }

    private DataView LoadCampaignData()
    {
        CommonFunctions objCommon = new CommonFunctions();
        DataTable dtCampaigns = GetCampaigns(objCommon.GetUsersCompanyID(Context));
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["AvblCampaign_Sort_Direction"].ToString();
        gvSource.DataSource = dvCampaigns;
        gvSource.DataBind();
        return dvCampaigns;
    }

    public DataView GetChannels(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions objCommon = new CommonFunctions();
        DataTable dtChannels = objBussLogic.GetChannels(objCommon.GetUsersCompanyID(Context));
        DataView dvChannels = dtChannels.DefaultView;
        dvChannels.Sort = ViewState["Channel_Sort_Direction"].ToString();
        return dvChannels;
    }
    public DataTable GetCampaigns(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions objCommon = new CommonFunctions();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociatedCampaigns(objCommon.GetUsersCompanyID(Context));
        return dtMediaFiles;
    }

    private DataView LoadAssociationGrid(string channelName)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions objCommon = new CommonFunctions();
        //DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID());
        DataTable dtAssociations = objBussLogic.GetCampaignChannelAssociation(objCommon.GetUsersCompanyID(Context), channelName);
        DataView dvAssociations = dtAssociations.DefaultView;
        dvAssociations.Sort = ViewState["AssctedCampaign_Sort_Direction"].ToString();
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
    public static void SaveCampaign(Campaign campaign)
    {
        Pages_Associate_CampaignToChannel associate = new Pages_Associate_CampaignToChannel();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociateCampaignToChannel(campaign.ID, Convert.ToInt32(campaign.ChannelID), associate.GetUsersCompanyID());
    }

    [WebMethod]
    public static List<string> GetChannelName(string channelName)
    {
        List<string> channelResult = new List<string>();
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions objCommon = new CommonFunctions();
        //DataTable dtPLayLists = objBussLogic.GetChannels(GetUsersCompanyID());
        Pages_Associate_CampaignToChannel associate = new Pages_Associate_CampaignToChannel();
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
        int channelId = objBussLogic.GetChannelID(txtChannel.Text);
        hdnChannelID.Value = channelId.ToString();
        LoadCampaignData();
        LoadAssociationGrid(txtChannel.Text);
    }
    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        UpdatePreference(sender, e);
    }
    protected void imgShow_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions objCommon = new CommonFunctions();
        ImageButton imgShowHide = (sender as ImageButton);
        GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);
        if (imgShowHide.CommandArgument == "Show")
        {
            row.FindControl("pnlPlaylist").Visible = true;
            imgShowHide.CommandArgument = "Hide";
            imgShowHide.ImageUrl = "../../img/minus.gif";
            string campaignName = gvDest.DataKeys[row.RowIndex].Value.ToString();
            GridView gvPlaylist = row.FindControl("gvPlaylist") as GridView; gvPlaylist.ToolTip = campaignName;
            DataTable dt = objBussLogic.GetPlayListCompanyAssociation(objCommon.GetUsersCompanyID(Context), campaignName);
            gvPlaylist.DataSource = dt;
            gvPlaylist.DataBind();
        }
        else
        {
            row.FindControl("pnlPlaylist").Visible = false;
            imgShowHide.CommandArgument = "Show";
            imgShowHide.ImageUrl = "../../img/plus.gif";
        }
    }
    protected void imgUnAssociate_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions objCommon = new CommonFunctions();
        ImageButton imgUnAssociate = (sender as ImageButton);
        GridViewRow row = (imgUnAssociate.NamingContainer as GridViewRow);
        int campanignID = Convert.ToInt32(gvDest.DataKeys[row.RowIndex].Values["CampaignID"].ToString());
        bool result = objBussLogic.UnAssociateCampaigns(objCommon.GetUsersCompanyID(Context),campanignID);
        if (result)
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
    }
    protected void grdChannels_Sorting(object sender, GridViewSortEventArgs e)
    {
        CommonFunctions objCommon = new CommonFunctions();
        string[] SortOrder = ViewState["Channel_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["Channel_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["Channel_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["Channel_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        grdChannels.DataSource = GetChannels(objCommon.GetUsersCompanyID(Context));
        grdChannels.DataBind();
    }
    protected void gvDest_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AssctedCampaign_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AssctedCampaign_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AssctedCampaign_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AssctedCampaign_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvDest.DataSource = LoadAssociationGrid(txtChannel.Text);
        gvDest.DataBind();

    }
    protected void gvSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AvblCampaign_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AvblCampaign_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AvblCampaign_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AvblCampaign_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvSource.DataSource = LoadCampaignData();
        gvSource.DataBind();
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
}

public class Campaign
{
    public int ID { get; set; }
    public string ChannelID { get; set; }
}