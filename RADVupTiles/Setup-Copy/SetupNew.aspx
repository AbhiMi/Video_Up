<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="SetupNew.aspx.cs" Inherits="SetupNew" %>

<%--<%@ Register TagPrefix="put" Namespace="ParameterDemo" %>--%>

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
        //    $('#wizard').smartWizard({ transitionEffect: 'slide' });
        //});
    </script>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        div h3 {
            width: 140px;
            margin-top: -30px;
            margin-left: 50px;
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
            margin-top: -20px;
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
            /*background-color: #aaa;
            overflow: hidden;
            padding: 20px 20px 100px 20px;*/
            position: relative;
            margin-left: 375px;
            /*width: 400px;*/
            z-index: -1;
            margin-top: 10px;
        }

            .bg-text::after {
                color: #E0E0E0;
                /*color:#D8D8D8;*/
                content: attr(data-bg-text);
                display: block;
                font-size: 8rem;
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
            margin-top: -360px;
        }

        .rwzHorizontal .rwzBreadCrumb {
            margin-top: 350px !important;
        }

        .RadWizard .rwzContent {
            overflow: hidden !important;
            height: 650px !important;
            margin-top: -520px;
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
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
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
    <div style="width: 95%">
        <div style="float: left;" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 20px">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                    width="350" height="350   ">
                    <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                    <param name="movie" value="../../Swf/MissionControl.swf" />
                    <param name="quality" value="high" />
                    <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                    <embed src="../../Swf/MissionControl.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                        type="application/x-shockwave-flash" width="350px" height="350px" />
                </object>
                <div>
                    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                        <AjaxSettings>
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
                            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="rgRegions"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="rgArea"></telerik:AjaxUpdatedControl>
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
                            <%-- <telerik:AjaxSetting AjaxControlID="rgCompanies">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="Label1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="Label2"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>--%>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" CssClass="marginTop350">
                        <WizardSteps>
                            <telerik:RadWizardStep runat="server" Title="Manage Companies" ToolTip="" CssClass="loginStep" ActiveImageUrl="../img/done.png">
                                <div style="float: right; padding: 20px; margin-top: 150px; position: relative; background-repeat: repeat; height: 100%; width: 750px">
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
                                                </telerik:GridBoundColumn>
                                                 <telerik:GridBoundColumn DataField="NumOfLicenses" UniqueName="NumOfLicenses" HeaderText="# Licenses">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DateCreated" UniqueName="DateCreated" HeaderText="Date Created" ReadOnly="true">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="DateModified" UniqueName="DateModified" HeaderText="Date Modified" ReadOnly="true">
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
                            <telerik:RadWizardStep runat="server" Title="  1            Set Up" ToolTip="View RAD Device, region, area & stores." CssClass="loginStep" ActiveImageUrl="../img/done.png">
                                <div style="float: right; padding: 20px; margin-top: 150px; position: relative; background-repeat: repeat; height: 100%; width: 750px">
                                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                                        AutoPostBack="True" SelectedIndex="0">
                                        <Tabs>
                                            <telerik:RadTab TabIndex="1" PageViewID="pvRegions" Text="Regions" runat="server">
                                            </telerik:RadTab>
                                            <telerik:RadTab TabIndex="2" PageViewID="pvAreas" Text="Areas" runat="server">
                                            </telerik:RadTab>
                                            <telerik:RadTab TabIndex="3" PageViewID="pvStores" Text="Stores" runat="server">
                                            </telerik:RadTab>
                                            <telerik:RadTab TabIndex="4" PageViewID="pvRaddevices" Text="RADDevices" runat="server">
                                            </telerik:RadTab>
                                        </Tabs>
                                    </telerik:RadTabStrip>
                                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" RenderSelectedPageOnly="True"
                                        SelectedIndex="0">
                                        <telerik:RadPageView ID="pvRegions" runat="server">
                                            <div>
                                                <asp:Label ID="Label3" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#FF8080"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" EnableViewState="False" Font-Bold="True" ForeColor="#00C000"></asp:Label>
                                            </div>
                                            <telerik:RadGrid RenderMode="Lightweight" ID="rgRegions" DataSourceID="SqlDataSource2" AllowSorting="True"
                                                AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowAutomaticDeletes="true"
                                                PageSize="7" AllowPaging="True" runat="server" OnItemCreated="rgRegions_ItemCreated"
                                                OnItemDeleted="rgRegions_ItemDeleted" OnItemUpdated="rgRegions_ItemUpdated" OnItemInserted="rgRegions_ItemInserted">
                                                <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataSourceID="SqlDataSource2"
                                                    DataKeyNames="RegionID" AutoGenerateColumns="false" InsertItemDisplay="Top"
                                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <telerik:GridEditCommandColumn>
                                                        </telerik:GridEditCommandColumn>
                                                        <telerik:GridBoundColumn DataField="RegionID" UniqueName="RegionID" HeaderText="RegionID"
                                                            MaxLength="5" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="RegionName" UniqueName="RegionName" HeaderText="Region Name">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DateCreated" UniqueName="DateCreated" HeaderText="Date Created" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DateModified" UniqueName="DateModified" HeaderText="Date Modified" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <CommandItemSettings AddNewRecordText="Add New Region" AddNewRecordImageUrl="Images/AddRecord.png"></CommandItemSettings>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="pvAreas" runat="server">
                                            <telerik:RadGrid RenderMode="Lightweight" ID="rgArea" DataSourceID="SqlDataSource3" AllowSorting="True"
                                                AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowAutomaticDeletes="true"
                                                PageSize="7" AllowPaging="True" runat="server" OnItemCreated="rgArea_ItemCreated"
                                                OnItemDeleted="rgArea_ItemDeleted" OnItemUpdated="rgArea_ItemUpdated" OnItemInserted="rgArea_ItemInserted">
                                                <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataSourceID="SqlDataSource3"
                                                    DataKeyNames="AreaID" AutoGenerateColumns="false" InsertItemDisplay="Top"
                                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <telerik:GridEditCommandColumn>
                                                        </telerik:GridEditCommandColumn>
                                                        <telerik:GridBoundColumn DataField="AreaID" UniqueName="AreaID" HeaderText="AreaID"
                                                            MaxLength="5" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="AreaName" UniqueName="AreaName" HeaderText="Area Name">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="RegionName" UniqueName="RegionName" DataField="RegionID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegionName" runat="server">
                                                                         <%# DataBinder.Eval(Container.DataItem, "RegionName")%>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadDropDownList ID="ddlRegion" runat="server"  DataSourceID="SqlDataSource4"
                                                                    DataTextField="RegionName">
                                                                </telerik:RadDropDownList>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridBoundColumn DataField="DateCreated" UniqueName="DateCreated" HeaderText="Date Created" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DateModified" UniqueName="DateModified" HeaderText="Date Modified" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <CommandItemSettings AddNewRecordText="Add New Area" AddNewRecordImageUrl="Images/AddRecord.png"></CommandItemSettings>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="pvStores" runat="server">
                                            <telerik:RadGrid RenderMode="Lightweight" ID="rgStores" DataSourceID="SqlDataSource5" AllowSorting="True"
                                                AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowAutomaticDeletes="true"
                                                PageSize="7" AllowPaging="True" runat="server" OnItemCreated="rgStores_ItemCreated"
                                                OnItemDeleted="rgStores_ItemDeleted" OnItemUpdated="rgStores_ItemUpdated" OnItemInserted="rgStores_ItemInserted">
                                                <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataSourceID="SqlDataSource5"
                                                    DataKeyNames="AreaID" AutoGenerateColumns="false" InsertItemDisplay="Top"
                                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <telerik:GridEditCommandColumn>
                                                        </telerik:GridEditCommandColumn>
                                                        <telerik:GridBoundColumn DataField="StoreID" UniqueName="StoreID" HeaderText="StoreID"
                                                            MaxLength="5" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="StoreName" UniqueName="StoreName" HeaderText="Store Name">
                                                        </telerik:GridBoundColumn>
                                                         <telerik:GridBoundColumn DataField="Location" UniqueName="Location" HeaderText="Location">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="RegionName" UniqueName="RegionName" DataField="RegionID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRegionName" runat="server">
                                                                         <%# DataBinder.Eval(Container.DataItem, "RegionName")%>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadDropDownList ID="ddlRegion" runat="server"  DataSourceID="SqlDataSource4"
                                                                    DataTextField="RegionName">
                                                                </telerik:RadDropDownList>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                         <telerik:GridTemplateColumn HeaderText="Area" UniqueName="Area">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblArea" runat="server">
                                                                         <%# DataBinder.Eval(Container.DataItem, "AreaName")%>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadDropDownList ID="ddlArea" runat="server"  DataSourceID="SqlDataSource6"
                                                                    DataTextField="AreaName">
                                                                </telerik:RadDropDownList>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>

                                                        <telerik:GridBoundColumn DataField="DateCreated" UniqueName="DateCreated" HeaderText="Date Created" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DateModified" UniqueName="DateModified" HeaderText="Date Modified" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <CommandItemSettings AddNewRecordText="Add New Store" AddNewRecordImageUrl="Images/AddRecord.png"></CommandItemSettings>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </telerik:RadPageView>
                                        <telerik:RadPageView ID="pvRaddevices" runat="server">
                                            <telerik:RadGrid RenderMode="Lightweight" ID="rgRADDevices" DataSourceID="SqlDataSource7" AllowSorting="True"
                                                AllowAutomaticInserts="true" AllowAutomaticUpdates="true" AllowAutomaticDeletes="true"
                                                PageSize="7" AllowPaging="True" runat="server" OnItemCreated="rgRADDevices_ItemCreated"
                                                OnItemDeleted="rgRADDevices_ItemDeleted" OnItemUpdated="rgRADDevices_ItemUpdated" OnItemInserted="rgRADDevices_ItemInserted">
                                                <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                                <MasterTableView Width="100%" CommandItemDisplay="TopAndBottom" DataSourceID="SqlDataSource7"
                                                    DataKeyNames="RADDeviceID" AutoGenerateColumns="false" InsertItemDisplay="Top"
                                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <telerik:GridEditCommandColumn>
                                                        </telerik:GridEditCommandColumn>
                                                        <telerik:GridBoundColumn DataField="RADDeviceID" UniqueName="RADDeviceID" HeaderText="RADDeviceID"
                                                            MaxLength="5" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DeviceInfo" UniqueName="DeviceInfo" HeaderText="RADDevice Info">
                                                        </telerik:GridBoundColumn>
                                                         <telerik:GridBoundColumn DataField="Description" UniqueName="Description" HeaderText="Description">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="RADDeviceType" UniqueName="RADDeviceType" HeaderText="RADDevice Type">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Store Name" UniqueName="StoreName" DataField="StoreName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStoreName" runat="server">
                                                                         <%# DataBinder.Eval(Container.DataItem, "StoreName")%>
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <telerik:RadDropDownList ID="ddlStores" runat="server"  DataSourceID="SqlDataSource8"
                                                                    DataTextField="StoreName">
                                                                </telerik:RadDropDownList>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn DataField="DateCreated" UniqueName="DateCreated" HeaderText="Date Created" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="DateModified" UniqueName="DateModified" HeaderText="Date Modified" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                    <CommandItemSettings AddNewRecordText="Add New RADDevice" AddNewRecordImageUrl="Images/AddRecord.png"></CommandItemSettings>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </telerik:RadPageView>
                                    </telerik:RadMultiPage>
                                </div>
                            </telerik:RadWizardStep>
                        </WizardSteps>
                    </telerik:RadWizard>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        DeleteCommand="DELETE FROM [Regions] WHERE [RegionID] = @RegionID"
                        InsertCommand="INSERT INTO [Regions] ([RegionName],[CompanyID],[DateCreated]) VALUES (@RegionName, @CompanyID,GetDate())"
                        SelectCommand="SELECT [RegionID], [RegionName], [CompanyID],[DateCreated], [DateModified] FROM [Regions] WHERE [CompanyID] = @CompanyID"
                        UpdateCommand="UPDATE [Regions] SET [RegionName] = @RegionName, [DateModified] = GetDate() WHERE [RegionID] = @RegionID"
                        OnInserting="SqlDataSource2_Inserting">
                        <DeleteParameters>
                            <asp:Parameter Name="RegionID" Type="String"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="RegionName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="RegionName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="DateModified" />
                            <asp:Parameter Name="RegionID" Type="String"></asp:Parameter>
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:Parameter Name="CompanyID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        DeleteCommand="DELETE FROM [Company] WHERE [CompanyID] = @CompanyID"
                        InsertCommand="INSERT INTO [Company] ([CompanyName],[NumOfLicenses],[DateCreated]) VALUES (@CompanyName,@NumOfLicenses,GetDate())"
                        SelectCommand="SELECT [CompanyID], [CompanyName],[NumOfLicenses],[DateCreated], [DateModified] FROM [Company]"
                        UpdateCommand="UPDATE [Company] SET [CompanyName] = @CompanyName, [NumOfLicenses] = @NumOfLicenses, [DateModified] = GetDate() WHERE [CompanyID] = @CompanyID">
                        <DeleteParameters>
                            <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CompanyName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CompanyName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="DateModified" />
                            <asp:Parameter Name="CompanyID" Type="String"></asp:Parameter>
                        </UpdateParameters>
                       <SelectParameters>
                            <asp:Parameter Name="CompanyID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" OnInserting="SqlDataSource3_Inserting"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        DeleteCommand="DELETE FROM [Area] WHERE [AreaID] = @AreaID"
                        InsertCommand="INSERT INTO [Area] ([AreaName],[RegionID],[DateCreated]) VALUES (@AreaName, @RegionID,GetDate())"
                        SelectCommand="SELECT A.[AreaID], A.[AreaName], A.[RegionID],R.[RegionName],A.[DateCreated], A.[DateModified] FROM [Area] A INNER JOIN [Regions] R ON A.RegionID = R.RegionID"
                        UpdateCommand="UPDATE [Area] SET [AreaName] = @AreaName, [RegionID]= (SELECT TOP 1 FROM [Regions] WHERE RegionName = @RegioName WHERE CompanyID=@CompanyID),[DateModified] = GetDate() WHERE [AreaID] = @AreaID">
                        <DeleteParameters>
                            <asp:Parameter Name="AreaID" Type="String"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="AreaName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="AreaName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="RegioName" />
                            <asp:Parameter Name="CompanyID"></asp:Parameter>
                            <asp:Parameter Name="AreaID" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" OnInserting="SqlDataSource5_Inserting"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        DeleteCommand="DELETE FROM [Store] WHERE [StoreID] = @StoreID"
                        InsertCommand="INSERT INTO [Store] ([StoreName],[Location],[CompanyID],[RegionID],[AreaID],[DateCreated]) VALUES (@StoreName,@Location,@CompanyID,@RegionID,@AreaID,GetDate())"
                        SelectCommand="SELECT S.[StoreID], S.[StoreName], S.[Location],R.[RegionName],A.[AreaID],A.[AreaName], S.[DateCreated]FROM Store S INNER JOIN [Regions] R ON S.RegionID = R.RegionID INNER JOIN [Area] A ON A.AreaID = S.AreaID"
                        UpdateCommand="UPDATE [Store] SET [StoreName] = @StoreName, [Location] = @Location, [CompanyID] = @CompanyID,[RegionID]= (SELECT TOP 1 FROM [Regions] WHERE RegionName = @RegioName WHERE CompanyID=@CompanyID),[AreaID]= (SELECT TOP 1 FROM [Area] WHERE AreaName = @AreaName WHERE CompanyID=@CompanyID),[DateModified] = GetDate() WHERE [StoreID] = @StoreID">
                        <DeleteParameters>
                            <asp:Parameter Name="StoreID" Type="String"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="StoreName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="Location" Type="String"></asp:Parameter>
                            <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="AreaID" Type="Int32"></asp:Parameter>
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="StoreName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="Location" Type="String"></asp:Parameter>
                            <asp:Parameter Name="RegionID" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="AreaID" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="DateModified" />
                        </UpdateParameters>
                         <SelectParameters>
                            <asp:Parameter Name="CompanyID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        SelectCommand="SELECT [RegionID],[RegionName] FROM [Regions] WHERE CompanyID = @CompanyID" >
                         <SelectParameters>
                            <asp:Parameter Name="CompanyID" Type="String" />
                        </SelectParameters>
                   </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        SelectCommand="SELECT [AreaID], [AreaName] FROM [Area]" >
                   </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" OnInserting="SqlDataSource7_Inserting"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        DeleteCommand="DELETE FROM [RADDevice] WHERE [RADDeviceID] = @RADDeviceID"
                        InsertCommand="INSERT INTO [RADDevice] ([DeviceInfo],[Description],[CompanyID],[StoreID],[DateCreated]) VALUES (@DeviceInfo,@Description,@CompanyID,@StoreID,GetDate())"
                        SelectCommand="SELECT R.[RADDeviceID], R.[DeviceInfo], R.[Description], S.[StoreName], S.[DateCreated]FROM RADDevice R INNER JOIN [Store] S ON R.StoreID = s.StoreID WHERE R.CompanyID = @CompanyID"
                        UpdateCommand="UPDATE [RADDevice] SET [DeviceInfo] = @DeviceInfo, [Description] = @Description, [CompanyID] = @CompanyID,[StoreID]= (SELECT TOP 1 FROM [Store] WHERE StoreName = @StoreName WHERE CompanyID=@CompanyID) WHERE [RADDeviceID] = @RADDeviceID">
                        <DeleteParameters>
                            <asp:Parameter Name="RADDeviceID" Type="String"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="DeviceInfo" Type="String"></asp:Parameter>
                            <asp:Parameter Name="Description" Type="String"></asp:Parameter>
                            <asp:Parameter Name="CompanyID" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="StoreID" Type="Int32"></asp:Parameter>
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="DeviceInfo" Type="String"></asp:Parameter>
                            <asp:Parameter Name="Description" Type="String"></asp:Parameter>
                            <asp:Parameter Name="StoreID" Type="Int32"></asp:Parameter>
                            <asp:Parameter Name="DateModified" />
                        </UpdateParameters>
                         <SelectParameters>
                            <asp:Parameter Name="CompanyID" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource8" runat="server"
                        ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                        SelectCommand="SELECT [StoreID],[StoreName] FROM [Stores] WHERE CompanyID = @CompanyID" >
                         <SelectParameters>
                            <asp:Parameter Name="CompanyID" Type="String" />
                        </SelectParameters>
                   </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

