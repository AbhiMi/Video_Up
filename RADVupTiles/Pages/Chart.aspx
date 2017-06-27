<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="Pages_Chart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="margin-left: 200px">
        <asp:Chart ID="Chart1" runat="server" Height="450px" Palette="EarthTones" Width="874px">
            <Series>
                <asp:Series ChartArea="ChartArea1" Legend="Dotnet Chart Example" Name="Channels" YValueType="Int32">
                    <Points>
                        <asp:DataPoint AxisLabel="Sports Channel" YValues="10" />
                        <asp:DataPoint AxisLabel="Training" YValues="20" />
                        <asp:DataPoint AxisLabel="VUP Channel" YValues="50" />
                        <asp:DataPoint AxisLabel="Ski" YValues="30" />
                        <asp:DataPoint AxisLabel="Abhishek's Channel" YValues="40" />
                    </Points>
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" Name="Dotnet Chart Example" />
            </Legends>
        </asp:Chart>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

