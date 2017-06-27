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

public partial class Pages_Associate_MediaToPlayList : System.Web.UI.Page
{
    string Playlist_Sort_Direction = "PlayListName ASC";
    string AvblMedia_Sort_Direction = "Description ASC";
    string AssctedMedia_Sort_Direction = "Description ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion

        if (!IsPostBack)
        {
            ViewState["Playlist_Sort_Direction"] = Playlist_Sort_Direction;
            ViewState["AvblMedia_Sort_Direction"] = AvblMedia_Sort_Direction;
            ViewState["AssctedMedia_Sort_Direction"] = AssctedMedia_Sort_Direction;


            BusinessLogic objBussLogic = new BusinessLogic();
            DataView dvPlaylist = GetPlaylists(GetUsersCompanyID());
            grdPlaylists.DataSource = dvPlaylist;
            grdPlaylists.DataBind();
            if (Request.QueryString["PlayListName"] != null)
            {
                txtPlaylist.Text = Convert.ToString(Request.QueryString["PlayListName"]);
                int playlistId = objBussLogic.GetPlaylistID(Convert.ToString(Request.QueryString["PlayListName"]));
                hdnPlaylistID.Value = Convert.ToString(playlistId);
                LoadAssociationGrid();
                LoadMediaData();
            }
            if (txtPlaylist.Text == "")
                dragdrop.Visible = false;
        }
        else
        {
            if (txtPlaylist.Text == "")
                dragdrop.Visible = false;
            else
                dragdrop.Visible = true;
        }
        if (gvDest.Rows.Count == 0)
            btnSaveOrder.Visible = false;
        else
            btnSaveOrder.Visible = true;
    }

    private DataView LoadMediaData()
    {
        DataTable dtCampaigns = GetUnAssociatedMedia(GetUsersCompanyID());
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["AvblMedia_Sort_Direction"].ToString();
        gvSource.DataSource = dvCampaigns;
        gvSource.DataBind();
        return dvCampaigns;
    }

    public DataView GetPlaylists(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtPlayLists = objBussLogic.GetPlayLists(CompanyID);
        DataView dvPlaylists = dtPlayLists.DefaultView;
        dvPlaylists.Sort = ViewState["Playlist_Sort_Direction"].ToString();
        return dvPlaylists;
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
    public DataTable GetUnAssociatedMedia(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociateMedia(GetUsersCompanyID());
        return dtMediaFiles;
    }

    private DataView LoadAssociationGrid()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID());
        DataTable dtAssociations = objBussLogic.GetMediaPlayListAssociation(GetUsersCompanyID());
        DataView dvAssociations = dtAssociations.DefaultView;
        dvAssociations.Sort = ViewState["AssctedMedia_Sort_Direction"].ToString();
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
            objBussLogic.UpdateMediaAssociationOrder(associationId, associationorder);
            associationorder += 1;
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }

    [WebMethod]
    [ScriptMethod]
    public static void SavePlayList(Media media)
    {
        Pages_Associate_MediaToPlayList associate = new Pages_Associate_MediaToPlayList();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociateMediaToPlayList(media.ID, Convert.ToInt32(media.PlaylistID), associate.GetUsersCompanyID());
    }

    [WebMethod]
    public static List<string> GetChannelName(string channelName)
    {
        List<string> channelResult = new List<string>();
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtPLayLists = objBussLogic.GetChannels(GetUsersCompanyID());
        Pages_Associate_MediaToPlayList associate = new Pages_Associate_MediaToPlayList();
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
        int campaignId = objBussLogic.GetCampaignID(txtPlaylist.Text);
        hdnPlaylistID.Value = campaignId.ToString();
        LoadMediaData();
        LoadAssociationGrid();
    }
    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        UpdatePreference(sender, e);
    }

    protected void imgUnAssociate_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        ImageButton imgUnAssociate = (sender as ImageButton);
        GridViewRow row = (imgUnAssociate.NamingContainer as GridViewRow);
        int mediaID = Convert.ToInt32(gvDest.DataKeys[row.RowIndex].Values["MediaID"].ToString());
        bool result = objBussLogic.UnAssociateMedia(GetUsersCompanyID(), mediaID);
        if (result)
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
    }
    protected void grdChannels_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["Playlist_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["Playlist_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["Playlist_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["Playlist_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        grdPlaylists.DataSource = GetPlaylists(GetUsersCompanyID());
        grdPlaylists.DataBind();
    }
    protected void gvDest_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AssctedMedia_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AssctedMedia_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AssctedMedia_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AssctedMedia_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvDest.DataSource = LoadAssociationGrid();
        gvDest.DataBind();

    }
    protected void gvSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] SortOrder = ViewState["AvblMedia_Sort_Direction"].ToString().Split(' ');
        if (SortOrder[0] == e.SortExpression)
        {
            if (SortOrder[1] == "ASC")
            {
                ViewState["AvblMedia_Sort_Direction"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["AvblMedia_Sort_Direction"] = e.SortExpression + " " + "ASC";
            }
        }
        else
        {
            ViewState["AvblMedia_Sort_Direction"] = e.SortExpression + " " + "ASC";
        }
        gvSource.DataSource = LoadMediaData();
        gvSource.DataBind();
    }
}

public class Media
{
    public int ID { get; set; }
    public string PlaylistID { get; set; }
}