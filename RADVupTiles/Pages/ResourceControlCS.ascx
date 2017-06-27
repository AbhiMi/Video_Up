<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResourceControlCS.ascx.cs" Inherits="Pages_ResourceControlCS" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
 
<%--
    This is a custom control used for editing resources that support single values.
     
    It contains a label and DropDownList.
--%>
 
<asp:Label runat="server" ID="ResourceLabel" AssociatedControlID="ResourceValue" Text='<%# Label %>' CssClass="rsAdvResourceLabel" /><!--
--><telerik:RadComboBox runat="server" ID="ResourceValue" CssClass="rsAdvResourceValue" />