using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_CreatePlaylist : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;

    string Playlist_Sort_Direction = "PlayListName ASC";
    string AvblMedia_Sort_Direction = "Description ASC";
    string AssctedMedia_Sort_Direction = "Description ASC";

    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion
        BusinessLogic objBusinessLogic = new BusinessLogic();
        if (!IsPostBack)
        {
            ViewState["Playlist_Sort_Direction"] = Playlist_Sort_Direction;
            ViewState["AvblMedia_Sort_Direction"] = AvblMedia_Sort_Direction;
            ViewState["AssctedMedia_Sort_Direction"] = AssctedMedia_Sort_Direction;

            string userName = Context.User.Identity.Name;
            if (!Roles.IsUserInRole(userName, "Guest"))
            {

                //DataTable dtRADDevices = objBusinessLogic.GetPlayLists(GetUsersCompanyID());
                //if (!IsPostBack)
                //{
                //    BindGrid();
                //}
            }
            else
            {
                //tblPlaylist.Visible = false;
                //BindGrid();
            }
        }
        if (!string.IsNullOrEmpty(hdnPlaylistName.Value))
        {
            int playlistId = objBusinessLogic.GetPlaylistID(hdnPlaylistName.Value);
            hdnPlaylistID.Value = Convert.ToString(playlistId);
            LoadAssociationGrid();
            LoadMediaData();
        }
        if (gvDest.Rows.Count == 0)
            btnSaveOrder.Visible = false;
        else
            btnSaveOrder.Visible = true;
        LoadMediaData();
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

    public DataTable GetUnAssociatedMedia(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociateMedia(GetUsersCompanyID());
        return dtMediaFiles;
    }

    public DataView GetPlaylists(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtPlayLists = objBussLogic.GetPlayLists(CompanyID);
        DataView dvPlaylists = dtPlayLists.DefaultView;
        dvPlaylists.Sort = ViewState["Playlist_Sort_Direction"].ToString();
        return dvPlaylists;
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

    //protected void grdPlayList_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    grdPlayList.EditIndex = e.NewEditIndex;
    //    BindGrid();
    //}
    //protected void grdPlayList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    string strPlayListID = grdPlayList.DataKeys[e.RowIndex].Values["PlayListID"].ToString();
    //    TextBox txtPlayListName = (TextBox)grdPlayList.Rows[e.RowIndex].FindControl("txtPlayListName");
    //    BusinessLogic objBussLogic = new BusinessLogic();
    //    bool blnResult = objBussLogic.UpdatePlayList(txtPlayListName.Text, Convert.ToInt32(strPlayListID));
    //    if (blnResult)
    //    {
    //        lblmsg.ForeColor = Color.Green;
    //        lblmsg.Text = txtPlayListName.Text + " updated successfully.";
    //        grdPlayList.EditIndex = -1;
    //    }
    //    else
    //    {
    //        lblmsg.ForeColor = Color.Red;
    //        lblmsg.Text = "Updated failed. Please contact system administrator.";
    //        grdPlayList.EditIndex = -1;
    //    }
    //    BindGrid();
    //}
    //protected void grdPlayList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    grdPlayList.EditIndex = -1;
    //    BindGrid();
    //}
    //protected void grdPlayList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    string strCompanyID = grdPlayList.DataKeys[e.RowIndex].Values["PlayListID"].ToString();
    //    BusinessLogic objBussLogic = new BusinessLogic();
    //    bool blnResult = objBussLogic.DeletePlayList(Convert.ToInt32(strCompanyID));
    //    if (blnResult)
    //    {
    //        lblmsg.ForeColor = Color.Green;
    //        lblmsg.Text = "PlayList deleted successfully.";
    //        grdPlayList.EditIndex = -1;
    //    }
    //    else
    //    {
    //        lblmsg.ForeColor = Color.Red;
    //        lblmsg.Text = "Deletion failed. Please contact system administrator.";
    //        grdPlayList.EditIndex = -1;
    //    }
    //    BindGrid();

    //}
    //protected void grdPlayList_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {

    //        System.Web.UI.WebControls.Image imgPlayListName = (System.Web.UI.WebControls.Image)e.Row.FindControl("imgPlayListName");
    //        if (imgPlayListName != null)
    //        {
    //            imgPlayListName.ImageUrl = "..\\..\\img\\" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FileName"));
    //        }
    //    }
    //    e.Row.Height = Unit.Pixel(20);
    //}

    private void BindGrid()
    {
        DataTable dataTable = GetPlayLists();
        if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                grdPlayList.DataSource = dataView;
                grdPlayList.DataBind();
            }
        }
        else
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                grdPlayList.DataSource = dataTable.DefaultView;
                grdPlayList.DataBind();
            }
            else
            {
                dataTable.NewRow();
                grdPlayList.DataSource = dataTable.DefaultView;
                grdPlayList.DataBind();

            }
        }
    }
    //protected void grdPlayList_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //    int sortColumnIndex = 0;

    //    if (e.Row.RowType == DataControlRowType.Header)
    //        sortColumnIndex = GetSortColumnIndex();

    //    if (sortColumnIndex != 1)
    //    {
    //        AddSortImage(sortColumnIndex, e.Row);
    //    }

    //    if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdPlayList.EditIndex)
    //    {
    //        // Programmatically reference the Edit and Delete LinkButtons
    //        Button EditButton = e.Row.FindControl("ButtonEdit") as Button;

    //        Button DeleteButton = e.Row.FindControl("ButtonDelete") as Button;

    //        EditButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
    //        DeleteButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
    //    }
    //}
    //protected int GetSortColumnIndex()
    //{
    //    foreach (DataControlField field in grdPlayList.Columns)
    //    {
    //        if (field.SortExpression == grdPlayList.SortExpression)
    //            return grdPlayList.Columns.IndexOf(field);
    //        else
    //            return -1;
    //    }
    //    return -1;
    //}
    protected void AddSortImage(int columnIndex, GridViewRow HeaderRow)
    {
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        if (showImage) // this is a boolean variable which should be false 
        {
            if (ViewState["sortDirection"] != null)
            {//  on page load so that image wont show up initially.
                if (ViewState["sortDirection"].ToString() == "Ascending")
                {
                    sortImage.ImageUrl = "~/Images/asc.gif";
                    sortImage.AlternateText = " Ascending Order";
                }
                else
                {
                    sortImage.ImageUrl = "~/Images/desc.gif";
                    sortImage.AlternateText = " Descending Order";
                }
            }
            //grdPlayList.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
    //protected void grdPlayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdPlayList.PageIndex = e.NewPageIndex;

    //    if (!isSort) // this will get exectued if user clicks paging
    //    {            // before sorting istelf

    //        BindGrid();    //instance. Provide your datasource
    //        // to bind the data
    //    }

    //    else if (isAscend)// this will get exectued if user clicks paging
    //    // after cliclking ascending order
    //    {

    //        // I am passing only "DateRequest" as sortexpression for instance. because
    //        // i am implementing sorting for only one column. You can generalize it to 
    //        // pass that particular column on sorting.
    //        SortGridView("PlayListName", ASCENDING);

    //    }
    //    else // this will get exectued if user clicks paging
    //    // after cliclking descending order
    //    {
    //        SortGridView("PlayListName", DESCENDING);
    //    }
    //}
    private SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }
    //protected void SortGridView(string sortExpression, string direction)
    //{
    //    DataTable dataTable = GetPlayLists();
    //    if (dataTable != null)
    //    {
    //        DataView dataView = new DataView(dataTable);
    //        dataView.Sort = sortExpression + direction;

    //        grdPlayList.DataSource = dataView;
    //        grdPlayList.DataBind();
    //    }
    //}
    //protected void grdPlayList_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    isSort = true;
    //    string sortExpression = e.SortExpression;

    //    ViewState["SortExpression"] = sortExpression;
    //    showImage = true;
    //    if (GridViewSortDirection == SortDirection.Ascending)
    //    {
    //        isAscend = true;
    //        SortGridView(sortExpression, ASCENDING);
    //        ViewState["SortDirection"] = ASCENDING;
    //        GridViewSortDirection = SortDirection.Descending;
    //    }
    //    else
    //    {
    //        isAscend = false;
    //        SortGridView(sortExpression, DESCENDING);
    //        ViewState["SortDirection"] = DESCENDING;
    //        GridViewSortDirection = SortDirection.Ascending;
    //    }
    //}
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
    public DataTable GetPlayLists()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        int companyID = GetUsersCompanyID();
        DataTable dtPlayLists = objBussLogic.GetPlayLists(commFunc.GetUsersCompanyID(Context));
        DataTable dtFilteredPlayLists = new DataTable();
        //if (!string.IsNullOrEmpty(txtPlaylist.Text.Trim()))
        //{
        //    DataRow[] drRows = dtPlayLists.Select(string.Format("PlayListName = '{0}'", txtPlaylist.Text));
        //    if (drRows != null && drRows.Count() > 0)
        //    {
        //        dtFilteredPlayLists = drRows.CopyToDataTable();
        //    }
        //}
        if (dtFilteredPlayLists != null && dtFilteredPlayLists.Rows.Count > 0)
        {
            return dtFilteredPlayLists;
        }
        else
        {
            return dtPlayLists;
        }
    }
    //protected void btnCreatePlayList_Click(object sender, EventArgs e)
    //{
    //    bool blnResult = false;
    //    string strFileName = string.Empty;
    //    string strFilePath = string.Empty;
    //    string tempPath = string.Empty;
    //    string savepath = string.Empty;
    //    string fileName = string.Empty;
    //    string filename = string.Empty;
    //    if (!string.IsNullOrEmpty(txtCreatePlayList.Text))
    //    {
    //        if (imgFileUpload.HasFile)
    //        {
    //            filename = imgFileUpload.PostedFile.FileName;
    //            string fullPath = Path.GetFullPath(filename);
    //            string strfilename = Path.GetFileName(filename);
    //            fileName = strfilename;

    //            strFilePath = HttpContext.Current.Server.MapPath("../../img/") + filename;
    //            imgFileUpload.SaveAs(strFilePath);
    //        }
    //        else
    //        {
    //            strFilePath = HttpContext.Current.Server.MapPath("../../img/") + "Default.png";
    //            strFileName = "Default.png";
    //        }
    //        BusinessLogic objBusinessLogic = new BusinessLogic();
    //        blnResult = objBusinessLogic.CreatePlayList(txtCreatePlayList.Text, GetUsersCompanyID(), strFilePath, filename);
    //        if (blnResult)
    //        {
    //            lblCreatePlayListStatus.Visible = true;
    //            lblCreatePlayListStatus.ForeColor = Color.Green;
    //            lblCreatePlayListStatus.Text = "Playlist created successfully.";
    //            txtCreatePlayList.Text = "";
    //        }
    //        else
    //        {
    //            lblCreatePlayListStatus.Visible = true;
    //            lblCreatePlayListStatus.ForeColor = Color.Red;
    //            lblCreatePlayListStatus.Text = "Operation Failed. Please Contact Administrator.";
    //        }
    //    }
    //    BindGrid();
    //}

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        UpdatePreference(sender, e);
    }

    [WebMethod]
    [ScriptMethod]
    public static void SavePlayList(Media media)
    {
        Pages_CreatePlaylist associate = new Pages_CreatePlaylist();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociateMediaToPlayList(media.ID, Convert.ToInt32(media.PlaylistID), associate.GetUsersCompanyID());
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
    //protected void grdPlayList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in grdPlayList.Rows)
    //    {
    //        if (row.RowIndex == grdPlayList.SelectedIndex)
    //        {
    //            row.BackColor = ColorTranslator.FromHtml("#a3a3a4");
    //            row.ToolTip = string.Empty;
    //            Label lblPlayListName = grdPlayList.SelectedRow.FindControl("lblPlayListName") as Label;
    //            if (lblPlayListName != null)
    //            {
    //                string strPlaylistName = (grdPlayList.SelectedRow.FindControl("lblPlayListName") as Label).Text;
    //                lblSelectedCampaign.Visible = true;
    //                //lblSelectedCampaign.Text = " - " + strPlaylistName;
    //                hdnPlaylistName.Value = strPlaylistName;
    //            }
    //        }
    //        else
    //        {
    //            row.BackColor = Color.Transparent;
    //        }
    //    }
    //}
    //protected void btnLoadSearchGrid_Click(object sender, EventArgs e)
    //{
    //    DataTable dtPlayLists = GetPlayLists();
    //    DataTable dtFilteredPlayLists = new DataTable();
    //    if (!string.IsNullOrEmpty(txtPlaylist.Text.Trim()))
    //    {
    //        DataRow[] drRows = dtPlayLists.Select(string.Format("PlayListName = '{0}'", txtPlaylist.Text));
    //        if (drRows != null && drRows.Count() > 0)
    //        {
    //            dtFilteredPlayLists = drRows.CopyToDataTable();
    //        }
    //    }
    //    if (dtFilteredPlayLists != null && dtFilteredPlayLists.Rows.Count > 0)
    //    {
    //        grdPlayList.DataSource = dtFilteredPlayLists;
    //        grdPlayList.DataBind();
    //    }
    //    else
    //    {
    //        grdPlayList.DataSource = dtPlayLists;
    //        grdPlayList.DataBind();
    //    }
    //}

    protected void grdPlayList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string userName = Context.User.Identity.Name;
        if (!Roles.IsUserInRole(userName, "Guest"))
        {
            DataTable dataTable = GetPlayLists(); 
            grdPlayList.DataSource = dataTable;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in grdPlayList.SelectedItems)
        {
            string playlistId = item.GetDataKeyValue("PlayListID").ToString(); // Works if you set the DataKeyValue as CustomerID             
            item.Edit = true;
            grdPlayList.MasterTableView.Rebind();
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in grdPlayList.SelectedItems)
        {
            //Get the primary key value using the DataKeyValue.       
            int playlistId = Convert.ToInt32(item.GetDataKeyValue("PlayListID"));
            BusinessLogic objBussLogic = new BusinessLogic();
            try
            {
                bool blnResult = objBussLogic.DeletePlayList(playlistId);
                if (blnResult)
                {
                    grdPlayList.Controls.Add(new LiteralControl("Playlist Deleted Successfully."));
                    grdPlayList.MasterTableView.Rebind();
                }
                else
                    grdPlayList.Controls.Add(new LiteralControl("Unable to delete."));
            }
            catch (Exception ex)
            {
                grdPlayList.Controls.Add(new LiteralControl("Unable to delete. Reason: " + ex.Message));
            }
        }
    }

    protected void grdPlayList_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        GridEditableItem editedItem = e.Item as GridEditableItem;
        string strPlayListID = editedItem.GetDataKeyValue("PlayListID").ToString();
        TextBox txtPlayListName = (TextBox)editedItem.FindControl("txtPlayListName");
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdatePlayList(txtPlayListName.Text, Convert.ToInt32(strPlayListID));
        if (blnResult)
        {
            grdPlayList.MasterTableView.Rebind();
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtPlayListName.Text + " updated successfully.";
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
        }
    }
}

public class Media
{
    public int ID { get; set; }
    public string PlaylistID { get; set; }
}