define(["route_builder", "presenter", "guard"], function(route_builder, presenter, guard) {

    var time_allocation_palette_route_map = {

        white_space: "white-space-time-allocation-palette",
        shift: "shift-time-allocation-palette"

    }


    return {
        get_appropriate_palette: function (params) {

            var pallete_route_name = time_allocation_palette_route_map[params.options.time_allocation_type];

            guard.is_not_null_or_undefined(pallete_route_name, "No palette mapping for time allocation type.");

            var route_params = {
                start_date: params.options.start_date,
                operations_calendar_id: params.options.operations_calendar_id,
                shift_calendar_id: params.options.shift_calendar_id,
                shift_calendar_pattern_id: params.options.shift_calendar_pattern_id
            };

            var palette_url = route_builder.route_url(pallete_route_name, route_params);

            presenter.get_view({
                url: palette_url,
                on_success: params.on_success,
                on_error: params.on_error
            });

        }
    };

});