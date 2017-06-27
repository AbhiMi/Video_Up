<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewLocation.aspx.cs" Inherits="Pages_AddNewLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Location</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <%--<script src="../js/jquery.smartWizard-2.0.min.js"></script>
    <script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../css/demo_style.css" rel="stylesheet" />
    <link href="../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../js/jquery-1.4.2.min.js"></script>
    <script src="../js/jquery.smartWizard-2.0.min.js"></script>
    <script src="../Scripts/jquery.autocomplete.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>--%>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        input[type=text] {
            width: 197px;
        }

        .txtWidth {
            width: 160px;
            font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
            font-size:14px;
        }

        div h3 {
            width: 140px;
            margin-top: -30px;
            margin-left: 50px;
        }

        .marginleftImages {
            margin-left: 100px;
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
            display: table;
            table-layout: fixed;
            margin-top: 280px !important;
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

        .marginTop60 {
            margin-top: 60px;
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

        ui-tagging {
        position: relative;
        border: 1px solid #B4BBCD;
        height: auto;
    }
    
    .ui-tagging .ui-tagging-highlight {
        position: absolute;
        padding: 5px;
        overflow: hidden;
    }
    .ui-tagging .ui-tagging-highlight div {
        color: transparent;
        font-size: 13px;
        line-height: 18px;
        white-space: pre-wrap;
    }
    
    .ui-tagging .ui-tagging-wrap {
        position: relative;
        padding: 5px;
        overflow: hidden;
        zoom: 1;
        border: 0;
    }
    
    .ui-tagging div > span {
        background-color: #D8DFEA;
        font-weight: normal !important;
    }
    
    .ui-tagging textarea {
        display: block;
        font-family: "lucida grande",tahoma,verdana,arial,sans-serif;
        background: transparent;
        border-width: 0;
        font-size: 13px;
        height: 18px;
        outline: none;
        resize: none;
        vertical-align: top;
        width: 100%;
        line-height: 18px;
        overflow: hidden;
    }
    
    .ui-autocomplete {
        font-size: 13px;
        background-color: white;
        border: 1px solid black;
        margin-bottom: -5px;
        width: 0;
    }
    </style>
    <script type="text/javascript">
        function dialogOpen(option) {
            var ddlregiontext;
            if (option == "1")
                ddlregiontext = $('#ddlRegion :selected').text();
            else
                ddlregiontext = "";
            //var a = document.getElementById('hdnCompnayID').value;
            //window.radopen("AddRegionArea.aspx?CompanyID=" + a + "," + ddlregiontext, "RadDeviceDialog");
            window.radopen("AddRegionArea.aspx?CompanyID=" + 4 + "," + ddlregiontext, "RadDeviceDialog");
            return false;
        }
        (function($){
    
            $.widget("ui.tagging", {
                // default options
                options: {
                    source: [],
                    maxItemDisplay: 3,
                    autosize: true,
                    animateResize: false,
                    animateDuration: 50
                },
                _create: function() {
                    var self = this;
                
                    this.activeSearch = false;
                    this.searchTerm = "";
                    this.beginFrom = 0;
    
                    this.wrapper = $("<div>")
                        .addClass("ui-tagging-wrap");
                
                    this.highlight = $("<div></div>");
                
                    this.highlightWrapper = $("<span></span>")
                        .addClass("ui-corner-all");
    
                    this.highlightContainer = $("<div>")
                        .addClass("ui-tagging-highlight")
                        .append(this.highlight);
    
                    this.meta = $("<input>")
                        .attr("type", "hidden")
                        .addClass("ui-tagging-meta");
    
                    this.container = $("<div></div>")
                        .width(this.element.width())
                        .insertBefore(this.element)
                        .addClass("ui-tagging")
                        .append(
                            this.highlightContainer, 
                            this.element.wrap(this.wrapper).parent(), 
                            this.meta
                        );
                
                    var initialHeight = this.element.height();
                
                    this.element.height(this.element.css('lineHeight'));
                
                    this.element.keypress(function(e) {
                        // activate on @
                        if (e.which == 64 && !self.activeSearch) {
                            self.activeSearch = true;
                            self.beginFrom = e.target.selectionStart + 1;
                        }
                        // deactivate on space
                        if (e.which == 32 && self.activeSearch) {
                            self.activeSearch = false;
                        }
                    }).bind("expand keyup keydown change", function(e) {
                        var cur = self.highlight.find("span"),
                            val = self.element.val(),
                            prevHeight = self.element.height(),
                            rowHeight = self.element.css('lineHeight'),
                            newHeight = 0;
                        cur.each(function(i) {
                            var s = $(this);
                            val = val.replace(s.text(), $("<div>").append(s).html());
                        });
                        self.highlight.html(val);
                        newHeight = self.element.height(rowHeight)[0].scrollHeight;
                        self.element.height(prevHeight);
                        if (newHeight < initialHeight) {
                            newHeight = initialHeight;
                        }
                        if (!$.browser.mozilla) {
                            if (self.element.css('paddingBottom') || self.element.css('paddingTop')) {
                                var padInt =
                                    parseInt(self.element.css('paddingBottom').replace('px', '')) + 
                                    parseInt(self.element.css('paddingTop').replace('px', ''));
                                newHeight -= padInt;
                            }
                        }
                        self.options.animateResize ?
                            self.element.stop(true, true).animate({
                                height: newHeight
                            }, self.options.animateDuration) : 
                            self.element.height(newHeight);
                    
                        var widget = self.element.autocomplete("widget");
                        widget.position({
                            my: "left top",
                            at: "left bottom",
                            of: self.container
                        }).width(self.container.width()-4);
                    
                    }).autocomplete({
                        minLength: 0,
                        delay: 0,
                        maxDisplay: this.options.maxItemDisplay,
                        open: function(event, ui) {
                            var widget = $(this).autocomplete("widget");
                            widget.position({
                                my: "left top",
                                at: "left bottom",
                                of: self.container
                            }).width(self.container.width()-4);
                        },
                        source: function(request, response) {
                            if (self.activeSearch) {
                                self.searchTerm = request.term.substring(self.beginFrom); 
                                if (request.term.substring(self.beginFrom - 1, self.beginFrom) != "@") {
                                    self.activeSearch = false;
                                    self.beginFrom = 0;
                                    self.searchTerm = "";
                                }
                                if (self.searchTerm != "") {
                                
                                    if ($.type(self.options.source) == "function") {
                                        self.options.source(request, response);                   
                                    } else {
                                        var re = new RegExp("^" + escape(self.searchTerm) + ".+", "i");
                                        var matches = [];
                                        $.each(self.options.source, function() {
                                            if (this.label.match(re)) {
                                                matches.push(this);
                                            }
                                        });
                                        response(matches);
                                    }
                                }
                            }
                        },
                        focus: function() {
                            // prevent value inserted on focus
                            return false;
                        },
                        select: function(event, ui) {
                            self.activeSearch = false;
                            //console.log("@"+searchTerm, ui.item.label);
                            this.value = this.value.replace("@" + self.searchTerm, ui.item.label) + ' ';
                            self.highlight.html(
                                self.highlight.html()
                                    .replace("@" + self.searchTerm,
                                             $("<div>").append(
                                                 self.highlightWrapper
                                                     .text(ui.item.label)
                                                     .clone()
                                             ).html()+' ')
                            );
                            
                            self.meta.val((self.meta.val() + " @[" + ui.item.value + ":]").trim());
                            return false;
                        }
                    });
    
                }
            });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 10px; margin-right: 10px; margin-top: 10px; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
            <asp:Label ID="lblMessage" runat="server" />
            <table style="border: 1px solid gray; width: 100%;" cellpadding="5">
                            <tr>
                                <td align="right" style="margin-right:10px;width:200px">Location Name:</td>
                                <td>
                                    <asp:TextBox ID="txtLocation" runat="server" Width="136px" EnableViewState="true" CssClass="txtWidth"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLocation" ErrorMessage="*" ForeColor="Red" />
                                </td>
                            </tr>
                    <tr>
                        <td align="right" style="margin-right:10px;width:200px">Address:</td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="txtWidth" EnableViewState="true"  />
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" /></td>
                    </tr>
                    <tr>
                        <td align="right" style="margin-right:10px">Country:</td>
                        <td>
                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="txtWidth">
                                <asp:ListItem Text="United States" Value="United States" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="margin-right:10px">State:</td>
                        <td>
                            <asp:DropDownList ID="ddlState" runat="server" CssClass="txtWidth" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="margin-right:10px">Zipcode:</td>
                        <td>
                            <asp:TextBox ID="txtZipCode" runat="server" Width="136px" EnableViewState="true" CssClass="txtWidth" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtZipCode" ErrorMessage="*" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="margin-right:10px">Region Name:</td>
                        <td>
                            <asp:DropDownList ID="ddlRegion" runat="server" DataTextField="RegionName" DataValueField="RegionID" CssClass="txtWidth" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="margin-right:10px">Area Name:</td>
                        <td>
                            <asp:DropDownList ID="ddlArea" runat="server" DataTextField="AreaName" DataValueField="AreaID" CssClass="txtWidth" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="margin-right:10px">Custom Tags:</td>
                        <td>
                            <asp:TextBox ID="txtCustomeTags" runat="server" Width="136px" EnableViewState="true" CssClass="txtWidth" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCustomeTags" ErrorMessage="*" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <div>
                                <asp:Button ID="btnSave" runat="server" CssClass="button" OnClick="btnSave_Click" Text="SAVE" />
                                <asp:Button ID="btnReset" runat="server" CausesValidation="false" CssClass="button" OnClick="btnReset_Click" Text="RESET" />
                            </div>
                        </td>
                    </tr>
            </table>
        </div>
    </form>
</body>
</html>
