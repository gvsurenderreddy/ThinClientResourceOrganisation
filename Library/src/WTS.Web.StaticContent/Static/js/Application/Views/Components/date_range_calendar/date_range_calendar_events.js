define(["console", "underscore", "jquery", "event", "resources"],
function (console, _, $, event, resources) {
    console.log("page_events");

    var start_date_changed_handlers = [];

    var date_range_changed_handlers = [];


    event.listen(resources.date_selected_event, "#calendar", function (target, event_data) {
        var $calendar = $(target);

        var action_data = { start_date: event_data.mvc_invariant_culture_start_date };

        var details = {
            id: $calendar.attr("id"),
            action_data: action_data
        };

        _.each(start_date_changed_handlers, function (handler) {
            handler(details);
        });
    }, false);

    event.listen("click", "[data-action='toggle-week']", function (target, event_data) {

        var details = { range_type: "week" };

        _.each(date_range_changed_handlers, function (handler) {
            handler(details);
        });
    }, false);

    event.listen("click", "[data-action='toggle-four-weeks']", function (target, event_data) {

        var details = { range_type: "fourweek" };

        _.each(date_range_changed_handlers, function (handler) {
            handler(details);
        });
    }, false);



    return {
        on_start_date_changed: function (handler) {
            start_date_changed_handlers.push(handler);
        },
        on_date_range_changed: function (handler) {
            date_range_changed_handlers.push(handler);
        }
    };
});