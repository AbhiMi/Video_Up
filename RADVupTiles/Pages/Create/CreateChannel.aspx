<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CreateChannel.aspx.cs" Inherits="Pages_CreateChannel" EnableEventValidation="false" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="scheduler" TagName="AdvancedForm" Src="~/Pages/AdvancedFormCS.ascx" %>

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
    <script>
       <%-- $(document).ready(function () {
            $('<%= imgFileUpload.ClientID %>').change(function () {
            });
        });--%>
        function RefreshPage()//function in parent page
        {
            document.location.reload();
        }
        function ShowText(myFile) {
            var file = myFile.files[0];
            var filename = file.name;
            // alert(filename);
            document.getElementById('lblUpload').innerText = filename;

        }
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
            });
        });
        (function (global, undefined) {
            var TelerikDemo = global.TelerikDemo = {};
            var colorPicker, textBoxNewColor, textBoxColor;

            TelerikDemo.OnClientLoad = function (sender, args) {
                colorPicker = sender;
            };

            TelerikDemo.TextBoxNewColor_OnLoad = function (sender, args) {
                textBoxNewColor = sender;
            };

            TelerikDemo.TextBoxColor_OnLoad = function (sender, args) {
                textBoxColor = sender;
            };

            TelerikDemo.SetColor = function () {
                var newColor = textBoxNewColor.get_value();
                colorPicker.set_selectedColor(newColor);
            };

            TelerikDemo.GetColor = function () {
                var color = colorPicker.get_selectedColor();
                textBoxColor.set_value(color || "No Color!");
            };

            TelerikDemo.ResetColor = function () {
                // set the value to null to select the no color option
                colorPicker.set_selectedColor(null);
            };

            TelerikDemo.ShowPallete = function () {
                colorPicker.showPalette();
            };

            TelerikDemo.HidePallete = function () {
                colorPicker.hidePalette();
            };
        })(window);
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
       <%-- $('#<%=Button3.ClientID%>').live("click", function () {
            // your existing page
            var url = "ScheduleChannel.aspx";
            // append value of textbox as querystring
            var newUrl = url + "?p=" + $('#<%=hdnCampaignID.ClientID%>').val();
            // update the src attribute of your iframe with the newUrl
            $('#<%=Iframe2.ClientID%>').attr("src", newUrl);
        })--%>
        function changeActiveIndex(lnk) {
            var wizard = $find("<%= RadWizard1.ClientID %>");
            wizard.set_activeIndex(1);
            //alert($("hdnCampainName").val())

            args.set_cancel(false);
            return 0;
        }
       <%-- $(document).ready(function () {
            $("#<%=txtChannel.ClientID%>").autocomplete('Search_CS.ashx');
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

        $(function () { SetupFilter("txtChannel", "grdChannels", "Channel Name"); });
    </script>
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        .rsHeaderTimeline {
            display: none !important;
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
            margin-top: 380px !important;
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
            position: relative;
            margin-left: 700px;
            z-index: -1;
            margin-top: -15px;
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

        .RadGrid_Default {
            background: none !important;
            border: none !important;
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
            margin-top: 280px !important;
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
            height: 38px;
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
            height: 850px !important;
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

        .RadScheduler_Default {
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

        .RadWindow_Default {
            border-color: #ef7c31 !important;
            background-color: #ef7c31 !important;
        }

            .RadWindow_Default .rwTitleBar, .RadWindow.rwRoundedCorner .rwTitleBar {
                background-image: linear-gradient(#ef7c31,#ef7c31) !important;
            }

        h6.rwTitle {
            color: #FFFFFF !important;
        }

        .RadWindow .rwTitleWrapper .rwTitle {
            font-size: 1.2em !important;
        }

        .rwStatusBar {
            background-color: #ef7c31 !important;
            border-color: #ef7c31 !important;
        }

        .RadWindow .rwStatusBar input {
            color: #FFFFFF !important;
        }

        .buttonEditDelete {
            background: #808080;
            color: #FFFFFF;
            /*border: solid 2px rgba(127, 128, 159, 1);*/
            border: none;
            border-radius: 5px;
            font-size: 12px;
            font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
            padding: 4px;
            font-weight: bold;
        }
    </style>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function AddNewChannel() {
                window.radopen("AddNewChannel.aspx", "RadChannelDialog");
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="bg-text" data-bg-text="Channel">
    </div>
    <br />
    <table style="margin-left: 390px">
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" CssClass="lblTitle" />
                <asp:Label ID="lblSelectedCampaign" runat="server" Text="" CssClass="lblSelectedCampaign" Visible="false" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnChannelName" runat="server" />
    <%--<asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" " />--%>
    <div style="width: 95%">
        <div style="float: left; margin: 20px 0 0 25px">
            <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                width="350" height="350   ">
                <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                <param name="movie" value="../../Swf/ChannelGuide.swf" />
                <param name="quality" value="high" />
                <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                <embed src="../../Swf/ChannelGuide.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                    type="application/x-shockwave-flash" width="350px" height="350px" />
            </object>
        </div>
        <div style="float: left;" class="RADCycle">
            <div class="swMain" id="wizard" style="margin-top: 150px">
                <div>
                    <telerik:RadSkinManager ID="RadSkinManager2" runat="server" ShowChooser="true" />
                    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="ConfiguratorPanel1">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="RadWizard1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="ConfiguratorPanel1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                    <telerik:AjaxUpdatedControl ControlID="RadColorPicker1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadWizard ID="RadWizard1" runat="server" Height="320px" BackColor="Transparent" DisplayNavigationButtons="false">
                        <WizardSteps>
                            <telerik:RadWizardStep Title="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Channel Guide" ToolTip="Manage Channel through Calendar">

                                <div style="margin: 100px 0 20px 0">
                                    <div style="margin: -35px 0 0 0">
                                        <telerik:RadDropDownList ID="ddlChannels" AutoPostBack="true" runat="server" Width="300px" OnSelectedIndexChanged="ddlChannels_SelectedIndexChanged" />
                                    </div>
                                    <div class="demo-container no-bg" style="width: 850px; height: 500px">
                                        <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="EndDateTime" DataStartField="StartDateTime"
                                            DataKeyField="CampaignID" DataSubjectField="CampaignName" OnAppointmentCreated="RadScheduler1_AppointmentCreated"
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
                            <telerik:RadWizardStep Title="&nbsp;&nbsp;&nbsp;&nbsp; Manage Channel" ToolTip="This step is to select channel">
                                <div style="float: left; position: relative; background-repeat: repeat; height: 400px;">
                                    <div style="margin-top: 100px">
                                        <table style="float: left;">
                                            <tr>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtSearch" placeholder="Search by Channel Name" Width="250px" />
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="btn1" Text="Search" OnClick="btn1_Click" CssClass="button" />
                                                </td>
                                                <td>
                                                    <asp:Button runat="server" ID="ClearSearch" Text="Clear" OnClick="ClearSearch_Click"
                                                        CssClass="button" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSearchText" runat="server" ForeColor="#808080" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                    <div style="width: 250px"></div>
                                                </td>
                                                <td style="width: 30px; height: 30px; cursor: pointer; margin-left: 200px" onclick="AddNewChannel();">
                                                    <img src="../../img/Add.png">
                                                </td>
                                                <td>
                                                    <h1 style="color: #808080; font-size: 17px; font-family: 'Segoe UI', 'Century Gothic', 'Courier New'">Add New</h1>
                                                </td>
                                            </tr>
                                        </table>
                                        <div>
                                            <input id="hdnCampaignID" type="hidden" value="0" runat="server">
                                            <asp:GridView ID="grdChannel" runat="server" AutoGenerateColumns="false"
                                                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="ChannelID" AllowPaging="true"
                                                AllowSorting="True" PageSize="10"
                                                OnPageIndexChanging="grdChannel_PageIndexChanging"
                                                OnSorting="grdChannel_Sorting"
                                                OnRowCancelingEdit="grdChannel_RowCancelingEdit"
                                                OnRowDeleting="grdChannel_RowDeleting"
                                                OnRowEditing="grdChannel_RowEditing"
                                                OnRowUpdating="grdChannel_RowUpdating"
                                                OnRowCommand="grdChannel_RowCommand"
                                                OnRowDataBound="grdChannel_RowDataBound"
                                                OnSelectedIndexChanged="grdChannel_SelectedIndexChanged" PagerStyle-BackColor="#ef7c31"
                                                CssClass="Grid" AlternatingRowStyle-CssClass="alt" HeaderStyle-CssClass="FixedHeader"
                                                Width="775px" EmptyDataText="No Channels Found.">
                                                <PagerStyle BackColor="#ef7c31" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" />
                                                <SelectedRowStyle BackColor="#cbcbcb" Font-Bold="True" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="#" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" SortExpression="ChannelID">
                                                        <ItemTemplate>
                                                            <span>
                                                                <%#Container.DataItemIndex + 1%>
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ChannelID" Visible="false" SortExpression="ChannelID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtChannelID" runat="server" Text='<%#Eval("ChannelID") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblChannelID" runat="server" Width="40px" Text='<%#Eval("ChannelID") %>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Channel Image" ItemStyle-HorizontalAlign="center" SortExpression="ChannelID">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgChannelName" runat="server" ImageUrl='<%# "~/img/"+Eval("FileName") %>' Width="20px" Height="20px" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <div class="mini_file_upload">
                                                                <asp:FileUpload ID="imgFileUpload" runat="server" CssClass="fileUploaderBtn" />
                                                            </div>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Channel Color" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" SortExpression="Color">
                                                        <ItemTemplate>
                                                            <telerik:RadColorPicker RenderMode="Lightweight" ShowIcon="true" ID="rdDefaultColor" runat="server" PaletteModes="All"
                                                                OnClientLoad="TelerikDemo.OnClientLoad">
                                                            </telerik:RadColorPicker>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <telerik:RadColorPicker RenderMode="Lightweight" ShowIcon="true" ID="rdDefaultColor" runat="server" PaletteModes="All"
                                                                OnClientLoad="TelerikDemo.OnClientLoad">
                                                            </telerik:RadColorPicker>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Channel Name" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" SortExpression="ChannelName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblChannelName" runat="server" Text='<%#Eval("ChannelName") %>' />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtChannelName" Width="250px" runat="server" Text='<%#Eval("ChannelName") %>' />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></asp:BoundField>
                                                    <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="buttonEditDelete" CausesValidation="false" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" CssClass="buttonEditDelete" CausesValidation="false" />
                                                            <p></p>
                                                            <p></p>
                                                            <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="buttonEditDelete" CausesValidation="false" />
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <span onclick="return confirm('Are you sure to delete?')">
                                                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CssClass="buttonEditDelete" CommandName="Delete" CausesValidation="false" />
                                                            </span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                            </telerik:RadWizardStep>
                        </WizardSteps>
                    </telerik:RadWizard>
                    <asp:HiddenField ID="hdnCompanyID" runat="server" />
                    <asp:HiddenField ID="hdnVideoNames" runat="server" />
                    <asp:HiddenField ID="hdnCampainName" runat="server" />
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
            <telerik:RadWindow RenderMode="Lightweight" ID="RadChannelDialog" runat="server" Height="320px"
                Width="500px" Left="10px" ReloadOnShow="true" ShowContentDuringLoad="false" OnClientClose="RefreshPage"
                Modal="true">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
