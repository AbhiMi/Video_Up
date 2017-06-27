﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/VideoUpTile.master" %>
<%@ OutputCache NoStore="true" Location="None"  %>

<asp:Content ContentPlaceHolderID="scripts" runat="server">
    
<% if (Request.IsLocal) { %>    
    <!-- 
        If you change any of the below javascript files, make sure you run the Combine.bat
        file in the /js folder to generate the CombinedDashboard.js file again. And then don't
        forget to update the ?v=14#. Otherwise user's will have cached copies in their browser
        and won't get the newly deployed file. -->
    <script type="text/javascript" src="js/TheCore.js?v=14"></script>
    <script type="text/javascript" src="tiles/tiles.js?v=14"></script>
    <script type="text/javascript" src="js/Dashboard.js?v=14"></script>
    
<% } else { %>    
    <script type="text/javascript" src="js/CombinedDashboard.js?v=14"></script>
<% } %>

    <script type="text/javascript">
        $(document).ready(function(){
            <%= GetAlerts() %>
            });
    </script>
    
</asp:Content>

<asp:Content ContentPlaceHolderID="body" runat="server">
    <div id="body" class="unselectable">
       <div id="content" style="visibility: hidden">
            <div id="start" data-bind="text: title"></div>
            <div id="user" data-bind="with: user" onclick="ui.settings()">
                <div id="name">
                    <div id="firstname" data-bind="text: firstName">Abhishek</div>
                    <div id="lastname" data-bind="text: lastName">Mishra</div>
                </div>
                <div id="photo">
                    <img src="img/User No-Frame.png" data-bind="attr: { src: photo }" width="40" height="40" />
                </div>
            </div>
            <div id="browser_incompatible" class="alert">
                <button class="close" data-dismiss="alert">×</button>
                <strong>Warning!</strong>
                Your browser is incompatible with Video-Up. Please use Internet Explorer 9+, Chrome, Firefox or Safari.
            </div>
            <div id="CombinedScriptAlert" class="alert">
                <button class="close" data-dismiss="alert">×</button>
                <strong>Warning!</strong>
                Combined javascript files are outdated. 
                Please retun the js\Combine.bat file. 
                Otherwise it won't work when you will deploy on a server.
            </div>
            <div id="metro-sections-container" class="metro">
                
                <div class="metro-sections" data-bind="foreach: sections">
                    <%--<div class="metro-section" data-bind="attr: {id : uniqueId}, foreach: sortedTiles">--%>
                    <div class="metro-section" data-bind="sortable: { data: tiles }">
                        <div data-bind="attr: { id: uniqueId, 'class': tileClasses }">
                            
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
                        
                    </div>
                </div>
            
                <div id="trash" class="trashcan" data-bind="sortable: { data: trash }"></div>
            </div>
        </div>
        </div>

        
    


</asp:Content>
