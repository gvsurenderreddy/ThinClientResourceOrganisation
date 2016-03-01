using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Fields.Title {

    [TestClass]
    public class I_can_set_the_title_via_the_metadata {

        // done: as a static string
        // done: from an expression
        // done: will be an empty string if not specified

        [TestMethod]
        public void as_a_static_string () {
            model_metadata_builder
                .title( "A Tile" )
                .build()
                ;

            tile.title.Should().Be( "A Tile" );
        }

        [TestMethod]
        public void from_an_expression () {
            var title = DateTime.Now.Ticks.ToString();

            model_metadata_builder
                .title( () => title )
                ;

            tile.title.Should().Be( title );
        }

        [TestMethod]
        public void will_be_an_empty_string_if_not_specified () {
            tile.title.Should().Be( string.Empty );
        }

        [TestInitialize]
        public void before_each_test () {
            helper = new StaticTileHelper();
        }



        private StaticTileStaticDefinitionBuilder model_metadata_builder {
            get { return helper.model_metadata_builder; }
        }

        private Tile tile {
            get { return helper.tile; }
        }

        private StaticTileHelper helper;

    }
}