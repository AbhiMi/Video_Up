<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RADdeviceDialog.aspx.cs" Inherits="Pages_RADdeviceDialog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>insert into rad devices</title>
</head>
<style type="text/css">
    .formCls {
        font-family: 'Segoe UI', 'Century Gothic', 'Arial';
        font-size: 13px;
    }

    .Button {
        font-weight: bold;
        background-color: #EF7C31;
        color: white;
    }
</style>
<body>
    <form id="form1" runat="server" class="formCls">
        <div>
            <div>
                <script type="text/javascript">
                    function CloseAndRebind(args) {
                        GetRadWindow().BrowserWindow.refreshGrid(args);
                        GetRadWindow().close();
                    }

                    function GetRadWindow() {
                        var oWindow = null;
                        if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

                        return oWindow;
                    }

                    function CancelEdit() {
                        GetRadWindow().close();
                    }
                </script>
                <asp:ScriptManager ID="ScriptManager2" runat="server" />
                <asp:UpdatePanel runat="server" ID="updatePanel1">
                    <ContentTemplate>
                        <div align="Center">
                            <asp:Label runat="server" ID="lblmsg" Font-Bold="true" />
                            <br />
                            <br />
                            <table cellspacing="2" cellpadding="2" class="formCls">
                                <tr>
                                    <td align="Right">DeviceInfo :</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDeviceInfo" />
                                        <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="txtDeviceInfo" ErrorMessage="*" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Right">Description :</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDescription" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="Right">RadDevice Type :</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtRadDeviceType" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtRadDeviceType" ErrorMessage="*" ForeColor="Red" />
                                    </td>
                                </tr>

                            </table>
                            <table style="padding-top: 15px; font-weight: bold;">
                                <tr>
                                    <td align="right">
                                        <asp:Button runat="server" ID="btnAddRadLicence" Text="Add" OnClick="btnAddRadLicence_click" CssClass="Button" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnReset" Text="Reset" OnClick="btnReset_Click" CssClass="Button" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="GridView1" DataKeyNames="StoreID" runat="server" AutoGenerateRows="False" BorderWidth="1px" Font-Bold="false" CssClass="formCls"
                                AutoGenerateColumns="False" HeaderStyle-BackColor="#ef7c31" CellPadding="4" GridLines="Both" ForeColor="#333333" BorderColor="#A0A0A0">
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" BackColor="#ef7c31" Font-Bold="true" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="black" />
                                <Columns>
                                    <asp:BoundField DataField="RADDeviceID" HeaderText="RADDeviceID" Visible="false" />
                                    <asp:BoundField DataField="RADLicence" HeaderText="RADLicence" Visible="false" />
                                    <asp:BoundField DataField="DeviceInfo" HeaderText="Device Info" ReadOnly="true" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="true" />
                                    <asp:BoundField DataField="RADDeviceType" HeaderText="RADDevice Type" ReadOnly="true" NullDisplayText="NULL" />
                                    <%--<asp:CommandField ShowInsertButton="True" ButtonType="Button" />--%>
                                </Columns>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
