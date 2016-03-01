define(["console", "jquery", "underscore"], function (console, $, _) {
    console.log("shift-time-allocation-palette-page_events");

    return {
        "shift-time-allocation-palette": {
            
            "remove": function(target, handlers) {
                var remove_button = $(target);

                var details = {
                    action_url: remove_button.attr("href")
                };

                _.each(handlers, function (handler) {
                    handler("shift-time-allocation-palette-remove", details);
                });
            },

            "edit": function(target, handlers) {
                var edit_button = $(target);

                var details = {
                    action_url: edit_button.attr("href")
                };

                _.each(handlers, function (handler) {
                    handler("shift-time-allocation-palette-edit", details);
                });
            }
        }
    };
});