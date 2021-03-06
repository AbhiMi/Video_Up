﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CreatePlaylist.aspx.cs" Inherits="Pages_CreatePlaylist" EnableEventValidation="false" %>

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
    <script type="text/javascript">
        function ShowText(myFile) {
            var file = myFile.files[0];
            var filename = file.name;
            // alert(filename);
            document.getElementById('lblUpload').innerText = filename;
        }

        function deleteConfirm(companyName) {
            var result = confirm('Are you sure you want to delete ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }

       <%-- function ValidateFileUpload(Source, args) {
            var fuData = document.getElementById('<%= imgFileUpload.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "jpg" || Extension == "jpeg" || Extension == "png" || Extension == "gif" || Extension == "bmp") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }--%>
    </script>
    <script type="text/javascript">
        $(function () {
            $(".drag_drop_grid").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'move',
                connectWith: '.drag_drop_grid',
                dropOnEmpty: true,
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                   <%-- var gvid = '<%=gvDest.ClientID %>';--%>
                    var media = {};
                    //var row = $(this).parent().parent();
                    //var hidd = row.find('td').find(':input').val();
                    //campaign.ID = $('#' + gvid + ' input[type=hidden]').val();
                    media.ID = $("[id*=gvDest] tr:last").find("td:nth-child(1)").html();
                    media.PlaylistID = $("#<%=hdnPlaylistID.ClientID%>").val()
                    $.ajax({
                        type: "POST",
                        url: "CreatePlaylist.aspx/SavePlayList",
                        data: '{media: ' + JSON.stringify(media) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            //alert("Campaign has been added to Channel successfully.");
                        },
                        error: function (response)
                        { alert(response); }

                    });
                    window.location.href = window.location.href;
                    return false;
                }
            });
            //$("[id*=gvDest] tr:not(tr:first-child)").remove();
        });

        function hideColumn() {
            var gvid = '<%=gvSource.ClientID %>';
            var rows = document.getElementById(gvid).rows;
            for (i = 0; i <= rows.length; i++) {
                if (rows[i] != undefined && rows[i].cells[0] != undefined)
                    rows[i].cells[0].style.display = "none";
            }
        }
    </script>
    <script>
        <%--$(document).ready(function () {
            $("#<%=txtPlaylist.ClientID%>").autocomplete('Search_Playlist.ashx');
        });--%>
        function SetupFilter(textboxID, gridID, columnName) {
            $('#' + textboxID).keyup(function () {
                var index;
                var text = $("#" + textboxID).val();

                $('#' + gridID + ' tbody tr').each(function () {
                    $(this).children('th').each(function () {
                        if ($(this).html() == columnName)
                            index = $(this).index();
                    });

                    $(this).children('td').each(function () {
                        if ($(this).index() == index) {
                            var tdText = $(this).children(0).html() == null ? $(this).html() : $(this).children(0).html();

                            if (tdText.indexOf(text, 0) > -1) {
                                $(this).closest('tr').show();
                            } else {
                                $(this).closest('tr').hide();
                            }
                        };
                    });
                });
            });
        };

        $(function () { SetupFilter("txtPlaylist", "grdPlaylists", "Playlist Name"); });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[src*=minus]").each(function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
                $(this).next().remove()
            });
        });
        function ConfirmUnAssociate() {
            return confirm("Are you sure you would like to unassociate this playlist?");
        }
    </script>
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
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
        .RadGrid_Default {
            background: none !important;
            border: none !important;
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
            margin-top: 340px !important;
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
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function AddNewPlayList() {
                window.radopen("AddNewPlayList.aspx", "RadPlayListDialog");
                return false;
            }
         </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="bg-text" data-bg-text="Playlist">
    </div>
    <table style="margin-left: 390px">
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" CssClass="lblTitle" />
                <asp:Label ID="lblSelectedCampaign" runat="server" Text="" CssClass="lblSelectedCampaign" Visible="false" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnPlaylistName" runat="server" />
    <div style="width: 95%">
        <div style="float: left; margin: -55px 0 0 25px">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                width="350" height="350   ">
                <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                <param name="movie" value="../../Swf/CustomizePlaylist.swf" />
                <param name="quality" value="high" />
                <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                <embed src="../../Swf/CustomizePlaylist.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                    type="application/x-shockwave-flash" width="350px" height="350px" />
            </object>
        </div>
        <div style="float: left; width: 65%" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 20px">
                <div>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadWizard1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" CssClass="marginTop350" DisplayNavigationButtons="false">
                        <WizardSteps>
                            <%--<telerik:RadWizardStep runat="server" Title="&nbsp;&nbsp;&nbsp;&nbsp;Create Playlist" ToolTip="This step is to create new playlist." CssClass="loginStep">
                                <div style="float: left; position: relative; background-repeat: repeat; height: 600px; margin-top: 80px">
                                    <table id="tblPlaylist" runat="server">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 2px;">
                                                <asp:Label ID="lblCreatePlayList" Text="PlayList Name:" runat="server" CssClass="label" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCreatePlayList" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 2px;">
                                                <asp:Label ID="lblUploadImage" runat="server" Text="Upload PlayList Image:" CssClass="label" />
                                            </td>
                                            <td>
                                                <div class="custom_file_upload">
                                                    <div class="file_upload">
                                                        <asp:FileUpload ID="imgFileUpload" runat="server" CssClass="fileUploaderBtn" onchange="ShowText(this);" />
                                                    </div>
                                                </div>
                                                <label id="lblUpload" style="float: right; margin-top: -35px; width: 100px;"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="float: left; margin-top: 10px">
                                                <asp:Button ID="btnCreatePlayList" runat="server" Text="Create PlayList" CssClass="button" OnClick="btnCreatePlayList_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload" ErrorMessage="Invalid file type. Only .gif, .jpg, .png, .bmp and .jpeg are allowed." ControlToValidate="imgFileUpload" ValidationGroup="update">&nbsp;</asp:CustomValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCreatePlayListStatus" runat="server" Visible="false" Font-Bold="true" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </telerik:RadWizardStep>--%>
                            <telerik:RadWizardStep runat="server" Title="&nbsp;&nbsp;&nbsp;&nbsp;Select Playlist" ToolTip="Select the playlist to be managed." CssClass="loginStep">
                                <div style="float: left; position: relative; background-repeat: repeat; height: 600px;">
                                    <div style="width: 700px; height: 330px; margin-top: 110px">
                                        <table style="float: left">
                                                 <tr style="cursor: pointer;" onclick="AddNewPlayList()">
                                                <td style="width: 30px; height: 30px">
                                                    <img src="../../img/Add.png">
                                                </td>
                                                <td>
                                                    <h1 style="color: #808080; font-size: 17px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                                </td>
                                            </tr>
                                            </table>
                                        <table style="float: right; margin-top: 20px">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="button" /></td>
                                                    <td>
                                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="button" /></td>
                                                </tr>
                                            </table>
                                        <div>
                                            <telerik:RadGrid ID="grdPlayList" runat="server" OnNeedDataSource="grdPlayList_NeedDataSource" OnUpdateCommand="grdPlayList_UpdateCommand">
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <SelectedItemStyle BackColor="Fuchsia" BorderColor="Purple" BorderStyle="Dashed"
                                                    BorderWidth="1px" />
                                                <MasterTableView DataKeyNames="PlayListID" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="PlayListID" HeaderText="Playlist Id" UniqueName="PlayListID"
                                                            ColumnGroupName="PlayListID" Visible="false" ReadOnly="true">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn HeaderText="PlayList Image" ItemStyle-HorizontalAlign="Center" SortExpression="PlayListName">
                                                            <ItemTemplate>
                                                                <asp:Image ID="imgPlayListName" runat="server" ImageUrl='<%# "~/img/"+Eval("FileName") %>' Width="20px" Height="20px" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <div class="mini_file_upload">
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileUploaderBtn" />
                                                                </div>
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="PlayList Name" SortExpression="PlayListName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPlayListName" runat="server" Text='<%#Eval("PlayListName") %>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtPlayListName" Width="270px" runat="server" Text='<%#Eval("PlayListName") %>' />
                                                            </EditItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>                                                    
                                            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                                        </div>
                                     </div>
                                </div>
                            </telerik:RadWizardStep>
                            <telerik:RadWizardStep runat="server" Title="&nbsp;&nbsp;&nbsp;&nbsp;Manage Playlist" ToolTip="Associate media to the playlist." CssClass="loginStep">
                                <div style="float: left; position: relative; background-repeat: repeat; height: 600px; margin-top: 130px">
                                    <asp:HiddenField ID="hdnPlaylistID" runat="server" />
                                    <div>
                                        <asp:Label ID="lblNote" runat="server" Text="* Please select a media and drag & drop to assign media files to playlist." CssClass="label" />
                                    </div>
                                    <div id="dragdrop" runat="server">
                                        <div style="float: left; width: 45%; height: 330px; padding: 10px; margin-right: 25px; margin-top: 20px; background-color: #A3A3A4;border: 2px solid #ef7c31 !important;">
                                            <h3 class="h3" style="width: 360px; background-color: #ef7c31; text-align: center; margin-left: -5px">Associated Media</h3>
                                            <div class="content scrollbar" style="margin-bottom: 20px; min-height: 300px;">
                                                <asp:Button ID="btnSaveOrder" Text="Apply Changes" runat="server" OnClick="btnSaveOrder_Click" CssClass="button marginBottom17" />
                                                <asp:GridView ID="gvDest" GridLines="Both" runat="server" ShowHeaderWhenEmpty="true" CssClass="drag_drop_grid Grid" AutoGenerateColumns="false"
                                                    DataKeyNames="Description,MediaID" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader"
                                                    AllowSorting="true" OnSorting="gvDest_Sorting">
                                                    <SelectedRowStyle BackColor="#a3a3a4" Font-Bold="True" ForeColor="#333333" />
                                                    <RowStyle BackColor="#e9e9e9" />
                                                    <AlternatingRowStyle BackColor="#d2d2d2" />
                                                    <Columns>
                                                        <asp:BoundField DataField="MediaID" Visible="false"></asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input type="hidden" name="AssociationId" value='<%# Eval("ID") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="imgThumbNail" runat="server" ImageUrl='<%# "~/img/" + Eval("FileName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                                        <asp:BoundField ItemStyle-Width="210px" HeaderText="Media" ItemStyle-HorizontalAlign="Left" DataField="Description"
                                                            HeaderStyle-HorizontalAlign="Left" SortExpression="Description"></asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgUnAssociate" runat="server" OnClick="imgUnAssociate_Click" ImageUrl="~/img/UnAssociate.png" OnClientClick="if ( ! ConfirmUnAssociate()) return false;" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div style="float: right; min-height: 320px; padding: 10px; width: 45%; background-color: #A3A3A4; margin-top: 20px;border: 2px solid #ef7c31 !important;">
                                            <h3 class="h3" style="width: 360px; background-color: #ef7c31; text-align: center; margin-left: -5px">Available Media</h3>
                                            <div class="content scrollbar" style="min-height: 300px;">
                                                <asp:GridView ID="gvSource" GridLines="Both" runat="server" CssClass="drag_drop_grid Grid" AutoGenerateColumns="false"
                                                    AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader" AllowSorting="true"
                                                    OnSorting="gvSource_Sorting">
                                                    <SelectedRowStyle BackColor="#a3a3a4" Font-Bold="True" ForeColor="#333333" />
                                                    <RowStyle BackColor="#e9e9e9" />
                                                    <AlternatingRowStyle BackColor="#d2d2d2" />
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="25px" ItemStyle-Height="20px" ItemStyle-HorizontalAlign="Center" DataField="MediaID"
                                                            HeaderText="ID" SortExpression="MediaID"></asp:BoundField>
                                                        <%--<asp:TemplateField HeaderText="" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="imgThumbNail" runat="server" ImageUrl='<%# "~/img/" + Eval("FileName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                                        <asp:BoundField ItemStyle-Width="250px" HeaderText="Media" ItemStyle-HorizontalAlign="Left" DataField="Description"
                                                            HeaderStyle-HorizontalAlign="Left" SortExpression="Description"></asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
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
            <telerik:RadWindow RenderMode="Lightweight" ID="RadPlayListDialog" runat="server" Height="320px"
                Width="500px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

