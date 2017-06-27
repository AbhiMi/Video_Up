<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="CreateChannel.aspx.cs" Inherits="Master_CreateChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
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
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px">
        <table>
            <tr>
                <td style="padding-right: 20px; padding-top: 2px">
                    <asp:TextBox ID="txtCreateChannel" runat="server" />
                </td>
                <td style="padding-right: 20px; float: left">
                    <asp:Button ID="btnCreateChannel" runat="server" Text="Create Channel" class="btn btn-primary btn-large" OnClick="btnCreateChannel_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCreateChannelStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <div style="padding-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdChannel" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="ChannelID"
                            AllowPaging="True" AllowSorting="True" PageSize="5"
                            OnPageIndexChanging="grdChannel_PageIndexChanging"
                            OnSorting="grdChannel_Sorting"
                            OnRowCancelingEdit="grdChannel_RowCancelingEdit"
                            OnRowDeleting="grdChannel_RowDeleting"
                            OnRowEditing="grdChannel_RowEditing"
                            OnRowUpdating="grdChannel_RowUpdating"
                            OnRowCommand="grdChannel_RowCommand"
                            OnRowDataBound="grdChannel_RowDataBound"
                            OnRowCreated="grdChannel_RowCreated"
                            CssClass="datatable">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            <Columns>
                                <asp:TemplateField HeaderText="ChannelID" Visible="false" SortExpression="ChannelID">
                                    <ItemTemplate>
                                        <asp:Label ID="txtChannelID" runat="server" Text='<%#Eval("ChannelID") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblChannelID" runat="server" Width="40px" Text='<%#Eval("ChannelID") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Channel Name" SortExpression="ChannelName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChannelName" runat="server" Text='<%#Eval("ChannelName") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtChannelName" Width="270px" runat="server" Text='<%#Eval("ChannelName") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="floatRight" />
                                    <EditItemTemplate>
                                        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" class="btn btn-primary btn-large" />
                                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-primary btn-large" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" class="btn btn-primary btn-large" />
                                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" class="btn btn-primary btn-large" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="gridview"></PagerStyle>
                            <SortedAscendingHeaderStyle CssClass="sortasc" />
                            <SortedDescendingHeaderStyle CssClass="sortdesc" />
                        </asp:GridView>
                        <div style="color: #FFFFFF; font-weight: bold; background-color: #507CD1; text-align: center; padding-top: 5px">
                            <i>You are viewing page
                        <%=grdChannel.PageIndex + 1%> of
                        <%=grdChannel.PageCount%>
                            </i>
                        </div>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

