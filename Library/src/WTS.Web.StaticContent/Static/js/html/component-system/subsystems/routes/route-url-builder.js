// Route url builder

// Will create a url for a route.  It accepts a route request which contains the route name and any substitution values. 
// The routes will be looked up and a url created by replacing the parameters in the url template with the substition values.
//
// If the route does not exist in the routes table then an error is thrown because

define([ 
        'string_utils',
        'route_table' ],
    function (
        string_ ,
        routes
    ) {


    var FindRouteFailed = function ( message ){
        this.message = message;
    }

    FindRouteFailed.prototype = new Error();


    return {

        build : function ( build_request ) {

            var url_tempate = routes[  build_request.route_name ];

            if ( !url_tempate ) throw new FindRouteFailed( 'Could not find route for route name.' );


            return string_.ReplaceParameters( url_tempate, build_request.route_parameters );
        },
    };

});