require(["console", "operational_calendar_api"], function (console, operational_calendar_api) {

    //base component system logic
    require(['component_system'], function () { });

    //Calendar component implementation
    require(["date_range_calendar_startup", "date_range_calendar_events", "date_range_calendar_api", "page_api"], function (date_range_calendar_startup, date_range_calendar_events, date_range_calendar_api, page_api) {

        date_range_calendar_events.on_start_date_changed(function (details) {
            //modify state
            date_range_calendar_api.append_to_state(details.action_data);


            //get_state
            var state = operational_calendar_api.get_state();
            console.log(state);
            page_api.refresh_page(state);

        });

        date_range_calendar_events.on_date_range_changed(function (details) {
            //modify state
            date_range_calendar_api.append_to_state(details);


            //get_state
            var state = operational_calendar_api.get_state();
            page_api.refresh_page(state);

        });

    });

    //Date Range Bar component implementation
    require(["date_range_bar_events", "date_range_calendar_api", "page_api"], function (date_range_bar_events, date_range_calendar_api, page_api) {

        date_range_bar_events.on_today_selected(function () {

            var start_date = operational_calendar_api.determine_todays_date_mvc_invariant_culture();

            //modify state
            date_range_calendar_api.append_to_state({ start_date: start_date });


            //get_state
            var state = operational_calendar_api.get_state();
            page_api.refresh_page(state);

        });

        date_range_bar_events.on_forward_selected(function () {
            //modify state
            var start_date = operational_calendar_api.determine_next_page_start_date_mvc_invariant_culture();

            date_range_calendar_api.append_to_state({ start_date: start_date });


            //get_state
            var state = operational_calendar_api.get_state();
            page_api.refresh_page(state);

        });

        date_range_bar_events.on_back_selected(function () {

            var start_date = operational_calendar_api.determine_previous_page_start_date_mvc_invariant_culture();

            date_range_calendar_api.append_to_state({ start_date: start_date });


            //get_state
            var state = operational_calendar_api.get_state();
            page_api.refresh_page(state);

        });

    });

    //Shift Pattern Grid component implementation
    require(["shift_pattern_grid_startup", "shift_pattern_grid_events", "shift_pattern_grid_api"], function (shift_pattern_grid_startup, shift_pattern_grid_events, shift_pattern_grid_api) {

        shift_pattern_grid_events.on_shift_pattern_block_selected(function (details) {

            shift_pattern_grid_api.display_time_allocation_palette(details);

        });

    });

});