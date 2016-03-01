define(["console", "jquery", "presenter", "controller"],
       function (console, $, presenter, controller) {
           console.log("shift_calendar_api");

           var shift_calendar_api = function () { };

           shift_calendar_api.prototype.replace_shift_calendar_with_an_editor = function (edit_shift_calendar_details) {
               var shift_calendar_context = $('#' + edit_shift_calendar_details.id);
               var edit_shift_calendar_action = edit_shift_calendar_details.action_url;
               var action_data = edit_shift_calendar_details.action_data || null;

               presenter.get_view({
                   url: edit_shift_calendar_action,
                   data: action_data,
                   on_success: function (content) {
                       var editor = $(content);
                       editor.attr("data-shift_calendar-presenter", shift_calendar_context.attr("data-shift_calendar-presenter"));
                       shift_calendar_context.after(editor);
                   },
                   on_error: function () {
                       navigate_to("/Error");
                   }
               });
           };

           shift_calendar_api.prototype.replace_shift_calendar_with_a_read_only_editor = function (remove_shift_calendar_details) {
               var shift_calendar_context = $('#' + remove_shift_calendar_details.id);
               var remove_shift_calendar_action = remove_shift_calendar_details.action_url;
               var action_data = remove_shift_calendar_details.action_data || null;

               presenter.get_view({
                   url: remove_shift_calendar_action,
                   data: action_data,
                   on_success: function (content) {
                       var editor = $(content);
                       editor.attr("data-shift_calendar-presenter", shift_calendar_context.attr("data-shift_calendar-presenter"));
                       shift_calendar_context.after(editor);
                   },
                   on_error: function () {
                       navigate_to("/Error");
                   }
               });
           };

           return new shift_calendar_api();
       }
);