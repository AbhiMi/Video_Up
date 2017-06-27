<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleChannel.aspx.cs" Inherits="Pages_Create_ScheduleChannel" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/kendo.common.min.css" rel="stylesheet" />
    <link href="../css/kendo.default.min.css" rel="stylesheet" />
    <link href="../css/kendo.rtl.min.css" rel="stylesheet" />
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="../js/kendo.all.min.js"></script>
    <script runat="server">    
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.hdnField.Value = this.Request.QueryString.Get("p");         
        }    
    </script>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="example">
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
            <div id="window">
                <ul class="fieldlist">
                    <li>
                        <label for="campaignddl">Campaign</label>
                        <telerik:RadDropDownList ID="ddlCampaign" runat="server" CssClass="k-dropdown-wrap k-state-default" />
                    </li>
                    <li>
                        <label for="datetimepicker1">Start Time</label>
                        <telerik:RadDateTimePicker ID="RadDateTimePicker1" runat="server">
                        </telerik:RadDateTimePicker>
                        <asp:HiddenField ID="hdndtpicker1" runat="server" />
                    </li>
                    <li>
                        <label for="datetimepicker2">End Time</label>
                        <telerik:RadDateTimePicker ID="RadDateTimePicker2" runat="server">
                        </telerik:RadDateTimePicker>
                        <asp:HiddenField ID="hdndtpicker2" runat="server" />
                    </li>
                    <li>
                        <asp:CheckBox ID="chkBox" runat="server" for="isAllDay" CssClass="floatLeft" />
                        <label id="lblchkText" for="chkBox">Run All Day</label>
                    </li>
                </ul>
                <div style="margin-top: 70px">
                    <asp:Button runat="server" ID="editButton" Text="Save" OnClick="editButton_Click" CssClass="button" />
                    <asp:HiddenField ID="hdnField" runat="server" />
                </div>
                <style>
                    .floatLeft {
                        float: left;
                    }

                    .fieldlist {
                        margin: 0 0 -2em;
                        padding: 0;
                    }

                        .fieldlist li {
                            list-style: none;
                            padding-bottom: 1em;
                        }

                        .fieldlist label, .fieldlist checkbox {
                            display: block;
                            padding-bottom: 1em;
                            font-weight: bold;
                            font-size: 12px;
                            color: #444;
                            font-family: 'Carrois Gothic SC', sans-serif;
                        }
                </style>
            </div>            
        </div>
    </form>
</body>
</html>