define(["console", "underscore", "jquery", "event", "resources"],
function (console, _, $, event, resources) {
    console.log("page_events");

    var shift_pattern_block_selected_handlers = [];

    event.listen(resources.cell_selected_event, "td", function (target, event_data) {

        var $target = $(target);

        var details = {
            element_id: $target.attr("id"),
            content_type: event_data.content_type,
            mvc_invariant_culture_start_date: event_data.mvc_invariant_culture_start_date,
            operations_calendar_id: event_data.operations_calendar_id,
            shift_calendar_id: event_data.shift_calendar_id,
            shift_calendar_pattern_id: event_data.shift_calendar_pattern_id
        };

        _.each(shift_pattern_block_selected_handlers, function (handler) {
            handler(details);
        });
        
    }, false);

    return {
        on_shift_pattern_block_selected: function (handler) {
            shift_pattern_block_selected_handlers.push(handler);
        }
    };
});