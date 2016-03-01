using System.Web.Mvc;
using System.Web.Routing;

namespace WTS.Web.StaticContent {

    public class RouteConfig {

        public static void RegisterRoutes
                            ( RouteCollection routes ) {

            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            // Tiles

            routes
                .MapRoute(
                    name: "title",
                    url: "tile",
                    defaults: new { controller = "TileTest", action = "Index" }
                );

            routes
                .MapRoute(
                    name: "title-call-to-action-modifier",
                    url: "tile/call-to-action-modifier",
                    defaults: new { controller = "TileTest", action = "call_to_action_modifier" }
                );

            routes
                .MapRoute(
                    name: "title-bootstrapper",
                    url: "tile-bootstrapper",
                    defaults: new { controller = "TileBootstrapperTest", action = "Index" }
                );

            // tile-grid

            routes
                .MapRoute(
                    name:  "tile-grid-section-title-markup-excluded",
                    url: "tile-grid/section-tile-markup-excluded",
                    defaults: new { controller = "TileGridTest", action="section_tile_markup_is_excluded_if_no_specified" }
                );

            routes
                .MapRoute(
                    name:  "tile-grid-multiple-sections",
                    url: "tile-grid/multiple-sections",
                    defaults: new { controller = "TileGridTest", action="multiple_sections_are_rendered" }
                );

            routes
                .MapRoute(
                    name:  "tile-grid-components-are-rendered-correctly",
                    url: "tile-grid/components-are-rendered-correctly",
                    defaults: new { controller = "TileGridTest", action="the_correct_component_is_rendered_in_a_tile" }
                );

            routes
                .MapRoute(
                    name:  "tile-grid",
                    url: "tile-grid",
                    defaults: new { controller = "TileGridTest", action="Index" }
                );


            // client side routing
            routes
                .MapRoute(
                    name: "route-url-builder",
                    url: "route-url-builder",
                    defaults: new { controller = "RouteUrlBuilderTest", action = "Index" }
                );


            // standard behaviours

            routes
                .MapRoute(
                    name: "navigation-action-standard-behaviour",
                    url: "navigation-action-standard-behaviour",
                    defaults: new { controller = "NavigationActionStandardBehaviourTest", action = "Index" }
                );
        }
    }
}