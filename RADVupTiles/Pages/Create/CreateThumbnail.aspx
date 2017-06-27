<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CreateThumbnail.aspx.cs" Inherits="Pages_Create_CreateThumbnail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../js/jquery-1.3.2.min.js"></script>
    <script>        
        function getCurTime() {
            //var video = $('#myVideo');
            var vid = document.getElementById('<%=myVideo.ClientID%>');
            var jsVar = vid.currentTime;
            // Set the value of the hidden variable to
            // the value of the javascript variable
            var hiddenControl = '<%= inpHide.ClientID %>';
            document.getElementById(hiddenControl).value = jsVar;
            //alert(vid.currentTime);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <input id="inpHide" type="hidden" runat="server" />  
    <video id="myVideo" runat="server" width="320" height="176" controls>              
        Your browser does not support HTML5 video.
    </video>
    <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" OnClientClick="getCurTime()"
        Text="Get Frame" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

