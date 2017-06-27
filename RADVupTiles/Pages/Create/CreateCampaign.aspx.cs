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

public partial class Pages_CreateCampaign : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    string Campaign_Sort_Direction = "CampaignName ASC";
    string AvblPlaylist_Sort_Direction = "PlayListName ASC";
    string AssctedPlaylist_Sort_Direction = "PlayListName ASC";
    public static DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        #region ClientSideEvents
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion
        if (!IsPostBack)
        {
            BindGrid();

            ViewState["Campaign_Sort_Direction"] = Campaign_Sort_Direction;
            ViewState["AvblPlaylist_Sort_Direction"] = AvblPlaylist_Sort_Direction;
            ViewState["AssctedPlaylist_Sort_Direction"] = AssctedPlaylist_Sort_Direction;
        }
        if (!string.IsNullOrEmpty(hdnCampaignName.Value))
        {
            BusinessLogic objBussLogic = new BusinessLogic();
            int campaignId = objBussLogic.GetCampaignID(hdnCampaignName.Value);
            hdnCampaignID.Value = Convert.ToString(campaignId);
            LoadAssociationGrid(hdnCampaignName.Value);
            LoadPlaylistData();
        }
        LoadPlaylistData();
        if (gvDest.Rows.Count == 0)
            btnSaveOrder.Visible = false;
        else
            btnSaveOrder.Visible = true;
    }
    private DataView LoadPlaylistData()
    {
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtCampaigns = GetUnAssociatedPlayLists(commFunc.GetUsersCompanyID(Context));
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["AvblPlaylist_Sort_Direction"].ToString();
        gvSource.DataSource = dvCampaigns;
        gvSource.DataBind();
        gvSource.Visible = true;
        return dvCampaigns;
    }
    public DataTable GetUnAssociatedPlayLists(int CompanyId)
    {
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociatePlaylists(commFunc.GetUsersCompanyID(Context));
        return dtMediaFiles;
    }
    public DataView GetChannels(int CompanyID)
    {
        CommonFunctions commFunc = new CommonFunctions();
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtChannels = objBussLogic.GetChannels(commFunc.GetUsersCompanyID(Context));
        DataView dvChannels = dtChannels.DefaultView;
        dvChannels.Sort = ViewState["Channel_Sort_Direction"].ToString();
        return dvChannels;
    }
    //protected void btnCreateCampaign_Click(object sender, EventArgs e)
    //{
    //    bool blnResult = false;
    //    string strFileName = string.Empty;
    //    string strFilePath = string.Empty;
    //    string tempPath = string.Empty;
    //    string savepath = string.Empty;
    //    string fileName = string.Empty;
    //    string filename = string.Empty;
    //    if (!string.IsNullOrEmpty(txtCreateCampaign.Text))
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
    //        imgFileUpload.SaveAs(strFilePath);
    //        BusinessLogic objBusinessLogic = new BusinessLogic();
    //        CommonFunctions commFunc = new CommonFunctions();
    //        blnResult = objBusinessLogic.CreateCampaign(txtCreateCampaign.Text, commFunc.GetUsersCompanyID(Context), strFilePath, filename, ColorTranslator.ToHtml(RadColorPicker1.SelectedColor));
    //        if (blnResult)
    //        {
    //            lblCreateCampaignStatus.Visible = true;
    //            lblCreateCampaignStatus.ForeColor = Color.Green;
    //            lblCreateCampaignStatus.Text = "Campaign created successfully.";
    //            txtCreateCampaign.Text = "";
    //        }
    //        else
    //        {
    //            lblCreateCampaignStatus.Visible = true;
    //            lblCreateCampaignStatus.ForeColor = Color.Red;
    //            lblCreateCampaignStatus.Text = "Operation Failed. Please Contact Administrator.";
    //        }
    //    }
    //    //BindGrid();
    //}
    private DataView LoadAssociationGrid(string campaignName)
    {
        DataView dvAssociations = null;
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        //DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID());
        DataTable dtAssociations = objBussLogic.GetPlayListCompanyAssociation(commFunc.GetUsersCompanyID(Context), campaignName);
        if (dtAssociations.Rows.Count == 0)
        {
            //dtAssociations.Rows.Add(dtAssociations.NewRow());
            //dvAssociations = dtAssociations.DefaultView;
            //gvDest.DataSource = dtAssociations;
            //gvDest.DataBind();
            //int columncount = gvDest.Rows[0].Cells.Count;
            //gvDest.Rows[0].Cells.Clear();
            //gvDest.Rows[0].Cells.Add(new TableCell());
            //gvDest.Rows[0].Cells[0].ColumnSpan = columncount;
            //gvDest.Rows[0].Cells[0].Text = "No Records Found";
        }
        else
        {
            dvAssociations = dtAssociations.DefaultView;
            dvAssociations.Sort = ViewState["AssctedPlaylist_Sort_Direction"].ToString();
            gvDest.DataSource = dvAssociations;
            gvDest.DataBind();
        }
        gvDest.Visible = true;
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
        Pages_CreateCampaign associate = new Pages_CreateCampaign();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociatePlayListToCampaign(playlist.ID, Convert.ToInt32(playlist.CampaignID), associate.GetUsersCompanyID());
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

    [WebMethod]
    public static List<string> GetChannelName(string channelName)
    {
        List<string> channelResult = new List<string>();
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtPLayLists = objBussLogic.GetChannels(GetUsersCompanyID());
        Pages_CreateCampaign associate = new Pages_CreateCampaign();
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

    protected void btnSaveOrder_Click(object sender, EventArgs e)
    {
        UpdatePreference(sender, e);
    }
    protected void imgShow_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        ImageButton imgShowHide = (sender as ImageButton);
        GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);
        if (imgShowHide.CommandArgument == "Show")
        {
            row.FindControl("pnlMedia").Visible = true;
            imgShowHide.CommandArgument = "Hide";
            imgShowHide.ImageUrl = "../../img/minus.gif";
            string playListName = gvDest.DataKeys[row.RowIndex].Value.ToString();
            GridView gvMedia = row.FindControl("gvMedia") as GridView; gvMedia.ToolTip = playListName;
            DataTable dt = objBussLogic.GetMediaPlayListAssociation(commFunc.GetUsersCompanyID(Context));
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
        CommonFunctions commFunc = new CommonFunctions();
        bool result = objBussLogic.UnAssociatePlayLists(commFunc.GetUsersCompanyID(Context), playlistID);
        if (result)
        {
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }
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
        gvDest.DataSource = LoadAssociationGrid(hdnCampaignName.Value);
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

    public DataTable GetCampaigns(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtCampaigns = objBussLogic.GetCampaigns(CompanyID);
        DataTable dtFilteredCampaigns = new DataTable();
        //if (!string.IsNullOrEmpty(txtCampaign.Text.Trim()))
        //{
        //    DataRow[] drRows = dtCampaigns.Select(string.Format("CampaignName = '{0}'", txtCampaign.Text));
        //    if (drRows != null && drRows.Count() > 0)
        //    {
        //        dtFilteredCampaigns = drRows.CopyToDataTable();
        //    }
        //}
        if (dtFilteredCampaigns != null && dtFilteredCampaigns.Rows.Count > 0)
        {
            return dtFilteredCampaigns;
        }
        else
        {
            return dtCampaigns;
        }
    }

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
            //grdCampaign.HeaderRow.Cells[0].Controls.Add(sortImage);
        }
    }
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

    protected void btnLoadGrid_Click(object sender, EventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        int campaignId = objBussLogic.GetCampaignID(hdnCampaignName.Value);
        hdnCampaignID.Value = campaignId.ToString();
        LoadPlaylistData();
        LoadAssociationGrid(hdnCampaignName.Value);
    }

    protected void SideBarList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        WizardStep dataItem = e.Item.DataItem as WizardStep;
        LinkButton linkButton = e.Item.FindControl("SideBarButton") as LinkButton;

        if (dataItem != null)
        {
            if (dataItem.Wizard.ActiveStepIndex == e.Item.ItemIndex)
            {
                linkButton.CssClass = "sidebarActiveLink";
            }
        }
    }

    protected void grdCampaign_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        string userName = Context.User.Identity.Name;
        if (!Roles.IsUserInRole(userName, "Guest"))
        {
            CommonFunctions commFunc = new CommonFunctions();
            commFunc.GetUsersCompanyID(Context);
            DataTable dataTable = GetCampaigns(GetUsersCompanyID());
            //DataTable dataTable = GetCampaigns(42); 
            grdCampaign.DataSource = dataTable;
        }
    }

    //protected void grdCampaign_UpdateCommand(object sender, GridCommandEventArgs e)
    //{
    //    GridEditableItem editedItem = e.Item as GridEditableItem;
    //    string strSelectedColor = string.Empty;
    //    int iCampaignID = Convert.ToInt32(editedItem.GetDataKeyValue("CampaignID"));
    //    TextBox txtCampaignName = (TextBox)editedItem.FindControl("txtCampaignName");
    //    RadColorPicker rdColorPicker = (RadColorPicker)editedItem.FindControl("RadColorPicker1");        
    //    if (rdColorPicker != null)
    //    {
    //        strSelectedColor = ColorTranslator.ToHtml(rdColorPicker.SelectedColor);
    //    }
    //    BusinessLogic objBussLogic = new BusinessLogic();
    //    bool blnResult = objBussLogic.UpdateCampaign(iCampaignID, txtCampaignName.Text, strSelectedColor);
    //    if (blnResult)
    //    {
    //        grdCampaign.Controls.Add(new LiteralControl(txtCampaignName.Text + " updated successfully."));
    //        grdCampaign.MasterTableView.Rebind();
    //    }
    //    else
    //    {
    //        grdCampaign.Controls.Add(new LiteralControl("Updated failed.Please contact system administrator."));
    //        e.Canceled = true;
    //    }
    //}

    //protected void btnEdit_Click(object sender, EventArgs e)
    //{
    //    foreach (GridDataItem item in grdCampaign.SelectedItems)
    //    {
    //        string campaignID = item.GetDataKeyValue("CampaignID").ToString(); // Works if you set the DataKeyValue as CustomerID             
    //        item.Edit = true;
    //        grdCampaign.MasterTableView.Rebind();
    //    }
    //}

    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    foreach (GridDataItem item in grdCampaign.SelectedItems)
    //    {
    //        //Get the primary key value using the DataKeyValue.       
    //        int campaignId = Convert.ToInt32(item.GetDataKeyValue("CampaignID"));
    //        BusinessLogic objBussLogic = new BusinessLogic();
    //        try
    //        {
    //            bool blnResult = objBussLogic.DeleteCampaign(campaignId);
    //            if (blnResult)
    //            {
    //                grdCampaign.Controls.Add(new LiteralControl("Campaign Deleted Successfully."));
    //                grdCampaign.MasterTableView.Rebind();
    //            }
    //            else
    //                grdCampaign.Controls.Add(new LiteralControl("Unable to delete."));
    //        }
    //        catch (Exception ex)
    //        {
    //            grdCampaign.Controls.Add(new LiteralControl("Unable to delete. Reason: " + ex.Message));                
    //        }
    //    }
    //}

    protected void grdCampaign_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdCampaign.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void grdCampaign_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strSelectedColor = string.Empty;
        string strCampaignID = grdCampaign.DataKeys[e.RowIndex].Values["CampaignID"].ToString();
        TextBox txtCampaignName = (TextBox)grdCampaign.Rows[e.RowIndex].FindControl("txtCampaignName");
        RadColorPicker rdColorPicker = (RadColorPicker)grdCampaign.Rows[e.RowIndex].FindControl("rdDefaultColor");

        bool isImageChanged = false;
        # region "image upload "

        FileUpload imgFileUpload = (FileUpload)grdCampaign.Rows[e.RowIndex].FindControl("imgFileUpload");
        string strFilePath = string.Empty;
        string strFileName = string.Empty;
        if (imgFileUpload.HasFile)
        {
            isImageChanged = true;
            string filename = imgFileUpload.PostedFile.FileName;
            string fullPath = Path.GetFullPath(filename);
            string strfilename = Path.GetFileName(filename);
            strFileName = strfilename;

            strFilePath = HttpContext.Current.Server.MapPath("../../img/") + filename;
            imgFileUpload.SaveAs(strFilePath);
        }
        else
        {
            strFilePath = HttpContext.Current.Server.MapPath("../../img/") + "Default.png";
            strFileName = "Default.png";
            imgFileUpload.SaveAs(strFilePath);
        }
        #endregion



        if (rdColorPicker != null)
        {
            strSelectedColor = ColorTranslator.ToHtml(rdColorPicker.SelectedColor);
            //  rdDefaultColor.SelectedColor = ColorTranslator.FromHtml(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Color")));
        }
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateCampaign(Convert.ToInt32(strCampaignID), txtCampaignName.Text, strSelectedColor.Trim(), strFilePath, strFileName, isImageChanged);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtCampaignName.Text + " updated successfully.";
            grdCampaign.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdCampaign.EditIndex = -1;
        }
        BindGrid();
        lblTitle.Text = txtCampaignName.Text;
        hdnCampaignName.Value = txtCampaignName.Text;
    }
    protected void grdCampaign_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdCampaign.EditIndex = -1;
        BindGrid();
    }
    protected void grdCampaign_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strStoreID = grdCampaign.DataKeys[e.RowIndex].Values["CampaignID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteCampaign(Convert.ToInt32(strStoreID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Campaign deleted successfully.";
            grdCampaign.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdCampaign.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdCampaign_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadColorPicker rdDefaultColor = (RadColorPicker)e.Row.FindControl("rdDefaultColor");
            if (rdDefaultColor != null)
            {
                //Color color = (Color)(DataBinder.Eval(e.Row.DataItem, "Color"));

                rdDefaultColor.SelectedColor = ColorTranslator.FromHtml(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Color")));
            }

        }
        e.Row.Height = Unit.Pixel(20);
    }

    protected void SortGridView(string sortExpression, string direction)
    {
        DataTable dataTable = GetCampaigns(GetUsersCompanyID());
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdCampaign.DataSource = dataView;
            grdCampaign.DataBind();
        }
    }
    protected void grdCampaign_Sorting(object sender, GridViewSortEventArgs e)
    {
        isSort = true;
        string sortExpression = e.SortExpression;

        ViewState["SortExpression"] = sortExpression;
        showImage = true;
        if (GridViewSortDirection == SortDirection.Ascending)
        {
            isAscend = true;
            SortGridView(sortExpression, ASCENDING);
            ViewState["SortDirection"] = ASCENDING;
            GridViewSortDirection = SortDirection.Descending;
        }
        else
        {
            isAscend = false;
            SortGridView(sortExpression, DESCENDING);
            ViewState["SortDirection"] = DESCENDING;
            GridViewSortDirection = SortDirection.Ascending;
        }
    }

    private void BindGrid()
    {
        dataTable = GetCampaigns(GetUsersCompanyID());
        if (!IsPostBack)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = "DateCreated desc";

                grdCampaign.DataSource = dataView;
                grdCampaign.DataBind();
            }
        }
        else
        {
            if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
            {
                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                    grdCampaign.DataSource = dataView;
                    grdCampaign.DataBind();
                }
            }
            else
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    grdCampaign.DataSource = dataTable.DefaultView;
                    grdCampaign.DataBind();
                }
                else
                {
                    dataTable.NewRow();
                    grdCampaign.DataSource = dataTable.DefaultView;
                    grdCampaign.DataBind();

                }
            }
        }

    }
    public class Playlist
    {
        public int ID { get; set; }
        public string CampaignID { get; set; }
    }
    protected void grdCampaign_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCampaign.PageIndex = e.NewPageIndex;

        if (!isSort) // this will get exectued if user clicks paging
        {            // before sorting istelf

            BindGrid();    //instance. Provide your datasource
            // to bind the data
        }
        else if (isAscend)// this will get exectued if user clicks paging
        // after cliclking ascending order
        {

            // I am passing only "DateRequest" as sortexpression for instance. because
            // i am implementing sorting for only one column. You can generalize it to 
            // pass that particular column on sorting.
            SortGridView("CampaignName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("CampaignName", DESCENDING);
        }
    }

    [WebMethod]
    public static void SearchText(string name)
    {
        var qry = from dr in dataTable.AsEnumerable()
                  where dr["CampaignName"].ToString().Contains(name)
                  select dr;
        //Page page = (Page)HttpContext.Current.Handler;
        //GridView gv = (GridView)page.FindControl("grdCampaign");
        //gv.DataSource = dataTable;
        //gv.DataBind();
        //grdCampaign.DataSource = qry.ToList();
        //grdCampaign.DataBind();
        if (HttpContext.Current != null)
        {
            Page page = (Page)HttpContext.Current.Handler;
            GridView gd = (GridView)page.FindControl("grdCampaign");//null value

            gd.DataSource = dataTable;
            gd.DataBind();


        }
    }

    private void BindGrid_Search(DataTable dataTable)
    {
        // dataTable = GetCampaigns(GetUsersCompanyID());
        if (!IsPostBack)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = "DateCreated desc";

                grdCampaign.DataSource = dataView;
                grdCampaign.DataBind();
            }
        }
        else
        {
            if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
            {
                if (dataTable != null)
                {
                    DataView dataView = new DataView(dataTable);
                    dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                    grdCampaign.DataSource = dataView;
                    grdCampaign.DataBind();
                }
            }
            else
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    grdCampaign.DataSource = dataTable.DefaultView;
                    grdCampaign.DataBind();
                }
                else
                {
                    dataTable.NewRow();
                    grdCampaign.DataSource = dataTable.DefaultView;
                    grdCampaign.DataBind();

                }
            }
        }

    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var qry = from dr in dataTable.AsEnumerable()
                  where dr["CampaignName"].ToString().Contains(txtSearch.Text)
                  select dr;
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        lblSearchText.Text = txtSearch.Text;
        IEnumerable<DataRow> query = from dr in dataTable.AsEnumerable()
                                     where dr.Field<string>("CampaignName").Contains(txtSearch.Text)
                                     select dr;
        if (query.Count() > 0)
        {
            // Create a table from the query.
            DataTable boundTable = query.CopyToDataTable<DataRow>();
            BindGrid_Search(boundTable);
        }
        else
        {
            BindGrid_Search(new DataTable());
        }
    }
    protected void ClearSearch_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
        lblSearchText.Text = string.Empty;
        BindGrid();
    }
}