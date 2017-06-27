<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleCampaign.aspx.cs" Inherits="Pages_ScheduleCampaign" %>

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

    <script type="text/javascript">
        function SaveDate() {
            var raddropdownlist = $find('ddlChannel');
            var selecteditem = raddropdownlist.get_selectedItem().get_value();
            var date1 = $find('RadDateTimePicker1').get_selectedDate().format("yyyy/MM/dd");
            var date2 = $find('RadDateTimePicker2').get_selectedDate().format("yyyy/MM/dd");

     <%--       var date1 = document.getElementById('<%=RadDateTimePicker1.ClientID%>');
            var date2 = document.getElementById('<%=RadDateTimePicker2.ClientID%>');--%>
            $.ajax({
                type: "POST",
                url: "ScheduleCampaign.aspx/CheckExistData",
                data: '{channel:"' + selecteditem + '",date1: "' + date1 + '",date2:"' + date2 + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            if (response.d) {
                if (confirm("The Selected date already scheduled.Do you want to save the same date?")) {
                    $("#editButton").click();
                }
                else {

                }
            }
            else {
                $("#editButton").click();
            }
            // alert(response.d);
        }
    </script>


    <link href="../css/AssociationStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="example">

            <telerik:RadScriptManager runat="server" ID="RadSciptManager1" />
            <div id="window">
                <ul class="fieldlist">
                    <li>
                        <label for="campaignddl">Channel</label>
                        <telerik:RadDropDownList ID="ddlChannel" runat="server" CssClass="k-dropdown-wrap k-state-default" />
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
                <div style="margin-top: 20px">
                    <input id="btnsave" type="button" value="Save" class="button" onclick="SaveDate()" /><br />
                    <asp:Button runat="server" ID="editButton" OnClick="editButton_Click" CssClass="hide" />
                    <asp:HiddenField ID="hdnField" runat="server" Value="0" />
                </div>
                <style>
                    .hide {
                        display: none;
                    }

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
            <asp:Label runat="server" ID="lbl1" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
