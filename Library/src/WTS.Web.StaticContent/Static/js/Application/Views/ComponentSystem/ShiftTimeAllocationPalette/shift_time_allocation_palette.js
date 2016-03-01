define(["console", "page_api"], function (console, page_api) {
    return {
        "shift-time-allocation-palette-remove": function (details) {
            page_api.navigate_to(details.action_url);
        },
        "shift-time-allocation-palette-edit": function (details) {
            page_api.navigate_to(details.action_url);
        }
    };
});