<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Pages_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/AssociationStyle.css" rel="stylesheet" />
    <style>
        .sortasc a  
        {
            display:block; padding:0 4px 0 15px; 
            background:url(Images/asc.gif) no-repeat;  
        }

        .sortdesc a 
        {
            display:block; padding:0 4px 0 15px; 
            background:url(Images/desc.gif) no-repeat;
        }
        div h3 {
            width: 90px !important;
            margin-top: -30px;
            margin-left: 40px;
        }
        .label {
            font-style:normal;
        }
        #footer, #footer a{
            width: 100%; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div id="navbar" class="navbar navbar-fixed-top navbar-inverse">
            <div class="navbar-inner">
                <div class="container">
                    <div class="nav-collapse collapse">
                        <ul class="nav">
                            <li class="active">
                                <a class="brand" href="..\Default.aspx">Video-Up</a>
                            </li>
                            <li><a class="active" href="..\Default.aspx"><i class="icon-white icon-th-large"></i>Dashboard</a></li>
                            <%--<li><a href="AppStore.aspx"><i class="icon-white icon-shopping-cart"></i>Apps</a></li>--%>
                        </ul>
                        <ul class="nav pull-right">
                            <%--<li><a href="javascript:fullscreen()"><i class="icon-facetime-video"></i>Go Fullscreen</a></li>--%>
                            <li><a href="ServerStuff/Logout.ashx"><i class="icon-white icon-refresh"></i>Reset</a></li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-white icon-tint"></i>Theme<b class="caret"></b></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#" onclick="ui.switchTheme('theme-green')">Metallic Gray</a></li>
                                    <li><a href="#" onclick="ui.switchTheme('theme-white')">White</a></li>
                                    <li><a href="#" onclick="ui.switchTheme('theme-Bloom')">Bloom</a></li>
                                </ul>
                            </li>
                            <li data-bind="if: user().isAnonymous"><a onclick="ui.login()" href="#login"><i class="icon-white icon-user"></i>Login</a></li>
                            <li data-bind="if: !user().isAnonymous"><a href="ServerStuff/Logout.ashx"><i class="icon-white icon-user"></i>Logout</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    <div style="padding: 20px; border: 3px solid gray; border-radius: 10px; margin: 60px 25px 0 0px; background: transparent url(../img/wallpapers/Brushed-Metal.jpg);
         position: relative; background-repeat: repeat;width:71%;float:right;min-height:405px;color:#343553">
         <h3>Contact Us</h3><br />
        <img src="../img/ContactUS.png" /> <br /><br />
        Please contact the IS Helpline for help and support with software or any other computing issues using the number below.<br /><br />
       <b> IS Helpline <br />
        Web: Self service portal (preferred)<br />
        Email: IS.Helpline@video-up.com<br />
        Phone: (804)(xxx)(xxxx)<br /></b>
        For product support issues, please <a href="#">Contact Support.</a>
    </div>
    <div id="footer">
        <span class="vupFooterText"><a href="ContactUs.aspx">Contact Us</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Privacy</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupFooterText"><a href="#">Terms of Use</a></span>
        <span class="vupSeparator">|</span>
        <span class="vupCopyright"> &copy;Video-Up</span>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

