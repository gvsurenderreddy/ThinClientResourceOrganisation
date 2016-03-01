
require(["console", "page_events"], function (console, page_events) {
    console.log("list");

    page_events.on_drill_into_entry(function (entry, page) {

        page.navigate_to(entry.details_url);
    });

});