using System.Web.Mvc;
using System.Web.Routing;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Tests
{
    public class RouteConfig
    {
        public static void RegisterRoutes
                                (RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "ViewElements",
                url: "ViewElements",
                defaults: new { controller = "ViewElements", action = "Index" }
            );

            routes.MapRoute(
                name: "Reports",
                url: "Reports",
                defaults: new { controller = "Reports", action = "Index" }
            );

            routes.MapRoute(
                name: "Editors",
                url: "Editors",
                defaults: new { controller = "Editors", action = "Index" }
            );

            routes.MapRoute(
                name: "PageNavigation",
                url: "PageNavigation",
                defaults: new { controller = "PageNavigation", action = "Index" }
            );

            routes.MapRoute(
                name: "Tables",
                url: "Tables",
                defaults: new { controller = "Tables", action = "Index" }
            );

            routes.MapRoute(
                name: "Tiles",
                url: "Tiles",
                defaults: new { controller = "Tiles", action = "Index" }
            );

            routes.MapRoute(
                name: "TileGrids",
                url: "TileGrids",
                defaults: new { controller = "TileGrids", action = "Index" }
            );

            routes.MapRoute(
                name: "ViewModel",
                url: "ViewModel",
                defaults: new { controller = "ViewModel", action = "Index" }
            );

            routes.MapRoute(
                name: "DetailsList",
                url: "DetailsList",
                defaults: new { controller = "DetailsList", action = "Index" }
            );

            routes.MapRoute(
                name: "ContentHeader",
                url: "ContentHeader",
                defaults: new { controller = "ContentHeader", action = "Index" }
            );

            routes.MapRoute(
                name: "ShiftCalendarsLister",
                url: "ShiftCalendarsLister",
                defaults: new { controller = "ShiftCalendarsLister", action = "Index" }
            );

            routes.MapRoute(
                name: "ShiftCalendar",
                url: "ShiftCalendar",
                defaults: new { controller = "ShiftCalendar", action = "Index" }
                );

            routes.MapRoute(
                name: "SimplePalette",
                url: "SimplePalette",
                defaults: new { controller = "SimplePalette", action = "Index" }
            );

            routes.MapRoute(
                name: "StaticContent",
                url: "StaticContent",
                defaults: new { controller = "StaticContent", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "BreadCrumbNavigation",
                url: "BreadCrumbNavigation",
                defaults: new { controller = "BreadCrumbNavigation", action = "Index" }
            );


            routes.MapRoute(
                name: "ColourPickerWithValueMockPresenter",
                url: "ColourPickerWithValueMockPresenter",
                defaults: new { controller = "ColourPicker", action = "PresentSomeValue" }
            );

            routes.MapRoute(
                name: "ColourPickerNullValueMockPresenter",
                url: "ColourPickerNullValueMockPresenter",
                defaults: new { controller = "ColourPicker", action = "PresentNullValue" }
            );

            routes.MapRoute(
                name: "ColourPickerMockController",
                url: "ColourPickerMockController",
                defaults: new { controller = "ColourPicker", action = "Command" }
            );


            // Display table colour.

            routes.MapRoute(
               name: "SelectColourToDisplayInTable",
               url: "SelectColourToDisplayInTable",
               defaults: new { controller = "Tablecolour", action = "SelectColour" }
           );

            routes.MapRoute(
               name: "DisplaySelectedColourInTable",
               url: "DisplaySelectedColourInTable",
               defaults: new { controller = "Tablecolour", action = "DisplayColourInTable" }
           );
        }
    }
}