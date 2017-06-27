<%@ Page Title="" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="UploadMediaLibrary.aspx.cs" Inherits="UploadMediaLibrary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    <br />
    <script src="Scripts/jquery-1.3.2.min.js"></script>
    <script src="Scripts/jquery.uploadify.js"></script>
    <link href="Content/uploadify.css" type="text/css" rel="stylesheet" />
    <style>
        .vupGridHeader {
            background: linear-gradient(to bottom,grey 10%, black 50%);
            border-color: #080808;
        }
    </style>
    <script type="text/javascript">
        $(window).load(
      function () {
          $("#<%=FileUpload1.ClientID%>").fileUpload({
              'uploader': 'Scripts/uploader.swf',
              'cancelImg': 'Images/cancel.png',
              'buttonText': 'Browse Files',
              'script': 'Upload.ashx',
              'folder': 'Media',
              'multi': true,
              'auto': false
          });
      }
);
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "aqua";
            }
            else {
                //If not checked change back to original color
                if (row.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    row.style.backgroundColor = "#C2D69B";
                }
                else {
                    row.style.backgroundColor = "white";
                }
            }

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=grdMediaPlaylist.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
    <asp:Wizard ID="WZ_VideoUp" runat="server" HeaderText="Video-Up Wizard" HeaderStyle-Font-Size="Larger" HeaderStyle-ForeColor="White"
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
            <asp:WizardStep ID="WizadStep1" runat="server" Title="Upload Media">
                <div style="padding: 20px">
                    <table>
                        <tr>
                            <td style="padding-right: 20px; padding-top: 2px">
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-primary btn-large" /></td>
                            <td style="padding-right: 20px; float: left"><a href="javascript:$('#<%=FileUpload1.ClientID%>').fileUploadStart()" class="btn btn-primary btn-large">Start Upload</a></td>
                            <td style="float: left"><a href="javascript:$('#<%=FileUpload1.ClientID%>').fileUploadClearQueue()" class="btn btn-primary btn-large">Clear</a></td>
                        </tr>
                    </table>
                    <div style="margin-top: 10px; padding-left: 100px">
                        <asp:Label ID="lblFileUploadStatus" runat="server" Visible="false" />
                    </div>
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Associate Media to Playlists">
                <div style="padding: 20px">
                    <div style="margin-bottom: 10px;">
                        <asp:Label ID="lblAssociateMediatoPLStatus" runat="server" Visible="false" ForeColor="Green" Font-Bold="true" />
                    </div>
                    <asp:GridView ID="grdMediaPlaylist" runat="server" AutoGenerateColumns="false" OnRowDataBound="grdMediaPlaylist_RowDataBound"
                        CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="MediaID" Width="90%">
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
                    <asp:ObjectDataSource ID="odsAssociateMedia" runat="server"></asp:ObjectDataSource>
                    <div style="margin-top: 20px">
                        <asp:Button runat="server" ID="btnAssociateMediatoPL" Text="Associate Media to PlayLists" OnClick="btnAssociateMediatoPL_Click"
                            class="btn btn-primary btn-large" />
                    </div>
                 </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Associate Playlists to Campaigns">
                <div style="padding: 20px">
                    <div style="margin-bottom: 10px;">
                        <asp:Label ID="lblAssociatePlayListToCampaign" runat="server" Visible="false" ForeColor="Green" Font-Bold="true" />
                    </div>
                    <asp:GridView ID="grdPlayListCampaigns" runat="server" AutoGenerateColumns="false"
                        CellPadding="4" ForeColor="#333333" GridLines="Horizontal" DataKeyNames="PlayListID" Width="90%">
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
                    <asp:ObjectDataSource ID="odsAssociatePLToCampaingns" runat="server"></asp:ObjectDataSource>
                    <div style="margin-top: 20px">
                        <asp:Button runat="server" ID="Button1" Text="Associate Playlists to Campaigns" OnClick="btnAssociatePLtoCmpgn_Click"
                            class="btn btn-primary btn-large" />
                    </div>
                 </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep4" runat="server" Title="Assign Campaign to Channels">
                <div style="padding: 20px">
                    TBD...
                </div>
            </asp:WizardStep>
        </WizardSteps>
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
    </asp:Wizard>
</asp:Content>


