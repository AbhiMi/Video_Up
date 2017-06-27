<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="SetupRADDevice.aspx.cs" Inherits="Pages_SetupRADDevice" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Pages/UserName.ascx" TagPrefix="uc1" TagName="UserName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" />
    <div id="content">
        <uc1:UserName runat="server" ID="UserName" />
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Wireless Name (SSID)"></asp:Label></td>
            <td>
                <telerik:RadComboBox RenderMode="Lightweight" ID="lstNetworks" runat="server" Width="305"
                    ChangeTextOnKeyBoardNavigation="false">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblConnType" runat="server" Text="Connection Type"></asp:Label>
            </td>
            <td>
                <telerik:RadDropDownList runat="server" ID="ddlConnType" RenderMode="Lightweight" Width="305">
                    <Items>
                        <telerik:DropDownListItem runat="server" Text="WiFi"/>
                        <telerik:DropDownListItem runat="server" Text="Ethernet" />
                    </Items>
                    
                </telerik:RadDropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label></td>
            <td>
                <telerik:RadTextBox ID="networkPassword" RenderMode="Lightweight" Width="305" runat="server"></telerik:RadTextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Company Encrypted ID:"></asp:Label></td>
            <td>
                <telerik:RadTextBox ID="companyPass" ReadOnly="true" RenderMode="Lightweight" Width="305" runat="server"></telerik:RadTextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <telerik:RadButton ID="btnGenerateConfig" Text="Generate Config" runat="server" OnClick="btnGenerateConfig_Click"></telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
    <% if (Request.IsLocal) 
       { %>
    <!-- 
        If you change any of the below javascript files, make sure you run the Combine.bat
        file in the /js folder to generate the CombinedDashboard.js file again. And then don't
        forget to update the ?v=14#. Otherwise user's will have cached copies in their browser
        and won't get the newly deployed file. -->
    <script type="text/javascript" src="../js/TheCore.js?v=14"></script>
    <script type="text/javascript" src="../tiles/tiles.js?v=14"></script>
    <script type="text/javascript" src="../js/Dashboard.js?v=14"></script>

    <% }
       else
       { %>
    <script type="text/javascript" src="../js/CombinedDashboard.js?v=14"></script>
    <% } %>
</asp:Content>

