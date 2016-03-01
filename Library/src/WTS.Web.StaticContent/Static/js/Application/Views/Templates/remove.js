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

    //on submit editor
    page_events.on_save_edits(function (editor_id, page, button_id) {
        page.disable_view_actions_for(editor_id);
        page.clear_all_messages();
        page.submit_edits({
            editor_id: editor_id,
            on_success: function (response) {
                // happy case 
                page.persist_confirmation_notifications(response.messages);

                page.get_known_destination_for_command({
                    action_id: button_id,
                    on_success: function(url) {
                        page.navigate_to(url);
                    },
                    on_error: function() {
                        console.log("No known destinations found");
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
        page.navigate_to_previous_page();
        page.enable_view_actions();
    });

});