<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="SetupNew.aspx.cs" Inherits="Pages_SetupNew" %>

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
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $('#SelectCompany').change(function () {
        //        alert('hiii'); // or $(this).val()
        //    });
        //});
    </script>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        #RadWindowWrapper_ctl00_body_RadLocationDialog {
            margin-top: 60px;
        }

        input[type=text] {
            width: 197px;
        }

        div h3 {
            width: 140px;
            margin-top: -30px;
            margin-left: 50px;
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
            margin-left: 700px;
            z-index: -1;
            margin-top: -65px;
        }

            .bg-text::after {
                color: #E0E0E0;
                /*color:#D8D8D8;*/
                content: attr(data-bg-text);
                display: block;
                font-size: 4.9rem;
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
            margin-top: 270px !important;
            margin-left: -370px !important;
        }

        .RadWizard_Default .rwzBreadCrumb .rwzLI {
            position: relative;
            display: block;
            margin: 0;
            padding: 0;
            padding-top: 3px;
            padding-bottom: 3px;
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
            margin-bottom: 5px !important;
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
            padding: 2px !important;
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
            margin-top: 90px;
        }

        .rwzHorizontal .rwzBreadCrumb {
            /*margin-top: 350px !important;*/
            width: 400px !important;
        }

        .RadWizard .rwzContent {
            overflow: hidden !important;
            height: 450px !important;
            margin-top: -450px;
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
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function locationDialogOpen() {
                //alert(1);
                var a = document.getElementById('<%= hdnCompnayID.ClientID%>').value;
                // window.radopen("Locations.aspx?CompanyID=" + a, "RadLocationDialog");
                window.radopen("Location.aspx?CompanyID=" + a, "RadLocationDialog");
                return false;
            }
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
            function GetSelectedRow(lnk) {
                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 2;
                window.radopen("RADdeviceDialog.aspx?StoreID=" + StoreID, "RadDeviceDialog");
                return false;
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
    <div class="bg-text" data-bg-text="Set Up">
    </div>
    <table style="margin-left: 390px">
        <tr>
            <%--  <td>
                <asp:Image ID="imgDesignCampaign" runat="server" ImageUrl="~/img/DC.gif" Width="100px" Height="100px" CssClass="marginLeft415" />
            </td>--%>
            <td>
                <asp:Label ID="lblTitle" runat="server" CssClass="lblTitle" />
                <asp:Label ID="lblSelectedCampaign" runat="server" Text="" CssClass="lblSelectedCampaign" Visible="false" />
            </td>
        </tr>
    </table>
    <div style="width: 95%; font-family: Segoe UI,Arial,Helvetica,sans-serif;">
        <div style="float: left; margin: -40px 0 0 25px">
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
        <div style="float: left; width: 65%" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 20px">
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="rgCompanies">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="rgCompanies"></telerik:AjaxUpdatedControl>
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadWizard1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadTabStrip1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadTabStrip1" />
                                <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadMultiPage1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadTabStrip1" />
                                <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadTabStrip2">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadTabStrip2" />
                                <telerik:AjaxUpdatedControl ControlID="RadMultiPage2" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadMultiPage2">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadTabStrip2" />
                                <telerik:AjaxUpdatedControl ControlID="RadMultiPage2" />
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
                                <telerik:AjaxUpdatedControl ControlID="rgRADDevices"></telerik:AjaxUpdatedControl>
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
                <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" CssClass="marginTop60" DisplayNavigationButtons="false">
                    <WizardSteps>
                        <telerik:RadWizardStep runat="server" Title="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Manage Companies" ToolTip="" ID="radStepCompany" CssClass="loginStep">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px;margin-top:50px">
                                <telerik:RadGrid RenderMode="Lightweight" ID="rgCompanies" DataSourceID="SqlDataSource1" AllowSorting="True"
                                    AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowAutomaticDeletes="true"
                                    PageSize="7" AllowPaging="True" runat="server" OnItemCreated="rgCompany_ItemCreated"
                                    OnItemDeleted="rgRegions_ItemDeleted" OnItemUpdated="rgRegions_ItemUpdated" OnItemInserted="rgRegions_ItemInserted">
                                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                    <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataSourceID="SqlDataSource1"
                                        DataKeyNames="CompanyID" AutoGenerateColumns="false" InsertItemDisplay="Top"
                                        InsertItemPageIndexAction="ShowItemOnFirstPage">
                                        <Columns>
                                            <telerik:GridEditCommandColumn>
                                            </telerik:GridEditCommandColumn>
                                            <telerik:GridBoundColumn DataField="CompanyID" UniqueName="CompanyID" HeaderText="CompanyID"
                                                MaxLength="5" ReadOnly="true">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CompanyName" UniqueName="CompanyName" HeaderText="Company Name">
                                                <%-- <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                                    <RequiredFieldValidator ForeColor="Red" ErrorMessage="Company Name is required"></RequiredFieldValidator>
                                                    <ModelErrorMessage BackColor="Red" />
                                                </ColumnValidationSettings>--%>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumOfLicenses" UniqueName="NumOfLicenses" HeaderText="# Licenses">
                                                <%-- <ColumnValidationSettings EnableRequiredFieldValidation="true" EnableModelErrorMessageValidation="true">
                                                    <RequiredFieldValidator ForeColor="Red" ErrorMessage="Number Of Licenses is required"></RequiredFieldValidator>
                                                    <ModelErrorMessage BackColor="Red" />
                                                </ColumnValidationSettings>--%>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DateCreated" UniqueName="DateCreated" DataFormatString="{0: dd-MMM-yy}" HeaderText="Date Created" ReadOnly="true">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DateModified" UniqueName="DateModified" DataFormatString="{0: dd-MMM-yy}" HeaderText="Date Modified" ReadOnly="true">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                        <CommandItemSettings AddNewRecordText="Add New Company" AddNewRecordImageUrl="Images/AddRecord.png"></CommandItemSettings>
                                    </MasterTableView>
                                    <ClientSettings>
                                        <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </telerik:RadWizardStep>
                        <telerik:RadWizardStep Title="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Setup RAD Device" ToolTip="RAD Device Configuration Setup">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px;margin-top:50px">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Wireless Name (SSID)"></asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtConnectionName" Width="282px" />
                                            <%-- <telerik:RadComboBox RenderMode="Lightweight" ID="lstNetworks" runat="server" Width="305"
                                                ChangeTextOnKeyBoardNavigation="false">
                                            </telerik:RadComboBox>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblConnType" runat="server" Text="Connection Type"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadDropDownList runat="server" ID="ddlConnType" RenderMode="Lightweight" Width="305">
                                                <Items>
                                                    <telerik:DropDownListItem runat="server" Text="WiFi" />
                                                    <telerik:DropDownListItem runat="server" Text="Ethernet" />
                                                </Items>

                                            </telerik:RadDropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
                                        <td>
                                            <telerik:RadTextBox ID="networkPassword" RenderMode="Lightweight" Width="305" runat="server"></telerik:RadTextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Company Encrypted ID:"></asp:Label></td>
                                        <td>
                                            <telerik:RadTextBox ID="companyPass" ReadOnly="true" RenderMode="Lightweight" Width="305" runat="server"></telerik:RadTextBox></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <telerik:RadButton ID="btnGenerateConfig" Text="Generate Config" runat="server" OnClick="btnGenerateConfig_Click"></telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </telerik:RadWizardStep>
                    </WizardSteps>
                </telerik:RadWizard>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    DeleteCommand="DELETE FROM [Regions] WHERE [RegionID] = @RegionID AND ISDEFAULT is null"
                    InsertCommand="INSERT INTO [Regions] ([RegionName],[CompanyID],[DateCreated]) VALUES (@RegionName, @CompanyID,GetDate())"
                    SelectCommand="SELECT [RegionID], [RegionName], R.[CompanyID],C.[CompanyName],R.[DateCreated], R.[DateModified] FROM [Regions] R INNER JOIN [Company] C ON R.CompanyID = C.CompanyID WHERE R.[CompanyID] = @CompanyID"
                    UpdateCommand="UPDATE [Regions] SET [RegionName] = @RegionName, [DateModified] = GetDate() WHERE [RegionID] = @RegionID"
                    OnInserting="SqlDataSource2_Inserting">
                    <DeleteParameters>
                        <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="RegionName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="RegionName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="DateModified" />
                        <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" InsertCommandType="StoredProcedure"
                    DeleteCommand="DELETE FROM [Company] WHERE [CompanyID] = @CompanyID"
                    InsertCommand="SP_CompanyDataInsert"
                    SelectCommand="SELECT [CompanyID], [CompanyName],[NumOfLicenses],[DateCreated], [DateModified] FROM [Company]"
                    UpdateCommand="UPDATE [Company] SET [CompanyName] = @CompanyName, [NumOfLicenses] = @NumOfLicenses, [DateModified] = GetDate() WHERE [CompanyID] = @CompanyID">
                    <DeleteParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CompanyName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="NumOfLicenses" Type="Int32"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CompanyName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="NumOfLicenses" />
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" OnInserting="SqlDataSource3_InsertingAndUpdating" OnUpdating="SqlDataSource3_InsertingAndUpdating"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    DeleteCommand="DELETE FROM [Area] WHERE [AreaID] = @AreaID AND ISDEFAULT is null"
                    InsertCommand="INSERT INTO [Area] ([AreaName],[RegionID],[DateCreated]) VALUES (@AreaName, @RegionID,GetDate())"
                    SelectCommand="SELECT A.[AreaID], A.[AreaName], A.[RegionID],R.[RegionName],A.[DateCreated], A.[DateModified] FROM [Area] A INNER JOIN [Regions] R ON A.RegionID = R.RegionID WHERE A.[CompanyID] = @CompanyID"
                    UpdateCommand="UPDATE [Area] SET [AreaName] = @AreaName, [RegionID]= @RegionID,[DateModified] = GetDate() WHERE [AreaID] = @AreaID">
                    <DeleteParameters>
                        <asp:Parameter Name="AreaID" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="AreaName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="AreaName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RegionID" Type="Int32" />
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="AreaID" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" OnInserting="SqlDataSource5_Inserting" OnUpdating="SqlDataSource5_Updating"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    DeleteCommand="DELETE FROM [Store] WHERE [StoreID] = @StoreID AND ISDEFAULT is null"
                    InsertCommand="INSERT INTO [Store] ([StoreName],[Location],[CompanyID],[RegionID],[AreaID],[DateCreated]) VALUES (@StoreName,@Location,@CompanyID,@RegionID,@AreaID,GetDate())"
                    SelectCommand="SELECT S.[StoreID],Count(RD.RADDeviceID) as RADDeviceID ,S.[StoreName], S.[Location],R.[RegionName],A.[AreaID],A.[AreaName], S.[DateCreated] FROM   Store S INNER JOIN [Regions] R ON S.RegionID = R.RegionID  INNER JOIN [Area] A ON A.AreaID = S.AreaID inner join  RADDevice RD on s.StoreID= RD.StoreID WHERE s.[CompanyID] = @CompanyID group by S.StoreID,S.[StoreName], S.[Location],R.[RegionName],A.[AreaID],A.[AreaName], S.[DateCreated] order by  S.[StoreID]"
                    UpdateCommand="UPDATE [Store] SET [StoreName] = @StoreName, [Location] = @Location, [CompanyID] = @CompanyID,[RegionID]= @RegionID,[AreaID]= @AreaID,[DateModified] = GetDate() WHERE [StoreID] = @StoreID">
                    <DeleteParameters>
                        <asp:Parameter Name="StoreID" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="StoreName" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Location" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="AreaID" Type="Int32"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="StoreID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="Location" Type="String"></asp:Parameter>
                        <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="AreaID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="DateModified" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                        <%--<asp:QueryStringParameter Name="StoreID" QueryStringField="StoreID" Type="Int32" />--%>
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="SELECT [RegionID],[RegionName] FROM [Regions] WHERE CompanyID = @CompanyID">
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="SELECT [AreaID], [AreaName] FROM [Area]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource7" runat="server" OnInserting="SqlDataSource7_InsertingAndUpdateting" OnUpdating="SqlDataSource7_InsertingAndUpdateting"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" InsertCommandType="StoredProcedure"
                    DeleteCommand="DELETE FROM [RADDevice] WHERE [RADDeviceID] = @RADDeviceID AND ISDEFAULT is null"
                    InsertCommand="SP_RADDeviceInsert"
                    SelectCommand="SELECT R.[RADDeviceID], R.[DeviceInfo],ISNULL(R.[IsDefault],0) as IsDefault, R.[Description],R.RADDeviceType, S.[StoreName], S.[DateCreated]FROM RADDevice R INNER JOIN [Store] S ON R.StoreID = s.StoreID WHERE R.CompanyID = @CompanyID"
                    UpdateCommand="UPDATE [RADDevice] SET [DeviceInfo] = @DeviceInfo, [Description] = @Description, [CompanyID] = @CompanyID,[StoreID]= @StoreID,DateModified=GetDate(),RADDeviceType=@RADDeviceType WHERE [RADDeviceID] = @RADDeviceID">
                    <DeleteParameters>
                        <asp:Parameter Name="RADDeviceID" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="DeviceInfo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Description" Type="String"></asp:Parameter>
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="StoreID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="RADDeviceType" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="DeviceInfo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="Description" Type="String"></asp:Parameter>
                        <asp:Parameter Name="StoreID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="RADDeviceType" Type="String"></asp:Parameter>
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource8" runat="server"
                    ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                    SelectCommand="SELECT [StoreID],[StoreName] FROM [Store] WHERE CompanyID = @CompanyID">
                    <SelectParameters>
                        <asp:Parameter Name="CompanyID" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
                    <Windows>
                        <telerik:RadWindow RenderMode="Lightweight" ID="RadDeviceDialog" runat="server" Height="580px"
                            Width="680px" Left="100px" ReloadOnShow="true" ShowContentDuringLoad="false"
                            Modal="true">
                        </telerik:RadWindow>
                        <telerik:RadWindow RenderMode="Lightweight" ID="RadLocationDialog" runat="server" Height="700px"
                            Width="1000px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false"
                            Modal="true">
                        </telerik:RadWindow>

                    </Windows>
                </telerik:RadWindowManager>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

