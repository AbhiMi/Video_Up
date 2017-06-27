<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="RADScheduler.aspx.cs" Inherits="Pages_RADScheduler" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="scheduler" TagName="AdvancedForm" Src="AdvancedFormCS.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server"></telerik:RadSkinManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadScheduler ID="RadScheduler1" runat="server" DataEndField="EndDateTime" DataStartField="StartDateTime"
        DataKeyField="CampaignID" DataSubjectField="CampaignName" OnAppointmentCreated="RadScheduler1_AppointmentCreated"
        OnDataBound="RadScheduler1_DataBound" OnAppointmentInsert="RadScheduler1_AppointmentInsert" OnAppointmentDataBound="RadScheduler1_AppointmentDataBound"
        OnAppointmentUpdate="RadScheduler1_AppointmentUpdate" SelectedView="MonthView" AllowInsert="false">
        <AdvancedForm Modal="true" EnableTimeZonesEditing="true" />
        <AdvancedEditTemplate>
            <scheduler:advancedform runat="server" id="AdvancedEditForm1" mode="Edit" subject='<%# Bind("Subject") %>'
                start='<%# Bind("Start") %>' end='<%# Bind("End") %>' />
        </AdvancedEditTemplate>
        <AdvancedInsertTemplate>
            <scheduler:advancedform runat="server" id="AdvancedInsertForm1" mode="Insert" subject='<%# Bind("Subject") %>'
                start='<%# Bind("Start") %>' end='<%# Bind("End") %>' />
        </AdvancedInsertTemplate>
    </telerik:RadScheduler>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

