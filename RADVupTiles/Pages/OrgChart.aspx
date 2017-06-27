<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="OrgChart.aspx.cs" Inherits="Pages_OrgChart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
     <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <div class="demo-container no-bg">
        <telerik:RadOrgChart RenderMode="Lightweight" runat="server" ID="RadOrgChart1" 
            EnableCollapsing="true" EnableDrillDown="true" EnableGroupCollapsing="true">
            <Nodes>
                <telerik:OrgChartNode>
                    <RenderedFields>
                        <telerik:OrgChartRenderedField Text="CEOs" />
                    </RenderedFields>
                    <GroupItems>
                        <telerik:OrgChartGroupItem Text="Jim Neeley" />
                    </GroupItems>
                    <Nodes>
                        <telerik:OrgChartNode>
                            <GroupItems>
                                <telerik:OrgChartGroupItem Text="Scott Wallace">
                                    <RenderedFields>
                                        <telerik:OrgChartRenderedField Text="Team Leader" />
                                    </RenderedFields>
                                </telerik:OrgChartGroupItem>
                            </GroupItems>
                            <Nodes>
                                <telerik:OrgChartNode ColumnCount="2">
                                    <GroupItems>
                                        <telerik:OrgChartGroupItem Text="Abhishek Mishra" />
                                        <telerik:OrgChartGroupItem Text="Tarun Srivastav" />
                                    </GroupItems>
                                </telerik:OrgChartNode>
                            </Nodes>
                        </telerik:OrgChartNode>
                        <telerik:OrgChartNode>
                            <GroupItems>
                                <telerik:OrgChartGroupItem Text="Craig Wallace">
                                    <RenderedFields>
                                        <telerik:OrgChartRenderedField Text="Team Leader" />
                                    </RenderedFields>
                                </telerik:OrgChartGroupItem>
                            </GroupItems>
                            <Nodes>
                                <telerik:OrgChartNode ColumnCount="2">
                                    <GroupItems>
                                        <telerik:OrgChartGroupItem Text="Srikant Prasad" />
                                    </GroupItems>
                                </telerik:OrgChartNode>
                            </Nodes>
                        </telerik:OrgChartNode>
                    </Nodes>
                </telerik:OrgChartNode>
            </Nodes>
        </telerik:RadOrgChart>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

