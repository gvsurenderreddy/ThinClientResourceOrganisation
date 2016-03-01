define([ "console"
       , "jquery"
       , "presenter"],

function (console, $, presenter) {
    console.log("shift_calendars_lister_api");

    var shift_calendars_lister_api = function () { };

    shift_calendars_lister_api.prototype.append_editor_to_top_of_shift_calendars_lister = function (details) {
        var header_context = $('#' + details.header_id);
        var action = details.editor_url;

        presenter.get_view({
            url: action,
            on_success: function (content) {
                var editor = $(content);
                header_context.after(editor);
            },
            on_error: function () {
                navigate_to("/Error");
            }
        });
    };

    return new shift_calendars_lister_api();
});