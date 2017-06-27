using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

/// <summary>
/// Specifies the advanced form mode.
/// </summary>
public enum AdvancedFormMode
{
    Insert,
    Edit
}
public partial class Pages_AdvancedFormCS : System.Web.UI.UserControl
{
    #region Private members

    private bool FormInitialized
    {
        get
        {
            return (bool)(ViewState["FormInitialized"] ?? false);
        }

        set
        {
            ViewState["FormInitialized"] = value;
        }
    }

    private AdvancedFormMode mode = AdvancedFormMode.Insert;

    #endregion

    #region Protected properties

    protected RadScheduler Owner
    {
        get
        {
            return Appointment.Owner;
        }
    }

    protected Appointment Appointment
    {
        get
        {
            SchedulerFormContainer container = (SchedulerFormContainer)BindingContainer;
            return container.Appointment;
        }
    }

    #endregion

    #region Attributes and resources

    //[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    //public string Description
    //{
    //    get
    //    {
    //        return DescriptionText.Text;
    //    }

    //    set
    //    {
    //        DescriptionText.Text = value;
    //    }
    //}

    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public string AppointmentColor
    {
        get
        {
            // No color selected
            if (AppointmentColorPicker.SelectedColor.A == 0)
                return null;

            return AppointmentColorPicker.SelectedColor.ToArgb().ToString();
        }

        set
        {
            if (string.IsNullOrEmpty(value))
                return;

            int argbValue;
            if (int.TryParse(value, out argbValue))
                AppointmentColorPicker.SelectedColor = Color.FromArgb(argbValue);
        }
    }
    //[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    //public object RoomID
    //{
    //    get
    //    {
    //        return ResRoom.Value;
    //    }

    //    set
    //    {
    //        ResRoom.Value = value;
    //    }
    //}

    //[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    //public object UserID
    //{
    //    get
    //    {
    //        return ResUser.Value;
    //    }

    //    set
    //    {
    //        ResUser.Value = value;
    //    }
    //}

    #endregion

    #region Public properties

    public AdvancedFormMode Mode
    {
        get
        {
            return mode;
        }
        set
        {
            mode = value;
        }
    }

    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public string Subject
    {
        get
        {
            return SubjectText.Text;
        }

        set
        {
            SubjectText.Text = value;
        }
    }

    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public DateTime Start
    {
        get
        {
            DateTime result = StartDate.SelectedDate.Value.Date;

            if (AllDayEvent.Checked)
            {
                result = result.Date;
            }
            else
            {
                TimeSpan time = StartTime.SelectedDate.Value.TimeOfDay;
                result = result.Add(time);
            }

            return Owner.DisplayToUtc(result);
        }

        set
        {
            StartDate.SelectedDate = Owner.UtcToDisplay(value);
            StartTime.SelectedDate = Owner.UtcToDisplay(value);
        }
    }

    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public DateTime End
    {
        get
        {
            DateTime result = EndDate.SelectedDate.Value.Date;

            if (AllDayEvent.Checked)
            {
                result = result.Date.AddDays(1);
            }
            else
            {
                TimeSpan time = EndTime.SelectedDate.Value.TimeOfDay;
                result = result.Add(time);
            }

            return Owner.DisplayToUtc(result);
        }

        set
        {
            EndDate.SelectedDate = Owner.UtcToDisplay(value);
            EndTime.SelectedDate = Owner.UtcToDisplay(value);
        }
    }


    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public string RecurrenceRuleText
    {
        get
        {
            if (Owner.RecurrenceSupport)
            {
                bool dateSpecified = StartDate.SelectedDate.HasValue && EndDate.SelectedDate.HasValue;
                bool timeSpecified = StartTime.SelectedDate.HasValue && EndTime.SelectedDate.HasValue;

                if ((AllDayEvent.Checked && !dateSpecified) ||
                    (!AllDayEvent.Checked && !(dateSpecified && timeSpecified)))
                {
                    return string.Empty;
                }

                AppointmentRecurrenceEditor.StartDate = Start;
                AppointmentRecurrenceEditor.EndDate = End;

                RecurrenceRule rrule = AppointmentRecurrenceEditor.RecurrenceRule;

                if (rrule == null)
                {
                    return string.Empty;
                }

                RecurrenceRule originalRule;
                if (RecurrenceRule.TryParse(OriginalRecurrenceRule.Value, out originalRule))
                {
                    rrule.Exceptions = originalRule.Exceptions;
                }

                if (rrule.Range.RecursUntil != DateTime.MaxValue)
                {
                    rrule.Range.RecursUntil = Owner.DisplayToUtc(rrule.Range.RecursUntil);

                    if (!AllDayEvent.Checked)
                    {
                        rrule.Range.RecursUntil = rrule.Range.RecursUntil.AddDays(1);
                    }
                }

                return rrule.ToString();
            }

            return string.Empty;
        }

        set
        {
            RecurrenceRule rrule;
            RecurrenceRule.TryParse(value, out rrule);

            if (rrule != null)
            {
                if (rrule.Range.RecursUntil != DateTime.MaxValue)
                {
                    DateTime recursUntil = Owner.UtcToDisplay(rrule.Range.RecursUntil);

                    if (!IsAllDayAppointment(Appointment))
                    {
                        recursUntil = recursUntil.AddDays(-1);
                    }

                    rrule.Range.RecursUntil = recursUntil;
                }

                AppointmentRecurrenceEditor.RecurrenceRule = rrule;

                OriginalRecurrenceRule.Value = value;
            }
        }
    }

    //[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    //public string Reminder
    //{
    //    get
    //    {
    //        if (Owner.RemindersSupport && ReminderDropDown.SelectedValue != string.Empty)
    //        {
    //            return ReminderDropDown.SelectedValue;
    //        }

