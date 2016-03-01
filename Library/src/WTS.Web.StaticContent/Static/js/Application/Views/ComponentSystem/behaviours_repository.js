define(["content_header"
        , "shift_calendar_lister"
        , "shift_calendar"
        , "editor"
        , "shift_time_allocation_palette"]

, function (content_header
            , shift_calendar_lister
            , shift_calendar
            , editor
            , shift_time_allocation_palette) {

    var behaviours = $.extend({}
                             , content_header
                             , shift_calendar_lister
                             , shift_calendar
                             , editor
                             , shift_time_allocation_palette
                             );

    return behaviours;
});