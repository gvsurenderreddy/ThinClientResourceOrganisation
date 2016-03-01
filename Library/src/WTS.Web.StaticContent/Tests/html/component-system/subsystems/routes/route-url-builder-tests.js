// Test to ensure the route url builder works as expected

require( ['application_boot'], function () {


    require(
            ['route_table'
            , 'route_url_builder' ],
        function (
            routes,
            route_url_builder
        ) {
      
        // done: parameterless templates return the template
        // done: parameters are replaced in the template
        // done: route with partial parameters is not an error, we can not know if that is what is needed the final url
        // done: route with substitute values that do not have parameters is not an error.
        
        // done: It is an error if the route does not exist. 

        test( 'parameterless templates return the template', function( ) {

            var route_name = 'test_route_1';

            routes[ route_name ] = 'http://aroute.com';

            equal( routes[ route_name ], route_url_builder.build( { route_name : route_name }) );
        });

        test( 'parameters are replaced in the template', function () {

            var route_name = 'test_route_2';
            var route_constant = 'http://test route 2/';
            var user_id = 'fred';

            routes[ route_name ] = route_constant + '{user_id}';

            equal(
              route_url_builder.build( { route_name : route_name, route_parameters : { user_id : user_id }} ),
              route_constant + user_id 
            );
        });

        test( 'route with partial parameters is not an error', function () {

            var route_name = 'test_route_3';
            var route_constant = 'http://test route 3/{not_a_parameter}/';
            var user_id = 'fred';

            routes[ route_name ] = route_constant + '{user_id}';

            equal(
              route_url_builder.build( { route_name : route_name, route_parameters : { user_id : user_id }}),
              route_constant + user_id
            );
        });

        test( 'route with substitute values that do not have parameters is not an error.', function ()  {

            var route_name =  'test_route_4';
            var route_constant = 'http://test route 4/';
            var user_id = 'fred';

            routes[ route_name ] =  route_constant + '{user_id}';

            equal(
              route_url_builder.build( { route_name : route_name, route_parameters : { user_id : user_id, spurious_parameter: 'spurious' }}),
              route_constant + user_id 
            );

        });

        test( 'It is an error if the route does not exist', function(){

            throws( 
                function () { route_url_builder.build( { route_name : 'this route does not exit'} ); },
                'Error thrown as expected'
            );
        });
   });
});