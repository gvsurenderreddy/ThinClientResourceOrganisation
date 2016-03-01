
define(["console", "page_api", "content_header_api"], function (console, page_api, content_header_api) {


    return {
        "content-header-edit": function (details) {
            page_api.clear_all_messages();
            page_api.disable_view_actions();
            content_header_api.append_editor_to_content_header(details);
        }
    };

});