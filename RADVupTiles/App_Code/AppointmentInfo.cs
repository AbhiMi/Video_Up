using System;
using System.Collections.Generic;
using System.Web;
using Telerik.Web.UI;

public class AppointmentInfo
{
    private readonly string _id;
    private string _subject;
    private DateTime _start;
    private DateTime _end;
    private string _recurrenceRule;
    private string _recurrenceParentId;

    public string ID
    {
        get { return _id; }
    }

    public string Subject
    {
        get { return _subject; }
        set { _subject = value; }
    }

    public DateTime Start
    {
        get { return _start; }
        set { _start = value; }
    }

    public DateTime End
    {
        get { return _end; }
        set { _end = value; }
    }

    public string RecurrenceRule
    {
        get { return _recurrenceRule; }
        set { _recurrenceRule = value; }
    }

    public string RecurrenceParentID
    {
        get { return _recurrenceParentId; }
        set { _recurrenceParentId = value; }
    }

    private AppointmentInfo()
    {
        _id = Guid.NewGuid().ToString();
    }

    public AppointmentInfo(string subject, DateTime start, DateTime end,
        string recurrenceRule, string recurrenceParentID)
        : this()
    {
        _subject = subject;
        _start = start;
        _end = end;
        _recurrenceRule = recurrenceRule;
        _recurrenceParentId = recurrenceParentID;
    }

    public AppointmentInfo(Appointment source)
        : this()
    {
        CopyInfo(source);
    }

    public void CopyInfo(Appointment source)
    {
        Subject = source.Subject;
        Start = source.Start;
        End = source.End;
        RecurrenceRule = source.RecurrenceRule;
        if (source.RecurrenceParentID != null)
        {
            RecurrenceParentID = source.RecurrenceParentID.ToString();
        }
    }
}
