using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Subsystems.Routing._1;



namespace WTS.Web.StaticContent.Tests.html.component_system.components.tiles {


    public class TileBootstrapperTestController : Controller {
        //
        // GET: /TileBootstrapperTest/
        public ActionResult Index() {

            var tile_view_model_builder = new TileViewModelBuilder();
            
            return View(  
                @"~/Tests/html/component-system/components/tiles/TileBootstrapperTestView.cshtml",
                tile_view_model_builder
                  .title( "A title" )
                  .route_name( "google" )
                  .build()
            );
        }
	}
}