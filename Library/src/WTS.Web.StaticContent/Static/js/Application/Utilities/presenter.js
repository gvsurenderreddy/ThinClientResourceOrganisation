/*
    A module that abstracts view presentation logic
*/
define(["ajax", "global"], function (ajax, window) {

    // Get a view element from the server
    var get_view_element = function (options) {
        if (options) {
            ajax.execute("GET", options.url, options.data, "html")
                .onsuccess(options.on_success)
                .onerror(options.on_error);
        }
    };

    var redirect_to_resource = function(url) {
        window.location.href = url;
    };

    return {
        get_view: get_view_element,
        redirect: redirect_to_resource
    };
});