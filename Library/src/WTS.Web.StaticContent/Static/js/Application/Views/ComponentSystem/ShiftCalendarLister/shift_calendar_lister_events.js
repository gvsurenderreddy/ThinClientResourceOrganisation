define([ "console"
       , "jquery"
       , "underscore"
       , "event"
       , "global"
       , "random"],

function (console, $, _, event, window, random) {
    console.log("shift_calendars_lister_events");

    return {
        "shift-calendars-lister": {
            "new": function (target, handlers) {
                var button = $(target);
                var header = button.closest(".shift-calendars-lister-header");

                random.generate_dom_id_for_element(header[0]);

                var details = {
                    header_id: header.attr("id"),
                    editor_url: button.attr("href")
                };

                _.each(handlers, function (handler) {
                    handler("shift-calendars-lister-new", details);
                });
            },
        }
    };
});