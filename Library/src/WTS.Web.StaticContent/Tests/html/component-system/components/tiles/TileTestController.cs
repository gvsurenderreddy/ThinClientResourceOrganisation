using System.Web.Mvc;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1;

namespace WTS.Web.StaticContent.Tests.html.components.tiles {

    /// <summary>
    /// Presents the Tile component tests view.  The tests are javascript based and check that the
    /// the semantic classes are present and that the events and api work as expected.
    /// </summary>
    public class TileTestController 
                    : Controller {

        public ActionResult Index () {

            var tile_view_model_builder = new TileViewModelBuilder();

            // These are all javascript tests so the are loaded as script files in the razor view. As such 
            //  we just need to create a view mode with the right data for the component that we are testing
            // and display the view.

            // These test are only supposed to test that we have what we need for the javascript behaviour, styling tests 
            // should be done via so form of browser automation.

            return View(  
                @"~/Tests/html/component-system/components/tiles/TileTestView.cshtml",
                tile_view_model_builder
                  .title( "A title" )
                  .route_name( "route_name" )
                  .route_parameters( new { param = "1" } )
                  .build()
            );
        }

        public ActionResult call_to_action_modifier () {

            var view_model = new [] {
                
                (new TileViewModelBuilder())
                    .title( "Primary" )
                    .route_name( "route_name" )
                    .call_to_action<TileIsAPrimaryCallToAction>()
                    .build(),

                (new TileViewModelBuilder())
                    .title( "Secondary" )
                    .route_name( "route_name" )
                    .call_to_action<TileIsASecondaryCallToAction>()
                    .build(),

                (new TileViewModelBuilder())
                    .title( "Special" )
                    .route_name( "route_name" )
                    .call_to_action<TileIsASpecialCallToAction>()
                    .build(),
            };

            return View( 
                @"~/Tests/html/component-system/components/tiles/TileCallToActionModifierTestView.cshtml",
                view_model
            );
        }
    }
}