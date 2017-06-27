<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="RADDevice.aspx.cs" Inherits="Pages_RADDevice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/jquery.min.js"></script>
    <script src="../js/jquery-ui.min.js"></script>
    <script src="../Scripts/jquery.autocomplete.js"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtRADDevice.ClientID%>").autocomplete('Associate/Search_RADDevice.ashx');
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a#pop').live('click', function (e) {
                e.preventDefault();
                var page = $(this).attr("href")
                var pagetitle = $(this).attr("title")
                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 625,
                    width: 500,
                    title: pagetitle
                });
                $dialog.dialog('open');
            });
        });
    </script>
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        .breadcrumb {
            margin-left: 20px;
            width: 16%;
        }

        .SiteMap {
            margin-left: -257px;
        }

        .marginLeft20 {
            margin-left: 20px;
        }

        .h3 {
            margin-top: -20px;
        }

        #footer, #footer a {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="padding: 10px; border-radius: 10px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg); position: relative; background-repeat: repeat; width: 95%; margin-top: 25px">
        <div style="float: right; border: 3px solid Gray; min-height: 425px; padding: 10px; border-radius: 10px; width: 22%; float: left; margin: 50px 0 0 26px">
            <h3 class="h3" style="width: 171px">Search RAD Devices</h3>            
            <asp:TextBox ID="txtRADDevice" runat="server" Width="160px" ClientIDMode="Static" CssClass="textbox" />
            <asp:GridView ID="grdRADDevice" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" ShowHeaderWhenEmpty="True"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader"
                AllowSorting="true">
                <Columns>
                    <asp:TemplateField HeaderText="#" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <span>
                                <%#Container.DataItemIndex + 1%>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Left" DataField="RADDeviceID" HeaderText="ID" SortExpression="RADDeviceID"></asp:BoundField>--%>
                    <asp:TemplateField HeaderText="RADDevice Name" ControlStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" SortExpression="DeviceInfo">
                        <ItemTemplate>
                            <asp:HyperLink ID="pop" runat="server" NavigateUrl='<%# string.Format("~/Pages/phpvarbinary.php?RADDeviceID={0}&CompanyID={1}",
                    HttpUtility.UrlEncode(Eval("RADDeviceID").ToString()),hdnCompanyID.Value) %>'
                                Text='<%# Eval("DeviceInfo").ToString()%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hdnCompanyID" runat="server" />
        </div>
    </div>
    <div id="footer">
        <span class="vupFooterText"><a href="..\ContactUs.aspx">Contact Us</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Privacy</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Terms of Use</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupCopyright">&copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

