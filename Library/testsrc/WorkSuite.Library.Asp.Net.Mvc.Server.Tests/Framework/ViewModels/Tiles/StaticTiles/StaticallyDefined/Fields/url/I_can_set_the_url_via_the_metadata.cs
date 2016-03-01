using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Fields.url {

    [TestClass]
    public class I_can_set_the_url_via_the_metadata {

        // done: as a string 
        // done: as an expression
        // done: is empty if no url has been specified

        [TestMethod]
        public void as_a_string () {
            model_metadata_builder
                .url( "a url" )
                ;

            tile.url.Should().Be( "a url" );
        }

        [TestMethod]
        public void as_an_expression () {
            var url = DateTime.Now.Ticks.ToString();

            model_metadata_builder
                .url( () => url )
                ;

            tile.url.Should().Be( url );
        }

        [TestMethod]
        public void is_empty_if_no_url_has_been_specified () {

            tile.url.Should().NotBeNull();
            tile.url.Should().BeEmpty();
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