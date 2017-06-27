<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="RADDeviceChannelAssociation.aspx.cs" Inherits="AssociationViews_RADDeviceChannelAssociation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="border: 2px solid #a1a1a1; padding: 10px 40px; background: #dddddd; border-radius: 25px;">
        <div style="border: 1px solid rgba(80, 124, 208, 1); background: rgba(80, 124, 208, 1); border-radius: 5px; color: white; padding-left: 5px; text-align: center">
            <h4>Associate RAD  Device to Channel</h4>
        </div>
        <div style="border: 2px solid #a1a1a1; padding: 10px 40px; background: #dddddd; border-radius: 25px; padding-bottom: 40px; margin-top: 20px">
            <table>
                <tr>
                    <td style="padding-right: 100px;">
                        <div style="background: rgba(80, 124, 208, 1); border-radius: 10px; color: white; padding-left: 5px; margin-bottom: 10px; width: 500px; text-align: center">
                            <h4>Please select RAD Device for Association</h4>
                        </div>
                        <div style="background-color: #507CD1; background-repeat: repeat-x; height: 30px; width: 500px; margin: 0; padding: 0">
                            <table cellspacing="0" cellpadding="0" rules="all" border="1" id="tblPlayListHeader"
                                style="font-family: Arial; font-size: 10pt; width: 500px; color: white; border-collapse: collapse; height: 100%;">
                                <tr>
                                    <td style="width: 50px; text-align: center">Select</td>
                                    <td style="width: 100px; text-align: center">RAD Device ID</td>
                                    <td style="width: 250px; text-align: center">RAD Device Name</td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; height: 200px; width: 500px; overflow: auto;">
                            <asp:GridView ID="grdRADDevice" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                ForeColor="#333333" GridLines="Horizontal" ShowHeader="false" Width="500px">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelectRADDevice" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" DataField="RADDeviceID" HeaderText="ID"></asp:BoundField>
                                    <asp:BoundField ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" DataField="DeviceInfo" HeaderText="Device Name"></asp:BoundField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </td>
                    <td>
                        <div style="background: rgba(80, 124, 208, 1); border-radius: 10px; color: white; padding-left: 5px; margin-bottom: 10px; width: 500px; text-align: center">
                            <h4>Please select Channel to associate to RAD Device</h4>
                        </div>
                        <div style="background-color: #507CD1; background-repeat: repeat-x; height: 30px; width: 500px; margin: 0; padding: 0">
                            <table cellspacing="0" cellpadding="0" rules="all" border="1" id="tblPlaylistHeader"
                                style="font-family: Arial; font-size: 10pt; width: 500px; color: white; border-collapse: collapse; height: 100%;">
                                <tr>
                                    <td style="width: 50px; text-align: center">Select</td>
                                    <td style="width: 100px; text-align: center">Campaign ID</td>
                                    <td style="width: 250px; text-align: center">Campaign Name</td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: right; height: 200px; width: 500px; overflow: auto;">
                            <asp:GridView ID="grdChannel" runat="server" Style="height: 100px; overflow: auto" AutoGenerateColumns="false"
                                CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeader="false">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbSelectChannel" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" DataField="ChannelID" HeaderText="ID"></asp:BoundField>
                                    <asp:BoundField ItemStyle-Width="350px" ItemStyle-HorizontalAlign="Center" DataField="ChannelName" HeaderText="Channel Name"></asp:BoundField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </td>
                    <td>
                        <div style="float: right; margin-left: 30px">
                            <asp:Button runat="server" ID="btnAssociateChannel" Text="Associate RAD Device to Channel" class="btn btn-primary btn-large" OnClick="btnAssociateChannel_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="text-align: center; padding-bottom: 10px">
            <asp:Label ID="ActionStatus" runat="server" Font-Bold="true"></asp:Label>
        </div>

        <div align="center" style="border: 2px solid #a1a1a1; padding: 10px 40px; background: #dddddd; border-radius: 25px; margin-bottom: 20px">
            <div style="background: rgba(80, 124, 208, 1); border-radius: 10px; color: white; padding-left: 5px; margin-bottom: 10px; width: 500px; text-align: center">
                <h4>RAD Device and Channel Association</h4>
            </div>
            <div style="background-color: #507CD1; background-repeat: repeat-x; height: 30px; width: 500px; margin: 0; padding: 0">
                <table cellspacing="0" cellpadding="0" rules="all" border="1" id="tblCampaignHeader"
                    style="font-family: Arial; font-size: 10pt; width: 500px; color: white; border-collapse: collapse; height: 100%;">
                    <tr>
                        <td style="width: 250px; text-align: center">RAD Device Name</td>
                        <td style="width: 250px; text-align: center">Channel Name</td>
                    </tr>
                </table>
            </div>
            <div style="height: 200px; width: 500px; overflow: auto;">
                <asp:GridView ID="grdRADDeviceChannel" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" ShowHeader="false" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" DataField="DeviceInfo" HeaderText="RAD Device Name"></asp:BoundField>
                        <asp:BoundField ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Center" DataField="ChannelName" HeaderText="Channel Name"></asp:BoundField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
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

