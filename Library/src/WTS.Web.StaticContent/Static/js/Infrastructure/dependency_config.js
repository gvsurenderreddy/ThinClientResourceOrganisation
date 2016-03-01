//  Holds all configuration for require js dependency management
define([], function () {
    return {
        shim: {
            //Improve: See https://gist.github.com/jrburke/4037081 to look at this map config thing to achieve proper shimming
            'jquery_sortable': ['jquery'],
            'fullcalendar': ['jquery', 'moment']
        },
        paths: {

            /*******************************STARTUP***********************/
            //Application and page specific startup code
            "startup": "Static/js/Application/Startup/app_startup",
            "sortable_startup": "Static/js/Application/Startup/sortable_startup",
            "date_range_calendar_startup": "Static/js/Application/Startup/date_range_calendar_startup",
            "color_picker_startup": "Static/js/Application/Startup/color_picker_startup",
            "shift_pattern_grid_startup": "Static/js/Application/Startup/shift_pattern_grid_startup",


            /***************************PAGES***************************/

            //Operational Calendar Page
            "operational_calendar": "Static/js/Application/Views/PlannedSupply/operational_calendar",
            "operational_calendar_api": "Static/js/Application/Views/PlannedSupply/operational_calendar_api",

            //Legacy view templates
            "new": "Static/js/Application/Views/Templates/new",
            "remove": "Static/js/Application/Views/Templates/remove",
            "list": "Static/js/Application/Views/Templates/list",
            "details": "Static/js/Application/Views/Templates/details",
            "details_list": "Static/js/Application/Views/Templates/details_list",

            //General
            "page_api": "Static/js/Application/Views/Page/page_api",
            "page_events": "Static/js/Application/Views/Page/page_events",

            /***************************COMPONENTS***************************/

            //Date range calendar component
            "date_range_calendar_events": "Static/js/Application/Views/Components/date_range_calendar/date_range_calendar_events",
            "date_range_calendar_api": "Static/js/Application/Views/Components/date_range_calendar/date_range_calendar_api",

            //Date range bar
            "date_range_bar_events": "Static/js/Application/Views/Components/date_range_bar/date_range_bar_events",

            //Shift pattern grid component
            "shift_pattern_grid_events": "Static/js/Application/Views/Components/shift_pattern_grid/shift_pattern_grid_events",
            "shift_pattern_grid_api": "Static/js/Application/Views/Components/shift_pattern_grid/shift_pattern_grid_api",

            /***************************COMPONENT SYSTEM***************************/
            //base
            "component_system": "Static/js/Application/Views/ComponentSystem/component_system",
            "component_system_events": "Static/js/Application/Views/ComponentSystem/component_system_events",
            "events_repository": "Static/js/Application/Views/ComponentSystem/events_repository",
            "behaviours_repository": "Static/js/Application/Views/ComponentSystem/behaviours_repository",

            //Content Header component (component system)
            "content_header": "Static/js/Application/Views/ComponentSystem/ContentHeader/content_header",
            "content_header_api": "Static/js/Application/Views/ComponentSystem/ContentHeader/content_header_api",
            "content_header_events": "Static/js/Application/Views/ComponentSystem/ContentHeader/content_header_events",

            //Shift calendar component (component system)
            "shift_calendar": "Static/js/Application/Views/ComponentSystem/ShiftCalendar/shift_calendar",
            "shift_calendar_api": "Static/js/Application/Views/ComponentSystem/ShiftCalendar/shift_calendar_api",
            "shift_calendar_events": "Static/js/Application/Views/ComponentSystem/ShiftCalendar/shift_calendar_events",


            // lister component (component system)
            "shift_calendar_lister": "Static/js/Application/Views/ComponentSystem/ShiftCalendarLister/shift_calendar_lister",
            "shift_calendar_lister_api": "Static/js/Application/Views/ComponentSystem/ShiftCalendarLister/shift_calendar_lister_api",
            "shift_calendar_lister_events": "Static/js/Application/Views/ComponentSystem/ShiftCalendarLister/shift_calendar_lister_events",

            //editor component (component system)
            "editor": "Static/js/Application/Views/ComponentSystem/Editor/editor",
            "editor_events": "Static/js/Application/Views/ComponentSystem/Editor/editor_events",

            //white space time allocation palette component (component system)
            "white_space_time_allocation_palette_events": "Static/js/Application/Views/ComponentSystem/WhiteSpaceTimeAllocationPalette/white_space_time_allocation_palette_events",

            //shift time allocation palette component (component system)
            "shift_time_allocation_palette": "Static/js/Application/Views/ComponentSystem/ShiftTimeAllocationPalette/shift_time_allocation_palette",
            "shift_time_allocation_palette_events": "Static/js/Application/Views/ComponentSystem/ShiftTimeAllocationPalette/shift_time_allocation_palette_events",


            /*******************************UTILITIES***********************/
            //Low level application specific code

            "date_range": "Static/js/Application/Utilities/date_range",
            "sortable": "Static/js/Application/Utilities/sortable",
            "resources": "Static/js/Application/Utilities/resources",
            "page_resources": "Static/js/Application/Utilities/page_resources",
            "controller": "Static/js/Application/Utilities/controller",
            "presenter": "Static/js/Application/Utilities/presenter",
            "route_repository": "Static/js/Application/Utilities/route_repository",
            "route_builder": "Static/js/Application/Utilities/route_builder",
            "workflow_repository": "Static/js/Application/Utilities/workflow_repository",
            "feature_degradation": "Static/js/Application/Utilities/feature_degradation",
            "time_allocation_palette_loader": "Static/js/Application/Utilities/time_allocation_palette_loader",

            /*****************************PRIMITIVES**********************/
            //Low level non-application specific bespoke code
            "string_extensions": "Static/js/Primitives/string",
            "global": "Static/js/Primitives/global",
            "console": "Static/js/Primitives/logger",
            "event": "Static/js/Primitives/event",
            "ajax": "Static/js/Primitives/ajax",
            "guard": "Static/js/Primitives/guard",
            "dom": "Static/js/Primitives/dom",
            "modal": "Static/js/Primitives/modal",
            "session_storage": "Static/js/Primitives/session_storage",
            "persistent_storage": "Static/js/Primitives/persistent_storage",
            "random": "Static/js/Primitives/random",
            "callbacks": "Static/js/Primitives/callbacks",

            /****************************LIBRARIES****************************/
            //Low level third party non-application specific off-the-shelf code
            "jquery": "Static/js/library/jquery/jquery-1.10.2",
            "moment": "Static/js/library/moment-js/moment.min",
            "fullcalendar": "Static/js/library/fullcalendar-js/fullcalendar",
            "underscore": "Static/js/library/underscore-js/underscore-min.1.5.1",
            "jqueryeasyModal": "Static/js/library/easyModal/jqueryeasyModal",
            "jquery_sortable": "Static/js/library/jquery-sortable/jquery-sortable"
        }
    };
});