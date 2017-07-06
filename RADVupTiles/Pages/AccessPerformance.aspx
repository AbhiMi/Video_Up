<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="AccessPerformance.aspx.cs" Inherits="Pages_AccessPerformance" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .k-content, .k-editable-area, .k-panel > li.k-item, .k-panelbar > li.k-item, .k-tiles {
            background-color: transparent;
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
            margin-top: 350px !important;
            margin-left: -380px !important;
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
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function getAjaxManager() {
                return $find("<%=RadAjaxManager1.ClientID%>");
            }
        </script>
    </telerik:RadCodeBlock>
    <script type="text/javascript">
        (function (global, undefined) {
            global.OnClientSeriesClicked = function (sender, args) {
                var ajaxManager = global.getAjaxManager();

                if (args.get_seriesName() !== "Videos") {
                    ajaxManager.ajaxRequest(args.get_category());
                }
            }
        })(window);
    </script>
    <script type="text/javascript">
    function pageLoad() {
        //get the chart
        var chart = $find("<%= RadHtmlChart1.ClientID %>");
        //set the "gap" property of the first series, i.e. the ColumnSeries in our case
        chart._chartObject.options.series[0].gap = 50;
        //repaint the chart to apply the changes
        chart.repaint();
    }
</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="bg-text" data-bg-text="Access Performance">
    </div>
    <asp:HiddenField ID="hdnDescription" runat="server" />
    <br />
    <%--    <table style="margin-left: 390px">
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="Access Performance" Font-Size="2em" CssClass="lblTitle" /></td>
        </tr>
    </table>--%>

    <div style="width: 95%">
        <div style="float: left; margin: -50px 0 0 25px">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                width="350" height="350   ">
                <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                <param name="movie" value="../../Swf/AccessPeformance.swf" />
                <param name="quality" value="high" />
                <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                <embed src="../../Swf/AccessPeformance.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                    type="application/x-shockwave-flash" width="350px" height="350px" />
            </object>
        </div>
        <div style="float: left; width: 65%" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 20px">
                <div>
                    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="hidePanel" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="visiblePanel" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="Refresh">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="hidePanel" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <%--<telerik:AjaxSetting AjaxControlID="btnReport">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="chartPie" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="btnReport">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="chartBar" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>--%>
                            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="HtmlChartHolder" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Height="77px" Width="113px">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" CssClass="marginTop350" DisplayNavigationButtons="false">
                        <WizardSteps>
                            <telerik:RadWizardStep runat="server" Title="&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp; Custom Report" ToolTip="View all data" CssClass="loginStep">
                                <div style="position: relative; background-repeat: repeat; margin-top: 20px">
                                    <telerik:RadGrid RenderMode="Lightweight" ID="RadGrid1" Width="100%" DataSourceID="SqlDataSource1" runat="server" PageSize="20"
                                        AllowSorting="True" AllowMultiRowSelection="True" AllowPaging="True" ShowGroupPanel="True" AllowFilteringByColumn="True"
                                        AutoGenerateColumns="False" GridLines="none" ShowFooter="True" OnItemDataBound="RadGrid1_ItemDataBound">
                                        <ClientSettings>
                                            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"></Scrolling>
                                        </ClientSettings>
                                        <PagerStyle PageSizeControlType="RadDropDownList" Mode="NextPrevAndNumeric"></PagerStyle>
                                        <MasterTableView ShowGroupFooter="True" AllowMultiColumnSorting="true" Width="100%">
                                            <GroupByExpressions>
                                                <%--<telerik:GridGroupByExpression>
                                                    <SelectFields>
                                                        <telerik:GridGroupByField FieldAlias="RADDevice" FieldName="RADDevice"
                                                            HeaderValueSeparator=" name: "></telerik:GridGroupByField>
                                                    </SelectFields>
                                                    <GroupByFields>
                                                        <telerik:GridGroupByField FieldName="RADDeviceID" SortOrder="Descending"></telerik:GridGroupByField>
                                                    </GroupByFields>
                                                </telerik:GridGroupByExpression>--%>
                                                <telerik:GridGroupByExpression>
                                                    <SelectFields>
                                                        <telerik:GridGroupByField FieldAlias="Campaign" FieldName="Campaign"></telerik:GridGroupByField>
                                                    </SelectFields>
                                                    <GroupByFields>
                                                        <telerik:GridGroupByField FieldName="Campaign"></telerik:GridGroupByField>
                                                    </GroupByFields>
                                                </telerik:GridGroupByExpression>
                                            </GroupByExpressions>
                                            <Columns>
                                                <telerik:GridBoundColumn Aggregate="Sum" DataField="View" HeaderText="Views" FooterText="Campaign Total Views: ">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Region" HeaderText="Region" HeaderButtonType="TextButton"
                                                    DataField="Region">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Area" HeaderText="Area" HeaderButtonType="TextButton"
                                                    DataField="Area">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Store" HeaderText="Store" HeaderButtonType="TextButton"
                                                    DataField="Store">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="RADDevice" HeaderText="RADDevice" HeaderButtonType="TextButton"
                                                    DataField="RADDevice">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Campaign" HeaderText="Campaign" HeaderButtonType="TextButton"
                                                    DataField="Campaign">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Playlist" HeaderText="Playlist" HeaderButtonType="TextButton"
                                                    DataField="Playlist">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Video" HeaderText="Video" HeaderButtonType="TextButton"
                                                    DataField="Video">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="Start" HeaderText="Start" HeaderButtonType="TextButton"
                                                    DataField="Start" DataFormatString="{0:MM/dd/yy hh:mm:ss}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn SortExpression="End" HeaderText="End" HeaderButtonType="TextButton"
                                                    DataField="End" DataFormatString="{0:MM/dd/yy hh:mm:ss}">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridCalculatedColumn HeaderText="Duration" UniqueName="Durata" DataType="System.TimeSpan"
                                                    DataFields="Start, End" Expression="{1}-({0})" />
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="true" ReorderColumnsOnClient="true">
                                            <Resizing AllowRowResize="True" EnableRealTimeResize="True" ResizeGridOnColumnResize="True"
                                                AllowColumnResize="True"></Resizing>
                                        </ClientSettings>
                                        <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                                    </telerik:RadGrid>
                                </div>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
                                    ProviderName="System.Data.SqlClient" SelectCommandType="StoredProcedure" SelectCommand="SP_GetAccessPerformance" OnSelecting="SqlDataSource1_Selecting">
                                    <SelectParameters>
                                        <asp:Parameter Name="CompanyID" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </telerik:RadWizardStep>
                            <telerik:RadWizardStep runat="server" Title="&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp; Data Charts" ToolTip="View all data" CssClass="loginStep">
                                <table>
                                    <tr>
                                        <td>
                                            <label for="RadDateTimePicker1">Start Date:</label></td>
                                        <td>
                                            <telerik:RadDateTimePicker ID="RadDateTimePicker1" runat="server">
                                            </telerik:RadDateTimePicker>
                                        </td>
                                        <td>
                                            <label for="RadDateTimePicker2">End Date:</label></td>
                                        <td>
                                            <telerik:RadDateTimePicker ID="RadDateTimePicker2" runat="server">
                                            </telerik:RadDateTimePicker>
                                        </td>
                                        <td>
                                            <telerik:RadDropDownList ID="ddlReportType" runat="server">
                                                <Items>
                                                    <telerik:DropDownListItem Text="Bar Chart" Value="1" />
                                                    <telerik:DropDownListItem Text="Pie Chart" Value="2" />
                                                    <telerik:DropDownListItem Text="Line Chart" Value="3" />
                                                    <telerik:DropDownListItem Text="Scatter Chart" Value="4" />
                                                </Items>
                                            </telerik:RadDropDownList>
                                        </td>
                                        <td>
                                            <telerik:RadButton ID="btnReport" runat="server" OnClick="btnReport_Click" Text="Generate Report"></telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                                <telerik:RadClientExportManager runat="server" ID="RadClientExportManager1">
                                </telerik:RadClientExportManager>
                                <asp:Panel ID="hidePanel" runat="server">
                                    <div id="chartBar" runat="server">
                                        <telerik:RadHtmlChart runat="server" ID="RadHtmlChart1" Height="400px" Width="800px" OnClientSeriesClicked="OnClientSeriesClicked">
                                            <PlotArea>
                                                <Series>
                                                    <telerik:ColumnSeries DataFieldY="CampaignViews" Name="Campaigns">
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ef7c31"></FillStyle>
                                                        </Appearance>
                                                        <TooltipsAppearance Color="White" />
                                                    </telerik:ColumnSeries>
                                                </Series>
                                                <XAxis DataLabelsField="CampaignName">
                                                    <TitleAppearance Text="Campaign Name">
                                                        <TextStyle Margin="20" />
                                                    </TitleAppearance>
                                                    <MajorGridLines Visible="false" />
                                                    <MinorGridLines Visible="false" />
                                                </XAxis>
                                                <YAxis>
                                                    <TitleAppearance Text="Views">
                                                        <TextStyle Margin="20" />
                                                    </TitleAppearance>
                                                    <MinorGridLines Visible="false" />
                                                </YAxis>
                                            </PlotArea>
                                            <%--<ChartTitle Text="Total Views">
                                            </ChartTitle>--%>
                                        </telerik:RadHtmlChart>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="visiblePanel" runat="server">
                                    <div id="chartPie" runat="server">
                                        <telerik:RadHtmlChart runat="server" ID="RadHtmlChart2" Height="400px" Width="480px"
                                            CssClass="fb-sized" OnClientSeriesClicked="OnClientSeriesClicked">
                                            <PlotArea>
                                                <Series>
                                                    <telerik:PieSeries DataFieldY="Views" NameField="Name" Name="Campaigns" ExplodeField="IsExploded">
                                                        <LabelsAppearance DataFormatString="{0}">
                                                        </LabelsAppearance>
                                                        <TooltipsAppearance Color="White" DataFormatString="{0}"></TooltipsAppearance>
                                                    </telerik:PieSeries>
                                                </Series>
                                                <XAxis>
                                                </XAxis>
                                            </PlotArea>
                                            <%--<ChartTitle Text="Total Views">
                                            </ChartTitle>--%>
                                        </telerik:RadHtmlChart>
                                    </div>
                                    <div id="chartLine" runat="server">
                                        <telerik:RadHtmlChart runat="server" ID="RadHtmlChart3" Height="400px" Width="750px" CssClass="fb-sized">
                                            <PlotArea>
                                                <XAxis BaseUnitStep="1">
                                                    <TitleAppearance Text="Date">
                                                    </TitleAppearance>                                                    
                                                    <MajorGridLines Color="#EFEFEF" Width="1"></MajorGridLines>
                                                    <MinorGridLines Color="#F7F7F7" Width="1"></MinorGridLines>
                                                </XAxis>
                                            </PlotArea>
                                            <ChartTitle Text="Total Views">
                                            </ChartTitle>
                                        </telerik:RadHtmlChart>
                                    </div>
                                    <div id="chartScatter" runat="server">
                                        <telerik:RadHtmlChart runat="server" ID="RadHtmlChart4" Width="750px" Height="400px" OnClientSeriesClicked="OnClientSeriesClicked">
                                            <PlotArea>
                                                <Series>
                                                    <telerik:ScatterLineSeries DataFieldY="CampaignViews" DataFieldX="Start" Name="Campaigns">
                                                        <LineAppearance Width="5%" />
                                                        <LabelsAppearance Visible="false" DataFormatString="{1} ({0:m})">
                                                        </LabelsAppearance>
                                                        <TooltipsAppearance Color="White" DataFormatString="{1} campaigns viewed on<br/>{0:D}" />
                                                        <Appearance>
                                                            <FillStyle BackgroundColor="#ef7c31"></FillStyle>
                                                        </Appearance>
                                                    </telerik:ScatterLineSeries>
                                                </Series>
                                                <XAxis BaseUnit="days">
                                                    <TitleAppearance Text="Date">
                                                    </TitleAppearance>
                                                    <LabelsAppearance DataFormatString="m">
                                                    </LabelsAppearance>
                                                    <MajorGridLines Color="#EFEFEF" Width="1"></MajorGridLines>
                                                    <MinorGridLines Color="#F7F7F7" Width="1"></MinorGridLines>
                                                </XAxis>
                                                <YAxis>
                                                    <TitleAppearance Text="Total Views">
                                                    </TitleAppearance>
                                                    <MajorGridLines Color="#EFEFEF" Width="1"></MajorGridLines>
                                                    <MinorGridLines Color="#F7F7F7" Width="1"></MinorGridLines>
                                                </YAxis>
                                            </PlotArea>
                                            <ChartTitle Text="Campaign Views per Date">
                                            </ChartTitle>
                                        </telerik:RadHtmlChart>
                                    </div>
                                </asp:Panel>
                                <table>
                                    <tr>
                                        <td>
                                            <telerik:RadButton RenderMode="Lightweight" CssClass="button" runat="server" OnClientClicked="exportRadHtmlChart" Text="Export Chart to PDF" AutoPostBack="false" UseSubmitBehavior="false"></telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadWizardStep>
                        </WizardSteps>
                    </telerik:RadWizard>
                </div>
            </div>
        </div>
    </div>

    <div id="footer">
        <span class="vupFooterText"><a href="ContactUs.aspx">Contact Us</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Privacy</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Terms of Use</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupCopyright">&copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
    <script>
        var js = $telerik.$;
        function exportRadHtmlChart() {
            js.find('<%=RadClientExportManager1.ClientID%>').exportPDF(js(".RadHtmlChart"));
            }
    </script>
</asp:Content>
