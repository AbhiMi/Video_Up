<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="PreviewCampaign.aspx.cs" Inherits="Pages_PreviewCampaign" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="scheduler" TagName="AdvancedForm" Src="AdvancedFormCS.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../css/demo_style.css" rel="stylesheet" />
    <link href="../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../js/jquery-1.4.2.min.js"></script>
    <%--<script src="../js/jquery.min.js"></script>--%>
    <script src="../Scripts/jquery-ui.js"></script>
    <%-- <script src="../js/kendo.all.min.js"></script>
    <script src="../js/kendo.timezones.min.js"></script>
    <link href="../css/kendo.common.min.css" rel="stylesheet" />
    <link href="../css/kendo.default.min.css" rel="stylesheet" />--%>
    <%--<script src="../js/jquery.smartWizard-2.0.min.js"></script>--%>
    <script src="../js/jquery.fancybox.js"></script>
    <script src="../js/jquery.fancybox.pack.js"></script>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />
    <script>
        $(function () {
            modalPosition();
            $(window).resize(function () {
                modalPosition();
            });
            $('.openModal').click(function (e) {
                $('.modal, .modal-backdrop').fadeIn('fast');
                $('.modal-backdrop').removeAttr('style');
                e.preventDefault();
            });
            $('.close-modal').click(function (e) {
                $('.modal, .modal-backdrop').fadeOut('fast');
                window.location.href = window.location.href;
            });
        });
        function modalPosition() {
            var width = $('.modal').width();
            var pageWidth = $(window).width();
            var x = (pageWidth / 2) - (width / 2);
            $('.modal').css({ left: x + "px" });
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //$('#wizard').smartWizard({ transitionEffect: 'slide' });
            fancyPopup();
        });
        function fancyPopup() {
            // Declare some variables.
            var el = "";
            var posterPath = "";
            var replacement = "";
            var videoTag = "";
            var fancyBoxId = "";
            var posterPath = "";
            var videoTitle = "";

            // Loop over each video tag.
            $("video").each(function () {
                // Reset the variables to empty.
                el = "";
                posterPath = "";
                replacement = "";
                videoTag = "";
                fancyBoxId = "";
                posterPath = "";
                videoTitle = "";

                // Get a reference to the current object.
                el = $(this);

                // Set some values we'll use shortly.
                fancyBoxId = this.id + "_fancyBox";
                videoTag = el.parent().html();      // This gets the current video tag and stores it.
                posterPath = el.attr("poster");
                videoTitle = "Play Video " + this.id;


                // Concatenate the linked image that will take the place of the <video> tag.
                replacement = "<a title='" + videoTitle + "' id='" + fancyBoxId + "' href='javascript:;'><img src='" +
                    posterPath + "' class='img-link'/></a>"

                // Replace the parent of the current element with the linked image HTML.
                el.parent().replaceWith(replacement);

                /*
                Now attach a Fancybox to this item and set its attributes. 
                   
                This entire function acts as an onClick handler for the object to
                which it's attached (hence the "end click function" comment).
                */
                $("[id=" + fancyBoxId + "]").fancybox(
                {
                    'content': videoTag,
                    'title': videoTitle,
                    'autoDimensions': true,
                    'padding': 5,
                    'showCloseButton': true,
                    'enableEscapeButton': true,
                    'titlePosition': 'outside',
                }); // end click function
            });
        }
    </script>
    <script type="text/javascript">
        function OnAudioPlay(evt) {
            var a = $("audio[id!='" + evt.target.id + "']").get();
            for (var i = 0; i < a.length; i++) {
                a[i].pause();
            }

        }

        function OnVideoPlay(evt) {
            var v = $("video[id!='" + evt.target.id + "']").get();
            for (var i = 0; i < v.length; i++) {
                v[i].pause();
            }
        }
    </script>
    <script type="text/javascript">
        <%-- $(function () {

            var RowID = $('#<%=hdnCampaignID.ClientID%>').val();
            if (RowID != "0") {
                $('#<%=grdCampaign.ClientID%> tr[id=' + RowID + ']').css({ "background-color": "#A3A3A4", "color": "#333333" });
            }

            $('#<%=grdCampaign.ClientID%> tr[id]').click(function () {
                $('#<%=grdCampaign.ClientID%> tr[id]').css({ "background-color": "#A3A3A4", "color": "#333333" });
                $(this).css({ "background-color": "#A3A3A4", "color": "#333333" });
                $('#<%=hdnCampaignID.ClientID%>').val($(this).attr("id"));
            });

            $('#<%=grdCampaign.ClientID%> tr[id]').mouseover(function () {
                $(this).css({ cursor: "hand", cursor: "pointer" });
            });

        });--%>
    </script>
    <script>
        //protected void Buy(object sender, EventArgs e)
        //{
        //    this.Iframe2.Attributes.Add("src", this.ResolveUrl(
        //        string.Format("ScheduleCampaign.aspx?p={0}", this.hdnCampaignID.Value)));
        //}
        function OpenWindow() {
        <%--$('#<%=Button3.ClientID%>').live("click", function () {--%>
            var raddropdownlist = $find('<%=ddlCampaigns.ClientID %>');
            var selecteditem = raddropdownlist.get_selectedItem().get_value();
            // your existing page
            var url = "ScheduleCampaign.aspx";
            // append value of textbox as querystring
            var newUrl = url + "?p=" + selecteditem;
            // update the src attribute of your iframe with the newUrl
            $('#<%=Iframe2.ClientID%>').attr("src", newUrl);
        }
        function changeActiveIndex(lnk) {
            var wizard = $find("<%= RadWizard1.ClientID %>");
            wizard.set_activeIndex(1);
            //alert($("hdnCampainName").val())

            args.set_cancel(false);
            return 0;
        }


    </script>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <style>
         .rsHeaderTimeline {
             display:none !important;
         }
        .RadDropDownList_Default {
            font-size: 12px !important;
            color: #808080 !important;
            font-family: 'Segoe UI','Century Gothic','Courier New' !important;
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
            top: 810px !important;
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
            width: 730px;
            height: 500px;
            margin-top: -420px;
            padding-left: 50px;
        }

        .content {
            overflow-y: visible !important;
        }

        .modal-backdrop {
            background-color: rgba(0, 0, 0, 0.61);
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            display: none;
        }

        .modal {
            width: 600px;
            height: 400px;
            position: absolute;
            top: 25%;
            z-index: 1020;
            background-color: #FFF;
            border-radius: 6px;
            display: none;
        }

        .modal-header {
            background-color: #ef7c31;
            color: #FFF;
            border-top-right-radius: 5px;
            border-top-left-radius: 5px;
        }

            .modal-header h3 {
                width: 545px;
                margin: 0;
                padding: 0 10px 0 10px;
                line-height: 40px;
            }

                .modal-header h3 .close-modal {
                    float: right;
                    text-decoration: none;
                    color: #FFF;
                }

        .modal-footer {
            background-color: #F1F1F1;
            padding: 0 10px 0 10px;
            line-height: 40px;
            text-align: right;
            border-bottom-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-top: solid 1px #CCC;
        }

        .modal-body {
            padding: 0 10px 0 10px;
            height: 360px;
        }

        .RadWizard_Default.rwzVertical .rwzProgressBar {
            display: none;
        }

        .rwzVertical .rwzBreadCrumb {
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
            margin-top: 335px !important;
            margin-left: -360px !important;
            margin-right: 0px !important;
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

        .RadWizard {
            padding: 0px !important;
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

        .marginTop350 {
            /*margin-top: -360px;*/
        }

        .rwzVertical .rwzBreadCrumb {
            /*margin-top: 350px !important;*/
            width: 360px !important;
        }

        .RadWizard .rwzContent {
            overflow: hidden !important;
            height: 650px !important;
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
        .RadScheduler_Default{
            border: 2px solid #ef7c31 !important;
        }
        .RadScheduler_Default .rsHeader, .RadScheduler_Default .rsHeader ul a:hover, .RadScheduler_Default .rsHeader ul a:hover span, .RadScheduler_Default .rsHeader .rsSelected, .RadScheduler_Default .rsHeader .rsSelected em, .RadScheduler_Default .rsHeader .rsDatePickerActivator, .RadScheduler_Default .rsHeader .rsPrevDay, .RadScheduler_Default .rsHeader .rsNextDay {
            /*background-image: none !important;*/
            font-size: 14px;
        }

            .RadScheduler_Default .rsHeader ul li a:hover {
                background-color: #ef7c31 !important;
            }

        .RadScheduler .rsHeader .rsSelected {
            background-color: #ef7c31 !important;
        }

        .RadScheduler_Default .rsAptIn, .RadScheduler_Default .rsAptMid, .RadScheduler_Default .rsAptContent {
            /*background-color: #ef7c31 !important;
            border-color: #ef7c31 !important;
            background-image: none !important;
            color: #FFF !important;
            font-size: 14px;
            vertical-align: baseline;
            padding: 3px 0 0 8px !important;
            font-weight: bold;*/
        }

        .RadWizard .rwzBreadCrumb .rwzImage {
            float: right !important;
        }

        .marginTop100 {
            margin-top: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:ScriptManager runat="server" ID="sc1"></asp:ScriptManager>
    <div class="bg-text" data-bg-text="Publish">
    </div>
    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always">
        <ContentTemplate>
            <table style="margin-left: 390px">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text="" CssClass="lblTitle" />
                        <asp:Label ID="lblSelectedCampaign" runat="server" Text="" CssClass="lblSelectedCampaign" Visible="false" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="width: 95%">
        <div style="float: left; margin: -45px 0 0 25px">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                width="350" height="350">
                <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                <param name="movie" value="../../Swf/PreviewCampaign.swf" />
                <param name="quality" value="high" />
                <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                <embed src="../../Swf/PreviewCampaign.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                    type="application/x-shockwave-flash" width="350px" height="350px" />
            </object>
        </div>
        <div style="float: left;" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 40px">
                <div>
                    <%-- <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />--%>
                    <%--<telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />--%>
                    <asp:UpdatePanel runat="server" ID="up1" UpdateMode="Always">
                        <ContentTemplate>
                            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                                <AjaxSettings>
                                    <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                        <UpdatedControls>
                                            <telerik:AjaxUpdatedControl ControlID="RadWizard1" />
                                            <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" />
                                            <telerik:AjaxUpdatedControl ControlID="RadScheduler1"></telerik:AjaxUpdatedControl>
                                        </UpdatedControls>
                                    </telerik:AjaxSetting>
                                </AjaxSettings>
                            </telerik:RadAjaxManager>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always">
                        <ContentTemplate>--%>
                            <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" DisplayNavigationButtons="false">
                                <WizardSteps>
                                    <telerik:RadWizardStep Title="&nbsp;&nbsp;&nbsp;&nbsp; View Campaign" ToolTip="This step is to preview campaign" CssClass="loginStep">
                                        <div style="position: relative; background-repeat: repeat; height: 300px; margin-top: 70px;">
                                            <input id="hdnCampaignID" type="hidden" value="0" runat="server">
                                            <asp:GridView ID="grdCampaign" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" ShowHeaderWhenEmpty="True"
                                                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader"
                                                AllowSorting="true" DataKeyNames="CampaignID" OnRowDataBound="grdCampaign_RowDataBound" OnRowCommand="grdCampaign_RowCommand"
                                                Width="350px" OnSorting="grdCampaign_Sorting">
                                                <Columns>
                                                   <asp:TemplateField HeaderText="Campaign Image" ItemStyle-Width="150px" HeaderStyle-Width="180px"  ItemStyle-HorizontalAlign="Center" SortExpression="CampaignName">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgThumbNail" runat="server" ImageUrl='<%# "~/img/" + Eval("FileName") %>' CssClass="thumbNailImage" />
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="200px" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Campaign Name" ControlStyle-Width="400px" SortExpression="CampaignName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CampaignName").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="400px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Video" HeaderStyle-HorizontalAlign="Left" SortExpression="Video">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="Literal1" runat="server"
                                                                Text=''></asp:Literal>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" Width="400px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Publish" HeaderStyle-HorizontalAlign="Center" SortExpression="Publish">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgPublish" runat="server" ImageUrl="~/img/publish.png" Width="20px" Height="20px" OnClientClick="changeActiveIndex(this)" CommandArgument='<%# Eval("CampaignName").ToString()%>' CommandName="Publish"></asp:ImageButton>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="300px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </telerik:RadWizardStep>
                                    <telerik:RadWizardStep Title="&nbsp;&nbsp;&nbsp;&nbsp;Publish Campaign" ToolTip="Manage Channel through Calendar">
                                        <div style="margin: 60px 0 20px 0">
                                            <div style="margin: -35px 0 0 0">
                                                <telerik:RadDropDownList ID="ddlCampaigns" AutoPostBack="true" runat="server" Font-Size="10px" Width="300px" OnSelectedIndexChanged="ddlCampaigns_SelectedIndexChanged" />
                                            </div>
                                            <%--<div style="float: left; margin: -25px 0 0 280px;">
                                                <asp:Label ID="lblCampaignName" runat="server" ForeColor="#808080" Font-Bold="true" Font-Names="'Segoe UI', 'Century Gothic', 'Courier New'" Font-Size="15px" Text="Please select a campaign" />
                                            </div>--%>
                                            <div style="float: right; margin: -55px 355px 0 0">
                                                <asp:Button ID="Button3" runat="server" Text="Schedule Campaign" CssClass="openModal button" OnClientClick="OpenWindow();" /><br />
                                            </div>
                                            <div class="modal" style="left: 650px">
                                                <div class="modal-header">
                                                    <h3>Schedule Campaign<a class="close-modal" href="#">&times;</a></h3>
                                                </div>
                                                <div class="modal-body">
                                                    <iframe style="width: 100%; height: 100%;" id="Iframe2" src="ScheduleCampaign.aspx" runat="server"></iframe>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="Button4" runat="server" Text="OK" CssClass="modalOK close-modal button" />
                                                </div>
                                            </div>
                                            <%--<telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="EndDateTime" DataStartField="StartDateTime"
                                        DataKeyField="CampaignID" DataSubjectField="CampaignName" OnAppointmentCreated="RadScheduler1_AppointmentCreated"
                                        OnDataBound="RadScheduler1_DataBound">
                                    </telerik:RadScheduler>--%>
                                            <div class="demo-container no-bg" style="width: 850px;height:500px">
                                                <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="EndDateTime" DataStartField="StartDateTime"
                                                    DataKeyField="ChannelID" DataSubjectField="ChannelName" OnAppointmentCreated="RadScheduler1_AppointmentCreated"
                                                    OnDataBound="RadScheduler1_DataBound" OnAppointmentInsert="RadScheduler1_AppointmentInsert" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound"
                                                    OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" SelectedView="MonthView" AllowInsert="false" OverflowBehavior="Expand" Height="100%">
                                                    <AdvancedForm Modal="true" EnableTimeZonesEditing="true" />
                                                    <AdvancedEditTemplate>
                                                        <scheduler:AdvancedForm runat="server" ID="AdvancedEditForm1" Mode="Edit" Subject='<%# Bind("Subject") %>'
                                                            Start='<%# Bind("Start") %>' End='<%# Bind("End") %>' />
                                                    </AdvancedEditTemplate>
                                                    <AdvancedInsertTemplate>
                                                        <scheduler:AdvancedForm runat="server" ID="AdvancedInsertForm1" Mode="Insert" Subject='<%# Bind("Subject") %>'
                                                            Start='<%# Bind("Start") %>' End='<%# Bind("End") %>' />
                                                    </AdvancedInsertTemplate>
                                                </telerik:RadScheduler>
                                            </div>
                                        </div>
                                    </telerik:RadWizardStep>
                                </WizardSteps>
                            </telerik:RadWizard>
                      <%--  </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <asp:HiddenField ID="hdnCompanyID" runat="server" />
                    <asp:HiddenField ID="hdnVideoNames" runat="server" />
                    <asp:HiddenField ID="hdnCampainName" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
