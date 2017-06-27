using RADBusinessLogicLayer;
using RADCommonServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_RADScheduler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CommonFunctions commFunc = new CommonFunctions();
            GetCampaigns(commFunc.GetUsersCompanyID(Context));
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
    private void GetCampaigns(int companyID)
    {
        BusinessLogic objBusiness = new BusinessLogic();
        CommonFunctions commFunc = new CommonFunctions();
        DataSet dsCampaign = new DataSet();

        dsCampaign = objBusiness.GetCampaignsForScheduler(commFunc.GetUsersCompanyID(Context));

        RadScheduler1.DataStartField = "StartDateTime";
        RadScheduler1.DataSubjectField = "CampaignName";
        RadScheduler1.DataEndField = "EndDateTime";
        RadScheduler1.DataKeyField = "ID";        
        RadScheduler1.DataSource = dsCampaign;
        DataView dv = dsCampaign.Tables[0].DefaultView;
        RadScheduler1.DataSource = dv;
        RadScheduler1.DataBind();
        RadScheduler1.SelectedView = SchedulerViewType.MonthView;
        RadScheduler1.SelectedDate = Convert.ToDateTime(dv.Table.Rows[0]["EndDateTime"]);
        RadScheduler1.Visible = true;


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
        //objBusiness.UpdateSchedulerCampaign(Convert.ToInt32(e.Appointment.ID), displayStart,displayEnd,IsAllDayAppointment);
    }
    protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {
        BusinessLogic objBusiness = new BusinessLogic();
        //int id = objBusiness.GetCampaignID(e.Appointment.Subject);
        DateTime displayStart = TimeZoneInfo.ConvertTimeToUtc(e.ModifiedAppointment.Start);
        DateTime displayEnd = TimeZoneInfo.ConvertTimeToUtc(e.ModifiedAppointment.End);
        bool IsAllDayAppointment = displayStart.CompareTo(displayStart.Date) == 0 && displayEnd.CompareTo(displayEnd.Date) == 0;
        objBusiness.UpdateSchedulerCampaign(Convert.ToInt32(e.ModifiedAppointment.ID), displayStart, displayEnd, IsAllDayAppointment);
    }
    protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        string colorAttribute = e.Appointment.Attributes["AppointmentColor"];
        if (!string.IsNullOrEmpty(colorAttribute))
        {
            int colorValue;
            if (int.TryParse(colorAttribute, out colorValue))
            {
                int borderColorValue = (colorValue < -0x7F7F7F ? colorValue + 0x202020 : colorValue - 0x202020);
                e.Appointment.BackColor = Color.FromArgb(colorValue);
                e.Appointment.BorderColor = Color.FromArgb(borderColorValue);
            }
        }

        e.Appointment.ToolTip = e.Appointment.Subject + ": " + e.Appointment.Description;
    }
}