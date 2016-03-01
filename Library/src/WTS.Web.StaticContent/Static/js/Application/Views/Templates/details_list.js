
require(["console", "page_events"], function (console, page_events) {

    //When the reorder action is clicked on a details list :)
    page_events.on_reorder_details_list_entry(function (details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.replace_report_with_editor(details);
    });

    //When the report has been [DROPPED after dragging] via the reorder action link on a report in a details list :)
    page_events.on_drop_details_list_entry(function (details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.replace_report_with_editor(details);
    });

    //When the new action is clicked on a details list :)
    page_events.on_new_details_list_entry(function (details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.append_editor_to_report(details);
    });

    //When the [edit details list] action is clicked on a details list :)
    page_events.on_edit_details_list_collection(function (details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.replace_details_list_with_editor(details);
    });

    //When the remove action is clicked on a details list
    page_events.on_remove_details_list_entry(function (details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.submit_request({
            url: details.action_url,
            data: {},
            on_success: function (response) {
                // happy case 
                page_api.persist_confirmation_notifications(response.messages);
                page_api.refresh_page();
            },
            on_error: function (response) {
                //sad case
                page_api.persist_warning_notifications(response.messages);
                page_api.refresh_page();
            }
        });
    });

    //When the edit action is clicked on a report
    page_events.on_edit_details_list_entry(function (details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.replace_report_with_editor(details);
    });

    //When the save action is clicked on an editor in a details list
    page_events.on_save_details_list_edits(function (editor_id, page) {
        page.disable_view_actions_for(editor_id);
        page.clear_all_messages();
        page.submit_edits({
            editor_id: editor_id,
            on_success: function (response) {
                // happy case 
                page.persist_confirmation_notifications(response.messages);
                page.refresh_page();
            },
            on_error: function (response) {
                //sad case
                page.display_error_messages(response.messages, editor_id);
                page.enable_view_actions_for(editor_id);
            }
        });
    });

    //When the cancel action is clicked on an editor in a details list
    page_events.on_cancel_details_list_edits(function (editor_id, page) {
        page.refresh_page();
        
    });
});