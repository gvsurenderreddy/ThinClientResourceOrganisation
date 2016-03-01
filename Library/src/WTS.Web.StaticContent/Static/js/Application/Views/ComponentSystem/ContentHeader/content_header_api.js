define(["console", "jquery", "presenter", "controller"],
       function (console, $, presenter, controller) {
           console.log("content_header_api");

           var content_header_api = function () { };

           content_header_api.prototype.append_editor_to_content_header = function (details) {
               var content_header_context = $('#' + details.content_header_id);
               var action_url = details.editor_url;

               presenter.get_view({
                   url: action_url,
                   on_success: function (content) {
                       var editor = $(content);
                       content_header_context.after(editor);
                   },
                   on_error: function () {
                       navigate_to("/Error");
                   }
               });
           };

           return new content_header_api();
       }
);