define(["console"
       , "underscore"
       , "jquery"
       , "event"
       , "resources"
       , "events_repository"],

function (console, _, $, event, resources, events) {
    console.log("component_system_events");

    var handlers = [];


    event.listen("click", "[data-component] [data-action]", function (target) {
        if (!$(target).closest("[data-component]").parent().closest("[data-component]")[0]) {
            var $action_trigger = $(target);

            var component = $action_trigger.closest("[data-component]").attr("data-component");

            var action = $action_trigger.attr("data-action");

            if ($action_trigger.attr("data-context")) {
                component = $action_trigger.attr("data-context");
            }

            events[component][action](target, handlers);
        }
    });

    event.listen("click", "[data-component] [data-action]", function (target) {
        if ($(target).closest("[data-component]").parent().closest("[data-component]")[0]) {
            var $action_trigger = $(target);

            var inner_component = $action_trigger.closest("[data-component]");

            var inner_component_name = inner_component.attr("data-component");

            var outer_component_name = inner_component.parent().closest("[data-component]").attr("data-component");

            var action = $action_trigger.attr("data-action");

            //A component can have a default action
            //but if we have an action defined in an outer component
            //then prefer that over the default

            if ($action_trigger.attr("data-context")) {
                var component = $action_trigger.attr("data-context");
                events[component][action](target, handlers);
            } else if (events[outer_component_name][action]) {
                events[outer_component_name][action](target, handlers);
            } else {
                events[inner_component_name][action](target, handlers);
            }
        }
    });

    return {
        on_execute_action: function (handler) {
            handlers.push(handler);
        }
    };
});