using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Fields.Fields {

    [TestClass]
    public class Static_tiles_do_not_support_fields {


        [TestMethod]
        public void Static_tile_fields_is_an_empty_collection() {

            tile.fields.Should().BeEmpty();
        }


        [TestInitialize]
        public void before_each_test()
        {
            helper = new StaticTileHelper();
        }



        private StaticTileStaticDefinitionBuilder model_metadata_builder
        {
            get { return helper.model_metadata_builder; }
        }

        private Tile tile
        {
            get { return helper.tile; }
        }

        private StaticTileHelper helper;

    }

}