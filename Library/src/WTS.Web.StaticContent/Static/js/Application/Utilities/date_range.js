
define(["jquery", "moment", "event", "guard", "route_builder", "presenter", "resources"], function ($, moment, event, guard, route_builder, presenter, resources) {

    var calendar_url = route_builder.route_url("date-range-palette");
    guard.is_not_null_or_undefined(calendar_url);

    var $calendar_context = function () {
        var $cal = $("#calendar");
        guard.is_not_null_or_undefined($cal[0]);
        return $cal;
    }
    var selected_date = function () {
        var value = $calendar_context().attr("data-selected-start-date");

        guard.is_not_null_or_undefined(value);

        return moment(value, "DD-MM-YYYY");
    }
    var calendar_date = function () {
        var value = $calendar_context().attr("data-calendar-start-date");

        guard.is_not_null_or_undefined(value);

        return moment(value, "DD-MM-YYYY");
    }


    var mvc_invariant_culture = function (moment_date) {
        //Query strings use an invariant culture, which in our case is american
        //see: http://weblogs.asp.net/melvynharbour/archive/2008/11/21/mvc-modelbinder-and-localization.aspx
        return moment_date.format('MM-DD-YYYY');
    };

    var select_date = function (moment_date) {

        event.trigger(resources.date_selected_event, $calendar_context()[0], { mvc_invariant_culture_start_date: mvc_invariant_culture(moment_date) });
    };

    event.listen("click", "#calendar [data-date]", function (target) {
        var date_string = guard.is_not_null_or_undefined($(target).attr("data-date"));
        select_date(moment(date_string, "DD-MM-YYYY"));
    });

    var get_date_range_page = function (steps) {

        presenter.get_view({
            url: calendar_url,
            data: {
                selected_date: mvc_invariant_culture(selected_date()),
                calendar_start_date: mvc_invariant_culture(calendar_date().add('months', steps)),
                range_type: $("[data-selected-range]").attr("data-selected-range")
            },
            on_success: function (data) {

                var $palette_context = $calendar_context().closest(".palette");
                guard.is_not_null_or_undefined($palette_context[0]);

                $palette_context.replaceWith(data);

            },
            on_error: function () {
                guard.throw_exception("An error occured while trying to page calendar");
            }
        });
    }

    return {
        get_selected_date: function () {
            return selected_date();
        },
        get_selected_date_mvc_invariant_culture: function () {
            return mvc_invariant_culture(selected_date());
        },
        select_date: select_date,
        next_page: function () {
            get_date_range_page(1);
        },
        previous_page: function () {
            get_date_range_page(-1);
        }
    };

});