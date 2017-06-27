<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="CreatePlayList.aspx.cs" Inherits="Master_CreatePlayList" %>

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
                    <asp:TextBox ID="txtCreatePlayList" runat="server" />
                </td>
                <td style="padding-right: 20px; float: left">
                    <asp:Button ID="btnCreatePlayList" runat="server" Text="Create PlayList" class="btn btn-primary btn-large" OnClick="btnCreatePlayList_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCreatePlayListStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <div style="padding-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdPlayList" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="PlayListID"
                            AllowPaging="True" AllowSorting="True" PageSize="5" Width="450px"
                            OnPageIndexChanging="grdPlayList_PageIndexChanging"
                            OnSorting="grdPlayList_Sorting"
                            OnRowCancelingEdit="grdPlayList_RowCancelingEdit"
                            OnRowDeleting="grdPlayList_RowDeleting"
                            OnRowEditing="grdPlayList_RowEditing"
                            OnRowUpdating="grdPlayList_RowUpdating"
                            OnRowCommand="grdPlayList_RowCommand"
                            OnRowDataBound="grdPlayList_RowDataBound" 
                            OnRowCreated="grdPlayList_RowCreated"
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
                                <asp:TemplateField HeaderText="PlayListID" Visible="false" SortExpression="PlayListID">
                                    <ItemTemplate>
                                        <asp:Label ID="txtPlayListID" runat="server" Text='<%#Eval("PlayListID") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPlayListID" runat="server" Width="40px" Text='<%#Eval("PlayListID") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PlayList Name" SortExpression="PlayListName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlayListName" runat="server" Text='<%#Eval("PlayListName") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPlayListName" Width="270px" runat="server" Text='<%#Eval("PlayListName") %>' />
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
                            <pagerstyle cssclass="gridview"></pagerstyle>
                            <SortedAscendingHeaderStyle CssClass="sortasc" />
                            <SortedDescendingHeaderStyle CssClass="sortdesc" />
                        </asp:GridView>
                        <div style="color: #FFFFFF; font-weight: bold;background-color:#507CD1;text-align:center;padding-top:5px">
                            <i>You are viewing page
                             <%=grdPlayList.PageIndex + 1%> of
                             <%=grdPlayList.PageCount%>
                            </i>
                        </div>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

