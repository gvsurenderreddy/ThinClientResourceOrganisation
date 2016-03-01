
define(["console", "page_api"], function (console, editor_api) {


    var submit_form = function (request) {

        editor_api.disable_view_actions_for(request.details.editor_id);
        editor_api.clear_all_messages();
        editor_api.submit_edits({
            editor_id: request.details.editor_id,
            on_success: function (response) {
                // happy case
                editor_api.persist_confirmation_notifications(response.messages);

                editor_api.get_known_destination_for_command({
                    action_id: request.details.action_id,
                    response: response.result,
                    on_success: function (url) {
                        editor_api.navigate_to(url);
                    },
                    on_error: function () {
                        request.success_default_navigation_action();
                    }
                });

            },
            on_error: function (response) {
                //sad case
                editor_api.get_known_error_destination_for_command({
                    action_id: request.details.action_id,
                    on_success: function (url) {

                        editor_api.persist_warning_notifications(response.messages);
                        editor_api.navigate_to(url);
                    },
                    on_error: function () {
                        editor_api.display_error_messages(response.messages, request.details.editor_id);
                        editor_api.enable_view_actions_for(request.details.editor_id);
                    }
                });
                
            }
        });
    };

    return {
        "editor-submit-new": function (details) {

            submit_form({
                details: details,
                success_default_navigation_action: editor_api.refresh_page,
            });

        },
        "editor-submit-edit": function (details) {

            submit_form({
                details: details,
                success_default_navigation_action: editor_api.refresh_page,
            });

        },
        "editor-submit-remove": function (details) {

            submit_form({
                details: details,
                success_default_navigation_action: editor_api.navigate_to_previous_page,
            });

        },
        "editor-cancel": function (details) {

            editor_api.get_known_destination_for_command({
                action_id: details.action_id,
                on_success: function (url) {
                    editor_api.navigate_to(url);
                },
                on_error: function () {
                    editor_api.refresh_page();
                }
            });

        }
    };

});