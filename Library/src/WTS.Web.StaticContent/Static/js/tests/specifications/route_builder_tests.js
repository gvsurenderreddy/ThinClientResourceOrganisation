define(['route_builder', 'route_repository'], function (route_builder, routes_helper) {

    var urls = routes_helper.urls;

    var resource_id = routes_helper.resource_id;

    test("Simple Url", function () {

        var url = route_builder.route_url("user-home");
        equal(url, "/", "The home should be built");
    });

    test("Simple Url", function () {
        var url = route_builder.route_url("view-employees");
        equal(url, "/employees/view", "The view employees should be built");
    });

    test("Parameterized Url", function () {
        var url = route_builder.route_url("employee-book", resource_id);
        equal(url, "/employee/4/books/6/data", "A complex Url has been built");
    });

});