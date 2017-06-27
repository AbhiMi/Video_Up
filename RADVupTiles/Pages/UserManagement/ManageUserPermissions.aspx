<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="ManageUserPermissions.aspx.cs" Inherits="Pages_UserManagement_ManageUserPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        div h3 {
            width: 220px !important;
            margin-top: -30px;
            margin-left: 50px;
        }

        label {
            font-style: normal;
            float:right;
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
        <h3>Manage User Permissions</h3>
        <div class="content scrollbar" style="width: 800px; height: 300px; margin-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" Height="141px" Width="588px"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader">
                            <AlternatingRowStyle BackColor="White" />
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
                        </asp:GridView>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button" />
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
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
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

