<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="RADDevice.aspx.cs" Inherits="Master_RADDevice" %>

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
            <tr style="padding: 22px 20px 20px 0px">
                <td style="margin-bottom: 20px">
                    <asp:Label ID="lblRADDeviceName" runat="server" Text="RAD Device Name:" />
                </td>
                <td>
                    <asp:TextBox ID="txtRADDeviceName" runat="server" Width="300px" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr style="padding: 22px 20px 20px 0px">
                <td>
                    <asp:Label ID="lblRADDeviceInfo" runat="server" Text="RAD Device Information:" />
                </td>
                <td>
                    <asp:TextBox ID="txtRADDeviceInfo" runat="server" TextMode="MultiLine" Height="50px" Width="300px" />
                </td>
            </tr>
            <%--<tr style="padding: 22px 20px 20px 0px">
                <td>
                    <asp:Label ID="lblCompany" runat="server" Text="Company:" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlCompanies" runat="server" Width="200px" />
                </td>
            </tr>--%>
            <tr style="padding: 22px 20px 20px 0px">
                <td>
                    <asp:Label ID="lblAddRADDeviceStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Button ID="btnAddRADDevice" runat="server" Text="Create RAD Device" class="btn btn-primary btn-large" OnClick="btnAddRADDevice_Click" />
                </td>
            </tr>
        </table>
        <div style="padding-top:20px">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="grdRADDevice" runat="server" AutoGenerateColumns="false"
                        CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="RADDeviceID"
                        AllowPaging="True" AllowSorting="True" PageSize="5"
                        OnPageIndexChanging="grdRADDevice_PageIndexChanging"
                        OnSorting="grdRADDevice_Sorting"
                        OnRowCancelingEdit="grdRADDevice_RowCancelingEdit"
                        OnRowDeleting="grdRADDevice_RowDeleting"
                        OnRowEditing="grdRADDevice_RowEditing"
                        OnRowUpdating="grdRADDevice_RowUpdating"
                        OnRowCommand="grdRADDevice_RowCommand"
                        OnRowDataBound="grdRADDevice_RowDataBound">
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
                                    <asp:Label ID="lblDeviceInfo" runat="server" Text='<%#Eval("DeviceInfo") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDeviceInfo" Width="270px" runat="server" Text='<%#Eval("DeviceInfo") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescription" Width="270px" runat="server" Text='<%#Eval("Description") %>' />
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
                    </asp:GridView>
                   <div style="color: #FFFFFF; font-weight: bold;background-color:#507CD1;text-align:center;padding-top:5px">
                    <i>You are viewing page
                        <%=grdRADDevice.PageIndex + 1%> of
                        <%=grdRADDevice.PageCount%>
                    </i>
                        </div>
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </div>
    
</asp:Content>



