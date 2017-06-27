<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="ManageRoles.aspx.cs" Inherits="Pages_UserManagement_ManageRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        div h3 {
            width: 120px !important;
            margin-top: -30px;
            margin-left: 50px;
        }

        .label {
            font-style: normal;
        }

        .breadcrumb {
            min-height: 475px !important;
        }
        #footer, #footer a{
            width: 100%; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" " />
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px; margin: 0px 25px 0 0px;
 background: transparent url(../img/wallpapers/Brushed-Metal.jpg); position: relative; 
 background-repeat: repeat; width: 71%; float: right;height:450px;">
        <h3>Manage Roles</h3>
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
        <div class="content scrollbar" style="width: 750px;margin-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="RoleList" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal"
                            OnRowDeleting="RoleList_RowDeleting" Width="100%"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="#" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <span>
                                            <%#Container.DataItemIndex + 1%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Roles" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField DeleteText="Delete" ShowDeleteButton="True" ControlStyle-CssClass="button" ButtonType="Button"/>
                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>        
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

