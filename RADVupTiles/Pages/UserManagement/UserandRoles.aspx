﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="UserandRoles.aspx.cs" Inherits="Pages_UserManagement_UserandRoles" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <link href="../../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../../css/demo_style.css" rel="stylesheet" />
    <link href="../../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    <script src="../../js/jquery-1.4.2.min.js"></script>
    <script src="../../js/jquery.smartWizard-2.0.min.js"></script>
    <script src="../../Scripts/jquery.autocomplete.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    <link href='https://fonts.googleapis.com/css?family=Carrois+Gothic+SC' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.autocomplete.js"></script>
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
            top: 750px !important;
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
            display: none;
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
                font-size: 13rem;
                line-height: 0.5;
                position: absolute;
                margin-top: -40px;
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

        .RadGrid_Default .rgHeader {
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
            margin-top: 300px !important;
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

        .rwzHorizontal .rwzBreadCrumb {
            /*margin-top: 350px !important;*/
            width: 400px !important;
        }

        .RadWizard .rwzContent {
            overflow: hidden !important;
            height: 450px !important;
            margin-top: -500px;
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
    <style type="text/css">
        .tooltipDemo {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 5px;
            top: 0px;
        }

            .tooltipDemo:hover:before {
                border: solid;
                border-color: transparent #ef7c31;
                border-width: 6px 6px 6px 0px;
                bottom: 21px;
                content: "";
                left: 35px;
                top: 5px;
                position: absolute;
                z-index: 95;
                -webkit-transition: all 1s ease-in-out;
            }

            .tooltipDemo:hover:after {
                background: #ef7c31;
                border-radius: 5px;
                color: #fff;
                width: 150px;
                left: 40px;
                top: -5px;
                content: attr(alt);
                position: absolute;
                padding: 5px 15px;
                z-index: 95;
                -webkit-transition: all 1s ease-in-out;
            }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function AddNewRole() {
                window.radopen("AddNewRole.aspx", "RadRoleDialog");
                return false;
            }

            function AddNewUser() {
                window.radopen("../Create/CreateNewUser.aspx", "RadRoleDialog");
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div style="width: 95%">
        <div style="float: left; margin: -60px 0 0 25px">
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
            <div class="swMain" id="wizard" style="margin-top: 60px">
                <div>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadWizard1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadWizard ID="RadWizard1" runat="server" BackColor="Transparent" CssClass="marginTop350" DisplayNavigationButtons="false">
                        <WizardSteps>
                            <telerik:RadWizardStep runat="server" Title="Users & Permissions" ToolTip="This step is to create new Users." CssClass="loginStep">
                                <div style="float: left; position: relative; background-repeat: repeat;">
                                    <div style="width: 730px; height: 75px; margin-top: 10%">
                                        <table style="float: left; margin-top: 10px">
                                            <tr>
                                                <td style="width: 30px; height: 30px; cursor: pointer;" onclick="AddNewUser()"><%--TBD--%>
                                                    <img src="../../img/Add.png">
                                                </td>
                                                <td style="cursor: pointer;" onclick="AddNewUser()">
                                                    <h1 style="color: #808080; font-size: 20px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="float: right; margin-top: 20px">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnUserEdit" runat="server" CssClass="button" OnClick="btnUserEdit_Click" Text="Edit" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <telerik:RadGrid runat="server" ID="UserList" RenderMode="Lightweight" AllowPaging="false" CellSpacing="0"
                                            GridLines="None" EnableTheming="true" OnNeedDataSource="UserList_NeedDataSource"
                                            OnItemDataBound="UserList_ItemDataBound" OnUpdateCommand="UserList_UpdateCommand">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                                                BorderWidth="1px" />
                                            <MasterTableView AutoGenerateColumns="false" DataKeyNames="UserId">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="UserId" HeaderText="UserId" UniqueName="UserId"
                                                        ColumnGroupName="UserId" Visible="false" ReadOnly="true">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn HeaderStyle-Width="30%" DataField="UserName" HeaderText="User" UniqueName="UserName"
                                                        ColumnGroupName="UserName" ReadOnly="true">
                                                    </telerik:GridBoundColumn>                                                    
                                                    <telerik:GridTemplateColumn HeaderText="Role Name" HeaderStyle-Width="30%" ColumnGroupName="Role Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserRole" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate> 
                                                            <asp:HiddenField ID="hdnUserRole" runat="server" Value='<%#Eval("RoleName") %>' /> 
                                                            <asp:DropDownList ID="ddlUserRole" runat="server"></asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="Email" HeaderStyle-Width="30%" HeaderText="Email" UniqueName="Email"
                                                        ColumnGroupName="Email" ReadOnly="true">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-Width="30%" ColumnGroupName="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserStatus" runat="server" Text='<%# Eval("IsLockedOut") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:DropDownList ID="ddlUserStatus" runat="server"></asp:DropDownList>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                        <div style="float: right;">
                                            <a href="#" alt="Take control, you can create user accounts for individual
                                        members of your team. Creating users allows you to define and manage permission for each user(s).They can be
                                        assigned to Roles(s) with predifined permissions."
                                                class="tooltipDemo">
                                                <img src="../../img/Help.png" width="50px" height="50px" /></a>
                                        </div>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>
                            <telerik:RadWizardStep runat="server" Title="Roles & Permissions" ToolTip="This step is to create new Roles." CssClass="loginStep">
                                <div style="float: left; position: relative; background-repeat: repeat;">
                                    <div style="width: 730px; height: 75px; margin-top: 10%">
                                        <table style="float: left; margin-top: 10px">
                                            <tr>
                                                <td style="width: 30px; height: 30px; cursor: pointer;" onclick="AddNewRole()"><%--TBD--%>
                                                    <img src="../../img/Add.png">
                                                </td>
                                                <td style="cursor: pointer;" onclick="AddNewRole()">
                                                    <h1 style="color: #808080; font-size: 20px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="float: right; margin-top: 10px">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="button" /></td>
                                                <td>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="button" /></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <telerik:RadGrid runat="server" RenderMode="Lightweight" AllowPaging="True" CellSpacing="0"
                                            GridLines="None" PageSize="10" ID="RoleList" OnNeedDataSource="RoleList_NeedDataSource"
                                            OnUpdateCommand="RoleList_UpdateCommand" OnItemDataBound="RoleList_ItemDataBound">
                                            <ClientSettings>
                                                <Selecting AllowRowSelect="True" />
                                            </ClientSettings>
                                            <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                                                BorderWidth="1px" />
                                            <MasterTableView AutoGenerateColumns="false" DataKeyNames="RoleName">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="RoleId" HeaderText="Role Id" UniqueName="RoleId"
                                                        ColumnGroupName="RoleId" Visible="false" ReadOnly="true">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn UniqueName="RoleTemplateColumn" HeaderText="Role">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("RoleName") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RoleName") %>' />
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn UniqueName="ActionTemplateColumn" HeaderText="Permissions">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblActions" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <telerik:RadListBox ID="radList1" SelectionMode="Multiple" runat="server"></telerik:RadListBox>
                                                        </EditItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                        <div style="float: right;">
                                            <a href="#" alt="Take control, you can create user accounts for individual members of your team. Creating users allows
                                            you to define and manage permission for each user(s).They can be assigned to Roles(s) with predifined permissions."
                                                class="tooltipDemo">
                                                <img src="../../img/Help.png" width="50px" height="50px" /></a>
                                        </div>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>
                        </WizardSteps>
                    </telerik:RadWizard>
                </div>
        </div>
    </div>
    </div>
    <div id="footer">
        <span class="vupFooterText"><a href="..\ContactUs.aspx">Contact Us</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Privacy</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Terms of Use</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupCopyright">&copy;Video-Up</span>
    </div>
    <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="RadRoleDialog" runat="server" Height="580px"
                Width="680px" Left="100px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

