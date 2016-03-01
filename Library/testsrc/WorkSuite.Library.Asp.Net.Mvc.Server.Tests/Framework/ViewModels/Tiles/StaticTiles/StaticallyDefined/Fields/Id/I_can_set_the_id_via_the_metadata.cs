using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Definitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Helpers;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Tests.Framework.ViewModels.Tiles.StaticTiles.StaticallyDefined.Fields.Id {

    [TestClass]
    public class I_can_set_the_id_via_the_metadata {

        // done: as a static string
        // done: from an expression
        // to do: will be an empty string if not specified

        [TestMethod]
        public void as_a_string () {

            model_metadata_builder
                .id( "an id" )
                ;

            tile.id.Should().Be( "an id" );
        }

        [TestMethod]
        public void from_an_expression () {
            var id = DateTime.Now.Ticks.ToString();

            model_metadata_builder
                .id( () => id )
                ;
        }

        [TestMethod]
        public void will_be_an_empty_string_if_not_specified () {

            tile.id.Should().Be( string.Empty );
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