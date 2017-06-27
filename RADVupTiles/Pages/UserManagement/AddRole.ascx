<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddRole.ascx.cs" Inherits="Pages_UserManagement_AddRole" %>
<table style="border: 1px solid black; width: 690px;">
    <tr style="border: 1px solid black">
        <td style="padding-right: 20px; padding-top: 2px; border: 1px solid black">
            <asp:Label ID="lblCreateNewRole" runat="server" Text="Create a New Role:" />
        </td>
        <td style="border: 1px solid black">
            <asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td style="float: left; margin-top: 10px">
            <asp:Button ID="CreateRoleButton" runat="server" Text="Create Role" CssClass="button" OnClick="CreateRoleButton_Click" class="btn btn-primary btn-large" />
        </td>
    </tr>
</table>
