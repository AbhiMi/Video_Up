<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.1111/styles/kendo.common.min.css">
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.1111/styles/kendo.rtl.min.css">
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.1111/styles/kendo.default.min.css">
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.1111/styles/kendo.dataviz.min.css">
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.1111/styles/kendo.dataviz.default.min.css">
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.1111/styles/kendo.mobile.all.min.css">

    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <script src="http://kendo.cdn.telerik.com/2015.3.1111/js/kendo.all.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <div id="example">
        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                             <div id="window">
                                <ul class="fieldlist">
                                    <li>
                                        <label for="campaignddl">Campaign</label>
                                        <input id="campaignddl" style="width: 100%;" />
                                    </li>
                                  <li>
                                    <label for="datetimepicker1">Start Time</label>
                                    <input id="datetimepicker1" />
                                  </li>
                                  <li>
                                    <label for="datetimepicker2">End Time</label>
                                    <input id="datetimepicker2" />
                                  </li>
                                </ul>        
                                <button type="button" class="k-button" id="editButton">Save</button>
                                <style>
                                    .fieldlist {
                                        margin: 0 0 -2em;
                                        padding: 0;
                                    }

                                        .fieldlist li {
                                            list-style: none;
                                            padding-bottom: 2em;
                                        }

                                        .fieldlist label {
                                            display: block;
                                            padding-bottom: 1em;
                                            font-weight: bold;
                                            text-transform: uppercase;
                                            font-size: 12px;
                                            color: #444;
                                        }
                                </style>
                            </div>
                             <button class="k-button open-button">Open window</button>
                                <script>
                                    $("#datetimepicker1").kendoDateTimePicker({
                                        animation: false
                                    });
                                    $("#datetimepicker2").kendoDateTimePicker({
                                        animation: false
                                    });
                                    $(document).ready(function () {
                                        $("#campaignddl").kendoDropDownList({
                                            dataTextField: "ProductName",
                                            dataValueField: "ProductID",
                                            dataSource: {
                                                transport: {
                                                    read: {
                                                        dataType: "jsonp",
                                                        url: "//demos.telerik.com/kendo-ui/service/Products",
                                                    }
                                                }
                                            }
                                        });
                                    });
                                 </script>
                                <script>
                                    $(document).ready(function () {
                                        var wnd = $("#window");
                                        $(".open-button").bind("click", function () {
                                            wnd.data("kendoWindow").open();
                                            $(this).hide();
                                        });

                                        $(".close-button").click(function () {
                                            // call 'close' method on nearest kendoWindow
                                            $(this).closest("[data-role=window]").kendoWindow("close");
                                        });

                                        if (!wnd.data("kendoWindow")) {
                                            wnd.kendoWindow({
                                                modal: true,
                                                title: "Dialog window",
                                                close: function () {
                                                    $(".open-button").show();
                                                    },
                                                visible: false
                                            });
                                        }
                                    });
                              </script>
                       </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

