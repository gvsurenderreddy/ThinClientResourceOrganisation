/*
    A module that abstracts view presentation logic
*/
define(["ajax"], function (ajax) {

    // Get a view element from the server
    var submit = function (options) {
        if (options) {
            ajax.execute("POST", options.submit_url, options.submit_data)
                .onsuccess(options.on_success)
                .onerror(options.on_error);
        }
    };

    return {
        submit_data: submit
    };
});