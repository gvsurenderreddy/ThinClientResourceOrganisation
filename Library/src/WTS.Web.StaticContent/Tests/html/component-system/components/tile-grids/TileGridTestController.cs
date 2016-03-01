using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.ViewComponents._1;


namespace WTS.Web.StaticContent.Tests.html.component_system.components.tile_grids
{
    public class TileGridTestController : Controller
    {

        public ActionResult Index()
        {
            var grid_builder = new TileGridViewModelBuilder();
            var section_builder = new TileGridSectionViewModelBuilder();

            return View( 
                @"~/Tests/html/component-system/components/tile-grids/TileGridTestView.cshtml",
                grid_builder
                    .add_section(
                        section_builder
                            .title( "a title" )
                            .add_tile( new DummyViewModel() )
                            .build()
                    )
                    .build()                
            );
        }

        public ActionResult section_tile_markup_is_excluded_if_no_specified () {
            var grid_builder = new TileGridViewModelBuilder();
            var section_builder = new TileGridSectionViewModelBuilder();
            
            return View( 
                @"~/Tests/html/component-system/components/tile-grids/TileGridSectionTitleExcludedTestView.cshtml",
                grid_builder
                    .add_section(
                        section_builder
                            .add_tile( new DummyViewModel() )
                            .build()
                    )
                    .build()
            );            
        }

        public ActionResult multiple_sections_are_rendered () {
            var grid_builder = new TileGridViewModelBuilder();
            var first_section_builder = new TileGridSectionViewModelBuilder();
            var second_section_builder = new TileGridSectionViewModelBuilder();

            return View( 
                @"~/Tests/html/component-system/components/tile-grids/TileGridMultipleSectionsTestView.cshtml",
                grid_builder
                    .add_section(  
                        first_section_builder
                            .title( "Section 1" )
                            .add_tile( new DummyViewModel() )
                            .build()                    
                    )
                    .add_section(  
                        second_section_builder
                            .title(  "Section 2" )
                            .add_tile(  new DummyViewModel() )
                            .build()
                    )
                    .build()
            );
        }

        public ActionResult the_correct_component_is_rendered_in_a_tile () {
            var grid_builder = new TileGridViewModelBuilder();
            var section_builder = new TileGridSectionViewModelBuilder();          
            var tile_view_model_builder = new TileViewModelBuilder();


            return View( 
                @"~/Tests/html/component-system/components/tile-grids/TileGridComponentsAreRenderedCorrectlyTestView.cshtml",

                grid_builder
                    .add_section(
                        section_builder
                            .title( "Section 1" )
                            .add_tile(
                                tile_view_model_builder
                                    .title( "A title" )
                                    .route_name( "route_name" )
                                    .route_parameters( new { param = "1" } )
                                    .build()
                            )
                            .build()
                    )
                    .build()
            );
        }
	}

    public class DummyViewModel
                    : IComponentViewModel { } 
}