
require([ "console"
        , "component_system_events"
        , "behaviours_repository"],

function (console, base_page_events, behaviours) {
    console.log("component_system");

    base_page_events.on_execute_action(function (name, details) {

        var behaviour = behaviours[name];

        behaviour(details);
    });

});