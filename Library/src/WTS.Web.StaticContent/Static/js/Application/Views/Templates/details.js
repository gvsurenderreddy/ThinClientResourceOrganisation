/*
    This a application logic for a standard details view i.e. a details view presents
    one or more reports each of which can have zero or more actions such as edit, 
    remove, new.  
    
    This module defines our standard implementation of that journey. It is
    the sole responsibility of the view to implement the journey application
    all manipulation of view and identification of action requests from the 
    user are delegated to a Page object.

*/
require(["console", "page_events"], function (console, page_events) {


    page_events.on_edit_entity(function (edit_report_details, page_api) {
        page_api.clear_all_messages();
        page_api.disable_view_actions();
        page_api.replace_report_with_editor(edit_report_details);
    });

    //When the remove action is clicked on a details list
    //Todo: This needs to be changed to clear-report rather than remove-report
    //Todo: as it conveys its purpose semantically
    page_events.on_remove_entity(function (details, page_api) {
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
                page_api.display_error_messages(response.messages);
                page_api.enable_view_actions();
            }
        });
    });


    //When a file is selected for upload in an editor
    page_events.on_select_file_for_upload(function (details, page_api) {
        page_api.show_image_preview(details);
    });



    //on submit editor
    page_events.on_save_edits(function (editor_id, page, action_id) {
        page.disable_view_actions_for(editor_id);
        page.clear_all_messages();
        page.submit_edits({
            editor_id: editor_id,
            on_success: function (response) {
                // happy case 

                page.persist_confirmation_notifications(response.messages);

                page.get_known_destination_for_command({
                    action_id: action_id,
                    response: response.result,
                    on_success: function (url) {
                        page.navigate_to(url);
                    },
                    on_error: function () {
                        page.refresh_page();
                    }
                });
                

            },
            on_error: function (response) {
                //sad case
                page.display_error_messages(response.messages, editor_id);
                page.enable_view_actions_for(editor_id);
            }
        });
    });

    //on cancel editor
    page_events.on_cancel_edits(function (editor_id, page) {
        page.refresh_page();
    });

});