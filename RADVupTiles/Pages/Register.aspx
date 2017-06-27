<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Pages_Register" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ OutputCache NoStore="true" Location="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/Loginstyle.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../css/Loginslide.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <link rel="stylesheet" type="text/css" href="../css/Sliderstyle2.css" />
    <script src="../js/modernizr.custom.28468.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Economica:700,400italic' rel='stylesheet' type='text/css'>
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <noscript>
        <link rel="stylesheet" type="text/css" href="../css/nojs.css" />
    </noscript>
    <style>
        .test {
            margin-top: 210px;
        }

        .da-slider {
            margin-left: 30px;
            width: 95%;
            background: #87c2f0;
            border-top: 8px solid #87c2f0;
            border-bottom: 8px solid #87c2f0;
        }

        .anchor {
            font-size: 20px !important;
            text-decoration: underline;
            padding: 10px 20px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px solid #ef7c31;
            background: -moz-linear-gradient( top, #ef7c31 0%, #ef7c31);
            background: -webkit-gradient( linear, left top, left bottom, from(#ef7c31), to(#ef7c31));
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: 14px;
            text-shadow: 0px 1px 2px rgba(000,000,000,0.7);
            text-decoration: none;
        }

            .anchor:hover {
                background: -moz-linear-gradient( top, #87c2f0 0%, #4281b9);
                background: -webkit-gradient( linear, left top, left bottom, from(#87c2f0), to(#4281b9));
                color: #FFFFFF;
                border: 1px solid #1f5d9b;
            }
    </style>
    <script type="text/javascript">
        (function (global, undefined) {
            var demo = {};

            function populateValue() {
                $get(demo.label).innerHTML = $get(demo.textBox).value;
                $find(demo.contentTemplateID).close();
            }

            function openWinContentTemplate() {
                $find(demo.templateWindowID).show();
            }
            function openWinNavigateUrl() {
                $find(demo.urlWindowID).show();
            }

            global.$windowContentDemo = demo;
            global.populateValue = populateValue;
            global.openWinContentTemplate = openWinContentTemplate;
            global.openWinNavigateUrl = openWinNavigateUrl;
        })(window);
        $(function () {
            $('#da-slider').cslider({
                autoplay: true,
                bgincrement: 450,
                interval: 8000
            });
        });
        function ConfirmApproval(objMsg) {
            if (confirm(objMsg)) {
                window.location.href = "StoryPage.aspx?NewUser=true";
                return true;
            }
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div id="body" style="background-color: rgba(233, 233, 233, 1); margin-top: -10px">
        <table class="registerContent" style="margin-left: 50px">
            <tr>
                <td>
                    <h1>Register</h1>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="UserName" placeholder="User Name" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="RegisterUser" ToolTip="User Name is required." ID="UserNameRequired" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:TextBox runat="server" TextMode="Password" ID="Password" placeholder="Password" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="RegisterUser" ToolTip="Password is required." ID="PasswordRequired" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" TextMode="Password" ID="ConfirmPassword" placeholder="Confirm Password" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ValidationGroup="RegisterUser" ToolTip="Confirm Password is required." ID="ConfirmPasswordRequired" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="Email" placeholder="E-mail" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ValidationGroup="RegisterUser" ToolTip="E-mail is required." ID="EmailRequired" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="The Password and Confirmation Password must match." Display="Dynamic" ValidationGroup="RegisterUser" ID="PasswordCompare" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <br />
                    <asp:TextBox runat="server" ID="txtQuestion" placeholder="Secret Question" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQuestion" ErrorMessage="Secret Question is required." ValidationGroup="RegisterUser" ToolTip="Secret Question is required." ID="RequiredFieldValidator2" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:TextBox runat="server" ID="txtAnswer" placeholder="Secret Answer" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAnswer" ErrorMessage="Secret Answer is required." ValidationGroup="RegisterUser" ToolTip="Secret Answer is required." ID="RequiredFieldValidator3" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <br />
                <td align="center" colspan="2" style="color: Red;">
                    <asp:Literal runat="server" ID="ErrorMessage" EnableViewState="False"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:TextBox runat="server" ID="txtCompanyCode" placeholder="Company Code" Width="256px"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompanyCode" ErrorMessage="CompanyCode is required." ValidationGroup="RegisterUser" ToolTip="Company Code is required." ID="RequiredFieldValidator1" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
             <%--       <div class="g-recaptcha" data-sitekey="6Lca8iEUAAAAAGdNCeI-Vcmk9MVk0tCCeezu8Bf6"></div>--%>
                    <recaptcha:RecaptchaControl
                        ID="recaptcha"
                        runat="server"
                        PublicKey="6Lca8iEUAAAAAGdNCeI-Vcmk9MVk0tCCeezu8Bf6"
                        PrivateKey="6Lca8iEUAAAAAHsRdi1B4Fc5CLJY2RWzkjb6L6tz" />
                    <%--       <div class="g-recaptcha" data-sitekey="6Lfc6RwUAAAAAMkcUCmZb5cz9SLnQcSM9iDPumaT"></div>--%>
                    <%--<asp:TextBox ID="CaptchaCode" runat="server" placeholder="Captcha Text" Width="256px" BackColor="White"  />
                                            <asp:Label ID="CaptchaErrorLabel" runat="server" ForeColor="Red" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" CssClass="button" Text="Register" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="footer" style="background-color: black; margin-top: 600px; width: 100%; color: #FFFFFF;">
            <span class="vupFooterText"><a href="Pages/ContactUs.aspx">Contact Us</a></span>
            <span class="vupSeparator">|</span>
            <span class="vupFooterText"><a href="#">Privacy</a></span>
            <span class="vupSeparator">|</span>
            <span class="vupFooterText"><a href="#">Terms of Use</a></span>
            <span class="vupSeparator">|</span>
            <span class="vupCopyright">&copy; Video-Up</span>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

