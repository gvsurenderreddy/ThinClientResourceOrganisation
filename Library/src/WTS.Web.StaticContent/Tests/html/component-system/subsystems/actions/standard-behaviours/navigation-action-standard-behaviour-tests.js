// navigation-action-standard-behaviour-tests 

require( ['application_boot'], function (){

    require([ 
            'navigation_action_standard_behaviour',
            'route_table',
            'page_loader' ],

        function (
            navigation_action_standard_behaviour,
            routes,
            fake_page_loader
        ) {
            
            // Note - a fake page_loaded is configured in the application boot module

            // done: loads the actions page.
            // done: if the model does not contain a route_request an error is thrown
            // done: if there is not a route defined for the route name an error is thrown

            // {  
            //   action: <action name>,
            //
            //   context: {
            //   },
            //
            //   model : {
            //      route_request : {
            //         route_name: <route name>,
            //         route_parameters: { <substitution values for the route>  }
            //      },
            //   },
            // }


            test( 'loads the actions page.', function (){
            
                var route_name = 'new_page';

                routes[ route_name ] = 'http://www.google.co.uk';

                var action = {

                    model: {
                        route_request: {
                            route_name: route_name,
                        }
                    }
                }

                navigation_action_standard_behaviour( action  );

                ok( fake_page_loader.navigation_requests.indexOf( routes[ route_name ] ) > -1  )
            });


            test( 'if the model does not contain a route_request an error is thrown', function () {
            
                var action = {
                
                    model: {}
                }

                
                throws( function() {  navigation_action_standard_behaviour( action  );  });
            });
            

            test( 'if there is not a route defined for the route name an error is thrown', function () { 

                var action = {
                    
                    model : {
                        route_request: {
                            route_name : 'this route does not exist'
                        }                    
                    }
                };

                throws( function() {  navigation_action_standard_behaviour( action  );  });

            });

        });


});

