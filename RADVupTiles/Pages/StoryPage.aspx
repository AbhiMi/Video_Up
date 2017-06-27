<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="StoryPage.aspx.cs" Inherits="Pages_StoryPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ OutputCache NoStore="true" Location="None" %>

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
            .Story {
            visibility:visible !important;
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
        function OpenChild() {
            var WinSettings = "center:yes;resizable:no;dialogHeight:400px"
            // ALTER BELOW LINE - supply correct URL for Child Form
            var params = new Array();
            var MyArgs = window.showModalDialog("ScheduleDemo.aspx", params, WinSettings);
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="Server">
    <div id="body" style="background-color: rgba(233, 233, 233, 1);margin-top:-90px;">
        <div style="margin: 20px;margin-left:10%">
            <img src="../Images/SampleBanner.jpg" style="height: 500px;" />
        </div>
        <div id="da-slider" class="da-slider" style="margin-top: 20px">
            <div class="da-slide">
                <h2>How it works</h2>
                <p>
                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.
                    <small style="font-size: medium;">
                        <br />
                        is a test text from vup</small>
                </p>
                <a href="Pages/HowitWorks.aspx" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/2.png" alt="image01" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Retailers</h2>
                <p>
                    Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean.
                    <small style="font-size: medium;">
                        <br />
                        is a test text from vup</small>
                </p>
                <a href="Pages/Retailers.aspx" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/2.png" alt="image01" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Product Manufactures</h2>
                <p>A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.</p>
                <a href="Pages/ProductManufacturers.aspx" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/3.png" alt="image01" />
                </div>
            </div>
            <div class="da-slide">
                <h2>Entertainment</h2>
                <p>
                    When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road,
                    the Line Lane.
                </p>
                <a href="Pages/Entertainment.aspx" class="da-link">Read more</a>
                <div class="da-img">
                    <div class="da-img">
                        <img src="../img/1.png" alt="image01" />
                    </div>
                </div>
            </div>
            <div class="da-slide">
                <h2>Service</h2>
                <p>Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar.</p>
                <a href="Pages/Service.aspx" class="da-link">Read more</a>
                <div class="da-img">
                    <img src="../img/4.png" alt="image01" />
                </div>
            </div>
            <nav class="da-arrows">
                <span class="da-arrows-prev"></span>
                <span class="da-arrows-next"></span>
            </nav>
        </div>
        <div id="footer" style="background-color: black; width: 100%; color: #FFFFFF;">
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

