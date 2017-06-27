<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="UserPermissions.aspx.cs" Inherits="Pages_UserManagement_UserPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        .breadcrumb {
            margin-left: 20px;
            width: 16%;
        }

        .SiteMap {
            margin-left: -257px;
        }

        .h3 {
            margin-top: -20px;
            width:190px !important;
        }
        input[type="checkbox"] {
            float:left;
            margin-right:5px !important;
        }
        body{
            color:#343553;
        }
        #footer, #footer a{
            width: 100%; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" " />
    <div style="padding: 10px; border-radius: 10px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg); position: relative; background-repeat: repeat; width: 95%; margin-top: 25px">
        <div style="float: right; border: 3px solid Gray; min-height: 425px; padding: 10px; border-radius: 10px; width: 30%; float: left; margin: 50px 0 0 -10px">
            <h3 class="h3">Manage Roles By User</h3>
            <b>Select a User:</b>
            <asp:DropDownList ID="UserList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="UserList_SelectedIndexChanged" ForeColor="#343553">
            </asp:DropDownList>
            <br />
            <div style="width:300px;margin-top:20px">
            <asp:Repeater ID="UsersRoleList" runat="server">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true"
                        Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckedChanged" />
                    <br />
                </ItemTemplate>
            </asp:Repeater>
                </div>
        </div>
        </div>
        <div style="float: left; width: 35%; border: 3px solid Gray; min-height: 425px; border-radius: 10px; padding: 10px;margin: 40px 0 0 20px">
            <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
            <h3 class="h3" style="background-color: rgba(206, 206, 204, 1)">Manage Users By Role</h3>
            <p>
                <b>Select a Role:</b>

                <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RoleList_SelectedIndexChanged" ForeColor="#343553"></asp:DropDownList>
            </p>
            <p>
                <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False"
                    EmptyDataText="No users belong to this role." OnRowDeleting="RolesUserList_RowDeleting"
                    CellPadding="4" ForeColor="#343553" GridLines="None" Width="410px" CssClass="Grid">
                    <Columns>
                        <asp:TemplateField HeaderText="Users" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="UserNameLabel"
                                    Text='<%# Container.DataItem %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" HeaderText="Remove" ButtonType="Link" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </p>
            <p>
                <b>UserName:</b>
                <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Button ID="AddUserToRoleButton" runat="server" Text="Add User to Role" OnClick="AddUserToRoleButton_Click" class="button" />
            </p>
        </div>
     <div id="footer">
        <span class="vupFooterText"><a href="..\ContactUs.aspx">Contact Us</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Privacy</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Terms of Use</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupCopyright"> &copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

