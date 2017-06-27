/// <reference path="../../js/Underscore.js" />
/// <reference path="../../js/jquery-1.7.2.min.js" />
// Part of Droptiles project.



function flickr_load(tile, div) {
    //var url = "http://api.flickr.com/services/feeds/photos_public.gne?lang=en-us&format=json&tags=waterfall&jsoncallback=?";
    //var url = "http://api.flickr.com/services/feeds/photos_faves.gne?id=36587311@N08&format=json&jsoncallback=?";
    var url = "http://api.flickr.com/services/feeds/groups_pool.gne?id=1642523@N22&format=json&jsoncallback=?&test=" + (new Date().getDate());
    
    $.getJSON(url, function (data) {        
        var ctr = 0;
        //$.each(data.items.reverse(), function (i, item) {
        //    var sourceSquare = item.media.m;
        //    var sourceOrig = (item.media.m).replace("_m.jpg", ".jpg");

        //    var htmlString = '<div class="flickr_item">' 
        //        //+ '<a target="_blank" href="' + sourceOrig + '" class="link" title="' + item.title + '">';
        //    htmlString += '<img title="' + item.title +
        //        '" src="' + sourceSquare + '" ';
        //    htmlString += 'alt="' + item.title +
        //        '" />';
        //    htmlString += '</a>'
        //        + '<div class="flickr_title">' + item.title + '</div>' +
        //        '</div>';
        var htmlString = '<div class="flickr_item">' +
            '<img title="Tulips.jpg" src="../img/Tulips.jpg" alt="Tulips">' +
            '<div class="flickr_title"> ' + "Tulips" + '</div>' 
            +'</div>';
        var htmlString1 = '<div class="flickr_item">' + '<img title="Koala" src="../img/Koala.jpg" alt="Koala">' +
            '<div class="flickr_title"> ' + "Koala" + '</div>' +'</div>';
        var htmlString2 = '<img title="Chrysanthemum.jpg" src="../img/Chrysanthemum.jpg" alt="Chrysanthemum">' +
            '<div class="flickr_title"> ' + "Chrysanthemum" + '</div>' + '</div>';

        var htmlString3 = '<img title="Lighthouse.jpg" src="../img/Lighthouse.jpg" alt="Lighthouse">' +
            '<div class="flickr_title"> ' + "Lighthouse" + '</div>' + '</div>';

        tile.slides.push(htmlString);
        tile.slides.push(htmlString1);
        tile.slides.push(htmlString2);
        tile.slides.push(htmlString3);

        //    ctr = ctr + 1;
            
        //});

        tile.counter(4);
    });
    
}

