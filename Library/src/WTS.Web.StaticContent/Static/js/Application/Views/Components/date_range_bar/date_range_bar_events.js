define(["console", "underscore", "jquery", "event"],
function (console, _, $, event) {
    console.log("page_events");

    var today_selected_handlers = [];

    var forward_selected_handlers = [];

    var back_selected_handlers = [];

    event.listen("click", "#today", function (target, event_data) {

        _.each(today_selected_handlers, function (handler) {
            handler();
        });
    }, false);

    event.listen("click", "#forward", function (target, event_data) {

        _.each(forward_selected_handlers, function (handler) {
            handler();
        });
    }, false);

    event.listen("click", "#back", function (target, event_data) {

        _.each(back_selected_handlers, function (handler) {
            handler();
        });
    }, false);



    return {
        on_today_selected: function (handler) {
            today_selected_handlers.push(handler);
        },
        on_forward_selected: function (handler) {
            forward_selected_handlers.push(handler);
        },
        on_back_selected: function (handler) {
            back_selected_handlers.push(handler);
        }
    };
});