<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomErrorPage.aspx.cs" Inherits="Pages_ErrorPages_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 50px; margin-top: 30px; color: white; font-family: Verdana, Arial, Helvetica, sans-serif !important; font-size: 16px !important;">
            <table border="2px" style="background-color: #ef7c31 !important; border-color: #cdcdcd;">
                <tr>
                    <td>
                        <asp:Image runat="server" ImageUrl="~/Images/error.jpg" ID="img1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>"Oops! Something went wrong."
                            <br />
                            "The application has encountered an unknown error."
                        </h3>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:LinkButton runat="server" ID="lnk1" PostBackUrl="~/ServerStuff/Login.aspx" Text="Click here go to Login"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
