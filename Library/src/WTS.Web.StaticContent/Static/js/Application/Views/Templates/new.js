/*
    This a application logic for a standard new view i.e. a new view is 
    a view that allows a new item to be created, it is made up of one 
    editor.  
    
    This module defines our standard implementation of that journey. It is
    the sole responsibility of the view to implement the journey application
    all manipulation of view and identification of action requests from the 
    user are delegated to a Page object.

*/
require(["console", "page_events"], function (console, page_events) {

    var view = function () {
        page_events.on_save_edits(function (editor_id, page) {
            page.disable_view_actions_for(editor_id);
            page.clear_all_messages();
            page.submit_edits({
                editor_id: editor_id,
                on_success: function (response) {
                    // happy case 
                    page.persist_confirmation_notifications(response.messages);
                    page.navigate_to_previous_page();
                },
                on_error: function (response) {
                    //sad case
                    page.display_error_messages(response.messages, editor_id);
                    page.enable_view_actions_for(editor_id);
                }
            });
        });

        page_events.on_cancel_edits(function (editor_id, page) {
            page.navigate_to_previous_page();
            page.enable_view_actions();
        });
    };

    //No need to return anything here, just execute
    (view());
});