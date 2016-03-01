define(["console", "jquery", "underscore", "event", "global", "random"],
function (console, $, _, event, window, random) {
    console.log("page_events");


    var extract_details_from_target = function(target) {
        var edit_button = $(target);
        var shift_calendar = edit_button.closest(".shift-calendar");

        random.generate_dom_id_for_element(shift_calendar[0]);

        var details = {
            id: shift_calendar.attr("id"),
            action_url: edit_button.attr("href")
        };

        return details;
    };


    return {
        "shift-calendar": {
            "view": function (target, handlers) {

                var details = extract_details_from_target(target);

                _.each(handlers, function (handler) {
                    handler("shift-calendar-view", details);
                });
            },
            "edit": function (target, handlers) {

                var details = extract_details_from_target(target);

                _.each(handlers, function (handler) {
                    handler("shift-calendar-edit", details);
                });
            },
            "remove": function (target, handlers) {

                var details = extract_details_from_target(target);

                _.each(handlers, function (handler) {
                    handler("shift-calendar-remove", details);
                });
            }
        }
    };
});