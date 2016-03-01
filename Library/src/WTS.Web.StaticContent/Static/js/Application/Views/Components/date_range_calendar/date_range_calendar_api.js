define(["jquery", "date_range"], function ($, date_range) {

    var state_object = {
        start_date: date_range.get_selected_date_mvc_invariant_culture(),
        range_type: $("[data-selected-range]").attr("data-selected-range")
    };

    return {
        get_state: function () {
            return state_object;
        },
        append_to_state: function (key_value_object) {

            $.extend(state_object, key_value_object);
        }
    };

});