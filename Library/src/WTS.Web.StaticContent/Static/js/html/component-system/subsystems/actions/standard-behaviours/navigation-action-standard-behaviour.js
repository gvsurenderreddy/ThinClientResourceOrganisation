// navigation-action-standard-behaviour 

// Standard behaviour for a navigation action is to load the page for the route request in the navigation action's model.

define( [
        'route_url_builder',
        'page_loader'], 
    function (
        route_url_builder,
        page_loader        
    ) {

    return function ( navigation_action ) {

        // get the url from the route builder and navigate to that page.
        var url = route_url_builder.build( navigation_action.model.route_request );

        page_loader.load( url );
    };
});