<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="ServerStuff.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/Loginstyle.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="../css/Loginslide.css" rel="stylesheet" type="text/css" media="screen" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/demo.css" />
    <link rel="stylesheet" type="text/css" href="../css/Sliderstyle2.css" />
    <script src="../js/modernizr.custom.28468.js"></script>
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <link href='http://fonts.googleapis.com/css?family=Economica:700,400italic' rel='stylesheet' type='text/css'>
    <noscript>
        <link rel="stylesheet" type="text/css" href="../css/nojs.css" />
    </noscript>
    <script type="text/javascript" src="../js/jquery.cslider.js"></script>
    <script src="../js/slide.js"></script>
    <style>
        .test
        {
            margin-top:210px;
        }
         .da-slider {
             margin-top:30px;
         }
    </style>
    <script type="text/javascript">
        function ShowTogglePopup() {
            $('#da-slider').css("margin-top", "210px");
            $('.da-slider').css("margin-top", "210px");
            $(".da-slider").css({ "margin-top": "210px" });
            $("div#panel").slideDown("slow");
            $("div#panel").css({ "height": "200px" });
            $("div#toppanel").css({ "height": "480px" });
            $("div#menu").css({ "height": "200px" });
            $(".registerContent").css({ "display": "none" });
            $(".loginContent").css({ "display": "block" });
            if (document.getElementById("ctl00_body_txtUserName").value == '' || document.getElementById("ctl00_body_txtPassword").value == '')
            {
                alert('Please enter User Name and Password to login. ');
                document.getElementById("ctl00_body_txtUserName").focus();
                return false;
            }
            else
            {
                return true;
            }
            
        }
        function showRegisterTogglePopup() {
            $("div#panel").slideDown("slow");
            $(".da-slider").css({ "margin-top": "450px", "slideDown": "slow" });
            $("div#panel").css({ "height": "410px" });
            $("div#toppanel").css({ "height": "410px" });
            $("div#menu").css({ "height": "350px" });
            $(".loginContent").css({ "display": "none" });
            $(".registerContent").css({ "display": "block" });
            if (document.getElementById("ctl00_body_UserName").value == '' || document.getElementById("ctl00_body_Password").value == document.getElementById("ctl00_body_ConfirmPassword").value == ''
                || document.getElementById("ctl00_body_Email").value == '' || document.getElementById("ctl00_body_txtCompanyCode").value == ''
                || document.getElementById("ctl00_body_CaptchaCode").value == '') {
                alert('Please enter all the required fields to register. ');
                document.getElementById("ctl00_body_UserName").focus();
                return false;
            }
            if (document.getElementById("ctl00_body_Email").value != '') {
                var x = document.getElementById("ctl00_body_Email").value;
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");
                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    alert("Not a valid e-mail address");
                    document.getElementById("ctl00_body_Email").focus();
                    return false;
                }
            }
        }
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
                bgincrement: 450
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="body">
        <div id="toppanel">
            <div id="panel">
                <div id="menu">
                    <div class="content clearfix">
                        <div class="left">
                            <form class="clearfix" runat="server" id="LoginForm">
                                <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                                <asp:HiddenField runat="server" ID="hdnIsPostback" value="<%=Page.IsPostBack.ToString()%>" />
                                <table class="loginContent">
                                    <tr>
                                        <td>
                                            <h1>Member Login</h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="field" placeholder="Username"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" CssClass="field" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox></td>
                                        <td>
                                            <nobr><a class="lost-pwd" href="#" style="margin-bottom: 10px;font-family: 'Century Gothic';">Lost your password?</a></nobr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <br />
                                            <label style="font-family: 'Century Gothic';">
                                                <input name="rememberme" id="rememberme" type="checkbox" checked="checked" value="forever" />
                                                &nbsp;Remember me</label></td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;&nbsp;
                                            <asp:Button ID="LoginButton" OnClick="LoginButton_Click" runat="server" CssClass="bt_login" Text="Login" OnClientClick="return ShowTogglePopup()" />
                                        </td>
                                    </tr>
                                    <div class="clear"></div>
                                </table>
                                <table class="registerContent">
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
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal runat="server" ID="ErrorMessage" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCompanyCode" placeholder="Company Code" Width="256px"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCompanyCode" ErrorMessage="CompanyCode is required." ValidationGroup="RegisterUser" ToolTip="Company Code is required." ID="RequiredFieldValidator1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div class="g-recaptcha" data-sitekey="6Lfc6RwUAAAAAMkcUCmZb5cz9SLnQcSM9iDPumaT"></div>
                                            <%--<asp:TextBox ID="CaptchaCode" runat="server" placeholder="Captcha Text" Width="256px" BackColor="White"  />
                                            <asp:Label ID="CaptchaErrorLabel" runat="server" ForeColor="Red" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" CssClass="bt_login" Text="Register" 
                                                OnClientClick="return showRegisterTogglePopup()" />
                                        </td>
                                    </tr>
                                </table>
                                <div class="clear"></div>
                                <telerik:RadWindow RenderMode="Lightweight" runat="server" ID="RadWindow_NavigateUrl" NavigateUrl="~/Pages/Create/CreateNewUser.aspx"
                                    Modal="true" InitialBehaviors="Maximize" RestrictionZoneID="NavigateUrlZone" Width="100px">
                                </telerik:RadWindow>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab" style="float:right">
                <ul class="login">
                    <li class="left">&nbsp;</li>
                    <li><span style="font-family: 'Century Gothic';">Hello Guest !</span></li>
                    <li class="sep">|</li>
                    <li class="toggle">
                        <a id="open" class="open" href="#" style="width: 40px">Log In</a>
                    </li>
                    <li class="toggle">
                        <a id="register" class="register" href="#" style="margin-top: 2px">Register</a>
                        <a id="close" style="display: none;" class="topclose" href="#">Close Panel</a>
                    </li>
                    <li class="right">&nbsp;</li>
                </ul>
            </div>
        </div>
        <div id="da-slider" class="da-slider">
            <div class="da-slide">
                <h2>Easy management</h2>
                <p>
                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.
                    <small style="font-size: medium;">
                        <br />
                        is a test text from Srikant</small>
                </p>
                <a href="#" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/2.png" alt="image01" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Revolution</h2>
                <p>A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.</p>
                <a href="#" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/3.png" alt="image01" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Warm welcome</h2>
                <p>
                    When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road,
                    the Line Lane.
                </p>
                <a href="#" class="da-link">Read more</a>
                <div class="da-img">
                    <div class="da-img">
                        <img src="../img/1.png" alt="image01" />
                    </div>
                </div>
            </div>
            <div class="da-slide">
                <h2>Quality Control</h2>
                <p>Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar.</p>
                <a href="#" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/4.png" alt="image01" />
                </div>
            </div>
            <nav class="da-arrows">
                <span class="da-arrows-prev"></span>
                <span class="da-arrows-next"></span>
            </nav>
        </div>
    </div>
    <script type="text/javascript">
       Sys.Application.add_load(function () {
            $windowContentDemo.urlWindowID = "<%=RadWindow_NavigateUrl.ClientID %>";
        });

    </script>
</asp:Content>
