using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssociationViews_PlayListCampaignAssociation : System.Web.UI.Page
{
    List<int> playList = new List<int>();
    List<int> campaign = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPlaylistData();
            LoadCampaignData();
        }
        LoadAssociationGrid();
    }

    private void LoadPlaylistData()
    {
        DataTable dt = GetPlayLists();
        if (dt != null)
        {
            grdPlayList.DataSource = dt;
            grdPlayList.DataBind();
        }
    }

    private void LoadCampaignData()
    {
        DataTable dt = GetCampaign();
        if (dt != null)
        {
            grdCampaign.DataSource = dt;
            grdCampaign.DataBind();
        }
    }

    public DataTable GetPlayLists()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtPLayLists = objBussLogic.GetPlayLists(GetUsersCompanyID());
        return dtPLayLists;
    }
    public int GetUsersCompanyID()
    {
        int companyID = 0;
        string userName = Context.User.Identity.Name;
        BusinessLogic objBussLogic = new BusinessLogic();
        string userId = objBussLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            DataTable dtCompanies = objBussLogic.GetUserCompany(userId);
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
    public DataTable GetCampaign()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        return dtMediaFiles;
    }
    protected void btnAssociatePlayList_Click(object sender, EventArgs e)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        foreach (GridViewRow row in grdPlayList.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (row.FindControl("cbSelectPlaylist")) as CheckBox;
                if (chk != null && chk.Checked)
                {
                    playList.Add(Convert.ToInt32(row.Cells[1].Text));
                }
            }
        }

        foreach (GridViewRow row in grdCampaign.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (row.FindControl("cbSelectCampaign")) as CheckBox;
                if (chk != null && chk.Checked)
                {
                    campaign.Add(Convert.ToInt32(row.Cells[1].Text));
                }
            }
        }

        if (playList != null && playList.Count > 0)
        {
            if (campaign != null && campaign.Count > 0)
            {
                bool blnResult = false;
                foreach (int playlistID in playList)
                {
                    foreach (int campaignID in campaign)
                    {
                        blnResult = objBusinessLogic.AssociatePlayListToCampaign(playlistID, campaignID, GetUsersCompanyID());
                    }
                }

                if (blnResult)
                {
                    ActionStatus.Text = string.Format("PlayList(s) are successfully associated with the selected campaign(s). ");
                    ActionStatus.ForeColor = Color.Green;
                    LoadAssociationGrid();
                }
            }
        }
    }

    private void LoadAssociationGrid()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dt = objBussLogic.GetPlayListCompanyAssociation(GetUsersCompanyID());
        if (dt != null)
        {
            grdPlayListCampaign.DataSource = dt;
            grdPlayListCampaign.DataBind();
        }
    }

}