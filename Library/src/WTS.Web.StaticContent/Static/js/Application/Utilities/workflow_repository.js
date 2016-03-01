define(["jquery", "workflow", "route_builder"], function ($, workflow_data, route_builder) {


    var get_destination_set = function (action_button_element) {
        //Exctract DOM info
        var page_id = $("#page-id").attr("content");
        var action = $(action_button_element).attr("data-action");
        var component_type = $(action_button_element).closest("form").attr("data-type");


        //Get the destination set for the action
        return workflow_data[page_id]
                            [component_type]
                            [action];
    };



    var params_needed = function (destination_route) {
        var route_definition = route_builder.route_definition(destination_route);
        return route_definition.contains("{") && route_definition.contains("}");
    }



    return {
        get_url_for_route: function (route_id, route_params) {

            if (!params_needed(route_id)) {
                route_params = undefined;
            }

            return route_builder.route_url(route_id, route_params);
        },
        get_destination_for_action: function (action_button_element, route_params) {

            var destination_set = get_destination_set(action_button_element);

            //Get a destination(the 1st for now) from the workflow destinations repository
            var destination_route = destination_set.success_destinations[0].route_name;

            //Check if the route needs params

            if (!params_needed(destination_route)) {
                route_params = undefined;
            }

            return route_builder.route_url(destination_route, route_params);
        },

        get_error_destination_for_action: function (action_button_element, route_params) {

            var destination_set = get_destination_set(action_button_element);

            //Get the error destination from the workflow destinations repository
            var destination_route = destination_set.error_destination.route_name;

            //Check if the route needs params

            if (!params_needed(destination_route)) {
                route_params = undefined;
            }

            return route_builder.route_url(destination_route, route_params);
        }
    };

});