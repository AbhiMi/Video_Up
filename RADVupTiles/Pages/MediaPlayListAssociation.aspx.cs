﻿using RADBusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_MediaPlayListAssociation : System.Web.UI.Page
{
    List<int> playList = new List<int>();
    List<int> media = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPlaylistData();
            LoadMediaData();
        }
        LoadAssociationGrid();
    }

    private void LoadPlaylistData()
    {
        DataTable dt = GetPlayLists();
        if (dt != null)
        {
            grdPlaylist.DataSource = dt;
            grdPlaylist.DataBind();
        }
    }

    private void LoadMediaData()
    {
        DataTable dt = GetMedia();
        if (dt != null)
        {
            grdMedia.DataSource = dt;
            grdMedia.DataBind();
        }
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
    public DataTable GetPlayLists()
    {
        int companyID = GetUsersCompanyID();
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtPLayLists = objBussLogic.GetPlayLists(companyID);
        return dtPLayLists;
    }

    public DataTable GetMedia()
    {
        int companyID = GetUsersCompanyID();
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtMediaFiles = objBussLogic.GetUploadedMediaFiles(companyID);
        return dtMediaFiles;
    }
    protected void btnAssociateMedia_Click(object sender, EventArgs e)
    {
        BusinessLogic objBusinessLogic = new BusinessLogic();
        int companyID = 0;
        string userName = Context.User.Identity.Name;
        string userId = objBusinessLogic.GetUserId(userName.ToLower());
        if (userId != "0")
        {
            DataTable dtCompanies = objBusinessLogic.GetUserCompany(userId);
            if (dtCompanies != null && dtCompanies.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCompanies.Rows)
                {
                    companyID = Convert.ToInt32(dr["CompanyID"]);
                }
            }
        }
        foreach (GridViewRow row in grdPlaylist.Rows)
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

        foreach (GridViewRow row in grdMedia.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (row.FindControl("cbSelectMedia")) as CheckBox;
                if (chk != null && chk.Checked)
                {
                    media.Add(Convert.ToInt32(row.Cells[1].Text));
                }
            }
        }

        if (playList != null && playList.Count > 0)
        {
            if (media != null && media.Count > 0)
            {
                bool blnResult = false;
                foreach (int playlistID in playList)
                {
                    foreach (int mediaID in media)
                    {
                        blnResult = objBusinessLogic.AssociateMediaToPlayList(mediaID, playlistID, companyID);
                    }
                }

                if (blnResult)
                {
                    ActionStatus.Text = string.Format("Media file(s) are successfully associated with the selected playlist(s). ");
                    ActionStatus.ForeColor = Color.Green;
                    LoadAssociationGrid();
                }
            }
        }
    }

    private void LoadAssociationGrid()
    {
        //BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dt = objBussLogic.GetMediaPlayListAssociation(GetUsersCompanyID());
        //if (dt != null)
        //{
        //    grdPlayListMedia.DataSource = dt;
        //    grdPlayListMedia.DataBind();
        //}
    }
    
}