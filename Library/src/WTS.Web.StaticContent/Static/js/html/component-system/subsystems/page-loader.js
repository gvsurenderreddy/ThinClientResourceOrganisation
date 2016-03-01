// Page Loader

// This component is responsible for loading pages.  It expects to be passed a url and it will then load that page into the browser.
// It serves two purposes, when unit testing to allows us to inject a fake which will so that we do not actually navigate off the page,
// it second purpose is that we are likely to be getting pages from the application via ajax calls to allow custom error handling.

define( [], function () {

    return {

        load : function ( url )  {
            window.location.href = url;     
        },
    };
});