define([ "console"
       , "page_api"
       , "shift_calendar_lister_api"],

function (console, page_api, shift_calendar_lister_api) {
    return {
        "shift-calendars-lister-new": function (details) {
            page_api.clear_all_messages();
            page_api.disable_view_actions();
            shift_calendar_lister_api.append_editor_to_top_of_shift_calendars_lister(details);
        },
        "shift-calendars-lister-submit-new": function (details) {
            page_api.disable_view_actions_for(details.editor_id);
            page_api.clear_all_messages();
            page_api.submit_edits({
                editor_id: details.editor_id,
                on_success: function (response) {
                    // happy case
                    page_api.persist_confirmation_notifications(response.messages);
                    page_api.refresh_page();
                },
                on_error: function (response) {
                    //sad case
                    page_api.display_error_messages(response.messages, details.editor_id);
                    page_api.enable_view_actions_for(details.editor_id);
                }
            });
        }
    };
});