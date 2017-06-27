<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="UserMgmt.aspx.cs" Inherits="Pages_UserMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="body" class="unselectable" style="margin-top:50px">
        <table style="width: 800px; margin: 25px">
            <tr>
                <td>
                    <div style="width: 300px; height: 300px; margin-right: 10px;padding: 30px 0 0 40px; border: 3px solid black; border-radius: 10px; -webkit-border-radius: 10px; -o-border-radius: 10px; -moz-border-radius: 10px">
                        <a href="ManageRoles.aspx">
                            <img src="../../img/Question.png" />
                        </a>
                    </div>
                        <p style="margin-left: 100px"><span style="font-weight: bold">Manage Roles</span></p>

                </td>
                <td style="width: 300px; height: 300px">
                    <div style="width: 300px; height: 300px; padding: 30px 0 0 40px; margin-right: 10px; border: 3px solid black; border-radius: 10px; -webkit-border-radius: 10px; -o-border-radius: 10px; -moz-border-radius: 10px">
                        <a href="UserPermissions.aspx">
                            <img src="../../img/Question.png" />
                        </a>
                    </div>
                        <p style="margin-left: 100px"><span style="font-weight: bold">Users & Roles</span></p>
                </td>
                <td>
                    <div style="width: 300px; height: 300px;padding: 30px 0 0 40px; margin-right: 10px; border: 3px solid black; border-radius: 10px; -webkit-border-radius: 10px; -o-border-radius: 10px; -moz-border-radius: 10px">
                        <a href="ManageUserPermissions">
                            <img src="../../img/Question.png" />
                        </a>
                    </div>
                        <p style="margin-left: 100px"><span style="font-weight: bold">Manage User Permissions</span></p>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

