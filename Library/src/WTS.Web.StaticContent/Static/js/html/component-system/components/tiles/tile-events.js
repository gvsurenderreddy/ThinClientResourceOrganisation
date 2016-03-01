// hooks the event handlers to a tile component.

// Tile events handlers convert events into actions and then
// publish that actions.

define([
    'jquery',
    'tile_constants',
    'tile_view',
    'standard_action_names',
    'action_publisher'],
function (
    $,
    tile_constants,
    tile_view,
    standard_action_names,
    action_publisher
    ) {

    return {
        version: '1.0.0',

        bind: function () {

            // Improve: use an event binder module for binding as we should probably
            //          be doing this in a uniformed way across all the components.

            // Query: Should the action name come from a constant value or from an attribute on the component.

            // hook the event handler onto the body element because this is intended
            // to be used in an ajax environment so we need the event to work for
            // tiles that are added after the bind has taken place
            $('body').on('click', '.'+tile_constants.tile_class, function () {

                var tile = tile_view.from_element( this );

                var action = {
                    action: standard_action_names.navigation,
                    context: {
                        type: tile_constants.context_type
                    },
                    model: tile.get_model(),
                };

                action_publisher.publish( action );
            });
        }
    };
});