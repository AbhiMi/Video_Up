<%@ Page Language="C#" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="Pages_ErrorPages_404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 100px; margin-top: 90px;font-family: Verdana, Arial, Helvetica, sans-serif !important; font-size: 16px !important;"">
            <asp:Image runat="server" ImageUrl="~/Images/404.png" ID="img2" />
            <br />
            <asp:LinkButton runat="server" ID="lnk1" PostBackUrl="~/ServerStuff/Login.aspx" Text="Click here go to Login"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
