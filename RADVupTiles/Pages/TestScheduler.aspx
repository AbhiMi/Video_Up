<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="TestScheduler.aspx.cs" Inherits="Pages_TestScheduler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.930/styles/kendo.common.min.css">  
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.930/styles/kendo.rtl.min.css">  
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.930/styles/kendo.default.min.css">  
    <link rel="stylesheet" href="http://kendo.cdn.telerik.com/2015.3.930/styles/kendo.mobile.all.min.css">  
      <script src="../js/jquery-1.4.2.min.js"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>  
    <script src="http://kendo.cdn.telerik.com/2015.3.930/js/angular.min.js"></script>  
    <script src="http://kendo.cdn.telerik.com/2015.3.930/js/jszip.min.js"></script>  
    <script src="http://kendo.cdn.telerik.com/2015.3.930/js/kendo.all.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="scheduler">
        <div data-role="scheduler"
            data-bind="source: Campaigns,
    visible: isVisible,"
            style="height: 600px" data-selectable="true">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
    <script type="text/javascript">
        var viewModel = kendo.observable({
            isVisible: true,
            Campaigns: new kendo.data.SchedulerDataSource({                
                transport:
                  {
                      read:
                       {
                           url: "http://localhost:63813/Services/SchedulerService.svc/GetCampaignNames/5",
                           dataType: "json"
                       },

                      parameterMap: function(options, operation) {
                          var parameter = {
                              $top: options.take,
                              $skip: options.skip,
                              $select: 'CampaignID,CampaignName',
                              $orderby: options.sort[0].field + ' ' + options.sort[0].dir
                          };
                          return parameter;

                      }
                  },

                schema: {
                    model: {
                        id: "CampaignID",
                        fields: {
                            campaignId: { from: "CampaignID", type: "number" },
                            title: { from: "Title", defaultValue: "No title", validation: { required: true } },
                            start: { type: "date", from: "StartTime" },
                            end: { type: "date", from: "EndTime" },
                            isAllDay: { type: "boolean", from: "IsAllDay" }
                        }
                    }
                }
            })
        });
        kendo.bind($("#example"), viewModel);
    </script>
    
</asp:Content>

