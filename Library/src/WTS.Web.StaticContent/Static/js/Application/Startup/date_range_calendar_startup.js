require(['date_range', "event"], function(date_range, event) {

    event.listen("click", "#date-range-forward", function () {
        date_range.next_page();

    });

    event.listen("click", "#date-range-back", function () {
        date_range.previous_page();
    });

});