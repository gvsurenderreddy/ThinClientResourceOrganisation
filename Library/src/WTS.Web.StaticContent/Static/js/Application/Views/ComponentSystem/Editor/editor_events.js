
define(["console", "jquery", "underscore", "event", "global", "random"],
function (console, $, _, event, window, random) {

    console.log("page_events");


    var extract_details_from_target = function(target) {
        var $action_button_context = $(target);
        var $editor_context = $action_button_context.closest("form");

        $editor_context.attr("action", $action_button_context.attr("formaction"));

        random.generate_dom_id_for_element($editor_context[0]);
        random.generate_dom_id_for_element($action_button_context[0]);

        var details = {
            editor_id: $editor_context.attr("id"),
            action_id: $action_button_context.attr("id")
        };

        return details;
    };


    return {
        "editor": {
            "submit-new": function (target, handlers) {

                var details = extract_details_from_target(target);


                _.each(handlers, function (handler) {
                    handler("editor-submit-new", details);
                });
            },
            "submit-edit": function (target, handlers) {

                var details = extract_details_from_target(target);


                _.each(handlers, function (handler) {
                    handler("editor-submit-edit", details);
                });
            },
            "submit-remove": function (target, handlers) {

                var details = extract_details_from_target(target);


                _.each(handlers, function (handler) {
                    handler("editor-submit-remove", details);
                });
            },
            "cancel": function (target, handlers) {

                var $action_button_context = $(target);
                var $editor_context = $action_button_context.closest("form");

                random.generate_dom_id_for_element($editor_context[0]);
                random.generate_dom_id_for_element($action_button_context[0]);

                var details = {
                    editor_id: $editor_context.attr("id"),
                    action_id: $action_button_context.attr("id")
                };
                
                _.each(handlers, function (handler) {
                    handler("editor-cancel", details);
                });

            },
        }

    };
});