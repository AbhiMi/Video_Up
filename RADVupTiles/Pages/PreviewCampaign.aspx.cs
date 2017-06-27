using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_PreviewCampaign : System.Web.UI.Page
{
    public static bool isSort = false;
    public static bool isAscend = false;
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static bool showImage = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        string Campaign_Sort_Direction = "CampaignName ASC";
        string AssctedPlaylist_Sort_Direction = "PlayListName ASC";
        CommonFunctions commFunc = new CommonFunctions();
        if (!Page.IsPostBack)
        {
            ViewState["Campaign_Sort_Direction"] = Campaign_Sort_Direction;
            ViewState["AssctedPlaylist_Sort_Direction"] = AssctedPlaylist_Sort_Direction;

            GetChannels(commFunc.GetUsersCompanyID(Context));
            hdnCompanyID.Value = commFunc.GetUsersCompanyID(Context).ToString();
            DataView dvCampaign = GetCampaign(Convert.ToInt32(hdnCompanyID.Value));
            grdCampaign.DataSource = dvCampaign;
            grdCampaign.DataBind();

            
            ddlCampaigns.DataSource = dvCampaign;
            ddlCampaigns.DataTextField = "CampaignName";
            ddlCampaigns.DataValueField = "CampaignID";
            ddlCampaigns.DataBind();
            ddlCampaigns.Items.Insert(0, "-- Please Select a Campaign --");
        }
    }
    public DataView GetCampaign(int CompanyID)
    {
        BusinessLogic objBussLogic = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataTable dtCampaigns = objBussLogic.GetCampaigns(commFunc.GetUsersCompanyID(Context));
        DataView dvCampaigns = dtCampaigns.DefaultView;
        dvCampaigns.Sort = ViewState["Campaign_Sort_Direction"].ToString();
        return dvCampaigns;
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        RadWizard1.NavigationBarPosition = RadWizardNavigationBarPosition.Left;
        RadWizard1.ProgressBarPosition = RadWizardProgressBarPosition.Left;
    }
    protected void grdCampaign_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string key = grdCampaign.DataKeys[e.Row.RowIndex].Value.ToString();
            e.Row.Attributes.Add("id", key);

            Literal media = (Literal)e.Row.Cells[3].FindControl("Literal1");
            Label lblButton = (Label)e.Row.Cells[2].FindControl("lblCampaign");
            hdnCampainName.Value = lblButton.Text;
            string mediaId = "media_" + media.ClientID;
            StringBuilder str = new StringBuilder();
            str.Append("<video controls='controls' width='480' height='360' autoplay poster='../img/Player Play.png' id='" + mediaId + "'>");

            BusinessLogic objBussLogic = new BusinessLogic();
            CommonFunctions commFunc = new CommonFunctions();
            DataTable dtMedia = objBussLogic.GetMediaForCampaign(commFunc.GetUsersCompanyID(Context), lblButton.Text);

            if (dtMedia != null && dtMedia.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMedia.Rows)
                {
                    str.Append("<source src='" + dr["UrlLocation"].ToString() + "' type='video/mp4'>");
                }

                str.Append("</video>");
            }
            media.Text = str.ToString();
        }
    }
    protected void RadWizard1_ActiveStepChanged(object sender, EventArgs e)
    {
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
    //private void GetCampaigns(int companyID)
    //{
    //    BusinessLogic objBusiness = new BusinessLogic();
    //    CommonFunctions commFunc = new CommonFunctions();
    //    DataSet dsCampaign = new DataSet();

    //    dsCampaign = objBusiness.GetCampaignsForScheduler(commFunc.GetUsersCompanyID(Context));

    //    RadScheduler1.DataStartField = "StartDateTime";
    //    RadScheduler1.DataSubjectField = "CampaignName";
    //    RadScheduler1.DataEndField = "EndDateTime";
    //    RadScheduler1.DataKeyField = "ID";
    //    RadScheduler1.DataSource = dsCampaign;
    //    DataView dv = dsCampaign.Tables[0].DefaultView;
    //    RadScheduler1.DataSource = dv;
    //    RadScheduler1.DataBind();
    //    RadScheduler1.SelectedView = SchedulerViewType.MonthView;
    //    if (dv != null && dv.Table.Rows.Count > 0)
    //    {
    //        RadScheduler1.SelectedDate = Convert.ToDateTime(dv.Table.Rows[0]["EndDateTime"]);
    //        RadScheduler1.Visible = true;
    //    }
    //}
    private void GetChannels(int companyID)
    {
        BusinessLogic objBusiness = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataSet dsChannels = new DataSet();

        if (ddlCampaigns.SelectedIndex > 0)
        {
            dsChannels = objBusiness.GetChannelsForScheduler(commFunc.GetUsersCompanyID(Context), Convert.ToInt32(ddlCampaigns.SelectedItem.Value));

            RadScheduler1.DataStartField = "StartDateTime";
            RadScheduler1.DataSubjectField = "ChannelName";
            RadScheduler1.DataEndField = "EndDateTime";
            RadScheduler1.DataKeyField = "ID";
            RadScheduler1.DataSource = dsChannels;
            DataView dv = dsChannels.Tables[0].DefaultView;
            RadScheduler1.DataSource = dv;
            RadScheduler1.DataBind();
            RadScheduler1.SelectedView = SchedulerViewType.MonthView;
            if (dv != null && dv.Table.Rows.Count > 0)
            {
                RadScheduler1.SelectedDate = Convert.ToDateTime(dv.Table.Rows[0]["EndDateTime"]);
                RadScheduler1.Visible = true;
            }
        }
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
        BusinessLogic objBusiness = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataSet dsChannels = new DataSet();

        if (ddlCampaigns.SelectedIndex > 0)
        {
            dsChannels = objBusiness.GetChannelsForScheduler(commFunc.GetUsersCompanyID(Context), Convert.ToInt32(ddlCampaigns.SelectedItem.Value));
            if (dsChannels != null && dsChannels.Tables.Count > 0)
            {
                DataTable dtChannels = dsChannels.Tables[0];
                if (dtChannels != null && dtChannels.Rows.Count > 0)
                {
                    DataRow[] drRows = dtChannels.Select(string.Format("ID = {0}", e.Appointment.ID));
                    if (drRows != null && drRows.Count() > 0)
                    {
                        e.Appointment.BackColor = ColorTranslator.FromHtml(Convert.ToString(drRows[0]["Color"]));
                    }
                }
            }
        }
        e.Appointment.ToolTip = e.Appointment.Subject + ": " + e.Appointment.Description;
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
    protected void SortGridView(string sortExpression, string direction)
    {
        //CommonFunctions commFunc = new CommonFunctions();
        //DataTable dataTable = GetCampaigns(commFunc.GetUsersCompanyID(Context));
        //if (dataTable != null)
        //{
        //    DataView dataView = new DataView(dataTable);
        //    dataView.Sort = sortExpression + direction;

        //    grdCampaign.DataSource = dataView;
        //    grdCampaign.DataBind();
        //}
    }
    protected void grdCampaign_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToLowerInvariant() == "publish")
        {
            CommonFunctions commFunc = new CommonFunctions();
            string strCampaignName = e.CommandArgument.ToString();
            //lblCampaignName.Text = strCampaignName;
            ddlCampaigns.SelectedText = strCampaignName;
            GetChannels(commFunc.GetUsersCompanyID(Context));
        }
    }
    protected void ddlCampaigns_SelectedIndexChanged(object sender, DropDownListEventArgs e)
    {
        if (ddlCampaigns.SelectedIndex > 0)
        {
            CommonFunctions commFunc = new CommonFunctions();
            //lblCampaignName.Text = ddlCampaigns.SelectedItem.Text;
            GetChannels(commFunc.GetUsersCompanyID(Context));
        }
        else
        {
            //lblCampaignName.Text = "Please select a campaign";
        }
    }
}