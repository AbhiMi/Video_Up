/// <reference path="../Pages/Create.aspx" />
/// <reference path="../Pages/Create.aspx" />

// This file holds the definition of tiles and which tiles appear by default 
// to new visitors. 


// The default tile setup offered to new users.
window.DefaultTiles = [
    {
        name: "Section1",
        tiles: [
           //{ id: "flickr1", name: "flickr" },

           //{ id: "amazon1", name:"amazon" },
           //{ id: "news1", name: "news" },
           { id: "cuttherope1", name: "cutTheRope" },
           { id: "facebook1", name: "facebook" },
           { id: "Associate", name: "reader" },
           //{ id: "weather1", name: "weather" },

           //{ id: "calendar1", name: "calendar" },

           //{ id: "feature1", name: "feature" },
          // { id: "wikipedia1", name: "wikipedia" },

        //{ id: "video1", name: "video" },
          { id: "UserManagement", name: "ie" },
           //{ id: "facebook1", name: "facebook" },
            //{ id: "angrybirds1", name: "angrybirds" }



        ]
    },
    {
        name: "Section2",
        tiles: [
            // { id: "myblog1", name: "myblog" },

        //{ id: "email1", name: "email" },
        //{ id: "maps1", name: "maps" },
        { id: "calendar1", name: "calendar" },

        { id: "dynamicTile1", name: "dynamicTile" }
           //{ id: "wikipedia1", name: "wikipedia" },           
           //{ id: "email1", name: "email" },
           //{ id: "maps1", name: "maps" },
           //{ id: "facebook1", name: "facebook" },
           //{ id: "ie1", name: "ie" },
           //{ id: "dynamicTile1", name: "dynamicTile" }
           //{ id: "buy1", name: "buy" }
        ]
    }
];


// Convert it to a serialized string
window.DefaultTiles = _.map(window.DefaultTiles, function (section) {
    return "" + section.name + "~" + (_.map(section.tiles, function (tile) {
        return "" + tile.id + "," + tile.name;
    })).join(".");
}).join("|");


