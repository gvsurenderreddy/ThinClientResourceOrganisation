define([], function () {
    var routes = {
        "user-home": "",
        "view-employees": "employees/view",
        "employee-book": "employee/{employee_id}/books/{book_id}/data"
    };

    var urls = {
        "user-home": "/",
        "view-employees": "/employees/view",
        "employee-book": "/employee/4/books/6/data"
    };

    var resource_id = {
        employee_id: 4,
        book_id: 6
    };


    return {
        routes: routes,
        urls: urls,
        resource_id: resource_id
    };
});


