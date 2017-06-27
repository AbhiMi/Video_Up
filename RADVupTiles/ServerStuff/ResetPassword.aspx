<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ServerStuff_ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <asp:PasswordRecovery ID="loginPasswordRecovery" runat="server" OnSendingMail="loginPasswordRecovery_SendingMail"></asp:PasswordRecovery>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