    //        return string.Empty;
    //    }

    //    set
    //    {
    //        RadComboBoxItem item = ReminderDropDown.Items.FindItemByValue(value);
    //        if (item != null)
    //        {
    //            item.Selected = true;
    //        }
    //    }
    //}

    //[Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    //public string TimeZoneID
    //{
    //    get
    //    {
    //        return TimeZonesDropDown.SelectedValue;
    //    }

    //    set
    //    {

    //        RadComboBoxItem item = TimeZonesDropDown.Items.FindItemByValue(value);
    //        if (item != null)
    //        {
    //            item.Selected = true;
    //        }
    //    }
    //}

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        UpdateButton.ValidationGroup = Owner.ValidationGroup;
        UpdateButton.CommandName = Mode == AdvancedFormMode.Edit ? "Update" : "Insert";
        SubjectText.LabelWidth = Unit.Empty;
        //DescriptionText.LabelWidth = Unit.Empty;
        //if (Owner.AdvancedForm.EnableTimeZonesEditing)
        //    PopulateTimeZonesDropDown();
        //else
        //    TimeZonesDropDown.Visible = false;

        //if (!Owner.Reminders.Enabled)
            //ReminderDropDown.Visible = false;

        InitializeStrings();
        InitializeRecurrenceEditor();

        if (!FormInitialized)
        {
            UpdateResetExceptionsVisibility();
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!FormInitialized)
        {
            if (IsAllDayAppointment(Appointment))
            {
                EndDate.SelectedDate = EndDate.SelectedDate.Value.AddDays(-1);
            }

            FormInitialized = true;
        }

        //if (String.IsNullOrEmpty(Appointment.TimeZoneID))
        //    TimeZoneID = Owner.TimeZonesProvider.OperationTimeZone.TimeZoneId;
        //else
        //    TimeZoneID = Appointment.TimeZoneID;
    }

    //private void PopulateTimeZonesDropDown()
    //{
    //    TimeZonesDropDown.DataSource = Owner.TimeZonesProvider.GetAllTimeZones();
    //    TimeZonesDropDown.DataTextField = "DisplayName";
    //    TimeZonesDropDown.DataValueField = "Id";
    //}

    protected void BasicControlsPanel_DataBinding(object sender, EventArgs e)
    {
        AllDayEvent.Checked = IsAllDayAppointment(Appointment);
    }

    protected void DurationValidator_OnServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = (End - Start) > TimeSpan.Zero;
    }

    protected void ResetExceptions_OnClick(object sender, EventArgs e)
    {
        Owner.RemoveRecurrenceExceptions(Appointment);
        OriginalRecurrenceRule.Value = Appointment.RecurrenceRule;
        ResetExceptions.Text = Owner.Localization.AdvancedDone;
    }

    #region Private methods

    private void InitializeStrings()
    {
        SubjectValidator.ErrorMessage = Owner.Localization.AdvancedSubjectRequired;
        SubjectValidator.ValidationGroup = Owner.ValidationGroup;

        AllDayEvent.Text = Owner.Localization.AdvancedAllDayEvent;

        StartDateValidator.ErrorMessage = Owner.Localization.AdvancedStartDateRequired;
        StartDateValidator.ValidationGroup = Owner.ValidationGroup;

        StartTimeValidator.ErrorMessage = Owner.Localization.AdvancedStartTimeRequired;
        StartTimeValidator.ValidationGroup = Owner.ValidationGroup;

        EndDateValidator.ErrorMessage = Owner.Localization.AdvancedEndDateRequired;
        EndDateValidator.ValidationGroup = Owner.ValidationGroup;

        EndTimeValidator.ErrorMessage = Owner.Localization.AdvancedEndTimeRequired;
        EndTimeValidator.ValidationGroup = Owner.ValidationGroup;

        DurationValidator.ErrorMessage = Owner.Localization.AdvancedStartTimeBeforeEndTime;
        DurationValidator.ValidationGroup = Owner.ValidationGroup;

        ResetExceptions.Text = Owner.Localization.AdvancedReset;

        SharedCalendar.FastNavigationSettings.OkButtonCaption = Owner.Localization.AdvancedCalendarOK;
        SharedCalendar.FastNavigationSettings.CancelButtonCaption = Owner.Localization.AdvancedCalendarCancel;
        SharedCalendar.FastNavigationSettings.TodayButtonCaption = Owner.Localization.AdvancedCalendarToday;
    }

    private void InitializeRecurrenceEditor()
    {
        AppointmentRecurrenceEditor.SharedCalendar = SharedCalendar;
        AppointmentRecurrenceEditor.Culture = Owner.Culture;
        AppointmentRecurrenceEditor.StartDate = Appointment.Start;
        AppointmentRecurrenceEditor.EndDate = Appointment.End;
    }

    private void UpdateResetExceptionsVisibility()
    {
        // Render the reset exceptions checkbox when using web service binding
        if (string.IsNullOrEmpty(Owner.WebServiceSettings.Path))
        {
            ResetExceptions.Visible = false;
            RecurrenceRule rrule;
            if (RecurrenceRule.TryParse(Appointment.RecurrenceRule, out rrule))
            {
                ResetExceptions.Visible = rrule.Exceptions.Count > 0;
            }
        }
    }

    private bool IsAllDayAppointment(Appointment appointment)
    {
        DateTime displayStart = Owner.UtcToDisplay(appointment.Start);
        DateTime displayEnd = Owner.UtcToDisplay(appointment.End);
        return displayStart.CompareTo(displayStart.Date) == 0 && displayEnd.CompareTo(displayEnd.Date) == 0;
    }

    #endregion
}