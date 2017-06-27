<%@ Page Title="" Language="C#" MasterPageFile="~/RADVupTiles.master" AutoEventWireup="true" CodeFile="CampaignPreview.aspx.cs" Inherits="Pages_CampaignPreview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../js/jquery-1.9.1.min.js"></script>
    <script src="../js/jquery.fancybox.js"></script>
    <script src="../js/jquery.fancybox.pack.js"></script>
    <link href="../css/jquery.fancybox.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            fancyPopup();
        });

        function fancyPopup() {
            // Declare some variables.
            var el = "";
            var posterPath = "";
            var replacement = "";
            var videoTag = "";
            var fancyBoxId = "";
            var posterPath = "";
            var videoTitle = "";

            // Loop over each video tag.
            $("video").each(function () {
                // Reset the variables to empty.
                el = "";
                posterPath = "";
                replacement = "";
                videoTag = "";
                fancyBoxId = "";
                posterPath = "";
                videoTitle = "";

                // Get a reference to the current object.
                el = $(this);

                // Set some values we'll use shortly.
                fancyBoxId = this.id + "_fancyBox";
                videoTag = el.parent().html();      // This gets the current video tag and stores it.
                posterPath = el.attr("poster");
                videoTitle = "Play Video " + this.id;


                // Concatenate the linked image that will take the place of the <video> tag.
                replacement = "<a title='" + videoTitle + "' id='" + fancyBoxId + "' href='javascript:;'><img src='" +
                    posterPath + "' class='img-link'/></a>"

                // Replace the parent of the current element with the linked image HTML.
                el.parent().replaceWith(replacement);

                /*
                Now attach a Fancybox to this item and set its attributes. 
                   
                This entire function acts as an onClick handler for the object to
                which it's attached (hence the "end click function" comment).
                */
                $("[id=" + fancyBoxId + "]").fancybox(
                {
                    'content': videoTag,
                    'title': videoTitle,
                    'autoDimensions': true,
                    'padding': 5,
                    'showCloseButton': true,
                    'enableEscapeButton': true,
                    'titlePosition': 'outside',
                }); // end click function
            });
        }
    </script>
    <style type="text/css">
        #mymain {
            width: 16px;
            margin: 0px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <asp:HiddenField ID="hdnVideoNames" runat="server" />
    <video id="ctrlVideo" runat="server" width="480" height="360" poster="../img/Player%20Play.png" controls preload>
    </video>
    <div id="mymain">
    </div>
    <script type="text/javascript">
        <%-- $(document).ready(function () {
            console.log("ready!");
            //songNames holds the comma separated name of songs
            $('#<% =hdnVideoNames.ClientID %>')
            });--%>
        //$(function () {
            //Find the audio control on the page
            var video = document.getElementById('<%=ctrlVideo.ClientID%>');
            //songNames holds the comma separated name of songs
            var videoNames = document.getElementById('<%=hdnVideoNames.ClientID%>');
            var lstvideoNames = videoNames.value.split(',');
            var curPlaying = 0;
            // Attaches an event ended and it gets fired when current playing song get ended
            video.addEventListener("ended", function () {
                var urls = video.getElementsByTagName('source');
                // Checks whether last song is already run
                if (urls[0].src.indexOf(lstvideoNames[lstvideoNames.length - 1]) == -1) {
                    //replaces the src of audio song to the next song from the list
                    urls[0].src = urls[0].src.replace(lstvideoNames[curPlaying], lstvideoNames[++curPlaying]);
                    //Loads the audio song
                    video.load();
                    //Plays the audio song
                    video.play();
                }
            });
        //});
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>

