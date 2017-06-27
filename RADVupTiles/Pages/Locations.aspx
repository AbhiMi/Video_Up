<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="Locations.aspx.cs" Inherits="Pages_Locations" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../css/demo_style.css" rel="stylesheet" />
    <link href="../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../js/jquery-1.4.2.min.js"></script>
    <script src="../js/jquery.smartWizard-2.0.min.js"></script>
    <script src="../Scripts/jquery.autocomplete.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <link href='https://fonts.googleapis.com/css?family=Carrois+Gothic+SC' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <script type="text/javascript">
        function OnChange(name) {
            $.ajax({
                type: "POST",
                url: "SetupNew.aspx/CheckUserName",
                data: '{userName: "' + name.value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess(response) {
            alert(' ');
            var mesg = $("#mesg")[0];

            switch (response.d) {
                case "true":
                    mesg.style.color = "green";
                    mesg.innerHTML = "User Name Available";
                    break;
                case "false":
                    mesg.style.color = "red";
                    mesg.innerHTML = "User Name Already Exist";
                    break;
                case "error":
                    mesg.style.color = "red";
                    mesg.innerHTML = "Error occured";
                    break;
            }
        }
        $(function () {
            $("#AddNewRegion").dialog({
                modal: true,
                autoOpen: false,
                title: "Add New Region",
                width: 300,
                height: 150
            });
            $(".btnShow").click(function () {
                $('#AddNewRegion').dialog('open');
            });
        });
        function RefreshPage()//function in parent page
        {
            document.location.reload();
        }
        //function OnChange() {
        //    $("#mesg")[0].innerHTML = "";
        //}

    </script>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        #RadWindowWrapper_ctl00_body_RadLocationDialog {
            margin-top: 60px;
        }
        .button, fileUploaderBtn
        {
            padding:6px !important;
        }

        input[type=text] {
            width: 197px;
        }

        div h3 {
            width: 140px;
            margin-top: -30px;
            margin-left: 50px;
        }

        .RadGrid_Default {
            background: none !important;
            border: none !important;
        }

        .RadGrid .rgGroupPanel {
            height: 0px !important;
        }

        .underline {
            text-decoration: underline;
        }

        .label {
            font-style: normal;
        }

        .breadcrumb {
            min-height: 475px !important;
            margin-top: 350px !important;
            display: none;
        }

        #footer, #footer a {
            width: 100%;
        }

        #footer {
            top: 650px !important;
        }

        .FixedHeader {
            border: none;
            font-size: 1.1em;
            border-color: #ef7c31;
            background-color: #ef7c31;
            color: #FFFFFF;
        }

        .siteMapImage {
            float: left;
            margin-top: -35px;
            margin-left: 20px;
        }

        .SiteMap {
            float: right;
        }

        .lblTitle, .lblSelectedCampaign {
            margin-top: 40px;
            margin-left: 20px;
            color: #808080;
            font-size: 1.2975rem;
            font-weight: bold;
            text-transform: uppercase;
            font-family: 'Carrois Gothic SC', sans-serif;
            /*text-shadow:2px 2px 3px #808080;*/
        }

        .lblTitle {
            font-size: 2.2975rem;
        }

        .marginLeft415 {
            margin-left: 415px;
        }

        .leftNavigation {
            float: left;
            margin-top: 300px;
            margin-left: -390px;
            /*border: 3px solid gray;*/
            /*border-radius: 10px;*/
            width: 350px;
            padding: 20px 0px 10px 0px;
            background-color: lightgray;
            text-align: center;
        }

            .leftNavigation td {
                width: 350px;
            }

                .leftNavigation td:hover {
                    width: 350px;
                    background-color: #ef7c31;
                    color: #FFFFFF !important;
                    padding: 5px 0 5px 0px;
                }

            .leftNavigation a {
                /*text-shadow:2px 2px 3px #808080;*/
                margin-left: 10px;
                font-size: 1.125rem !important;
                font-family: 'Carrois Gothic SC', sans-serif;
                color: #808080 !important;
                width: 350px;
            }

                .leftNavigation a:active {
                    color: gray !important;
                }

                .leftNavigation a:hover {
                    font-weight: bold;
                    font-size: 1.2825rem !important;
                    text-transform: uppercase;
                    color: #FFFFFF !important;
                    text-decoration: none;
                }

        .sidebarActiveLink {
            color: #49494a;
        }

        .hidden {
            display: none;
        }

        .sideBar a:hover {
            background-color: #49494a;
        }

        .h3 {
            margin-top: -15px;
            width: 80%;
            margin-left: 30px;
        }

        .RADCycle {
            width: 350px;
            height: 350px;
            margin-left: 20px;
            margin-top: -70px;
        }

        #radList {
            position: relative;
        }

            #radList li {
                margin: 0;
                padding: 0;
                list-style: none;
                position: absolute;
            }

            #radList li, #radList a {
                height: 80px;
                display: block;
            }

        #designCampaign {
            left: 107px;
            top: 10px;
            width: 80px;
            /*background:url("../img/RADCycle_Home.gif") no-repeat 0 100px;*/
        }

            #designCampaign a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 450px -16px;
            }

        #uploadMedia {
            width: 80px;
            left: 215px;
            top: 60px;
        }

            #uploadMedia a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 953px -123px;
            }

        #customizePlaylist {
            left: 242px;
            top: 175px;
            width: 80px;
            background: url("../img/RADCycle_Home.gif") -530px -332px;
        }

            #customizePlaylist a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 901px -338px;
            }

        #previewCampaign {
            top: 270px;
            left: 170px;
            width: 80px;
        }

            #previewCampaign a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 1051px -522px;
            }

        #ScheduleChannel {
            top: 270px;
            left: 49px;
            width: 80px;
        }

            #ScheduleChannel a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 568px -519px;
            }

        #goLive {
            top: 175px;
            left: -26px;
            width: 80px;
        }

            #goLive a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 712px -333px;
            }

        #accessPerformance {
            top: 60px;
            left: 2px;
            width: 80px;
        }

            #accessPerformance a:hover {
                width: 180px;
                background: url("../img/RADCycle_Hover.gif") 667px -106px;
            }

        .bg-text {
        position: relative;
        margin-left: 500px;
        z-index: -1;
        margin-top: -60px;
        }
        .bg-text::after {
            color: #E0E0E0;
            /*color:#D8D8D8;*/
            content: attr(data-bg-text);
            display: block;
            font-size: 5rem;
            line-height: 0.5;
            position: absolute;
        }

        .swMain .stepContainer {
            width: 800px;
            height: 500px;
            margin-top: -370px;
        }

        .content {
            overflow-y: visible !important;
        }

        .RadGrid_Default .rgHeader, .RadGrid_Default .rgHoveredRow {
            background: none !important;
            background-color: #ef7c31 !important;
        }

            .RadGrid_Default .rgHeader, .RadGrid_Default .rgHeader a {
                font-weight: bold !important;
                color: #FFFFFF !important;
            }

        .RadGrid_Default .rgSelectedRow {
            background: none !important;
            background-color: #a4a4a6 !important;
        }

        .RadGrid_Default .rgMasterTable {
            font-size: 13px !important;
            font-family: Verdana, Arial, Helvetica, sans-serif !important;
        }

        .RadGrid_Default .rgGroupItem {
            background: none !important;
            background-color: #a4a4a6 !important;
            border-color: #a4a4a6 !important;
            color: #FFFFFF !important;
            font-weight: bold !important;
        }

        .RadWizard_Default.rwzVertical .rwzProgressBar {
            display: none;
        }

        .rwzHorizontal .rwzBreadCrumb {
            position: relative;
            display: block;
            /* float: left; */
            list-style: none;
            padding: 0px;
            margin: 5px 10px 0 0;
            border: 0px solid #CCCCCC;
            background: transparent;
            display: table;
            table-layout: fixed;
            margin-top: 330px !important;
            margin-left: -380px !important;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzLI {
            position: relative;
            display: block;
            margin: 0;
            padding: 0;
            padding-top: 1px;
            padding-bottom: 1px;
            border: 0px solid #E0E0E0;
            float: left;
            clear: both;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzLI {
            display: block;
            position: relative;
            float: left;
            margin: 0;
            padding: 1px;
            height: 45px;
            width: 335px !important;
            text-decoration: none;
            outline-style: none;
            line-height: 20px;
            color: #CCCCCC;
            background: #F8F8F8;
            border: 1px solid #CCC;
            cursor: text;
            display: block;
            float: left;
            text-align: left;
            padding: 5px;
            width: 70%;
            font: bold 16px Verdana, Arial, Helvetica, sans-serif;
            margin-bottom: 2px !important;
        }

        .RadWizard_Default.rwzVertical .rwzFirst.rwzSelected .rwzLink {
            border-top-right-radius: 5px !important;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzLink {
            background: none !important;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzSelected .rwzLink {
            background: none !important;
            border: none;
            background-image: none !important;
            -moz-border-radius: 5px !important;
            -webkit-border-radius: 5px !important;
            z-index: 99;
            position: relative;
        }

        .RadWizard_Default.rwzVertical .rwzFirst.rwzSelected, .RadWizard_Default .rwzBreadCrumb .rwzLI.rwzSelected {
            color: #F8F8F8 !important;
            background: #ef7c31 !important;
            border: 1px solid #ef7c31 !important;
            cursor: text !important;
            -moz-box-shadow: 1px 5px 10px #888 !important;
            -webkit-box-shadow: 1px 5px 10px #888 !important;
            box-shadow: 1px 5px 10px #888 !important;
        }

        .RadWizard .rwzBreadCrumb .rwzLI {
            padding: 1px !important;
            color: #CCCCCC !important;
            background: #F8F8F8 !important;
            border: 1px solid #CCC !important;
            cursor: text !important;
            -moz-border-radius: 5px !important;
            -webkit-border-radius: 5px !important;
        }

            .RadWizard .rwzBreadCrumb .rwzLI:visited {
                color: #FFF !important;
                background: #a4a4a6 !important;
                border: 1px solid #a4a4a6 !important;
            }


        .RadComboBox table {
            display: none;
        }

        .RadWizard_Default.rwzVertical .rwzFirst.rwzSelected, .RadWizard_Default.rwzVertical .rwzFirst.rwzSelected .rwzLink, .RadWizard_Default.rwzVertical .rwzLast.rwzSelected, .RadWizard_Default.rwzVertical .rwzLast.rwzSelected .rwzLink {
            color: #F8F8F8 !important;
            background: #ef7c31 !important;
            border: 1px solid #ef7c31 !important;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzSelected .rwzCallout {
            background-image: none !important;
            display: none !important;
        }

        .rwzHorizontal .rwzBreadCrumb .rwzCallout:before {
            background: none !important;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzCallout {
            background: none !important;
        }

        .RadWizard .rwzBreadCrumb .rwzImage {
            float: right;
        }

        .marginTop350 {
            /*margin-top: -360px;*/
        }

        .marginTop60 {
            margin-top: 60px;
        }

        .rwzHorizontal .rwzBreadCrumb {
            /*margin-top: 350px !important;*/
            width: 390px !important;
        }

        .RadWizard .rwzContent {
            overflow: hidden !important;
            height: 550px !important;
            margin-top: -480px;
            width: 850px !important;
        }

        .RadWizard_Default .rwzButton {
            display: block !important;
            float: right !important;
            margin: 5px 3px 0 3px !important;
            padding: 5px !important;
            text-decoration: none !important;
            text-align: center !important;
            font: bold 13px Verdana, Arial, Helvetica, sans-serif !important;
            width: 100px !important;
            color: #FFF !important;
            outline-style: none !important;
            background-color: #5A5655 !important;
            border: 1px solid #5A5655 !important;
            -moz-border-radius: 5px !important;
            -webkit-border-radius: 5px !important;
            background-image: none !important;
        }

        .openModal {
            margin-bottom: 10px;
            margin-top: 10px;
        }

        .RadWizard_Default.rwzHorizontal .rwzProgress, .RadWizard .rwzProgressBar {
            display: none;
            border: none !important;
            background: none !important;
        }

        .rwzHorizontal .rwzBreadCrumb, .rwzHorizontal .rwzProgressBar {
            margin-bottom: 0px !important;
        }

        .RadTabStrip_Default .rtsLI, .RadTabStrip_Default .rtsLink {
            font-weight: bold !important;
            color: #808080 !important;
        }

        .RadTabStrip_Default .rtsLevel .rtsLink.rtsSelected {
            color: #FFFFFF !important;
            background-color: #ef7c31 !important;
        }

        .RadTabStrip .rtsLevel .rtsSelected .rtsIn {
            background-color: #ef7c31 !important;
        }

        .RadGrid .rgActionButton .rgEdit, .RadGrid .rgEditIcon:before {
            /*content:none !important;
            background-image: url(Images/Edit.png) !important;*/
        }

        .FixedHeader {
            border: none;
            font-size: 1.1em;
            border-color: #ef7c31;
            background-color: #ef7c31;
        }

        .Grid {
            border: 1px solid #a0a0a0;
            background-color: #f2f2f2;
            font: normal 13px "Segoe UI",Arial,Helvetica,sans-serif;
        }

        .RadGrid_Default .rgRow a, .RadGrid_Default .rgAltRow a, .RadGrid_Default .rgFooter a, .RadGrid_Default .rgEditForm a, .RadGrid_Default .rgEditRow a, .RadGrid_Default .rgHoveredRow a {
            text-decoration: underline;
        }
        .RadGrid_Default .rgEditForm{
            background-color: rgba(233, 233, 233, 1) !important;
            left:245px !important
        }

        .RadWindow_Default {
            border-color: #ef7c31 !important;
            background-color:#ef7c31 !important;
        }
        .RadWindow_Default .rwTitleBar, .RadWindow.rwRoundedCorner .rwTitleBar {
        background-image: linear-gradient(#ef7c31,#ef7c31) !important;
    }
        h6.rwTitle {
        color: #FFFFFF !important;
    }
        .RadWindow .rwTitleWrapper .rwTitle{
            font-size:1.2em !important; 
        }
        .rwStatusBar {
    background-color: #ef7c31 !important;
    border-color: #ef7c31 !important;
}
        .RadWindow .rwStatusBar input{
            color:#FFFFFF !important;
        }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function ImportExportDialogOpen() {
                window.radopen("ImportExport.aspx", "RadImportExportDialog");
                return false;
            }
            function AddNewLocationOpen() {
                window.radopen("AddNewLocation.aspx", "RadLocationDialog");
                return false;
            }
            function AddNewRegionOpen() {
                window.radopen("AddNewRegion.aspx", "RadRegionDialog");
                return false;
            }
            function AddNewAreaOpen() {
                window.radopen("AddNewArea.aspx", "RadAreaDialog");
                return false;
            }
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }

            function InitialRADDeviceSetup() {
                window.radopen("InitialRADDeviceSetup.aspx", "RadDeviceDialog");
                return false;
            }
            function RowDblClick(sender, eventArgs) {
                //window.radopen("RADdeviceDialog.aspx?StoreID=" + eventArgs.getDataKeyValue("StoreID"), "UserListDialog");
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:HiddenField runat="server" ID="hdnCompnayID" Value="0" />
    <div class="bg-text" data-bg-text="Locations">
    </div>
    <table style="margin-left: 390px">
    </table>
    <div style="width: 95%; font-family: Segoe UI,Arial,Helvetica,sans-serif;">
        <div>
            <div style="float: left; margin: -20px 0 0 25px">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                    width="350" height="350   ">
                    <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                    <param name="movie" value="../../Swf/Setup.swf" />
                    <param name="quality" value="high" />
                    <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                    <embed src="../../Swf/Setup.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                        type="application/x-shockwave-flash" width="350px" height="350px" />
                </object>
            </div>
        </div>
        <div style="float: left; width: 65%" class="RADCycle">
            <div class="swMain" id="wizard">
                <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="rgLocations">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgLocations"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadWizard1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgRegions"></telerik:AjaxUpdatedControl>
                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgLocations"></telerik:AjaxUpdatedControl>
                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="Area"></telerik:AjaxUpdatedControl>
                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgCompanies"></telerik:AjaxUpdatedControl>
                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="rgRegions">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="Label3"></telerik:AjaxUpdatedControl>
                                <telerik:AjaxUpdatedControl ControlID="Label4"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <asp:Label runat="server" ID="lblmsg" ForeColor="Green" Font-Bold="true" />
                <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" CssClass="marginTop60"
                    DisplayNavigationButtons="false">
                    <WizardSteps>
                        <telerik:RadWizardStep Title="Locations" ToolTip="Locations">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px;">
                                <div style="float: left;">
                                    <table>
                                        <tr style="cursor: pointer;" onclick="AddNewLocationOpen()">
                                            <td style="width: 30px; height: 30px">
                                                <img src="../img/Add.png">
                                            </td>
                                            <td>
                                                <h1 style="color: #808080; font-size: 17px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="float: right;" onclick="">
                                    <table>
                                        <tr style="cursor: pointer;" onclick="ImportExportDialogOpen()">
                                            <td style="width: 30px; height: 30px">
                                                <img src="../img/ExcelIcon.png">
                                            </td>
                                            <td>
                                                <h1 style="color: #808080; font-size:17px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Import/Export</h1>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <telerik:RadGrid ID="rgLocation" runat="server" AllowPaging="True" AllowSorting="True"
                                    OnNeedDataSource="rgLocation_NeedDataSource" AllowFilteringByColumn="True" Width="850px"
                                    CellSpacing="0" GridLines="None" EnableTheming="true" ShowGroupPanel="True">
                                    <GroupingSettings CaseSensitive="false" ShowUnGroupButton="true" />
                                    <SelectedItemStyle BackColor="#a3a3a4" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle ForeColor="#FFFFFF" />
                                    <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed" GroupLoadMode="Client">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="LocationID" HeaderText="Location ID" UniqueName="LocationID"
                                                ColumnGroupName="LocationID" Visible="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="LocationName" HeaderText="Location Name" UniqueName="LocationName"
                                                ColumnGroupName="LocationName" FilterControlWidth="50px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Address" HeaderText="Address" UniqueName="Address"
                                                ColumnGroupName="Address" FilterControlWidth="50px">
                                                <ItemStyle Width="125px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Country" HeaderText="Country" UniqueName="Country"
                                                ColumnGroupName="Country" FilterControlWidth="50px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="State" HeaderText="State" UniqueName="State"
                                                ColumnGroupName="State" FilterControlWidth="50px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Zipcode" HeaderText="Zipcode" UniqueName="Zipcode"
                                                ColumnGroupName="Zipcode" FilterControlWidth="45px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AreaName" HeaderText="Area" UniqueName="Area"
                                                ColumnGroupName="Area" FilterControlWidth="45px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="RegionName" HeaderText="Region" UniqueName="Region"
                                                ColumnGroupName="Region" FilterControlWidth="45px">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CustomTags" HeaderText="Custom Tags" UniqueName="CustomTags"
                                                ColumnGroupName="CustomTags" FilterControlWidth="45px">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </div>
                        </telerik:RadWizardStep>
                        <telerik:RadWizardStep ID="Regions" Title="Regions" ToolTip="Regions" CssClass="loginStep">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px;">
                                <div>
                                    <table style="float:left">
                                        <tr style="cursor: pointer;" onclick="AddNewRegionOpen()">
                                            <td style="width: 30px; height: 30px">
                                                <img src="../img/Add.png">
                                            </td>
                                            <td>
                                                <h1 style="color: #808080; font-size: 17px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="float:right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnEditRegion" runat="server" Text="Edit" OnClick="btnEditRegion_Click" CssClass="button" /></td>
                                            <td>
                                                <asp:Button ID="btnDeleteRegion" runat="server" Text="Delete" OnClick="btnDeleteRegion_Click" CssClass="button" /></td>
                                        </tr>
                                    </table>
                                    <div>
                                        <telerik:RadGrid RenderMode="Lightweight" ID="rgRegion" runat="server" AllowPaging="false"
                                            AllowFilteringByColumn="true" EnableTheming="true" CellSpacing="0"
                                            GridLines="None" OnNeedDataSource="rgRegion_NeedDataSource" OnUpdateCommand="rgRegion_UpdateCommand">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                                                BorderWidth="1px" />
                                            <MasterTableView AutoGenerateColumns="false" DataKeyNames="RegionID" EditMode="PopUp">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="RegionID" HeaderText="Region ID" UniqueName="RegionID"
                                                        ColumnGroupName="RegionID" Visible="false" ReadOnly="true">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="RegionName" HeaderText="Region Name" UniqueName="RegionName"
                                                        ColumnGroupName="RegionName" FilterControlWidth="200px" >
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="Description"
                                                        ColumnGroupName="Description" FilterControlWidth="275px">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DateCreated" HeaderText="Date Created" UniqueName="DateCreated"
                                                        ColumnGroupName="DateCreated" FilterControlWidth="50px" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-HorizontalAlign="Center">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DateModified" HeaderText="Date Modified" UniqueName="DateModified"
                                                        ColumnGroupName="DateModified" FilterControlWidth="50px" ReadOnly="true" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-HorizontalAlign="Center">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="CompanyID" HeaderText="CompanyID" UniqueName="CompanyID"
                                                        ColumnGroupName="CompanyID" FilterControlWidth="45px" Visible="false" ReadOnly="true">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                        </telerik:RadWizardStep>
                        <telerik:RadWizardStep Title="Areas" ToolTip="Areas">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px;margin-top:-10px">
                                <div>
                                    <table style="float:left">
                                        <tr style="cursor: pointer;" onclick="AddNewAreaOpen()">
                                            <td style="width: 30px; height: 30px">
                                                <img src="../img/Add.png">
                                            </td>
                                            <td>
                                                <h1 style="color: #808080; font-size: 17px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="float:right;margin-top:20px">
                                        <tr>
                                            <td style="float:right">
                                                <asp:Button ID="btnEditArea" runat="server" Text="Edit" OnClick="btnEditArea_Click" CssClass="button" /></td>
                                            <td>
                                                <asp:Button ID="btnDeleteArea" runat="server" Text="Delete" OnClick="btnDeleteArea_Click" CssClass="button" /></td>
                                        </tr>
                                    </table>
                                    <telerik:RadGrid RenderMode="Lightweight" ID="rgArea" runat="server" AllowPaging="True" AllowFilteringByColumn="true" CellSpacing="0"
                                        GridLines="None" PageSize="10" OnNeedDataSource="rgArea_NeedDataSource" OnUpdateCommand="rgArea_UpdateCommand">
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="True" />
                                        </ClientSettings>
                                        <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                                            BorderWidth="1px" />
                                        <MasterTableView AutoGenerateColumns="false" DataKeyNames="AreaID">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="AreaID" HeaderText="Area ID" UniqueName="AreaID"
                                                    ColumnGroupName="AreaID" Visible="false" ReadOnly="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="AreaName" HeaderText="Area Name" UniqueName="AreaName"
                                                    ColumnGroupName="AreaName" FilterControlWidth="200px" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DateCreated" HeaderText="Date Created" UniqueName="DateCreated"
                                                    ColumnGroupName="DateCreated" FilterControlWidth="145px" ReadOnly="true" HeaderStyle-Width="200px" ItemStyle-Width="200px" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DateModified" HeaderText="Date Modified" UniqueName="DateModified"
                                                    ColumnGroupName="DateModified" FilterControlWidth="145px" ReadOnly="true" HeaderStyle-Width="200px" ItemStyle-Width="200px" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-HorizontalAlign="Center">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="RegionID" HeaderText="RegionID" UniqueName="RegionID"
                                                    ColumnGroupName="RegionID" FilterControlWidth="45px" Visible="false" ReadOnly="true">
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </div>
                            </div>
                        </telerik:RadWizardStep>
                        <telerik:RadWizardStep Title="Custom Tags" ToolTip="Custom Tags">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px">
                                TBD...
                            </div>
                        </telerik:RadWizardStep>
                    </WizardSteps>
                </telerik:RadWizard>
            </div>
        </div>
    </div>
    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadDeviceDialog" runat="server" Height="580px"
                Width="680px" Left="100px" ReloadOnShow="true" ShowContentDuringLoad="false" Behaviors="Close"
                Modal="true">
            </telerik:RadWindow>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadImportExportDialog" runat="server" Height="320px"
                Width="600px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false" OnClientClose="RefreshPage" Behaviors="Close"
                Modal="true">
            </telerik:RadWindow>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadLocationDialog" runat="server" Height="520px" Behaviors="Close"
                Width="600px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false" OnClientClose="RefreshPage"
                Modal="true">
            </telerik:RadWindow>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadRegionDialog" runat="server" Height="400px" Behaviors="Close"
                Width="600px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false" OnClientClose="RefreshPage"
                Modal="true">
            </telerik:RadWindow>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadAreaDialog" runat="server" Height="400px" Behaviors="Close"
                Width="600px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false" OnClientClose="RefreshPage"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>