define(["string_extensions", "guard", "route_repository"], function (string, guard, route_repository) {


    var get_thin_client_absolute_base_url = function() {
        return thin_client_base_url;
    };


    return {


        //Fetches the url after being formatted
        route_url: function (name, obj_params) {

            var route = route_repository.routes[name];


            var url = string.formatWithParams(route, obj_params);
            

            return get_thin_client_absolute_base_url() + url;
        },

        //Fetches the raw route definition without any formatting.
        route_definition: function(name) {
            var route = route_repository.routes[name];


            return get_thin_client_absolute_base_url() + route;
        }




    };
});