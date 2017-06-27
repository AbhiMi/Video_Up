<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppStore.aspx.cs" Inherits="Tiles_AppStore" MasterPageFile="VideoUpTile.master" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" type="text/css" href="css/AppStore.css?v=14" /> 
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="scripts">
   <script type="text/javascript" src="js/TheCore.js?v=14"></script>
    <script type="text/javascript" src="Tiles/AppStoreTiles.js?v=14"></script>
    <script type="text/javascript" src="js/AppStore.js?v=14"></script>       
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <div id="body" class="unselectable">
        <div id="navbar" class="navbar navbar-fixed-top navbar-inverse">
            <div class="navbar-inner">
                <div class="container">                    
                    <div class="nav-collapse collapse">
                        <ul class="nav">
                            <li class="active">                                
                                <a class="brand" href="?"><img src="img/avatar474_2.gif" style="max-height: 20px; margin-top: -2px; margin-right:5px; vertical-align: middle" />Video-Up</a>
                            </li>
                            <li><a class="active" href="?"><i class="icon-white icon-th-large"></i>Dashboard</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div id="content" style="visibility: hidden">
            <a class="backbutton" href="Default.aspx">
                <img src="img/Left.png" />
            </a>
            
            <div id="metro-sections-container" class="metro">
                <div class="metro-sections" data-bind="foreach: sections">                   
                    <div class="metro-section" data-bind="attr: {id : uniqueId}">
                        <div class="metro-section-title" data-bind="text: name"></div>
                        <!-- ko foreach: tiles -->
                            <div data-bind="attr: { id: uniqueId, 'class': tileClasses }">
                                <b class="check"></b>
                                <!-- ko if: tileImage -->
                                <div class="tile-image">
                                    <img data-bind="attr: { src: tileImage }" src="img/Internet%20Explorer.png" />
                                </div>
                                <!-- /ko -->
                                <!-- ko if: iconSrc -->
                                <!-- ko if: slides().length == 0 -->
                                <div data-bind="attr: { 'class': iconClasses }">
                                    <img data-bind="attr: { src: iconSrc }" src="img/Internet%20Explorer.png" />
                                </div>
                                <!-- /ko -->
                                <!-- /ko -->
                                <div data-bind="foreach: slides">
                                    <div class="tile-content-main">
                                        <div data-bind="html: $data">
                                        </div>
                                    </div>
                                </div>
                                <!-- ko if: label -->
                                <span class="tile-label" data-bind="html: label">Label</span>
                                <!-- /ko -->
                                <!-- ko if: counter -->
                                <span class="tile-counter" data-bind="html: counter">10</span>
                                <!-- /ko -->
                                <!-- ko if: subContent -->
                                <div data-bind="attr: { 'class': subContentClasses }, html: subContent">
                                    subContent
                                </div>
                                <!-- /ko -->
                            </div>
                        <!-- /ko -->
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>