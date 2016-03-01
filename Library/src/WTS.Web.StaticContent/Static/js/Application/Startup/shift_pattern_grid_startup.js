require(['jquery', 'event', 'resources', 'moment'], function($, event, resources, moment) {
    

    var mvc_invariant_culture = function (moment_date) {
        //Query strings use an invariant culture, which in our case is american
        //see: http://weblogs.asp.net/melvynharbour/archive/2008/11/21/mvc-modelbinder-and-localization.aspx
        return moment_date.format('MM-DD-YYYY');
    };



    event.listen("click", "[data-block-date].shift-block", function (context) {

        $("[data-block-date].shift-block[selected]").removeAttr("selected").removeClass("shift-block-selected");

        var $context = $(context);

        $context.attr("selected", true).addClass("shift-block-selected");

        var event_args = {
            mvc_invariant_culture_start_date: mvc_invariant_culture(moment($context.attr("data-block-date"), "DD-MM-YYYY")),
            operations_calendar_id: $context.closest("[data-operations-calendar-id]").attr("data-operations-calendar-id"),
            shift_calendar_id: $context.closest("[data-shift-calendar-id]").attr("data-shift-calendar-id"),
            shift_calendar_pattern_id: $context.closest("[data-shift-calendar-pattern-id]").attr("data-shift-calendar-pattern-id"),
            content_type: $context.attr("data-block-content-type")
        };
        event.trigger(resources.cell_selected_event, $context[0], event_args);

    });
});