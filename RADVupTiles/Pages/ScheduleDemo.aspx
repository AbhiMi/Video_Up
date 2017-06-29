<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="ScheduleDemo.aspx.cs" Inherits="Pages_ScheduleDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/Loginstyle.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../css/Loginslide.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <link rel="stylesheet" type="text/css" href="../css/Sliderstyle2.css" />
    <script src="../js/modernizr.custom.28468.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Economica:700,400italic' rel='stylesheet' type='text/css'>
    <noscript>
        <link rel="stylesheet" type="text/css" href="../css/nojs.css" />
    </noscript>
    <script type="text/javascript" src="../js/jquery.cslider.js"></script>
    <script src="../js/slide.js"></script>
    <link href="../css/AssociationStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div style="width: 95%;background-color:"#e0e3ec url(../img/bg.png) repeat top left">
        <div style="float: left; width: 65%" class="RADCycle">
            <table border="0" style="width: 409px; margin: 40px">
                <tr>
                    <td>
                        <h2 style="font-weight: bold">Schedule a Demo</h2>
                        <br />
                        <br />
                        <br />
                    </td>
                    <td></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email*"></asp:Label><br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
                        <asp:RegularExpressionValidator ID="valRegEx" runat="server"
                            ControlToValidate="txtEmail"
                            ValidationExpression=".*@.*\..*"
                            ErrorMessage="*Invalid Email address."
                            Display="dynamic">
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name*"></asp:Label><br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" ValidationGroup="contact"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCompany" runat="server" Text="Company*"></asp:Label><br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompany" runat="server" ValidationGroup="contact"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                            ControlToValidate="txtCompany"></asp:RequiredFieldValidator>
                    </td>
                </tr>
               <tr>
                    <td>
                       <asp:Label ID="lblSubject" runat="server" Text="Subject*"></asp:Label><br />
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlSubject" runat="server">
                            <asp:ListItem Text="I want someone to call / contact me" Value="0" Selected="True" />
                            <asp:ListItem Text="I got a question" Value="1" />
                            <asp:ListItem Text="Learn more about Video-Up" Value="2" />
                        </asp:DropDownList><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="ddlSubject"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblContactNo" runat="server" Text="ContactNo*"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="txtContactNo"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOfficeExtn" runat="server" Text="Office Contact "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOfficeExtn" runat="server"></asp:TextBox> / Extn# <asp:TextBox ID="txtExtn" runat="server" Width="100px"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                            ControlToValidate="txtOfficeExtn"></asp:RequiredFieldValidator>
                    </td>
                </tr>
               <tr>
                    <td>
                        <asp:Label ID="lblCompanySiteUrl" runat="server" Text="Company SiteUrl"></asp:Label><br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanySiteUrl" runat="server" ValidationGroup="contact"></asp:TextBox><br /><br />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSend" runat="server" Text="Schedule Demo" OnClick="btnSend_Click" CssClass="button" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

