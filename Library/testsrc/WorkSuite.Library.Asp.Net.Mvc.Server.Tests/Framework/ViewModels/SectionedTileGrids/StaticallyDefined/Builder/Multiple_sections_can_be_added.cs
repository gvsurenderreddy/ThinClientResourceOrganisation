using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Builder;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.SectionedTileGrid.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.SectionedTileGrids.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.SectionedTileGrids.StaticallyDefined.Builder {

    [TestClass]
    public class Multiple_sections_can_be_added {         

        // done: can add multiple tiles
        // done: tiles are order in the order they are added


        [TestMethod]
        public void can_add_multiple_tiles () {

            metadata_builder
                .new_section( "first" )
                .add(  )
                ;

            metadata_builder
                .new_section( "second")
                .add()
                ;


            sectioned_tile_grid.sections.Should().Contain(s => s.title == "first");
            sectioned_tile_grid.sections.Should().Contain(s => s.title == "second");
        }


        [TestMethod]
        public void tiles_are_order_in_the_order_they_are_added()
        {

            metadata_builder
                .new_section("first")
                .add()
                ;

            metadata_builder
                .new_section("second")
                .add()
                ;

            sectioned_tile_grid.sections.First().title.Should().Be("first");
            sectioned_tile_grid.sections.Skip(1).First().title.Should().Be("second");
        }


        [TestInitialize]
        public void before_each_test()
        {
            helper = new StaticSectionedTileGridHelper();
        }

        private StaticSectionedTileGridMetadataBuilder metadata_builder
        {
            get { return helper.metadata_builder; }
        }

        private StaticSectionedTileGridBuilder view_model_builder
        {
            get { return helper.view_model_builder; }
        }

        private SectionedTileGrid sectioned_tile_grid
        {
            get { return helper.sectioned_tile_grid; }
        }

        private StaticSectionedTileGridHelper helper;
    }
}