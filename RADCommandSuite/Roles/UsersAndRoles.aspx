<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="UsersAndRoles.aspx.cs" Inherits="Roles_UsersAndRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="padding: 20px; border: 1px solid #428bca; margin-top: 20px">
        <h2>User Role Management</h2>
        <div style="width: 100%;min-height:300px">
            <div style="float:left;width:500px">
                <h3>Manage Roles By User</h3>
                <p>
                    <b>Select a User:</b>
                    <asp:DropDownList ID="UserList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="UserList_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                </p>
                <asp:Repeater ID="UsersRoleList" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true"
                            Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckedChanged" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div style="float:left">
                <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
                <h3>Manage Users By Role</h3>
                <p>
                    <b>Select a Role:</b>

                    <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RoleList_SelectedIndexChanged"></asp:DropDownList>
                </p>
                <p>
                    <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No users belong to this role." OnRowDeleting="RolesUserList_RowDeleting"
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="410px">
                        <Columns>
                            <asp:TemplateField HeaderText="Users">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="UserNameLabel"
                                        Text='<%# Container.DataItem %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" HeaderText="Remove" ButtonType="Link" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </p>
                <p>
                    <b>UserName:</b>
                    <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="AddUserToRoleButton" runat="server" Text="Add User to Role" OnClick="AddUserToRoleButton_Click" class="btn btn-primary btn-large" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>

