using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.TileGrids.StaticallyDefined.Metadata;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.TileGrids.StaticallyDefined.Builder {

    [TestClass]
    public class Allows_multiple_titles_to_be_added {         

        // done: can add multiple tiles
        // done: tiles are order in the order they are added


        [TestMethod]
        public void can_add_multiple_tiles () {

            metadata_builder
                .new_tile()
                .id( "first" )
                .add(  )
                ;

            metadata_builder
                .new_tile()
                .id("second")
                .add()
                ;

            tile_grid.tiles.Should().Contain(t => t.id == "first");
            tile_grid.tiles.Should().Contain(t => t.id == "second");
        }


        [TestMethod]
        public void tiles_are_order_in_the_order_they_are_added () {

            metadata_builder
                .new_tile()
                .id("first")
                .add()
                ;

            metadata_builder
                .new_tile()
                .id("second")
                .add()
                ;

            tile_grid.tiles.First().id.Should().Be("first");
            tile_grid.tiles.Skip(1).First().id.Should().Be("second");
        }

        [TestInitialize]
        public void before_each_test()
        {
            helper = new StaticTileGridHelper();
        }

        private StaticTileGridMetadataBuilder metadata_builder
        {
            get { return helper.metadata_builder; }
        }

        private TileGrid tile_grid
        {
            get { return helper.tile_grid; }
        }

        private StaticTileGridHelper helper;
    }
}