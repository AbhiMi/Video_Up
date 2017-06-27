<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomUpload.aspx.cs" MasterPageFile="~/RADVupTiles.master" Inherits="Pages_CustomUpload"
    EnableEventValidation="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="../js/jquery-1.3.2.min.js"></script>
    <%--<script src="../js/jquery.min.js"></script>--%>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../css/demo_style.css" rel="stylesheet" />
    <link href="../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../../js/jquery-1.4.2.min.js"></script>
    <%--<script src="../js/jquery.min.js"></script>--%>
    <script src="../Scripts/jquery-ui.js"></script>
    <script src="../js/FileUpload.js"></script>
    <script src="../Scripts/jquery.autocomplete.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <link href="../css/FileUpload.css" rel="stylesheet" />
    <script src="../js/jquery.uploadify.js"></script>
    <link href="../css/uploadify.css" type="text/css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Carrois+Gothic+SC' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <script src="../js/html5lightbox/html5lightbox.js"></script>  
    <style>
        .uploadify-button {
            background: #808080;
            color: #FFFFFF;
        }

        .uploadify:hover .uploadify-button {
            background: #808080;
            color: #FFFFFF;
        }

        .uploadWrapper embed {
            background-color: #808080;
        }

            .uploadWrapper embed:hover {
                background-color: #808080;
            }

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
            top: 700px !important;
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
            position: relative;
            margin-left: 375px;
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
            margin-top: 320px !important;
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

        .ruFakeInput {
            display: none !important;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="bg-text" data-bg-text="Upload">
    </div>
    <asp:HiddenField ID="hdnDescription" runat="server" />
    <br />
    <table style="margin-left: 390px">
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" Font-Size="2em" CssClass="lblTitle" /></td>
        </tr>
    </table>

    <div style="width: 95%">
        <div style="float: left; margin: -70px 0 0 25px">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                width="350" height="350   ">
                <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                <param name="movie" value="../../Swf/UploadMedia.swf" />
                <param name="quality" value="high" />
                <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                <embed src="../../Swf/UploadMedia.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                    type="application/x-shockwave-flash" width="350px" height="350px" />
            </object>
        </div>
        <div style="float: left; width: 65%" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 20px">
                <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadWizard1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" CssClass="marginTop350" DisplayNavigationButtons="false">
                    <WizardSteps>
                        <telerik:RadWizardStep runat="server" Title="Upload Media" ToolTip="This step is to upload media." CssClass="loginStep">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px; margin: 80px 0 0 10px">
                                <table>
                                    <tr>
                                        <td style="vertical-align: middle">
                                            <div class="demo-container size-narrow" style="float: left;">
                                                <telerik:RadAsyncUpload EnableInlineProgress="true" RenderMode="Lightweight" runat="server" ID="RadAsyncUpload1" AllowedFileExtensions="jpg,jpeg,png,gif,mp4" TargetFolder="" MultipleFileSelection="Automatic"
                                                    MaxFileSize="1242880000" OnFileUploaded="RadAsyncUpload1_FileUploaded" OnClientValidationFailed="validationFailed" UploadedFilesRendering="AboveFileInput">
                                                </telerik:RadAsyncUpload>
                                                <telerik:RadProgressArea RenderMode="Lightweight" runat="server" ID="RadProgressArea1" />
                                            </div>
                                            <div style="float: right; margin-top: 5.2%">
                                                <telerik:RadButton RenderMode="Lightweight" runat="server" ID="BtnSubmit" Text="Upload Files"></telerik:RadButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </telerik:RadWizardStep>
                        <telerik:RadWizardStep runat="server" Title="Preview Media" ToolTip="This step is to preview media." CssClass="loginStep">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px; margin: 80px 0 0 10px">
                                <table style="float: left; margin-top: 10px">
                                    <tr>
                                        <td>                                        
                                            <div id="ifvid1" style="display: none">
                                                <video id="videoclip" controls="controls" width="40%" height="40%" poster="images/cover.jpg" title="Video title">
                                                    <source id="mp4video" src="media/video1.mp4" type="video/mp4" />
                                                </video>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <table style="float: right; margin-top: 25px">
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="button" /></td>
                                        <td>
                                            <asp:Button ID="btnDelete" runat="server" CssClass="button" OnClick="btnDelete_Click" Text="Delete" />
                                        </td>
                                    </tr>
                                </table>
                                <div style="height: 330px;">
                                    <table>
                                        <tr>
                                            <td>
                                                <telerik:RadGrid runat="server" ID="grdMedia" RenderMode="Lightweight" AllowPaging="false" CellSpacing="0"
                                                    GridLines="None" EnableTheming="true" OnNeedDataSource="grdMedia_NeedDataSource" OnUpdateCommand="grdMedia_UpdateCommand" Width="700px">
                                                    <ClientSettings>
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                                                        BorderWidth="1px" />
                                                    <MasterTableView AutoGenerateColumns="false" DataKeyNames="MediaID">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="MediaID" HeaderText="MediaID" UniqueName="MediaID"
                                                                ColumnGroupName="MediaID" Visible="false" ReadOnly="true">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Description" HeaderStyle-Width="30%" ColumnGroupName="Description">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="lnkDescription"  class="html5lightbox" runat="server" Text='<%#Eval("Description") %>' NavigateUrl='<%#Eval("UrlLocation") %>'></asp:HyperLink>
                                                                    <%--<asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>' />--%>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtDescription" Width="170px" runat="server" Text='<%#Eval("Description") %>' />
                                                                </EditItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn UniqueName="URL" HeaderText="Url" Display="false" DataField="UrlLocation"></telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="UploadedOn" HeaderText="Date Created" SortExpression="UploadedOn"
                                                                DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified"
                                                                DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true">
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>                                                
                                                <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="popup" style="float: left; width: 400px; height: 400px;">
                                    <asp:Literal runat="server" ID="mediaplayerLtr"></asp:Literal>
                                </div>
                            </div>
                        </telerik:RadWizardStep>
                        <%--<telerik:RadWizardStep runat="server" Title="3&nbsp;&nbsp;&nbsp;&nbsp;Generate ThumbNail" ToolTip="This step is to generate thumbnail." CssClass="loginStep">
                            <div style="float: left; position: relative; background-repeat: repeat; height: 600px; margin: 40px 0 0 10px">
                                <input id="inpHide" type="hidden" runat="server" />
                                <video id="myVideo" runat="server" width="320" height="176" controls>
                                    Your browser does not support HTML5 video.
                                </video>
                                <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" OnClientClick="getCurTime()"
                                    Text="Get Frame" />
                            </div>
                        </telerik:RadWizardStep>--%>
                    </WizardSteps>
                </telerik:RadWizard>
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
    <%--    </form>
</body>
</html>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
