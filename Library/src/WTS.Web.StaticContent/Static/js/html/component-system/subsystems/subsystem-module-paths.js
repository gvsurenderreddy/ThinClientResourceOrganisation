// Requirejs module paths for subsystems

define([], function () {

    return {
        version: '1.0.0',
        paths: {

            // action modules
            action: 'Static/js/html/component-system/subsystems/actions/action',
            ActionBehaviours: 'Static/js/html/component-system/subsystems/actions/ActionBehaviours',
            action_publisher: 'Static/js/html/component-system/subsystems/actions/action-publisher',
            action_behaviour_repository: 'Static/js/html/component-system/subsystems/actions/action-behaviour-repository',
            standard_action_names: 'Static/js/html/component-system/subsystems/actions/standard_action_names',

            navigation_action_standard_behaviour: 'Static/js/html/component-system/subsystems/actions/standard-behaviours/navigation-action-standard-behaviour',

            // page navigation modules
            page_loader: 'Static/js/html/component-system/subsystems/page-loader',

            // route modules
            route_url_builder: 'Static/js/html/component-system/subsystems/routes/route-url-builder'
        }
    };
});