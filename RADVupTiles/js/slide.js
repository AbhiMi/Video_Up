$(document).ready(function () {
    var AuthValue = $('#ctl00_hdnIsAuthenticated').val();
    if (AuthValue == 0) // Not Authenticated 
    {
        $("#open").css({ "display": "block" });
        $("#register").css({ "display": "block" });
        $("#btnlogout").css({ "display": "none" });
    }
    else
    {
        $("#open").css({ "display": "none" });
        $("#register").css({ "display": "none" });
        $("#btnlogout").css({ "display": "block" });

    }
    var name = GetParameterValues('NewUser');
    if (name != null && name != '')
    {
        $("div#panel").slideDown("slow");
        $(".da-slider").css({ "margin-top": "210px", "slideDown": "slow" });
        $("div#panel").css({ "height": "250px" });
        $("div#toppanel").css({ "height": "500px" });
        $("div#menu").css({ "height": "250px" });
        $(".registerContent").css({ "display": "none" });
        $(".loginContent").css({ "display": "block" });
        $("#close").css('display', 'block !important');
    }
    function GetParameterValues(param) {
        var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < url.length; i++) {
            var urlparam = url[i].split('=');
            if (urlparam[0] == param) {
                return urlparam[1];
            }
        }
    }  
// Expand Panel
    $("#open").click(function(){
        $("div#panel").slideDown("slow");
        $(".da-slider").css({ "margin-top": "210px", "slideDown": "slow" });
        $("div#panel").css({ "height": "250px" });
        $("div#toppanel").css({ "height": "500px" });
        $("div#menu").css({ "height": "250px" });
        $(".registerContent").css({ "display": "none" });        
        $(".loginContent").css({ "display": "block" });
        $("#close").css('display', 'block !important');
        
    });

    $("#register").click(function () {
        //$("div#panel").slideDown("slow");
        //$(".da-slider").css({ "margin-top": "435px", "slideDown": "slow" });
        //$("div#panel").css({ "height": "450px" });
        //$("div#toppanel").css({ "height": "450px" });
        //$("div#menu").css({ "height": "350px" });
        //$(".loginContent").css({ "display": "none" });
        //$(".registerContent").css({ "display": "block" });
        window.location.href = "/Pages/Register.aspx";
    });
    $("#close").click(function () {
        $("div#ClosePanel").slideDown("slow");
        $(".da-slider").css({ "margin-top": "160px", "slideDown": "slow" });
    });
	
	// Collapse Panel
	$("#close").click(function(){
	    $("div#panel").slideUp("slow");
	    $(".da-slider").css({ "margin-top": "32px", "slideDown": "slow" });
	});		
	
	// Switch buttons from "Log In | Register" to "Close Panel" on click
	$(".toggle a").click(function () {
		$(".toggle a").toggle();
	});				
});