<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="CreateCampaign.aspx.cs" Inherits="Master_CreateCampaign" %>

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
                    <asp:TextBox ID="txtCreateCampaign" runat="server" />
                </td>
                <td style="padding-right: 20px; float: left">
                    <asp:Button ID="btnCreateCampaign" runat="server" Text="Create Campaign" class="btn btn-primary btn-large" OnClick="btnCreateCampaign_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCreateCampaignStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <div style="padding-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdCampaign" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="CampaignID"
                            AllowPaging="True" AllowSorting="True" PageSize="5"
                            OnPageIndexChanging="grdCampaign_PageIndexChanging"
                            OnSorting="grdCampaign_Sorting"
                            OnRowCancelingEdit="grdCampaign_RowCancelingEdit"
                            OnRowDeleting="grdCampaign_RowDeleting"
                            OnRowEditing="grdCampaign_RowEditing"
                            OnRowUpdating="grdCampaign_RowUpdating"
                            OnRowCommand="grdCampaign_RowCommand"
                            OnRowDataBound="grdCampaign_RowDataBound"
                            OnRowCreated="grdCampaign_RowCreated"
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
                                <asp:TemplateField HeaderText="CampaignID" Visible="false" SortExpression="CampaignID">
                                    <ItemTemplate>
                                        <asp:Label ID="txtCampaignID" runat="server" Text='<%#Eval("CampaignID") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCampaignID" runat="server" Width="40px" Text='<%#Eval("CampaignID") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Campaign Name" SortExpression="CampaignName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCampaignName" runat="server" Text='<%#Eval("CampaignName") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCampaignName" Width="270px" runat="server" Text='<%#Eval("CampaignName") %>' />
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
                        <%=grdCampaign.PageIndex + 1%> of
                        <%=grdCampaign.PageCount%>
                            </i>
                        </div>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

