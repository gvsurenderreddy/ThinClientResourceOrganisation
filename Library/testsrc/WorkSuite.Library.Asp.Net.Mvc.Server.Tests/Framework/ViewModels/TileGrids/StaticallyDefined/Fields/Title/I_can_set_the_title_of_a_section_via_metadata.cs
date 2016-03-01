using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Fields.Title {


    [TestClass]
    public class I_can_set_the_title_of_a_tile_grid {

        [TestMethod]
        public void tile_grids_can_have_their_title_set_as_a_static_string () {

            metadata_builder
                .title( "A title" )
                ;

            tile_grid.title.Should().Be( "A title" );
        }

        [TestMethod]
        public void tile_grids_can_have_their_title_set_as_via_an_expression () {
            var title = DateTime.Now.Ticks.ToString();

            metadata_builder
                .title(() => title )
                ;

            tile_grid.title.Should().Be( title );
        }

        [TestInitialize]
        public void before_each_test() {
            helper = new StaticTileGridHelper();
        }

        private StaticTileGridMetadataBuilder metadata_builder {
            get { return helper.metadata_builder; }
        }

        private TileGrid tile_grid {
            get { return helper.tile_grid; }
        }

        private StaticTileGridHelper helper;
    }
}