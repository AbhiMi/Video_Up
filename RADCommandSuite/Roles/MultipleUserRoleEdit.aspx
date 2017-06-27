<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="MultipleUserRoleEdit.aspx.cs" Inherits="Roles_MultipleUserRoleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="141px" Width="588px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField HeaderText="User Name" DataField="UserName" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="ChkCompanyAdminAll" runat="server" Text="Company Admin" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkCompanyAdmin" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="ChkStoreAdminAll" runat="server" Text="Store Admin" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkStoreAdmin" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="ChkVUPAdminAll" runat="server" Text="VUP Admin" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkVUPAdmin" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="ChkGuestAll" runat="server" Text="Guest" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkGuest" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <div style="margin-top: 20px">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
    <script type="text/javascript">
        var gridView1Control = document.getElementById('<%= GridView1.ClientID %>');

        //ADD Column
        $('input:checkbox[id$=ChkCompanyAdminAll]', gridView1Control).click(function (e) {
            if (this.checked) {
                $('input:checkbox[id*=ChkCompanyAdmin]', gridView1Control).prop("checked", true);
            }
            else {
                $('input:checkbox[id*=ChkCompanyAdmin]', gridView1Control).prop("checked", false);
            }
        });

        //DELETE Column
        $('input:checkbox[id*=ChkStoreAdminAll]', gridView1Control).click(function (e) {
            if (this.checked) {
                $('input:checkbox[id*=ChkStoreAdmin]', gridView1Control).prop('checked', true);
            }
            else {
                $('input:checkbox[id*=ChkStoreAdmin]', gridView1Control).prop('checked', false);
            }
        });

        //EDIT Column
        $('input:checkbox[id*=ChkVUPAdminAll]', gridView1Control).click(function (e) {
            if (this.checked) {
                $('input:checkbox[id*=ChkVUPAdmin]', gridView1Control).prop('checked', true);
            }
            else {
                $('input:checkbox[id*=ChkVUPAdmin]', gridView1Control).prop('checked', false);
            }
        });

        //VIEW Column
        $('input:checkbox[id*=ChkGuestAll]', gridView1Control).click(function (e) {
            if (this.checked) {
                $('input:checkbox[id*=ChkGuest]', gridView1Control).prop('checked', true);
            }
            else {
                $('input:checkbox[id*=ChkGuest]', gridView1Control).prop('checked', false);
            }
        });




        //To uncheck the ADD header checkbox when there are no selected checkboxes in itemtemplate
        $('input:checkbox[id*=ChkCompanyAdmin]', gridView1Control).click(function (e) {
            if ($('input:checkbox[id*=ChkCompanyAdmin]:checked', gridView1Control).length < $('input:checkbox[id*=ChkCompanyAdmin]', gridView1Control).length) {
                $('input:checkbox[id$=ChkCompanyAdminAll]', gridView1Control).removeAttr('checked');
            }
            else if ($('input:checkbox[id*=ChkCompanyAdmin]:checked', gridView1Control).length == $('input:checkbox[id*=ChkCompanyAdmin]', gridView1Control).length) {
                $('input:checkbox[id$=ChkCompanyAdminAll]', gridView1Control).prop('checked', true);
            }
        });


        //To uncheck the DELETE header checkbox when there are no selected checkboxes in itemtemplate
        $('input:checkbox[id*CchkStoreAdmin]', gridView1Control).click(function (e) {
            if ($('input:checkbox[id*=ChkStoreAdmin]:checked', gridView1Control).length < $('input:checkbox[id*=ChkStoreAdmin]', gridView1Control).length) {
                $('input:checkbox[id$=ChkStoreAdminAll]', gridView1Control).removeAttr('checked');
            }
            else if ($('input:checkbox[id*=ChkStoreAdmin]:checked', gridView1Control).length == $('input:checkbox[id*=ChkStoreAdmin]', gridView1Control).length) {
                $('input:checkbox[id$=ChkStoreAdminAll]', gridView1Control).prop('checked', true);
            }
        });

        //To uncheck the EDIT header checkbox when there are no selected checkboxes in itemtemplate
        $('input:checkbox[id*=ChkVUPAdmin]', gridView1Control).click(function (e) {
            if ($('input:checkbox[id*=ChkVUPAdmin]:checked', gridView1Control).length < $('input:checkbox[id*=ChkVUPAdmin]', gridView1Control).length) {
                $('input:checkbox[id$=ChkVUPAdminAll]', gridView1Control).removeAttr('checked');
            }
            else if ($('input:checkbox[id*=ChkVUPAdmin]:checked', gridView1Control).length == $('input:checkbox[id*=ChkVUPAdmin]', gridView1Control).length) {
                $('input:checkbox[id$=ChkVUPAdminAll]', gridView1Control).prop('checked', true);
            }
        });

        //To uncheck the VIEW header checkbox when there are no selected checkboxes in itemtemplate
        $('input:checkbox[id*=chkGuest]', gridView1Control).click(function (e) {
            if ($('input:checkbox[id*=ChkGuest]:checked', gridView1Control).length < $('input:checkbox[id*=ChkGuest]', gridView1Control).length) {
                $('input:checkbox[id$=ChkGuestAll]', gridView1Control).removeAttr('checked');
            }
            else if ($('input:checkbox[id*=chkGuest]:checked', gridView1Control).length == $('input:checkbox[id*=ChkGuest]', gridView1Control).length) {
                $('input:checkbox[id$=ChkGuestAll]', gridView1Control).prop('checked', true);
            }
        });
    </script>
</asp:Content>