// Definition of the tiles, their default values.
window.TileBuilders = {

    weather: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "weather",
            color: "bg-color-blue",
            label: "Weather",
            appTitle: "Weather App",
            appUrl: "http://www.bbc.co.uk/weather/",
            size: "tile-double",
            scriptSrc: ["tiles/weather/jQuery.simpleWeather.js", "tiles/weather/weather.js"],
            cssSrc: ["tiles/weather/weather.css"],
            initFunc: "load_weather",
            initParams: {
                location: 'London, UK'
            }
        };
    },

    amazon: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "amazon",
            color: "bg-color-yellow",
            label: "Amazon",
            iconSrc: "img/Amazon alt.png",
            appTitle: "Amazon",
            appUrl: "http://www.amazon.com",
            size: "tile-double-vertical",
            iconSrc: "img/Amazon.png"
        };
    },

    maps: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "maps",
            color: "bg-color-purple",
            label: "Maps",
            appTitle: "Maps",
            appUrl: "http://maps.google.com/",
            iconSrc: "img/Google Maps.png",
            appInNewWindow: true
        };
    },

    ie: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "UserManagement",
            iconSrc: "img/UserManagement.jpg",
            label: "User Management",
            appUrl: "Pages/UserManagement/ManageRoles.aspx"
        };
    },

    video: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "video",
            size: "tile-double",
            color: "bg-color-darken",
            iconSrc: "img/Youtube.png",
            slides: ['<iframe width="310" height="174" src="http://youtube.com/embed/g4iD-9GSW-0" frameborder="0" allowfullscreen=""></iframe>']
        };
    },

    facebook: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "Create",
            iconSrc: "img/Create1.jpg",
            label: "Create",
            color: "bg-color-purple",
            appUrl: "Pages/Create/CreateCompany.aspx",
            appInNewWindow: false
        };
    },

    calendar: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "calendar",
            iconSrc: "img/Calendar.png",
            label: "Calendar",
            size: "tile-double",
            color: "bg-color-deepSea",
            appUrl: "Pages/Calendar.aspx",
            appInNewWindow: false
        };
    },

    library: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "library",
            iconSrc: "img/Libraries.png",
            label: "Library",
            color: "bg-color-orange",
            appUrl: "http://www.londonlibrary.co.uk/"
        };
    },

    skydrive: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "skydrive",
            iconSrc: "img/Live SkyDrive.png",
            label: "Skydrive",
            appUrl: "http://www.skydrive.com/"
        };
    },

    flickr: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "flickr",
            iconSrc: "img/Flickr alt 1.png",
            label: "Video-Up Slide Show",
            size: "tile-double tile-double-vertical",
            color: "bg-color-darken",
            appUrl: "Tiles/Flickr/App/FlickrApp.html",
            cssSrc: ["tiles/flickr/flickr.css"],
            scriptSrc: ["tiles/flickr/flickr.js?v=1"],
            //scriptSrc: ["tiles/flickr/flickr_interesting.js"],
            //cssSrc: ["tiles/flickr/flickr_interesting.css"],            
            initFunc: "flickr_load"
        };
    },

    email: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "email",
            iconSrc: "img/Gmail Alt.png",
            label: "Gmail",
            color: "bg-color-pink",
            appUrl: "http://www.gmail.com/",
            appInNewWindow: true
        };
    },

    youtube: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "youtube",
            iconSrc: "img/Youtube.png",
            label: "Youtube",
            color: "bg-color-darken",
            appUrl: "http://www.youtube.com/",
            appInNewWindow: true
        };
    },

    angrybirds: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "ContactUs",
            tileImage: "img/ContactUs.jpg",
            appUrl: "Pages/ContactUs.aspx"
        };
    },

    wikipedia: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "wikipedia",
            tileImage: "img/Wikipedia alt 1.png",
            label: "Wikipedia",
            color: "bg-color-green",
            appIcon: "img/Wikipedia alt 1.png",
            appUrl: "http://www.wikipedia.org"
        };
    },


    news: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "news",
            color: "bg-color-pink",
            size: "tile-double",
            appUrl: "http://www.bbc.co.uk/news/world/",
            scriptSrc: ["tiles/news/news.js?v=1"],
            cssSrc: ["tiles/news/news.css?v=1"],
            initFunc: "load_news",
            initParams: { url: "http://feeds.bbci.co.uk/news/world/rss.xml" }
        };
    },

    myblog: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "myblog",
            label: "My Blog",
            color: "bg-color-blueDark",
            size: "tile-double",
            //appUrl: "http://omaralzabir.com/",
            scriptSrc: ["tiles/news/news.js?v=1"],
            cssSrc: ["tiles/news/news.css?v=1"],
            initFunc: "load_news",
            //initParams: { url: "http://omaralzabir.com/feed" }
        };
    },

    feature: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "feature",
            color: "bg-color-pink",
            size: "tile-double",
            appUrl: "http://oazabir.github.com/Droptiles/",
            slidesFrom: ["tiles/features/feature1.html",
                "tiles/features/feature2.html",
                "tiles/features/feature3.html"],
            cssSrc: ["tiles/features/features.css"]
        };
    },

    howto: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "howto",
            color: "bg-color-blue",
            size: "tile-triple tile-triple-vertical",
            appUrl: "http://oazabir.github.com/Droptiles/",
            slidesFrom: ["tiles/features/howto.html?2"]
        };
    },

    //dynamicTile: function (uniqueId) {
    //    return {
    //        uniqueId: uniqueId,
    //        name: "dynamicTile",
    //        color: "bg-color-darkBlue",
    //        size: "tile-triple tile-double-vertical",
    //        label: "Server side Tile in ASP.NET",
    //        slidesFrom: ["tiles/DynamicTile/DynamicTile.aspx"]
    //        //cssSrc: ["tiles/DynamicTile/visualize.css"],
    //        //scriptSrc: ["tiles/DynamicTile/tablechart.js",
    //        //    "tiles/DynamicTile/DynamicTile.js"],
    //        //initFunc: "load_dynamic"
    //    }
    //},

    cutTheRope: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "UploadVideos",
            tileImage: "img/Uploads.jpg",
            appUrl: "Pages/CustomUpload.aspx"
        };
    },

    buy: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "buy",
            color: "bg-color-blueDark",
            size: 'tile-double tile-double-vertical',
            slidesFrom: ["tiles/buy/buy.html?v=1"],
            cssSrc: ["tiles/buy/buy.css"]
        };
    },

    reader: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "Associate",
            color: "bg-color-blue",
            label: "Associate",
            iconSrc: 'img/Associate.jpg',
            appUrl: 'Pages/Associate/CampaignToChannel.aspx'
        };
    }
}; 