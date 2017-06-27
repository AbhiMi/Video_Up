<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="UserCompanyAssociation.aspx.cs" Inherits="Roles_RoleBasedAuthorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="form-horizontal">
        <h4>View Users.</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlCompany" CssClass="col-md-2 control-label">Please Select Company</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div style="vertical-align:central;">
                <asp:GridView ID="grdAllUserCompany" runat="server" AutoGenerateColumns="true"
                    CellPadding="4" ForeColor="#333333" GridLines="Horizontal" AllowPaging="True" AllowSorting="True" PageSize="20" Width="450px"
                    CssClass="datatable" OnPageIndexChanging="grdAllUserCompany_PageIndexChanging">
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
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

