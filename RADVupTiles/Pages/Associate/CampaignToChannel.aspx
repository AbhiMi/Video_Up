<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CampaignToChannel.aspx.cs" Inherits="Pages_Associate_CampaignToChannel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <link href="../../css/jquery.autocomplete.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.js"></script>
    <script src="../../Scripts/jquery-1.4.1.min.js"></script>
    <script src="../../Scripts/jquery-ui.js"></script>
    <script src="../../Scripts/jquery.autocomplete.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtChannel.ClientID%>").autocomplete('Search_CS.ashx');
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $(".drag_drop_grid").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'move',
                connectWith: '.drag_drop_grid',
                dropOnEmpty: true,
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                   <%-- var gvid = '<%=gvDest.ClientID %>';--%>
                    var campaign = {};
                    //var row = $(this).parent().parent();
                    //var hidd = row.find('td').find(':input').val();
                    //campaign.ID = $('#' + gvid + ' input[type=hidden]').val();
                    campaign.ID = $("[id*=gvDest] tr:last").find("td:nth-child(1)").html();
                    campaign.ChannelID = $("#<%=hdnChannelID.ClientID%>").val()
                    $.ajax({
                        type: "POST",
                        url: "CampaignToChannel.aspx/SaveCampaign",
                        data: '{campaign: ' + JSON.stringify(campaign) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            //alert("Campaign has been added to Channel successfully.");
                        },
                        error: function (response) {
                            //alert(response);
                        }

                    });
                    window.location.href = window.location.href;
                    return false;
                }
            });
            //$("[id*=gvDest] tr:not(tr:first-child)").remove();
        });

        function hideColumn() {
            var gvid = '<%=gvSource.ClientID %>';
            var rows = document.getElementById(gvid).rows;
            for (i = 0; i <= rows.length; i++) {
                if (rows[i] != undefined && rows[i].cells[0] != undefined)
                    rows[i].cells[0].style.display = "none";
            }
        }
    </script>
    <script>
        function SetupFilter(textboxID, gridID, columnName) {
            $('#' + textboxID).keyup(function () {
                var index;
                var text = $("#" + textboxID).val();

                $('#' + gridID + ' tbody tr').each(function () {
                    $(this).children('th').each(function () {
                        if ($(this).html() == columnName)
                            index = $(this).index();
                    });

                    $(this).children('td').each(function () {
                        if ($(this).index() == index) {
                            var tdText = $(this).children(0).html() == null ? $(this).html() : $(this).children(0).html();

                            if (tdText.indexOf(text, 0) > -1) {
                                $(this).closest('tr').show();
                            } else {
                                $(this).closest('tr').hide();
                            }
                        };
                    });
                });
            });
        };

        $(function () { SetupFilter("txtChannel", "grdChannels", "Channel Name"); });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[src*=minus]").each(function () {
                $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
                $(this).next().remove()
            });
        });
        function ConfirmUnAssociate() {
            return confirm("Are you sure you would like to unassociate this campaign?");
        }
    </script>
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        .breadcrumb {
            margin-left:20px;
            width:16%;
        }
        .SiteMap {
            margin-left:-257px;
        }
        .h3{
            margin-top:-20px;
        }
        #footer, #footer a{
            width: 100%; 
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
     <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" " />
    <div style="padding: 10px; border-radius: 10px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg); position: relative; background-repeat: repeat; width: 95%; margin-top: 25px">
        <div style="float: right; border: 3px solid Gray; min-height: 425px; padding: 10px; 
                border-radius: 10px; width: 23%;float:left;margin:50px 0 0 -25px">
            <h3 class="h3">Search Channel</h3>
            <asp:TextBox ID="txtChannel" runat="server" Width="160px" ClientIDMode="Static" CssClass="textbox" />
            <asp:Button ID="btnLoadGrid" runat="server" Text="Load" OnClick="btnLoadGrid_Click" CssClass="button" />
            <asp:HiddenField ID="hdnChannelID" runat="server" />
            <div class="content scrollbar" style="margin-top:18px">
                <asp:GridView ID="grdChannels" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" ShowHeaderWhenEmpty="True"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" HeaderStyle-CssClass="FixedHeader"
                    AllowSorting="true" OnSorting="grdChannels_Sorting">
                    <Columns>
                        <asp:TemplateField HeaderText="#" ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span>
                                    <%#Container.DataItemIndex + 1%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Image ID="imgThumbNail" runat="server" ImageUrl='<%# "~/img/" + Eval("FileName") %>' CssClass="thumbNailImage" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Channel Name" ControlStyle-Width="180px" HeaderStyle-HorizontalAlign="Left" SortExpression="ChannelName">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Pages/Associate/CampaignToChannel.aspx?ChannelName={0}",
                    HttpUtility.UrlEncode(Eval("ChannelName").ToString())) %>'
                                    Text='<%# Eval("ChannelName").ToString()%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div id="dragdrop" runat="server" style="width: 52%; float: right;margin-top:50px">
            <div style="float: left; width: 44%; border: 3px solid Gray; min-height: 425px; border-radius: 10px; padding: 10px;">
                <h3 style="width: 190px; background-color: rgba(209, 209, 209, 1)" class="h3">Associated Campaigns</h3>
                <asp:Button ID="btnSaveOrder" Text="Apply Changes" runat="server" OnClick="btnSaveOrder_Click" CssClass="button marginBottom17" />
                <div class="content scrollbar" style="height: 350px">
                    <asp:GridView ID="gvDest" GridLines="None" runat="server" ShowHeaderWhenEmpty="true" CssClass="drag_drop_grid Grid" AutoGenerateColumns="false"
                        DataKeyNames="CampaignName,CampaignID" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowSorting="true" OnSorting="gvDest_Sorting">
                        <Columns>
                            <asp:BoundField DataField="CampaignID" Visible="false"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgShow" runat="server" OnClick="imgShow_Click" ImageUrl="~/img/plus.gif" CommandArgument="Show" CssClass="paddingLeft10" />
                                    <asp:Panel ID="pnlPlaylist" runat="server" Visible="false" Style="position: relative">
                                        <asp:GridView ID="gvPlaylist" runat="server" AutoGenerateColumns="false" PageSize="5"
                                            AllowPaging="true" CssClass="Grid marginLeft30" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                                            <Columns>
                                                <asp:BoundField ItemStyle-Width="120px" DataField="PlayListName" HeaderText="PlayList Name" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ItemTemplate>
                                <HeaderStyle BorderWidth="0px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="hidden" name="AssociationId" value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="imgThumbNail" runat="server" ImageUrl='<%# "~/img/" + Eval("FileName") %>' CssClass="thumbNailImage" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField runat="server" ItemStyle-Width="150px" DataTextField="CampaignName" HeaderText="Associated Campaigns"
                                  DataNavigateUrlFormatString="PlayListToCampaign.aspx?CampaignName={0}" DataNavigateUrlFields="CampaignName" SortExpression="CampaignName" />
                            <%--<asp:BoundField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left" DataField="CampaignName"
                                HeaderText="Associated Campaigns" HeaderStyle-HorizontalAlign="Left" SortExpression="CampaignName"></asp:BoundField>--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgUnAssociate" runat="server" OnClick="imgUnAssociate_Click" ImageUrl="~/img/UnAssociate.png" OnClientClick="if ( ! ConfirmUnAssociate()) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div style="float: right; width: 46%; border: 3px solid gray; min-height: 425px; border-radius: 10px; padding: 10px;">
                <h3  class="h3" style="width: 175px; background-color: rgba(206, 206, 204, 1)">Available Campaigns</h3>
                <asp:Label ID="lblNote" runat="server" Text="* Please select a channel and drag & drop <br/> to assign campaigns." CssClass="label" />
                <div class="content scrollbar" style="height: 350px">
                    <asp:GridView ID="gvSource" GridLines="None" runat="server" CssClass="drag_drop_grid Grid" AutoGenerateColumns="false"
                        AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" AllowSorting="true"
                        OnSorting="gvSource_Sorting">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="25px" ItemStyle-Height="20px" ItemStyle-HorizontalAlign="Center" DataField="CampaignID"
                                HeaderText="ID" SortExpression="CampaignID"></asp:BoundField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Image ID="imgThumbNail" runat="server" ImageUrl='<%# "~/img/" + Eval("FileName") %>' CssClass="thumbNailImage" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField ItemStyle-Width="220px" ItemStyle-HorizontalAlign="Left" DataField="CampaignName"
                                HeaderText="Available Campaigns" HeaderStyle-HorizontalAlign="Left" SortExpression="CampaignName"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
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

