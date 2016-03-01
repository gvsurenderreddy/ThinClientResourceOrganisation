define([ "console"
       , "content_header_events"
       , "shift_calendar_lister_events"
       , "shift_calendar_events"
       , "editor_events"
       , "white_space_time_allocation_palette_events"
       , "shift_time_allocation_palette_events"]

, function ( console
           , content_header_events
           , shift_calendar_lister_events
           , shift_calendar_events
           , editor_events
           , white_space_time_allocation_palette_events
           , shift_time_allocation_palette_events) {

    console.log("events_repository");

    var events = $.extend({}
                         , content_header_events
                         , shift_calendar_lister_events
                         , shift_calendar_events, editor_events
                         , white_space_time_allocation_palette_events
                         , shift_time_allocation_palette_events
                         );

    return events;
});