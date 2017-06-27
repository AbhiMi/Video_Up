<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/VideoUp.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/jquery.slides.min.js"></script>
    <link href="Content/Slide.css" rel="stylesheet" />
    <script>
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
    <div id="wrapper" style="margin-top: 20px">
        <!-- The slider wrapper div  -->
        <div class="slider-wrapper theme-default">
            <div id="slider" class="nivoSlider" style="width: 100%; height: 505px">
                <!--  Images to slide through.  -->
                <img src="Images/Desert.jpg" />
                <img src="Images/Jellyfish.jpg" />
                <img src="Images/Koala.jpg" />
                <img src="Images/Chrysanthemum.jpg" />

                <img src="Images/Desert.jpg" />
            </div>
            <!--  Captions to show for images  -->
            <div id="htmlcaption" class="nivo-html-caption">
                <strong>This</strong> is an example of a <em>HTML</em> caption with <a href="#">a link</a>. 
            </div>
        </div>

    </div>
    <div class="latest">
        <div class="row">
            <h1 class="lead-tag left" title="the latest from kawasaki">The Latest from Video-Up</h1>
            <div class="late-line right"></div>
            <div class="row">
                <ul class="options inline-list" style="font-size: 1.1em">
                    <li class="three">
                        <p onclick="RecordMetric_PageView('OFFERS-PROMOTIONS', 'HOMEPAGE BUCKET');" class="late-list first active">view it</p>
                    </li>
                    <li class="one">
                        <p onclick="RecordMetric_PageView('NEW VEHICLES', 'HOMEPAGE BUCKET');" class="late-list">feel it</p>
                    </li>
                    <li class="two">
                        <p onclick="RecordMetric_PageView('SOCIAL COMMUNITIES', 'HOMEPAGE BUCKET');" class="late-list">buy it</p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row" style="margin-top: 20px">
                <div class="col-md-4">
                    <h2>RAD Devices</h2>
                    <p>
                        The RAD Devices are miniature computers and need to  be capable of performing standard tasks such as internet connectivity, playing videos, saving files, and connecting with USB peripherals and multimedia displays. However, unlike your standard computer, the RAD Device is designed to operate in an autonomous fashion without a keyboard, mouse, or any other "standard" Human Interface Device. 
                    </p>
                    <p>
                        <a class="btn btn-primary btn-large" href="#">Learn more &raquo;</a>
                    </p>
                </div>
                <div class="col-md-4">
                    <h2>Upload Videos</h2>
                    <p>
                        When uploading video content, each file must be given a unique name for use within RAD Command.  Clients can also add a description and tags so they can quickly identify it in their video library, and can also add other identifiers yet to be determined that will help the client glean data from their efforts.  Once RAD Devices are organized and video-content is present, the client can progress further through the RAD Cycle.
                    </p>
                    <p>
                        <a class="btn btn-primary btn-large" href="#">Learn more &raquo;</a>
                    </p>
                </div>
                <div class="col-md-4">
                    <h2>RAD Sensors</h2>
                    <p>
                        RAD Sensors are microprocessor-driven proximity detectors (see Figure 7), which are used by RAD Devices to monitor for the presence of individuals. Besides detecting proximity, these sensors will communicate with the RAD Device to receive firmware updates and send/receive various commands to and from the RAD Device. RAD Sensors are microprocessor-driven proximity detectors.
                    </p>
                    <p>
                        <a class="btn btn-primary btn-large" href="#">Learn more &raquo;</a>
                    </p>
                </div>
            </div>
</asp:Content>
