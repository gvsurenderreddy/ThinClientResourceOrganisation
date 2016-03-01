define(["time_allocation_palette_loader", "jquery", "guard"], function (time_allocation_palette_loader, $, guard) {
    
    return {



        display_time_allocation_palette: function (details) {

            time_allocation_palette_loader.get_appropriate_palette({
                options: {
                    time_allocation_type: details.content_type,
                    start_date: details.mvc_invariant_culture_start_date,
                    operations_calendar_id: details.operations_calendar_id,
                    shift_calendar_id: details.shift_calendar_id,
                    shift_calendar_pattern_id: details.shift_calendar_pattern_id,
                },
                on_success: function (palette) {

                    if ($(".shift-palette")[0]) {
                        $(".shift-palette").replaceWith(palette);
                    } else {
                        $(".palette").last().after(palette);
                    }

                },
                on_failure: function() {
                    guard.throw_exception("Could not load time allocation palette");
                }

            });

        },

    };
});