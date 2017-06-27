<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CreateStore.aspx.cs" Inherits="Pages_CreateStore" %>

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
            width: 105px;
            margin-top: -30px;
            margin-left: 50px;
        }

        .label {
            font-style: normal;
        }
        .breadcrumb
        {
            min-height:475px !important;
        }
         #footer, #footer a{
            width: 100%; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" "/>
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px; margin: 60px 25px 0 0px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg);
         position: relative; background-repeat: repeat;width:71%;float:right;height:450px">
        <h3>Create Store</h3>
        <table id="tblStore" runat="server" style="border: 1px solid black; width: 750px;">
            <tr style="border: 1px solid black">
                <td style="padding-right: 20px; padding-top: 2px; border: 1px solid black">
                    <asp:Label ID="lblCreateStore" Text="Store Name:" runat="server" CssClass="label" />
                </td>
                <td>
                    <asp:TextBox ID="txtCreateStore" runat="server" />
                </td>
            </tr>
            <tr style="margin-bottom: 10px">
                <td style="padding-right: 20px; padding-top: 2px; border: 1px solid black">
                     <asp:Label ID="lblLocation" Text="Location:" runat="server" CssClass="label" />
                </td>
                <td>
                    <asp:TextBox ID="txtLocation" runat="server" /></td>
            </tr>
            <tr style="margin-bottom: 10px">
                <td style="border: 1px solid black">
                    <asp:Label ID="lblCompany" Text="Company:" runat="server" CssClass="label" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlCompanies" runat="server" DataTextField="CompanyName" DataValueField="CompanyID" />
                </td>
            </tr>
            <tr style="margin-top: 10px">
                <td></td>
                <td>
                    <asp:Button ID="btnCreatePlayList" runat="server" Text="Create Store" CssClass="button" OnClick="btnCreateStore_Click" /></td>
            </tr>
            <tr style="margin-bottom: 10px">
                <td>
                    <asp:Label ID="lblCreateStoreStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
        </table>
         <div class="content scrollbar" style="width:750px;height:300px;margin-top:20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdStore" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="StoreID"
                            AllowSorting="True"
                            OnPageIndexChanging="grdStore_PageIndexChanging"
                            OnSorting="grdStore_Sorting"
                            OnRowCancelingEdit="grdStore_RowCancelingEdit"
                            OnRowDeleting="grdStore_RowDeleting"
                            OnRowEditing="grdStore_RowEditing"
                            OnRowUpdating="grdStore_RowUpdating"
                            OnRowCommand="grdStore_RowCommand"
                            OnRowDataBound="grdStore_RowDataBound"
                            OnRowCreated="grdStore_RowCreated"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader">
                            <Columns>
                                 <asp:TemplateField HeaderText="#" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                                     <ItemTemplate>
                                         <span>
                                            <%#Container.DataItemIndex + 1%>
                                         </span>
                                     </ItemTemplate>
                                </asp:TemplateField>
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
                                        <asp:TextBox ID="txtStoreName" Width="170px" runat="server" Text='<%#Eval("StoreName") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Location" SortExpression="Location">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLocation" Width="170px" runat="server" Text='<%#Eval("Location") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></asp:BoundField>
                                <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="DateModified" HeaderText="Date Modified" SortExpression="DateModified" DataFormatString="{0: dd-MMM-yy}" HtmlEncode="false" ReadOnly="true"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemStyle CssClass="floatRight" />
                                    <EditItemTemplate>
                                        <asp:Button ID="ButtonUpdate" runat="server" CommandName="Update" Text="Update" CssClass="button"/>
                                        <asp:Button ID="ButtonCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="button" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" CssClass="button" />
                                        <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="button"/>
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
        <span class="vupCopyright"> &copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

