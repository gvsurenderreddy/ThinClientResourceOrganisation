define(["jquery", "global"], function ($, window) {


    return {
        current_route_name: function () {
            return $("#page-id").attr("content");
        },
        current_route_params: function () {
            var params = $("#resource-id").attr("content");

            return window.JSON.parse(params);
        }
    };


});