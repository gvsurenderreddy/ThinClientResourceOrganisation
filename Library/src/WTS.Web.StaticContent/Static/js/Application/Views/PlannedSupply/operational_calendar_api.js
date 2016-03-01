define(["jquery", "moment", "date_range_calendar_api", "guard"], function ($, moment, date_range_calendar_api, guard) {
    return {

        get_state: function () {
            var date_range_palette_state = date_range_calendar_api.get_state();

            var state_object = $.extend({}, date_range_palette_state);

            return state_object;
        },
        determine_todays_date_mvc_invariant_culture: function () {

            return moment().format('MM-DD-YYYY');

        },
        determine_next_page_start_date_mvc_invariant_culture: function () {

            var calendar_state = date_range_calendar_api.get_state();

            if (calendar_state.range_type == "Week") {
                return moment(calendar_state.start_date, "MM-DD-YYYY").add('days', 7).format('MM-DD-YYYY');
            }

            if (calendar_state.range_type == "FourWeek") {
                return moment(calendar_state.start_date, "MM-DD-YYYY").add('days', 28).format('MM-DD-YYYY');
            }

            guard.throw_exception("could not determine next page start date");

            return false;
        },
        determine_previous_page_start_date_mvc_invariant_culture: function () {

            var calendar_state = date_range_calendar_api.get_state();

            if (calendar_state.range_type == "Week") {
                return moment(calendar_state.start_date, "MM-DD-YYYY").add('days', -7).format('MM-DD-YYYY');
            }

            if (calendar_state.range_type == "FourWeek") {
                return moment(calendar_state.start_date, "MM-DD-YYYY").add('days', -28).format('MM-DD-YYYY');
            }

            guard.throw_exception("could not determine next page start date");

            return false;
        }


    };
});