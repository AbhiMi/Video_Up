<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="CreateCompany.aspx.cs" Inherits="CreateCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <style>
        .sortasc a  
        {
            display:block; padding:0 4px 0 15px; 
            background:url(Images/asc.gif) no-repeat;  
        }

        .sortdesc a 
        {
            display:block; padding:0 4px 0 15px; 
            background:url(Images/desc.gif) no-repeat;
        }
    </style>
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
   <%--<asp:Wizard ID="WZ_Company" runat="server" HeaderText="Video-Up Wizard" HeaderStyle-Font-Size="Larger" HeaderStyle-ForeColor="White"
        BorderColor="#428bca" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="1.1em" Width="100%" DisplaySideBar="false">
        <HeaderStyle Font-Size="1.1em" ForeColor="White" Font-Bold="True" HorizontalAlign="Left"></HeaderStyle>
        <NavigationButtonStyle CssClass="btn btn-primary btn-large" />
        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
        <SideBarStyle ForeColor="White" BorderWidth="0px" Font-Size="1.1em" VerticalAlign="Top" />
        <SideBarTemplate>
            <asp:DataList ID="SideBarList" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="SideBarButton" runat="server"></asp:LinkButton>
                </ItemTemplate>
                <SelectedItemStyle Font-Bold="True" />
            </asp:DataList>
        </SideBarTemplate>
        <StartNavigationTemplate>
            <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Next" OnClick="StartNextButton_Click" class="btn btn-primary btn-large" />
        </StartNavigationTemplate>
        <StepNavigationTemplate>
            <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" class="btn btn-primary btn-large" />
            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Next" OnClick="StepNextButton_Click" class="btn btn-primary btn-large" />
        </StepNavigationTemplate>
        <StepStyle BorderWidth="0px" ForeColor="#428bca" />
        <WizardSteps>
            <asp:WizardStep ID="WizadStep1" runat="server" Title="Create Company">--%>
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px">
        <table>
            <tr>
                <td style="padding-right: 20px; padding-top: 2px">
                    <asp:TextBox ID="txtCreateCompany" runat="server" />
                </td>
                <td style="padding-right: 20px; float: left">
                    <asp:Button ID="btnCreateCompany" runat="server" Text="Create Company" class="btn btn-primary btn-large" OnClick="btnCreateCompany_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddCompanyStatus" runat="server" Visible="false" Font-Bold="true" />
                </td>
            </tr>
        </table>
        <div style="padding-top: 20px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdCompany" runat="server" AutoGenerateColumns="false"
                            CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="CompanyID"
                            AllowPaging="True" AllowSorting="True" PageSize="5" Width="450px"
                            OnPageIndexChanging="grdCompany_PageIndexChanging"
                            OnSorting="grdCompany_Sorting"
                            OnRowCancelingEdit="grdCompany_RowCancelingEdit"
                            OnRowDeleting="grdCompany_RowDeleting"
                            OnRowEditing="grdCompany_RowEditing"
                            OnRowUpdating="grdCompany_RowUpdating"
                            OnRowCommand="grdCompany_RowCommand"
                            OnRowDataBound="grdCompany_RowDataBound" 
                            OnRowCreated="grdCompany_RowCreated"
                            CssClass="datatable">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingHeaderStyle CssClass="sortasc" />
                            <SortedDescendingHeaderStyle CssClass="sortdesc" />
                            <Columns>
                                <asp:TemplateField HeaderText="CompanyID" Visible="false" SortExpression="CompanyID">
                                    <ItemTemplate>
                                        <asp:Label ID="txtCompanyID" runat="server" Text='<%#Eval("CompanyID") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCompanyID" runat="server" Width="40px" Text='<%#Eval("CompanyID") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Company Name" SortExpression="CompanyName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompanyName" runat="server" Text='<%#Eval("CompanyName") %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCompanyName" Width="270px" runat="server" Text='<%#Eval("CompanyName") %>' />
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
                             <%=grdCompany.PageIndex + 1%> of
                             <%=grdCompany.PageCount%>
                            </i>
                        </div>
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <%-- </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Associate RAD Device to Company">--%>

    <%--</asp:WizardStep>--%>
    <%--<asp:WizardStep ID="WizardStep3" runat="server" Title="Assign RAD Device to Company">
                <div style="padding: 20px">
                    <div style="margin-bottom: 10px;">
                        <asp:Label ID="lblAssteRADDevicetoCompanyStatus" runat="server" Visible="false" ForeColor="Green" Font-Bold="true" />
                    </div>
                    <asp:GridView ID="grdRADCompany" runat="server" AutoGenerateColumns="false"
                        CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="RADDeviceID" Width="90%">
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
                    <asp:ObjectDataSource ID="odsAssociateRAD" runat="server"></asp:ObjectDataSource>
                    <div style="margin-top: 20px">
                        <asp:Button runat="server" ID="btnAssteRADtoCompany" Text="Associate RADDevice to Companies" OnClick="btnAssteRADtoCompany_Click"
                            class="btn btn-primary btn-large" />
                    </div>
                </div>
            </asp:WizardStep>--%>
    <%--</WizardSteps>
        <HeaderTemplate>
            <ul id="wizHeader">
                <asp:Repeater ID="SideBarList" runat="server">
                    <ItemTemplate>
                        <li><a class="<%# GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                            <%# Eval("Name")%></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </HeaderTemplate>
    </asp:Wizard>--%>
</asp:Content>