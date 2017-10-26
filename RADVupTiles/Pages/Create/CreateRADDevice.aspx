<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CreateRADDevice.aspx.cs" Inherits="Pages_CreateRADDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function deleteConfirm(companyName) {
            var result = confirm('Are you sure you want to delete ?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        div h3 {
            width: 160px;
            margin-top: -30px;
            margin-left: 50px;
        }

        .label {
            font-style: normal;
        }

        .breadcrumb {
            min-height: 475px !important;
        }

        #footer, #footer a {
            width: 100%;
        }
        .Grid th a {
            color:#000000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" " />
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px; margin: 60px 25px 0 0px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg); position: relative; background-repeat: repeat; width: 71%; float: right; height: 450px">
        <h3 style="width: 155px">Create RAD Device</h3>
        <table id="tblRADDevice" runat="server" style="border: 1px solid black; width: 690px;">
            <tr style="padding: 22px 20px 20px 0px">
                <td style="padding-right: 20px; padding-top: 2px; border: 1px solid black">
                    <asp:Label ID="lblRADDeviceName" runat="server" Text="RAD Device Name:" CssClass="label" />
                </td>
                <td style="border: 1px solid black">
                    <asp:TextBox ID="txtRADDeviceName" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr style="padding: 22px 20px 20px 0px">
                <td style="border: 1px solid black">
                    <asp:Label ID="lblRADDeviceInfo" runat="server" Text="RAD Device Information:" CssClass="label" />
                </td>
                <td style="border: 1px solid black">
                    <asp:TextBox ID="txtRADDeviceInfo" runat="server" TextMode="MultiLine" Height="50px" Width="200px" />
                </td>
            </tr>
            <tr style="padding: 22px 20px 20px 0px">
                <td style="border: 1px solid black">
                    <asp:Label ID="lblScreenFlip" runat="server" Text="Screen Flip:" CssClass="label" />
                </td>
                <td style="border: 1px solid black">
                    <asp:DropDownList ID="ddlScreenFlip" runat="server">
                        <asp:ListItem Text="None" Value="None" />
                        <asp:ListItem Text="Horizontal" Value="Horizontal" />
                        <asp:ListItem Text="Vertical" Value="Vertical" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="padding: 22px 20px 20px 0px">
                <td style="border: 1px solid black">
                    <asp:Label ID="lblScreenOrientation" runat="server" Text="Screen Orientation:" CssClass="label" />
                </td>
                <td style="border: 1px solid black">
                    <asp:DropDownList ID="ddlScreenOrientation" runat="server">
                        <asp:ListItem Text="0 degrees" Value="0 degrees" />
                        <asp:ListItem Text="90 degrees" Value="90 degrees" />
                        <asp:ListItem Text="180 degrees" Value="180 degrees" />
                        <asp:ListItem Text="360 degrees" Value="360 degrees" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="padding: 22px 20px 20px 0px">
                <td>
                    <asp:Label ID="lblAddRADDeviceStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAddRADDevice" runat="server" Text="Create RAD Device" CssClass="button" OnClick="btnAddRADDevice_Click" />
                </td>
            </tr>
        </table>
        <div class="content scrollbar" style="width: 850px; height: 300px; margin-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdRADDevice" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="RADDeviceID"
                            AllowSorting="True"
                            OnPageIndexChanging="grdRADDevice_PageIndexChanging"
                            OnSorting="grdRADDevice_Sorting"
                            OnRowCancelingEdit="grdRADDevice_RowCancelingEdit"
                            OnRowDeleting="grdRADDevice_RowDeleting"
                            OnRowEditing="grdRADDevice_RowEditing"
                            OnRowUpdating="grdRADDevice_RowUpdating"
                            OnRowCommand="grdRADDevice_RowCommand"
                            OnRowDataBound="grdRADDevice_RowDataBound"
                            OnRowCreated="grdRADDevice_RowCreated"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader">
                            <Columns>
                                <asp:TemplateField HeaderText="#" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <span>
                                            <%#Container.DataItemIndex + 1%>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RADDeviceID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="txtRADDeviceID" runat="server" Text='<%#Eval("RADDeviceID") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRADDeviceID" runat="server" Width="40px" Text='<%#Eval("RADDeviceID") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RAD Device Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeviceInfo" runat="server" Text='<%#Eval("Name") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDeviceInfo" Width="200px" runat="server" Text='<%#Eval("Name") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescription" Width="200px" runat="server" Text='<%#Eval("Description") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="floatRight" />
                                    <EditItemTemplate>
                                        <%--<asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="button"/>
                                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="button" />--%>
                                        <asp:ImageButton ID="ButtonUpdate" runat="server" CommandName="Update" ImageUrl="~/img/check-mark-3-16.png" />
                                        <asp:ImageButton ID="ButtonCancel" runat="server" CommandName="Cancel" ImageUrl="~/img/x-mark-16.png" CssClass="paddingLeft20" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <%--<asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="button" />
                                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="button" />--%>
                                        <asp:ImageButton ID="ButtonEdit" runat="server" CommandName="Edit" ImageUrl="~/img/edit-2-16.png" />
                                        <asp:ImageButton ID="ButtonDelete" runat="server" CommandName="Delete" ImageUrl="~/img/delete-16.png" CssClass="paddingLeft20" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
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
        <span class="vupCopyright">&copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

