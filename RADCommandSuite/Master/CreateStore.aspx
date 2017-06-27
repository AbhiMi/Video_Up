<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="CreateStore.aspx.cs" Inherits="Master_CreateStore" %>

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
        <table style="width: 30%;">
            <tr style="margin-bottom: 10px">
                <td>StoreName: </td>
                <td>
                    <asp:TextBox ID="txtCreateStore" runat="server" /></td>

            </tr>
            <tr style="margin-bottom: 10px">
                <td>Location:</td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" /></td>
            </tr>
            <tr style="margin-bottom: 10px">
                <td>Company:</td>
                <td>
                    <asp:DropDownList ID="ddlCompanies" runat="server" DataTextField="CompanyName" DataValueField="CompanyID" />
                </td>
            </tr>
            <tr style="margin-top: 10px">
                <td></td>
                <td><asp:Button ID="btnCreatePlayList" runat="server" Text="Create Store" class="btn btn-primary btn-large" OnClick="btnCreateStore_Click" /></td>
            </tr>
            <tr style="margin-bottom: 10px">
                <td>
                    <asp:Label ID="lblCreateStoreStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <div style="padding-top:20px">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="grdStore" runat="server" AutoGenerateColumns="false"
                        CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="StoreID"
                        AllowPaging="True" AllowSorting="True" PageSize="5"
                        OnPageIndexChanging="grdStore_PageIndexChanging"
                            OnSorting="grdStore_Sorting"
                            OnRowCancelingEdit="grdStore_RowCancelingEdit"
                            OnRowDeleting="grdStore_RowDeleting"
                            OnRowEditing="grdStore_RowEditing"
                            OnRowUpdating="grdStore_RowUpdating"
                            OnRowCommand="grdStore_RowCommand"
                            OnRowDataBound="grdStore_RowDataBound" 
                            OnRowCreated="grdStore_RowCreated"
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
                            <asp:TemplateField HeaderText="StoreID" Visible="false" SortExpression="StoreID">
                                <ItemTemplate>
                                    <asp:Label ID="txtStoreID" runat="server" Text='<%#Eval("StoreID") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblStoreID" runat="server" Width="40px" Text='<%#Eval("StoreID") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Store Name" SortExpression="StoreName">
                                <ItemTemplate>
                                    <asp:Label ID="lblStoreName" runat="server" Text='<%#Eval("StoreName") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStoreName" Width="270px" runat="server" Text='<%#Eval("StoreName") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Location" SortExpression="Location">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtLocation" Width="270px" runat="server" Text='<%#Eval("Location") %>' />
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
                        <%=grdStore.PageIndex + 1%> of
                        <%=grdStore.PageCount%>
                    </i>
                        </div>
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </div>
</asp:Content>