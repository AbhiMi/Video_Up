using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Associate_PlayListToCampaign : System.Web.UI.Page
{
    string Campaign_Sort_Direction = "CampaignName ASC";
    string AvblPlaylist_Sort_Direction = "PlayListName ASC";
    string AssctedPlaylist_Sort_Direction = "PlayListName ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion

        if (!IsPostBack)
        {
            ViewState["Campaign_Sort_Direction"] = Campaign_Sort_Direction;
            ViewState["AvblPlaylist_Sort_Direction"] = AvblPlaylist_Sort_Direction;
            ViewState["AssctedPlaylist_Sort_Direction"] = AssctedPlaylist_Sort_Direction;


            BusinessLogic objBussLogic = new BusinessLogic();
            DataView dvCampaign = GetCampaign(GetUsersCompanyID());
            grdCampaigns.DataSource = dvCampaign;
            grdCampaigns.DataBind();
            if (Request.QueryString["CampaignName"] != null)
            {
                txtCampaign.Text = Convert.ToString(Request.QueryString["CampaignName"]);
                int campaignId = objBussLogic.GetCampaignID(Convert.ToString(Request.QueryString["CampaignName"]));
                hdnCampaignID.Value = Convert.ToString(campaignId);
                LoadAssociationGrid(Convert.ToString(Request.QueryString["CampaignName"]));
                LoadPlaylistData();
            }
            if (txtCampaign.Text == "")
                dragdrop.Visible = false;
        }
        else
        {
            if (txtCampaign.Text == "")
                dragdrop.Visible = false;
            else
                dragdrop.Visible = true;
        }
        if (gvDest.Rows.Count == 0)
            btnSaveOrder.Visible = false;
        else
            btnSaveOrder.Visible = true;
    }

    private DataView LoadPlaylistData()
    {
        DataTable dtCampaigns = GetUnAssociatedPlayLists(GetUsersCompanyID());
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["AvblPlaylist_Sort_Direction"].ToString();
        gvSource.DataSource = dvCampaigns;
        gvSource.DataBind();
        return dvCampaigns;
    }

    public DataView GetCampaign(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCampaigns = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["Campaign_Sort_Direction"].ToString();
        return dvCampaigns;
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
    public DataTable GetUnAssociatedPlayLists(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociatePlaylists(GetUsersCompanyID());
        return dtMediaFiles;
    }

    private DataView LoadAssociationGrid(string campaignName)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID());
        DataTable dtAssociations = objBussLogic.GetPlayListCompanyAssociation(GetUsersCompanyID(), campaignName);
        DataView dvAssociations = dtAssociations.DefaultView;
        dvAssociations.Sort = ViewState["AssctedPlaylist_Sort_Direction"].ToString();
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
            objBussLogic.UpdatePlaylistAssociationOrder(associationId, associationorder);
            associationorder += 1;
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }

    [WebMethod]
    [ScriptMethod]
    public static void SavePlayList(Playlist playlist)
    {
        Pages_Associate_PlayListToCampaign associate = new Pages_Associate_PlayListToCampaign();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociatePlayListToCampaign(playlist.ID, Convert.ToInt32(playlist.CampaignID), associate.GetUsersCompanyID());
    }

    [WebMethod]
    public static List<string> GetChannelName(string channelName)
    {
        List<string> channelResult = new List<string>();
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtPLayLists = objBussLogic.GetChannels(GetUsersCompanyID());
        Pages_Associate_PlayListToCampaign associate = new Pages_Associate_PlayListToCampaign();
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
        int campaignId = objBussLogic.GetCampaignID(txtCampaign.Text);
        hdnCampaignID.Value = campaignId.ToString();
        LoadPlaylistData();
        LoadAssociationGrid(txtCampaign.Text);
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
            row.FindControl("pnlMedia").Visible = true;
            imgShowHide.CommandArgument = "Hide";
            imgShowHide.ImageUrl = "../../img/minus.gif";
            string playListName = gvDest.DataKeys[row.RowIndex].Value.ToString();
            GridView gvMedia = row.FindControl("gvMedia") as GridView; gvMedia.ToolTip = playListName;
            DataTable dt = objBussLogic.GetMediaPlayListAssociation(GetUsersCompanyID());
            gvMedia.DataSource = dt;
            gvMedia.DataBind();
        }
        else
        {
            row.FindControl("pnlMedia").Visible = false;
            imgShowHide.CommandArgument = "Show";
            imgShowHide.ImageUrl = "../../img/plus.gif";
        }
    }
    protected void imgUnAssociate_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        ImageButton imgUnAssociate = (sender as ImageButton);
        GridViewRow row = (imgUnAssociate.NamingContainer as GridViewRow);
        int playlistID = Convert.ToInt32(gvDest.DataKeys[row.RowIndex].Values["PlayListID"].ToString());
        bool result = objBussLogic.UnAssociatePlayLists(GetUsersCompanyID(), playlistID);
        if (result)
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
    }
    protected void grdChannels_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["Campaign_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["Campaign_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["Campaign_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["Campaign_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        grdCampaigns.DataSource = GetCampaign(GetUsersCompanyID());
        grdCampaigns.DataBind();
    }
    protected void gvDest_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AssctedPlaylist_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AssctedPlaylist_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AssctedPlaylist_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AssctedPlaylist_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvDest.DataSource = LoadAssociationGrid(txtCampaign.Text);
        gvDest.DataBind();

    }
    protected void gvSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AvblPlaylist_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AvblPlaylist_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AvblPlaylist_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AvblPlaylist_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvSource.DataSource = LoadPlaylistData();
        gvSource.DataBind();
    }
}

public class Playlist
{
    public int ID { get; set; }
    public string CampaignID { get; set; }
}