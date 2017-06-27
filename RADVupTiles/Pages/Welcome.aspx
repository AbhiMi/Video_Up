<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Pages_Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: rgba(233, 233, 233, 1);font-family:Verdana, Arial, Helvetica, sans-serif !important;font-size:13px">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <link href="../css/jquery.autocomplete.css" rel="stylesheet" />
    <link href="../css/demo_style.css" rel="stylesheet" />
    <link href="../css/smart_wizard_vertical.css" rel="stylesheet" />
    <script src="../js/jquery-1.4.2.min.js"></script>
    <script src="../js/jquery.smartWizard-2.0.min.js"></script>
    <script src="../Scripts/jquery.autocomplete.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <link href='https://fonts.googleapis.com/css?family=Carrois+Gothic+SC' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <style>
        body, .divs{
            font-family:  "Segoe UI",Arial,Helvetica,sans-serif !important;
            font-size: 14px !important;
        }
        .listitem li {
          font-family:  "Segoe UI",Arial,Helvetica,sans-serif !important;
          font-size: 14px !important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".divs div").each(function (e) {
                if (e != 0)
                    $(this).hide();
            });

            $("#next").click(function () {
                if ($(".divs div:visible").next().length != 0) {
                    $(".divs div:visible").next().show().prev().hide();
                    var pageSize = parseInt($("#pageSize").html()) + 1;
                    $("#pageSize").html(pageSize);
                    console.log(pageSize);
            }
                else {
                    $("#pageSize").html(1);
                    $(".divs div:visible").hide();
                    $(".divs div:first").show();
                }
                return false;
            });

            $("#prev").click(function () {
                if ($(".divs div:visible").prev().length != 0) {
                    $(".divs div:visible").prev().show().next().hide();
                    var pageSize = parseInt($("#pageSize").html()) - 1;
                    $("#pageSize").html(pageSize);
                }
                else {
                    $("#pageSize").html(8);
                    $(".divs div:visible").hide();
                    $(".divs div:last").show();
                }
                return false;
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divs" style="height:450px">
            <div class="cls1" style="padding: 20px; text-align: center">
                <h1 style="text-align: center; color: #ef7c31;">Welcome to Video-Up!
                    <br />
                </h1>
                Your video distribution solution with shopper analytical feedback.<br />
                <%--<img src="../img/Mini_RADCycle.jpg" width="100px" height="100px" />--%>
                      <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0"
                    width="200" height="200">
                    <%-- in the value below line give the path of the folder in which you are storing the .swf file& bind the datalist with the colum name of the database with eval function --%>

                    <param name="movie" value="../../Swf/RADCycle_NoNavigation.swf" />
                    <param name="quality" value="high" />
                    <%-- in the src below line give the path of the folder in which you are storing the .swf file--%>
                    <embed src="../../Swf/RADCycle_NoNavigation.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                        type="application/x-shockwave-flash" width="200px" height="200px" />
                </object>
                <br />
                This app will allow you to
                <ul style="text-align: left; margin-left: 50px" class="listitem">
                    <li>Create, manage, and schedule video campaigns </li>
                    <li>Measure campaign and video performance </li>
                    <li>Track RAD Devices across many locations, areas, and regions</li>
                    <li>Create and Manage User Accounts and Roles</li>
                </ul>
                Let's start a quick overview
                <div style="padding-bottom:20px"></div>
            </div>
            <div class="cls2" style="padding: 20px">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: Locations<img src="../img/location-icon.png" width="100px" height="100px" style="float: right; margin-top: -35px;" /></h1>
               <br /> A location is a place where RAD Device(s) reside. Locations allow you to track your <br />
                devices and performance across your organsization. <br />
            </div>
            <div class="cls3" style="padding: 20px">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: Users<img src="../img/Users.png" width="100px" height="100px" style="float: right; margin-top: -35px;" /></h1>
               <br /> Take Control, you can create user accounts for individual members of your team. <br />
                Creating users allow you to define and manage permissions for each user. <br />
                Users can also be assigned to Role(s) with predefined permissions.
                <br />
            </div>
            <div class="cls4" style="padding: 20px">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: RAD Devices<img src="../img/skull-8-xxl.png" width="100px" height="100px" style="float: right; margin-top: -35px;" /></h1>
               <br /> Now that you have a location, RAD Device(s) can be assigned and their status monitored by selecting the RAD Device icon.
                <br />
            </div>
            <div class="cls5" style="padding: 20px;">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: Physical RAD Device Setup
                    <img src="../img/Setup.png" width="100px" height="100px" style="float: right;" /></h1>
                Now that you have a location, the individual RAD Devices are ready to be installed.<br />
                Video-up will guide you through this process using the RAD Device Setup Wizard. 
                <ul>
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 10px 100px"></li>
                </ul>
            </div>
            <div class="cls6" style="padding: 20px;">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: The RAD Cycle </h1>
                <p style="text-align: center">Use the following RAD Cycle steps to design and rollout your video solutions.</p>
                <ul>
                    <img src="../img/Icon_MissionControl.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em;margin:-75px 0 20px 110px">Mission Control:  The place to view RAD Device, Locations and User Status </li>
                    <img src="../img/Icon_DesignCampaign.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 20px 110px">Design Campaign:  Create and manage video campaigns </li>
                    <img src="../img/Icon_UploadMedia.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 0 110px">Upload Media:  Central location for uploading and managing video</li>
                    </ul>
                </div>
            <div class="cls7" style="padding: 20px;">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: The RAD Cycle</h1>
                <p style="text-align: center">Use the following RAD Cycle steps to design and rollout your video solutions.</p>
                <ul>
                    <img src="../img/Icon_CustomizePlaylist.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 20px 105px">Customize Playlist:  Fine tune your videos into groups </li>
                    <img src="../img/Icon_ViewPublish.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 20px 105px">Preview & Assign Campaign:  Assign videos to Campaigns and preview them </li>
                    <img src="../img/Icon_ChannelGuide.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 20px 105px">Channel Guide:  Create your play schedule and take it live! </li>
                    </ul>
                </div>
            <div class="cls8" style="padding: 20px;">
                <h1 style="text-align: center; color: #ef7c31">Getting Started: The RAD Cycle</h1>
                <p style="text-align: center">Use the following RAD Cycle steps to design and rollout your video solutions.</p>
                <ul>
                    <img src="../img/Icon_AccessPerformance.png" width="85px" height="85px" />
                    <li style="list-style-type: decimal; line-height: 4.5em; margin:-75px 0 20px 110px">Access Performance: good, better, best performing campaigns and videos.</li>
                </ul>
            </div>
        </div>
        <div style="padding: 20px 0 0 20px;font-weight:bold">
            <a id="prev" style="cursor: pointer; text-decoration: underline; margin-top: 20px; color: #ef7c31; font-weight: bold">PREV</a>
            <span id="pageSize" style="margin-top: 20px;margin-left:250px;font-weight: bold">1</span> of 8
            <div style="float: right; padding-right: 20px">
                <a id="next" style="cursor: pointer; text-decoration: underline; margin-top: 20px; color: #ef7c31; font-weight: bold">NEXT</a>
            </div>

        </div>
    </form>
</body>
</html>
