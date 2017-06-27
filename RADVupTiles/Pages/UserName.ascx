<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserName.ascx.cs" Inherits="Pages_UserName" %>
<div id="content" style="visibility: hidden">
    <div id="start">
        <asp:Label ID="userCompany" runat="server"></asp:Label>
    </div>
    <div id="user" data-bind="with: user" onclick="ui.settings()">
        <div id="name">
            <div id="firstname" data-bind="text: firstName"></div>
            <div id="lastname" data-bind="text: lastName"></div>
        </div>
        <div id="photo">
            <img src="../img/User No-Frame.png" width="40" height="40" />
        </div>
    </div>
</div>
