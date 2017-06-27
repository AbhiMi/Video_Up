<%@ Page Title="Contact" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
       
    </address>
     Salt Lake, Utah.
    <address>
      
    </address>
    <asp:Button ID="btnAddAddress" Text="Add Address" runat="server" OnClick="btnAddAddress_Click" class="btn btn-primary btn-large" OnClientClick="RunCodeOnClientSide();" />
</asp:Content>
