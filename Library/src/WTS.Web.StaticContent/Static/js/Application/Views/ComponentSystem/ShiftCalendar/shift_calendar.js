define(["console", "page_api", "shift_calendar_api"], function (console, page_api, shift_calendar_api) {
    return {
        "shift-calendar-view": function (details) {
            page_api.navigate_to(details.action_url);
        },
        "shift-calendar-edit": function (details) {
            page_api.clear_all_messages();
            page_api.disable_view_actions();
            shift_calendar_api.replace_shift_calendar_with_an_editor(details);
        },
        "shift-calendar-remove": function (details) {
            page_api.clear_all_messages();
            page_api.disable_view_actions();
            shift_calendar_api.replace_shift_calendar_with_a_read_only_editor(details);
        }
    };
});