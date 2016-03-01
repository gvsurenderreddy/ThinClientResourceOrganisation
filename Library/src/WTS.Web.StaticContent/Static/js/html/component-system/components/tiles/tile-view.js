// Api that directly manipulates the DOM both the events and api (which provide the public interface)
// for the component need to access the DOM so rather than having duiplication of code this will provide
// all the manipulation functions which the events and api shall use.

define([
    'jquery',
    'guards',
    'tile_constants'], 
function(
    $,
    guard,
    tile_constants
    ) {

    // checks that the elements is wellformed
    var is_wellformed_tile = function( $_element ) {

        var result = $_element // check that the parameter is not null
                  && $_element.hasClass( tile_constants.tile_class ); // check that it has been identified as a tile component (marked with a class)

        return result;
    };

    // api that wrapps a tile DOM element.
    var TileDomElementApi = function( dom_element ) {
        var $_element = $( dom_element );

        guard.PremiseHolds( is_wellformed_tile( $_element ));


        this.dom_element = dom_element;
        this.$_element = $( dom_element );
    };

    var get_route_request = function ( $_element ) {
    
        guard.IsNotNull( $_element );

        return JSON.parse( $_element.attr("data-route-request") ); 
    };

    // Get the model from the tile DOM object
    // NOTE - We assume that nobody has munkied around with the dom_element and $_element.  These would normally be readonly private fields but we do not have that facility in javascript.
    TileDomElementApi.prototype.get_model = function() {

        return {
            route_request : get_route_request( this.$_element ),
        };
    };


    return {

        // returns the api from the dom element.
        from_element : function( dom_element ) {

            return new TileDomElementApi( dom_element );
        }
    };

});