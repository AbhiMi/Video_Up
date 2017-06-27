<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="HowitWorks.aspx.cs" Inherits="Pages_HowitWorks" %>

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
        .test {
            margin-top: 210px;
        }

        .da-slider {
            margin-left: 30px;
            width: 95%;
            background: #87c2f0;
            border-top: 8px solid #87c2f0;
            border-bottom: 8px solid #87c2f0;
        }

        .anchor {
            font-size: 20px !important;
            text-decoration: underline;
            padding: 10px 20px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px solid #ef7c31;
            background: -moz-linear-gradient( top, #ef7c31 0%, #ef7c31);
            background: -webkit-gradient( linear, left top, left bottom, from(#ef7c31), to(#ef7c31));
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: 14px;
            text-shadow: 0px 1px 2px rgba(000,000,000,0.7);
            text-decoration: none;
            
        }

            .anchor:hover {
                background: -moz-linear-gradient( top, #87c2f0 0%, #4281b9);
                background: -webkit-gradient( linear, left top, left bottom, from(#87c2f0), to(#4281b9));
                color: #FFFFFF;
                border: 1px solid #1f5d9b;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="width: 95%">
        <div style="float: left; margin: -25px 0 0 10px">
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
        <div style="float:left;margin-top:-35px; margin-left:-125px">
            <ul style="margin-top:30px; position:relative; left:20%;">
                    <li style="float:left;list-style-type:none;"><a style="margin-right:30px;" href="Pages/Retailers.aspx" class="anchor">Retailers</a></li>
                    <li style="float:left;list-style-type:none;"><a style="margin-right:30px;" href="Pages/ProductManufacturers.aspx" class="anchor">Product Manufactuers</a></li>
                    <li style="float:left;list-style-type:none;"><a style="margin-right:30px;" href="Pages/Entertainment.aspx" class="anchor">Entertainment</a></li>
                    <li style="float:left;list-style-type:none;"><a style="margin-right:30px;" href="Pages/Service.aspx" class="anchor">Service</a></li>
            </ul>
        </div>
     </div>
    <div style="float:left;margin-top:135px;margin-right:50px">
        How it works content comes here......
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

