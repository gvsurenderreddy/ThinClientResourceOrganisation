
define(["console", "jquery", "underscore", "event", "global", "random"],
function (console, $, _, event, window, random) {

    console.log("page_events");

    return {
        "content-header": {
            "edit": function (target, handlers) {

                var edit_button = $(target);
                var content_header = edit_button.closest(".content-header");

                if (edit_button.attr("data-context")) {
                    content_header = $("[data-component='content-header']");
                }
                

                random.generate_dom_id_for_element(content_header[0]);

                var details = {
                    content_header_id: content_header.attr("id"),
                    editor_url: edit_button.attr("href")
                };
                _.each(handlers, function (handler) {
                    handler("content-header-edit", details);
                });
            },
            "remove": function (target, handlers) {

                var remove_button = $(target);
                var content_header = remove_button.closest(".content-header");
                
                if (remove_button.attr("data-context")) {
                    content_header = $("[data-component='content-header']");
                }


                random.generate_dom_id_for_element(content_header[0]);

                var details = {
                    content_header_id: content_header.attr("id"),
                    editor_url: remove_button.attr("href")
                };
                _.each(handlers, function (handler) {
                    handler("content-header-edit", details);
                });

            },
        }

    };
});