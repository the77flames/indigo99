requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'knockout': '../Scripts/knockout-3.1.0.debug',
        'bootstrap': '../Scripts/bootstrap',
        'jquery': '../Scripts/jquery-1.8.2',
        'toastr': '../Scripts/toastr',
        'moment': '../Scripts/moment',
        'roundabout': '../js/jquery.roundabout.min',
        'bxslider': '../js/jquery.bxslider.min',
        'mediaplayer': '../js/media-player.min'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        },
        'roundabout': {
            deps: ['jquery']
        },
        'bxslider': {
            deps: ['jquery']
        },
        'mediaplayer': {
            deps: ['jquery']
        }
    }
});

