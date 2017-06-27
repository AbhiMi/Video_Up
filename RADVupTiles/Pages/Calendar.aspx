<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Pages_Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/fullcalendar.css" rel='stylesheet' />
    <%--<link href='../fullcalendar.print.css' rel='stylesheet' media='print' />--%>
    <script src="../js/moment.min.js"></script>
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="../js/fullcalendar.min.js"></script>

    <script>
        $(document).ready(function () {

            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                //defaultDate: '2015-02-12',
                editable: true,
                eventLimit: true, // allow "more" link when too many events
                events: [
                    {
                        title: 'BBB Channel',
                        start: '2015-07-01'
                    },
                    {
                        title: 'BBB Channel 99',
                        start: '2015-07-07',
                        end: '2015-07-10'
                    },
                    {
                        id: 999,
                        title: 'Test Channel',
                        start: '2015-07-09T16:00:00'
                    },
                    {
                        id: 999,
                        title: 'Wallmarts Channel',
                        start: '2015-07-16T16:00:00'
                    },
                    {
                        title: 'Jims Channel',
                        start: '2015-07-11',
                        end: '2015-07-13'
                    },
                    {
                        title: 'Scotts Channel',
                        start: '2015-07-12T10:30:00',
                        end: '2015-07-12T12:30:00'
                    },
                    {
                        title: 'Jims Channel',
                        start: '2015-07-12T12:00:00'
                    },
                    {
                        title: 'Craigs Channel',
                        start: '2015-07-12T14:30:00'
                    },
                    {
                        title: 'Reeboks Channel',
                        start: '2015-07-12T17:30:00'
                    },
                    {
                        title: 'Testing Channel',
                        start: '2015-07-12T20:00:00'
                    },
                    {
                        title: 'Test Channel',
                        start: '2015-07-13T07:00:00'
                    },
                    {
                        title: 'Click for Video-Up',
                        url: 'http://google.com/',
                        start: '2015-07-28'
                    },
                    {
                         title: 'Craigs Channel',
                         start: '2015-07-24',
                         end: '2015-07-27'
                    },
                ]
            });

        });

</script>
    <style>

	body {
		margin: 40px 10px;
		padding: 0;
		font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
		font-size: 14px;
	}

	#calendar {
		max-width: 900px;
		margin: 0 auto;
        float:left;
        margin:10px 0 0 20px;
	}
    .breadcrumb{
        min-height:710px !important;
    }
    #footer, #footer a{
            width: 100%; 
        }
    #footer{
        top:800px !important;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:SiteMapPath ID="SiteMap1" runat="server" CssClass="SiteMap" PathSeparator=" "/>
    <h3>Video-Up Channel Calendar</h3>
    <div id="calendar" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>