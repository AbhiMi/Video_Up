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

public partial class Pages_CreateChannel : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;

    string Channel_Sort_Direction = "ChannelName ASC";
    string AvblCampaign_Sort_Direction = "CampaignName ASC";
    string AssctedCampaign_Sort_Direction = "CampaignName ASC";
    public static DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        #region ClientSideEvents
        Page.ClientScript.RegisterStartupScript(this.GetType(), "HideColumn", "<script language='javascript'>hideColumn();</script>");
        #endregion
        BusinessLogic objBusinessLogic = new BusinessLogic();
        if (!IsPostBack)
        {
            BindGrid();
            string userName = Context.User.Identity.Name;
            if (!Roles.IsUserInRole(userName, "Guest"))
            {
                ViewState["Channel_Sort_Direction"] = Channel_Sort_Direction;
                ViewState["AvblCampaign_Sort_Direction"] = AvblCampaign_Sort_Direction;
                ViewState["AssctedCampaign_Sort_Direction"] = AssctedCampaign_Sort_Direction;
                DataView dvChannels = GetChannels(GetUsersCompanyID());
                ddlChannels.DataSource = dvChannels;
                ddlChannels.DataTextField = "ChannelName";
                ddlChannels.DataValueField = "ChannelID";
                ddlChannels.DataBind();
                ddlChannels.Items.Insert(0, "--Please Select a Channel--");
            }
        }
        if (!string.IsNullOrEmpty(hdnChannelName.Value))
        {
            int channelId = objBusinessLogic.GetChannelID(hdnChannelName.Value);
            //hdnChannelID.Value = Convert.ToString(channelId);
            LoadAssociationGrid(hdnChannelName.Value);
            LoadCampaignData();
        }
        //if (gvDest.Rows.Count == 0)
        //    btnSaveOrder.Visible = false;
        //else
        //    btnSaveOrder.Visible = true;

    }

    private DataView LoadCampaignData()
    {
        DataTable dtCampaigns = GetCampaigns(GetUsersCompanyID());
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["AvblCampaign_Sort_Direction"].ToString();
        //gvSource.DataSource = dvCampaigns;
        //gvSource.DataBind();
        return dvCampaigns;
    }

    public DataView GetChannels(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtChannels = objBussLogic.GetChannels(GetUsersCompanyID());
        DataView dvChannels = dtChannels.DefaultView;
        dvChannels.Sort = ViewState["Channel_Sort_Direction"].ToString();

        DataSet dsCampaign = new DataSet();
        CommonFunctions commFunc = new CommonFunctions();
        dsCampaign = objBussLogic.GetCampaignsForScheduler(commFunc.GetUsersCompanyID(Context));

        RadScheduler1.DataStartField = "StartDateTime";
        RadScheduler1.DataSubjectField = "CampaignName";
        RadScheduler1.DataEndField = "EndDateTime";
        RadScheduler1.DataKeyField = "ID";
        RadScheduler1.DataSource = dsCampaign;
        DataView dv = dsCampaign.Tables[0].DefaultView;
        RadScheduler1.DataSource = dv;
        RadScheduler1.DataBind();
        RadScheduler1.SelectedView = SchedulerViewType.MonthView;
        if (dv != null && dv.Table.Rows.Count > 0)
        {
            ViewState["Campaigns"] = dsCampaign.Tables[0];
            RadScheduler1.SelectedDate = Convert.ToDateTime(dv.Table.Rows[0]["EndDateTime"]);
            RadScheduler1.Visible = true;
        }

        return dvChannels;
    }
    protected void RadScheduler1_AppointmentInsert(object sender, AppointmentInsertEventArgs e)
    {
        //Appointment meetingAppointment = new Appointment();
        //meetingAppointment.Subject = e.Appointment.Subject;
        //meetingAppointment.Start = e.Appointment.Start;
        //meetingAppointment.End = e.Appointment.End;
        //DateTime displayStart = TimeZoneInfo.ConvertTimeToUtc(e.Appointment.Start);
        //DateTime displayEnd = TimeZoneInfo.ConvertTimeToUtc(e.Appointment.End);
        //bool IsAllDayAppointment = displayStart.CompareTo(displayStart.Date) == 0 && displayEnd.CompareTo(displayEnd.Date) == 0;
        ////RadScheduler1.InsertAppointment(meetingAppointment);
        //BusinessLogic objBusiness = new BusinessLogic();
        //int id = objBusiness.GetCampaignID(meetingAppointment.Subject);
        //objBusiness.UpdateCampaign(id, meetingAppointment.Subject);
    }
    protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {

        BusinessLogic objBusiness = new BusinessLogic();
        //int id = objBusiness.GetCampaignID(e.Appointment.Subject) ;
        DateTime displayStart = TimeZoneInfo.ConvertTimeToUtc(e.ModifiedAppointment.Start);
        DateTime displayEnd = TimeZoneInfo.ConvertTimeToUtc(e.ModifiedAppointment.End);
        bool IsAllDayAppointment = displayStart.CompareTo(displayStart.Date) == 0 && displayEnd.CompareTo(displayEnd.Date) == 0;
        objBusiness.UpdateSchedulerCampaign(Convert.ToInt32(e.ModifiedAppointment.ID), displayStart, displayEnd, IsAllDayAppointment);
    }
    protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        if (ViewState["Campaigns"] != null)
        {
            DataTable dtCampaigns = (DataTable)ViewState["Campaigns"];
            if (dtCampaigns != null && dtCampaigns.Rows.Count > 0)
            {
                DataRow[] drRows = dtCampaigns.Select(string.Format("ID = {0}", e.Appointment.ID));
                if (drRows != null && drRows.Count() > 0)
                {
                    e.Appointment.BackColor = ColorTranslator.FromHtml(Convert.ToString(drRows[0]["Color"]));
                    e.Appointment.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

        e.Appointment.ToolTip = e.Appointment.Subject + ": " + e.Appointment.Description;
    }
    public DataTable GetCampaigns(int CompanyId)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtMediaFiles = objBussLogic.GetCampaigns(GetUsersCompanyID());
        DataTable dtMediaFiles = objBussLogic.GetUnAssociatedCampaigns(GetUsersCompanyID());
        return dtMediaFiles;
    }

    private DataView LoadAssociationGrid(string channelName)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dt = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID());
        DataTable dtAssociations = objBussLogic.GetCampaignChannelAssociation(GetUsersCompanyID(), channelName);
        DataView dvAssociations = dtAssociations.DefaultView;
        dvAssociations.Sort = ViewState["AssctedCampaign_Sort_Direction"].ToString();
        //gvDest.DataSource = dvAssociations;
        //gvDest.DataBind();
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

        Pages_CreateChannel associate = new Pages_CreateChannel();

        BusinessLogic objBussLogic = new BusinessLogic();
        objBussLogic.AssociateCampaignToChannel(campaign.ID, Convert.ToInt32(campaign.ChannelID), associate.GetUsersCompanyID());
    }

    [WebMethod]
    public static List<string> GetChannelName(string channelName)
    {
        List<string> channelResult = new List<string>();
        BusinessLogic objBussLogic = new BusinessLogic();
        //DataTable dtPLayLists = objBussLogic.GetChannels(GetUsersCompanyID());
        Pages_CreateChannel associate = new Pages_CreateChannel();
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

    public DataTable GetChannels()
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        DataTable dtChannels = objBussLogic.GetChannels(GetUsersCompanyID());
        DataTable dtFilteredPlayLists = new DataTable();
        return dtChannels;
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
            //grdChannel.HeaderRow.Cells[0].Controls.Add(sortImage);
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
            row.FindControl("pnlPlaylist").Visible = true;
            imgShowHide.CommandArgument = "Hide";
            imgShowHide.ImageUrl = "../../img/minus.gif";
            //string campaignName = gvDest.DataKeys[row.RowIndex].Value.ToString();
            //GridView gvPlaylist = row.FindControl("gvPlaylist") as GridView; gvPlaylist.ToolTip = campaignName;
            //DataTable dt = objBussLogic.GetPlayListComp            //gvPlaylist.DataSource = dt;
            //gvPlaylist.DataBind();anyAssociation(GetUsersCompanyID(), campaignName);

        }
        else
        {
            row.FindControl("pnlPlaylist").Visible = false;
            imgShowHide.CommandArgument = "Show";
            imgShowHide.ImageUrl = "../../img/plus.gif";
        }
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
        //gvDest.DataSource = LoadAssociationGrid(txtChannel.Text);
        //gvDest.DataBind();

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
        //gvSource.DataSource = LoadCampaignData();
        //gvSource.DataBind();
    }

    protected void imgUnAssociate_Click(object sender, ImageClickEventArgs e)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        ImageButton imgUnAssociate = (sender as ImageButton);
        GridViewRow row = (imgUnAssociate.NamingContainer as GridViewRow);
        //int campanignID = Convert.ToInt32(gvDest.DataKeys[row.RowIndex].Values["CampaignID"].ToString());
        //bool result = objBussLogic.UnAssociateCampaigns(GetUsersCompanyID(), campanignID);
        //if (result)
        //{
        //    Response.Redirect(HttpContext.Current.Request.Url.ToString());
        //}
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

    protected void RadScheduler1_AppointmentCreated(object sender, Telerik.Web.UI.AppointmentCreatedEventArgs e)
    {
        if (e.Appointment.RecurrenceState == RecurrenceState.Master || e.Appointment.RecurrenceState == RecurrenceState.Occurrence)
        {
            Panel recurrenceStateDiv = new Panel();
            recurrenceStateDiv.CssClass = "rsAptRecurrence";
            e.Container.Controls.AddAt(0, recurrenceStateDiv);
        }
        if (e.Appointment.RecurrenceState == RecurrenceState.Exception)
        {
            Panel recurrenceStateDiv = new Panel();
            recurrenceStateDiv.CssClass = "rsAptRecurrenceException";
            e.Container.Controls.AddAt(0, recurrenceStateDiv);
        }
    }
    protected void RadScheduler1_DataBound(object sender, EventArgs e)
    {
        // Turn off the support for multiple resource values.
        foreach (ResourceType resType in RadScheduler1.ResourceTypes)
        {
            resType.AllowMultipleValues = false;
        }
    }
    protected void ddlChannels_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        if (ddlChannels.SelectedIndex > 0)
        {
            CommonFunctions commFunc = new CommonFunctions();
            //lblCampaignName.Text = ddlChannels.SelectedItem.Text;

            BusinessLogic objBussLogic = new BusinessLogic();
            DataTable dtChannels = objBussLogic.GetChannels(GetUsersCompanyID());


            DataSet dsCampaign = new DataSet();
            dsCampaign = objBussLogic.GetCampaignsForScheduler(commFunc.GetUsersCompanyID(Context), Convert.ToInt32(ddlChannels.SelectedItem.Value));

            RadScheduler1.DataStartField = "StartDateTime";
            RadScheduler1.DataSubjectField = "CampaignName";
            RadScheduler1.DataEndField = "EndDateTime";
            RadScheduler1.DataKeyField = "ID";
            RadScheduler1.DataSource = dsCampaign;
            DataView dv = dsCampaign.Tables[0].DefaultView;
            RadScheduler1.DataSource = dv;
            RadScheduler1.DataBind();
            RadScheduler1.SelectedView = SchedulerViewType.MonthView;
            if (dv != null && dv.Table.Rows.Count > 0)
            {
                ViewState["Campaigns"] = dsCampaign.Tables[0];
                RadScheduler1.SelectedDate = Convert.ToDateTime(dv.Table.Rows[0]["EndDateTime"]);
                RadScheduler1.Visible = true;
            }

        }
        else
        {
            //lblCampaignName.Text = "Please select a campaign";
        }
    }
    protected void btnLoadSearchGrid_Click(object sender, EventArgs e)
    {
        //BindGrid();
    }

    protected void grdChannel_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        DataTable dataTable = GetChannels();
        grdChannel.DataSource = dataTable;
    }

    //protected void btnEdit_Click(object sender, EventArgs e)
    //{
    //    foreach (GridDataItem item in grdChannel.SelectedItems)
    //    {
    //        string campaignID = item.GetDataKeyValue("ChannelID").ToString(); // Works if you set the DataKeyValue as CustomerID             
    //        item.Edit = true;
    //        grdChannel.MasterTableView.Rebind();
    //    }
    //}

    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    foreach (GridDataItem item in grdChannel.SelectedItems)
    //    {
    //        //Get the primary key value using the DataKeyValue.       
    //        int channelId = Convert.ToInt32(item.GetDataKeyValue("ChannelID"));
    //        BusinessLogic objBussLogic = new BusinessLogic();
    //        try
    //        {
    //            bool blnResult = objBussLogic.DeleteChannel(channelId);
    //            if (blnResult)
    //            {
    //                grdChannel.Controls.Add(new LiteralControl("Channel Deleted Successfully."));
    //                grdChannel.MasterTableView.Rebind();
    //            }
    //            else
    //                grdChannel.Controls.Add(new LiteralControl("Unable to delete."));
    //        }
    //        catch (Exception ex)
    //        {
    //            grdChannel.Controls.Add(new LiteralControl("Unable to delete. Reason: " + ex.Message));
    //        }
    //    }        
    //}

    protected void grdChannel_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strSelectedColor = string.Empty;
        string strChannelID = grdChannel.DataKeys[e.RowIndex].Values["ChannelID"].ToString();
        TextBox txtChannelName = (TextBox)grdChannel.Rows[e.RowIndex].FindControl("txtChannelName");
        RadColorPicker rdColorPicker = (RadColorPicker)grdChannel.Rows[e.RowIndex].FindControl("rdDefaultColor");

        bool isImageChanged = false;
        # region "image upload "

        FileUpload imgFileUpload = (FileUpload)grdChannel.Rows[e.RowIndex].FindControl("imgFileUpload");
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
        }
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.UpdateChannel(Convert.ToInt32(strChannelID), txtChannelName.Text, strSelectedColor.Trim(), strFilePath, strFileName, isImageChanged);
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = txtChannelName.Text + " updated successfully.";
            grdChannel.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Updated failed. Please contact system administrator.";
            grdChannel.EditIndex = -1;
        }
        BindGrid();
    }


    protected void grdChannel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdChannel.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void grdChannel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdChannel.EditIndex = -1;
        BindGrid();
    }
    protected void grdChannel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strChannelID = grdChannel.DataKeys[e.RowIndex].Values["ChannelID"].ToString();
        BusinessLogic objBussLogic = new BusinessLogic();
        bool blnResult = objBussLogic.DeleteChannel(Convert.ToInt32(strChannelID));
        if (blnResult)
        {
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Channel deleted successfully.";
            grdChannel.EditIndex = -1;
        }
        else
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = "Deletion failed. Please contact system administrator.";
            grdChannel.EditIndex = -1;
        }
        BindGrid();

    }
    protected void grdChannel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadColorPicker rdDefaultColor = (RadColorPicker)e.Row.FindControl("rdDefaultColor");
            if (rdDefaultColor != null)
            {
                rdDefaultColor.SelectedColor = ColorTranslator.FromHtml(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Color")));
            }
        }
        e.Row.Height = Unit.Pixel(20);
    }
    protected void grdChannel_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void BindGrid()
    {
        dataTable = GetChannels();
        if (ViewState["SortExpression"] != null && ViewState["SortDirection"] != null)
        {
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = Convert.ToString(ViewState["SortExpression"]) + Convert.ToString(ViewState["SortDirection"]);

                grdChannel.DataSource = dataView;
                grdChannel.DataBind();
            }
        }
        else
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                grdChannel.DataSource = dataTable.DefaultView;
                grdChannel.DataBind();
            }
            else
            {
                dataTable.NewRow();
                grdChannel.DataSource = dataTable.DefaultView;
                grdChannel.DataBind();

            }
        }
    }

    protected void grdChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdChannel.Rows)
        {
            if (row.RowIndex == grdChannel.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#a3a3a4");
                row.ToolTip = string.Empty;
                Label lblChannelName = grdChannel.SelectedRow.FindControl("lblChannelName") as Label;
                if (lblChannelName != null)
                {
                    string strChannelName = (grdChannel.SelectedRow.FindControl("lblChannelName") as Label).Text;
                    lblSelectedCampaign.Visible = true;
                    //lblSelectedCampaign.Text = " - " + strChannelName;
                    hdnChannelName.Value = strChannelName;
                }
            }
            else
            {
                row.BackColor = Color.Transparent;
            }
        }
    }
    protected void grdChannel_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void SortGridView(string sortExpression, string direction)
    {
        DataTable dataTable = GetChannels();
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = sortExpression + direction;

            grdChannel.DataSource = dataView;
            grdChannel.DataBind();
        }
    }
    protected void grdChannel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdChannel.PageIndex = e.NewPageIndex;

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
            SortGridView("ChannelName", ASCENDING);

        }
        else // this will get exectued if user clicks paging
        // after cliclking descending order
        {
            SortGridView("ChannelName", DESCENDING);
        }
    }

    protected int GetSortColumnIndex()
    {
        foreach (DataControlField field in grdChannel.Columns)
        {
            if (field.SortExpression == grdChannel.SortExpression)
                return grdChannel.Columns.IndexOf(field);
            else
                return -1;
        }
        return -1;
    }
    protected void grdChannel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int sortColumnIndex = 0;

        if (e.Row.RowType == DataControlRowType.Header)
            sortColumnIndex = GetSortColumnIndex();

        if (sortColumnIndex != 1)
        {
            AddSortImage(sortColumnIndex, e.Row);
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != grdChannel.EditIndex)
        {
            // Programmatically reference the Edit and Delete LinkButtons
            Button EditButton = e.Row.FindControl("ButtonEdit") as Button;

            Button DeleteButton = e.Row.FindControl("ButtonDelete") as Button;

            EditButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
            DeleteButton.Visible = (User.IsInRole("VUP Admin") || User.IsInRole("Company Admin") || User.IsInRole("Store Admin"));
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

                grdChannel.DataSource = dataView;
                grdChannel.DataBind();
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

                    grdChannel.DataSource = dataView;
                    grdChannel.DataBind();
                }
            }
            else
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    grdChannel.DataSource = dataTable.DefaultView;
                    grdChannel.DataBind();
                }
                else
                {
                    dataTable.NewRow();
                    grdChannel.DataSource = dataTable.DefaultView;
                    grdChannel.DataBind();

                }
            }
        }

    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        lblSearchText.Text = txtSearch.Text;
        IEnumerable<DataRow> query = from dr in dataTable.AsEnumerable()
                                     where dr.Field<string>("ChannelName").Contains(txtSearch.Text)
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

public class Campaign
{
    public int ID { get; set; }
    public string ChannelID { get; set; }
}